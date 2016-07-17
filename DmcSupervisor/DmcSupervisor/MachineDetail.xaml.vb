' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary> 
Public NotInheritable Class MachineDetail
    Inherits Page
    Private _MachData As ObservableCollection(Of MachineData)
    Public Property MachData() As ObservableCollection(Of MachineData)
        Get
            Return _MachData
        End Get
        Set(ByVal value As ObservableCollection(Of MachineData))
            _MachData = value
        End Set
    End Property
    Public Property Backbtn() As UIElement
        Get
            Return btnBack
        End Get
        Set(value As UIElement)
            btnBack = value
        End Set
    End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = Me
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        MachData = New ObservableCollection(Of MachineData)(modDmcSupervisor.g2Data)
        listView.ItemsSource = MachData
    End Sub
    Private Sub Button_Tapped(sender As Object, e As TappedRoutedEventArgs)
        If Frame.CanGoBack Then
            Frame.GoBack()
        End If
    End Sub
End Class
