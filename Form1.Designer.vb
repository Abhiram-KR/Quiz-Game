<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.label3 = New System.Windows.Forms.Label()
        Me.checkBox1 = New System.Windows.Forms.CheckBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.RoundButton2 = New QUIZ_System.RoundButton()
        Me.RoundButton1 = New QUIZ_System.RoundButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(217, 571)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(116, 22)
        Me.label3.TabIndex = 19
        Me.label3.Text = "No account ?"
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.BackColor = System.Drawing.Color.Transparent
        Me.checkBox1.Location = New System.Drawing.Point(308, 380)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(124, 20)
        Me.checkBox1.TabIndex = 16
        Me.checkBox1.Text = "Show password"
        Me.checkBox1.UseVisualStyleBackColor = False
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!)
        Me.txtPass.Location = New System.Drawing.Point(267, 340)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPass.ShortcutsEnabled = False
        Me.txtPass.Size = New System.Drawing.Size(165, 28)
        Me.txtPass.TabIndex = 15
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!)
        Me.txtUser.Location = New System.Drawing.Point(267, 284)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(165, 28)
        Me.txtUser.TabIndex = 14
        '
        'linkLabel2
        '
        Me.linkLabel2.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue
        Me.linkLabel2.AutoSize = True
        Me.linkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.linkLabel2.Location = New System.Drawing.Point(318, 416)
        Me.linkLabel2.Name = "linkLabel2"
        Me.linkLabel2.Size = New System.Drawing.Size(109, 16)
        Me.linkLabel2.TabIndex = 13
        Me.linkLabel2.TabStop = True
        Me.linkLabel2.Text = "Forgot Password"
        '
        'linkLabel1
        '
        Me.linkLabel1.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.linkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkLabel1.Location = New System.Drawing.Point(346, 571)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(99, 22)
        Me.linkLabel1.TabIndex = 12
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Create one"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!)
        Me.label2.Location = New System.Drawing.Point(146, 343)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(98, 21)
        Me.label2.TabIndex = 11
        Me.label2.Text = "Password"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(146, 291)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(102, 21)
        Me.label1.TabIndex = 10
        Me.label1.Text = "Username"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.RoundButton2)
        Me.Panel1.Controls.Add(Me.RoundButton1)
        Me.Panel1.Controls.Add(Me.txtPass)
        Me.Panel1.Controls.Add(Me.label3)
        Me.Panel1.Controls.Add(Me.label1)
        Me.Panel1.Controls.Add(Me.label2)
        Me.Panel1.Controls.Add(Me.linkLabel1)
        Me.Panel1.Controls.Add(Me.checkBox1)
        Me.Panel1.Controls.Add(Me.linkLabel2)
        Me.Panel1.Controls.Add(Me.txtUser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(507, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(633, 723)
        Me.Panel1.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Forte", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label5.Location = New System.Drawing.Point(7, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(590, 62)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Welcome to Quiz App" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sharpen your knowledge and challenge yourself"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(217, 632)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 22)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Login as Admin ?"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.LinkLabel3.Location = New System.Drawing.Point(379, 632)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(54, 22)
        Me.LinkLabel3.TabIndex = 24
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Login"
        '
        'RoundButton2
        '
        Me.RoundButton2.BackColor = System.Drawing.Color.SlateBlue
        Me.RoundButton2.BackgroundColor = System.Drawing.Color.SlateBlue
        Me.RoundButton2.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton2.BorderRadius = 10
        Me.RoundButton2.BorderSize = 0
        Me.RoundButton2.FlatAppearance.BorderSize = 0
        Me.RoundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!)
        Me.RoundButton2.ForeColor = System.Drawing.Color.White
        Me.RoundButton2.Location = New System.Drawing.Point(192, 471)
        Me.RoundButton2.Name = "RoundButton2"
        Me.RoundButton2.Size = New System.Drawing.Size(79, 60)
        Me.RoundButton2.TabIndex = 23
        Me.RoundButton2.Text = "Exit"
        Me.RoundButton2.TextColor = System.Drawing.Color.White
        Me.RoundButton2.UseVisualStyleBackColor = False
        '
        'RoundButton1
        '
        Me.RoundButton1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.RoundButton1.BackgroundColor = System.Drawing.Color.CornflowerBlue
        Me.RoundButton1.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton1.BorderRadius = 18
        Me.RoundButton1.BorderSize = 0
        Me.RoundButton1.FlatAppearance.BorderSize = 0
        Me.RoundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!)
        Me.RoundButton1.ForeColor = System.Drawing.Color.White
        Me.RoundButton1.Location = New System.Drawing.Point(298, 471)
        Me.RoundButton1.Name = "RoundButton1"
        Me.RoundButton1.Size = New System.Drawing.Size(161, 60)
        Me.RoundButton1.TabIndex = 22
        Me.RoundButton1.Text = "Login"
        Me.RoundButton1.TextColor = System.Drawing.Color.White
        Me.RoundButton1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(507, 723)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 723)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Loginpage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents label3 As Label
    Public WithEvents checkBox1 As CheckBox
    Private WithEvents txtPass As TextBox
    Private WithEvents txtUser As TextBox
    Private WithEvents linkLabel2 As LinkLabel
    Private WithEvents linkLabel1 As LinkLabel
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RoundButton1 As QUIZ_System.RoundButton
    Friend WithEvents RoundButton2 As QUIZ_System.RoundButton
    Friend WithEvents LinkLabel3 As LinkLabel
    Private WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
