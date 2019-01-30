Public Class Fsale_retail
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
        Dim discount As Double = txtdis.Text
        Dim total As Double = tprice - total
        txtallnet.Text = total.ToString("#,###,##0.00")
        txtallcost.Text = tcost.ToString("#,###,##0.00")
        txttotal.Text = total.ToString("#,###,##0.00")
    End Sub

    Private Sub runid()
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()
        Dim strrun As String = "SELECT TOP 1 ID_sale FROM T_sale_retail ORDER BY ID_sale DESC"
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
            txtidsale.Text = "1100000001"
        End Try
    End Sub

    Private Sub Fsale_retail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        runid()
        runno()
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim btn As New DataGridViewButtonColumn()
        DataGridView1.Columns.Add(btn)
        btn.Text = "ลบ"
        btn.Name = "ลบ"
        btn.UseColumnTextForButtonValue = True
        btn.Width = 35


        Dim strselect As String = "select * from T_sale_retail_deteil where ID_sale = '" & txtidsale.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        With DataGridView1
            If .RowCount > 0 Then
                .Columns(1).Visible = False
                .Columns(2).HeaderText = "รหัสการขาย"
                .Columns(3).HeaderText = "วันที่ขาย"
                .Columns(4).HeaderText = "รหัสสินค้า"
                .Columns(5).HeaderText = "ชื่อสินค้า"
                .Columns(6).HeaderText = "จำนวน"
                .Columns(7).HeaderText = "หน่วย"
                .Columns(8).Visible = False
                .Columns(9).HeaderText = "ราคาขายรวม"

                .Columns(2).Width = 160
                .Columns(3).Width = 160
                .Columns(4).Width = 160
                .Columns(5).Width = 150
                .Columns(6).Width = 150
                .Columns(7).Width = 150
                .Columns(9).Width = 150
            End If
        End With
        autocal()
    End Sub

    Private Sub runno()
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()
        Dim strrun As String = "SELECT TOP 1 ID_no FROM T_sale_retail_deteil ORDER BY ID_no DESC"
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

    Private Sub txtpid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strselect As String = "select * from T_pro_retail where ID_pro = '" & txtpid.Text & "'"
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
                Else
                    Dim strinsert As String = "insert into T_sale_retail_deteil(ID_no,ID_sale,s_date,ID_pro,p_name,p_num,p_unit,p_totalcost,p_totalsale) values('" & Label19.Text & "','" & txtidsale.Text & "','" & DateTimePicker1.Text & "','" & txtpid.Text & "','" & txtpname.Text & "','" & txtsalenum.Text & "','" & Label6.Text & "','" & costnet.ToString("#,###,##0.00") & "','" & txtnet.Text & "')"
                    Dim cmd2 As New OleDb.OleDbCommand(strinsert, conn)
                    cmd2.ExecuteNonQuery()

                    Dim strupdate As String = "update T_pro_retail set p_num = '" & txtsum.Text & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
                    Dim cmd1 As New OleDb.OleDbCommand(strupdate, conn)
                    cmd1.ExecuteNonQuery()
                    runid()
                    Dim strshow As String = "select * from T_sale_retail_deteil where ID_sale = '" & txtidsale.Text & "'"
                    Dim adp1 As New OleDb.OleDbDataAdapter(strshow, conn)
                    Dim dt1 As New DataTable
                    adp1.Fill(dt1)
                    DataGridView1.DataSource = dt1
                    'MessageBox.Show("เพิ่มข้อมูลเรียบร้อย", "แจ้งเตือน")

                    runno()
                    txtpid.Clear()
                    txtpname.Clear()
                    txtsalenum.Value = 1
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
            End If
        End If
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
                    txtsalenum.Value = 1
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
                    txtsalenum.Value = 1
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        runid()
        runno()
        txtpid.Clear()
        txtpname.Clear()
        txtsalenum.Value = 1
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

    Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If DataGridView1.Columns(e.ColumnIndex).Name = "ลบ" Then
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

            Dim strselect As String = "select * from T_pro_retail where ID_pro = '" & txtpid.Text & "'"
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

            Dim pp As Double = txtpprice_cost.Text

            Dim sn As Integer = txtsalenum.Text
            Dim pn As Integer = txtpnum.Text
            Dim nn As Double = sn + pn

            bsum = pp * nn
            If txtpid.Text = "" Then
                MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
                txtpid.Focus()
            Else
                Dim vbyesno As Integer = MsgBox("ต้องการลบหรือไม่", 36, "ลบข้อมูล")
                If vbyesno = vbYes Then
                    Dim strdelete As String = "delete from T_sale_retail_deteil where ID_no = '" & Label19.Text & "'"
                    Dim cmd2 As New OleDb.OleDbCommand(strdelete, conn)
                    cmd2.ExecuteNonQuery()
                    MessageBox.Show("ลบข้อมูลเรียบ", "ลบข้อมูล")
                    Dim strshow As String = "select * from T_sale_retail_deteil where ID_sale = '" & txtidsale.Text & "'"
                    Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
                    Dim dt As New DataTable

                    Dim all As Integer = txtpnum.Text
                    Dim num As Integer = p_num1
                    Dim net As Integer = all + num
                    Dim strupdate As String = "Update T_pro_retail set p_num = '" & net & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
                    Dim cmd1 As New OleDb.OleDbCommand(strupdate, conn)
                    cmd1.ExecuteNonQuery()

                    adp.Fill(dt)
                    DataGridView1.DataSource = dt

                    runid()
                    runno()
                    txtpid.Clear()
                    txtpname.Clear()
                    txtsalenum.Value = 1
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
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
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
        Else
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strupdate As String = "update T_sale_retail_deteil set p_num = '" & txtsalenum.Text & "',p_totalsale = '" & txtnet.Text & "',p_totalcost = '" & costnet.ToString("#,###,##0.00") & "' where ID_no = '" & Label19.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(strupdate, conn)
            cmd.ExecuteNonQuery()

            Dim strupdate1 As String = "update T_pro_retail set p_num = '" & txtsum.Text & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strupdate1, conn)
            cmd1.ExecuteNonQuery()

            Dim strshow As String = "select * from T_sale_retail_deteil where ID_sale = '" & txtidsale.Text & "'"
            Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            DataGridView1.DataSource = dt
            With DataGridView1
                If .RowCount > 0 Then
                    .Columns(0).Visible = False
                End If
            End With
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")
            runid()
            runno()
            txtpid.Clear()
            txtpname.Clear()
            txtsalenum.Value = 1
            txtnet.Text = "0.00"
            txtpnum.Text = "0"
            txtsum.Text = "0"
            txtpprice_cost.Text = "0.00"
            txtpprice_sale.Text = "0.00"
            Label6.Text = ".........."
            Label14.Text = ".........."
            txtpid.Focus()
            Button1.Text = "_"
            autocal()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
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
        Else
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strinsert As String = "insert into T_sale_retail_deteil(ID_no,ID_sale,s_date,ID_pro,p_name,p_num,p_unit,p_totalcost,p_totalsale) values('" & Label19.Text & "','" & txtidsale.Text & "','" & DateTimePicker1.Text & "','" & txtpid.Text & "','" & txtpname.Text & "','" & txtsalenum.Text & "','" & Label6.Text & "','" & costnet.ToString("#,###,##0.00") & "','" & txtnet.Text & "')"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()

            Dim strupdate As String = "update T_pro_retail set p_num = '" & txtsum.Text & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strupdate, conn)
            cmd1.ExecuteNonQuery()
            runid()
            Dim strshow As String = "select * from T_sale_retail_deteil where ID_sale = '" & txtidsale.Text & "'"
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
            txtsalenum.Value = 1
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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
        conn.Open()

        Dim i As Integer = 0
        For i = 0 To DataGridView1.Rows.Count - 2
            Dim tid As String
            Dim tnum As Integer = 0
            Dim pnum As Integer = 0
            Dim pbal As Double = 0
            Dim pc As Double = 0
            tid = DataGridView1.Rows(i).Cells(4).Value
            tnum = DataGridView1.Rows(i).Cells(6).Value
            pc = DataGridView1.Rows(i).Cells(8).Value

            Dim strselect As String = "Select p_num,p_bal from T_pro_retail where ID_pro = '" & tid & "'"
            Dim cmd As New OleDb.OleDbCommand(strselect, conn)
            cmd.ExecuteNonQuery()
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            dr.Read()
            pnum = dr("p_num")
            pbal = dr("p_bal")
            Dim totalamount As Integer = pnum + tnum
            Dim ss As Double = pbal + pc

            Dim strinsert As String = "Update T_pro_retail set p_num = '" & totalamount & "',p_bal = '" & ss.ToString("#,###,##0.00") & "' where ID_pro = '" & tid & "'"
            Dim cmd1 As New OleDb.OleDbCommand(strinsert, conn)
            cmd1.ExecuteNonQuery()
        Next

        Dim strdelete As String = "delete from T_sale_retail_deteil where ID_sale = '" & txtidsale.Text & "'"
        Dim cmd2 As New OleDb.OleDbCommand(strdelete, conn)
        cmd2.ExecuteNonQuery()

        Dim strselect1 As String = "select ID_sale,s_date,ID_pro,p_name,p_num,p_unit,p_totalcost,p_totalsale from T_sale_retail_deteil where ID_sale = '" & txtidsale.Text & "'"
        Dim adp As New OleDb.OleDbDataAdapter(strselect1, conn)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt
        runid()
        runno()
        txtpid.Clear()
        txtpname.Clear()
        txtsalenum.Value = 1
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

        txttotal.Text = "0.00"
        txtdis.Text = "0.00"
        txtallnet.Text = "0.00"
        txtmoney.Text = "0.00"
        txtchange.Text = "0.00"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim pp As Double = txtpprice_cost.Text

        Dim sn As Integer = txtsalenum.Text
        Dim pn As Integer = txtpnum.Text
        Dim nn As Double = sn + pn

        bsum = pp * nn
        If txtpid.Text = "" Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
            txtpid.Focus()
        Else
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim vbyesno As Integer = MsgBox("ต้องการลบหรือไม่", 36, "ลบข้อมูล")
            If vbyesno = vbYes Then
                Dim strdelete As String = "delete from T_sale_retail_deteil where ID_no = '" & Label19.Text & "'"
                Dim cmd As New OleDb.OleDbCommand(strdelete, conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("ลบข้อมูลเรียบ", "ลบข้อมูล")
                Dim strshow As String = "select * from T_sale_retail_deteil"
                Dim adp As New OleDb.OleDbDataAdapter(strshow, conn)
                Dim dt As New DataTable

                Dim all As Integer = txtpnum.Text
                Dim num As Integer = p_num1
                Dim net As Integer = all + num
                Dim strupdate As String = "Update T_pro_retail set p_num = '" & net & "',p_bal = '" & bsum.ToString("#,###,##0.00") & "' where ID_pro = '" & txtpid.Text & "'"
                Dim cmd1 As New OleDb.OleDbCommand(strupdate, conn)
                cmd1.ExecuteNonQuery()

                adp.Fill(dt)
                DataGridView1.DataSource = dt
                With DataGridView1
                    If .RowCount > 0 Then
                        .Columns(0).Visible = False
                    End If
                End With
                runid()
                runno()
                txtpid.Clear()
                txtpname.Clear()
                txtsalenum.Value = 1
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
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If DataGridView1.Rows.Count = vbNull Then
            MessageBox.Show("ข้อมูลไม่ครบ", "แจ้งเตือน")
        Else
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbsub.accdb")
            conn.Open()

            Dim strinsert As String = "insert into T_sale_retail(ID_sale,s_date,s_sale,s_dis,s_cost) values('" & txtidsale.Text & "','" & DateTimePicker1.Text & "','" & txtallnet.Text & "','" & txtdis.Text & "','" & txtallcost.Text & "')"
            Dim cmd As New OleDb.OleDbCommand(strinsert, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน")

            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim psz As New Printing.PaperSize
                With (psz)
                    .RawKind = Printing.PaperKind.Custom
                    .Width = 208
                    .Height = 3276
                    PrintDocument1.DefaultPageSettings.PaperSize = psz
                End With
                PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
                PrintPreviewDialog1.WindowState = FormWindowState.Maximized
                PrintPreviewDialog1.ShowDialog()
                PrintDocument1.Print()
            End If

                runid()
                Dim strselect As String = "select * from T_sale_retail where ID_sale = '" & txtidsale.Text & "'"
                Dim adp As New OleDb.OleDbDataAdapter(strselect, conn)
                Dim dt As New DataTable
                adp.Fill(dt)
                DataGridView1.DataSource = dt
                Dim frm As Fsale_retail
                frm = New Fsale_retail
                frm.TopLevel = False
                frm.Parent = Fmenu_retail.Panel2
                frm.Show()
                frm.BringToFront()
            End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim Font As New Font("AngsanaUPC", 20), Brush As New SolidBrush(Color.Black)
        Dim Font1 As New Font("AngsanaUPC", 14)
        Dim Font2 As New Font("AngsanaUPC", 10)
        Dim Format As New StringFormat(StringFormatFlags.DirectionRightToLeft)

        e.Graphics.DrawString("ร้าน   PJ Shop", Font1, Brush, 50, 20)
        e.Graphics.DrawString("_____________________________", Font1, Brush, 0, 90)
        e.Graphics.DrawString("เลขที่ใบเสร็จ :  " & txtidsale.Text, Font1, Brush, 25, 110)
        e.Graphics.DrawString("วันที่ :  " & DateTimePicker1.Value, Font1, Brush, 25, 130)
        e.Graphics.DrawString("_____________________________", Font1, Brush, 0, 140)
        Dim i As Integer = 0
        Dim j As Integer = 160
        For i = 0 To DataGridView1.Rows.Count - 2
            Dim tt As Double = DataGridView1.Rows(i).Cells(9).Value / DataGridView1.Rows(i).Cells(6).Value
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(5).Value, Font1, Brush, 0, j)
            e.Graphics.DrawString("ราคา :  " & tt.ToString("#,###,##0.00"), Font1, Brush, 0, j + 20)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(6).Value & "@", Font1, Brush, 115, j + 20, Format)
            e.Graphics.DrawString(DataGridView1.Rows(i).Cells(9).Value & "@", Font1, Brush, 195, j + 20, Format)

            j = j + 50
        Next
        e.Graphics.DrawString("_____________________________", Font1, Brush, 0, j)
        Dim total As Double = txtallnet.Text
        Dim dis As Double = txtdis.Text
        Dim net As Double = dis + total

        e.Graphics.DrawString("ยอดรวม", Font1, Brush, 20, j + 20)
        e.Graphics.DrawString("ส่วนลด", Font1, Brush, 20, j + 40)
        e.Graphics.DrawString("ยอดสุทธิ", Font1, Brush, 20, j + 60)
        e.Graphics.DrawString("เงินสด", Font1, Brush, 20, j + 80)
        e.Graphics.DrawString("ยอดสุทธิ", Font1, Brush, 20, j + 100)

        e.Graphics.DrawString(":", Font1, Brush, 80, j + 20)
        e.Graphics.DrawString(":", Font1, Brush, 80, j + 40)
        e.Graphics.DrawString(":", Font1, Brush, 80, j + 60)
        e.Graphics.DrawString(":", Font1, Brush, 80, j + 80)
        e.Graphics.DrawString(":", Font1, Brush, 80, j + 100)

        e.Graphics.DrawString(net.ToString("#,###,##0.00"), Font1, Brush, 170, j + 20, Format)
        e.Graphics.DrawString(dis.ToString("#,###,##0.00"), Font1, Brush, 170, j + 40, Format)
        e.Graphics.DrawString(txtallnet.Text, Font1, Brush, 170, j + 60, Format)
        e.Graphics.DrawString(txtmoney.Text, Font1, Brush, 170, j + 80, Format)
        e.Graphics.DrawString(txtchange.Text, Font1, Brush, 170, j + 100, Format)
        e.Graphics.DrawString("_____________________________", Font1, Brush, 0, j + 120)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim psz As New Printing.PaperSize
            With (psz)
                .RawKind = Printing.PaperKind.Custom
                .Width = 208
                .Height = 3276
                PrintDocument1.DefaultPageSettings.PaperSize = psz
            End With
            PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    Private Sub txtdis_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdis.TextChanged
        Try
            Dim tprice As Double = 0
            Dim i As Integer = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                tprice += CDbl(DataGridView1.Rows(i).Cells(9).Value)
            Next

            Dim discount As Double = txtdis.Text
            Dim total As Double = tprice - discount
            txtallnet.Text = total.ToString("#,###,##0.00")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtmoney_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmoney.TextChanged
        Try
            Dim tprice As Double = 0
            Dim i As Integer = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                tprice += CDbl(DataGridView1.Rows(i).Cells(9).Value)
            Next

            Dim discount As Double = txtdis.Text
            Dim total As Double = tprice - discount
            txtallnet.Text = total.ToString("#,###,##0.00")

            Dim money As Double = txtmoney.Text
            Dim change As Double = money - total
            txtchange.Text = change.ToString("#,###,##0.00")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtsalenum_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtsalenum.ValueChanged
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
            txtpid.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtpid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpid.TextChanged

    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As System.Object, e As System.EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub txtidsale_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtidsale.TextChanged

    End Sub
End Class