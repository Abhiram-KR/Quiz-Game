Imports System.Data.SqlClient
Imports System.IO

Public Class Form7
    Private HintsShown As New HashSet(Of Integer)()
    Private QuizCompleted As Boolean = False
    Private AttemptedCount As Integer = 0
    Private currentAttemptID As Integer = 0
    Private ReadOnly pointsPerCorrect As Integer = 10
    Private TotalScore As Integer = 0
    Private CorrectAnswers As Integer = 0
    Private HintsUsed As Integer = 0
    Private currentUser As String
    Private selectedCategory As String
    Private ReadOnly connectionString As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True"
    Private questionIDs As New List(Of Integer)
    Private currentIndex As Integer = 0
    Private loadedOptionIDs As New List(Of Integer)

    ' NEW: track selected option button (toggle behavior)
    Private selectedButton As Button = Nothing

    Public Sub New(user As String, category As String)
        InitializeComponent()
        currentUser = user
        selectedCategory = category
    End Sub
    Private Function LoadImageSafely(bytes As Byte()) As Image
        If bytes Is Nothing OrElse bytes.Length = 0 Then Return Nothing
        Try
            Using ms As New MemoryStream(bytes)
                Using tmp As Image = Image.FromStream(ms, useEmbeddedColorManagement:=False, validateImageData:=True)
                    Return New Bitmap(tmp)
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Sub DisposePictureBoxImage()
        If PictureBox1.Image IsNot Nothing Then
            Dim old = PictureBox1.Image
            PictureBox1.Image = Nothing
            old.Dispose()
        End If
    End Sub

    Private Sub ClearOptions()
        For Each btn As Button In New Button() {OptionButton1, OptionButton2, OptionButton3, OptionButton4}
            btn.Text = ""
            btn.Tag = Nothing
            btn.Visible = True
            btn.Enabled = True
            btn.ForeColor = Color.Black
            btn.BackColor = Color.LightGray    ' default color
            btn.FlatStyle = FlatStyle.Flat
        Next
        selectedButton = Nothing
    End Sub

    Private Sub ResetOptionButtons()
        For Each btn As Button In New Button() {OptionButton1, OptionButton2, OptionButton3, OptionButton4}
            btn.BackColor = Color.LightGray
        Next
        selectedButton = Nothing
    End Sub

    Private Sub UpdateNavButtons()
        RoundButton2.Enabled = (currentIndex > 0)
        RoundButton3.Enabled = (currentIndex < questionIDs.Count - 1)
    End Sub

    Private Sub LoadCategoryQuestions()
        questionIDs.Clear()
        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("
                    SELECT q.QuestionID
                    FROM Questions q
                    INNER JOIN Category c ON q.CategoryID = c.CategoryID
                    WHERE c.CategoryName = @cat
                    ORDER BY q.QuestionID;", con)
                    cmd.Parameters.AddWithValue("@cat", selectedCategory)
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            questionIDs.Add(Convert.ToInt32(reader("QuestionID")))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading questions: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadQuestion(index As Integer)
        If index < 0 OrElse index >= questionIDs.Count Then
            MessageBox.Show("No more questions in this category.")
            Return
        End If

        Dim qid As Integer = questionIDs(index)
        currentIndex = index

        ClearOptions()
        loadedOptionIDs.Clear()
        DisposePictureBoxImage()

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Load Question
                Using cmd As New SqlCommand("
                    SELECT QuestionText, QuestionImage
                    FROM Questions
                    WHERE QuestionID = @id;", con)
                    cmd.Parameters.AddWithValue("@id", qid)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            RoundButton1.Text = If(IsDBNull(rdr("QuestionText")), "", rdr("QuestionText").ToString())
                            If Not IsDBNull(rdr("QuestionImage")) Then
                                Dim bytes = DirectCast(rdr("QuestionImage"), Byte())
                                Dim img = LoadImageSafely(bytes)
                                PictureBox1.Image = img
                                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                            Else
                                PictureBox1.Image = Nothing
                            End If
                        Else
                            MessageBox.Show("Question not found (ID " & qid & ").")
                            Return
                        End If
                    End Using
                End Using

                Using cmdOpt As New SqlCommand("
                    SELECT OptionID, OptionText
                    FROM Options
                    WHERE QuestionID = @id
                    ORDER BY OptionID;", con)
                    cmdOpt.Parameters.AddWithValue("@id", qid)
                    Using rdrOpt = cmdOpt.ExecuteReader()
                        Dim i As Integer = 1
                        While rdrOpt.Read() AndAlso i <= 4
                            Dim optID As Integer = Convert.ToInt32(rdrOpt("OptionID"))
                            Dim text As String = If(IsDBNull(rdrOpt("OptionText")), "", rdrOpt("OptionText").ToString())
                            loadedOptionIDs.Add(optID)

                            Dim btn As Button = Nothing
                            Select Case i
                                Case 1 : btn = OptionButton1
                                Case 2 : btn = OptionButton2
                                Case 3 : btn = OptionButton3
                                Case 4 : btn = OptionButton4
                            End Select

                            If btn IsNot Nothing Then
                                btn.Text = If(String.IsNullOrWhiteSpace(text), "Option " & i.ToString(), text)
                                btn.Tag = optID
                                btn.BackColor = Color.LightGray
                            End If
                            i += 1
                        End While
                    End Using
                End Using
            End Using

            UpdateNavButtons()
            Dim currentQid As Integer = questionIDs(currentIndex)
            RoundButton4.Enabled = (Not QuizCompleted) AndAlso (Not HintsShown.Contains(currentQid))

        Catch ex As Exception
            MessageBox.Show("Error loading question: " & ex.Message)
        End Try
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        RoundButton8.Text = selectedCategory
        Me.WindowState = FormWindowState.Maximized
        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("
                    INSERT INTO QuizAttempts (UserName, StartedAt, TotalScore)
                    VALUES (@user, SYSUTCDATETIME(), @initialScore);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", con)
                    cmd.Parameters.AddWithValue("@user", currentUser)
                    cmd.Parameters.AddWithValue("@initialScore", 0)
                    con.Open()
                    Dim idObj = cmd.ExecuteScalar()
                    If idObj IsNot Nothing Then currentAttemptID = Convert.ToInt32(idObj)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error starting attempt: " & ex.Message)
        End Try
        ToolTip1.SetToolTip(RoundButton2, "Go to Previous Question")
        ToolTip1.SetToolTip(RoundButton3, "Go to Next Question")
        ToolTip1.SetToolTip(RoundButton4, "Click here to see Hint !!")
        ToolTip1.SetToolTip(RoundButton6, "Click here to check the Answer")
        ToolTip1.SetToolTip(RoundButton7, "Click here to save the Answer in the database")
        ToolTip1.SetToolTip(RoundButton5, "Click here to go back to home")

        LoadCategoryQuestions()
        If questionIDs.Count > 0 Then
            LoadQuestion(0)
        Else
            MessageBox.Show("No questions available in this category.")
        End If
    End Sub
    Private Sub QuizGameForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Previous Question: "<" key
        If e.KeyCode = Keys.Oemcomma Then  ' The "<" key is usually Oemcomma
            RoundButton2.PerformClick()
        End If

        ' Next Question: ">" key
        If e.KeyCode = Keys.OemPeriod Then ' The ">" key is usually OemPeriod
            RoundButton3.PerformClick()
        End If
        If e.KeyCode = Keys.H Then
            RoundButton4.PerformClick()
        End If

        If e.KeyCode = Keys.Escape Then
            RoundButton5.PerformClick()
        End If

    End Sub
    Private Sub RoundButton2_Click(sender As Object, e As EventArgs) Handles RoundButton2.Click
        If currentIndex > 0 Then LoadQuestion(currentIndex - 1)
    End Sub

    Private Sub RoundButton3_Click(sender As Object, e As EventArgs) Handles RoundButton3.Click
        If currentIndex < questionIDs.Count - 1 Then LoadQuestion(currentIndex + 1)
    End Sub

    ' --- Option button click (toggle-radio behavior) ---
    Private Sub OptionButton_Click(sender As Object, e As EventArgs) _
        Handles OptionButton1.Click, OptionButton2.Click, OptionButton3.Click, OptionButton4.Click

        Dim btn As Button = DirectCast(sender, Button)

        ' If same button clicked -> deselect
        If selectedButton Is btn Then
            btn.BackColor = Color.LightGray
            selectedButton = Nothing
            Return
        End If

        ' Select new button and unselect previous
        ResetOptionButtons()
        btn.BackColor = Color.SteelBlue
        selectedButton = btn
    End Sub

    ' --- Check Answer ---
    Private Sub RoundButton6_Click(sender As Object, e As EventArgs) Handles RoundButton6.Click
        If selectedButton Is Nothing Then
            MessageBox.Show("Please select an option before submitting.")
            Return
        End If

        If selectedButton.Tag Is Nothing Then
            MessageBox.Show("Option not linked to database.")
            Return
        End If

        Dim qid As Integer = questionIDs(currentIndex)
        Dim optionID As Integer = Convert.ToInt32(selectedButton.Tag)
        Dim isCorrect As Boolean = False
        Dim explanation As String = ""
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' 1) Check selected option correctness and explanation
                Using cmd As New SqlCommand("
                SELECT IsCorrect, ISNULL(Explanation,'') AS Explanation
                FROM Options
                WHERE OptionID = @optid AND QuestionID = @qid;", con)
                    cmd.Parameters.AddWithValue("@optid", optionID)
                    cmd.Parameters.AddWithValue("@qid", qid)
                    Using r = cmd.ExecuteReader()
                        If r.Read() Then
                            isCorrect = Convert.ToBoolean(r("IsCorrect"))
                            explanation = r("Explanation").ToString()
                        End If
                    End Using
                End Using

                ' 2) If incorrect, fetch correct option text + explanation for user feedback
                If Not isCorrect Then
                    Using cmd2 As New SqlCommand("
                    SELECT TOP 1 OptionText, ISNULL(Explanation,'') AS Explanation
                    FROM Options
                    WHERE QuestionID=@qid AND IsCorrect=1;", con)
                        cmd2.Parameters.AddWithValue("@qid", qid)
                        Using r2 = cmd2.ExecuteReader()
                            If r2.Read() Then
                                explanation = "Correct: " & r2("OptionText").ToString() & vbCrLf &
                                          If(String.IsNullOrWhiteSpace(r2("Explanation").ToString()), "No explanation available.", r2("Explanation").ToString())
                            End If
                        End Using
                    End Using
                End If

                ' 3) Retrieve BasePoint for this question (no default of 10)
                Dim basePoint As Integer = 0
                Using cmdBP As New SqlCommand("SELECT BasePoint FROM Questions WHERE QuestionID = @qid;", con)
                    cmdBP.Parameters.AddWithValue("@qid", qid)
                    Dim bpObj = cmdBP.ExecuteScalar()
                    If bpObj IsNot Nothing AndAlso Not IsDBNull(bpObj) Then
                        basePoint = Convert.ToInt32(bpObj)
                    Else
                        ' basePoint remains 0 if DB has NULL or missing value
                    End If
                End Using

                ' 4) Award points based on DB BasePoint
                Dim earnedPoints As Integer = If(isCorrect, basePoint, 0)
                TotalScore += earnedPoints
                If isCorrect Then CorrectAnswers += 1

                ' 5) Save AttemptAnswers row with earned points
                Using ins As New SqlCommand("INSERT INTO AttemptAnswers (AttemptID, QuestionID, SelectedOptionID, IsCorrect, EarnedPoints) VALUES (@att, @qid, @optid, @iscorrect, @points);", con)
                    ins.Parameters.AddWithValue("@att", currentAttemptID)
                    ins.Parameters.AddWithValue("@qid", qid)
                    ins.Parameters.AddWithValue("@optid", optionID)
                    ins.Parameters.AddWithValue("@iscorrect", If(isCorrect, 1, 0))
                    ins.Parameters.AddWithValue("@points", earnedPoints)
                    ins.ExecuteNonQuery()
                End Using

                AttemptedCount += 1

                ' 6) Update running TotalScore in QuizAttempts
                Using up As New SqlCommand("UPDATE QuizAttempts SET TotalScore=@score WHERE AttemptID=@att;", con)
                    up.Parameters.AddWithValue("@score", TotalScore)
                    up.Parameters.AddWithValue("@att", currentAttemptID)
                    up.ExecuteNonQuery()
                End Using
            End Using

            ' Reset selection for the next question (so state doesn't leak)
            selectedButton = Nothing

            Dim dlg As New CustomMessageBox(isCorrect, explanation)
            If dlg.ShowDialog() = DialogResult.OK Then
                If currentIndex < questionIDs.Count - 1 Then
                    LoadQuestion(currentIndex + 1)
                Else
                    StopAndSubmit()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking answer: " & ex.Message)
        End Try
    End Sub


    Private Sub RoundButton5_Click(sender As Object, e As EventArgs) Handles RoundButton5.Click
        ' Go home and close this form fully
        Try
            StopAndSubmit()
        Catch
        End Try

        Dim homeForm As New Form5(currentUser)
        homeForm.Show()
        Me.Close()
    End Sub

    Private Sub RoundButton7_Click(sender As Object, e As EventArgs) Handles RoundButton7.Click
        Dim totalQuestions As Integer = If(questionIDs IsNot Nothing, questionIDs.Count, 0)
        Dim resultForm As New MiniScoreboard(currentUser, TotalScore, CorrectAnswers, HintsUsed, AttemptedCount, totalQuestions)
        resultForm.Show()
    End Sub

    Private Sub StopAndSubmit()
        If QuizCompleted Then Return
        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("UPDATE QuizAttempts SET CompletedAt=SYSUTCDATETIME(), TotalScore=@score WHERE AttemptID=@att;", con)
                    cmd.Parameters.AddWithValue("@score", TotalScore)
                    cmd.Parameters.AddWithValue("@att", currentAttemptID)
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            QuizCompleted = True
            RoundButton4.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error finalizing attempt: " & ex.Message)
        End Try
    End Sub

    Private Function GetHintForQuestion(qid As Integer) As String
        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("
                    SELECT TOP 1 HintText
                    FROM Hints
                    WHERE QuestionID=@qid
                    ORDER BY HintID;", con)
                    cmd.Parameters.AddWithValue("@qid", qid)
                    con.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then Return result.ToString()
                    Return String.Empty
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading hint: " & ex.Message)
            Return String.Empty
        End Try
    End Function

    Private Sub RoundButton4_Click(sender As Object, e As EventArgs) Handles RoundButton4.Click
        If QuizCompleted Then
            MessageBox.Show("Hints are disabled after submitting the quiz.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If questionIDs Is Nothing OrElse questionIDs.Count = 0 Then
            MessageBox.Show("No question loaded.")
            Return
        End If

        Try
            Dim qid As Integer = questionIDs(currentIndex)
            If HintsShown.Contains(qid) Then
                MessageBox.Show("Hint already shown for this question.")
                RoundButton4.Enabled = False
                Return
            End If

            Dim hintText As String = GetHintForQuestion(qid)
            If String.IsNullOrWhiteSpace(hintText) Then
                MessageBox.Show("No hint available for this question.")
                Return
            End If

            MessageBox.Show("Hint: " & vbCrLf & hintText, "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HintsShown.Add(qid)
            HintsUsed += 1
            RoundButton4.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error showing hint: " & ex.Message)
        End Try
    End Sub

    Private Sub Form7_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' ensure we finalize attempt if user closes the form manually
        Try
            StopAndSubmit()
            DisposePictureBoxImage()
        Catch
        End Try
    End Sub
End Class
