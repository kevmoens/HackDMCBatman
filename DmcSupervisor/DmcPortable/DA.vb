Imports System.ServiceModel
Imports DmcPortable.ServiceReference1

Public Class DA
    Public Sub Main()
        Dim strFileSystemWebServiceURL As String = "http://192.168.21.128/WcfDmc/Service1.svc"
        strFileSystemWebServiceURL = "http://10.10.10.13/WcfDmc/Service1.svc"
        Dim bindingContext = New BasicHttpBinding ' BasicHttpContextBinding()
        bindingContext.MaxReceivedMessageSize = 2147483647
        bindingContext.MaxBufferSize = 2147483647
        bindingContext.ReaderQuotas.MaxDepth = 2147483647
        bindingContext.ReaderQuotas.MaxStringContentLength = 2147483647
        bindingContext.ReaderQuotas.MaxArrayLength = 2147483647
        Dim ChannelFactory As New ServiceModel.ChannelFactory(Of ServiceReference1.IService1)(bindingContext, New EndpointAddress(New Uri(strFileSystemWebServiceURL)))
        Dim oProxy As ServiceReference1.IService1 = ChannelFactory.CreateChannel(New EndpointAddress(New Uri(strFileSystemWebServiceURL)))
        Dim collLU = oProxy.GetLaborUtilization("sa")
        Debug.WriteLine(collLU.Count.ToString)
    End Sub
    Public Function GetLaborUtilization(user As String) As List(Of LaborUtilization)
        Dim strFileSystemWebServiceURL As String = "http://192.168.21.128/WcfDmc/Service1.svc"
        strFileSystemWebServiceURL = "http://10.10.10.13/WcfDmc/Service1.svc"
        Dim bindingContext = New BasicHttpBinding ' BasicHttpContextBinding()
        bindingContext.MaxReceivedMessageSize = 2147483647
        bindingContext.MaxBufferSize = 2147483647
        bindingContext.ReaderQuotas.MaxDepth = 2147483647
        bindingContext.ReaderQuotas.MaxStringContentLength = 2147483647
        bindingContext.ReaderQuotas.MaxArrayLength = 2147483647
        Dim ChannelFactory As New ServiceModel.ChannelFactory(Of ServiceReference1.IService1)(bindingContext, New EndpointAddress(New Uri(strFileSystemWebServiceURL)))
        Dim oProxy As ServiceReference1.IService1 = ChannelFactory.CreateChannel(New EndpointAddress(New Uri(strFileSystemWebServiceURL)))
        Return oProxy.GetLaborUtilization(user).ToList
    End Function

End Class
