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
        PictureBox6 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox6
        ' 
        PictureBox6.BackColor = Color.Transparent
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(598, 626)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(85, 76)
        PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox6.TabIndex = 29
        PictureBox6.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Romantic", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(2))
        Label1.Location = New Point(12, 92)
        Label1.Name = "Label1"
        Label1.Size = New Size(1265, 520)
        Label1.TabIndex = 30
        Label1.Text = resources.GetString("Label1.Text")
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Romantic", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(2))
        Label2.Location = New Point(12, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(594, 28)
        Label2.TabIndex = 31
        Label2.Text = "Master Module – Component Management System (CMS)"
        ' 
        ' About
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1312, 714)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox6)
        Name = "About"
        Text = "About"
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
