Imports System.Data.SqlClient

Public Class Form4
    Private ReadOnly useremail As String

    Public Sub New(email As String)
        InitializeComponent()
        useremail = If(email, String.Empty)
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    ' BACK button handler -- returns to Form3 (forgot password)
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles RoundButton2.Click
        Dim forgot As New Form3()
        forgot.Show()
        Me.Close()
    End Sub

    ' DONE button handler -- update username/password and go to login
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        ' Basic validation
        If String.IsNullOrWhiteSpace(usersetxt.Text) OrElse
           String.IsNullOrWhiteSpace(passetxt1.Text) OrElse
           String.IsNullOrWhiteSpace(passetxt2.Text) Then

            MessageBox.Show("Please fill in all fields.", "Input required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If passetxt1.Text <> passetxt2.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(useremail) Then
            MessageBox.Show("Internal error: user email is missing. Please go back and retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Update the user record safely
        Dim connString As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True"
        Dim sql As String = "UPDATE loginapp SET username = @username, password = @password WHERE Email = @Email"

        Try
            Using con As New SqlConnection(connString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@username", usersetxt.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", passetxt1.Text)        ' Consider hashing instead of storing plain text
                    cmd.Parameters.AddWithValue("@Email", useremail.Trim())

                    con.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Username and Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim loginForm As New Form1()
                        loginForm.Show()
                        Me.Close()
                    Else
                        MessageBox.Show("Update failed. No matching user found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub checkBox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox1.CheckedChanged
        passetxt1.PasswordChar = If(checkBox1.Checked, ChrW(0), "•"c)
    End Sub

    Private Sub checkBox2_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox2.CheckedChanged
        passetxt2.PasswordChar = If(checkBox2.Checked, ChrW(0), "•"c)
    End Sub
End Class
