﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
'
Namespace wsSFCxC
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="CxcWebServiceBinding", [Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService")>  _
    Partial Public Class CxcWebServiceService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private sessionHeaderValueField As SessionHeader
        
        Private callOptionsValueField As CallOptions
        
        Private debuggingHeaderValueField As DebuggingHeader
        
        Private allowFieldTruncationHeaderValueField As AllowFieldTruncationHeader
        
        Private debuggingInfoValueField As DebuggingInfo
        
        Private insertCxcOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.IDEWSSF.My.MySettings.Default.IDEWSSF_wsSFCxC_CxcWebServiceService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Property SessionHeaderValue() As SessionHeader
            Get
                Return Me.sessionHeaderValueField
            End Get
            Set
                Me.sessionHeaderValueField = value
            End Set
        End Property
        
        Public Property CallOptionsValue() As CallOptions
            Get
                Return Me.callOptionsValueField
            End Get
            Set
                Me.callOptionsValueField = value
            End Set
        End Property
        
        Public Property DebuggingHeaderValue() As DebuggingHeader
            Get
                Return Me.debuggingHeaderValueField
            End Get
            Set
                Me.debuggingHeaderValueField = value
            End Set
        End Property
        
        Public Property AllowFieldTruncationHeaderValue() As AllowFieldTruncationHeader
            Get
                Return Me.allowFieldTruncationHeaderValueField
            End Get
            Set
                Me.allowFieldTruncationHeaderValueField = value
            End Set
        End Property
        
        Public Property DebuggingInfoValue() As DebuggingInfo
            Get
                Return Me.debuggingInfoValueField
            End Get
            Set
                Me.debuggingInfoValueField = value
            End Set
        End Property
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event insertCxcCompleted As insertCxcCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("CallOptionsValue"),  _
         System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingInfoValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.Out),  _
         System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeaderValue"),  _
         System.Web.Services.Protocols.SoapHeaderAttribute("AllowFieldTruncationHeaderValue"),  _
         System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingHeaderValue"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://soap.sforce.com/schemas/class/CxcWebService", ResponseNamespace:="http://soap.sforce.com/schemas/class/CxcWebService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function insertCxc(<System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)> ByVal vCxc As cxcParam) As <System.Xml.Serialization.XmlElementAttribute("result", IsNullable:=true)> respuestaCxc
            Dim results() As Object = Me.Invoke("insertCxc", New Object() {vCxc})
            Return CType(results(0),respuestaCxc)
        End Function
        
        '''<remarks/>
        Public Overloads Sub insertCxcAsync(ByVal vCxc As cxcParam)
            Me.insertCxcAsync(vCxc, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub insertCxcAsync(ByVal vCxc As cxcParam, ByVal userState As Object)
            If (Me.insertCxcOperationCompleted Is Nothing) Then
                Me.insertCxcOperationCompleted = AddressOf Me.OninsertCxcOperationCompleted
            End If
            Me.InvokeAsync("insertCxc", New Object() {vCxc}, Me.insertCxcOperationCompleted, userState)
        End Sub
        
        Private Sub OninsertCxcOperationCompleted(ByVal arg As Object)
            If (Not (Me.insertCxcCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent insertCxcCompleted(Me, New insertCxcCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService", IsNullable:=false)>  _
    Partial Public Class CallOptions
        Inherits System.Web.Services.Protocols.SoapHeader
        
        Private clientField As String
        
        '''<comentarios/>
        Public Property client() As String
            Get
                Return Me.clientField
            End Get
            Set
                Me.clientField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService")>  _
    Partial Public Class respuestaCxc
        
        Private mensajeField As String
        
        Private numeroField As String
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Mensaje() As String
            Get
                Return Me.mensajeField
            End Get
            Set
                Me.mensajeField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Numero() As String
            Get
                Return Me.numeroField
            End Get
            Set
                Me.numeroField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService")>  _
    Partial Public Class cxcParam
        
        Private fec_FacturaField As String
        
        Private fec_Ult_ActividadField As String
        
        Private fec_VencimientoField As String
        
        Private folio_FacturaField As String
        
        Private folio_Factura_UbicacionField As String
        
        Private monedaField As String
        
        Private monto_TotalField As String
        
        Private monto_Total_MxpField As String
        
        Private no_ClienteField As String
        
        Private saldoField As String
        
        Private saldo_MxpField As String
        
        Private tipo_DocumentoField As String
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Fec_Factura() As String
            Get
                Return Me.fec_FacturaField
            End Get
            Set
                Me.fec_FacturaField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Fec_Ult_Actividad() As String
            Get
                Return Me.fec_Ult_ActividadField
            End Get
            Set
                Me.fec_Ult_ActividadField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Fec_Vencimiento() As String
            Get
                Return Me.fec_VencimientoField
            End Get
            Set
                Me.fec_VencimientoField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Folio_Factura() As String
            Get
                Return Me.folio_FacturaField
            End Get
            Set
                Me.folio_FacturaField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Folio_Factura_Ubicacion() As String
            Get
                Return Me.folio_Factura_UbicacionField
            End Get
            Set
                Me.folio_Factura_UbicacionField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Moneda() As String
            Get
                Return Me.monedaField
            End Get
            Set
                Me.monedaField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Monto_Total() As String
            Get
                Return Me.monto_TotalField
            End Get
            Set
                Me.monto_TotalField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Monto_Total_Mxp() As String
            Get
                Return Me.monto_Total_MxpField
            End Get
            Set
                Me.monto_Total_MxpField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property No_Cliente() As String
            Get
                Return Me.no_ClienteField
            End Get
            Set
                Me.no_ClienteField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Saldo() As String
            Get
                Return Me.saldoField
            End Get
            Set
                Me.saldoField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Saldo_Mxp() As String
            Get
                Return Me.saldo_MxpField
            End Get
            Set
                Me.saldo_MxpField = value
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Tipo_Documento() As String
            Get
                Return Me.tipo_DocumentoField
            End Get
            Set
                Me.tipo_DocumentoField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService")>  _
    Partial Public Class LogInfo
        
        Private categoryField As LogCategory
        
        Private levelField As LogCategoryLevel
        
        '''<comentarios/>
        Public Property category() As LogCategory
            Get
                Return Me.categoryField
            End Get
            Set
                Me.categoryField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property level() As LogCategoryLevel
            Get
                Return Me.levelField
            End Get
            Set
                Me.levelField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService")>  _
    Public Enum LogCategory
        
        '''<comentarios/>
        Db
        
        '''<comentarios/>
        Workflow
        
        '''<comentarios/>
        Validation
        
        '''<comentarios/>
        Callout
        
        '''<comentarios/>
        Apex_code
        
        '''<comentarios/>
        Apex_profiling
        
        '''<comentarios/>
        Visualforce
        
        '''<comentarios/>
        System
        
        '''<comentarios/>
        Wave
        
        '''<comentarios/>
        All
    End Enum
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService")>  _
    Public Enum LogCategoryLevel
        
        '''<comentarios/>
        None
        
        '''<comentarios/>
        Finest
        
        '''<comentarios/>
        Finer
        
        '''<comentarios/>
        Fine
        
        '''<comentarios/>
        Debug
        
        '''<comentarios/>
        Info
        
        '''<comentarios/>
        Warn
        
        '''<comentarios/>
        [Error]
    End Enum
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService", IsNullable:=false)>  _
    Partial Public Class DebuggingInfo
        Inherits System.Web.Services.Protocols.SoapHeader
        
        Private debugLogField As String
        
        '''<comentarios/>
        Public Property debugLog() As String
            Get
                Return Me.debugLogField
            End Get
            Set
                Me.debugLogField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService", IsNullable:=false)>  _
    Partial Public Class SessionHeader
        Inherits System.Web.Services.Protocols.SoapHeader
        
        Private sessionIdField As String
        
        '''<comentarios/>
        Public Property sessionId() As String
            Get
                Return Me.sessionIdField
            End Get
            Set
                Me.sessionIdField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService", IsNullable:=false)>  _
    Partial Public Class AllowFieldTruncationHeader
        Inherits System.Web.Services.Protocols.SoapHeader
        
        Private allowFieldTruncationField As Boolean
        
        '''<comentarios/>
        Public Property allowFieldTruncation() As Boolean
            Get
                Return Me.allowFieldTruncationField
            End Get
            Set
                Me.allowFieldTruncationField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService", IsNullable:=false)>  _
    Partial Public Class DebuggingHeader
        Inherits System.Web.Services.Protocols.SoapHeader
        
        Private categoriesField() As LogInfo
        
        Private debugLevelField As LogType
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute("categories")>  _
        Public Property categories() As LogInfo()
            Get
                Return Me.categoriesField
            End Get
            Set
                Me.categoriesField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property debugLevel() As LogType
            Get
                Return Me.debugLevelField
            End Get
            Set
                Me.debugLevelField = value
            End Set
        End Property
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0"),  _
     System.SerializableAttribute(),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://soap.sforce.com/schemas/class/CxcWebService")>  _
    Public Enum LogType
        
        '''<comentarios/>
        None
        
        '''<comentarios/>
        Debugonly
        
        '''<comentarios/>
        Db
        
        '''<comentarios/>
        Profiling
        
        '''<comentarios/>
        Callout
        
        '''<comentarios/>
        Detail
    End Enum
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub insertCxcCompletedEventHandler(ByVal sender As Object, ByVal e As insertCxcCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class insertCxcCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As respuestaCxc
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),respuestaCxc)
            End Get
        End Property
    End Class
End Namespace
