Imports System.Runtime.InteropServices

Public Class Help

    Private Sub Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        EffectInHelp()

        lblTitulo.Text = ""
        lblUno.Text = ""
        lblDos.Text = ""
        pbContrloes.Visible = False
        Me.Opacity = 0.8

#Region "Dictaminación"

        If Formulario = "Dictaminacion" Then
            Select Case Identificador
                Case 1
                    lblTitulo.Text = "CAMARA 1"
                    lblUno.Text = "Muestra el video del evento" + vbCrLf +
                                  "seleccionado desde la camara" + vbCrLf +
                                  "de 'CARRIL', iniciando diez segundos" + vbCrLf +
                                  "antes de la hora marcada en la transacción."
                    lblDos.Text = "El video continua corriendo hasta" + vbCrLf +
                                  "que el usuario determine lo contrario" + vbCrLf +
                                  "por medio de los controles (*3)."
                Case 2
                    lblTitulo.Text = "CAMARA 2"
                    lblUno.Text = "Muestra el video del evento" + vbCrLf +
                                  "seleccionado desde la camara" + vbCrLf +
                                  "de 'CABINA', iniciando diez segundos" + vbCrLf +
                                  "antes de la hora marcada en la transacción."
                    lblDos.Text = "El video continua corriendo hasta" + vbCrLf +
                                  "que el usuario determine lo contrario" + vbCrLf +
                                  "por medio de los controles (*3)."
                Case 3
                    lblTitulo.Text = "CONTROLES"
                    lblUno.Text = "Proporcionan al usuario la" + vbCrLf +
                                  "posibilidad de manipular la" + vbCrLf +
                                  "la reproducción del video."
                    lblDos.Text = ""
                    pbContrloes.Visible = True
                Case 4
                    lblTitulo.Text = "FILTRO"
                    lblUno.Text = "Da la posibilidad al usuario" + vbCrLf +
                                  "de hacer una busqueda mas" + vbCrLf +
                                  "especifica."
                    lblDos.Text = "El usuario puede aplicar el" + vbCrLf +
                                  "filtro para agrupar la busqueda" + vbCrLf +
                                  "segun el tipo de pago, asi como" + vbCrLf +
                                  "tambien consultar discrepancias."
                Case 5
                    lblTitulo.Text = "EVENTOS"
                    lblUno.Text = "Muestra al usuario el grupo" + vbCrLf +
                                  "de eventos y/o transacciones" + vbCrLf +
                                  "resultantes de los parametros" + vbCrLf +
                                  "especificados por el mismo."
                    lblDos.Text = "Los parametros son establecidos" + vbCrLf +
                                  "el los filtros previos a este" + vbCrLf +
                                  "formulario, asi como tambien en" + vbCrLf +
                                  "el filtro contenido en este ultimo (*4)."
                Case 6
                    lblTitulo.Text = "INFORMACION DE EVENTO"
                    lblUno.Text = "Resume la información sobre" + vbCrLf +
                                  "la dictaminación de un evento" + vbCrLf +
                                  "en especifico, resultado de dar" + vbCrLf +
                                  "click o dar el foco sobre una" + vbCrLf +
                                  "de las transacciones mostradas" + vbCrLf +
                                  "en la seccion 'Eventos' (*5)"
                    lblDos.Text = ""
                Case 7
                    lblTitulo.Text = "DICTAMINACION"
                    lblUno.Text = "Módulo donde el usuario" + vbCrLf +
                                  "lleva a cabo la dictaminación" + vbCrLf +
                                  "de eventos asi como la correción" + vbCrLf +
                                  "de dictaminaciones cuando asi lo" + vbCrLf +
                                  "requiere."
                    lblDos.Text = "Los datos requeridos para llevar" + vbCrLf +
                                  "a cabo estas acciones son ingresados" + vbCrLf +
                                  "en los campos automaticamente con" + vbCrLf +
                                  "la finalidad de agilizar el proceso." + vbCrLf +
                                  "*Algunos campos NO pueden ser" + vbCrLf +
                                  "modificados por politicas de serguridad."
            End Select
        End If

#End Region

