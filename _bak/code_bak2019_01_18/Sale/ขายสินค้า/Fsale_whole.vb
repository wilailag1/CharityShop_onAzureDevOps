Public Class Fsale_whole
    Dim ID_cus, c_name, c_add, c_tel As String
    Dim ID_pro, p_name, p_unit As String
    Dim p_price_cost, p_price_sale As Double
    Dim p_num As Integer
    Dim costnet As Double
    Dim ID_no1, ID_sale1, ID_pro1, p_name1, p_unit1, p_totalcost1, p_totalsale1 As String
    Dim p_num1 As Integer
    Dim bsum As Double

    Private Sub autocal()
        Dim tprice As Double = 0
        Dim tcost As Double = 0
        Dim i As Integer = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            tcost += CDbl(DataGridView1.Rows(i).Cells(8).Value)
            tprice += CDbl(DataGridView1.Rows(i).Cells(9).Value)
        Next
        txtallnet.Text = tprice.ToString("#,###,##0.00")
        txtallcost.Text = tcost.ToString("#,###,##0.00")
    End Sub

    Private Sub runid()
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()
        Dim strrun As String = "SELECT TOP 1 ID_sale FROM T_sale_whole ORDER BY ID_sale DESC"
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

                idrun = CInt(dr.Item("ID_sale"))
                idrun = idrun + 1
                txtidsale.Text = idrun.ToString("0000000000")
            End With
        Catch
            txtidsale.Text = "1200000001"
        End Try
    End Sub

    Private Sub runno()
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()
        Dim strrun As String = "SELECT TOP 1 ID_no FROM T_sale_whole_deteil ORDER BY ID_no DESC"
        Dim cmd As New OleDb.OleDbCommand(strrun, conn)
        Dim adp As New OleDb.OleDbDataAdapter(cmd)
        Dim dr As OleDb.OleDbDataReader
        Dim idno As Integer = 0
        Try
            With cmd
                .CommandType = CommandType.Text
                .CommandText = strrun
                .Connection = conn
                dr = .ExecuteReader()
                dr.Read()

                idno = CInt(dr.Item("ID_no"))
                idno = idno + 1
                Label19.Text = idno.ToString("000000")
            End With
        Catch
            Label19.Text = idno.ToString("000001")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strshow As String = "select * from T_cus"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView2.DataSource = dt
        With DataGridView2
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
        If DataGridView2.Visible = False Then
            DataGridView2.Visible = True
            DataGridView2.Width = 589
            DataGridView2.Height = 122
        ElseIf DataGridView2.Visible = True Then
            DataGridView2.Visible = False
        End If

    End Sub

    Private Sub DataGridView2_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDown
        ID_cus = DataGridView2.Rows.Item(e.RowIndex).Cells("ID_cus").Value.ToString()
        c_name = DataGridView2.Rows.Item(e.RowIndex).Cells("c_name").Value.ToString()
        c_add = DataGridView2.Rows.Item(e.RowIndex).Cells("c_add").Value.ToString()
        c_tel = DataGridView2.Rows.Item(e.RowIndex).Cells("c_tel").Value.ToString()

        txtcid.Text = ID_cus
        txtcname.Text = c_name
        txtcadd.Text = c_add
        txttel.Text = c_tel
        DataGridView2.Visible = False
    End Sub

    Private Sub Fsale_whole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        runid()
        runno()
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strselect As String = "select * from T_sale_whole_deteil where ID_sale = '" & txtidsale.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "รหัสการขาย"
                .Columns(2).HeaderText = "วันที่ขาย"
                .Columns(3).HeaderText = "รหัสสินค้า"
                .Columns(4).HeaderText = "ชื่อสินค้า"
                .Columns(5).HeaderText = "จำนวน"
                .Columns(6).HeaderText = "หน่วย"
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).HeaderText = "ราคาขายรวม"
                .Columns(10).Visible = False

                .Columns(1).Width = 160
                .Columns(2).Width = 160
                .Columns(3).Width = 160
                .Columns(4).Width = 160
                .Columns(5).Width = 160
                .Columns(6).Width = 160
                .Columns(7).Width = 160
                .Columns(9).Width = 160
            End If
        End With
        autocal()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If txtpname.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtpid.Focus()
        ElseIf txtsalenum.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtsalenum.Focus()
        Else
            Dim pnum As Integer = txtpnum.Text
            Dim snum As Integer = txtsalenum.Text
            Dim pcost As Double
            Dim psale As Double
            If Button1.Text = "_" Then
                If pnum < snum Then
                    MessageBox.Show("จำนวนคงเหลือไม่พอขาย", "แจ้งเตือน")
                    txtsalenum.Clear()
                    txtsalenum.Focus()
                Else
                    pnum = txtpnum.Text
                    snum = txtsalenum.Text
                    Dim sum As Integer = pnum - snum
                    txtsum.Text = sum

                    pcost = txtpprice_cost.Text
                    psale = txtpprice_sale.Text

                    costnet = pcost * snum
                    Dim salenet As Double = psale * snum
                    txtnet.Text = salenet.ToString("#,###,##0.00")
                End If
            ElseIf Button1.Text = "-" Then
                pnum = txtpnum.Text
                snum = txtsalenum.Text
                Dim anum As Integer = p_num1 - snum
                Dim sum As Integer = pnum + anum
                txtsum.Text = sum
                If sum < 0 Then
                    MessageBox.Show("จำนวนคงเหลือไม่พอขาย", "แจ้งเตือน")
                    txtsalenum.Clear()
                    txtsalenum.Focus()
                Else
                    pcost = txtpprice_cost.Text
                    psale = txtpprice_sale.Text
                    costnet = pcost * snum
                    Dim salenet As Double = psale * snum
                    txtnet.Text = salenet.ToString("#,###,##0.00")
                End If
            End If
        End If
    End Sub

    Private Sub txtpid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strselect As String = "select * from T_pro_whole where ID_pro = '" & txtpid.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strselect, conn)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView2.DataSource = dt
            dr.Read()
            If DataGridView2.Rows.Count = vbNull Then
                MessageBox.Show("ไม่พบข้อมูล", "แจ้งเตือน")
                txtpid.Clear()
                txtpid.Focus()
            Else
                p_name = dr("p_name")
                p_price_cost = dr("p_price_cost")
                p_price_sale = dr("p_price_sale")
                p_num = dr("p_num")
                p_unit = dr("p_unit")

                txtpname.Text = p_name
                txtpprice_cost.Text = p_price_cost.ToString("#,###,##0.00")
                txtpprice_sale.Text = p_price_sale.ToString("#,###,##0.00")
                txtpnum.Text = p_num
                Label6.Text = p_unit
                Label14.Text = p_unit
                txtsalenum.Focus()
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim pp As Double = txtpprice_cost.Text
        Dim nn As Double = txtsum.Text

        bsum = pp * nn
        If txtpid.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtpid.Focus()
        ElseIf txtsalenum.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtsalenum.Focus()
        ElseIf txtnet.Text = "0.00" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtsalenum.Focus()
        ElseIf txtcid.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtcid.Focus()
        Else
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strinsert As String = "insert into T_sale_whole_deteil(ID_no,ID_sale,s_date,ID_pro,p_name,p_num,p_unit,p_dis,p_totalcost,p_totalsale,ID_cus) values('" & Label19.Text & "','" & txtidsale.Text & "','" & DateTimePicker1.Text & "','" & txtpid.Text & "','" & txtpname.Text & "','" & txtsalenum.Text & "','" & Label6.Text & "','" & txtdis.Text & "','" & costnet.ToString("#,###,##0.00") & "','" & txtnet.Text & "','" & txtcid.Text & "')"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()

            Dim strupdate As String = "update T_pro_whole set p_num = '" & txtsum.Text & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strupdate, conn)
            cmd1.ExecuteNonQuery()
            runid()
            Dim strshow As String = "select * from T_sale_whole_deteil where ID_sale = '" & txtidsale.Text & "'"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            With DataGridView1
                If .RowCount > 0 Then
                    .Columns(0).Visible = False
                End If
            End With
            MessageBox.Show("เพิ่มข้อมูลเรียบร้อย", "แจ้งเตือน")

            runno()
            txtpid.Clear()
            txtpname.Clear()
            txtsalenum.Clear()
            txtnet.Text = "0.00"
            txtpnum.Text = "0"
            txtsum.Text = "0"
            txtpprice_cost.Text = "0.00"
            txtpprice_sale.Text = "0.00"
            Label6.Text = ".........."
            Label14.Text = ".........."
            txtpid.Focus()
            autocal()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        runid()
        runno()
        txtpid.Clear()
        txtpname.Clear()
        txtsalenum.Clear()
        txtnet.Text = "0.00"
        txtpnum.Text = "0"
        txtsum.Text = "0"
        txtpprice_cost.Text = "0.00"
        txtpprice_sale.Text = "0.00"
        Label6.Text = ".........."
        Label14.Text = ".........."
        txtpid.Focus()
        Button5.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button1.Text = "_"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim pp As Double = txtpprice_cost.Text

        Dim sn As Integer = txtsalenum.Text
        Dim pn As Integer = txtpnum.Text
        Dim nn As Double = sn + pn

        bsum = pp * nn
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim vbyesno As Integer = MsgBox("ต้องการลบหรือไม่", 36, "ลบข้อมูล")
        If vbyesno = vbYes Then
            Dim strdelete As String = "delete from T_sale_whole_deteil where ID_no = '" & Label19.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strdelete, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("ลบข้อมูลเรียบ", "ลบข้อมูล")
            Dim strshow As String = "select * from T_sale_whole_deteil"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable

            Dim all As Integer = txtpnum.Text
            Dim num As Integer = p_num1
            Dim net As Integer = all + num
            Dim strupdate As String = "Update T_pro_whole set p_num = '" & net & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strupdate, conn)
            cmd1.ExecuteNonQuery()

            adp.Fill(dt)
            DataGridView1.DataSource = dt
            With DataGridView1
                If .RowCount > 0 Then
                    .Columns(0).Visible = False
                    .Columns(10).Visible = False
                End If
            End With
            runid()
            runno()
            txtpid.Clear()
            txtpname.Clear()
            txtsalenum.Clear()
            txtnet.Text = "0.00"
            txtpnum.Text = "0"
            txtsum.Text = "0"
            txtpprice_cost.Text = "0.00"
            txtpprice_sale.Text = "0.00"
            Label6.Text = ".........."
            Label14.Text = ".........."
            txtpid.Focus()
            Button5.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
            Button1.Text = "_"
        End If
        autocal()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim pp As Double = txtpprice_cost.Text
        Dim nn As Double = txtsum.Text

        bsum = pp * nn
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strupdate As String = "update T_sale_whole_deteil set p_num = '" & txtsalenum.Text & "',p_totalsale = '" & txtnet.Text & "',p_totalcost = '" & costnet.ToString("#,###,##0.00") & "' where ID_no = '" & Label19.Text & "'"
        Dim cmd As New OleDb.OleDbCommand(strupdate, conn)
        cmd.ExecuteNonQuery()

        Dim strupdate1 As String = "update T_pro_whole set p_num = '" & txtsum.Text & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
        Dim cmd1 As New OleDb.OleDbCommand(strupdate1, conn)
        cmd1.ExecuteNonQuery()

        Dim strshow As String = "select * from T_sale_whole_deteil where ID_sale = '" & txtidsale.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).Visible = False
                .Columns(10).Visible = False
            End If
        End With
        MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
        runid()
        runno()
        txtpid.Clear()
        txtpname.Clear()
        txtsalenum.Clear()
        txtnet.Text = "0.00"
        txtpnum.Text = "0"
        txtsum.Text = "0"
        txtpprice_cost.Text = "0.00"
        txtpprice_sale.Text = "0.00"
        Label6.Text = ".........."
        Label14.Text = ".........."
        txtpid.Focus()
        Button5.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button1.Text = "_"
        autocal()
    End Sub

    Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        ID_no1 = DataGridView1.Rows.Item(e.RowIndex).Cells("ID_no").Value.ToString()
        ID_sale1 = DataGridView1.Rows.Item(e.RowIndex).Cells("ID_sale").Value.ToString()
        ID_pro1 = DataGridView1.Rows.Item(e.RowIndex).Cells("ID_pro").Value.ToString()
        p_name1 = DataGridView1.Rows.Item(e.RowIndex).Cells("p_name").Value.ToString()
        p_num1 = DataGridView1.Rows.Item(e.RowIndex).Cells("p_num").Value.ToString()
        p_unit1 = DataGridView1.Rows.Item(e.RowIndex).Cells("p_unit").Value.ToString()
        p_totalcost1 = DataGridView1.Rows.Item(e.RowIndex).Cells("p_totalcost").Value.ToString()
        p_totalsale1 = DataGridView1.Rows.Item(e.RowIndex).Cells("p_totalsale").Value.ToString()

        txtidsale.Text = ID_sale1
        txtpid.Text = ID_pro1
        txtpname.Text = p_name1
        txtsalenum.Text = p_num1
        Label6.Text = p_unit1
        Label14.Text = p_unit1
        txtnet.Text = p_totalsale1
        Label19.Text = ID_no1

        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim strselect As String = "select * from T_pro_whole where ID_pro = '" & txtpid.Text & "'"
        Dim cmd As New OleDb.OleDbCommand(strselect, conn)
        Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
        dr.Read()
        p_name = dr("p_name")
        p_price_cost = dr("p_price_cost")
        p_price_sale = dr("p_price_sale")
        p_num = dr("p_num")
        p_unit = dr("p_unit")

        txtpname.Text = p_name
        txtpprice_cost.Text = p_price_cost.ToString("#,###,##0.00")
        txtpprice_sale.Text = p_price_sale.ToString("#,###,##0.00")
        txtpnum.Text = p_num

        Button5.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        txtsalenum.Focus()
        Button1.Text = "-"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim i As Integer = 0
        For i = 0 To DataGridView1.Rows.Count - 2
            Dim tid As String
            Dim tnum As Integer = 0
            Dim pnum As Integer = 0
            Dim pbal As Double = 0
            Dim pc As Double = 0
            tid = DataGridView1.Rows(i).Cells(3).Value
            tnum = DataGridView1.Rows(i).Cells(5).Value
            pc = DataGridView1.Rows(i).Cells(8).Value

            Dim strselect As String = "Select p_num,p_bal from T_pro_whole where ID_pro = '" & tid & "'"
            Dim cmd As New OleDb.OleDbCommand(strselect, conn)
            cmd.ExecuteNonQuery()
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            dr.Read()
            pnum = dr("p_num")
            pbal = dr("p_bal")
            Dim totalamount As Integer = pnum + tnum
            Dim ss As Double = pbal + pc

            Dim strinsert As String = "Update T_pro_whole set p_num = '" & totalamount & "',p_bal = '" & ss.ToString("#,###,##0.00") & "' where ID_pro = '" & tid & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strinsert, conn)
            cmd1.ExecuteNonQuery()
        Next

        Dim strdelete As String = "delete from T_sale_whole_deteil where ID_sale = '" & txtidsale.Text & "'"
        Dim cmd2 As New OleDb.OleDbCommand(strdelete, conn)
        cmd2.ExecuteNonQuery()

        Dim strselect1 As String = "select * from T_sale_whole_deteil where ID_sale = '" & txtidsale.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect1, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(0).Visible = False
                .Columns(10).Visible = False
            End If
        End With
        runid()
        runno()
        txtpid.Clear()
        txtpname.Clear()
        txtsalenum.Clear()
        txtnet.Text = "0.00"
        txtpnum.Text = "0"
        txtsum.Text = "0"
        txtpprice_cost.Text = "0.00"
        txtpprice_sale.Text = "0.00"
        Label6.Text = ".........."
        Label14.Text = ".........."
        txtpid.Focus()
        Button5.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button1.Text = "_"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        If DataGridView1.Rows.Count = vbNull Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        ElseIf txtcid.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        ElseIf txtsendname.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        ElseIf txtrevname.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        ElseIf txtbook.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        ElseIf txtno.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        ElseIf txtmoney.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        Else
            Dim strinsert As String = "insert into T_sale_whole(ID_sale,ID_cus,s_date,s_sale,s_cost) values('" & txtidsale.Text & "','" & txtcid.Text & "','" & DateTimePicker1.Text & "','" & txtallnet.Text & "','" & txtallcost.Text & "')"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintPreviewDialog2.StartPosition = FormStartPosition.CenterScreen
                PrintPreviewDialog2.WindowState = FormWindowState.Maximized
                PrintPreviewDialog2.ShowDialog()
                Dim frm As Fsale_whole
                frm = New Fsale_whole
                frm.TopLevel = False
                frm.Parent = Fmenu_whole.Panel2
                frm.Show()
                frm.BringToFront()
            End If
        End If
    End Sub

    Dim i As Integer = 0
    Dim itemperpage As Integer = 0
    Dim np As Integer = 0

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim Font As New Font("AngsanaUPC", 18), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 16)
        Dim Font2 As New Font("AngsanaUPC", 27)
        Dim fim As New Font("AngsanaUPC", 2)
        Dim barc As New Font("3 of 9 Barcode", 25)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        'e.Graphics.DrawImage(PictureBox4.Image, 1, 1, 850, 1080)
        'For im = 0 To 1256 Step 10
        'e.Graphics.DrawString(im, fim, Brush, im, 1)
        'e.Graphics.DrawString(im, fim, Brush, 1, im)
        'Next

        e.Graphics.DrawString("เล่มที่ :  " & txtbook.Text, Font, Brush, 30, 30)
        e.Graphics.DrawString("เลขที่ :  " & txtno.Text, Font, Brush, 30, 60)
        e.Graphics.DrawString("[ " & np + 1 & " ]", Font, Brush, 770, 20)
        e.Graphics.DrawString("ใบส่งของ", Font, Brush, 360, 15)
        e.Graphics.DrawString("โรเบิร์ต เครื่องเขียน", Font2, Brush, 300, 40)
        e.Graphics.DrawString("373/1 หมู่ 1 บ้านนาหว้า ตำบลนาหว้า อำเภอปทุมราชวงศา จังหวัดอำนาจเจริญ", Font, Brush, 150, 80)
        e.Graphics.DrawString("โทร/แฟกซ์ 045-0984188 มือถือ 083-0810389, 095-2690684", Font, Brush, 200, 110)
        e.Graphics.DrawString("จำหน่าย : เครื่องเขียน เครื่องใช้สำนักงาน และสินค้าเบ็ดเตล็ด", Font, Brush, 200, 140)
        e.Graphics.DrawString("เลขประจำตัวผู้เสียภาษีอากร 0 9910 11065 86 1", Font, Brush, 240, 170)

        e.Graphics.DrawString("เลขที่ใบเสร็จ :  " & txtidsale.Text, Font, Brush, 600, 190)
        e.Graphics.DrawString("วันที่ :  " & DateTimePicker1.Text, Font, Brush, 600, 220)
        e.Graphics.DrawString("นามผู้ซื้อ : .................................................................................................. เบอร์โทร : ...........................................", Font, Brush, 30, 250)
        e.Graphics.DrawString(txtcname.Text, Font, Brush, 110, 245)
        e.Graphics.DrawString(txttel.Text, Font, Brush, 650, 245)
        e.Graphics.DrawString("ที่อยู่เลขที่ : ...............................................................................................................................................................", Font, Brush, 30, 280)
        e.Graphics.DrawString(txtcadd.Text, Font, Brush, 120, 275)
        e.Graphics.DrawString("ได้รับของตามรายการนี้ถูกต้องแล้ว", Font, Brush, 60, 310)

        e.Graphics.DrawImage(PictureBox2.Image, 35, 360, 750, 35)
        e.Graphics.DrawString("ลำดับที่", Font1, Brush, 38, 365)
        e.Graphics.DrawString("รายการสินค้า", Font1, Brush, 220, 365)
        e.Graphics.DrawString("จำนวน", Font1, Brush, 435, 365)
        e.Graphics.DrawString("หน่วย", Font1, Brush, 530, 365)
        e.Graphics.DrawString("ราคา", Font1, Brush, 625, 365)
        e.Graphics.DrawString("จำนวนเงิน", Font1, Brush, 700, 365)

        Dim j As Integer = 393
        Dim k As Integer = 390
        itemperpage = i = 0
        While i <= DataGridView1.Rows.Count - 2
            Dim num As Double = DataGridView1.Rows(i).Cells(5).Value
            Dim price As Double = DataGridView1.Rows(i).Cells(9).Value
            Dim sum As Double = price / num
            e.Graphics.DrawString(i + 1, Font1, Brush, 42, j)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(4).Value, Font1, Brush, 110, j)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font1, Brush, 500, j, Format)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(6).Value, Font1, Brush, 515, j)
            e.Graphics.DrawString(sum.ToString("#,###,##0.00"), Font1, Brush, 685, j, Format)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(9).Value, Font1, Brush, 780, j, Format)
            e.Graphics.DrawImage(PictureBox3.Image, 35, k, 750, 35)
            k = k + 30
            j = j + 30

            i += 1
            If itemperpage <= 18 Then
                itemperpage += 1
                e.HasMorePages = False
            Else
                itemperpage = 0
                e.HasMorePages = True
                np += 1
                Return
            End If
        End While

        e.Graphics.DrawString("รวมเงิน  :  ", Font1, Brush, 625, j + 10)
        e.Graphics.DrawString(txtallnet.Text, Font1, Brush, 780, j + 10, Format)

        e.Graphics.DrawString("ตัวอักษร  :   " & txtmoney.Text, Font1, Brush, 30, j + 10)

        e.Graphics.DrawString("ลงชื่อ..............................................ผู้รับของ", Font1, Brush, 80, j + 60)
        e.Graphics.DrawString("ลงชื่อ..............................................ผู้รับของ", Font1, Brush, 480, j + 60)
        e.Graphics.DrawString("(" & txtrevname.Text & ")", Font1, Brush, 100, j + 90)
        e.Graphics.DrawString("(" & txtsendname.Text & ")", Font1, Brush, 500, j + 90)
        itemperpage = i = 0
    End Sub

    Private Sub txtsalenum_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtsalenum.TextChanged
        Try
            Dim pnum As Integer = txtpnum.Text
            Dim snum As Integer = txtsalenum.Text
            Dim pcost As Double
            Dim psale As Double
            If Button1.Text = "_" Then
                    pnum = txtpnum.Text
                    snum = txtsalenum.Text
                    Dim sum As Integer = pnum - snum
                    txtsum.Text = sum

                    pcost = txtpprice_cost.Text
                    psale = txtpprice_sale.Text

                    costnet = pcost * snum
                    Dim salenet As Double = psale * snum
                    txtnet.Text = salenet.ToString("#,###,##0.00")
            ElseIf Button1.Text = "-" Then
                pnum = txtpnum.Text
                snum = txtsalenum.Text
                Dim anum As Integer = p_num1 - snum
                Dim sum As Integer = pnum + anum
                txtsum.Text = sum
                pcost = txtpprice_cost.Text
                psale = txtpprice_sale.Text
                costnet = pcost * snum
                Dim salenet As Double = psale * snum
                txtnet.Text = salenet.ToString("#,###,##0.00")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button6_Click_2(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            itemperpage = i = 0
            PrintPreviewDialog2.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog2.WindowState = FormWindowState.Maximized
            PrintPreviewDialog2.ShowDialog()
        End If
    End Sub
End Class