Imports System.Data.SqlClient

Public Class DepartmentStats
    Public Property DepartmentName As String
    Public Property TotalCount As Integer
    Public Property Breakdown As Dictionary(Of String, Integer)
End Class

Public Class DbManager
    Private ReadOnly connectionString As String

    Public Sub New(connStr As String)
        connectionString = connStr
    End Sub

    Public Function GetCarStats() As List(Of DepartmentStats)
        Dim list As New List(Of DepartmentStats)()
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' جلب عدد السيارات حسب القسم والحالة
            Dim sql As String = "SELECT c3 AS Department, CODE, COUNT(*) AS Count FROM CAR_A GROUP BY c3, CODE"
            Using cmd As New SqlCommand(sql, conn)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    Dim grouped As New Dictionary(Of String, DepartmentStats)()

                    While reader.Read()
                        Dim dept As String = reader.GetString(0)
                        Dim code As String = reader.GetString(1)
                        Dim count As Integer = reader.GetInt32(2)

                        If Not grouped.ContainsKey(dept) Then
                            grouped(dept) = New DepartmentStats With {
                                .DepartmentName = dept,
                                .Breakdown = New Dictionary(Of String, Integer)()
                            }
                        End If

                        grouped(dept).Breakdown(code) = count
                    End While

                    ' جمع المجموع الكلي
                    For Each kv In grouped
                        kv.Value.TotalCount = kv.Value.Breakdown.Values.Sum()
                        list.Add(kv.Value)
                    Next
                End Using
            End Using
        End Using

        Return list
    End Function
End Class
