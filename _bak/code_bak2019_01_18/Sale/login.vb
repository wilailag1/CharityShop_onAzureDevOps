Public Class login

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, Label2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "123456" Then
            MessageBox.Show("ยินดีต้อนรับ")
            Fmenu_retail.Show()
        ElseIf TextBox1.Text = "" And TextBox2.Text = "" Then
            MessageBox.Show("กรุณากรอก usnername และ password ให้ครบ")
        Else
            MessageBox.Show("กรุณาลองใหม่อีกครั้ง")

        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class