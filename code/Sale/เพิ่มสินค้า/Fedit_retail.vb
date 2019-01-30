Public Class Fedit_retail
    Dim ID_pro, p_name, p_price_cost, p_price_sale, p_unit As String
    Dim p_num As Integer
    Dim bsum As Double

    Private Sub Fedit_retail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select * from T_pro_retail"
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
                .Columns(4).HeaderText = "จำนวน"
                .Columns(5).HeaderText = "หน่วย"
                .Columns(6).Visible = False
                .Columns(7).Visible = False

                .Columns(0).Width = 100
                .Columns(1).Width = 340
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
            End If
        End With
    End Sub

    Private Sub txtpsearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strselect As String = "select * from T_pro_retail where ID_pro = '" & txtpsearch.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strselect, conn)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt

            With DataGridView1
                If .RowCount > 0 Then
                    .Columns(6).Visible = False
                End If
            End With

            dr.Read()
            If DataGridView1.Rows.Count = vbNull Then
                MessageBox.Show("ไม่พบข้อมูล", "แจ้งเตือน")
            End If
            txtpsearch.Clear()
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        ID_pro = DataGridView1.Rows.Item(e.RowIndex).Cells("ID_pro").Value.ToString()
        p_name = DataGridView1.Rows.Item(e.RowIndex).Cells("p_name").Value.ToString()
        p_price_cost = DataGridView1.Rows.Item(e.RowIndex).Cells("p_price_cost").Value.ToString()
        p_price_sale = DataGridView1.Rows.Item(e.RowIndex).Cells("p_price_sale").Value.ToString()
        p_unit = DataGridView1.Rows.Item(e.RowIndex).Cells("p_unit").Value.ToString()
        p_num = DataGridView1.Rows.Item(e.RowIndex).Cells("p_num").Value.ToString()

        txtpid.Text = ID_pro
        txtpname.Text = p_name
        txtpprice_cost.Text = p_price_cost
        txtpprice_sale.Text = p_price_sale
        Label5.Text = p_unit
        txtpnum.Text = p_num
        Button1.Enabled = True
        Button3.Enabled = True
        txtnum.Enabled = True
        txtnum.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtnum.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtnum.Focus()
        Else
            Dim pnum As Integer = txtpnum.Text
            Dim num As Integer = txtnum.Text
            Dim sum As Integer
            If Button1.Text = "คำนวน" Then
                sum = pnum + num
            ElseIf Button1.Text = "ลดจำนวน" Then
                sum = pnum - num
            End If
            txtsum.Text = sum.ToString("#,###,##0")

            Dim bnum As Integer = txtsum.Text
            Dim pricecost As Integer = txtpprice_cost.Text
            bsum = pricecost * bnum
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select * from T_pro_retail"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt

        With DataGridView1
            If .RowCount > 0 Then
                .Columns(6).Visible = False
            End If
        End With

        Button1.Text = "คำนวน"
        Label5.Text = "หน่วย"
        txtpid.Clear()
        txtpname.Clear()
        txtpprice_cost.Clear()
        txtpprice_sale.Clear()
        txtpnum.Clear()
        txtnum.Clear()
        txtsum.Clear()
        txtpsearch.Focus()
        Button1.Enabled = False
        Button3.Enabled = False
        txtnum.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        If txtnum.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtnum.Focus()
        ElseIf txtsum.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtnum.Focus()
        Else
            Dim strupdate As String = "update T_pro_retail set p_num = '" & txtsum.Text & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strupdate, conn)
            cmd.ExecuteNonQuery()
            Dim strshow As String = "select * from T_pro_retail"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt

            With DataGridView1
                If .RowCount > 0 Then
                    .Columns(6).Visible = False
                End If
            End With

            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtpid.Clear()
            txtpname.Clear()
            txtpprice_cost.Clear()
            txtpprice_sale.Clear()

            txtpnum.Clear()
            txtnum.Clear()
            txtsum.Clear()
            txtpsearch.Focus()
            Button1.Enabled = False
            Button3.Enabled = False
            txtnum.Enabled = False
            Button1.Text = "คำนวน"
            Label5.Text = "หน่วย"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Text = "ลดจำนวน"
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtpsearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpsearch.TextChanged

    End Sub
End Class