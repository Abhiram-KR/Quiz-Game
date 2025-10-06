Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms

Public Class Form8
    ' Connection string - MARS optional but not required since reader usage is safe.
    Private connString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
    Private selectedQuestionId As Integer = -1

    ' Mapping of category ids to names (fixed list)
    Private ReadOnly CategoryMap As New Dictionary(Of Integer, String) From {
        {1, "General Knowledge"},
        {2, "Geography"},
        {3, "History"},
        {4, "Science"},
        {5, "Animal Kingdom"},
        {6, "Sports"},
        {7, "Indian Cultural and Heritage"},
        {8, "Movies and Comics"},
        {9, "Literature and Books"}
    }

    ' Flag to avoid recursive selection-change events while syncing the two combos
    Private isSyncingCategoryCombos As Boolean = False

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Try
            ' DataGridView visual settings - conservative, traditional
            If dgvQuestions IsNot Nothing Then
                dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                dgvQuestions.MultiSelect = False
                dgvQuestions.ReadOnly = True
                dgvQuestions.AllowUserToAddRows = False
                dgvQuestions.AllowUserToDeleteRows = False
                dgvQuestions.RowHeadersVisible = False
            End If

            ' default points - leave blank so blank means "not pre-set"
            If txtBasePoint IsNot Nothing Then txtBasePoint.Text = ""

            ' Populate Category combos (ID -> 1..9, Name -> fixed list)
            If cboCategoryID IsNot Nothing And cboCategoryName IsNot Nothing Then
                isSyncingCategoryCombos = True
                cboCategoryID.Items.Clear()
                For i As Integer = 1 To 9
                    cboCategoryID.Items.Add(i)
                Next

                cboCategoryName.Items.Clear()
                For Each kvp In CategoryMap
                    cboCategoryName.Items.Add(kvp.Value)
                Next

                ' sensible default
                cboCategoryID.SelectedItem = 1
                cboCategoryName.SelectedItem = CategoryMap(1)
                isSyncingCategoryCombos = False
            End If

            LoadUserCount()
            LoadQuestions()
            ClearEditor()
        Catch ex As Exception
            MessageBox.Show("Error during startup: " & ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim dt As New DataTable()

            Using con As New SqlConnection(connString)
                con.Open()

                Dim sql As String =
                "SELECT Username, Email " &
                "FROM loginapp " &
                "ORDER BY Username"

                Using cmd As New SqlCommand(sql, con)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            dgvUsers.DataSource = dt

            ' Friendly headers
            If dgvUsers.Columns.Contains("Username") Then dgvUsers.Columns("Username").HeaderText = "Username"
            If dgvUsers.Columns.Contains("Email") Then dgvUsers.Columns("Email").HeaderText = "Email / Gmail"

            ' Layout
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            If dgvUsers.Columns.Contains("Username") Then dgvUsers.Columns("Username").Width = 150
            If dgvUsers.Columns.Contains("Email") Then dgvUsers.Columns("Email").Width = 250

            dgvUsers.ReadOnly = True
            dgvUsers.AllowUserToAddRows = False
            dgvUsers.AllowUserToDeleteRows = False
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvUsers.MultiSelect = False
            dgvUsers.RowHeadersVisible = False
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Load Users", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Convert Image -> bytes safely (clone then save)
    Private Function ImageToBytes(img As Image) As Byte()
        If img Is Nothing Then Return Nothing
        Try
            Using clone As New Bitmap(img)
                Using ms As New MemoryStream()
                    clone.Save(ms, Imaging.ImageFormat.Png)
                    Return ms.ToArray()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Image conversion failed: " & ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End Try
    End Function

    ' Convert bytes -> Image safely (validate and clone)
    Private Function BytesToImage(bytes As Byte()) As Image
        If bytes Is Nothing OrElse bytes.Length = 0 Then Return Nothing
        Try
            Using ms As New MemoryStream(bytes)
                Using orig As Image = Image.FromStream(ms, useEmbeddedColorManagement:=True, validateImageData:=True)
                    Return New Bitmap(orig)
                End Using
            End Using
        Catch ex As Exception
            ' Write to temp file for debugging (optional)
            Try
                Dim fn = IO.Path.Combine(IO.Path.GetTempPath(), $"dbg_img_{DateTime.Now:yyyyMMdd_HHmmss}.bin")
                IO.File.WriteAllBytes(fn, bytes)
                Debug.WriteLine("BytesToImage failed; wrote raw bytes to: " & fn)
            Catch
                ' ignore write errors
            End Try

            MessageBox.Show("Could not convert bytes to image: " & ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End Try
    End Function

    ' Browse and load image (clone immediately to avoid file lock)
    Private Sub btnBrowseImage_Click(sender As Object, e As EventArgs) Handles btnBrowseImage.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Using tempImg As Image = Image.FromFile(ofd.FileName)
                        picQuestionImage.Image = New Bitmap(tempImg)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Could not load image: " & ex.Message, "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnRemoveImage_Click(sender As Object, e As EventArgs) Handles btnRemoveImage.Click
        picQuestionImage.Image = Nothing
    End Sub

    Private Sub ClearEditor()
        selectedQuestionId = -1
        txtQuestion.Text = ""
        txtHint.Text = ""
        txtOption1.Text = ""
        txtOption2.Text = ""
        txtOption3.Text = ""
        txtOption4.Text = ""
        txtExp1.Text = ""
        txtExp2.Text = ""
        txtExp3.Text = ""
        txtExp4.Text = ""
        rdoOpt1.Checked = False
        rdoOpt2.Checked = False
        rdoOpt3.Checked = False
        rdoOpt4.Checked = False
        picQuestionImage.Image = Nothing

        ' leave points blank = "not pre-set"
        If txtBasePoint IsNot Nothing Then txtBasePoint.Text = ""

        ' reset category combos to default
        If cboCategoryID IsNot Nothing And cboCategoryName IsNot Nothing Then
            isSyncingCategoryCombos = True
            cboCategoryID.SelectedItem = 1
            cboCategoryName.SelectedItem = CategoryMap(1)
            isSyncingCategoryCombos = False
        End If

        If dgvQuestions.DataSource IsNot Nothing Then
            dgvQuestions.ClearSelection()
        End If
    End Sub

    ''' <summary>
    ''' Loads list of questions. Joins Category to show CategoryName and includes only QuestionID, Text, Category, BasePoint.
    ''' Shows runtime default of 10 for BasePoint in the grid when DB has NULL.
    ''' </summary>
    Private Sub LoadQuestions()
        Dim dt As New DataTable()
        Using con As New SqlConnection(connString)
            Using cmd As New SqlCommand("
            SELECT q.QuestionID,
                   q.QuestionText,
                   ISNULL(c.CategoryName, '') AS CategoryName,
                   q.BasePoint
            FROM Questions q
            LEFT JOIN Category c ON q.CategoryID = c.CategoryID
            ORDER BY q.QuestionID ASC", con)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        dgvQuestions.DataSource = dt

        ' Keep QuestionID visible and sized
        If dgvQuestions.Columns.Contains("QuestionID") Then
            dgvQuestions.Columns("QuestionID").Visible = True
            dgvQuestions.Columns("QuestionID").Width = 60
            dgvQuestions.Columns("QuestionID").Frozen = True
        End If

        ' Make QuestionText fill the grid nicely
        If dgvQuestions.Columns.Contains("QuestionText") Then
            dgvQuestions.Columns("QuestionText").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        ' Set CategoryName fixed width
        If dgvQuestions.Columns.Contains("CategoryName") Then
            dgvQuestions.Columns("CategoryName").Width = 150
        End If

        ' Set BasePoint small width
        If dgvQuestions.Columns.Contains("BasePoint") Then
            dgvQuestions.Columns("BasePoint").Width = 80
        End If

        dgvQuestions.ClearSelection()
    End Sub

    Private Sub LoadUserCount()
        Using con As New SqlConnection(connString)
            Using cmd As New SqlCommand("SELECT COUNT(1) FROM loginapp", con)
                con.Open()
                Dim cnt As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                lblTotalUsers.Text = $"Total users: {cnt}"
            End Using
        End Using
    End Sub

    ' Use SelectionChanged to react to row selection (robust)
    Private Sub dgvQuestions_SelectionChanged(sender As Object, e As EventArgs) Handles dgvQuestions.SelectionChanged
        If dgvQuestions.SelectedRows Is Nothing OrElse dgvQuestions.SelectedRows.Count = 0 Then Return
        Dim row As DataGridViewRow = dgvQuestions.SelectedRows(0)
        If row Is Nothing OrElse row.Cells("QuestionID").Value Is Nothing Then Return

        Try
            selectedQuestionId = Convert.ToInt32(row.Cells("QuestionID").Value)
            LoadQuestionDetails(selectedQuestionId)
        Catch ex As Exception
            ' ignore conversion errors
        End Try
    End Sub

    Private Sub dgvQuestions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuestions.CellClick
        If e.RowIndex < 0 Then Return
        Try
            Dim row As DataGridViewRow = dgvQuestions.Rows(e.RowIndex)
            If row Is Nothing OrElse row.Cells("QuestionID").Value Is Nothing Then Return
            selectedQuestionId = Convert.ToInt32(row.Cells("QuestionID").Value)
            LoadQuestionDetails(selectedQuestionId)
        Catch ex As Exception
            ' ignore
        End Try
    End Sub

    ''' <summary>
    ''' Loads details of a question including hints, options and explanations.
    ''' This version reads values into locals while reader is open, then uses them afterwards.
    ''' Shows BasePoint from DB if present (>0), otherwise shows runtime default 10.
    ''' </summary>
    Private Sub LoadQuestionDetails(selectedQuestionId As Integer)
        Using con As New SqlConnection(connString)
            con.Open()

            ' Local holders
            Dim catId As Integer = 0
            Dim imgBytes As Byte() = Nothing

            ' Load question row
            Using cmdQ As New SqlCommand("SELECT QuestionText, CategoryID, BasePoint, QuestionImage FROM Questions WHERE QuestionID = @id", con)
                cmdQ.Parameters.AddWithValue("@id", selectedQuestionId)
                Using rdr As SqlDataReader = cmdQ.ExecuteReader()
                    If rdr.Read() Then
                        ' QuestionText
                        Dim ordQ = rdr.GetOrdinal("QuestionText")
                        txtQuestion.Text = If(rdr.IsDBNull(ordQ), "", rdr.GetString(ordQ))

                        ' CategoryID (read into local)
                        If rdr.FieldCount > 1 Then
                            Dim ordCat = rdr.GetOrdinal("CategoryID")
                            If Not rdr.IsDBNull(ordCat) Then
                                catId = rdr.GetInt32(ordCat)
                            End If
                        End If

                        ' BasePoint: show DB value if present and >0, otherwise runtime default of 10
                        If rdr.FieldCount > 2 Then
                            Dim ordBase = rdr.GetOrdinal("BasePoint")
                            If Not rdr.IsDBNull(ordBase) AndAlso txtBasePoint IsNot Nothing Then
                                Dim dbBase As Integer = 0
                                If Integer.TryParse(rdr(ordBase).ToString(), dbBase) Then
                                    If dbBase > 0 Then
                                        txtBasePoint.Text = dbBase.ToString()
                                    Else
                                        txtBasePoint.Text = "10"
                                    End If
                                Else
                                    txtBasePoint.Text = "10"
                                End If
                            ElseIf txtBasePoint IsNot Nothing Then
                                ' DB had no value -> runtime default
                                txtBasePoint.Text = "10"
                            End If
                        End If

                        ' QuestionImage read into local bytes if present
                        Dim imgOrd As Integer = -1
                        Try
                            imgOrd = rdr.GetOrdinal("QuestionImage")
                        Catch ex As IndexOutOfRangeException
                            imgOrd = -1
                        End Try

                        If imgOrd >= 0 AndAlso Not rdr.IsDBNull(imgOrd) Then
                            imgBytes = CType(rdr(imgOrd), Byte())
                        End If
                    End If
                End Using

                ' Now the reader is closed; safe to call other DB helpers or set combos
            End Using

            ' Set category combos from catId (safe)
            If catId > 0 Then
                Dim catName = GetCategoryNameById(catId, con)
                isSyncingCategoryCombos = True
                If CategoryMap.ContainsKey(catId) Then
                    cboCategoryID.SelectedItem = catId
                    cboCategoryName.SelectedItem = CategoryMap(catId)
                Else
                    cboCategoryID.SelectedItem = Nothing
                    cboCategoryName.SelectedItem = If(String.IsNullOrWhiteSpace(catName), Nothing, catName)
                End If
                isSyncingCategoryCombos = False
            Else
                isSyncingCategoryCombos = True
                cboCategoryID.SelectedItem = 1
                cboCategoryName.SelectedItem = CategoryMap(1)
                isSyncingCategoryCombos = False
            End If

            ' Set image from bytes if present
            If imgBytes IsNot Nothing Then
                picQuestionImage.Image = BytesToImage(imgBytes)
            Else
                picQuestionImage.Image = Nothing
            End If

            ' Load hint
            Using cmdH As New SqlCommand("SELECT TOP 1 HintText FROM Hints WHERE QuestionID = @qid ORDER BY HintID", con)
                cmdH.Parameters.AddWithValue("@qid", selectedQuestionId)
                Dim hintObj = cmdH.ExecuteScalar()
                txtHint.Text = If(hintObj IsNot Nothing AndAlso Not Convert.IsDBNull(hintObj), hintObj.ToString(), "")
            End Using

            ' Load options and explanations
            Using cmdO As New SqlCommand("SELECT OptionText, IsCorrect, Explanation FROM Options WHERE QuestionID = @qid ORDER BY OptionID", con)
                cmdO.Parameters.AddWithValue("@qid", selectedQuestionId)
                Using da As New SqlDataAdapter(cmdO)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Reset options + explanations
                    txtOption1.Text = "" : txtExp1.Text = "" : rdoOpt1.Checked = False
                    txtOption2.Text = "" : txtExp2.Text = "" : rdoOpt2.Checked = False
                    txtOption3.Text = "" : txtExp3.Text = "" : rdoOpt3.Checked = False
                    txtOption4.Text = "" : txtExp4.Text = "" : rdoOpt4.Checked = False

                    For i As Integer = 0 To Math.Min(3, dt.Rows.Count - 1)
                        Dim optText As String = If(dt.Rows(i).IsNull("OptionText"), "", dt.Rows(i)("OptionText").ToString())
                        Dim isCorrect As Boolean = If(dt.Rows(i).IsNull("IsCorrect"), False, Convert.ToBoolean(dt.Rows(i)("IsCorrect")))
                        Dim explanation As String = If(dt.Rows(i).IsNull("Explanation"), "", dt.Rows(i)("Explanation").ToString())

                        Select Case i
                            Case 0
                                txtOption1.Text = optText
                                rdoOpt1.Checked = isCorrect
                                txtExp1.Text = explanation
                            Case 1
                                txtOption2.Text = optText
                                rdoOpt2.Checked = isCorrect
                                txtExp2.Text = explanation
                            Case 2
                                txtOption3.Text = optText
                                rdoOpt3.Checked = isCorrect
                                txtExp3.Text = explanation
                            Case 3
                                txtOption4.Text = optText
                                rdoOpt4.Checked = isCorrect
                                txtExp4.Text = explanation
                        End Select
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim qText As String = txtQuestion.Text.Trim()
        Dim hintText As String = txtHint.Text.Trim()

        If String.IsNullOrEmpty(qText) Then
            MessageBox.Show("Please enter the question text.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim options As String() = {txtOption1.Text.Trim(), txtOption2.Text.Trim(), txtOption3.Text.Trim(), txtOption4.Text.Trim()}
        Dim explanations As String() = {txtExp1.Text.Trim(), txtExp2.Text.Trim(), txtExp3.Text.Trim(), txtExp4.Text.Trim()}

        Dim correctIndex As Integer = If(rdoOpt1.Checked, 0, If(rdoOpt2.Checked, 1, If(rdoOpt3.Checked, 2, If(rdoOpt4.Checked, 3, -1))))
        If correctIndex < 0 Then
            MessageBox.Show("Please select the correct option.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Determine if admin provided a base point value. If left blank -> store DBNull (not pre-set).
        Dim basePointObj As Object = DBNull.Value
        If txtBasePoint IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtBasePoint.Text) Then
            Dim parsedBase As Integer
            If Integer.TryParse(txtBasePoint.Text.Trim(), parsedBase) Then
                basePointObj = parsedBase
            Else
                MessageBox.Show("Base points must be a valid integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If
        Try
            Using con As New SqlConnection(connString)
                con.Open()
                Using tran As SqlTransaction = con.BeginTransaction()
                    Try
                        ' Determine category id from combos
                        Dim categoryIdObj As Object = DBNull.Value
                        If cboCategoryID IsNot Nothing AndAlso cboCategoryID.SelectedItem IsNot Nothing Then
                            categoryIdObj = Convert.ToInt32(cboCategoryID.SelectedItem)
                        ElseIf cboCategoryName IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cboCategoryName.Text) Then
                            Dim selectedName = cboCategoryName.Text.Trim()
                            Dim found = CategoryMap.FirstOrDefault(Function(k) k.Value.Equals(selectedName, StringComparison.OrdinalIgnoreCase))
                            If found.Key <> 0 Then
                                categoryIdObj = found.Key
                            Else
                                categoryIdObj = GetOrCreateCategoryId(selectedName, con, tran)
                            End If
                        End If

                        Dim newQid As Integer
                        Using cmdQ As New SqlCommand("INSERT INTO Questions (CategoryID, QuestionText, BasePoint, QuestionImage) OUTPUT INSERTED.QuestionID VALUES(@catId, @text, @base, @img)", con, tran)
                            If categoryIdObj Is DBNull.Value Then
                                cmdQ.Parameters.AddWithValue("@catId", DBNull.Value)
                            Else
                                cmdQ.Parameters.AddWithValue("@catId", categoryIdObj)
                            End If
                            cmdQ.Parameters.AddWithValue("@text", qText)

                            ' base: either DBNull or the provided int
                            If basePointObj Is DBNull.Value Then
                                cmdQ.Parameters.AddWithValue("@base", DBNull.Value)
                            Else
                                cmdQ.Parameters.AddWithValue("@base", Convert.ToInt32(basePointObj))
                            End If

                            Dim imgBytes = ImageToBytes(picQuestionImage.Image)
                            If imgBytes Is Nothing Then
                                cmdQ.Parameters.AddWithValue("@img", DBNull.Value)
                            Else
                                cmdQ.Parameters.Add("@img", SqlDbType.VarBinary).Value = imgBytes
                            End If

                            newQid = Convert.ToInt32(cmdQ.ExecuteScalar())
                        End Using

                        If Not String.IsNullOrWhiteSpace(hintText) Then
                            Using cmdH As New SqlCommand("INSERT INTO Hints (QuestionID, HintText) VALUES(@qid, @hint)", con, tran)
                                cmdH.Parameters.AddWithValue("@qid", newQid)
                                cmdH.Parameters.AddWithValue("@hint", hintText)
                                cmdH.ExecuteNonQuery()
                            End Using
                        End If

                        For i As Integer = 0 To 3
                            Using cmdO As New SqlCommand("INSERT INTO Options (QuestionID, OptionText, IsCorrect, Explanation) VALUES(@qid, @opt, @isCorrect, @exp)", con, tran)
                                cmdO.Parameters.AddWithValue("@qid", newQid)
                                cmdO.Parameters.AddWithValue("@opt", If(String.IsNullOrWhiteSpace(options(i)), "", options(i)))
                                cmdO.Parameters.AddWithValue("@isCorrect", If(i = correctIndex, 1, 0))
                                cmdO.Parameters.AddWithValue("@exp", If(String.IsNullOrWhiteSpace(explanations(i)), DBNull.Value, explanations(i)))
                                cmdO.ExecuteNonQuery()
                            End Using
                        Next

                        tran.Commit()
                        MessageBox.Show("Question added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        tran.Rollback()
                        MessageBox.Show("Error adding question: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LoadQuestions()
        ClearEditor()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedQuestionId <= 0 Then
            MessageBox.Show("Select a question to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim qText As String = txtQuestion.Text.Trim()
        Dim hintText As String = txtHint.Text.Trim()

        If String.IsNullOrEmpty(qText) Then
            MessageBox.Show("Please enter the question text.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim options As String() = {txtOption1.Text.Trim(), txtOption2.Text.Trim(), txtOption3.Text.Trim(), txtOption4.Text.Trim()}
        Dim explanations As String() = {txtExp1.Text.Trim(), txtExp2.Text.Trim(), txtExp3.Text.Trim(), txtExp4.Text.Trim()}

        Dim correctIndex As Integer = If(rdoOpt1.Checked, 0, If(rdoOpt2.Checked, 1, If(rdoOpt3.Checked, 2, If(rdoOpt4.Checked, 3, -1))))
        If correctIndex < 0 Then
            MessageBox.Show("Please select the correct option.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Determine if admin provided a base point value. If left blank -> store DBNull (not pre-set).
        Dim basePointObj As Object = DBNull.Value
        If txtBasePoint IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtBasePoint.Text) Then
            Dim parsedBase As Integer
            If Integer.TryParse(txtBasePoint.Text.Trim(), parsedBase) Then
                basePointObj = parsedBase
            Else
                MessageBox.Show("Base points must be a valid integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If
        Try
            Using con As New SqlConnection(connString)
                con.Open()
                Using tran As SqlTransaction = con.BeginTransaction()
                    Try
                        ' Determine category id from combos
                        Dim categoryIdObj As Object = DBNull.Value
                        If cboCategoryID IsNot Nothing AndAlso cboCategoryID.SelectedItem IsNot Nothing Then
                            categoryIdObj = Convert.ToInt32(cboCategoryID.SelectedItem)
                        ElseIf cboCategoryName IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cboCategoryName.Text) Then
                            Dim selectedName = cboCategoryName.Text.Trim()
                            Dim found = CategoryMap.FirstOrDefault(Function(k) k.Value.Equals(selectedName, StringComparison.OrdinalIgnoreCase))
                            If found.Key <> 0 Then
                                categoryIdObj = found.Key
                            Else
                                categoryIdObj = GetOrCreateCategoryId(selectedName, con, tran)
                            End If
                        End If

                        Using cmdQ As New SqlCommand("UPDATE Questions SET CategoryID=@catId, QuestionText=@text, BasePoint=@base, QuestionImage=@img WHERE QuestionID=@id", con, tran)
                            If categoryIdObj Is DBNull.Value Then
                                cmdQ.Parameters.AddWithValue("@catId", DBNull.Value)
                            Else
                                cmdQ.Parameters.AddWithValue("@catId", categoryIdObj)
                            End If
                            cmdQ.Parameters.AddWithValue("@text", qText)

                            If basePointObj Is DBNull.Value Then
                                cmdQ.Parameters.AddWithValue("@base", DBNull.Value)
                            Else
                                cmdQ.Parameters.AddWithValue("@base", Convert.ToInt32(basePointObj))
                            End If

                            Dim imgBytes = ImageToBytes(picQuestionImage.Image)
                            If imgBytes Is Nothing Then
                                cmdQ.Parameters.AddWithValue("@img", DBNull.Value)
                            Else
                                cmdQ.Parameters.Add("@img", SqlDbType.VarBinary).Value = imgBytes
                            End If

                            cmdQ.Parameters.AddWithValue("@id", selectedQuestionId)
                            cmdQ.ExecuteNonQuery()
                        End Using

                        Using delH As New SqlCommand("DELETE FROM Hints WHERE QuestionID = @qid", con, tran)
                            delH.Parameters.AddWithValue("@qid", selectedQuestionId)
                            delH.ExecuteNonQuery()
                        End Using

                        If Not String.IsNullOrWhiteSpace(hintText) Then
                            Using insH As New SqlCommand("INSERT INTO Hints (QuestionID, HintText) VALUES(@qid, @hint)", con, tran)
                                insH.Parameters.AddWithValue("@qid", selectedQuestionId)
                                insH.Parameters.AddWithValue("@hint", hintText)
                                insH.ExecuteNonQuery()
                            End Using
                        End If

                        Using del As New SqlCommand("DELETE FROM Options WHERE QuestionID = @qid", con, tran)
                            del.Parameters.AddWithValue("@qid", selectedQuestionId)
                            del.ExecuteNonQuery()
                        End Using

                        For i As Integer = 0 To 3
                            Using cmdO As New SqlCommand("INSERT INTO Options (QuestionID, OptionText, IsCorrect, Explanation) VALUES(@qid, @opt, @isCorrect, @exp)", con, tran)
                                cmdO.Parameters.AddWithValue("@qid", selectedQuestionId)
                                cmdO.Parameters.AddWithValue("@opt", If(String.IsNullOrWhiteSpace(options(i)), "", options(i)))
                                cmdO.Parameters.AddWithValue("@isCorrect", If(i = correctIndex, 1, 0))
                                cmdO.Parameters.AddWithValue("@exp", If(String.IsNullOrWhiteSpace(explanations(i)), DBNull.Value, explanations(i)))
                                cmdO.ExecuteNonQuery()
                            End Using
                        Next

                        tran.Commit()
                        MessageBox.Show("Question updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        tran.Rollback()
                        MessageBox.Show("Error updating question: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LoadQuestions()
        ClearEditor()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Prefer an ID entered in the small delete box; if empty fall back to selectedQuestionId
        Dim idText As String = ""
        If txtDeleteQuestionID IsNot Nothing Then idText = txtDeleteQuestionID.Text.Trim()

        Dim qid As Integer = 0
        If Not String.IsNullOrWhiteSpace(idText) Then
            If Not Integer.TryParse(idText, qid) Then
                MessageBox.Show("Please enter a valid numeric Question ID to delete.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Else
            ' if user didn't type an ID, use the currently selected row
            If selectedQuestionId > 0 Then
                qid = selectedQuestionId
            Else
                MessageBox.Show("Please either select a question from the list or enter a Question ID to delete.", "No Question Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

        ' Confirm deletion
        Dim confirm = MessageBox.Show($"Are you sure you want to permanently delete Question ID {qid} and all its data? This cannot be undone.", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using con As New SqlConnection(connString)
                con.Open()

                ' Check if question exists
                Using cmdCheck As New SqlCommand("SELECT COUNT(1) FROM Questions WHERE QuestionID = @qid", con)
                    cmdCheck.Parameters.AddWithValue("@qid", qid)
                    Dim existsCount As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                    If existsCount = 0 Then
                        MessageBox.Show($"Question with ID {qid} was not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using

                Using tran As SqlTransaction = con.BeginTransaction()
                    Try
                        ' Delete dependent rows first
                        Using delO As New SqlCommand("DELETE FROM Options WHERE QuestionID = @qid", con, tran)
                            delO.Parameters.AddWithValue("@qid", qid)
                            delO.ExecuteNonQuery()
                        End Using

                        Using delH As New SqlCommand("DELETE FROM Hints WHERE QuestionID = @qid", con, tran)
                            delH.Parameters.AddWithValue("@qid", qid)
                            delH.ExecuteNonQuery()
                        End Using

                        ' Finally delete the questions row
                        Using delQ As New SqlCommand("DELETE FROM Questions WHERE QuestionID = @qid", con, tran)
                            delQ.Parameters.AddWithValue("@qid", qid)
                            delQ.ExecuteNonQuery()
                        End Using

                        tran.Commit()
                        MessageBox.Show($"Question ID {qid} and its related data have been deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh grid and clear editor
                        LoadQuestions()
                        ClearEditor()
                    Catch ex As Exception
                        tran.Rollback()
                        MessageBox.Show("Error deleting question: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error while deleting: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearEditor()
    End Sub

    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        Dim loginForm As New Form1()
        loginForm.Show()
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Helper: Given a category name, return its CategoryID. If it does not exist, create it (within the same connection/transaction).
    ''' </summary>
    Private Function GetOrCreateCategoryId(categoryName As String, con As SqlConnection, Optional tran As SqlTransaction = Nothing) As Integer
        If String.IsNullOrWhiteSpace(categoryName) Then Throw New ArgumentException("categoryName required")

        Using cmd As New SqlCommand("SELECT CategoryID FROM Category WHERE CategoryName = @name", con, If(tran IsNot Nothing, tran, Nothing))
            cmd.Parameters.AddWithValue("@name", categoryName)
            Dim obj = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not Convert.IsDBNull(obj) Then
                Return Convert.ToInt32(obj)
            End If
        End Using

        Using cmdIns As New SqlCommand("INSERT INTO Category (CategoryName) OUTPUT INSERTED.CategoryID VALUES(@name)", con, If(tran IsNot Nothing, tran, Nothing))
            cmdIns.Parameters.AddWithValue("@name", categoryName)
            Dim newId = Convert.ToInt32(cmdIns.ExecuteScalar())
            Return newId
        End Using
    End Function

    Private Function GetCategoryNameById(catId As Integer, con As SqlConnection) As String
        Using cmd As New SqlCommand("SELECT CategoryName FROM Category WHERE CategoryID = @id", con)
            cmd.Parameters.AddWithValue("@id", catId)
            Dim obj = cmd.ExecuteScalar()
            Return If(obj IsNot Nothing AndAlso Not Convert.IsDBNull(obj), obj.ToString(), "")
        End Using
    End Function

    Private Sub RoundButton3_Click(sender As Object, e As EventArgs) Handles RoundButton3.Click
        Me.Close()
    End Sub

    ' Show by ID handler
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim idText As String = ""
        If txtShowQuestionID IsNot Nothing Then idText = txtShowQuestionID.Text.Trim()
        Dim qid As Integer
        If Integer.TryParse(idText, qid) Then
            For Each row As DataGridViewRow In dgvQuestions.Rows
                If row.Cells("QuestionID").Value IsNot Nothing AndAlso Convert.ToInt32(row.Cells("QuestionID").Value) = qid Then
                    row.Selected = True
                    dgvQuestions.CurrentCell = row.Cells(0)
                    selectedQuestionId = qid
                    LoadQuestionDetails(qid)
                    Return
                End If
            Next

            Try
                LoadQuestionDetails(qid)
                selectedQuestionId = qid
            Catch ex As Exception
                MessageBox.Show("Could not find question with ID: " & qid, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Else
            MessageBox.Show("Enter a valid Question ID to show.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Sync category combos both ways
    Private Sub cboCategoryID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategoryID.SelectedIndexChanged
        If isSyncingCategoryCombos Then Return
        Try
            isSyncingCategoryCombos = True
            If cboCategoryID.SelectedItem IsNot Nothing Then
                Dim id As Integer = Convert.ToInt32(cboCategoryID.SelectedItem)
                If CategoryMap.ContainsKey(id) Then
                    cboCategoryName.SelectedItem = CategoryMap(id)
                Else
                    cboCategoryName.SelectedItem = Nothing
                End If
            End If
        Finally
            isSyncingCategoryCombos = False
        End Try
    End Sub

    Private Sub cboCategoryName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategoryName.SelectedIndexChanged
        If isSyncingCategoryCombos Then Return
        Try
            isSyncingCategoryCombos = True
            If cboCategoryName.SelectedItem IsNot Nothing Then
                Dim selName As String = cboCategoryName.SelectedItem.ToString()
                Dim found = CategoryMap.FirstOrDefault(Function(k) k.Value = selName)
                If found.Key <> 0 Then
                    cboCategoryID.SelectedItem = found.Key
                Else
                    cboCategoryID.SelectedItem = Nothing
                End If
            End If
        Finally
            isSyncingCategoryCombos = False
        End Try
    End Sub

    Private Sub txtBasePoint_TextChanged(sender As Object, e As EventArgs) Handles txtBasePoint.TextChanged

    End Sub
End Class
