Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
    Private SQLConnectionString As String = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enviarDocCXC()
        Dispose()
    End Sub

    Public Sub conectar()
        Dim loginClient As New sfdcReference.SoapClient
        Dim result As New sfdcReference.LoginResult
        Dim loginscop As New sfdcReference.LoginScopeHeader
        Dim usuario As String
        Dim pass As String
        Dim token As String

        Dim sessionId As String
        Dim serverUrl As String

        usuario = "ebavel@idealease.com"
        pass = "password2016"
        token = "sV7mNvNLp7PX47dldn48KPXSj"
        pass = pass '+ token

        Try
            result = loginClient.login(loginscop, usuario, pass)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        sessionId = result.sessionId
        serverUrl = result.serverUrl

        MsgBox(sessionId & " " & serverUrl)

        '$urlSoap = 'https://login.salesforce.com/services/Soap/c/33.0';
        '$username = 'ebavel@idealease.com';
        '$password = 'password2016';
        '$token = ''sV7mNvNLp7PX47dldn48KPXSj’’;



    End Sub


    Public Sub enviarDocCXC()
        'Varaibles login
        Dim loginClient As New sfdcReference.SoapClient
        Dim result As New sfdcReference.LoginResult
        Dim loginscop As New sfdcReference.LoginScopeHeader
        Dim usuario As String
        Dim pass As String
        Dim token As String
        Dim sessionId As String
        Dim serverUrl As String

        'Varaibles webservice cxc
        Dim ws As New wsSFCxC.CxcWebServiceService()
        Dim cxcparm As New wsSFCxC.cxcParam()
        Dim respuestaWS As New wsSFCxC.respuestaCxc()

        'Variables internas
        SQLConnectionString = My.Settings.SQLConnectionString
        Dim dataDocCXC As SqlClient.SqlDataReader

        Try
            dataDocCXC = TraeDocPendientes()
        Catch ex As Exception
            writeLog("Error al Conectarse SQL:" & vbCrLf & ex.Message.ToString & vbCrLf)
            Exit Sub
        End Try

        '/*Login*/
        'Instrucción para omitir el error de TLS1.0
        System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls11
        usuario = My.Settings.usuario '"@.mx"
        pass = My.Settings.password '""
        token = My.Settings.token '""
        pass = pass + token

        Try
            result = loginClient.login(loginscop, usuario, pass)
        Catch ex As Exception
            writeLog("Error al Conectarse a SalesForce:" + vbCrLf + ex.Message.ToString & vbCrLf)
            Exit Sub
        End Try

        Try
            sessionId = result.sessionId
            serverUrl = result.serverUrl
        Catch ex As Exception
            writeLog("Error al asignar variables result:" + vbCrLf + ex.Message.ToString & vbCrLf)
        End Try
        'MsgBox(sessionId & " " & serverUrl)
        '/*End Login*/

        'Obtener los registros a importar
        Do While (dataDocCXC.Read())
            'Llenar datos de la estrucutura del webservice
            Try

                Dim header = New wsSFCxC.SessionHeader

                Try
                    header.sessionId = sessionId
                    ws.SessionHeaderValue = header
                Catch ex As Exception
                    writeLog("Error al asignar variables header:" + vbCrLf + ex.Message.ToString & vbCrLf)
                End Try

                Dim dt_FechaFactura, dt_FechaUltAct, dt_FechaVenc As DateTime
                Dim str_FechaFactura, str_FechaUltAct, str_FechaVenc As String

                dt_FechaFactura = dataDocCXC("Fecha_factura__c")
                dt_FechaUltAct = dataDocCXC("Fecha_Ultima_Actividad_ERP__c")
                dt_FechaVenc = dataDocCXC("Fecha_de_vencimiento__c")

                str_FechaFactura = dt_FechaFactura.ToString("yyyy-MM-dd hh:mm:ss")
                str_FechaUltAct = dt_FechaUltAct.ToString("yyyy-MM-dd hh:mm:ss")
                str_FechaVenc = dt_FechaVenc.ToString("yyyy-MM-dd hh:mm:ss")

                cxcparm.Fec_Factura = str_FechaFactura
                cxcparm.Fec_Ult_Actividad = str_FechaUltAct
                cxcparm.Fec_Vencimiento = str_FechaVenc
                'Folio de factura de CXC
                cxcparm.Folio_Factura = dataDocCXC("Folio_Factura_Ubicaci_n__c")
                'Folio de factura relacionada
                cxcparm.Folio_Factura_Ubicacion = dataDocCXC("Folio_Factura_Relaci_on__c")
                cxcparm.Moneda = dataDocCXC("Moneda__c")
                cxcparm.Monto_Total = dataDocCXC("Monto_Total__c")
                cxcparm.Monto_Total_Mxp = dataDocCXC("Monto_Total_MXP__c")
                cxcparm.No_Cliente = Trim(dataDocCXC("Num_cliente"))
                cxcparm.Saldo = dataDocCXC("Saldo__c")
                cxcparm.Saldo_Mxp = dataDocCXC("Saldo_MXP__c")
                cxcparm.Tipo_Documento = dataDocCXC("Tipo_de_Documento__c")

                MsgBox(cxcparm.Folio_Factura + " " + cxcparm.Monto_Total)
                'Try
                '    writeLog(str_FechaFactura & " " & str_FechaUltAct & " " & str_FechaVenc & " " & dataDocCXC("Folio_Factura_Ubicaci_n__c") & " " & dataDocCXC("Moneda__c") & " " & dataDocCXC("Monto_Total__c") & " " & dataDocCXC("Monto_Total_MXP__c") & " " & Trim(dataDocCXC("Num_cliente")) & " " & dataDocCXC("Saldo__c") & " " & dataDocCXC("Saldo_MXP__c") & " " & dataDocCXC("Tipo_de_Documento__c"))
                'Catch ex As Exception
                '    writeLog("Error")
                'End Try

            Catch ex As Exception
                    writeLog("Error al Llenar Datos:" & vbCrLf & ex.Message.ToString & vbCrLf)
            End Try


            Try

                respuestaWS = ws.insertCxc(cxcparm)
                UpdateDocProcesado(dataDocCXC("Id"), "1")
                writeLog("Insertado. ID: " & dataDocCXC("Id") & vbCrLf & respuestaWS.Numero.ToString() & " " & respuestaWS.Mensaje.ToString() & vbCrLf)
            Catch ex As Exception
                MsgBox(ex.Message)
                UpdateDocProcesado(dataDocCXC("Id"), "2")
                Try
                    writeLog("Error al Insertar a SalesForce ID: " & vbCrLf & respuestaWS.Numero.ToString() & " " & respuestaWS.Mensaje.ToString() & vbCrLf)

                Catch ex2 As Exception
                    MsgBox(ex2.Message)
                    writeLog("Error al Insertar a SalesForce. Error al escribir log ID: " & vbCrLf & dataDocCXC("Id") & " " & ex2.Message & vbCrLf)
                End Try
            End Try

        Loop


    End Sub

    'Obetener el numero de registros a procesar
    Private Function TraeDocPendientes() As SqlDataReader
        Dim conSQL As New SqlConnection
        Dim cmdSQL As New SqlCommand
        Dim parmSQL As New SqlParameter
        Try
            conSQL.ConnectionString = Me.SQLConnectionString
            conSQL.Open()

            cmdSQL.Connection = conSQL
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.CommandText = "XSP_GetDocSF"

            Return cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Actualizar el movimiento registrado
    Private Function UpdateDocProcesado(ByVal id As Integer, estatus As String) As SqlDataReader
        Dim conSQL As New SqlConnection
        Dim cmdSQL As New SqlCommand
        Dim parmSQL As New SqlParameter
        Try
            conSQL.ConnectionString = Me.SQLConnectionString
            conSQL.Open()

            cmdSQL.Connection = conSQL
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.CommandText = "XSP_UpdDocSF"

            parmSQL = cmdSQL.CreateParameter()
            parmSQL.ParameterName = "@Id"
            parmSQL.SqlDbType = SqlDbType.Char
            parmSQL.Direction = ParameterDirection.Input
            parmSQL.Value = id
            cmdSQL.Parameters.Add(parmSQL)

            parmSQL = cmdSQL.CreateParameter()
            parmSQL.ParameterName = "@Estatus"
            parmSQL.SqlDbType = SqlDbType.Char
            parmSQL.Direction = ParameterDirection.Input
            parmSQL.Value = estatus
            cmdSQL.Parameters.Add(parmSQL)

            Return cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub writeLog(ByVal mensaje As String)
        Dim str_archivo As String
        'str_archivo = Application.StartupPath & "\EventLog\Log.log"
        str_archivo = Application.StartupPath & "\EventLog\" & "ID.EWS.SF " & Date.Now.Month & "-" & Date.Now.Day & "-" & Date.Now.Year & " " & Date.Now.Hour & Date.Now.Minute & ".log"

        Using w As StreamWriter = File.AppendText(str_archivo)
            w.Write(mensaje)
        End Using

    End Sub
End Class
