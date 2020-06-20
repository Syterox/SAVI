Imports System.Drawing


Public Class rendering

    Public Sub imagefrombytes(ByRef bytez() As Byte, ByRef piccolor As Bitmap)
        Dim rect As New Rectangle(0, 0, piccolor.Width, piccolor.Height)
        Dim bmpData As System.Drawing.Imaging.BitmapData = piccolor.LockBits(rect,
            Drawing.Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format32bppRgb)
        Dim ptr As IntPtr = bmpData.Scan0
        Dim bytes As Integer = bmpData.Stride * piccolor.Height
        Dim rgbValues(bytes - 1) As Byte
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)

        Dim secondcounter As Integer
        Dim tempred As Integer
        Dim tempblue As Integer
        Dim tempgreen As Integer
        Dim tempalpha As Integer
        secondcounter = 0

        While secondcounter < rgbValues.Length
            tempblue = rgbValues(secondcounter)
            tempgreen = rgbValues(secondcounter + 1)
            tempred = rgbValues(secondcounter + 2)
            tempalpha = rgbValues(secondcounter + 3)
            tempalpha = 255

            tempred = bytez(((secondcounter * 0.25) * 3) + 0)
            tempgreen = bytez(((secondcounter * 0.25) * 3) + 1)
            tempblue = bytez(((secondcounter * 0.25) * 3) + 2)

            rgbValues(secondcounter) = tempblue
            rgbValues(secondcounter + 1) = tempgreen
            rgbValues(secondcounter + 2) = tempred
            rgbValues(secondcounter + 3) = tempalpha

            secondcounter = secondcounter + 4
        End While


        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

        piccolor.UnlockBits(bmpData)

    End Sub

    Public Sub bytesfromimage(ByRef bytez() As Byte, ByRef piccolor As Bitmap)
        Dim rect As New Rectangle(0, 0, piccolor.Width, piccolor.Height)
        Dim bmpData As System.Drawing.Imaging.BitmapData = piccolor.LockBits(rect,
            Drawing.Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format32bppRgb)
        Dim ptr As IntPtr = bmpData.Scan0
        Dim bytes As Integer = bmpData.Stride * piccolor.Height
        Dim rgbValues(bytes - 1) As Byte
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)

        Dim secondcounter As Integer
        Dim tempred As Integer
        Dim tempblue As Integer
        Dim tempgreen As Integer
        Dim tempalpha As Integer
        secondcounter = 0
        Dim bytelist As List(Of Byte) = New List(Of Byte)

        While secondcounter < rgbValues.Length
            tempblue = rgbValues(secondcounter)
            tempgreen = rgbValues(secondcounter + 1)
            tempred = rgbValues(secondcounter + 2)
            tempalpha = rgbValues(secondcounter + 3)
            tempalpha = 255

            bytelist.Add(tempred)
            bytelist.Add(tempgreen)
            bytelist.Add(tempblue)

            rgbValues(secondcounter) = tempblue
            rgbValues(secondcounter + 1) = tempgreen
            rgbValues(secondcounter + 2) = tempred
            rgbValues(secondcounter + 3) = tempalpha

            secondcounter = secondcounter + 4
        End While


        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

        piccolor.UnlockBits(bmpData)

        Dim bytearray(bytelist.Count - 1) As Byte
        For i = 0 To bytelist.Count - 1
            bytearray(i) = bytelist(i)
        Next
        bytez = bytearray

    End Sub
End Class
