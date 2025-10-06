' FormFeedback.vb
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Text

Public Class Form6
    Inherits System.Windows.Forms.Form
    Private lblTitle As Label
    Private lblName As Label
    Private txtName As TextBox
    Private lblEmail As Label
    Private txtEmail As TextBox
    Private lblRating As Label
    Private numRating As NumericUpDown
    Private lblComments As Label
    Private txtComments As TextBox
    Private btnSubmit As Button
    Private btnSend As Button
    Private btnCancel As Button
    Private lblStatus As Label

    Private dgvFeedback As DataGridView
    Private btnLoad As Button

    Private Const SenderGmail As String = "quizgamealvas@gmail.com"
    Private Const SenderAppPassword As String = "mxqh ynjm gidc dnze"

    Private ReadOnly connStr As String = "Data Source=.\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True"

    Public Sub New()
        InitializeComponent()
        SetupFeedbackForm()
    End Sub

    Private Sub SetupFeedbackForm()
        Me.Text = "User Feedback"
        Me.Size = New Drawing.Size(720, 560)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent

        lblTitle = New Label() With {
            .Text = "We value your feedback",
            .Font = New Drawing.Font("Segoe UI", 12.0!, Drawing.FontStyle.Bold),
            .AutoSize = True,
            .Location = New Drawing.Point(18, 14)
        }

        lblName = New Label() With {.Text = "Name *", .Location = New Drawing.Point(18, 56), .AutoSize = True}
        txtName = New TextBox() With {.Location = New Drawing.Point(120, 52), .Width = 560}

        lblEmail = New Label() With {.Text = "Email", .Location = New Drawing.Point(18, 92), .AutoSize = True}
        txtEmail = New TextBox() With {.Location = New Drawing.Point(120, 88), .Width = 560}

        lblRating = New Label() With {.Text = "Rating (1-5) *", .Location = New Drawing.Point(18, 128), .AutoSize = True}
        numRating = New NumericUpDown() With {.Location = New Drawing.Point(120, 124), .Minimum = 1, .Maximum = 5, .Value = 5, .Width = 60}

        lblComments = New Label() With {.Text = "Comments *", .Location = New Drawing.Point(18, 164), .AutoSize = True}
        txtComments = New TextBox() With {
            .Location = New Drawing.Point(120, 160),
            .Size = New Drawing.Size(560, 140),
            .Multiline = True,
            .ScrollBars = ScrollBars.Vertical,
            .MaxLength = 4000
        }

        btnSubmit = New Button() With {.Text = "Submit (Save to DB)", .Location = New Drawing.Point(120, 320), .Width = 140}
        AddHandler btnSubmit.Click, AddressOf BtnSubmit_Click
        ToolTip1.SetToolTip(btnSubmit, "The Feedback will save in the database and will not send to the admin gmail")
        btnSend = New Button() With {.Text = "Send (Email)", .Location = New Drawing.Point(280, 320), .Width = 120}
        AddHandler btnSend.Click, AddressOf BtnSend_Click
        ToolTip1.SetToolTip(btnSend, "The Feedback will send to the admin gmail and will not saved in the database")
        btnCancel = New Button() With {.Text = "Cancel", .Location = New Drawing.Point(420, 320), .Width = 120}
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click

        btnLoad = New Button() With {.Text = "Load Feedback", .Location = New Drawing.Point(560, 320), .Width = 120}
        AddHandler btnLoad.Click, AddressOf BtnLoad_Click

        lblStatus = New Label() With {.Text = "", .Location = New Drawing.Point(18, 360), .AutoSize = True, .ForeColor = Drawing.Color.DarkGreen}

        dgvFeedback = New DataGridView() With {
            .Location = New Drawing.Point(18, 392),
            .Size = New Drawing.Size(662, 140),
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }

        Me.Controls.AddRange(New Control() {
            lblTitle, lblName, txtName, lblEmail, txtEmail, lblRating, numRating,
            lblComments, txtComments, btnSubmit, btnSend, btnCancel, btnLoad,
            lblStatus, dgvFeedback
        })
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs)
        lblStatus.Text = ""

        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter your name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtComments.Text) Then
            MessageBox.Show("Please enter your comments.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComments.Focus()
            Return
        End If

        Dim name As String = txtName.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim rating As Integer = Convert.ToInt32(numRating.Value)
        Dim comments As String = txtComments.Text.Trim()
        Dim timestamp As DateTime = DateTime.Now ' required by your schema (datetime NOT NULL)

        Try
            SaveFeedbackToDatabase(name, email, rating, comments, timestamp)
            lblStatus.ForeColor = Drawing.Color.DarkGreen
            lblStatus.Text = "Thank you! Your feedback has been saved to the database."

            ' Clear form
            txtName.Text = ""
            txtEmail.Text = ""
            numRating.Value = 5
            txtComments.Text = ""
        Catch ex As Exception
            lblStatus.ForeColor = Drawing.Color.DarkRed
            lblStatus.Text = "Error saving feedback: " & ex.Message
        End Try
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs)
        lblStatus.Text = ""
        If String.IsNullOrWhiteSpace(txtName.Text) Or String.IsNullOrWhiteSpace(txtComments.Text) Then
            MessageBox.Show("Please enter name and comments before sending.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            SendFeedbackEmail(txtName.Text.Trim(), txtEmail.Text.Trim(), Convert.ToInt32(numRating.Value), txtComments.Text.Trim())
            lblStatus.ForeColor = Drawing.Color.DarkGreen
            lblStatus.Text = "Email sent successfully."
        Catch ex As Exception
            lblStatus.ForeColor = Drawing.Color.DarkRed
            lblStatus.Text = "Error sending email: " & ex.Message
        End Try
    End Sub

    Private Sub SendFeedbackEmail(name As String, email As String, rating As Integer, comments As String)
        Dim smtp As SmtpClient = Nothing
        Dim mail As MailMessage = Nothing

        Try
            mail = New MailMessage()
            mail.From = New MailAddress(SenderGmail)
            mail.To.Add(SenderGmail)
            mail.Subject = "New User Feedback"
            mail.Body = $"Feedback Received:{Environment.NewLine}" &
                        $"Timestamp: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{Environment.NewLine}" &
                        $"Name: {name}{Environment.NewLine}" &
                        $"User Email: {email}{Environment.NewLine}" &
                        $"Rating: {rating}{Environment.NewLine}" &
                        $"Comments: {comments}"

            If Not String.IsNullOrWhiteSpace(email) Then
                Try
                    mail.ReplyToList.Add(New MailAddress(email))
                Catch
                    ' ignore invalid reply-to
                End Try
            End If

            smtp = New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.Credentials = New Net.NetworkCredential(SenderGmail, SenderAppPassword)
            smtp.EnableSsl = True
            smtp.Send(mail)
        Finally
            If mail IsNot Nothing Then mail.Dispose()
            If smtp IsNot Nothing Then smtp.Dispose()
        End Try
    End Sub
    Private Sub SaveFeedbackToDatabase(name As String, email As String, rating As Integer, comments As String, timestamp As DateTime)
        Dim sql As String =
            "INSERT INTO Feedback ([Timestamp], [Name], [Email], [Rating], [Comments]) " &
            "VALUES (@ts, @name, @email, @rating, @comments)"

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@ts", SqlDbType.DateTime).Value = timestamp
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name
                    If String.IsNullOrWhiteSpace(email) Then
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 150).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 150).Value = email
                    End If
                    cmd.Parameters.Add("@rating", SqlDbType.Int).Value = rating
                    cmd.Parameters.Add("@comments", SqlDbType.NVarChar, -1).Value = comments ' -1 = MAX

                    Dim rows As Integer = cmd.ExecuteNonQuery()
                    If rows = 0 Then
                        Throw New ApplicationException("Insert executed but no rows were affected.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database insert error: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs)
        lblStatus.Text = ""
        Try
            Dim dt As DataTable = LoadFeedbackFromDatabase()
            dgvFeedback.DataSource = dt
            lblStatus.ForeColor = Drawing.Color.DarkGreen
            lblStatus.Text = $"Loaded {If(dt IsNot Nothing, dt.Rows.Count, 0)} rows."
        Catch ex As Exception
            lblStatus.ForeColor = Drawing.Color.DarkRed
            lblStatus.Text = "Error loading feedback: " & ex.Message
        End Try
    End Sub

    Private Function LoadFeedbackFromDatabase() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim sql As String = "SELECT FeedbackID, [Timestamp], [Name], [Email], [Rating], [Comments] FROM Feedback ORDER BY FeedbackID DESC"
            Using da As New SqlDataAdapter(sql, conn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
