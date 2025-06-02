Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports Microsoft.Data.SqlClient

Public Class Login

    Dim connectionString As String = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"

    Private Function IsValidEmail(email As String) As Boolean
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Return Regex.IsMatch(email, emailPattern)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = TextBox1.Text.Trim()
        Dim password As String = TextBox3.Text.Trim()

        If email = "" Or password = "" Then
            MessageBox.Show("Please enter both email and password.")
            Exit Sub
        End If

        ' Admin login
        If email.ToLower() = "admin" AndAlso password = "123" Then
            MessageBox.Show("Admin login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim frm As New Adminuserview()
            frm.Show()
            Me.Hide()
            Exit Sub
        End If

        ' User login
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT name FROM register WHERE email = @email AND password = @password"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@password", password)

                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        Session.LoggedInEmail = email
                        Session.LoggedInName = reader("name").ToString()

                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim frm As New Adminuserview() ' Or your main user form
                        frm.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Invalid email or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        register.Show()
        Me.Hide()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox3.UseSystemPasswordChar = False
        Else
            TextBox3.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        TextBox3.UseSystemPasswordChar = True ' Masked by default
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ' Show password
            TextBox3.UseSystemPasswordChar = False
        Else
            ' Hide password
            TextBox3.UseSystemPasswordChar = True
        End If
    End Sub
End Class
