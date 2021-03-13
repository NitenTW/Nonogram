Public Class frmAbout

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmMain.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmAbout_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not frmMain.Enabled Then frmMain.Enabled = True
    End Sub

End Class