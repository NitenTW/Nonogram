Public Class clsField

    Public Sub Draw()   '繪圖
        Dim objGraphics As Graphics = frmMain.CreateGraphics
        Dim objPen As New Pen(Color.Gray, 1)
        Dim tmpFieldSize As Byte
        Dim i As Byte

        tmpFieldSize = frmMain.g_FieldSize + 1

        For i = 1 To tmpFieldSize
            objPen.Color = Color.Gray
            objGraphics.DrawLine(objPen, i * 15, 35, i * 15, tmpFieldSize * 15 + 20)
            objGraphics.DrawLine(objPen, 15, i * 15 + 20, tmpFieldSize * 15, i * 15 + 20)
            If i Mod 5 = 1 Then
                objPen.Color = Color.Black
                objGraphics.DrawLine(objPen, i * 15, 35, i * 15, tmpFieldSize * 15 + 20)
                objGraphics.DrawLine(objPen, 15, i * 15 + 20, tmpFieldSize * 15, i * 15 + 20)
            End If
        Next i

        Call Clear()
        Call Black()
        Call Cross()
        objPen.Dispose()
        objGraphics.Dispose()
    End Sub

    Public Sub InitializeField(ByRef tmpArray(,) As Integer)    '初始陣列的值為0
        Dim i As Byte, j As Byte

        For i = 0 To frmMain.g_FieldSize
            For j = 0 To frmMain.g_FieldSize
                tmpArray(i, j) = 0
            Next j
        Next i
    End Sub

    Public Sub Black()
        Dim objGraphics As Graphics = frmMain.CreateGraphics
        Dim objBrush As New SolidBrush(Color.Black)
        Dim i As Byte, j As Byte

        If frmMain.g_FieldSize <> 0 Then
            For i = 0 To frmMain.g_FieldSize
                For j = 0 To frmMain.g_FieldSize
                    If frmMain.g_Field(i, j) = 1 Then objGraphics.FillRectangle(objBrush, i * 15 + 1, j * 15 + 21, 14, 14)
                Next j
            Next i
        End If

        objBrush.Dispose()
        objGraphics.Dispose()
    End Sub

    Public Sub Cross()
        Dim objGraphics As Graphics = frmMain.CreateGraphics
        Dim objPen As New Pen(Color.Black, 1)
        Dim objBrush As New SolidBrush(frmMain.BackColor)
        Dim i As Byte, j As Byte

        If frmMain.g_FieldSize <> 0 Then
            For i = 0 To frmMain.g_FieldSize
                For j = 0 To frmMain.g_FieldSize
                    If frmMain.g_Field(i, j) = 2 Then
                        objGraphics.FillRectangle(objBrush, i * 15 + 1, j * 15 + 21, 14, 14)
                        objGraphics.DrawLine(objPen, i * 15, j * 15 + 20, (i + 1) * 15, (j + 1) * 15 + 20)
                        objGraphics.DrawLine(objPen, (i + 1) * 15, j * 15 + 20, i * 15, (j + 1) * 15 + 20)
                    End If
                Next j
            Next i
        End If

        objBrush.Dispose()
        objPen.Dispose()
        objGraphics.Dispose()
    End Sub

    Public Sub Clear()
        Dim objGraphics As Graphics = frmMain.CreateGraphics
        Dim objBrush As New SolidBrush(frmMain.BackColor)
        Dim i As Byte, j As Byte

        If frmMain.g_FieldSize <> 0 Then
            For i = 0 To frmMain.g_FieldSize
                For j = 0 To frmMain.g_FieldSize

                    If frmMain.g_Field(i, j) = 0 Then
                        objGraphics.FillRectangle(objBrush, i * 15 + 1, j * 15 + 21, 14, 14)
                    End If

                Next j
            Next i
        End If

        objBrush.Dispose()
        objGraphics.Dispose()
    End Sub

    Public Function Complete() As Boolean
        Dim i As Integer, j As Integer

        Complete = False

        For i = 1 To frmMain.g_FieldSize
            For j = 1 To frmMain.g_FieldSize
                If frmMain.g_Field(i, j) = frmMain.g_answerField(i, j) Then
                    Complete = True
                ElseIf frmMain.g_Field(i, j) = 2 And frmMain.g_answerField(i, j) = 0 Then
                    Complete = True
                Else
                    Complete = False
                    Exit Function
                End If
            Next j
        Next i
    End Function
End Class