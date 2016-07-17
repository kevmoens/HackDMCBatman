' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService1" in both code and config file together.
<ServiceContract()>
Public Interface IService1
    <OperationContract()>
    Function GetLaborUtilization(user As String) As List(Of LaborUtilization)

    '<OperationContract()>
    'Function GetData(ByVal value As Integer) As String

    '<OperationContract()>
    'Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType

    ' TODO: Add your service operations here

End Interface
