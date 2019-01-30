Public Class Fbar_whole
    Dim number As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Randomize()
        number = Int(Rnd() * 999999999) + 1
        txtpid.Text = "*a-" & number.ToString("000000000") & "-o*"
        txtbarcode.Text = txtpid.Text

        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strselect As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit from T_bar_whole where ID_pro = '" & txtpid.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView2.DataSource = dt
        Dim i As Integer
        For i = 0 To DataGridView2.Rows.Count = vbNull
            Randomize()
            number = Int(Rnd() * 999999999) + 1
            txtpid.Text = "*a-" & number.ToString("000000000") & "-o*"
            txtbarcode.Text = txtpid.Text
        Next
        txtpname.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
            Dim pp As Double = txtpprice_cost.Text
            txtpprice_cost.Text = pp.ToString("#,###,##0.00")
            Dim p1 As Double = txtpprice_sale.Text
            txtpprice_sale.Text = p1.ToString("#,###,##0.00")

            Dim strinsert As String = "insert into T_pro_whole(ID_pro,p_name,p_price_cost,p_price_sale,p_num,p_unit,p_bal) values('" & txtpid.Text & "','" & txtpname.Text & "','" & txtpprice_cost.Text & "','" & txtpprice_sale.Text & "','0','" & txtpunit.Text & "','0')"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()
            Dim strinsert1 As String = "insert into T_bar_whole(ID_pro,p_name,p_price_cost,p_price_sale,p_unit,b_date) values('" & txtpid.Text & "','" & txtpname.Text & "','" & txtpprice_cost.Text & "','" & txtpprice_sale.Text & "','" & txtpunit.Text & "','" & DateTimePicker1.Text & "')"
            Dim cmd1 As New OleDb.OleDbCommand(strinsert1, conn)
            cmd1.ExecuteNonQuery()
            Dim strshow As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit from T_bar_whole where b_date = '" & DateTimePicker1.Text & "'"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtpid.Clear()
            txtbarcode.Clear()
            txtpname.Clear()
            txtpprice_cost.Clear()
            txtpprice_sale.Clear()
            txtpunit.Clear()
            txtpid.Focus()
        End If
    End Sub

    Private Sub Fbar_whole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit from T_bar_whole where b_date = '" & DateTimePicker1.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัสสินค้า"
                .Columns(1).HeaderText = "ชื่อสินค้า"
                .Columns(2).HeaderText = "ราคาทุน"
                .Columns(3).HeaderText = "ราคาขาย"
                .Columns(4).HeaderText = "หน่วย"

                .Columns(0).Width = 100
                .Columns(1).Width = 440
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
            End If
        End With
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit from T_bar_whole where b_date = '" & DateTimePicker1.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtpid.Clear()
        txtbarcode.Clear()
        txtpname.Clear()
        txtpprice_cost.Clear()
        txtpprice_sale.Clear()
        txtpunit.Clear()
        txtpname.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        PrintDialog1.ShowDialog()
        PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim Font As New Font("AngsanaUPC", 10), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 22)
        Dim Font2 As New Font("AngsanaUPC", 25)
        Dim barc As New Font("3 of 9 Barcode", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("-- รหัสบาร์โค้ด", Font2, Brush, 110, 10)
        e.Graphics.DrawString("-- ชื่อสินค้า", Font2, Brush, 500, 10)

        Dim i As Integer = 0
        Dim j As Integer = 80
        For i = 0 And j To DataGridView1.Rows.Count - 2
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, barc, Brush, 30, j)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(0).Value, Font1, Brush, 110, j + 20)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(1).Value, Font1, Brush, 500, j)
            j = j + 70
        Next
    End Sub
End Class