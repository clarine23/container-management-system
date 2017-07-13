Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Net
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.Storage

Public Class WorkerRole
    Inherits RoleEntryPoint

    Private cancellationTokenSource As CancellationTokenSource = New CancellationTokenSource
    Private runCompleteEvent As ManualResetEvent = New ManualResetEvent(False)

    Public Overrides Sub Run()
        Trace.TraceInformation("CMSWorkerRole is running")

        Try
            Me.RunAsync(Me.cancellationTokenSource.Token).Wait()
        Finally
            Me.runCompleteEvent.Set()
        End Try
    End Sub

    Public Overrides Function OnStart() As Boolean
        ' Set the maximum number of concurrent connections
        ServicePointManager.DefaultConnectionLimit = 12

        ' For information on handling configuration changes
        ' see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.
        Dim result As Boolean = MyBase.OnStart()

        Trace.TraceInformation("CMSWorkerRole has been started")

        Return result
    End Function

    Public Overrides Sub OnStop()

        Trace.TraceInformation("CMSWorkerRole is stopping")

        Me.cancellationTokenSource.Cancel()
        Me.runCompleteEvent.WaitOne()

        MyBase.OnStop()

        Trace.TraceInformation("CMSWorkerRole has stopped")

    End Sub

    Private Async Function RunAsync(ByVal cancellationToken As CancellationToken) As Task

        ' TODO: Replace the following with your own logic.
        While Not cancellationToken.IsCancellationRequested
            Trace.TraceInformation("Working")
            Await Task.Delay(1000)
        End While

    End Function
End Class
