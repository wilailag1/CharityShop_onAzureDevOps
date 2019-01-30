<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fpro_whole
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fpro_whole))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtpsearch = New System.Windows.Forms.TextBox()
        Me.txtpunit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpname = New System.Windows.Forms.TextBox()
        Me.txtpid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtpprice_sale = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtpprice_cost = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog3 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument3 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog4 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument4 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog5 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument5 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog6 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument6 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog7 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument7 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog8 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument8 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog9 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument9 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog10 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument10 = New System.Drawing.Printing.PrintDocument()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Sale.My.Resources.Resources._121
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(282, 79)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button4.Image = Global.Sale.My.Resources.Resources.can2
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(156, 440)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(66, 78)
        Me.Button4.TabIndex = 31
        Me.Button4.Text = "ยกเลิก"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button3.Image = Global.Sale.My.Resources.Resources.edit
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(84, 440)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(66, 78)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "แก้ไข"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button2.Image = Global.Sale.My.Resources.Resources.del
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(12, 440)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 78)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "ลบ"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(359, 123)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(870, 395)
        Me.DataGridView1.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 20)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "ค้นหาสินค้า"
        '
        'txtpsearch
        '
        Me.txtpsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtpsearch.Location = New System.Drawing.Point(106, 123)
        Me.txtpsearch.Name = "txtpsearch"
        Me.txtpsearch.Size = New System.Drawing.Size(228, 26)
        Me.txtpsearch.TabIndex = 1
        Me.txtpsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtpunit
        '
        Me.txtpunit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtpunit.Location = New System.Drawing.Point(106, 301)
        Me.txtpunit.Name = "txtpunit"
        Me.txtpunit.Size = New System.Drawing.Size(85, 26)
        Me.txtpunit.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 304)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 20)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "หน่วย"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "ชื่อสินค้า"
        '
        'txtpname
        '
        Me.txtpname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtpname.Location = New System.Drawing.Point(106, 205)
        Me.txtpname.Name = "txtpname"
        Me.txtpname.Size = New System.Drawing.Size(228, 26)
        Me.txtpname.TabIndex = 34
        '
        'txtpid
        '
        Me.txtpid.Enabled = False
        Me.txtpid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtpid.Location = New System.Drawing.Point(106, 173)
        Me.txtpid.Name = "txtpid"
        Me.txtpid.Size = New System.Drawing.Size(228, 26)
        Me.txtpid.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "รหัสสินค้า"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(297, 272)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 20)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "บาท"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(297, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "บาท"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(36, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 20)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "ราคาขาย"
        '
        'txtpprice_sale
        '
        Me.txtpprice_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtpprice_sale.Location = New System.Drawing.Point(106, 269)
        Me.txtpprice_sale.Name = "txtpprice_sale"
        Me.txtpprice_sale.Size = New System.Drawing.Size(185, 26)
        Me.txtpprice_sale.TabIndex = 50
        Me.txtpprice_sale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(41, 240)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 20)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "ราคาทุน"
        '
        'txtpprice_cost
        '
        Me.txtpprice_cost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtpprice_cost.Location = New System.Drawing.Point(106, 237)
        Me.txtpprice_cost.Name = "txtpprice_cost"
        Me.txtpprice_cost.Size = New System.Drawing.Size(185, 26)
        Me.txtpprice_cost.TabIndex = 49
        Me.txtpprice_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button6.Image = Global.Sale.My.Resources.Resources.print
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.Location = New System.Drawing.Point(228, 440)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(66, 78)
        Me.Button6.TabIndex = 74
        Me.Button6.Text = "พิมพ์"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Sale.My.Resources.Resources.d2
        Me.PictureBox3.Location = New System.Drawing.Point(479, 458)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox3.TabIndex = 76
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Sale.My.Resources.Resources.c2
        Me.PictureBox2.Location = New System.Drawing.Point(369, 458)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox2.TabIndex = 75
        Me.PictureBox2.TabStop = False
        '
        'PrintPreviewDialog2
        '
        Me.PrintPreviewDialog2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog2.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog2.Document = Me.PrintDocument2
        Me.PrintPreviewDialog2.Enabled = True
        Me.PrintPreviewDialog2.Icon = CType(resources.GetObject("PrintPreviewDialog2.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog2.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog2.Visible = False
        '
        'PrintPreviewDialog3
        '
        Me.PrintPreviewDialog3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog3.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog3.Document = Me.PrintDocument3
        Me.PrintPreviewDialog3.Enabled = True
        Me.PrintPreviewDialog3.Icon = CType(resources.GetObject("PrintPreviewDialog3.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog3.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog3.Visible = False
        '
        'PrintPreviewDialog4
        '
        Me.PrintPreviewDialog4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog4.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog4.Document = Me.PrintDocument4
        Me.PrintPreviewDialog4.Enabled = True
        Me.PrintPreviewDialog4.Icon = CType(resources.GetObject("PrintPreviewDialog4.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog4.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog4.Visible = False
        '
        'PrintPreviewDialog5
        '
        Me.PrintPreviewDialog5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog5.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog5.Document = Me.PrintDocument5
        Me.PrintPreviewDialog5.Enabled = True
        Me.PrintPreviewDialog5.Icon = CType(resources.GetObject("PrintPreviewDialog5.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog5.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog5.Visible = False
        '
        'PrintPreviewDialog6
        '
        Me.PrintPreviewDialog6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog6.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog6.Document = Me.PrintDocument6
        Me.PrintPreviewDialog6.Enabled = True
        Me.PrintPreviewDialog6.Icon = CType(resources.GetObject("PrintPreviewDialog6.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog6.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog6.Visible = False
        '
        'PrintPreviewDialog7
        '
        Me.PrintPreviewDialog7.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog7.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog7.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog7.Document = Me.PrintDocument7
        Me.PrintPreviewDialog7.Enabled = True
        Me.PrintPreviewDialog7.Icon = CType(resources.GetObject("PrintPreviewDialog7.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog7.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog7.Visible = False
        '
        'PrintPreviewDialog8
        '
        Me.PrintPreviewDialog8.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog8.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog8.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog8.Document = Me.PrintDocument8
        Me.PrintPreviewDialog8.Enabled = True
        Me.PrintPreviewDialog8.Icon = CType(resources.GetObject("PrintPreviewDialog8.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog8.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog8.Visible = False
        '
        'PrintPreviewDialog9
        '
        Me.PrintPreviewDialog9.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog9.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog9.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog9.Document = Me.PrintDocument9
        Me.PrintPreviewDialog9.Enabled = True
        Me.PrintPreviewDialog9.Icon = CType(resources.GetObject("PrintPreviewDialog9.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog9.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog9.Visible = False
        '
        'PrintPreviewDialog10
        '
        Me.PrintPreviewDialog10.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog10.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog10.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog10.Document = Me.PrintDocument10
        Me.PrintPreviewDialog10.Enabled = True
        Me.PrintPreviewDialog10.Icon = CType(resources.GetObject("PrintPreviewDialog10.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog10.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog10.Visible = False
        '
        'Fpro_whole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtpprice_sale)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtpprice_cost)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtpsearch)
        Me.Controls.Add(Me.txtpunit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtpname)
        Me.Controls.Add(Me.txtpid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Name = "Fpro_whole"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpsearch As System.Windows.Forms.TextBox
    Friend WithEvents txtpunit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpname As System.Windows.Forms.TextBox
    Friend WithEvents txtpid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtpprice_sale As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtpprice_cost As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PrintPreviewDialog2 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog3 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument3 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog4 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument4 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog5 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument5 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog6 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument6 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog7 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument7 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog8 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument8 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog9 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument9 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog10 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument10 As System.Drawing.Printing.PrintDocument
End Class
