<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Admin
        '
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.Name = "Admin"
        Me.ResumeLayout(False)

    End Sub

    Private Sub dgvQuestions_SelectionChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnRemoveImage_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBrowseImage_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)

    End Sub

    Friend WithEvents dgvQuestions As DataGridView
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents txtQuestion As TextBox
    Friend WithEvents lblQuestion As Label
    Friend WithEvents rdoOpt4 As RadioButton
    Friend WithEvents rdoOpt3 As RadioButton
    Friend WithEvents rdoOpt2 As RadioButton
    Friend WithEvents rdoOpt1 As RadioButton
    Friend WithEvents txtOption4 As TextBox
    Friend WithEvents txtOption3 As TextBox
    Friend WithEvents txtOption2 As TextBox
    Friend WithEvents txtOption1 As TextBox
    Friend WithEvents lblOption4 As Label
    Friend WithEvents lblOption3 As Label
    Friend WithEvents lblOption2 As Label
    Friend WithEvents lblOption1 As Label
    Friend WithEvents btnClear As QUIZ_System.RoundButton
    Friend WithEvents btnDelete As QUIZ_System.RoundButton
    Friend WithEvents btnUpdate As QUIZ_System.RoundButton
    Friend WithEvents btnAdd As QUIZ_System.RoundButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtHint As TextBox
    Friend WithEvents lblHint As Label

    Private Sub AdminForm_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs)

    End Sub
End Class
