Public Class Form1

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim db As New ServiceReference1.Service1Client
        Dim collLU = db.GetLaborUtilization("sa")
        MsgBox(collLU.Count.ToString)
    End Sub
End Class
