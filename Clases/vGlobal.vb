''' <summary>
''' Modulo vGlobal
''' Aqui se declaran toda
''' las varibles globales para
''' este proyecto.
''' 
''' </summary>

Module vGlobal

#Region "Login"

    Public Sub EffectIn()
        Dim Effect As Double

        For Effect = 0.0 To 1.1 Step 0.1
            RadLogin.Opacity = Effect
            RadLogin.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

    Public Sub EffectOut()
        Dim Effect As Double

        For Effect = 1.1 To 0.0 Step -0.1
            RadLogin.Opacity = Effect
            RadLogin.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

#End Region

#Region "Help"

    Public Sub EffectInHelp()
        Dim Effect As Double

        For Effect = 0.0 To 0.8 Step 0.1
            Help.Opacity = Effect
            Help.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

    Public Sub EffectOutHelp()
        Dim Effect As Double

        For Effect = 0.8 To 0.0 Step -0.1
            Help.Opacity = Effect
            Help.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

#End Region

#Region "Dictaminación"

    Public Sub EffectInDictaminacion()
        Dim Effect As Double

        For Effect = 0.0 To 1.1 Step 0.1
            Dictaminacion.Opacity = Effect
            Dictaminacion.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

    Public Sub EffectOutDictaminacion()
        Dim Effect As Double

        For Effect = 1.1 To 0.0 Step -0.3
            Dictaminacion.Opacity = Effect
            Dictaminacion.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

#End Region

#Region "Principal"

    Public Sub EffectInPrincipal()
        Dim Effect As Double

        For Effect = 0.0 To 1.1 Step 0.2
            MDIPrincipal1.Opacity = Effect
            MDIPrincipal1.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

    Public Sub EffectOutPrincipal()
        Dim Effect As Double

        For Effect = 1.1 To 0.0 Step -0.2
            MDIPrincipal1.Opacity = Effect
            MDIPrincipal1.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

#End Region

#Region "Inicio"

    Public Sub EffectInInicio()
        Dim Effect As Double

        For Effect = 0.0 To 1.1 Step 0.1
            Inicio.Opacity = Effect
            Inicio.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

    Public Sub EffectOutInicio()
        Dim Effect As Double

        For Effect = 1.1 To 0.0 Step -0.1
            Inicio.Opacity = Effect
            Inicio.Refresh()
            Threading.Thread.Sleep(20)
        Next
    End Sub

#End Region

    Public TurnoD As Integer

    '***** Guarda el numero de evento seleccionado para comentar
    Public EventoComentar As Integer
    Public IdTransaccion As Integer
    Public PlazaComentario As Integer
    Public CarrilComentario As String
    Public FechaComentario As Date

    '***** IP servidor de Video
    Public IPVideo As String = ""

    '***** Themes
    Public Theme As String = "Aqua"

    '***** Login
    Public NoEmpleado As Integer
    Public idNivel As Integer

    Public BanderaLogin As Boolean = True
    Public ID As Integer

    Public SelectVSC As Integer

    Public Video As Boolean

    Public BanderaVideo As Boolean = True

    Public plazaC As Integer
    Public fechaC As Date
    Public NomC As String

    '********** Encabezado de Reportes
    Public SeleccionReporte As Integer
    Public TituloReporte As String
    Public FechaO As Date
    Public Caseta As String
    Public TurnoL As String
    Public NumCarril As String
    Public Bolsa As String
    Public NumDeclaracion As Integer
    Public idPlazaR As Integer
    Public idTurnoR As Integer
    Public FechaOperacionR As String
    Public idCarrilR As Integer
    Public CarrilR As String
    Public FechaR As Date
    Public IdPlazaUno As Integer    '<-- Para conteo de carriles
    Public IdPlazaDos As Integer    '<-- Para conteo de carriles
    Public NombrePlaza As String

    '***** FiltroCortes
    Public idCaseta As String
    Public NomCaseta As String
    Public NumeroCaseta As Integer
    Public dato1 As Date

    '***** Lógin
    Public sesion As Boolean = False

    '***** Variables para Liquidacion
    Public NumCaseta As Integer
    Public NombreCaseta As String
    Public FechaEvento As Date
    Public idHora As Integer
    Public idCarril As String

    '***** InputBox
    Public Liquidador As Integer

    '***** Nombres de Encargado de Turno y Administrador
    Public NoNomEncargado As String
    Public NoNomAdministrador As String

    '***** Observaciones
    Public PrimeraLinea As String
    Public SegundaLinea As String
    Public TerceraLinea As String

    '***** Ayudas
    Public Formulario As String
    Public Identificador As Integer

    '***** Alertas
    Public TipoAlerta As String
    Public TituloAlerta As String
    Public MensajeAlerta1 As String
    Public MensajeAlerta2 As String
    Public Respuesta As String

#Region "Formas de Pago"

    Public NoPago As Integer = 0
    Public Efectivo As Integer = 1
    Public EfectivoCRE As Integer = 2
    Public VSC As Integer = 27
    Public Valores As Integer = 9
    Public Residente As Integer = 10
    Public TDC As Integer = 12
    Public TDD As Integer = 14
    Public IAVE As Integer = 15
    Public Violacion As Integer = 13
    Public RP1 As Integer = 71
    Public RP2 As Integer = 72
    Public RP3 As Integer = 73
    Public RSP As Integer = 74

#End Region

#Region "Clases"

    '***** Clases
    Public T01A As Integer = 1
    Public T02C As Integer = 2
    Public T03C As Integer = 3
    Public T04C As Integer = 4
    Public T05C As Integer = 5
    Public T06C As Integer = 6
    Public T07C As Integer = 7
    Public T08C As Integer = 8
    Public T09C As Integer = 9
    Public TL01A As Integer = 10   '<----- Un aunto con un eje excedente
    Public TL02A As Integer = 11   '<----- Un auto con dos ejes excedentes
    Public T02B As Integer = 12
    Public T03B As Integer = 13
    Public T04B As Integer = 14
    Public T01M As Integer = 15
    Public T09PnnC As Integer = 16   '<----- Camion con "n" ejes excedentes
    Public T01LnnA As Integer = 17   '<----- Auto con "n" ejes excedentes
    Public T01T As Integer = 18
    Public T01P As Integer = 19

#End Region

#Region "Secuencias"

    Public Reclasificados As String = "F"

#End Region

#Region "Paso"

    Public Discrepancias As String = "6"

#End Region

#Region "Inserción de eventos"

    Public ie_NoEvento As Integer
    Public ie_Fecha As Date
    Public ie_Hora As TimeSpan
    Public ie_Folio As Integer
    Public ie_NoCajero As Integer
    Public ie_ClaseECT As String
    Public ie_ClaseCR As String
    Public ie_FormaPago As String

#End Region

#Region "Verificacion de cortes"

    Public NumeroPlaza As Integer = 0

#End Region

#Region "Carriles Cerrados"

    Public CC_Fecha As Date
    Public CC_Turno As Integer

#End Region

End Module