#Region "Cortes"

        If Formulario = "Cortes" Then
            Select Case Identificador
                Case 1
                    lblTitulo.Text = "CORTES"
                    lblUno.Text = "Muestra un listado de los" + vbCrLf +
                                  "cortes realizados en la plaza" + vbCrLf +
                                  "y fehca seleccioadas por el usuario"
                    lblDos.Text = "Al dar click o seleccionar un corte" + vbCrLf +
                                  "se muestra un resumen de este ultimo" + vbCrLf +
                                  "(*3)." + vbCrLf +
                                  "Al dar doble click sobre un corte" + vbCrLf +
                                  "se mostrara información mas detallada" + vbCrLf +
                                  "sobre este (*4, *5, *6, *7, *8)."
                Case 2
                    lblTitulo.Text = "FILTRO"
                    lblUno.Text = "Permite al usuario hacer una" + vbCrLf +
                                  "busqueda mas especifica sobre" + vbCrLf +
                                  " el listado de cortes."
                    lblDos.Text = "Cuenta con dos posibilidades" + vbCrLf +
                                  "de filtrado, por 'Turno' y por" + vbCrLf +
                                  "'Carril'"
                Case 3
                    lblTitulo.Text = "RESUMEN"
                    lblUno.Text = "Proporciona al usuario un" + vbCrLf +
                                  "breve resumen sobre un corte" + vbCrLf +
                                  "en especifico seleccionado" + vbCrLf +
                                  "previamente por el usuario."
                    lblDos.Text = ""
                Case 4
                    lblTitulo.Text = "NOMBRES"
                    lblUno.Text = "Enlista los nombres de " + vbCrLf +
                                  "Cajero, Encargado de Turno" + vbCrLf +
                                  "y Administrador involucrados" + vbCrLf +
                                  "en el corte seleccionado."
                    lblDos.Text = ""
                Case 5
                    lblTitulo.Text = "ENTREGADO"
                    lblUno.Text = "Detalla lo Entregado por el" + vbCrLf +
                                  "Cajero al momento del corte."
                    lblDos.Text = ""
                Case 6
                    lblTitulo.Text = "MARCADO"
                    lblUno.Text = "Detalla lo Marcado por el" + vbCrLf +
                                  "Sistema al momento del corte."
                    lblDos.Text = ""
                Case 7
                    lblTitulo.Text = "DIFERENCIA"
                    lblUno.Text = "Detalla la diferencia existente" + vbCrLf +
                                  "entre lo entregado por el cajero" + vbCrLf +
                                  "y lo marcado por el sistema."
                    lblDos.Text = ""
                Case 8
                    lblTitulo.Text = "TOTALES"
                    lblUno.Text = "Entrega un total de lo entregado," + vbCrLf +
                                  "lo marcado y el número de folios."
                    lblDos.Text = ""
            End Select
        End If

#End Region

#Region "Carriles"

        If Formulario = "Carriles" Then
            Select Case Identificador
                Case 1
                    lblTitulo.Text = "CARRILES"
                    lblUno.Text = "Muestra un listado de los" + vbCrLf +
                                  "carriles existentes en la" + vbCrLf +
                                  "plaza seleccionada previamente" + vbCrLf +
                                  "por el usuario."
                    lblDos.Text = "Al dar click o seleccionar alguno" + vbCrLf +
                                  "de los carriles se desplegara una" + vbCrLf +
                                  "lista de los eventos ocurridos en" + vbCrLf +
                                  " este (*3)."
                Case 2
                    lblTitulo.Text = "CAMBIO"
                    lblUno.Text = "Proporciona al usuario la" + vbCrLf +
                                  "opción de cambiar los parametros" + vbCrLf +
                                  "antes seleccionados para tener" + vbCrLf +
                                  "una nueva lista de carriles."
                    lblDos.Text = "Estos parametros son: Plaza y Fecha."
                Case 3
                    lblTitulo.Text = "EVENTOS"
                    lblUno.Text = "Desplega una lista de eventos" + vbCrLf +
                                  "pertenecientes al carril seleccionado" + vbCrLf +
                                  "en la lista de carriles (*1)."
                    lblDos.Text = ""
                Case 4
                    lblTitulo.Text = "INFORMACION DE EVENTO"
                    lblUno.Text = "Informa al usuario si el evento" + vbCrLf +
                                  "seleccionado ya esta dictaminado," + vbCrLf +
                                  "y de ser así muestra la hora, fecha" + vbCrLf +
                                  "y nombre del analista que realizo" + vbCrLf +
                                  "dicha dictaminación."
                    lblDos.Text = ""
                Case 5
                    lblTitulo.Text = "FILTRO"
                    lblUno.Text = "Permite al usuario hacer" + vbCrLf +
                                  "una busqueda mas especifica" + vbCrLf +
                                  "de la lista de eventos (*3)."
                    lblDos.Text = "Se puede filtrar por 'Turno' y" + vbCrLf +
                                  "'Tipo de Evento'."
            End Select
        End If

#End Region

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        EffectOutHelp()
        Me.Close()
    End Sub

End Class
