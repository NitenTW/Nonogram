Public MustInherit Class clsFileSystem
    Public MustOverride Sub run()
End Class

Public Class FileSystem
    Public Sub check(ByVal objValue As clsFileSystem)
        objValue.run()
    End Sub
End Class

Public Class clsSaveFile : Inherits clsFileSystem
    Public Overrides Sub run()
        Dim fileNum As Integer
        Dim i As Byte, j As Byte
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "Nonogram Files (*.nng)|*.nng"
        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fileNum = FreeFile()
            FileOpen(fileNum, saveFileDialog1.FileName, OpenMode.Output)
            Print(fileNum, frmMain.g_FieldSize & vbNullString)

            For i = 1 To frmMain.g_FieldSize
                Print(fileNum, vbCrLf)  '換行
                For j = 1 To frmMain.g_FieldSize
                    Print(fileNum, frmMain.g_Field(j, i) & vbNullString)
                Next j
            Next i
        End If

        FileClose(fileNum)
        saveFileDialog1.Dispose()
    End Sub
End Class

Public Class clsLoadFile : Inherits clsFileSystem
    Public Overrides Sub run()
        Dim fileNum As Integer
        Dim tmpArrayField As String
        Dim i As Integer, j As Integer
        Dim openFileDialog1 As New OpenFileDialog()
        Dim objField As New clsField

        'openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "Nonogram Files (*.nng)|*.nng"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fileNum = FreeFile()
            FileOpen(fileNum, openFileDialog1.FileName, OpenMode.Input)
            frmMain.g_FieldSize = LineInput(fileNum)

            ReDim frmMain.g_Field(frmMain.g_FieldSize, frmMain.g_FieldSize)
            ReDim frmMain.g_checkField(frmMain.g_FieldSize + 1, frmMain.g_FieldSize + 1)
            ReDim frmMain.g_answerField(frmMain.g_FieldSize + 1, frmMain.g_FieldSize + 1)
            objField.InitializeField(frmMain.g_Field)  '初始 g_Field 的值

            For i = 1 To frmMain.g_FieldSize
                tmpArrayField = LineInput(fileNum)
                For j = 1 To frmMain.g_FieldSize
                    frmMain.g_checkField(i, j) = Mid(tmpArrayField, j, 1)
                    frmMain.g_answerField(j, i) = Mid(tmpArrayField, j, 1)
                Next j
            Next i

            frmMain.Label1.Visible = False
            frmMain.SaveButton.Visible = False
            frmMain.g_GameState = frmMain.GameMODE.PlayMODE

            Select Case frmMain.g_FieldSize '設定form大小
                Case 10
                    frmMain.Size = New Size(235, 300)

                Case 15
                    frmMain.Size = New Size(350, 430)

                Case 20
                    frmMain.Size = New Size(445, 530)
            End Select

            FileClose(fileNum)
            openFileDialog1.Dispose()
        End If
    End Sub
End Class