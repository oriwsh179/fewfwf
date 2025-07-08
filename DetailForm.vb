Imports System.ComponentModel
Imports System.Text
Imports DevExpress.XtraEditors




Public Class DetailForm
        Private _departmentName As String

        Public Sub New(department As String)
            InitializeComponent()
            _departmentName = department
        End Sub

        Private Sub DetailForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "تفاصيل القسم: " & _departmentName
        ' يمكنك الآن استخدام _departmentName لعرض البيانات حسب القسم
    End Sub
    End Class


