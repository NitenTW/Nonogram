Public Class frmOpenGame

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objField As New clsField

        If RadioButton1.Checked Then
            frmMain.g_FieldSize = 10
            frmMain.SaveButton.Top = 195
            frmMain.SaveButton.Left = 81
            frmMain.Size = New Size(190, 270)
        End If

        If RadioButton2.Checked Then
            frmMain.g_FieldSize = 15
            frmMain.SaveButton.Top = 268
            frmMain.SaveButton.Left = 156
            frmMain.Size = New Size(265, 345)
        End If

        If RadioButton3.Checked Then
            frmMain.g_FieldSize = 20
            frmMain.SaveButton.Top = 343
            frmMain.SaveButton.Left = 232
            frmMain.Size = New Size(340, 420)
        End If

        ReDim frmMain.g_Field(frmMain.g_FieldSize, frmMain.g_FieldSize)
        objField.InitializeField(frmMain.g_Field) 'ªì©l g_Field ªº­È
        frmMain.g_GameState = frmMain.GameMODE.MarkMODE
        frmMain.Label1.Visible = False
        frmMain.SaveButton.Visible = True
        frmMain.Enabled = True

        Me.Close()
    End Sub

    Private Sub frmOpenGame_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not frmMain.Enabled Then frmMain.Enabled = True
    End Sub

End Class