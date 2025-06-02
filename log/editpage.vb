Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports Microsoft.Data.SqlClient

Public Class editpage
    Private connectionString As String = "Data Source=(local);Initial Catalog=SE Project;Integrated Security=True;Trust Server Certificate=True"

    Private Sub editpage_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        LoadData()
    End Sub

    Private Sub editpage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        Timer1.Start()
        Label1.Text = Session.LoggedInName
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
    End Sub

    Private Sub LoadData()
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM useritem ORDER BY slno"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error loading data: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim slno As Integer = Convert.ToInt32(selectedRow.Cells("slno").Value)
            Dim itemName As String = selectedRow.Cells("itemname").Value.ToString()

            Dim selectedDateTime As String = Label9.Text
            Dim status As String = ""

            If RadioButton1.Checked Then
                status = "Yes"
            ElseIf RadioButton2.Checked Then
                status = "No"
            Else
                MessageBox.Show("Please select Yes or No before updating.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim query As String = "UPDATE useritem SET status1 = @Status1, returnsts = @returnsts WHERE slno = @slno"
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Status1", status)
                    cmd.Parameters.AddWithValue("@returnsts", selectedDateTime)
                    cmd.Parameters.AddWithValue("@slno", slno)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If status = "Yes" Then
                        ' Get itemname from selected row

                        ' Update quantity
                        Dim updateQtyQuery As String = "UPDATE additem SET quantity = quantity + 1 WHERE item_name = @item_name"
                        Dim updateCmd As New SqlCommand(updateQtyQuery, conn)
                        updateCmd.Parameters.AddWithValue("@item_name", itemName)
                        updateCmd.ExecuteNonQuery()
                    End If
                    If rowsAffected > 0 Then
                        MessageBox.Show("Return status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No matching record found to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    RadioButton1.Checked = False
                    RadioButton2.Checked = False
                    LoadData()
                Catch ex As Exception
                    MessageBox.Show("Error updating data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conn.Close()
                End Try
            End Using
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim slno As Integer = Convert.ToInt32(selectedRow.Cells("slno").Value)

            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim deleteQuery As String = "DELETE FROM useritem WHERE slno = @slno"
                    Dim deleteCmd As New SqlCommand(deleteQuery, conn)
                    deleteCmd.Parameters.AddWithValue("@slno", slno)
                    Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No matching record found to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    LoadData()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Else
            MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        FilterDataByDate(DateTimePicker1.Value)
    End Sub

    Private Sub FilterDataByDate(selectedDate As DateTime)
        Dim formattedDate As String = selectedDate.ToString("dd-MM-yyyy")

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM useritem WHERE FORMAT(datetime1, 'dd-MM-yyyy') = @selectedDate"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@selectedDate", formattedDate)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error filtering data: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Home.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Home.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        additem.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        additem.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        About.Show()
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        About.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Close()
            Login.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label9.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.ScrollBars = ScrollBars.Both
    End Sub
End Class
