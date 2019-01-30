Public Class Fmenu_retail

    Private Sub color()
        m1.BackColor = Drawing.Color.Gainsboro
        m2.BackColor = Drawing.Color.Gainsboro
        m3.BackColor = Drawing.Color.Gainsboro
        m4.BackColor = Drawing.Color.Gainsboro
        m5.BackColor = Drawing.Color.Gainsboro
        m6.BackColor = Drawing.Color.Gainsboro
        m7.BackColor = Drawing.Color.Gainsboro
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Hide()
    End Sub

    Private Sub m1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m1.Click
        Dim frm As Fsale_retail
        frm = New Fsale_retail
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m1.BackColor = Drawing.Color.Green
    End Sub

    Private Sub m2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m2.Click
        Dim frm As Fpro_retail
        frm = New Fpro_retail
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m2.BackColor = Drawing.Color.Green
    End Sub

    Private Sub m4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m4.Click
        Dim frm As Faddpro_retail
        frm = New Faddpro_retail
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m4.BackColor = Drawing.Color.Green
    End Sub

    Private Sub m5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m5.Click
        Dim frm As Fedit_retail
        frm = New Fedit_retail
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m5.BackColor = Drawing.Color.Green
    End Sub

    Private Sub m6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m6.Click
        Dim frm As Fbar_retail
        frm = New Fbar_retail
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m6.BackColor = Drawing.Color.Green
    End Sub

    Private Sub m7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m7.Click
        Dim frm As Fbalance_retail
        frm = New Fbalance_retail
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m7.BackColor = Drawing.Color.Green
    End Sub

    Private Sub m3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m3.Click
        Dim frm As Fcircu_retail
        frm = New Fcircu_retail
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m3.BackColor = Drawing.Color.Green
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
