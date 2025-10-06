<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiniScoreboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RoundButton1 = New QUIZ_System.RoundButton()
        Me.RoundButton2 = New QUIZ_System.RoundButton()
        Me.RoundButton3 = New QUIZ_System.RoundButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundButton4 = New QUIZ_System.RoundButton()
        Me.SuspendLayout()
        '
        'RoundButton1
        '
        Me.RoundButton1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.RoundButton1.BackgroundColor = System.Drawing.Color.CornflowerBlue
        Me.RoundButton1.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton1.BorderRadius = 20
        Me.RoundButton1.BorderSize = 0
        Me.RoundButton1.FlatAppearance.BorderSize = 0
        Me.RoundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton1.Font = New System.Drawing.Font("Microsoft Tai Le", 10.2!, System.Drawing.FontStyle.Bold)
        Me.RoundButton1.ForeColor = System.Drawing.Color.White
        Me.RoundButton1.Location = New System.Drawing.Point(618, 352)
        Me.RoundButton1.Name = "RoundButton1"
        Me.RoundButton1.Size = New System.Drawing.Size(150, 60)
        Me.RoundButton1.TabIndex = 0
        Me.RoundButton1.Text = "Got it"
        Me.RoundButton1.TextColor = System.Drawing.Color.White
        Me.RoundButton1.UseVisualStyleBackColor = False
        '
        'RoundButton2
        '
        Me.RoundButton2.BackColor = System.Drawing.Color.SteelBlue
        Me.RoundButton2.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.RoundButton2.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton2.BorderRadius = 20
        Me.RoundButton2.BorderSize = 0
        Me.RoundButton2.FlatAppearance.BorderSize = 0
        Me.RoundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton2.Font = New System.Drawing.Font("Microsoft Tai Le", 10.2!, System.Drawing.FontStyle.Bold)
        Me.RoundButton2.ForeColor = System.Drawing.Color.Black
        Me.RoundButton2.Location = New System.Drawing.Point(138, 133)
        Me.RoundButton2.Name = "RoundButton2"
        Me.RoundButton2.Size = New System.Drawing.Size(473, 94)
        Me.RoundButton2.TabIndex = 1
        Me.RoundButton2.Text = "RoundButton2"
        Me.RoundButton2.TextColor = System.Drawing.Color.Black
        Me.RoundButton2.UseVisualStyleBackColor = False
        '
        'RoundButton3
        '
        Me.RoundButton3.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.RoundButton3.BackgroundColor = System.Drawing.Color.MediumSeaGreen
        Me.RoundButton3.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton3.BorderRadius = 20
        Me.RoundButton3.BorderSize = 0
        Me.RoundButton3.FlatAppearance.BorderSize = 0
        Me.RoundButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton3.Font = New System.Drawing.Font("Microsoft Tai Le", 10.2!, System.Drawing.FontStyle.Bold)
        Me.RoundButton3.ForeColor = System.Drawing.Color.White
        Me.RoundButton3.Location = New System.Drawing.Point(156, 233)
        Me.RoundButton3.Name = "RoundButton3"
        Me.RoundButton3.Size = New System.Drawing.Size(216, 94)
        Me.RoundButton3.TabIndex = 2
        Me.RoundButton3.Text = "RoundButton3"
        Me.RoundButton3.TextColor = System.Drawing.Color.White
        Me.RoundButton3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Tai Le", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(212, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'RoundButton4
        '
        Me.RoundButton4.BackColor = System.Drawing.Color.SeaGreen
        Me.RoundButton4.BackgroundColor = System.Drawing.Color.SeaGreen
        Me.RoundButton4.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton4.BorderRadius = 20
        Me.RoundButton4.BorderSize = 0
        Me.RoundButton4.FlatAppearance.BorderSize = 0
        Me.RoundButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton4.Font = New System.Drawing.Font("Microsoft Tai Le", 10.2!, System.Drawing.FontStyle.Bold)
        Me.RoundButton4.ForeColor = System.Drawing.Color.White
        Me.RoundButton4.Location = New System.Drawing.Point(378, 233)
        Me.RoundButton4.Name = "RoundButton4"
        Me.RoundButton4.Size = New System.Drawing.Size(216, 94)
        Me.RoundButton4.TabIndex = 4
        Me.RoundButton4.Text = "RoundButton4"
        Me.RoundButton4.TextColor = System.Drawing.Color.White
        Me.RoundButton4.UseVisualStyleBackColor = False
        '
        'MiniScoreboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RoundButton4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RoundButton3)
        Me.Controls.Add(Me.RoundButton2)
        Me.Controls.Add(Me.RoundButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "MiniScoreboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Points scored"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundButton1 As QUIZ_System.RoundButton
    Friend WithEvents RoundButton2 As QUIZ_System.RoundButton
    Friend WithEvents RoundButton3 As QUIZ_System.RoundButton
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundButton4 As QUIZ_System.RoundButton
End Class
