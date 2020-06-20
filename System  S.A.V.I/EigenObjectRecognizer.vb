Imports Emgu.CV.CvEnum
Imports Emgu.CV
Imports Emgu.CV.[Structure]
Imports System
Imports System.Diagnostics
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Namespace Emgu.CV
    <Serializable()>
    Public Class EigenObjectRecognizer
        Private _eigenImages As Image(Of Gray, Single)()

        Private _avgImage As Image(Of Gray, Single)

        Private _eigenValues As Matrix(Of Single)()

        Private _labels As String()

        Private _eigenDistanceThreshold As Double

        Public Property EigenImages() As Image(Of Gray, Single)()
            Get
                Return Me._eigenImages
            End Get
            Set(value As Image(Of Gray, Single)())
                Me._eigenImages = value
            End Set
        End Property

        Public Property Labels() As String()
            Get
                Return Me._labels
            End Get
            Set(value As String())
                Me._labels = value
            End Set
        End Property

        Public Property EigenDistanceThreshold() As Double
            Get
                Return Me._eigenDistanceThreshold
            End Get
            Set(value As Double)
                Me._eigenDistanceThreshold = value
            End Set
        End Property

        Public Property AverageImage() As Image(Of Gray, Single)
            Get
                Return Me._avgImage
            End Get
            Set(value As Image(Of Gray, Single))
                Me._avgImage = value
            End Set
        End Property

        Public Property EigenValues() As Matrix(Of Single)()
            Get
                Return Me._eigenValues
            End Get
            Set(value As Matrix(Of Single)())
                Me._eigenValues = value
            End Set
        End Property

        Private Sub New()
        End Sub

        Public Sub New(images As Image(Of Gray, Byte)(), ByRef termCrit As MCvTermCriteria)
            Me.New(images, EigenObjectRecognizer.GenerateLabels(images.Length), termCrit)
        End Sub

        Private Shared Function GenerateLabels(size As Integer) As String()
            Dim labels As String() = New String(size - 1) {}
            For i As Integer = 0 To size - 1
                labels(i) = i.ToString()
            Next
            Return labels
        End Function

        Public Sub New(images As Image(Of Gray, Byte)(), labels As String(), ByRef termCrit As MCvTermCriteria)
            Me.New(images, labels, 0.0, termCrit)
        End Sub

        Public Sub New(images As Image(Of Gray, Byte)(), labels As String(), eigenDistanceThreshold As Double, ByRef termCrit As MCvTermCriteria)
            Debug.Assert(images.Length = labels.Length, "The number of images should equals the number of labels")
            Debug.Assert(eigenDistanceThreshold >= 0.0, "Eigen-distance threshold should always >= 0.0")
            EigenObjectRecognizer.CalcEigenObjects(images, termCrit, Me._eigenImages, Me._avgImage)
            Me._eigenValues = Array.ConvertAll(Of Image(Of Gray, Byte), Matrix(Of Single))(images, Function(img As Image(Of Gray, Byte)) New Matrix(Of Single)(EigenObjectRecognizer.EigenDecomposite(img, Me._eigenImages, Me._avgImage)))
            Me._labels = labels
            Me._eigenDistanceThreshold = eigenDistanceThreshold
        End Sub

        Public Shared Sub CalcEigenObjects(trainingImages As Image(Of Gray, Byte)(), ByRef termCrit As MCvTermCriteria, <Out()> ByRef eigenImages As Image(Of Gray, Single)(), <Out()> ByRef avg As Image(Of Gray, Single))
            Dim width As Integer = trainingImages(0).Width
            Dim height As Integer = trainingImages(0).Height
            Dim inObjs As IntPtr() = Array.ConvertAll(Of Image(Of Gray, Byte), IntPtr)(trainingImages, Function(img As Image(Of Gray, Byte)) img.Ptr)
            If termCrit.max_iter <= 0 OrElse termCrit.max_iter > trainingImages.Length Then
                termCrit.max_iter = trainingImages.Length
            End If
            Dim maxEigenObjs As Integer = termCrit.max_iter
            eigenImages = New Image(Of Gray, Single)(maxEigenObjs - 1) {}
            For i As Integer = 0 To eigenImages.Length - 1
                eigenImages(i) = New Image(Of Gray, Single)(width, height)
            Next
            Dim eigObjs As IntPtr() = Array.ConvertAll(Of Image(Of Gray, Single), IntPtr)(eigenImages, Function(img As Image(Of Gray, Single)) img.Ptr)
            avg = New Image(Of Gray, Single)(width, height)
            CvInvoke.cvCalcEigenObjects(inObjs, termCrit, eigObjs, Nothing, avg.Ptr)
        End Sub

        Public Shared Function EigenDecomposite(src As Image(Of Gray, Byte), eigenImages As Image(Of Gray, Single)(), avg As Image(Of Gray, Single)) As Single()
            Return CvInvoke.cvEigenDecomposite(src.Ptr, Array.ConvertAll(Of Image(Of Gray, Single), IntPtr)(eigenImages, Function(img As Image(Of Gray, Single)) img.Ptr), avg.Ptr)
        End Function

        Public Function EigenProjection(eigenValue As Single()) As Image(Of Gray, Byte)
            Dim res As Image(Of Gray, Byte) = New Image(Of Gray, Byte)(Me._avgImage.Width, Me._avgImage.Height)
            CvInvoke.cvEigenProjection(Array.ConvertAll(Of Image(Of Gray, Single), IntPtr)(Me._eigenImages, Function(img As Image(Of Gray, Single)) img.Ptr), eigenValue, Me._avgImage.Ptr, res.Ptr)
            Return res
        End Function

        Public Function GetEigenDistances(image As Image(Of Gray, Byte)) As Single()
            Dim result As Single()
            Using eigenValue As Matrix(Of Single) = New Matrix(Of Single)(EigenObjectRecognizer.EigenDecomposite(image, Me._eigenImages, Me._avgImage))
                result = Array.ConvertAll(Of Matrix(Of Single), Single)(Me._eigenValues, Function(eigenValueI As Matrix(Of Single)) CSng(CvInvoke.cvNorm(eigenValue.Ptr, eigenValueI.Ptr, NORM_TYPE.CV_L2, IntPtr.Zero)))
            End Using
            Return result
        End Function

        Public Sub FindMostSimilarObject(image As Image(Of Gray, Byte), <Out()> ByRef index As Integer, <Out()> ByRef eigenDistance As Single, <Out()> ByRef label As String)
            Dim dist As Single() = Me.GetEigenDistances(image)
            index = 0
            eigenDistance = dist(0)
            For i As Integer = 1 To dist.Length - 1
                If dist(i) < eigenDistance Then
                    index = i
                    eigenDistance = dist(i)
                End If
            Next
            label = Me.Labels(index)
        End Sub

        Public Function Recognize(image As Image(Of Gray, Byte)) As String
            Dim index As Integer
            Dim eigenDistance As Single
            Dim label As String
            Me.FindMostSimilarObject(image, index, eigenDistance, label)
            If Me._eigenDistanceThreshold > 0.0 AndAlso CDec(eigenDistance) >= Me._eigenDistanceThreshold Then
                Return String.Empty
            End If
            Return Me._labels(index)
        End Function
    End Class
End Namespace
