Imports System.Data.SqlClient

Public Class Form2
    Dim i As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            signuptxt.PerformClick()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
    End Sub

    ' ---------- Configuration: change these limits as you like ----------
    Private Const USERNAME_MAX As Integer = 30
    Private Const PASSWORD_MIN As Integer = 8
    Private Const PASSWORD_MAX As Integer = 64
    Private Const GMAIL_MAX As Integer = 100
    ' -------------------------------------------------------------------

    ' ✅ Gmail validation helper (keeps your original checks + length)
    Private Function IsValidGmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False

        email = email.Trim()

        ' Basic format parse
        Try
            Dim ma As New Net.Mail.MailAddress(email)
        Catch
            Return False
        End Try

        ' Ensure exactly one '@'
        If email.Count(Function(c) c = "@"c) <> 1 Then
            Return False
        End If

        ' Ensure it ends with @gmail.com (case-insensitive)
        If Not email.ToLower().EndsWith("@gmail.com") Then
            Return False
        End If

        ' Length check
        If email.Length > GMAIL_MAX Then
            Return False
        End If

        Return True
    End Function

    ' Helper to show uniform validation messages
    Private Sub ShowValidation(msg As String)
        MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub signuptxt_Click(sender As Object, e As EventArgs) Handles signuptxt.Click
        Dim username = usertxt.Text?.Trim()
        Dim password1 = passtxt1.Text
        Dim password2 = passtxt2.Text
        Dim email = txtemail.Text?.Trim()

        ' ---------------- Basic validations ----------------
        If String.IsNullOrEmpty(username) Then
            ShowValidation("Username cannot be empty.")
            Return
        End If

        If username.Length > USERNAME_MAX Then
            ' Option A (recommended): Reject and ask user to shorten
            ShowValidation($"Username is too long. Maximum allowed is {USERNAME_MAX} characters.")
            Return

            ' Option B (auto-truncate): Uncomment to automatically truncate instead of rejecting
            ' username = username.Substring(0, USERNAME_MAX)
            ' usertxt.Text = username
        End If

        If String.IsNullOrEmpty(password1) Then
            ShowValidation("Password cannot be empty.")
            Return
        End If

        If password1.Length < PASSWORD_MIN Then
            ShowValidation($"Password too short. Minimum length is {PASSWORD_MIN} characters.")
            Return
        End If

        If password1.Length > PASSWORD_MAX Then
            ShowValidation($"Password is too long. Maximum allowed is {PASSWORD_MAX} characters.")
            Return

            ' Alternative auto-truncate (NOT recommended for passwords)
            ' password1 = password1.Substring(0, PASSWORD_MAX)
            ' passtxt1.Text = password1
            ' password2 = password2.Substring(0, PASSWORD_MAX)
            ' passtxt2.Text = password2
        End If

        If password1 <> password2 Then
            ShowValidation("Passwords do not match.")
            Return
        End If

        If Not IsValidGmail(email) Then
            ShowValidation($"Please enter a valid Gmail address ending with '@gmail.com' and up to {GMAIL_MAX} characters.")
            Return
        End If
        ' ---------------------------------------------------

        Dim con As New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True")

        Try
            con.Open()
            Dim query As String = "INSERT INTO loginapp (username, password, email, Answer1, Answer2, Answer3) VALUES (@username, @password, @email, @A1, @A2, @A3)"
            Dim cmd As New SqlCommand(query, con)

            ' Use typed parameters with explicit sizes to guard against very large strings and DB errors
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, USERNAME_MAX).Value = username
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, PASSWORD_MAX).Value = password1
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, GMAIL_MAX).Value = email

            ' For the security answers, you may also want a max length (here set to 200 each)
            cmd.Parameters.Add("@A1", SqlDbType.NVarChar, 200).Value = If(txtA1.Text?.Trim(), String.Empty)
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar, 200).Value = If(txtA2.Text?.Trim(), String.Empty)
            cmd.Parameters.Add("@A3", SqlDbType.NVarChar, 200).Value = If(txtA3.Text?.Trim(), String.Empty)

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim loginForm As New Form1()
                loginForm.Show()
                Me.Close()
            Else
                MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        Catch ex As SqlException
            If ex.Number = 2627 Or ex.Number = 2601 Then
                ' Duplicate entry
                MessageBox.Show("This username or gmail id already exists. Please choose a different one.", "Duplicate Entry", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub backtxt_Click(sender As Object, e As EventArgs) Handles backtxt.Click
        Dim loginForm As New Form1()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub checkBox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox1.CheckedChanged
        passtxt1.PasswordChar = If(checkBox1.Checked, ChrW(0), "•"c)
    End Sub

    Private Sub checkBox2_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox2.CheckedChanged
        passtxt2.PasswordChar = If(checkBox2.Checked, ChrW(0), "•"c)
    End Sub
End Class
