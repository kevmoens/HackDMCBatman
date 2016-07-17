' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.UI.Popups
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>


Partial Public NotInheritable Class MachineDataChartThree
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
    Private _UtilizationDays As ObservableCollection(Of UtilizationDay)
    Public Property UtilizationDays() As ObservableCollection(Of UtilizationDay)
        Get
            Return _UtilizationDays
        End Get
        Set(ByVal value As ObservableCollection(Of UtilizationDay))
            _UtilizationDays = value
        End Set
    End Property
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf MainPage_Loaded
        Me.DataContext = Me
    End Sub


    Public Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)


        Dim intOverallAbove As Integer = 0
        Dim intOverallBelow As Integer = 0
        Dim intDay As Integer = 0
        Dim intDayAbove As Integer = 0
        Dim intDayBelow As Integer = 0
        Dim intPrevSeq As Integer = 0
        Dim collUtilizationDays As New List(Of UtilizationDay)
        For Each oMD In g4Data
            If intPrevSeq + 700 < oMD.sequence Or ((oMD.value = 0) And gFakeData) Then
                If intDay > 0 Or gFakeData Then
                    collUtilizationDays.Add(New UtilizationDay() With {.Day = intDay, .Above = intDayAbove, .Below = intDayBelow})
                End If
                intDay += 1
                intDayAbove = 0
                intDayBelow = 0
            End If
            If oMD.value > 38 Or gFakeData And oMD.value > 3 Then
                intOverallAbove += 1
                intDayAbove += 1
            Else
                intOverallBelow += 1
                intDayBelow += 1
            End If
            intPrevSeq = oMD.sequence
        Next

        'Await New MessageDialog("Above:" + (intOverallAbove / 120.0).ToString + vbCrLf + "Below:" + (intOverallBelow / 120.0).ToString).ShowAsync()
        UtilizationDays = New ObservableCollection(Of UtilizationDay)(CType(collUtilizationDays, List(Of UtilizationDay)))
        Me.DataContext = Nothing
        Me.DataContext = Me
    End Sub

    Private Sub Button_Tapped(sender As Object, e As TappedRoutedEventArgs)
        If Frame.CanGoBack Then
            Frame.GoBack()
        End If
    End Sub
End Class