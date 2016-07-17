' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.UI.Popups
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>


Partial Public NotInheritable Class MachineDataChartTwo
    Inherits Page
    Public Property Backbtn() As UIElement
        Get
            Return btnBack
        End Get
        Set(value As UIElement)
            btnBack = value
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

    End Sub

    Public Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)


        Dim intOverallAbove As Integer = 0
        Dim intOverallBelow As Integer = 0
        Dim intDay As Integer = 0
        Dim intDayAbove As Integer = 0
        Dim intDayBelow As Integer = 0
        Dim intPrevSeq As Integer = 0
        Dim collUtilizationDays As New List(Of UtilizationDay)
        For Each oMD In g3Data
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
Public Class UtilizationDay
    Private _Day As Integer
    Public Property Day() As Integer
        Get
            Return _Day
        End Get
        Set(ByVal value As Integer)
            _Day = value
        End Set
    End Property
    Private _Above As Integer
    Public Property Above() As Integer
        Get
            Return _Above
        End Get
        Set(ByVal value As Integer)
            _Above = value
        End Set
    End Property
    Private _Below As Integer
    Public Property Below() As Integer
        Get
            Return _Below
        End Get
        Set(ByVal value As Integer)
            _Below = value
        End Set
    End Property
    Public ReadOnly Property AbovePercent As Double
        Get
            Return CDbl((Above / (Above + Below)) * 100.0)
        End Get
    End Property
End Class


