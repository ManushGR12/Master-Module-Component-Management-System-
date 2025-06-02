Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports Microsoft.Data.SqlClient
Imports MySqlConnector
Imports Windows.Win32.System

Public Class additem
    Private Sub additem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"
        Loaddata1()
        DataGridView1.Hide()
        Label16.Text = Session.LoggedInName

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Adminuserview.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel4.Show()
        DataGridView1.Hide()
        Label2.Text = "Add Items"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Show()
        Label2.Text = "View Items"
        Panel4.Hide()

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            TextBox3.Text = openFileDialog.FileName ' Save file path in TextBox3
            PictureBox5.Image = Image.FromFile(openFileDialog.FileName) ' Display Image
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim Itemname = TextBox1.Text
        If Itemname = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Please fill all fields and select an image.")
            Return
        End If
        Dim connectionString = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                ' Query to Insert Data

                Dim query = "INSERT INTO additem ( item_name, date_bought, img_path,quantity, added_by) VALUES (@itemname, @date, @imgpath, @Quantity, @added_by)"
                Dim cmd As New SqlCommand(query, conn)

                ' Assign Values from TextBoxes and Label
                cmd.Parameters.AddWithValue("@itemname", Itemname)
                cmd.Parameters.AddWithValue("@Quantity", TextBox4.Text)
                cmd.Parameters.AddWithValue("@date", Label11.Text)
                cmd.Parameters.AddWithValue("@imgpath", TextBox3.Text) ' Save File Path in Database
                cmd.Parameters.AddWithValue("@added_by", Label16.Text)


                ' Execute Query
                cmd.ExecuteNonQuery()

                ' Close Connection
                conn.Close()

                ' Success Message
                MessageBox.Show("Item Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Ensure Connection Closes
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End Using
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            Login.Show()
        End If
    End Sub
    Private Sub Loaddata1()
        Dim connectionString As String = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM additem"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") ' Format: YYYY-MM-DD HH:MM:SS AM/PM
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 AndAlso DataGridView1.SelectedRows.Count > 0 Then
            Button2.Visible = True ' Show Delete button
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionString As String = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get selected row's primary key value (assuming item_no is unique)
            Dim selectedRow As Integer = DataGridView1.CurrentCell.RowIndex
            Dim itemNo As String = DataGridView1.Rows(selectedRow).Cells("slno").Value.ToString()

            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim query As String = "DELETE FROM additem WHERE slno = @slno"
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@slno", itemNo)

                    If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Record Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh DataGridView
                        Loaddata1()

                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Else
            MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub editpage_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Loaddata1()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Dim imagePath As String = "C:\Users\Manush G R\Downloads\add-image.png" ' Change this path to your actual image
        If System.IO.File.Exists(imagePath) Then
            ' Load the image into PictureBox4
            PictureBox5.Image = Image.FromFile(imagePath)
        Else
            MessageBox.Show("Image not found at: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub
End Class