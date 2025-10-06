<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.RoundButton1 = New QUIZ_System.RoundButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RoundButton1
        '
        Me.RoundButton1.BackColor = System.Drawing.Color.Navy
        Me.RoundButton1.BackgroundColor = System.Drawing.Color.Navy
        Me.RoundButton1.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton1.BorderRadius = 20
        Me.RoundButton1.BorderSize = 0
        Me.RoundButton1.FlatAppearance.BorderSize = 0
        Me.RoundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton1.ForeColor = System.Drawing.Color.Transparent
        Me.RoundButton1.Location = New System.Drawing.Point(995, 961)
        Me.RoundButton1.Name = "RoundButton1"
        Me.RoundButton1.Size = New System.Drawing.Size(150, 50)
        Me.RoundButton1.TabIndex = 2
        Me.RoundButton1.Text = "Back"
        Me.RoundButton1.TextColor = System.Drawing.Color.Transparent
        Me.RoundButton1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(375, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1193, 542)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1868, 1049)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RoundButton1)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "About"
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RoundButton1 As QUIZ_System.RoundButton
    Friend WithEvents Label2 As Label
End Class
