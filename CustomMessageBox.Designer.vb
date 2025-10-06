<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMessageBox
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RoundButton1 = New QUIZ_System.RoundButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundButton2 = New QUIZ_System.RoundButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(280, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(263, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(170, 149)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
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
        Me.RoundButton1.Font = New System.Drawing.Font("Bookman Old Style", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton1.ForeColor = System.Drawing.Color.White
        Me.RoundButton1.Location = New System.Drawing.Point(530, 442)
        Me.RoundButton1.Name = "RoundButton1"
        Me.RoundButton1.Size = New System.Drawing.Size(150, 56)
        Me.RoundButton1.TabIndex = 3
        Me.RoundButton1.Text = "Ok"
        Me.RoundButton1.TextColor = System.Drawing.Color.White
        Me.RoundButton1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bookman Old Style", 10.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(41, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Explanation"
        '
        'RoundButton2
        '
        Me.RoundButton2.BackColor = System.Drawing.Color.MediumAquamarine
        Me.RoundButton2.BackgroundColor = System.Drawing.Color.MediumAquamarine
        Me.RoundButton2.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton2.BorderRadius = 20
        Me.RoundButton2.BorderSize = 0
        Me.RoundButton2.FlatAppearance.BorderSize = 0
        Me.RoundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton2.Font = New System.Drawing.Font("Microsoft Tai Le", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton2.ForeColor = System.Drawing.Color.Black
        Me.RoundButton2.Location = New System.Drawing.Point(35, 281)
        Me.RoundButton2.Name = "RoundButton2"
        Me.RoundButton2.Size = New System.Drawing.Size(635, 140)
        Me.RoundButton2.TabIndex = 5
        Me.RoundButton2.Text = "RoundButton2"
        Me.RoundButton2.TextColor = System.Drawing.Color.Black
        Me.RoundButton2.UseVisualStyleBackColor = False
        '
        'CustomMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(710, 525)
        Me.Controls.Add(Me.RoundButton2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RoundButton1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "CustomMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Answer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RoundButton1 As QUIZ_System.RoundButton
    Friend WithEvents Label2 As Label
    Friend WithEvents RoundButton2 As QUIZ_System.RoundButton
End Class
