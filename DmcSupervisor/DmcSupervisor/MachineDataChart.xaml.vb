' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.UI.Popups
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>


Partial Public NotInheritable Class MachineDataChart
    Inherits Page
    Public Property Backbtn() As UIElement
        Get
            Return btnBack
        End Get
        Set(value As UIElement)
            btnBack = value
        End Set
    End Property
    Private _MachData As ObservableCollection(Of MachineData)
    Public Property MachData() As ObservableCollection(Of MachineData)
        Get
            Return _MachData
        End Get
        Set(ByVal value As ObservableCollection(Of MachineData))
            _MachData = value
        End Set
    End Property
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf MainPage_Loaded
        Me.DataContext = Me
    End Sub

    Protected Sub OnNavigateTo(e As NavigationEventArgs)
        ' Get parameters
        MachData = New ObservableCollection(Of MachineData)(CType(e.Parameter, List(Of MachineData)))
    End Sub

    Public Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)

        'Dim db As New DmcUtility.MachineDataTryCast(Window.Current.Content, Frame)
        'MachData = New ObservableCollection(Of MachineData)(Await db.GetTop100())

        'Dim intOverallAbove As Integer = 0
        'Dim intOverallBelow As Integer = 0
        'Dim intDay As Integer = 0
        'Dim intDayAbove As Integer = 0
        'Dim intDayBelow As Integer = 0
        'Dim intPrevSeq As Integer = 0
        'Dim collUtilizationDays As New List(Of UtilizationDay)
        'For Each oMD In MachData
        '    If intPrevSeq + 700 < oMD.sequence Then
        '        If intDay > 0 Then
        '            collUtilizationDays.Add(New UtilizationDay() With {.Day = intDay, .Above = intDayAbove, .Below = intDayBelow})
        '        End If
        '        intDay += 1
        '        intDayAbove = 0
        '        intDayBelow = 0
        '    End If
        '    If oMD.value > 38 Then
        '        intOverallAbove += 1
        '        intDayAbove += 1
        '    Else
        '        intOverallBelow += 1
        '        intDayBelow += 1
        '    End If
        '    intPrevSeq = oMD.sequence
        'Next
        'For Each oUD In collUtilizationDays
        '    If oUD.Above + oUD.Below > 10 Then
        '        Await New MessageDialog("Day:" + oUD.Day.ToString + vbCrLf + "Total:" + CStr(oUD.Above + oUD.Below) + vbCrLf + "Above:" + CStr(CDbl(oUD.Above / (oUD.Above + oUD.Below))) + vbCrLf + "Below:" + CDbl(oUD.Below / (oUD.Above + oUD.Below)).ToString).ShowAsync()
        '    End If
        'Next
        'Await New MessageDialog("Above:" + (intOverallAbove / 120.0).ToString + vbCrLf + "Below:" + (intOverallBelow / 120.0).ToString).ShowAsync()
        'Me.DataContext = Nothing
        'Me.DataContext = Me
    End Sub

    Private Sub Button_Tapped(sender As Object, e As TappedRoutedEventArgs)
        If Frame.CanGoBack Then
            Frame.GoBack()
        End If
    End Sub
End Class


