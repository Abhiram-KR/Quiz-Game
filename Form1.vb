Imports System.Data.SqlClient
Public Class Form1
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox1.CheckedChanged
        txtPass.PasswordChar = If(checkBox1.Checked, ChrW(0), "•"c)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        Dim registerForm As New Form2()
        registerForm.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel2.LinkClicked
        Dim forgotPasswordForm As New Form3()
        forgotPasswordForm.Show()
        Me.Hide()
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            RoundButton1.PerformClick()
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
    End Sub

    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        Try
            Using con As New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True")
                con.Open()
                Dim query As String = "SELECT COUNT(*) FROM loginapp WHERE username=@username AND password=@password"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@username", txtUser.Text)
                    cmd.Parameters.AddWithValue("@password", txtPass.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK)
                        Dim loginForm As New Form5(txtUser.Text)
                        loginForm.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.RetryCancel)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error connecting to database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RoundButton2_Click(sender As Object, e As EventArgs) Handles RoundButton2.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim adminForm As New AdminLogin()
        adminForm.Show()
        Me.Hide()
    End Sub
End Class

