<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.usersetxt = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.checkBox2 = New System.Windows.Forms.CheckBox()
        Me.checkBox1 = New System.Windows.Forms.CheckBox()
        Me.passetxt2 = New System.Windows.Forms.TextBox()
        Me.passetxt1 = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RoundButton1 = New QUIZ_System.RoundButton()
        Me.RoundButton2 = New QUIZ_System.RoundButton()
        Me.SuspendLayout()
        '
        'usersetxt
        '
        Me.usersetxt.Location = New System.Drawing.Point(743, 227)
        Me.usersetxt.Margin = New System.Windows.Forms.Padding(4)
        Me.usersetxt.Name = "usersetxt"
        Me.usersetxt.Size = New System.Drawing.Size(213, 27)
        Me.usersetxt.TabIndex = 21
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.label3.Location = New System.Drawing.Point(557, 230)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(134, 20)
        Me.label3.TabIndex = 20
        Me.label3.Text = "New Username"
        '
        'checkBox2
        '
        Me.checkBox2.AutoSize = True
        Me.checkBox2.BackColor = System.Drawing.Color.Transparent
        Me.checkBox2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.checkBox2.Location = New System.Drawing.Point(774, 396)
        Me.checkBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.checkBox2.Name = "checkBox2"
        Me.checkBox2.Size = New System.Drawing.Size(161, 24)
        Me.checkBox2.TabIndex = 18
        Me.checkBox2.Text = "Show password"
        Me.checkBox2.UseVisualStyleBackColor = False
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.BackColor = System.Drawing.Color.Transparent
        Me.checkBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.checkBox1.Location = New System.Drawing.Point(774, 316)
        Me.checkBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(161, 24)
        Me.checkBox1.TabIndex = 17
        Me.checkBox1.Text = "Show password"
        Me.checkBox1.UseVisualStyleBackColor = False
        '
        'passetxt2
        '
        Me.passetxt2.Location = New System.Drawing.Point(743, 361)
        Me.passetxt2.Margin = New System.Windows.Forms.Padding(4)
        Me.passetxt2.Name = "passetxt2"
        Me.passetxt2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.passetxt2.Size = New System.Drawing.Size(213, 27)
        Me.passetxt2.TabIndex = 16
        '
        'passetxt1
        '
        Me.passetxt1.Location = New System.Drawing.Point(743, 284)
        Me.passetxt1.Margin = New System.Windows.Forms.Padding(4)
        Me.passetxt1.Name = "passetxt1"
        Me.passetxt1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.passetxt1.Size = New System.Drawing.Size(213, 27)
        Me.passetxt1.TabIndex = 15
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.label2.Location = New System.Drawing.Point(539, 368)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(160, 20)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Confirm password"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.label1.Location = New System.Drawing.Point(562, 284)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(131, 20)
        Me.label1.TabIndex = 12
        Me.label1.Text = "New Password"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 1102)
        Me.Panel1.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1457, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 1102)
        Me.Panel2.TabIndex = 23
        '
        'RoundButton1
        '
        Me.RoundButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RoundButton1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.RoundButton1.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton1.BorderRadius = 20
        Me.RoundButton1.BorderSize = 0
        Me.RoundButton1.FlatAppearance.BorderSize = 0
        Me.RoundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton1.ForeColor = System.Drawing.Color.White
        Me.RoundButton1.Location = New System.Drawing.Point(743, 480)
        Me.RoundButton1.Name = "RoundButton1"
        Me.RoundButton1.Size = New System.Drawing.Size(187, 60)
        Me.RoundButton1.TabIndex = 24
        Me.RoundButton1.Text = "Done"
        Me.RoundButton1.TextColor = System.Drawing.Color.White
        Me.RoundButton1.UseVisualStyleBackColor = False
        '
        'RoundButton2
        '
        Me.RoundButton2.BackColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton2.BackgroundColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton2.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton2.BorderRadius = 20
        Me.RoundButton2.BorderSize = 0
        Me.RoundButton2.FlatAppearance.BorderSize = 0
        Me.RoundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton2.ForeColor = System.Drawing.Color.White
        Me.RoundButton2.Location = New System.Drawing.Point(613, 480)
        Me.RoundButton2.Name = "RoundButton2"
        Me.RoundButton2.Size = New System.Drawing.Size(104, 62)
        Me.RoundButton2.TabIndex = 25
        Me.RoundButton2.Text = "Back"
        Me.RoundButton2.TextColor = System.Drawing.Color.White
        Me.RoundButton2.UseVisualStyleBackColor = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 1102)
        Me.Controls.Add(Me.RoundButton2)
        Me.Controls.Add(Me.RoundButton1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.usersetxt)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.checkBox2)
        Me.Controls.Add(Me.checkBox1)
        Me.Controls.Add(Me.passetxt2)
        Me.Controls.Add(Me.passetxt1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form4"
        Me.Text = "Reset password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents usersetxt As TextBox
    Private WithEvents label3 As Label
    Private WithEvents checkBox2 As CheckBox
    Private WithEvents checkBox1 As CheckBox
    Private WithEvents passetxt2 As TextBox
    Private WithEvents passetxt1 As TextBox
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RoundButton1 As QUIZ_System.RoundButton
    Friend WithEvents RoundButton2 As QUIZ_System.RoundButton
End Class
