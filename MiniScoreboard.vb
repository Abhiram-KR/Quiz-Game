Imports System
Imports System.Linq
Imports System.Windows.Forms

Public Class MiniScoreboard
    Private Score As Integer
    Private Correct As Integer
    Private Hints As Integer
    Private Attempted As Integer
    Private TotalQuestions As Integer
    Private currentUser As String

    ' Parameterless constructor - required for designer and safe initialization
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Parameterized constructor - calls the parameterless ctor to ensure InitializeComponent runs
    Public Sub New(user As String, score As Integer, correct As Integer, hints As Integer, attempted As Integer, totalQuestions As Integer)
        Me.New() ' ensures InitializeComponent() has run
        currentUser = user
        Me.Score = score
        Me.Correct = correct
        Me.Hints = hints
        Me.Attempted = attempted
        Me.TotalQuestions = totalQuestions
    End Sub

    ' Load handler - safe checks for controls, sets text values
    Private Sub MiniScoreboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Friendly message based on score
            If Score > 0 Then
                If Label1 IsNot Nothing Then Label1.Text = "Congratulations! You scored some points!"
            Else
                If Label1 IsNot Nothing Then Label1.Text = "Oops, try again!"
            End If

            ' Score display
            If RoundButton2 IsNot Nothing Then RoundButton2.Text = "Score: " & Score.ToString()

            ' Correct and Attempted
            If RoundButton3 IsNot Nothing Then RoundButton3.Text = "Correct: " & Correct.ToString()
            If RoundButton4 IsNot Nothing Then RoundButton4.Text = "Attempted: " & Attempted.ToString()

            ' Fraction label (optional)
            If Me.Controls.ContainsKey("LabelFraction") Then
                Dim lbl As Label = TryCast(Me.Controls("LabelFraction"), Label)
                If lbl IsNot Nothing Then lbl.Text = $"{Correct} / {TotalQuestions}"
            End If

            ' Hints used (optional label)
            If Me.Controls.ContainsKey("LabelHints") Then
                Dim lblHints As Label = TryCast(Me.Controls("LabelHints"), Label)
                If lblHints IsNot Nothing Then lblHints.Text = $"Hints used: {Hints}"
            Else
                ' fallback: put hints on the form's Title so it's always visible
                Me.Text = $"{Me.Text} - Hints: {Hints}"
            End If
        Catch ex As Exception
            MessageBox.Show("Error while loading scoreboard: " & ex.Message, "Scoreboard Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' Back / Home button -- simplified, safe closing of other forms
    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        Try
            ' Open home form passing currentUser (assumes Form5 has a string constructor)
            Dim homeForm As New Form5(currentUser)
            homeForm.Show()

            ' Close any open instance of Form7 (if present)
            For Each f As Form In Application.OpenForms.OfType(Of Form7)().ToList()
                Try
                    f.Close()
                Catch
                    ' ignore individual close errors
                End Try
            Next

            ' Close the scoreboard (this disposes it)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error while returning home: " & ex.Message, "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class
