Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Data.SqlClient
Imports MySqlConnector
Imports Windows.Win32.System

Public Class Home
    Public connectionString As String = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Adminuserview.Show()
        Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        additem.Show()
        Me.Hide()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadItemNames()
        PictureBox4.Show()
        TextBox2.CharacterCasing = CharacterCasing.Upper
        Label1.Text = Session.LoggedInName

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        additem.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        additem.Show()
        Me.Hide()
    End Sub


    Private Sub PictureBox5_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.LightBlue ' Change background color when mouse enters
    End Sub

    Private Sub PictureBox5_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.Transparent ' Reset background color when mouse leaves
    End Sub

    Private Sub PictureBox6_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.LightBlue ' Change background color when mouse enters
    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.Transparent ' Reset background color when mouse leaves
    End Sub

    Private Sub PictureBox11_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.LightBlue ' Change background color when mouse enters
    End Sub

    Private Sub PictureBox11_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.Transparent ' Reset background color when mouse leaves
    End Sub

    Private Sub PictureBox12_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.LightBlue ' Change background color when mouse enters
    End Sub

    Private Sub PictureBox12_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.Transparent ' Reset background color when mouse leaves
    End Sub
    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        editpage.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        About.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        editpage.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click


    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        editpage.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        About.Show()
    End Sub
    Private Sub LoadItemNames()
        Try
            Using con As New SqlConnection(connectionString)
                Dim query As String = "SELECT DISTINCT item_name FROM additem"
                Dim cmd As New SqlCommand(query, con)
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                ComboBox1.Items.Clear()
                While reader.Read()
                    ComboBox1.Items.Add(reader("item_name").ToString())
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem = ComboBox1.SelectedItem.ToString

            ' Check if the selected item is not empty
            If Not String.IsNullOrWhiteSpace(selectedItem) Then

                LoadItemImage(selectedItem)
            End If
        Else
            MessageBox.Show("No item selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        If ComboBox1.SelectedItem IsNot Nothing Then

        End If


    End Sub

    Private Sub LoadItemImage(selectedItemNo As String)
        Try
            Using con As New SqlConnection(connectionString)
                Dim query As String = "SELECT img_path FROM additem WHERE item_name = @item_name"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@item_name", selectedItemNo)
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim imagePath As String = reader("img_path").ToString()
                    If File.Exists(imagePath) Then
                        PictureBox4.Image = Image.FromFile(imagePath)
                    Else
                        PictureBox4.Image = Nothing
                        MessageBox.Show("Image file not found: " & imagePath)
                    End If
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub ComboBox1_TextUpdate(sender As Object, e As EventArgs) Handles ComboBox1.TextUpdate
        Dim searchText = ComboBox1.Text.ToLower
        ComboBox1.DroppedDown = True
        If searchText = "" Then
            LoadItemNames()
        Else
            Dim foundItems = ComboBox1.Items.Cast(Of String).Where(Function(item) item.ToLower.Contains(searchText)).ToList
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(foundItems.ToArray)
        End If
        ComboBox1.SelectionStart = searchText.Length
        ComboBox1.SelectionLength = 0
    End Sub

    Private Sub ComboBox2_TextUpdate(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = ""

        ComboBox4.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        Dim imagePath As String = "C:\Users\Manush G R\OneDrive\Desktop\se project\img not available.png" ' Change this path to your actual image

        ' Check if the file exists to avoid errors
        If System.IO.File.Exists(imagePath) Then
            ' Load the image into PictureBox4
            PictureBox4.Image = Image.FromFile(imagePath)
        Else
            MessageBox.Show("Image not found at: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox4.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("Please fill in all fields before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Get values from UI elements
        Dim itemName As String = ComboBox1.Text

        Dim userName As String = TextBox1.Text
        Dim refID As String = TextBox2.Text
        Dim department As String = ComboBox4.Text
        Dim dateTime As String = Label14.Text ' Assuming Label11 contains the current time

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO useritem ( itemname,itemno, username, refid, dept, datetime1, added_by) VALUES ( @itemname, @itemno, @username, @refid, @dept, @datetime1, @added_by)"
                Dim cmd As New SqlCommand(query, conn)

                ' Assign values to parameters
                cmd.Parameters.AddWithValue("@itemname", itemName)
                cmd.Parameters.AddWithValue("@itemno", TextBox3.Text)
                cmd.Parameters.AddWithValue("@username", userName)
                cmd.Parameters.AddWithValue("@refid", refID)
                cmd.Parameters.AddWithValue("@dept", department)
                cmd.Parameters.AddWithValue("@datetime1", dateTime)
                cmd.Parameters.AddWithValue("@added_by", Label1.Text)


                Dim cmdUpdate As New SqlCommand("UPDATE additem SET quantity = quantity - 1 WHERE item_name = @itemname", conn)
                cmdUpdate.Parameters.AddWithValue("@itemname", itemName)
                cmdUpdate.ExecuteNonQuery()
                ' Execute the query
                cmd.ExecuteNonQuery()

                ' Success message
                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Optionally, clear fields after saving
                ClearFields()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Function to clear all input fields after saving
    Private Sub ClearFields()
        ComboBox1.SelectedIndex = -1

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox4.SelectedIndex = -1
        Dim imagePath As String = "C:\Users\Manush G R\OneDrive\Desktop\se project\img not available.png" ' Change this path to your actual image

        ' Check if the file exists to avoid errors
        If System.IO.File.Exists(imagePath) Then
            ' Load the image into PictureBox4
            PictureBox4.Image = Image.FromFile(imagePath)
        Else
            MessageBox.Show("Image not found at: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label14.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") ' Format: YYYY-MM-DD HH:MM:SS AM/PM
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Close()
            Login.Show()
        End If
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class