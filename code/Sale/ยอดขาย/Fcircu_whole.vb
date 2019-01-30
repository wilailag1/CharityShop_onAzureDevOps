Public Class Fcircu_whole
    Dim ID_cus, c_name As String

    Private Sub autocal()
        Dim tprice As Double = 0
        Dim tcost As Double = 0
        Dim i As Integer = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            tcost += CDbl(DataGridView2.Rows(i).Cells(8).Value)
            tprice += CDbl(DataGridView2.Rows(i).Cells(9).Value)
        Next
        txtallnet.Text = tprice.ToString("#,###,##0.00")
        txtallcost.Text = tcost.ToString("#,###,##0.00")
        Dim net As Double = txtallnet.Text
        Dim cost As Double = txtallcost.Text
        Dim profit As Double = net - cost
        txtprofit.Text = profit.ToString("#,###,##0.00")
    End Sub

    Private Sub Fcircu_whole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strselect As String = "select * from T_sale_whole_deteil where s_date = '" & DateTimePicker1.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView2.DataSource = dt
        With DataGridView2
            If .RowCount > 0 Then
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "รหัสการขาย"
                .Columns(2).HeaderText = "วันที่ขาย"
                .Columns(3).HeaderText = "รหัสสินค้า"
                .Columns(4).HeaderText = "ชื่อสินค้า"
                .Columns(5).HeaderText = "จำนวน"
                .Columns(6).HeaderText = "หน่วย"
                .Columns(7).HeaderText = "ส่วนลด"
                .Columns(8).HeaderText = "ราคาทุนรวม"
                .Columns(9).HeaderText = "ราคาขายรวม"
                .Columns(10).Visible = False

                .Columns(1).Width = 131
                .Columns(2).Width = 131
                .Columns(3).Width = 131
                .Columns(4).Width = 131
                .Columns(5).Width = 131
                .Columns(6).Width = 131
                .Columns(7).Width = 131
                .Columns(8).Width = 131
                .Columns(9).Width = 131
            End If
        End With

        Dim strselect1 As String = "select * from T_sale_whole where s_date = '" & DateTimePicker1.Text & "'"
        Dim adp1 As New OleDb.OleDbDataAdapter(strselect1, conn)
        Dim dt1 As New DataTable
        adp1.Fill(dt1)
        DataGridView1.DataSource = dt1
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสการขาย"
                .Columns(1).HeaderText = "รหัสลูกค้า"
                .Columns(2).HeaderText = "วันที่ขาย"
                .Columns(3).HeaderText = "ราคาทุน"
                .Columns(4).HeaderText = "ยอดขาย"

                .Columns(0).Width = 236
                .Columns(1).Width = 236
                .Columns(2).Width = 236
                .Columns(3).Width = 236
                .Columns(4).Width = 236
            End If
        End With
        autocal()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()
        If txtcid.Text = "" Then
            Dim strselect1 As String = "select * from T_sale_whole where s_date = '" & DateTimePicker1.Text & "'"
            Dim adp1 As New OleDb.OleDbDataAdapter(strselect1, conn)
            Dim dt1 As New DataTable
            adp1.Fill(dt1)
            DataGridView1.DataSource = dt1

            Dim strselect As String = "select * from T_sale_whole_deteil where s_date = '" & DateTimePicker1.Text & "'"
            Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView2.DataSource = dt

        Else
            Dim strselect1 As String = "select * from T_sale_whole where s_date = '" & DateTimePicker1.Text & "' and ID_cus = '" & txtcid.Text & "'"
            Dim adp1 As New OleDb.OleDbDataAdapter(strselect1, conn)
            Dim dt1 As New DataTable
            adp1.Fill(dt1)
            DataGridView1.DataSource = dt1

            Dim strselect As String = "select * from T_sale_whole_deteil where s_date = '" & DateTimePicker1.Text & "'and ID_cus = '" & txtcid.Text & "'"
            Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView2.DataSource = dt
        End If
        With DataGridView2
            If .RowCount > 0 Then
                .Columns(0).Visible = False
                .Columns(10).Visible = False
            End If
        End With
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสการขาย"
                .Columns(1).HeaderText = "รหัสลูกค้า"
                .Columns(2).HeaderText = "วันที่ขาย"
                .Columns(3).HeaderText = "ราคาทุน"
                .Columns(4).HeaderText = "ยอดขาย"

                .Columns(0).Width = 236
                .Columns(1).Width = 236
                .Columns(2).Width = 236
                .Columns(3).Width = 236
                .Columns(4).Width = 236
            End If
        End With
        autocal()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select * from T_cus"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView3.DataSource = dt
        With DataGridView3
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสลูกค้า"
                .Columns(1).HeaderText = "ชื่อลูกค้า"
                .Columns(2).HeaderText = "ที่อยู่"
                .Columns(3).HeaderText = "เบอร์โทรศัพท์"

                .Columns(0).Width = 100
                .Columns(1).Width = 152
                .Columns(2).Width = 256
                .Columns(3).Width = 100
            End If
        End With
        If DataGridView3.Visible = False Then
            DataGridView3.Visible = True
        ElseIf DataGridView3.Visible = True Then
            DataGridView3.Visible = False
        End If
    End Sub

    Private Sub DataGridView3_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView3.CellMouseDown
        ID_cus = DataGridView3.Rows.Item(e.RowIndex).Cells("ID_cus").Value.ToString()
        c_name = DataGridView3.Rows.Item(e.RowIndex).Cells("c_name").Value.ToString()

        txtcid.Text = ID_cus
        txtcname.Text = c_name
        DataGridView3.Visible = False

        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strselect As String = "select * from T_sale_whole_deteil where s_date = '" & DateTimePicker1.Text & "' and ID_cus = '" & txtcid.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView2.DataSource = dt

        Dim strselect1 As String = "select * from T_sale_whole where s_date = '" & DateTimePicker1.Text & "' and ID_cus = '" & txtcid.Text & "'"
        Dim adp1 As New OleDb.OleDbDataAdapter(strselect1, conn)
        Dim dt1 As New DataTable
        adp1.Fill(dt1)
        DataGridView1.DataSource = dt1
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสการขาย"
                .Columns(1).HeaderText = "รหัสลูกค้า"
                .Columns(2).HeaderText = "วันที่ขาย"
                .Columns(3).HeaderText = "ราคาทุน"
                .Columns(4).HeaderText = "ยอดขาย"

                .Columns(0).Width = 236
                .Columns(1).Width = 236
                .Columns(2).Width = 236
                .Columns(3).Width = 236
                .Columns(4).Width = 236
            End If
        End With

        autocal()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MessageBox.Show("กรุณาข้อมูลที่ต้องการพิมพ์", "แจ้งเตือน")
        Else
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

                If RadioButton1.Checked = True Then
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
                ElseIf RadioButton2.Checked = True Then
                    If DataGridView2.Rows.Count < 30 Then
                        PrintPreviewDialog1.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 30 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 60 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                        PrintPreviewDialog3.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 90 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                        PrintPreviewDialog3.ShowDialog()
                        PrintPreviewDialog4.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 120 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                        PrintPreviewDialog3.ShowDialog()
                        PrintPreviewDialog4.ShowDialog()
                        PrintPreviewDialog5.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 150 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                        PrintPreviewDialog3.ShowDialog()
                        PrintPreviewDialog4.ShowDialog()
                        PrintPreviewDialog5.ShowDialog()
                        PrintPreviewDialog6.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 180 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                        PrintPreviewDialog3.ShowDialog()
                        PrintPreviewDialog4.ShowDialog()
                        PrintPreviewDialog5.ShowDialog()
                        PrintPreviewDialog6.ShowDialog()
                        PrintPreviewDialog7.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 210 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                        PrintPreviewDialog3.ShowDialog()
                        PrintPreviewDialog4.ShowDialog()
                        PrintPreviewDialog5.ShowDialog()
                        PrintPreviewDialog6.ShowDialog()
                        PrintPreviewDialog7.ShowDialog()
                        PrintPreviewDialog8.ShowDialog()
                    ElseIf DataGridView2.Rows.Count > 240 Then
                        PrintPreviewDialog1.ShowDialog()
                        PrintPreviewDialog2.ShowDialog()
                        PrintPreviewDialog3.ShowDialog()
                        PrintPreviewDialog4.ShowDialog()
                        PrintPreviewDialog5.ShowDialog()
                        PrintPreviewDialog6.ShowDialog()
                        PrintPreviewDialog7.ShowDialog()
                        PrintPreviewDialog8.ShowDialog()
                        PrintPreviewDialog9.ShowDialog()
                    ElseIf DataGridView2.Rows.Count <= 300 Then
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
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strselect As String = "select * from T_sale_whole_deteil where s_date = '" & DateTimePicker1.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView2.DataSource = dt
        With DataGridView2
            If .RowCount > 0 Then
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "รหัสการขาย"
                .Columns(2).HeaderText = "วันที่ขาย"
                .Columns(3).HeaderText = "รหัสสินค้า"
                .Columns(4).HeaderText = "ชื่อสินค้า"
                .Columns(5).HeaderText = "จำนวน"
                .Columns(6).HeaderText = "หน่วย"
                .Columns(7).HeaderText = "ส่วนลด"
                .Columns(8).HeaderText = "ราคาทุนรวม"
                .Columns(9).HeaderText = "ราคาขายรวม"
                .Columns(10).Visible = False

                .Columns(1).Width = 131
                .Columns(2).Width = 131
                .Columns(3).Width = 131
                .Columns(4).Width = 131
                .Columns(5).Width = 131
                .Columns(6).Width = 131
                .Columns(7).Width = 131
                .Columns(8).Width = 131
                .Columns(9).Width = 131
            End If
        End With

        Dim strselect1 As String = "select * from T_sale_whole where s_date = '" & DateTimePicker1.Text & "'"
        Dim adp1 As New OleDb.OleDbDataAdapter(strselect1, conn)
        Dim dt1 As New DataTable
        adp1.Fill(dt1)
        DataGridView1.DataSource = dt1
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสการขาย"
                .Columns(1).HeaderText = "รหัสลูกค้า"
                .Columns(2).HeaderText = "วันที่ขาย"
                .Columns(3).HeaderText = "ราคาทุน"
                .Columns(4).HeaderText = "ยอดขาย"

                .Columns(0).Width = 236
                .Columns(1).Width = 236
                .Columns(2).Width = 236
                .Columns(3).Width = 236
                .Columns(4).Width = 236
            End If
        End With
        autocal()
        txtcid.Clear()
        txtcname.Clear()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 30 Then
                For i = 0 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 30 Then
                For i = 0 To 29
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 30 Then
                For ii = 0 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 30 Then
                For ii = 0 To 29
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("1", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 60 Then
                For i = 30 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 60 Then
                For i = 30 To 59
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 60 Then
                For ii = 30 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 60 Then
                For ii = 30 To 59
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("2", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument3_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 90 Then
                For i = 60 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 90 Then
                For i = 60 To 89
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 90 Then
                For ii = 60 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 90 Then
                For ii = 60 To 89
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("3", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument4_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument4.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 120 Then
                For i = 90 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 120 Then
                For i = 90 To 119
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 120 Then
                For ii = 90 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 120 Then
                For ii = 90 To 119
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("4", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument5_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument5.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 150 Then
                For i = 120 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 150 Then
                For i = 120 To 149
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 150 Then
                For ii = 120 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 150 Then
                For ii = 120 To 149
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("5", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument6_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument6.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 180 Then
                For i = 150 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 180 Then
                For i = 150 To 179
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 180 Then
                For ii = 150 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 180 Then
                For ii = 150 To 179
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("6", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument7_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument7.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 210 Then
                For i = 180 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 210 Then
                For i = 180 To 209
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 210 Then
                For ii = 180 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 210 Then
                For ii = 180 To 209
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("7", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument8_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument8.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 240 Then
                For i = 210 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 240 Then
                For i = 210 To 239
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 240 Then
                For ii = 210 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 240 Then
                For ii = 210 To 239
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("8", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument9_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument9.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 270 Then
                For i = 240 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            ElseIf DataGridView1.Rows.Count > 270 Then
                For i = 240 To 269
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 270 Then
                For ii = 240 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            ElseIf DataGridView2.Rows.Count > 270 Then
                For ii = 240 To 269
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("9", Font, Brush, 750, 10)
    End Sub

    Private Sub PrintDocument10_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument10.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("ยอดขายสินค้า", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox2.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 70, 70)
            e.Graphics.DrawString("รหัสลูกค้า", Font, Brush, 230, 70)
            e.Graphics.DrawString("วันที่ขาย", Font, Brush, 380, 70)
            e.Graphics.DrawString("ราคาทุน", Font, Brush, 535, 70)
            e.Graphics.DrawString("ยอดขาย", Font, Brush, 675, 70)
            Dim i As Integer = 0
            Dim j As Integer = 102
            Dim k As Integer = 100
            If DataGridView1.Rows.Count <= 300 Then
                For i = 270 To DataGridView1.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font, Brush, 70, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font, Brush, 230, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(2).Value, Font, Brush, 340, j)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(3).Value, Font, Brush, 635, j, Format)
                    e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font, Brush, 785, j, Format)
                    e.Graphics.DrawImage(PictureBox3.Image, 40, k, 750, 33)
                    k = k + 30
                    j = j + 30
                Next
                e.Graphics.DrawString("ราคาทุน", Font, Brush, 50, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 250, k + 20)
                e.Graphics.DrawString("ยอดขาย", Font, Brush, 300, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 500, k + 20)
                e.Graphics.DrawString("กำไร", Font, Brush, 550, k + 20)
                e.Graphics.DrawString("บาท", Font, Brush, 750, k + 20)
                e.Graphics.DrawString(txtallcost.Text, Font, Brush, 250, k + 20, Format)
                e.Graphics.DrawString(txtallnet.Text, Font, Brush, 500, k + 20, Format)
                e.Graphics.DrawString(txtprofit.Text, Font, Brush, 750, k + 20, Format)
            End If
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("รายละเอียดการขาย", Font2, Brush, 335, 20)
            e.Graphics.DrawImage(PictureBox4.Image, 40, 70, 750, 33)
            e.Graphics.DrawString("รหัสการขาย", Font, Brush, 60, 70)
            e.Graphics.DrawString("ชื่อสินค้า", Font, Brush, 190, 70)
            e.Graphics.DrawString("จำนวน", Font, Brush, 320, 70)
            e.Graphics.DrawString("ส่วนลด", Font, Brush, 445, 70)
            e.Graphics.DrawString("ราคาทุนรวม", Font, Brush, 555, 70)
            e.Graphics.DrawString("ราคาขายรวม", Font, Brush, 680, 70)
            Dim ii As Integer = 0
            Dim jj As Integer = 102
            Dim kk As Integer = 100
            If DataGridView2.Rows.Count <= 300 Then
                For ii = 270 To DataGridView2.Rows.Count - 2
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(1).Value, Font, Brush, 60, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(4).Value, Font, Brush, 170, jj)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(5).Value, Font, Brush, 415, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(7).Value, Font, Brush, 540, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(8).Value, Font, Brush, 660, jj, Format)
                    e.Graphics.DrawString(DataGridView2.Rows(ii).Cells(9).Value, Font, Brush, 785, jj, Format)
                    e.Graphics.DrawImage(PictureBox5.Image, 40, kk, 750, 33)
                    kk = kk + 30
                    jj = jj + 30
                Next
            End If
        End If
        e.Graphics.DrawString("10", Font, Brush, 750, 10)
    End Sub
End Class