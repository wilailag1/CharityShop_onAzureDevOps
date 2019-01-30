<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fmenu_whole
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.m1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Location = New System.Drawing.Point(306, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(817, 134)
        Me.Panel1.TabIndex = 6
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m1, Me.m3, Me.m4, Me.m5, Me.m2, Me.m6, Me.m7})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(817, 129)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(12, 142)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1240, 528)
        Me.Panel2.TabIndex = 7
        '
        'm1
        '
        Me.m1.AutoSize = False
        Me.m1.Image = Global.Sale.My.Resources.Resources.s21
        Me.m1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.m1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m1.Name = "m1"
        Me.m1.Size = New System.Drawing.Size(112, 125)
        Me.m1.Text = "ขายสินค้า"
        Me.m1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.m1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'm3
        '
        Me.m3.AutoSize = False
        Me.m3.Image = Global.Sale.My.Resources.Resources.report
        Me.m3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m3.Name = "m3"
        Me.m3.Size = New System.Drawing.Size(112, 125)
        Me.m3.Text = "ยอดขาย"
        Me.m3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'm4
        '
        Me.m4.AutoSize = False
        Me.m4.Image = Global.Sale.My.Resources.Resources.addkist
        Me.m4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m4.Name = "m4"
        Me.m4.Size = New System.Drawing.Size(112, 125)
        Me.m4.Text = "เพิ่มรายการสินค้า"
        Me.m4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'm5
        '
        Me.m5.AutoSize = False
        Me.m5.Image = Global.Sale.My.Resources.Resources.addnum
        Me.m5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m5.Name = "m5"
        Me.m5.Size = New System.Drawing.Size(112, 125)
        Me.m5.Text = "เพิ่มสินค้า"
        Me.m5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'm2
        '
        Me.m2.AutoSize = False
        Me.m2.Image = Global.Sale.My.Resources.Resources.product
        Me.m2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m2.Name = "m2"
        Me.m2.Size = New System.Drawing.Size(112, 125)
        Me.m2.Text = "ข้อมูลสินค้า"
        Me.m2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'm6
        '
        Me.m6.AutoSize = False
        Me.m6.Image = Global.Sale.My.Resources.Resources.bar
        Me.m6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m6.Name = "m6"
        Me.m6.Size = New System.Drawing.Size(112, 125)
        Me.m6.Text = "สร้างบาร์โค้ด"
        Me.m6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'm7
        '
        Me.m7.AutoSize = False
        Me.m7.Image = Global.Sale.My.Resources.Resources.stock
        Me.m7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m7.Name = "m7"
        Me.m7.Size = New System.Drawing.Size(112, 125)
        Me.m7.Text = "สินค้าคงเหลือ"
        Me.m7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.Sale.My.Resources.Resources.close
        Me.Button1.Location = New System.Drawing.Point(1132, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 120)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "ปิดฟอร์ม"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Sale.My.Resources.Resources.lab3
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(277, 124)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Fmenu_whole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximumSize = New System.Drawing.Size(1280, 720)
        Me.MinimumSize = New System.Drawing.Size(1280, 720)
        Me.Name = "Fmenu_whole"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ระบบขายส่ง"
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents m1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
