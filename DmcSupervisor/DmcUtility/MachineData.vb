Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class MachineData
    Public Async Function GetTop100() As Task(Of List(Of MachineData))

        Dim results As String = String.Empty
        Dim strURI As String = "http://10.10.28.167:9000/data/items/400"

        Dim req As WebRequest = WebRequest.Create(strURI)
        Dim wr = Await req.GetResponseAsync
        Dim objStream As Stream = wr.GetResponseStream()
        Dim reader As New StreamReader(objStream)

        results = reader.ReadToEnd()
        Debug.WriteLine(results)
        Dim items = JObject.Parse(results).SelectToken("items").ToString()

        Dim objResults As List(Of MachineData) = JsonConvert.DeserializeObject(Of List(Of MachineData))(items)
        Return objResults
    End Function

    Private _category As String
    Public Property category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property
    Private _component As String
    Public Property component() As String
        Get
            Return _component
        End Get
        Set(ByVal value As String)
            _component = value
        End Set
    End Property
    Private _type As String
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property
    Private _subtype As String
    Public Property subtype() As String
        Get
            Return _subtype
        End Get
        Set(ByVal value As String)
            _subtype = value
        End Set
    End Property
    Private _machine_id As Integer
    Public Property machine_id() As Integer
        Get
            Return _machine_id
        End Get
        Set(ByVal value As Integer)
            _machine_id = value
        End Set
    End Property
    Private _instance_id As Integer
    Public Property instance_id() As Integer
        Get
            Return _instance_id
        End Get
        Set(ByVal value As Integer)
            _instance_id = value
        End Set
    End Property
    Private _sequence As Integer
    Public Property sequence() As Integer
        Get
            Return _sequence
        End Get
        Set(ByVal value As Integer)
            _sequence = value
        End Set
    End Property
    Private _mt_name As String
    Public Property mt_name() As String
        Get
            Return _mt_name
        End Get
        Set(ByVal value As String)
            _mt_name = value
        End Set
    End Property
    Private _mt_value As String
    Public Property mt_value() As String
        Get
            Return _mt_value
        End Get
        Set(ByVal value As String)
            _mt_value = value
        End Set
    End Property
    Public ReadOnly Property value() As Double
        Get
            Dim dblValue As Double = 0
            Dim bSuccess = Decimal.TryParse(mt_value, dblValue)
            If bSuccess Then
                Return dblValue
            Else
                Return 0
            End If
        End Get
    End Property
    Private _virtual_flag As String
    Public Property virtual_flag() As String
        Get
            Return _virtual_flag
        End Get
        Set(ByVal value As String)
            _virtual_flag = value
        End Set
    End Property
End Class
