Public Class Fpro_retail
    Dim ID_pro, p_name, p_type, p_price_cost, p_price_sale, p_unit As String
    Dim p_num As Integer

    Private Sub Fpro_retail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select ID_pro,p_name,p_type,p_price_cost,p_price_sale,p_num,p_unit from T_pro_retail"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสสินค้า"
                .Columns(1).HeaderText = "ชื่อสินค้า"
                .Columns(2).HeaderText = "ประเภทสินค้า"
                .Columns(3).HeaderText = "ราคาทุน"
                .Columns(4).HeaderText = "ราคาขาย"
                .Columns(5).HeaderText = "จำนวน"
                .Columns(6).HeaderText = "หน่วย"

                .Columns(0).Width = 100
                .Columns(1).Width = 240
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
                .Columns(6).Width = 100
            End If
        End With
    End Sub

    Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        ID_pro = DataGridView1.Rows.Item(e.RowIndex).Cells("ID_pro").Value.ToString()
        p_name = DataGridView1.Rows.Item(e.RowIndex).Cells("p_name").Value.ToString()
        p_type = DataGridView1.Rows.Item(e.RowIndex).Cells("p_type").Value.ToString()
        p_price_cost = DataGridView1.Rows.Item(e.RowIndex).Cells("p_price_cost").Value.ToString()
        p_price_sale = DataGridView1.Rows.Item(e.RowIndex).Cells("p_price_sale").Value.ToString()
        p_unit = DataGridView1.Rows.Item(e.RowIndex).Cells("p_unit").Value.ToString()
        p_num = DataGridView1.Rows.Item(e.RowIndex).Cells("p_num").Value.ToString()

        txtpid.Text = ID_pro
        txtpname.Text = p_name
        txtptype.Text = p_type
        txtpprice_cost.Text = p_price_cost
        txtpprice_sale.Text = p_price_sale
        txtpunit.Text = p_unit
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit,p_num from T_pro_retail order by ID_pro asc"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt

        txtpid.Clear()
        txtpname.Clear()
        txtptype.Clear()
        txtpprice_cost.Clear()
        txtpprice_sale.Clear()
        txtpunit.Clear()
        txtpsearch.Focus()
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim pp As Double = txtpprice_cost.Text
        txtpprice_cost.Text = pp.ToString("#,###,##0.00")
        Dim p1 As Double = txtpprice_sale.Text
        txtpprice_sale.Text = p1.ToString("#,###,##0.00")

        Dim bsum As Double = pp * p_num

        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        If txtpname.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtpname.Focus()
        ElseIf txtpprice_cost.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtpprice_cost.Focus()
        ElseIf txtpprice_sale.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtpprice_sale.Focus()
        ElseIf txtpunit.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtpunit.Focus()
        Else
            Dim strinsert As String = "update T_pro_retail set p_name = '" & txtpname.Text & "',p_type = '" & txtptype.Text & "',p_price_cost = '" & txtpprice_cost.Text & "',p_price_sale = '" & txtpprice_sale.Text & "',p_unit = '" & txtpunit.Text & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()
            Dim strinsert1 As String = "update T_bar_retail set p_name = '" & txtpname.Text & "',p_type = '" & txtptype.Text & "',p_price_cost = '" & txtpprice_cost.Text & "',p_price_sale = '" & txtpprice_sale.Text & "',p_unit = '" & txtpunit.Text & "' where ID_pro = '" & txtpid.Text & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strinsert1, conn)
            cmd1.ExecuteNonQuery()
            Dim strshow As String = "select ID_pro,p_name,p_type,p_price_cost,p_price_sale,p_num,p_unit from T_pro_retail order by ID_pro asc"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt

            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtpid.Clear()
            txtpname.Clear()
            txtptype.Clear()
            txtpprice_cost.Clear()
            txtpprice_sale.Clear()
            txtpunit.Clear()
            Button2.Enabled = False
            Button3.Enabled = False
            txtpsearch.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim vbyesno As Integer = MsgBox("ต้องการลบหรือไม่", 36, "ลบข้อมูล")
        If vbyesno = vbYes Then
            Dim strdelete As String = "delete from T_pro_retail where ID_pro = '" & txtpid.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strdelete, conn)
            cmd.ExecuteNonQuery()
            Dim strdelete1 As String = "delete from T_bar_retail where ID_pro = '" & txtpid.Text & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strdelete1, conn)
            cmd1.ExecuteNonQuery()
            Dim strshow As String = "select ID_pro,p_name,p_type,p_price_cost,p_price_sale,p_num,p_unit from T_pro_retail order by ID_pro asc"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt

            With DataGridView1
                If .RowCount > 0 Then
                    .Columns(5).Visible = False
                End If
            End With

            MessageBox.Show("ลบข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtpid.Clear()
            txtpname.Clear()
            txtptype.Clear()
            txtpprice_cost.Clear()
            txtpprice_sale.Clear()
            txtpunit.Clear()
            Button2.Enabled = False
            Button3.Enabled = False
            txtpsearch.Focus()
        End If
    End Sub

    Private Sub txtpsearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strselect As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit,p_num from T_pro_whole where ID_pro = '" & txtpsearch.Text & "' order by ID_pro asc"
            Dim cmd As New OleDb.OleDbCommand(strselect, conn)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt

            dr.Read()
            If DataGridView1.Rows.Count = vbNull Then
                MessageBox.Show("ไม่พบข้อมูล", "แจ้งเตือน")
            End If
            txtpsearch.Clear()
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 30 Then
            For i = 0 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 30 Then
            For i = 0 To 29
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 60 Then
            For i = 30 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 60 Then
            For i = 30 To 59
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 90 Then
            For i = 60 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 90 Then
            For i = 60 To 89
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 120 Then
            For i = 90 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 120 Then
            For i = 90 To 89
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 150 Then
            For i = 120 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 150 Then
            For i = 120 To 149
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 180 Then
            For i = 150 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 180 Then
            For i = 150 To 179
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 210 Then
            For i = 180 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 210 Then
            For i = 180 To 209
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 240 Then
            For i = 210 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 240 Then
            For i = 210 To 239
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 270 Then
            For i = 240 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        ElseIf DataGridView1.Rows.Count > 270 Then
            For i = 240 To 269
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
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

        e.Graphics.DrawString("ข้อมูลสินค้า", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 110, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 310, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 470, 70)
        e.Graphics.DrawString("ราคาขาย", Font, Brush, 570, 70)
        e.Graphics.DrawString("หน่วย", Font, Brush, 675, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 300 Then
            For i = 270 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 240, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 650, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 680, j)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("10", Font, Brush, 750, 10)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class