' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Dim bublAlarm As UIElement
    Dim bulbNormal As UIElement
    Private Sub Bulb_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles BAlarm.Tapped, BNormal.Tapped
        If DirectCast(sender, Windows.UI.Xaml.FrameworkElement).Name = "BNormal" Then
            theGrid.Children.Clear()
            theGrid.Children.Add(bublAlarm)
        Else
            theGrid.Children.Clear()
            theGrid.Children.Add(bulbNormal)
        End If
    End Sub

    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        bublAlarm = BAlarm
        bulbNormal = BNormal
        theGrid.Children.Clear()
        theGrid.Children.Add(bulbNormal)

    End Sub
End Class
