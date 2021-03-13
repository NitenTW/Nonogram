Public Class frmMain

    Private m_PosX As Integer, m_PosY As Integer   '滑鼠位於點繪的位置
    Public g_checkField(,) As Integer  '記錄點繪答案
    Public g_answerField(,) As Integer  '記錄點繪答案(反轉)
    Public g_Field(,) As Integer   '記錄滑鼠點擊
    Public g_FieldSize As Integer  '點繪範圍尺寸
    Public g_GameState As GameMODE  '遊戲模式
    Public Enum GameMODE
        WaitMODE = 0
        PlayMODE = 1
        MarkMODE = 2
    End Enum

    Private Sub MakeGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeGameToolStripMenuItem.Click
        frmOpenGame.Show()
        Me.Enabled = False
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.Show()
        Me.Enabled = False
    End Sub

    Private Sub frmMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Dim objGraphics As New clsField

        '判斷不點擊出Field範圍
        If e.X > 15 And e.X < (g_FieldSize + 1) * 15 And e.Y > 35 And e.Y < (g_FieldSize + 1) * 15 + 20 Then
            Select Case g_GameState
                Case GameMODE.MarkMODE
                    If e.Button = Windows.Forms.MouseButtons.Left Then
                        If g_GameState <> GameMODE.WaitMODE Then g_Field(m_PosX, m_PosY) = 1
                        objGraphics.Black()
                    End If

                    If e.Button = Windows.Forms.MouseButtons.Right Then
                        If g_GameState <> GameMODE.WaitMODE Then g_Field(m_PosX, m_PosY) = 0
                        objGraphics.Clear()
                    End If

                Case GameMODE.PlayMODE
                    If e.Button = Windows.Forms.MouseButtons.Left Then
                        If g_GameState <> GameMODE.WaitMODE Then g_Field(m_PosX, m_PosY) = 1
                        objGraphics.Black()
                    End If

                    If e.Button = Windows.Forms.MouseButtons.Right Then
                        If g_GameState <> GameMODE.WaitMODE Then g_Field(m_PosX, m_PosY) = 0
                        objGraphics.Clear()
                    End If

                    If e.Button = Windows.Forms.MouseButtons.Middle Then
                        If g_GameState <> GameMODE.WaitMODE Then g_Field(m_PosX, m_PosY) = 2
                        objGraphics.Cross()
                    End If

                    '驗證是否過關
                    If objGraphics.Complete = True Then
                        g_GameState = GameMODE.WaitMODE
                        MsgBox("Complete")
                    End If
            End Select

        End If
    End Sub

    Private Sub frmMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        m_PosX = e.X \ 15
        m_PosY = (e.Y - 20) \ 15
    End Sub

    Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim objField As New clsField
        Dim objCountField As New clsCountField

        If g_GameState <> GameMODE.WaitMODE Then objField.Draw()
        If g_GameState = GameMODE.PlayMODE Then objCountField.Start()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        g_GameState = GameMODE.WaitMODE
        SaveButton.Visible = False
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim objFileSystem As New FileSystem
        Dim objSaveSystem As New clsSaveFile

        objFileSystem.check(objSaveSystem)  '儲存檔案
    End Sub

    Private Sub LoadGmaeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadGmaeToolStripMenuItem.Click
        'Dim objField As New clsField
        Dim objFileSystem As New FileSystem
        Dim objLoadFile As New clsLoadFile

        objFileSystem.check(objLoadFile)    '讀取檔案

        Me.Refresh()
    End Sub

End Class

