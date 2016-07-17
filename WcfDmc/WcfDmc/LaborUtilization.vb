Public Class LaborUtilization
    Private _Date As String
    Public Property [Date]() As String
        Get
            Return _Date
        End Get
        Set(ByVal value As String)
            _Date = value
        End Set
    End Property
    Private _DirectHours As Decimal?
    Public Property DirectHours() As Decimal?
        Get
            Return _DirectHours
        End Get
        Set(ByVal value As Decimal?)
            _DirectHours = value
        End Set
    End Property
    Private _IndirectHours As Decimal?
    Public Property IndirectHours() As Decimal?
        Get
            Return _IndirectHours
        End Get
        Set(ByVal value As Decimal?)
            _IndirectHours = value
        End Set
    End Property
    Private _Utilization As Decimal?
    Public Property Utilization() As Decimal?
        Get
            Return _Utilization
        End Get
        Set(ByVal value As Decimal?)
            _Utilization = value
        End Set
    End Property
End Class
