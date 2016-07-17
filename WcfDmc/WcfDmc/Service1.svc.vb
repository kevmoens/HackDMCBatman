' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
Public Class Service1
    Implements IService1
    Private _ConnectionString As String = "Server=sl90000;database=demo_app;user id=sa;password=!!What4" ';Application Name=Shop-Trak:Demo"
    Public Sub New()
    End Sub
    Public Function GetLaborUtilization(user As String) As List(Of LaborUtilization) Implements IService1.GetLaborUtilization
        Dim db As New System.Data.Linq.DataContext(_ConnectionString)
        Return db.ExecuteQuery(Of LaborUtilization)("exec setsitesp 'Demo',null" & vbCrLf & "exec lc_lt_GetUtilizationForGraphSP {0}", user).ToList
    End Function
    

End Class
