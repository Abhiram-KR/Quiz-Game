Imports System.Data
Imports System.Data.SqlClient
Public Class Record
    Private connString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True"
    Private Sub Record_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRecords()
        StyleGrid()
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub LoadRecords()
        Dim dt As New DataTable()

        Dim query As String = "
            SELECT 
                qa.AttemptID,
                qa.UserName,
                ISNULL(c.CategoryName, 'Unknown') AS CategoryName,
                SUM(CASE WHEN aa.IsCorrect = 1 THEN 1 ELSE 0 END) AS CorrectCount,
                SUM(CASE WHEN aa.IsCorrect = 0 THEN 1 ELSE 0 END) AS WrongCount,
                qa.CompletedAt,
                qa.TotalScore
            FROM QuizAttempts qa
            LEFT JOIN AttemptAnswers aa ON qa.AttemptID = aa.AttemptID
            LEFT JOIN Questions q ON aa.QuestionID = q.QuestionID
            LEFT JOIN Category c ON q.CategoryID = c.CategoryID
            GROUP BY qa.AttemptID, qa.UserName, c.CategoryName, qa.CompletedAt, qa.TotalScore
            ORDER BY qa.CompletedAt DESC, qa.AttemptID DESC
        "

        Try
            Using con As New SqlConnection(connString)
                Using cmd As New SqlCommand(query, con)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            ' Ensure CompletedAt shows readable string even if DB value is null
            If Not dt.Columns.Contains("CompletedAtDisplay") Then
                dt.Columns.Add("CompletedAtDisplay", GetType(String))
            End If

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row("CompletedAt")) Then
                    Dim dtCompleted As DateTime
                    If DateTime.TryParse(row("CompletedAt").ToString(), dtCompleted) Then
                        row("CompletedAtDisplay") = dtCompleted.ToString("dd-MM-yyyy HH:mm:ss")
                    Else
                        row("CompletedAtDisplay") = row("CompletedAt").ToString()
                    End If
                Else
                    ' If CompletedAt is missing, fallback to StartedAt if present
                    row("CompletedAtDisplay") = "—"
                End If
            Next

            ' Bind to grid and show selected columns (make ordering clear)
            DataGridView1.DataSource = dt

            ' Optionally hide raw CompletedAt and AttemptID columns and show nicer column order
            If DataGridView1.Columns.Contains("AttemptID") Then
                DataGridView1.Columns("AttemptID").HeaderText = "Attempt ID"
                DataGridView1.Columns("AttemptID").DisplayIndex = 0
            End If
            If DataGridView1.Columns.Contains("UserName") Then
                DataGridView1.Columns("UserName").HeaderText = "User Name"
                DataGridView1.Columns("UserName").DisplayIndex = 1
            End If
            If DataGridView1.Columns.Contains("CategoryName") Then
                DataGridView1.Columns("CategoryName").HeaderText = "Category"
                DataGridView1.Columns("CategoryName").DisplayIndex = 2
            End If
            If DataGridView1.Columns.Contains("CorrectCount") Then
                DataGridView1.Columns("CorrectCount").HeaderText = "Correct"
                DataGridView1.Columns("CorrectCount").DisplayIndex = 3
            End If
            If DataGridView1.Columns.Contains("WrongCount") Then
                DataGridView1.Columns("WrongCount").HeaderText = "Wrong"
                DataGridView1.Columns("WrongCount").DisplayIndex = 4
            End If
            ' Show formatted CompletedAtDisplay column
            If DataGridView1.Columns.Contains("CompletedAtDisplay") Then
                DataGridView1.Columns("CompletedAtDisplay").HeaderText = "Completed (Date & Time)"
                DataGridView1.Columns("CompletedAtDisplay").DisplayIndex = 5
            End If
            If DataGridView1.Columns.Contains("TotalScore") Then
                DataGridView1.Columns("TotalScore").HeaderText = "Total Score"
                DataGridView1.Columns("TotalScore").DisplayIndex = 6
            End If

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub StyleGrid()
        ' Traditional, clean visuals: simple selection and read-only grid
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToOrderColumns = False
        DataGridView1.AllowUserToResizeRows = False
    End Sub
    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        Me.Close()
    End Sub
    Private Sub FormRecords_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ' Refresh records each time user returns to this form
        LoadRecords()
    End Sub
End Class