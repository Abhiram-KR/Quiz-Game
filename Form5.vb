Imports System.Data.SqlClient

Public Class Form5
    Private currentUser As String

    Public Sub New(Optional txtUser As String = "")
        InitializeComponent()
        currentUser = txtUser
    End Sub
    Private Sub LoadUserControl(uc As UserControl)
        panelMain.Controls.Clear()      ' Remove old content
        uc.Dock = DockStyle.Fill             ' Fill the panel
        panelMain.Controls.Add(uc)      ' Add new page
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        label1.Font = New Font("Tw Cen MT", 24, FontStyle.Bold)

        Dim hour As Integer = DateTime.Now.Hour
        Dim greeting As String

        If hour < 12 Then
            greeting = "🌞 Good Morning"
        ElseIf hour < 16 Then
            greeting = "☀️ Good Afternoon"
        ElseIf hour < 19 Then
            greeting = "🌇 Good Evening"
        Else
            greeting = "🌕 Good Night"
        End If

        label1.Text = $"{greeting}, {currentUser}!"
        label2.Font = New Font("Tw Cen MT", 14, FontStyle.Bold)
        label2.Text = currentUser

        Me.WindowState = FormWindowState.Maximized

        roundButton8.Tag = "General Knowledge"
        RoundButton6.Tag = "Geography"
        RoundButton10.Tag = "History"
        roundButton9.Tag = "Science"
        RoundButton7.Tag = "Animal Kingdom"
        RoundButton11.Tag = "Sports"
        RoundButton12.Tag = "Indian Cultural and Heritage"
        RoundButton13.Tag = "Movies and Comics"
        RoundButton14.Tag = "Literature and Books"

        ToolTip1.SetToolTip(roundButton8, "Test your awareness of the world around you!")
        ToolTip1.SetToolTip(RoundButton6, "Challenge your knowledge of countries, maps, and landmarks.")
        ToolTip1.SetToolTip(RoundButton10, "Explore past events, civilizations, and famous personalities.")
        ToolTip1.SetToolTip(roundButton9, "Discover facts about physics, chemistry, and biology.")
        ToolTip1.SetToolTip(RoundButton7, "Identify animals, their habitats, and unique behaviors.")
        ToolTip1.SetToolTip(RoundButton11, "Test your knowledge of sports, games, and champions.")
        ToolTip1.SetToolTip(RoundButton12, "Dive into the traditions, art, and culture of India.")
        ToolTip1.SetToolTip(RoundButton13, "Answer fun questions about movies, superheroes, and comics.")
        ToolTip1.SetToolTip(RoundButton14, "Check your knowledge of authors, novels, and poetry.")
    End Sub

    Private Sub CategoryButton_Click(sender As Object, e As EventArgs) _
    Handles roundButton8.Click, RoundButton6.Click, RoundButton10.Click,
            roundButton9.Click, RoundButton7.Click, RoundButton11.Click,
            RoundButton12.Click, RoundButton13.Click, RoundButton14.Click
        Dim clickedButton As Button = DirectCast(sender, Button)

        Dim category As String = clickedButton.Tag.ToString()

        Dim questionForm As New Form7(currentUser, category)
        questionForm.Show()
        Me.Hide()
    End Sub



    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        Dim aboutForm As New About()
        aboutForm.ShowDialog()
    End Sub
    Private Sub RoundButton4_Click(sender As Object, e As EventArgs) Handles RoundButton4.Click
        Dim home As New Form1()
        MsgBox("You have been logged out successfully.", MsgBoxStyle.Information, "Logout")
        home.Show()
        Me.Close()
    End Sub

    Private Sub RoundButton2_Click(sender As Object, e As EventArgs) Handles RoundButton2.Click
        Dim home As New Form6()
        home.Show()
    End Sub

    Private Sub RoundButton3_Click(sender As Object, e As EventArgs) Handles RoundButton3.Click
        Dim record As New Record()
        record.Show()
    End Sub
End Class
