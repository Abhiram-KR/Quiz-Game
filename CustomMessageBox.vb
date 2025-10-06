Imports System.Reflection.Emit
Public Class CustomMessageBox
    Private ReadOnly _isCorrect As Boolean
    Private ReadOnly _explanation As String

    Public Sub New(isCorrect As Boolean, explanation As String)
        InitializeComponent()
        _isCorrect = isCorrect
        _explanation = If(String.IsNullOrWhiteSpace(explanation),
                          "No explanation available.",
                          explanation)
    End Sub

    Private Sub CustomMessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Title + Icon
        Label1.Text = If(_isCorrect, "Correct Answer", "Wrong Answer")

        ' If you added icons to Resources:
        Try
            PictureBox1.Image = If(_isCorrect, My.Resources.correct, My.Resources.wrong)
        Catch
            ' Ignore if resource not present
        End Try
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

        ' Use the green rounded button as a display area for the explanation
        RoundButton2.Text = _explanation

        ' Make long text readable inside a button (depends on your custom control)
        RoundButton2.UseCompatibleTextRendering = True
        RoundButton2.TextAlign = ContentAlignment.TopLeft
        RoundButton2.AutoEllipsis = False
        RoundButton2.Padding = New Padding(12, 10, 12, 10)

        ' Colors
        If _isCorrect Then
            ' soft green
            RoundButton2.BackColor = Color.FromArgb(103, 232, 200)
            RoundButton2.ForeColor = Color.Black
        Else
            ' light red/pink
            RoundButton2.BackColor = Color.FromArgb(255, 205, 210) ' or Color.MistyRose
            RoundButton2.ForeColor = Color.Black
        End If

        ' It’s a display surface—prevent click focus
        RoundButton2.Enabled = False
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class

