Imports System.Windows.Forms

Public Class AdminLogin
    Inherits Form
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
        TextBox1.UseSystemPasswordChar = True
        TextBox1.MaxLength = 4
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim entered As String = TextBox1.Text.Trim()

            If String.IsNullOrEmpty(entered) Then
                MessageBox.Show("Please enter the 4-digit password.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If Globals.AdminPhoneSuffixes.Contains(entered) Then
                MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()
                Dim adminForm As New Form8()
                adminForm.Show()
                Me.DialogResult = DialogResult.OK   ' tell Sub Main login succeeded
                Me.Close()
            Else
                MessageBox.Show("Incorrect password. Try again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
