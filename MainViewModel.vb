Imports System.Threading.Tasks
Imports DevExpress.Mvvm.DataAnnotations
Imports NewDasboradMain
<POCOViewModel>
Public Class MainViewModel
    Public Overridable ReadOnly Property Title As String

    Public Sub New()
        Title = "Blank Application (MVVM)"
    End Sub

    Public Async Function OnCreate() As Task
        ' يمكنك تنفيذ تهيئة هنا إن لزم الأمر
        Await Task.CompletedTask
    End Function

    Public Async Function OnDestroy() As Task
        ' يمكنك تنفيذ تنظيف هنا إن لزم الأمر
        Await Task.CompletedTask
    End Function
End Class
