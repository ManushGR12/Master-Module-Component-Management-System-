Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System
Imports System.Data.SqlClient
Imports System.ComponentModel.DataAnnotations

Public Class Adminuserview
    Dim con As New SqlConnection("Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True")
    Dim connectionString As String = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"
    Private Sub Adminuserview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Text = "Welcome, " & Session.LoggedInName
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        Dim result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Close()
            Login.Show()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
    Public Sub UpdateLabel(newText As String)
        Label1.Text = newText
    End Sub
    Public Sub CloseDataGridView()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Home.Show()
        Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        additem.Show()
        Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Showdata.Show()
        Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        Dim result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Close()
            Login.Show()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        PictureBox5.Hide()
        additem.Show()
        Hide()
    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Home.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        additem.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        editpage.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        About.Show()

    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class