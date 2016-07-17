' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Async Sub FirstFrame_Tapped(sender As Object, e As TappedRoutedEventArgs)
        '// The URI to launch
        Dim uriBing = New Uri("http://www.dccomics.com/characters/batman")

        '// Launch the URI
        Dim success = Await Windows.System.Launcher.LaunchUriAsync(uriBing)

    End Sub

    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim db As New DmcUtility.MachineData
        Dim MachData = New ObservableCollection(Of MachineData)(Await db.GetTop100())
        If gFakeData Then
            Dim rnd = New Random()
            For i = 1 To 400
                MachData.Add(New MachineData() With {.sequence = i, .mt_value = Math.Ceiling(rnd.Next(0, 40)).ToString})
            Next
        End If
        g1Data = MachData.Take(100).ToList
        g2Data = MachData.Skip(100).Take(100).ToList
        g3Data = MachData.Skip(200).Take(100).ToList
        g4Data = MachData.Skip(300).Take(100).ToList
        FirstFrame.Navigate(GetType(MachineDataChart), g1Data)
        SecondFrame.Navigate(GetType(MachineDataChartOne), g2Data)
        ThirdFrame.Navigate(GetType(MachineDataChartTwo), g3Data)
        FourthFrame.Navigate(GetType(MachineDataChartThree), g4Data)
    End Sub

    Private Sub SecondFrame_Tapped(sender As Object, e As TappedRoutedEventArgs)
        Me.Frame.Navigate(GetType(MachineDetail))
    End Sub

    Private Sub FirstFrame_Navigated(sender As Object, e As NavigationEventArgs)
        CType(FirstFrame.Content, MachineDataChart).MachData = New ObservableCollection(Of MachineData)(modDmcSupervisor.g1Data)
        CType(CType(FirstFrame.Content, MachineDataChart).Content, Grid).Children.Remove(CType(FirstFrame.Content, MachineDataChart).Backbtn)
    End Sub

    Private Sub SecondFrame_Navigated(sender As Object, e As NavigationEventArgs)
        CType(SecondFrame.Content, MachineDataChartOne).MachData = New ObservableCollection(Of MachineData)(modDmcSupervisor.g2Data.Take(20))
        CType(SecondFrame.Content, MachineDataChartOne).MachDataNext = New ObservableCollection(Of MachineData)(modDmcSupervisor.g2Data.Skip(20))
        CType(CType(SecondFrame.Content, MachineDataChartOne).Content, Grid).Children.Remove(CType(SecondFrame.Content, MachineDataChartOne).Backbtn)
    End Sub

    Private Sub ThirdFrame_Navigated(sender As Object, e As NavigationEventArgs)
        CType(ThirdFrame.Content, MachineDataChartTwo).MachData = New ObservableCollection(Of MachineData)(modDmcSupervisor.g3Data)
        CType(CType(ThirdFrame.Content, MachineDataChartTwo).Content, Grid).Children.Remove(CType(ThirdFrame.Content, MachineDataChartTwo).Backbtn)
    End Sub

    Private Sub FourthFrame_Navigated(sender As Object, e As NavigationEventArgs)
        CType(FourthFrame.Content, MachineDataChartThree).MachData = New ObservableCollection(Of MachineData)(modDmcSupervisor.g4Data)
        CType(CType(FourthFrame.Content, MachineDataChartThree).Content, Grid).Children.Remove(CType(FourthFrame.Content, MachineDataChartThree).Backbtn)

    End Sub
End Class
