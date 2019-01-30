Public Class Faddpro_retail

    Private Sub Faddpro_retail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select ID_pro,p_name,p_type,p_price_cost,p_price_sale,p_unit from T_pro_retail"
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
                .Columns(5).HeaderText = "หน่วย"

                .Columns(0).Width = 100
                .Columns(1).Width = 340
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
            End If
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim pp As Double = txtpprice_cost.Text
        txtpprice_cost.Text = pp.ToString("#,###,##0.00")
        Dim p1 As Double = txtpprice_sale.Text
        txtpprice_sale.Text = p1.ToString("#,###,##0.00")
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
            Dim strinsert As String = "insert into T_pro_retail(ID_pro,p_name,p_price_cost,p_price_sale,p_num,p_unit,p_bal,p_type) values('" & txtpid.Text & "','" & txtpname.Text & "','" & txtpprice_cost.Text & "','" & txtpprice_sale.Text & "','0','" & txtpunit.Text & "','0','" & txtptype.Text & "')"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()
            Dim strshow As String = "select ID_pro,p_name,p_type,p_price_cost,p_price_sale,p_unit from T_pro_retail"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
            txtpid.Clear()
            txtpname.Clear()
            txtpprice_cost.Clear()
            txtpprice_sale.Clear()
            txtpunit.Clear()
            txtptype.Clear()
            txtpid.Focus()
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtpid.Clear()
        txtpname.Clear()
        txtpprice_cost.Clear()
        txtpprice_sale.Clear()
        txtpunit.Clear()
        txtptype.Clear()
        txtpid.Focus()
    End Sub

    Private Sub txtpid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strselect As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit from T_pro_retail where ID_pro = '" & txtpid.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strselect, conn)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            dr.Read()
            If DataGridView1.Rows.Count = vbNull Then
                txtpname.Focus()
            Else
                MessageBox.Show("ข้อมูลซ้ำ", "แจ้งเตือน")
                txtpid.Clear()
            End If
            Dim strshow As String = "select ID_pro,p_name,p_price_cost,p_price_sale,p_unit from T_pro_retail"
            Dim adp1 As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt1 As New DataTable
            adp1.Fill(dt1)
            DataGridView1.DataSource = dt1
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtpid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpid.TextChanged

    End Sub
End Class