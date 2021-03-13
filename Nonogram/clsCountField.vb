Public Class clsCountField
    Public Sub Start()
        NumberX()
        NumberY()
    End Sub

    Private Sub NumberX()
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim tmpString As String
        Dim DrawNumber As Graphics = frmMain.CreateGraphics

        tmpCount = 0
        For i = 1 To frmMain.g_FieldSize
            k = 0
            tmpString = ""
            For j = 1 To frmMain.g_FieldSize
                If frmMain.g_checkField(j, i) = 1 Then
                    k += 1
                    DrawNumber.DrawString(CountX(j, i), New Font("Arial", 10, FontStyle.Bold), Brushes.DarkOrange, i * 15 + 1, frmMain.g_FieldSize * 15 + k * 15 + 20)
                    j = j + tmpCount
                    tmpCount = 0
                End If
            Next j
        Next i

        DrawNumber.Dispose()
    End Sub

    Private Sub NumberY()
        Dim i As Integer
        Dim j As Integer
        Dim tmpString As String
        Dim DrawNumber As Graphics = frmMain.CreateGraphics

        tmpCount = 0
        For i = 1 To frmMain.g_FieldSize
            tmpString = ""
            For j = 1 To frmMain.g_FieldSize
                If frmMain.g_checkField(i, j) = 1 Then
                    tmpString = tmpString & " " & CountY(i, j)
                    j = j + tmpCount
                    tmpCount = 0
                End If
            Next j
            DrawNumber.DrawString(tmpString, New Font("Arial", 10, FontStyle.Bold), Brushes.DarkOrange, frmMain.g_FieldSize * 15 + 15, i * 15 + 20)
        Next i

        DrawNumber.Dispose()
    End Sub

    Private tmpCount As Integer
    Private Function CountX(ByVal tmpX As Integer, ByVal tmpY As Integer) As Integer
        tmpCount += 1
        If frmMain.g_checkField(tmpX + 1, tmpY) = 1 Then CountX(tmpX + 1, tmpY)
        Return CountX + tmpCount
    End Function

    Private Function CountY(ByVal tmpX As Integer, ByVal tmpY As Integer) As Integer
        tmpCount += 1
        If frmMain.g_checkField(tmpX, tmpY + 1) = 1 Then CountY(tmpX, tmpY + 1)
        Return CountY + tmpCount
    End Function
End Class