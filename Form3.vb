Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Windows.Forms

Public Class Form3
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    ' Helper: Strict Gmail validator
    Private Function IsValidGmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False

        email = email.Trim()

        ' Basic format check using MailAddress (throws if invalid)
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

        Return True
    End Function

    Private Sub sendmail_Click(sender As Object, e As EventArgs) Handles sendmail.Click
        Dim email As String = txtemail.Text.Trim()
        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Please enter an email address.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate the recipient email is a proper Gmail address
        If Not IsValidGmail(email) Then
            MessageBox.Show("Please enter a valid Gmail address that ends with '@gmail.com'.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connectionString As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True"

        Using con As New SqlConnection(connectionString)
            Try
                con.Open()

                ' Check if email exists and optionally get username
                Using cmd As New SqlCommand("SELECT Username FROM loginapp WHERE Email = @Email", con)
                    cmd.Parameters.AddWithValue("@Email", email)
                    Dim usernameObj As Object = cmd.ExecuteScalar()
                    If usernameObj Is Nothing Then
                        MessageBox.Show("Email not found in our records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Generate OTP and expiry in UTC (cryptographically stronger RNG recommended for higher security)
                Dim rnd As New Random()
                Dim generatedOTP As String = rnd.Next(10000, 99999).ToString() ' 5-digit numeric OTP
                Dim expiryUtc As DateTime = DateTime.UtcNow.AddMinutes(10) ' UTC

                ' Save OTP and expiry (as UTC) in DB using proper SqlDbType
                Using upd As New SqlCommand("UPDATE loginapp SET OTP = @OTP, OTPExpiry = @Expiry, IsOTPUsed = 0 WHERE Email = @Email", con)
                    upd.Parameters.AddWithValue("@OTP", generatedOTP)
                    Dim p As New SqlParameter("@Expiry", SqlDbType.DateTime2)
                    p.Value = expiryUtc
                    upd.Parameters.Add(p)
                    upd.Parameters.AddWithValue("@Email", email)
                    upd.ExecuteNonQuery()
                End Using

                Try
                    ' --- Configure these for your Gmail account ---
                    Dim senderEmail As String = "quizgamealvas@gmail.com"
                    Dim smtpPassword As String = "mxqh ynjm gidc dnze" ' 

                    Dim messageBody As String = $"Your password reset code is: {generatedOTP}{Environment.NewLine}This code will expire at {expiryUtc.ToLocalTime():f} (local time) - valid for 10 minutes."

                    Using message As New MailMessage()
                        message.From = New MailAddress(senderEmail, "Quiz Game app Support")
                        message.To.Add(email)
                        message.Subject = "Password Reset Code"
                        message.Body = messageBody
                        message.IsBodyHtml = False

                        Using smtp As New SmtpClient("smtp.gmail.com", 587)
                            smtp.EnableSsl = True
                            smtp.Credentials = New NetworkCredential(senderEmail, smtpPassword)
                            smtp.Send(message)
                        End Using
                    End Using

                    MessageBox.Show("Email sent successfully. Please check your inbox.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to send email." & vbCrLf & ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If con.State = ConnectionState.Open Then con.Close()
            End Try
        End Using
    End Sub

    Private Sub verify_Click(sender As Object, e As EventArgs) Handles verify.Click
        Dim enteredOtp As String = txtotp.Text.Trim()
        Dim email As String = txtemail.Text.Trim()

        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(enteredOtp) Then
            MessageBox.Show("Please provide both email and OTP.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate email again before DB ops
        If Not IsValidGmail(email) Then
            MessageBox.Show("Please enter a valid Gmail address that ends with '@gmail.com'.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connectionString As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True"

        Using con As New SqlConnection(connectionString)
            con.Open()
            Using cmd As New SqlCommand("SELECT OTP, OTPExpiry, IsOTPUsed FROM loginapp WHERE Email = @Email", con)
                cmd.Parameters.AddWithValue("@Email", email)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim dbOtp As String = ""
                        If Not IsDBNull(reader("OTP")) Then
                            dbOtp = reader("OTP").ToString()
                        End If

                        Dim expiryFromDb As DateTime = DateTime.MinValue
                        If Not IsDBNull(reader("OTPExpiry")) Then
                            expiryFromDb = Convert.ToDateTime(reader("OTPExpiry"))
                            ' Mark the DateTime as UTC so comparisons are correct
                            expiryFromDb = DateTime.SpecifyKind(expiryFromDb, DateTimeKind.Utc)
                        End If

                        Dim isUsed As Boolean = False
                        If Not IsDBNull(reader("IsOTPUsed")) Then
                            Dim raw = reader("IsOTPUsed")
                            Try
                                isUsed = Convert.ToBoolean(raw)
                            Catch
                                isUsed = (Convert.ToInt32(raw) <> 0)
                            End Try
                        End If

                        If isUsed Then
                            MessageBox.Show("This OTP has already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        ' Compare using UTC
                        If DateTime.UtcNow > expiryFromDb Then
                            MessageBox.Show("This OTP has expired. Please request a new one.", "OTP Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If

                        If enteredOtp = dbOtp Then
                            reader.Close()
                            ' Mark OTP as used
                            Using upd As New SqlCommand("UPDATE loginapp SET IsOTPUsed = 1 WHERE Email = @Email", con)
                                upd.Parameters.AddWithValue("@Email", email)
                                upd.ExecuteNonQuery()
                            End Using

                            MessageBox.Show("OTP Verified! You may now reset your password.", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Dim resetForm As New Form4(email)
                            resetForm.Show()
                            Me.Hide()
                        Else
                            MessageBox.Show("Incorrect OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Email not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        Dim loginForm As New Form1()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub RoundButton2_Click(sender As Object, e As EventArgs) Handles RoundButton2.Click
        Me.Close()
    End Sub

    Private Sub verify2_Click(sender As Object, e As EventArgs) Handles verify2.Click
        Dim connectionString As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True"

        Using con As New SqlConnection(connectionString)
            Try
                con.Open()
                Dim cmd As New SqlCommand("SELECT Answer1, Answer2, Answer3 FROM loginapp WHERE Email = @Email", con)
                cmd.Parameters.AddWithValue("@Email", txtemail2.Text.Trim())

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    Dim a1 As String = If(Not reader.IsDBNull(0), reader.GetString(0).Trim().ToLower(), "")
                    Dim a2 As String = If(Not reader.IsDBNull(1), reader.GetString(1).Trim().ToLower(), "")
                    Dim a3 As String = If(Not reader.IsDBNull(2), reader.GetString(2).Trim().ToLower(), "")

                    If a1 = txtans1.Text.Trim().ToLower() AndAlso
                       a2 = txtans2.Text.Trim().ToLower() AndAlso
                       a3 = txtans3.Text.Trim().ToLower() Then

                        reader.Close()
                        Dim resetForm As New Form4(txtemail2.Text.Trim())
                        resetForm.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("One or more answers are incorrect.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Email not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub
End Class
