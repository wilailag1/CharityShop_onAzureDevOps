Public Class Fmenu_whole

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
        Dim frm As Fsale_whole
        frm = New Fsale_whole
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m1.BackColor = Drawing.Color.YellowGreen
    End Sub

    Private Sub m2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m2.Click
        Dim frm As Fpro_whole
        frm = New Fpro_whole
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m2.BackColor = Drawing.Color.YellowGreen
    End Sub

    Private Sub m4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m4.Click
        Dim frm As Faddpro_whole
        frm = New Faddpro_whole
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m4.BackColor = Drawing.Color.YellowGreen
    End Sub

    Private Sub m5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m5.Click
        Dim frm As Fedit_whole
        frm = New Fedit_whole
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m5.BackColor = Drawing.Color.YellowGreen
    End Sub

    Private Sub m6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m6.Click
        Dim frm As Fbar_whole
        frm = New Fbar_whole
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m6.BackColor = Drawing.Color.YellowGreen
    End Sub

    Private Sub m7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m7.Click
        Dim frm As Fbalance_whole
        frm = New Fbalance_whole
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m7.BackColor = Drawing.Color.YellowGreen
    End Sub

    Private Sub m3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m3.Click
        Dim frm As Fcircu_whole
        frm = New Fcircu_whole
        frm.TopLevel = False
        frm.Parent = Me.Panel2
        frm.Show()
        frm.BringToFront()
        color()
        m3.BackColor = Drawing.Color.YellowGreen
    End Sub
End Class