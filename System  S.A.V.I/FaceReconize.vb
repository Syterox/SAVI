Imports Emgu.CV
Imports Emgu.Util
Imports Emgu.CV.Util
Imports Emgu.CV.Structure

Module FaceReconize
    Public imagez As Image(Of Gray, Byte)
    Public numLabels As Integer
    Public imagelist() As Image(Of Gray, Byte)
    Public labellist() As String
    Dim I As Integer
    Public Sub init_reco_facial()
        Try

            Dim labels(frmMemory.Memory.PsrnMemory.Rows.Count - 1) As String
            Dim imagelst(frmMemory.Memory.PsrnMemory.Rows.Count - 1) As Image(Of Gray, Byte)

            For I = 0 To frmMemory.Memory.PsrnMemory.Rows.Count - 1
                If I >= 0 Then
                    Dim dir As String = frmCarga.StrSystem_faces & "\face" & I + 1 & ".bmp"
                    Dim tempimage As Bitmap = New Bitmap(dir)
                    imagelst(I) = New Image(Of Gray, Byte)(tempimage)
                    labels(I) = frmMemory.Memory.PsrnMemory.Rows(I).Item("name")
                End If
            Next
            imagelist = imagelst
            labellist = labels
            numLabels = I

        Catch ex As Exception
            MsgBox("Error:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public Function faceReconize(bmp As Bitmap) As String


        imagez = New Image(Of Gray, Byte)(bmp)
        Dim TermCrit As MCvTermCriteria = New MCvTermCriteria(numLabels, 0.001)
        Dim maxdistance As Integer = 3000 'The higher the number, the difference is allowed
        Dim EobjectRec As EigenObjectRecognizer = New EigenObjectRecognizer(imagelist, labellist, maxdistance, TermCrit)

        Try
            Return EobjectRec.Recognize(imagez)

        Catch ex As Exception
            Return "Desconocido" 'This means nothing was close enough for a good match
        End Try

    End Function

    Public Function GetIdPerson(name As String) As Integer
        For b As Integer = 0 To frmMemory.Memory.PsrnMemory.Rows.Count - 1
            If frmMemory.Memory.PsrnMemory.Rows(b).Item(1) = name Then

                Return b

            End If
        Next
        Return -1
    End Function

    Sub saveNewFace(name As String, img As Bitmap)
        If img Is Nothing Then Return
        I += 1
        img.Save(frmCarga.StrSystem_faces & "\face" & I & ".bmp")
        frmMemory.Memory.PsrnMemory.AddPsrnMemoryRow(name, "", "", False)

        SaveFaceData()
        LoadFaceData()
        init_reco_facial()
    End Sub

    Public Sub SaveFaceData()
        frmMemory.Memory.WriteXml(frmCarga.StrSystem_memory_file)
        LoadFaceData()
    End Sub
    Public Sub LoadFaceData()
        frmMemory.Memory.Clear()
        frmMemory.Memory.ReadXml(frmCarga.StrSystem_memory_file)
        frmMemory.DataPersons.Update()
    End Sub
End Module
