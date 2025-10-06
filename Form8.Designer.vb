<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Me.dgvQuestions = New System.Windows.Forms.DataGridView()
        Me.lblTotalUsers = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCategoryName = New System.Windows.Forms.ComboBox()
        Me.txtBasePoint = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDeleteQuestionID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnDelete = New QUIZ_System.RoundButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnShow = New QUIZ_System.RoundButton()
        Me.txtShowQuestionID = New System.Windows.Forms.TextBox()
        Me.cboCategoryID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtExp4 = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New QUIZ_System.RoundButton()
        Me.txtExp3 = New System.Windows.Forms.TextBox()
        Me.txtExp2 = New System.Windows.Forms.TextBox()
        Me.txtExp1 = New System.Windows.Forms.TextBox()
        Me.rdoOpt4 = New System.Windows.Forms.RadioButton()
        Me.rdoOpt3 = New System.Windows.Forms.RadioButton()
        Me.rdoOpt2 = New System.Windows.Forms.RadioButton()
        Me.rdoOpt1 = New System.Windows.Forms.RadioButton()
        Me.txtOption3 = New System.Windows.Forms.TextBox()
        Me.txtHint = New System.Windows.Forms.TextBox()
        Me.txtOption4 = New System.Windows.Forms.TextBox()
        Me.txtOption2 = New System.Windows.Forms.TextBox()
        Me.txtOption1 = New System.Windows.Forms.TextBox()
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.btnClear = New QUIZ_System.RoundButton()
        Me.btnAdd = New QUIZ_System.RoundButton()
        Me.picQuestionImage = New System.Windows.Forms.PictureBox()
        Me.btnRemoveImage = New System.Windows.Forms.Button()
        Me.btnBrowseImage = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.RoundButton2 = New QUIZ_System.RoundButton()
        Me.RoundButton5 = New QUIZ_System.RoundButton()
        Me.RoundButton6 = New QUIZ_System.RoundButton()
        Me.RoundButton1 = New QUIZ_System.RoundButton()
        Me.RoundButton3 = New QUIZ_System.RoundButton()
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.dgvQuestions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picQuestionImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvQuestions
        '
        Me.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuestions.Location = New System.Drawing.Point(62, 108)
        Me.dgvQuestions.Name = "dgvQuestions"
        Me.dgvQuestions.RowHeadersWidth = 51
        Me.dgvQuestions.RowTemplate.Height = 24
        Me.dgvQuestions.Size = New System.Drawing.Size(689, 684)
        Me.dgvQuestions.TabIndex = 0
        '
        'lblTotalUsers
        '
        Me.lblTotalUsers.AutoSize = True
        Me.lblTotalUsers.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalUsers.Location = New System.Drawing.Point(360, 54)
        Me.lblTotalUsers.Name = "lblTotalUsers"
        Me.lblTotalUsers.Size = New System.Drawing.Size(70, 21)
        Me.lblTotalUsers.TabIndex = 1
        Me.lblTotalUsers.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.cboCategoryName)
        Me.GroupBox1.Controls.Add(Me.txtBasePoint)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtDeleteQuestionID)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnShow)
        Me.GroupBox1.Controls.Add(Me.txtShowQuestionID)
        Me.GroupBox1.Controls.Add(Me.cboCategoryID)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtExp4)
        Me.GroupBox1.Controls.Add(Me.btnUpdate)
        Me.GroupBox1.Controls.Add(Me.txtExp3)
        Me.GroupBox1.Controls.Add(Me.txtExp2)
        Me.GroupBox1.Controls.Add(Me.txtExp1)
        Me.GroupBox1.Controls.Add(Me.rdoOpt4)
        Me.GroupBox1.Controls.Add(Me.rdoOpt3)
        Me.GroupBox1.Controls.Add(Me.rdoOpt2)
        Me.GroupBox1.Controls.Add(Me.rdoOpt1)
        Me.GroupBox1.Controls.Add(Me.txtOption3)
        Me.GroupBox1.Controls.Add(Me.txtHint)
        Me.GroupBox1.Controls.Add(Me.txtOption4)
        Me.GroupBox1.Controls.Add(Me.txtOption2)
        Me.GroupBox1.Controls.Add(Me.txtOption1)
        Me.GroupBox1.Controls.Add(Me.txtQuestion)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.picQuestionImage)
        Me.GroupBox1.Controls.Add(Me.btnRemoveImage)
        Me.GroupBox1.Controls.Add(Me.btnBrowseImage)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.label2)
        Me.GroupBox1.Controls.Add(Me.RoundButton2)
        Me.GroupBox1.Controls.Add(Me.RoundButton5)
        Me.GroupBox1.Controls.Add(Me.RoundButton6)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!)
        Me.GroupBox1.Location = New System.Drawing.Point(568, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1198, 908)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add or Update Question"
        '
        'cboCategoryName
        '
        Me.cboCategoryName.FormattingEnabled = True
        Me.cboCategoryName.Location = New System.Drawing.Point(441, 124)
        Me.cboCategoryName.Name = "cboCategoryName"
        Me.cboCategoryName.Size = New System.Drawing.Size(308, 28)
        Me.cboCategoryName.TabIndex = 43
        '
        'txtBasePoint
        '
        Me.txtBasePoint.Location = New System.Drawing.Point(173, 505)
        Me.txtBasePoint.Name = "txtBasePoint"
        Me.txtBasePoint.Size = New System.Drawing.Size(176, 27)
        Me.txtBasePoint.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(92, 509)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 20)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Points"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label12.Location = New System.Drawing.Point(849, 620)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(211, 20)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Delete the Question data"
        '
        'txtDeleteQuestionID
        '
        Me.txtDeleteQuestionID.Location = New System.Drawing.Point(967, 663)
        Me.txtDeleteQuestionID.Name = "txtDeleteQuestionID"
        Me.txtDeleteQuestionID.Size = New System.Drawing.Size(100, 27)
        Me.txtDeleteQuestionID.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label10.Location = New System.Drawing.Point(847, 666)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 20)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Question ID"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Thistle
        Me.btnDelete.BackgroundColor = System.Drawing.Color.Thistle
        Me.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.btnDelete.BorderRadius = 20
        Me.btnDelete.BorderSize = 0
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDelete.Location = New System.Drawing.Point(848, 715)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(151, 49)
        Me.btnDelete.TabIndex = 37
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label11.Location = New System.Drawing.Point(71, 617)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(218, 20)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Update the Question data"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(289, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 20)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Category Name"
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.SlateBlue
        Me.btnShow.BackgroundColor = System.Drawing.Color.SlateBlue
        Me.btnShow.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.btnShow.BorderRadius = 20
        Me.btnShow.BorderSize = 0
        Me.btnShow.FlatAppearance.BorderSize = 0
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.ForeColor = System.Drawing.Color.White
        Me.btnShow.Location = New System.Drawing.Point(143, 716)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(151, 49)
        Me.btnShow.TabIndex = 35
        Me.btnShow.Text = "Show"
        Me.btnShow.TextColor = System.Drawing.Color.White
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'txtShowQuestionID
        '
        Me.txtShowQuestionID.Location = New System.Drawing.Point(191, 663)
        Me.txtShowQuestionID.Name = "txtShowQuestionID"
        Me.txtShowQuestionID.Size = New System.Drawing.Size(100, 27)
        Me.txtShowQuestionID.TabIndex = 34
        '
        'cboCategoryID
        '
        Me.cboCategoryID.FormattingEnabled = True
        Me.cboCategoryID.Location = New System.Drawing.Point(173, 124)
        Me.cboCategoryID.Name = "cboCategoryID"
        Me.cboCategoryID.Size = New System.Drawing.Size(77, 28)
        Me.cboCategoryID.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label9.Location = New System.Drawing.Point(69, 666)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Question ID"
        '
        'txtExp4
        '
        Me.txtExp4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtExp4.Location = New System.Drawing.Point(588, 359)
        Me.txtExp4.Multiline = True
        Me.txtExp4.Name = "txtExp4"
        Me.txtExp4.Size = New System.Drawing.Size(293, 39)
        Me.txtExp4.TabIndex = 29
        Me.txtExp4.Text = "Explanation"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.CadetBlue
        Me.btnUpdate.BackgroundColor = System.Drawing.Color.CadetBlue
        Me.btnUpdate.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.btnUpdate.BorderRadius = 20
        Me.btnUpdate.BorderSize = 0
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(493, 716)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(151, 49)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.TextColor = System.Drawing.Color.White
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtExp3
        '
        Me.txtExp3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtExp3.Location = New System.Drawing.Point(588, 298)
        Me.txtExp3.Multiline = True
        Me.txtExp3.Name = "txtExp3"
        Me.txtExp3.Size = New System.Drawing.Size(293, 40)
        Me.txtExp3.TabIndex = 28
        Me.txtExp3.Text = "Explanation"
        '
        'txtExp2
        '
        Me.txtExp2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtExp2.Location = New System.Drawing.Point(588, 235)
        Me.txtExp2.Multiline = True
        Me.txtExp2.Name = "txtExp2"
        Me.txtExp2.Size = New System.Drawing.Size(293, 38)
        Me.txtExp2.TabIndex = 27
        Me.txtExp2.Text = "Explanation"
        '
        'txtExp1
        '
        Me.txtExp1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtExp1.Location = New System.Drawing.Point(588, 173)
        Me.txtExp1.Multiline = True
        Me.txtExp1.Name = "txtExp1"
        Me.txtExp1.Size = New System.Drawing.Size(293, 42)
        Me.txtExp1.TabIndex = 26
        Me.txtExp1.Text = "Explanation"
        '
        'rdoOpt4
        '
        Me.rdoOpt4.AutoSize = True
        Me.rdoOpt4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.rdoOpt4.Location = New System.Drawing.Point(512, 369)
        Me.rdoOpt4.Name = "rdoOpt4"
        Me.rdoOpt4.Size = New System.Drawing.Size(43, 24)
        Me.rdoOpt4.TabIndex = 24
        Me.rdoOpt4.TabStop = True
        Me.rdoOpt4.Text = "D"
        Me.rdoOpt4.UseVisualStyleBackColor = False
        '
        'rdoOpt3
        '
        Me.rdoOpt3.AutoSize = True
        Me.rdoOpt3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.rdoOpt3.Location = New System.Drawing.Point(513, 310)
        Me.rdoOpt3.Name = "rdoOpt3"
        Me.rdoOpt3.Size = New System.Drawing.Size(43, 24)
        Me.rdoOpt3.TabIndex = 23
        Me.rdoOpt3.TabStop = True
        Me.rdoOpt3.Text = "C"
        Me.rdoOpt3.UseVisualStyleBackColor = False
        '
        'rdoOpt2
        '
        Me.rdoOpt2.AutoSize = True
        Me.rdoOpt2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.rdoOpt2.Location = New System.Drawing.Point(513, 243)
        Me.rdoOpt2.Name = "rdoOpt2"
        Me.rdoOpt2.Size = New System.Drawing.Size(42, 24)
        Me.rdoOpt2.TabIndex = 22
        Me.rdoOpt2.TabStop = True
        Me.rdoOpt2.Text = "B"
        Me.rdoOpt2.UseVisualStyleBackColor = False
        '
        'rdoOpt1
        '
        Me.rdoOpt1.AutoSize = True
        Me.rdoOpt1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.rdoOpt1.Location = New System.Drawing.Point(513, 183)
        Me.rdoOpt1.Name = "rdoOpt1"
        Me.rdoOpt1.Size = New System.Drawing.Size(42, 24)
        Me.rdoOpt1.TabIndex = 21
        Me.rdoOpt1.TabStop = True
        Me.rdoOpt1.Text = "A"
        Me.rdoOpt1.UseVisualStyleBackColor = False
        '
        'txtOption3
        '
        Me.txtOption3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtOption3.Location = New System.Drawing.Point(173, 298)
        Me.txtOption3.Multiline = True
        Me.txtOption3.Name = "txtOption3"
        Me.txtOption3.Size = New System.Drawing.Size(306, 40)
        Me.txtOption3.TabIndex = 20
        '
        'txtHint
        '
        Me.txtHint.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtHint.Location = New System.Drawing.Point(173, 421)
        Me.txtHint.Multiline = True
        Me.txtHint.Name = "txtHint"
        Me.txtHint.Size = New System.Drawing.Size(306, 42)
        Me.txtHint.TabIndex = 19
        '
        'txtOption4
        '
        Me.txtOption4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtOption4.Location = New System.Drawing.Point(173, 359)
        Me.txtOption4.Multiline = True
        Me.txtOption4.Name = "txtOption4"
        Me.txtOption4.Size = New System.Drawing.Size(306, 39)
        Me.txtOption4.TabIndex = 18
        '
        'txtOption2
        '
        Me.txtOption2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtOption2.Location = New System.Drawing.Point(173, 235)
        Me.txtOption2.Multiline = True
        Me.txtOption2.Name = "txtOption2"
        Me.txtOption2.Size = New System.Drawing.Size(306, 38)
        Me.txtOption2.TabIndex = 17
        '
        'txtOption1
        '
        Me.txtOption1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOption1.Location = New System.Drawing.Point(173, 170)
        Me.txtOption1.Multiline = True
        Me.txtOption1.Name = "txtOption1"
        Me.txtOption1.Size = New System.Drawing.Size(306, 45)
        Me.txtOption1.TabIndex = 16
        '
        'txtQuestion
        '
        Me.txtQuestion.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.txtQuestion.Location = New System.Drawing.Point(170, 57)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(394, 44)
        Me.txtQuestion.TabIndex = 14
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btnClear.BackgroundColor = System.Drawing.Color.PaleVioletRed
        Me.btnClear.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.btnClear.BorderRadius = 20
        Me.btnClear.BorderSize = 0
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(663, 716)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(151, 49)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.TextColor = System.Drawing.Color.White
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.CadetBlue
        Me.btnAdd.BackgroundColor = System.Drawing.Color.CadetBlue
        Me.btnAdd.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.btnAdd.BorderRadius = 20
        Me.btnAdd.BorderSize = 0
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(324, 715)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(151, 49)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.TextColor = System.Drawing.Color.White
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'picQuestionImage
        '
        Me.picQuestionImage.BackgroundImage = CType(resources.GetObject("picQuestionImage.BackgroundImage"), System.Drawing.Image)
        Me.picQuestionImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picQuestionImage.Location = New System.Drawing.Point(947, 282)
        Me.picQuestionImage.Name = "picQuestionImage"
        Me.picQuestionImage.Size = New System.Drawing.Size(159, 181)
        Me.picQuestionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picQuestionImage.TabIndex = 9
        Me.picQuestionImage.TabStop = False
        '
        'btnRemoveImage
        '
        Me.btnRemoveImage.Location = New System.Drawing.Point(947, 217)
        Me.btnRemoveImage.Name = "btnRemoveImage"
        Me.btnRemoveImage.Size = New System.Drawing.Size(156, 40)
        Me.btnRemoveImage.TabIndex = 8
        Me.btnRemoveImage.Text = "Remove image"
        Me.btnRemoveImage.UseVisualStyleBackColor = True
        '
        'btnBrowseImage
        '
        Me.btnBrowseImage.Location = New System.Drawing.Point(947, 164)
        Me.btnBrowseImage.Name = "btnBrowseImage"
        Me.btnBrowseImage.Size = New System.Drawing.Size(156, 38)
        Me.btnBrowseImage.TabIndex = 7
        Me.btnBrowseImage.Text = "Browse image"
        Me.btnBrowseImage.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(99, 436)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Hint"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(76, 371)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 20)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Option D"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(75, 314)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Option C"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(76, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Option B"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(75, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Option A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Category ID"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(69, 72)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(82, 20)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Question"
        '
        'RoundButton2
        '
        Me.RoundButton2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.RoundButton2.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.RoundButton2.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton2.BorderRadius = 20
        Me.RoundButton2.BorderSize = 0
        Me.RoundButton2.FlatAppearance.BorderSize = 0
        Me.RoundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton2.ForeColor = System.Drawing.Color.White
        Me.RoundButton2.Location = New System.Drawing.Point(493, 159)
        Me.RoundButton2.Name = "RoundButton2"
        Me.RoundButton2.Size = New System.Drawing.Size(79, 258)
        Me.RoundButton2.TabIndex = 32
        Me.RoundButton2.TextColor = System.Drawing.Color.White
        Me.RoundButton2.UseVisualStyleBackColor = False
        '
        'RoundButton5
        '
        Me.RoundButton5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.RoundButton5.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.RoundButton5.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton5.BorderRadius = 20
        Me.RoundButton5.BorderSize = 0
        Me.RoundButton5.FlatAppearance.BorderSize = 0
        Me.RoundButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton5.ForeColor = System.Drawing.Color.White
        Me.RoundButton5.Location = New System.Drawing.Point(49, 579)
        Me.RoundButton5.Name = "RoundButton5"
        Me.RoundButton5.Size = New System.Drawing.Size(269, 223)
        Me.RoundButton5.TabIndex = 45
        Me.RoundButton5.TextColor = System.Drawing.Color.White
        Me.RoundButton5.UseVisualStyleBackColor = False
        '
        'RoundButton6
        '
        Me.RoundButton6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.RoundButton6.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.RoundButton6.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton6.BorderRadius = 20
        Me.RoundButton6.BorderSize = 0
        Me.RoundButton6.FlatAppearance.BorderSize = 0
        Me.RoundButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton6.ForeColor = System.Drawing.Color.White
        Me.RoundButton6.Location = New System.Drawing.Point(820, 579)
        Me.RoundButton6.Name = "RoundButton6"
        Me.RoundButton6.Size = New System.Drawing.Size(283, 223)
        Me.RoundButton6.TabIndex = 46
        Me.RoundButton6.TextColor = System.Drawing.Color.White
        Me.RoundButton6.UseVisualStyleBackColor = False
        '
        'RoundButton1
        '
        Me.RoundButton1.BackColor = System.Drawing.Color.MediumPurple
        Me.RoundButton1.BackgroundColor = System.Drawing.Color.MediumPurple
        Me.RoundButton1.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton1.BorderRadius = 20
        Me.RoundButton1.BorderSize = 0
        Me.RoundButton1.FlatAppearance.BorderSize = 0
        Me.RoundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton1.ForeColor = System.Drawing.Color.White
        Me.RoundButton1.Location = New System.Drawing.Point(958, 25)
        Me.RoundButton1.Name = "RoundButton1"
        Me.RoundButton1.Size = New System.Drawing.Size(150, 50)
        Me.RoundButton1.TabIndex = 3
        Me.RoundButton1.Text = "Log Out"
        Me.RoundButton1.TextColor = System.Drawing.Color.White
        Me.RoundButton1.UseVisualStyleBackColor = False
        '
        'RoundButton3
        '
        Me.RoundButton3.BackColor = System.Drawing.Color.Thistle
        Me.RoundButton3.BackgroundColor = System.Drawing.Color.Thistle
        Me.RoundButton3.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RoundButton3.BorderRadius = 10
        Me.RoundButton3.BorderSize = 0
        Me.RoundButton3.FlatAppearance.BorderSize = 0
        Me.RoundButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!)
        Me.RoundButton3.ForeColor = System.Drawing.Color.Black
        Me.RoundButton3.Location = New System.Drawing.Point(876, 24)
        Me.RoundButton3.Name = "RoundButton3"
        Me.RoundButton3.Size = New System.Drawing.Size(76, 52)
        Me.RoundButton3.TabIndex = 33
        Me.RoundButton3.Text = "Exit"
        Me.RoundButton3.TextColor = System.Drawing.Color.Black
        Me.RoundButton3.UseVisualStyleBackColor = False
        '
        'dgvUsers
        '
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(63, 881)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.RowHeadersWidth = 51
        Me.dgvUsers.RowTemplate.Height = 24
        Me.dgvUsers.Size = New System.Drawing.Size(689, 204)
        Me.dgvUsers.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(59, 830)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(147, 21)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "All User Details"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(59, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(139, 21)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Question Bank"
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1872, 1014)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dgvUsers)
        Me.Controls.Add(Me.RoundButton3)
        Me.Controls.Add(Me.RoundButton1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTotalUsers)
        Me.Controls.Add(Me.dgvQuestions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form8"
        Me.Text = "Admin Page"
        CType(Me.dgvQuestions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picQuestionImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvQuestions As DataGridView
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents label2 As Label
    Friend WithEvents txtOption3 As TextBox
    Friend WithEvents txtHint As TextBox
    Friend WithEvents txtOption4 As TextBox
    Friend WithEvents txtOption2 As TextBox
    Friend WithEvents txtOption1 As TextBox
    Friend WithEvents txtQuestion As TextBox
    Friend WithEvents btnClear As QUIZ_System.RoundButton
    Friend WithEvents btnUpdate As QUIZ_System.RoundButton
    Friend WithEvents btnAdd As QUIZ_System.RoundButton
    Friend WithEvents picQuestionImage As PictureBox
    Friend WithEvents btnRemoveImage As Button
    Friend WithEvents btnBrowseImage As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents rdoOpt4 As RadioButton
    Friend WithEvents rdoOpt3 As RadioButton
    Friend WithEvents rdoOpt2 As RadioButton
    Friend WithEvents rdoOpt1 As RadioButton



    Friend WithEvents RoundButton1 As QUIZ_System.RoundButton
    Friend WithEvents txtExp4 As TextBox
    Friend WithEvents txtExp3 As TextBox
    Friend WithEvents txtExp2 As TextBox
    Friend WithEvents txtExp1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCategoryID As ComboBox
    Friend WithEvents RoundButton2 As QUIZ_System.RoundButton
    Friend WithEvents RoundButton3 As QUIZ_System.RoundButton
    Friend WithEvents txtShowQuestionID As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnShow As QUIZ_System.RoundButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtDeleteQuestionID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnDelete As QUIZ_System.RoundButton
    Friend WithEvents txtBasePoint As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cboCategoryName As ComboBox
    Friend WithEvents RoundButton5 As QUIZ_System.RoundButton
    Friend WithEvents RoundButton6 As QUIZ_System.RoundButton
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
End Class
