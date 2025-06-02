Imports Microsoft.Data.SqlClient
Imports MySqlConnector
Imports Windows.Win32.System

Public Class register
    Dim con As New SqlConnection("Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True")
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = TextBox1.Text.Trim()
        Dim email As String = TextBox2.Text.Trim()
        Dim password As String = TextBox3.Text.Trim()

        If name = "" Or email = "" Or password = "" Then
            MessageBox.Show("Please fill all fields.")
            Exit Sub
        End If

        Try
            con.Open()

            ' Check for duplicate name or email
            Dim checkQuery As String = "SELECT COUNT(*) FROM register WHERE name = @name OR email = @email"
            Dim checkCmd As New SqlCommand(checkQuery, con)
            checkCmd.Parameters.AddWithValue("@name", name)
            checkCmd.Parameters.AddWithValue("@email", email)

            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Name or Email already exists.")
                Exit Sub
            End If

            ' Insert if no duplicate found
            Dim insertQuery As String = "INSERT INTO register (name, email, password) VALUES (@name, @email, @password)"
            Dim insertCmd As New SqlCommand(insertQuery, con)
            insertCmd.Parameters.AddWithValue("@name", name)
            insertCmd.Parameters.AddWithValue("@email", email)
            insertCmd.Parameters.AddWithValue("@password", password)

            If insertCmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Registration successful!")
                Login.Show()
                Me.Hide()
            Else
                MessageBox.Show("Registration failed.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Login.Show()
        Me.Hide()
    End Sub
End Class