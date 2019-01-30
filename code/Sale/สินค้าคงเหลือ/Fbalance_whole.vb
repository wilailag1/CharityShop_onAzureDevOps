Public Class Fbalance_whole

    Private Sub autocal()
        Dim total As Double = 0
        Dim i As Integer = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            total += CDbl(DataGridView1.Rows(i).Cells(5).Value)
        Next
        txttotal.Text = total.ToString("#,###,##0.00")
    End Sub

    Private Sub txtpsearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strselect As String = "select ID_pro,p_name,p_price_sale,p_num,p_unit from T_pro_whole where ID_pro = '" & txtpsearch.Text & "'"
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
            txtpsearch.Focus()
        End If
    End Sub

    Private Sub Fbalance_whole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strselect As String = "select ID_pro,p_name,p_price_sale,p_num,p_unit,p_bal from T_pro_whole"
        Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสสินค้า"
                .Columns(1).HeaderText = "ชื่อสินค้า"
                .Columns(2).HeaderText = "ราคาทุน"
                .Columns(3).HeaderText = "จำนวนคงเหลือ"
                .Columns(4).HeaderText = "หน่วย"
                .Columns(5).HeaderText = "ยอดสุทธิ"

                .Columns(0).Width = 100
                .Columns(1).Width = 340
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
            End If
        End With
        autocal()
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
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 30 Then
            For i = 0 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 30 Then
            For i = 0 To 29
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("1", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 60 Then
            For i = 30 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 60 Then
            For i = 30 To 59
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("2", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument3_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 90 Then
            For i = 60 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 90 Then
            For i = 60 To 89
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("3", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument4_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument4.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 120 Then
            For i = 90 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 120 Then
            For i = 90 To 119
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("4", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument5_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument5.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 150 Then
            For i = 120 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 150 Then
            For i = 120 To 149
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("5", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument6_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument6.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 180 Then
            For i = 150 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 180 Then
            For i = 150 To 179
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("6", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument7_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument7.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 210 Then
            For i = 180 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 210 Then
            For i = 180 To 209
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("7", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument8_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument8.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 240 Then
            For i = 210 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 240 Then
            For i = 210 To 239
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("8", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument9_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument9.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 270 Then
            For i = 240 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        ElseIf DataGridView1.Rows.Count > 270 Then
            For i = 240 To 269
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
        End If
        e.Graphics.DrawString("9", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument10_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument10.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("สินค้าส่งคงเหลือ", Font2, Brush, 335, 20)
        e.Graphics.DrawImage(PictureBox2.Image, 50, 70, 700, 33)

        e.Graphics.DrawString("รหัสสินค้า", Font, Brush, 75, 70)
        e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 230, 70)
        e.Graphics.DrawString("ราคาทุน", Font, Brush, 375, 70)
        e.Graphics.DrawString("จำนวนคงเหลือ", Font1, Brush, 460, 72)
        e.Graphics.DrawString("หน่วย", Font, Brush, 580, 70)
        e.Graphics.DrawString("ยอดสุทธิ", Font, Brush, 665, 70)

        Dim i As Integer = 0
        Dim j As Integer = 102
        Dim k As Integer = 100
        If DataGridView1.Rows.Count <= 300 Then
            For i = 270 To DataGridView1.Rows.Count - 2
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 52, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 180, j + 2)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 455, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 550, j, Format)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 555, j)
                e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font, Brush, 750, j, Format)
                e.Graphics.DrawImage(PictureBox3.Image, 50, k, 700, 33)
                k = k + 30
                j = j + 30
            Next
            e.Graphics.DrawString("ยอดรวมสุทธิ", Font, Brush, 550, k + 20)
            e.Graphics.DrawString(txttotal.Text, Font, Brush, 750, k + 20, Format)
        End If
        e.Graphics.DrawString("10", Font, Brush, 750, 10)
    End Sub
End Class