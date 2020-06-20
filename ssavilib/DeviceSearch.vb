Imports System.Net.Sockets
Imports System.Text.Encoding
Imports System.Net
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Net.NetworkInformation

Namespace Network
    Public Class DeviceSearch


        Public Const SUCCESS = 1
        Public Const NOT_FOUND = 2
        Public Const PORT_IN_USE = 3


        Public Delegate Sub handleResult(r As Integer, ip As String)

        Private Shared device As DeviceSearch

        Private Port As Integer = -1

        Private listDevices As List(Of DeviceSearch.handleResult) = New List(Of DeviceSearch.handleResult)()

        Private _thread As Thread

        Protected receiveIP As IPEndPoint

        Protected udpClient As UdpClient

        Private isStart As Boolean

        Public Sub New()
        End Sub

        Public Shared Function getInstance() As DeviceSearch
            If DeviceSearch.device Is Nothing Then
                DeviceSearch.device = New DeviceSearch()
            End If
            Return DeviceSearch.device
        End Function

        Public Shared Function portInUse(port As Integer) As Boolean
            Dim activeUdpListeners As IPEndPoint() = IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners()
            For i As Integer = 0 To activeUdpListeners.Length - 1
                Dim iPEndPoint As IPEndPoint = activeUdpListeners(i)
                If iPEndPoint.Port = port Then
                    Return True
                End If
            Next
            Return False
        End Function

        Private Sub search()
            If DeviceSearch.portInUse(Me.Port) Then
                For Each current As DeviceSearch.handleResult In Me.listDevices
                    Try
                        current(PORT_IN_USE, Nothing)
                    Catch ex_2E As Exception
                    End Try
                Next
                Me.[stop]()
                Return
            End If
            Me.receiveIP = New IPEndPoint(IPAddress.Any, Me.Port)
            Me.udpClient = New UdpClient(Me.Port)
            Me.udpClient.Client.ReceiveTimeout = 500
            Dim num As Integer = -1
            While num <> 123 AndAlso Me.isStart
                Try
                    num = Me.udpResult()
                Catch ex_9A As Exception
                End Try
            End While
            Dim expr_B0 As List(Of DeviceSearch.handleResult) = Me.listDevices
            Dim obj As List(Of DeviceSearch.handleResult) = expr_B0
            Monitor.Enter(expr_B0)
            Try
                For Each current2 As DeviceSearch.handleResult In Me.listDevices
                    Try
                        If num = 123 Then
                            current2(SUCCESS, Me.receiveIP.Address.ToString())
                        Else
                            current2(NOT_FOUND, Nothing)
                        End If
                    Catch ex_F6 As Exception
                    End Try
                Next
                Me.listDevices.Clear()
            Finally
                Monitor.[Exit](obj)
            End Try
            Me.[stop]()
        End Sub


        Public Sub start(port As Integer, rcs As DeviceSearch.handleResult)
            Dim list As List(Of DeviceSearch.handleResult) = Me.listDevices
            Dim obj As List(Of DeviceSearch.handleResult) = list
            Monitor.Enter(list)
            Try
                If Not Me.listDevices.Contains(rcs) Then
                    listDevices.Add(rcs)
                End If
            Finally
                Monitor.[Exit](obj)
            End Try
            SyncLock Me
                If Not Me.isStart Then
                    Me.isStart = True
                    Me.Port = port
                    Me._thread = New Thread(AddressOf search)
                    Me._thread.Start()
                End If
            End SyncLock
        End Sub

        Public Sub [stop]()
            If Me.isStart Then
                SyncLock Me
                    Me.isStart = False
                    If Thread.CurrentThread IsNot Me._thread AndAlso Me._thread IsNot Nothing Then
                        Me._thread.Join()
                    End If
                    Try
                        If Me.udpClient IsNot Nothing Then
                            Me.udpClient.Close()
                        End If
                    Catch ex_4C As Exception
                    End Try
                End SyncLock
            End If
        End Sub

        Public Function getIP() As String
            If Me.receiveIP Is Nothing OrElse Me.receiveIP.Address Is Nothing OrElse Me.receiveIP.Address Is IPAddress.Any Then
                Return Nothing
            End If
            Return Me.receiveIP.Address.ToString()
        End Function

        Private Function udpResult() As Integer
            Dim array As Byte() = Me.udpClient.Receive(Me.receiveIP)
            Debug.Print("-->" & array(0))

            Return CInt(array(0))
        End Function

    End Class
End Namespace

