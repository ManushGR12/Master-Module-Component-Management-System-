<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Button3 = New Button()
        Label3 = New Label()
        Button1 = New Button()
        TextBox1 = New TextBox()
        PictureBox4 = New PictureBox()
        PictureBox5 = New PictureBox()
        Panel1 = New Panel()
        TextBox3 = New TextBox()
        CheckBox1 = New CheckBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox6 = New PictureBox()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.FromArgb(CByte(128), CByte(128), CByte(255))
        Button3.Font = New Font("Perpetua", 13.8F)
        Button3.Location = New Point(205, 331)
        Button3.Name = "Button3"
        Button3.Size = New Size(199, 57)
        Button3.TabIndex = 19
        Button3.Text = "Register"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Romantic", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, CByte(2))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(869, 213)
        Label3.Name = "Label3"
        Label3.Size = New Size(369, 37)
        Label3.TabIndex = 18
        Label3.Text = "Welcome to Master Module"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Gold
        Button1.Font = New Font("Perpetua", 13.8F)
        Button1.Location = New Point(210, 245)
        Button1.Name = "Button1"
        Button1.Size = New Size(194, 60)
        Button1.TabIndex = 15
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Romantic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(2))
        TextBox1.Location = New Point(120, 84)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(356, 34)
        TextBox1.TabIndex = 11
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(63, 75)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(51, 46)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 23
        PictureBox4.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(63, 175)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(51, 44)
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox5.TabIndex = 24
        PictureBox5.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(TextBox3)
        Panel1.Controls.Add(CheckBox1)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(PictureBox5)
        Panel1.Controls.Add(PictureBox4)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button1)
        Panel1.Location = New Point(732, 335)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(599, 421)
        Panel1.TabIndex = 26
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox3.Location = New Point(121, 180)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(356, 34)
        TextBox3.TabIndex = 32
        TextBox3.UseSystemPasswordChar = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Font = New Font("Perpetua", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox1.Location = New Point(430, 237)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(142, 27)
        CheckBox1.TabIndex = 33
        CheckBox1.Text = "Show password"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Romantic", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, CByte(2))
        Label1.ForeColor = Color.Gold
        Label1.Location = New Point(841, 268)
        Label1.Name = "Label1"
        Label1.Size = New Size(442, 37)
        Label1.TabIndex = 27
        Label1.Text = "Component Management System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(902, 74)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(287, 101)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 28
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(2, -5)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(368, 327)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 29
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(-6, 729)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(368, 327)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 30
        PictureBox3.TabStop = False
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(1817, 185)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(300, 858)
        PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox6.TabIndex = 31
        PictureBox6.TabStop = False
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1924, 1055)
        Controls.Add(PictureBox6)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Controls.Add(Label3)
        Controls.Add(Panel1)
        Name = "Login"
        Text = "Login"
        WindowState = FormWindowState.Maximized
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox3 As TextBox
End Class
