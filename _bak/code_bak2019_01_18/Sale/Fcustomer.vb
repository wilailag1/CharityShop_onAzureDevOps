Public Class Fcustomer
    Dim ID_cus, c_name, c_add, c_tel As String

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Hide()
    End Sub

    Private Sub runid()
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strrun As String = "SELECT TOP 1 ID_cus FROM T_cus ORDER BY ID_cus DESC"
        Dim cmd As New OleDb.OleDbCommand(strrun, conn)
        Dim adp As New OleDb.OleDbDataAdapter(cmd)
        Dim dr As OleDb.OleDbDataReader
        Dim idrun As Integer = 0
        Try
            With cmd
                .CommandType = CommandType.Text
                .CommandText = strrun
                .Connection = conn
                dr = .ExecuteReader()
                dr.Read()

                idrun = CInt(dr.Item("ID_cus"))
                idrun = idrun + 1
                txtcid.Text = idrun.ToString("00000000")
            End With
        Catch
            txtcid.Text = "10000001"
        End Try
    End Sub

    Private Sub Fcustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select * from T_cus"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสลูกค้า"
                .Columns(1).HeaderText = "ชื่อลูกค้า"
                .Columns(2).HeaderText = "ที่อยู่"
                .Columns(3).HeaderText = "เบอร์โทรศัพท์"

                .Columns(0).Width = 100
                .Columns(1).Width = 150
                .Columns(2).Width = 440
                .Columns(3).Width = 150
            End If
        End With
        runid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        If txtcname.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtcname.Focus()
        ElseIf txtcadd.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtcadd.Focus()
        ElseIf txtctel.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtctel.Focus()
        Else
            Dim strinsert As String = "insert into T_cus(ID_cus,c_name,c_add,c_tel) values('" & txtcid.Text & "','" & txtcname.Text & "','" & txtcadd.Text & "','" & txtctel.Text & "')"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()
            Dim strshow As String = "select * from T_cus"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtcid.Clear()
            txtcname.Clear()
            txtcadd.Clear()
            txtctel.Clear()
            runid()
            txtcname.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtcid.Clear()
        txtcname.Clear()
        txtcadd.Clear()
        txtctel.Clear()
        runid()
        txtcname.Focus()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        ID_cus = DataGridView1.Rows.Item(e.RowIndex).Cells("ID_cus").Value.ToString()
        c_name = DataGridView1.Rows.Item(e.RowIndex).Cells("c_name").Value.ToString()
        c_add = DataGridView1.Rows.Item(e.RowIndex).Cells("c_add").Value.ToString()
        c_tel = DataGridView1.Rows.Item(e.RowIndex).Cells("c_tel").Value.ToString()

        txtcid.Text = ID_cus
        txtcname.Text = c_name
        txtcadd.Text = c_add
        txtctel.Text = c_tel
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        If txtcname.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtcname.Focus()
        ElseIf txtcadd.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtcadd.Focus()
        ElseIf txtctel.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtctel.Focus()
        Else
            Dim strupdate As String = "update T_cus set c_name = '" & txtcname.Text & "',c_add = '" & txtcadd.Text & "',c_tel = '" & txtctel.Text & "' where ID_cus = '" & txtcid.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strupdate, conn)
            cmd.ExecuteNonQuery()
            Dim strshow As String = "select * from T_cus"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtcid.Clear()
            txtcname.Clear()
            txtcadd.Clear()
            txtctel.Clear()
            runid()
            txtcname.Focus()
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim vbyesno As Integer = MsgBox("ต้องการลบหรือไม่", 36, "ลบข้อมูล")
        If vbyesno = vbYes Then
            Dim strdelete As String = "delete from T_cus where ID_cus = '" & txtcid.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strdelete, conn)
            cmd.ExecuteNonQuery()
            Dim strshow As String = "select * from T_cus"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            MessageBox.Show("ลบข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtcid.Clear()
            txtcname.Clear()
            txtcadd.Clear()
            txtctel.Clear()
            runid()
            txtcname.Focus()
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized

            PrintPreviewDialog2.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog2.WindowState = FormWindowState.Maximized

            PrintPreviewDialog3.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog3.WindowState = FormWindowState.Maximized

            PrintPreviewDialog4.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog4.WindowState = FormWindowState.Maximized

            PrintPreviewDialog5.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog5.WindowState = FormWindowState.Maximized

            PrintPreviewDialog6.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog6.WindowState = FormWindowState.Maximized

            PrintPreviewDialog7.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog7.WindowState = FormWindowState.Maximized

            PrintPreviewDialog8.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog8.WindowState = FormWindowState.Maximized

            PrintPreviewDialog9.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog9.WindowState = FormWindowState.Maximized

            PrintPreviewDialog10.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog10.WindowState = FormWindowState.Maximized

            If DataGridView1.Rows.Count <= 31 Then
                PrintPreviewDialog1.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 62 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 93 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 121 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
                PrintPreviewDialog4.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 151 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
                PrintPreviewDialog4.ShowDialog()
                PrintPreviewDialog5.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 181 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
                PrintPreviewDialog4.ShowDialog()
                PrintPreviewDialog5.ShowDialog()
                PrintPreviewDialog6.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 211 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
                PrintPreviewDialog4.ShowDialog()
                PrintPreviewDialog5.ShowDialog()
                PrintPreviewDialog6.ShowDialog()
                PrintPreviewDialog7.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 241 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
                PrintPreviewDialog4.ShowDialog()
                PrintPreviewDialog5.ShowDialog()
                PrintPreviewDialog6.ShowDialog()
                PrintPreviewDialog7.ShowDialog()
                PrintPreviewDialog8.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 271 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
                PrintPreviewDialog4.ShowDialog()
                PrintPreviewDialog5.ShowDialog()
                PrintPreviewDialog6.ShowDialog()
                PrintPreviewDialog7.ShowDialog()
                PrintPreviewDialog8.ShowDialog()
                PrintPreviewDialog9.ShowDialog()
            ElseIf DataGridView1.Rows.Count <= 301 Then
                PrintPreviewDialog1.ShowDialog()
                PrintPreviewDialog2.ShowDialog()
                PrintPreviewDialog3.ShowDialog()
                PrintPreviewDialog4.ShowDialog()
                PrintPreviewDialog5.ShowDialog()
                PrintPreviewDialog6.ShowDialog()
                PrintPreviewDialog7.ShowDialog()
                PrintPreviewDialog8.ShowDialog()
                PrintPreviewDialog9.ShowDialog()
                PrintPreviewDialog10.ShowDialog()
            End If
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 30 Then
            For i = 0 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 30 Then
            For i = 0 To 29
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("1", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 60 Then
            For i = 30 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 60 Then
            For i = 30 To 59
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("2", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument3_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 90 Then
            For i = 60 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 90 Then
            For i = 60 To 89
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("3", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument4_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument4.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 120 Then
            For i = 90 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 120 Then
            For i = 90 To 119
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("4", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument5_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument5.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 150 Then
            For i = 120 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 150 Then
            For i = 120 To 149
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("5", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument6_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument6.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 180 Then
            For i = 150 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 180 Then
            For i = 150 To 179
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("6", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument7_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument7.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 210 Then
            For i = 180 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 210 Then
            For i = 180 To 209
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("7", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument8_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument8.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 240 Then
            For i = 210 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 240 Then
            For i = 210 To 239
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("8", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument9_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument9.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 270 Then
            For i = 240 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 270 Then
            For i = 240 To 269
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("9", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument10_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument10.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ข้อมูลลูกค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 70, 70)
        e.Graphics.DrawString("ชื่อลูกค้า", Font, Brush, 200, 70)
        e.Graphics.DrawString("ที่อยู่", Font, Brush, 430, 70)
        e.Graphics.DrawString("เบอร์โทรศัพท์", Font, Brush, 630, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 300 Then
            For i = 270 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 180, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 300, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 610, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("10", Font, Brush, 750, 10)
    End Sub
End Class