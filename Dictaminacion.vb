Imports AxIPNRMSControlLib
Imports Telerik.WinControls

''' <summary>
''' Formulario Dictaminacion
''' Se muestran los datos para lleva 
''' a cabo la liquidación, con y sin video
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @28/03/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>

Public Class Dictaminacion

#Region "Variables"

    Dim Normal As Integer = 1
    Dim Tarjeta As Integer = 2
    Dim TarjetaC As Integer = 12
    Dim TarjetaD As Integer = 14
    Dim IAVE As Integer = 15
    Dim Residente As Integer = 4
    Dim VSC As Integer = 27
    Dim Eludido As Integer = 13

    Public iav As Integer = 0
    Public vs As Integer = 0
    Public dis As Integer = 0
    Public elu As Integer = 0
    Public nor As Integer = 0
    Public tarj As Integer = 0
    Public tarjC As Integer = 0
    Public tarjD As Integer = 0
    Public resi As Integer = 0
    Public todos As Integer = 0

    Dim bandera As Boolean = True
    Dim bandera1 As Boolean = True
    Dim bandera2 As Boolean = True
    Dim bandera3 As Boolean = True
    Dim bandera4 As Boolean = True
    Dim bandera5 As Boolean = True
    Dim bandera6 As Boolean = True
    Dim bandera7 As Boolean = True

    Dim ClaseV As Integer
    Dim TipoP As Integer

    Dim mas As Integer = 1
    Dim menos As Integer = -1
    Dim FrameXsegundo As Integer = 7
    Dim contador As String = 1
    Dim valor1 As Integer
    Dim valor2 As Integer

    Dim NumTransaccion As Integer
    Dim count As Integer = 0
    Dim NumEvento As Integer

    Dim operacion As Integer

    Dim Uno As Integer
    Dim Dos As Integer

    '***** Nombre de camaras
    Dim CamaraCarril As String
    Dim CamaraCabina As String

    '****
    Dim Num_Evento As Integer

#End Region

    Dim ListaEventos As New ListBox
    Dim ListaClases As New ListBox
    Dim ListaPagos As New ListBox

    Public Sub New()

        InitializeComponent()

		With AxRMSInfo1
			.RemoteHost = IPVideo
			.RemotePort = 900
            .RemotePwd = "1234"
        End With

		With AxRecViewer2
			.RemoteHost = IPVideo
			.RemotePort = 900
            .RemotePwd = "1234"
        End With

		With AxRMSInfo2
			.RemoteHost = IPVideo
            .RemotePort = 900
            .RemotePwd = "1234"
        End With

		With rvFoto
			.RemoteHost = IPVideo
			.RemotePort = 900
            .RemotePwd = "1234"
        End With

		With rvCabina
			.RemoteHost = IPVideo
			.RemotePort = 900
            .RemotePwd = "1234"
        End With

	End Sub

    Private Sub Dictaminacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LiquidacionAutomatica()

        pbFondo.SendToBack()

        RadMessageBox.SetThemeName(Theme)
        btnComentar.Enabled = False

        Formulario = "Dictaminacion"

        EffectInDictaminacion()


        txtNoEmpleado.Text = NoEmpleado.ToString()
        txtNoEmpleado.IsReadOnly = True
        lblInformacion.Text = NombreCaseta + " - " + FechaEvento

        CargarClases()
        CargarPagos()
        DesactivarControles()

#Region "Members"

        pbPlay2.Visible = False
        pbPlay2.Visible = False
        pbStop2.Visible = False
        pbPause2.Visible = False
        pbRegresar2.Visible = False
        pbAdelantar2.Visible = False
        txtNoEvento.IsReadOnly = True
        txtNoEvento.Enabled = False
        dgvEventos.ReadOnly = True
        dgvLiquidacion.ReadOnly = True
        lblNoEjes.Visible = False
        txtNoejes.Visible = False
        CargarPredefinidos()
        DesactivarLiquidacion()

#End Region

        If BanderaVideo = False Then
            ActivarVistaSinVideo()
            rvCabina.BringToFront()
        Else
            ActivarVistaConVideo()
        End If

#Region "ToolTip"

        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.AutoPopDelay = 2000

        Me.ToolTip1.SetToolTip(txtBuscar, "Ingrese un Número de Evento")
        Me.ToolTip1.SetToolTip(pbPlay, "Play")
        Me.ToolTip1.SetToolTip(pbPause, "Pause")
        Me.ToolTip1.SetToolTip(pbStop, "Stop")
        Me.ToolTip1.SetToolTip(pbAdelantar, "Adelantar")
        Me.ToolTip1.SetToolTip(pbRegresar, "Regresar")
        Me.ToolTip1.SetToolTip(pbPlay2, "Play")
        Me.ToolTip1.SetToolTip(pbPause2, "Pause")
        Me.ToolTip1.SetToolTip(pbStop2, "Stop")
        Me.ToolTip1.SetToolTip(pbAdelantar2, "Adelantar")
        Me.ToolTip1.SetToolTip(pbRegresar2, "Regresar")

#End Region

    End Sub

#Region "Methods"

    Private Sub LiquidacionAutomatica()

        Dim ctx As New CLRDataContext()
        Dim num As Integer
        Dim num2 As Integer
        Dim numeroevento
        Dim Hora1 As New TimeSpan(20, 0, 0)
        Dim Hora2 As New TimeSpan(8, 0, 0)

        'Se limpian las listas
        ListaEventos.Items.Clear()
        ListaClases.Items.Clear()
        ListaPagos.Items.Clear()

        Try

			'Se trae el numero de la ultima Dictaminación
			Dim ultDic = (From u In ctx.Dictaminaciones
						  Select u.idDictaminacion).Max()

			num = ultDic + 1
            num2 = ultDic + 1

            If TurnoD = 1 Then
                numeroevento = From t In ctx.Transacciones
                               Where t.NoPlaza = NumCaseta And t.idTurno = TurnoD And t.NoCarrilCapufe = idCarril And ((t.Fecha = FechaEvento.AddDays(-1) And t.Hora > Hora1) Or (t.Fecha = FechaEvento And t.Hora < Hora2)) And (t.Dictaminado = False Or t.Dictaminado Is Nothing) And (t.idPago = 1 Or t.idPago = 12 Or t.idPago = 14)
                               Select t
            Else
                numeroevento = From t In ctx.Transacciones
                               Where t.NoPlaza = NumCaseta And t.idTurno = TurnoD And t.NoCarrilCapufe = idCarril And t.Fecha = FechaEvento And (t.Dictaminado = False Or t.Dictaminado Is Nothing) And (t.idPago = 1 Or t.idPago = 12 Or t.idPago = 14)
                               Select t
            End If

            'Se llenan las listas
            For Each c In numeroevento
                ListaEventos.Items.Add(c.NoEvento)
                ListaClases.Items.Add(c.idVehiculo)
                ListaPagos.Items.Add(c.idPago)
            Next

            Dim count As Integer = ListaEventos.Items.Count()

            'Modificaciones a la tabla Transacciones
            For Each eventos As Transacciones In numeroevento

                eventos.idDictaminacion = num2
                eventos.Dictaminado = True

                num2 = num2 + 1

            Next

            ctx.SubmitChanges()

            'Inserción a la tabla Dictaminaciones
            For index As Integer = 0 To ListaEventos.Items.Count() - 1

                Num_Evento = ListaEventos.Items(index)
                InsertarDictamen(num, index)
                num = num + 1

            Next

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub LiquidarTodos()

        Dim ctx As New CLRDataContext()
        Dim num As Integer
        Dim num2 As Integer
        Dim numeroevento
        Dim Hora1 As New TimeSpan(20, 0, 0)
        Dim Hora2 As New TimeSpan(8, 0, 0)

        'Se limpian las listas
        ListaEventos.Items.Clear()
        ListaClases.Items.Clear()
        ListaPagos.Items.Clear()

        Try

            'Se trae el numero de la ultima Dictaminación
            Dim ultDic = (From u In ctx.Dictaminaciones
                          Select u.idDictaminacion).Max()

            num = ultDic + 1
            num2 = ultDic + 1

            If TurnoD = 1 Then
                numeroevento = From t In ctx.Transacciones
                               Where t.NoPlaza = NumCaseta And t.idTurno = TurnoD And t.NoCarrilCapufe = idCarril And ((t.Fecha = FechaEvento.AddDays(-1) And t.Hora > Hora1) Or (t.Fecha = FechaEvento And t.Hora < Hora2)) And (t.Dictaminado = False Or t.Dictaminado Is Nothing)
                               Select t
            Else
                numeroevento = From t In ctx.Transacciones
                               Where t.NoPlaza = NumCaseta And t.idTurno = TurnoD And t.NoCarrilCapufe = idCarril And t.Fecha = FechaEvento And (t.Dictaminado = False Or t.Dictaminado Is Nothing)
                               Select t
            End If

            'Se llenan las listas
            For Each c In numeroevento
                ListaEventos.Items.Add(c.NoEvento)
                ListaClases.Items.Add(c.idVehiculo)
                ListaPagos.Items.Add(c.idPago)
            Next

            Dim count As Integer = ListaEventos.Items.Count()

            'Modificaciones a la tabla Transacciones
            For Each eventos As Transacciones In numeroevento

                eventos.idDictaminacion = num2
                eventos.Dictaminado = True

                num2 = num2 + 1

            Next

            ctx.SubmitChanges()

            'Inserción a la tabla Dictaminaciones
            For index As Integer = 0 To ListaEventos.Items.Count() - 1

                Num_Evento = ListaEventos.Items(index)
                InsertarDictamen(num, index)
                num = num + 1

            Next

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub InsertarDictamen(id As Integer, Index As Integer)

        Dim ctx As New CLRDataContext()

        Dim liquidacion As New Dictaminaciones()

        liquidacion.idDictaminacion = id
        liquidacion.NoTransaccion = ListaEventos.Items(Index)
        liquidacion.NoEmpleadoCapufe = NoEmpleado
        liquidacion.Fecha = Date.Now.Date()
        liquidacion.Hora = Date.Now.TimeOfDay()
        liquidacion.idVehiculo = ListaClases.Items(Index)
        liquidacion.idPago = ListaPagos.Items(Index)
        liquidacion.NuevaTarifa = NewTarif(ListaClases.Items(Index), Num_Evento)

        ctx.Dictaminaciones.InsertOnSubmit(liquidacion)
        ctx.SubmitChanges()

    End Sub

    Private Function NewTarif(Clase As Integer, Evento As Integer)

        Dim ctx As New CLRDataContext()
        Dim Hora1 As New TimeSpan(20, 0, 0)
        Dim Hora2 As New TimeSpan(8, 0, 0)
        Dim tarif

        Select Case Clase

            Case 10

                tarif = (From t In ctx.Tarifas
                         Where t.NoPlaza = NumCaseta And t.idVehiculo = 17  '<--- Tarifa del eje excedente
                         Select t.Tarifa).SingleOrDefault()

                Dim auto = (From a In ctx.Tarifas
                            Where a.NoPlaza = NumCaseta And a.idVehiculo = 1    '<--- Tarifa del auto normal
                            Select a.Tarifa).SingleOrDefault()

                tarif = tarif + auto

            Case 11

                tarif = (From t In ctx.Tarifas
                         Where t.NoPlaza = NumCaseta And t.idVehiculo = 17  '<--- Tarifa del eje excedente auto
                         Select t.Tarifa).SingleOrDefault()

                Dim auto = (From a In ctx.Tarifas
                            Where a.NoPlaza = NumCaseta And a.idVehiculo = 1    '<--- Tarifa del auto normal
                            Select a.Tarifa).SingleOrDefault()

                tarif = auto + (tarif * 2)

            Case 16

                tarif = (From t In ctx.Tarifas
                         Where t.NoPlaza = NumCaseta And t.idVehiculo = 16  '<--- Tarifa del eje excedente camion
                         Select t.Tarifa).SingleOrDefault()

                Dim camion = (From a In ctx.Tarifas
                              Where a.NoPlaza = NumCaseta And a.idVehiculo = 9    '<--- Tarifa del camion con nueve ejes
                              Select a.Tarifa).SingleOrDefault()

                Dim ejes

                If TurnoD = 1 Then
                    ejes = (From e In ctx.Transacciones
                            Where e.NoEvento = Num_Evento And e.NoPlaza = NumCaseta And e.idTurno = TurnoD And e.NoCarrilCapufe = idCarril And ((e.Fecha = FechaEvento.AddDays(-1) And e.Hora > Hora1) Or (e.Fecha = FechaEvento And e.Hora < Hora2))
                            Select e.Num_Ejes).SingleOrDefault()
                Else
                    ejes = (From e In ctx.Transacciones
                            Where e.NoEvento = Num_Evento And e.NoPlaza = NumCaseta And e.idTurno = TurnoD And e.NoCarrilCapufe = idCarril And e.Fecha = FechaEvento
                            Select e.Num_Ejes).SingleOrDefault()
                End If

                tarif = camion + (ejes * tarif)

            Case 17

                tarif = (From t In ctx.Tarifas
                         Where t.NoPlaza = NumCaseta And t.idVehiculo = 17  '<--- Tarifa del eje excedente auto
                         Select t.Tarifa).SingleOrDefault()

                Dim auto = (From a In ctx.Tarifas
                            Where a.NoPlaza = NumCaseta And a.idVehiculo = 1    '<--- Tarifa del camion con nueve ejes
                            Select a.Tarifa).SingleOrDefault()

                Dim ejes

                If TurnoD = 1 Then
                    ejes = (From e In ctx.Transacciones
                            Where e.NoEvento = Num_Evento And e.NoPlaza = NumCaseta And e.idTurno = TurnoD And e.NoCarrilCapufe = idCarril And ((e.Fecha = FechaEvento.AddDays(-1) And e.Hora > Hora1) Or (e.Fecha = FechaEvento And e.Hora < Hora2))
                            Select e.Num_Ejes).SingleOrDefault()
                Else
                    ejes = (From e In ctx.Transacciones
                            Where e.NoEvento = Num_Evento And e.NoPlaza = NumCaseta And e.idTurno = TurnoD And e.NoCarrilCapufe = idCarril And e.Fecha = FechaEvento
                            Select e.Num_Ejes).SingleOrDefault()
                End If

                tarif = auto + (ejes * tarif)

            Case Else

                tarif = (From t In ctx.Tarifas
                         Where t.NoPlaza = NumCaseta And t.idVehiculo = Clase
                         Select t.Tarifa).SingleOrDefault()

        End Select

        Return tarif

    End Function

    Private Sub ActivarVistaConVideo()

        AxRecViewer2.Visible = False
        rvFoto.Visible = True
        rvCabina.Visible = True
        Barra.Visible = True
        gpbControles.Visible = True
        lblCronometro.Visible = True

    End Sub

    Private Sub ActivarVistaSinVideo()

        AxRecViewer2.Visible = False
        rvCabina.Visible = False
        Barra.Visible = False
        gpbControles.Visible = False
        lblCronometro.Visible = False

    End Sub

    Private Sub AjusteColumnas()

        dgvEventos.Columns(0).Width = 65
        dgvEventos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(1).Width = 65
        dgvEventos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(2).Width = 70
        dgvEventos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(3).Width = 50
        dgvEventos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(4).Width = 80
        dgvEventos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(5).IsVisible = False
        dgvEventos.Columns(6).Width = 80
        dgvEventos.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(7).Width = 55
        dgvEventos.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(8).Width = 65
        dgvEventos.Columns(8).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(9).Width = 110
        dgvEventos.Columns(9).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(10).Width = 55
        dgvEventos.Columns(10).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(11).Width = 70
        dgvEventos.Columns(11).TextAlignment = ContentAlignment.MiddleCenter
        dgvEventos.Columns(12).IsVisible = False
        dgvEventos.Columns(13).IsVisible = False
        dgvEventos.Columns(14).IsVisible = False
        dgvEventos.Columns(15).IsVisible = False

    End Sub

    Private Sub CargarTodos()

        Dim ctx As New CLRDataContext

        Dim Hora1 As New TimeSpan(20, 0, 0)
        Dim Hora2 As New TimeSpan(8, 0, 0)

        If idHora = 1 Then
            Dim eventos = From pre In ctx.Transacciones
                          Join tp In ctx.TipoPago
                                   On pre.idPago Equals tp.idPago
                          Join tv In ctx.TipoVehiculo
                                   On pre.idVehiculo Equals tv.idVehiculo
                          Join t In ctx.Turnos
                                   On pre.idTurno Equals t.idTurno
                          Where ((pre.Fecha = FechaEvento.AddDays(-1) And pre.Hora > Hora1) Or (pre.Fecha = FechaEvento And pre.Hora < Hora2)) And pre.NoPlaza = NumCaseta And pre.NoCarrilCapufe = idCarril And pre.idTurno = idHora
                          Order By pre.Hora Descending
                          Select
                               Evento = pre.NoEvento,
                               Hora = pre.Hora,
                               Turno = t.Turno,
                               Carril = pre.NoCarrilCapufe,
                               Empleado = pre.NoEmpleadoCapufe,
                               Folio = pre.Folio,
                               PRE = tv.Clase,
                               POST = tv.Clase,
                               ClaseCR = tv.Clase,
                               Pago = tp.NomPago,
                               Tarifa = Format(pre.idTarifa, "###0.00"),
                               Liquidado = pre.Dictaminado,
                               Fecha = Format(pre.Fecha, "dd/MM/yyyy"),
                               Plaza = pre.NoPlaza,
                               NumLiquidacion = pre.idDictaminacion,
                               ID = pre.idTransaccion,
                               Anulado = pre.Anulado

            dgvEventos.DataSource = eventos.ToList()
            AjusteColumnas()
        Else
            Dim eventos = From pre In ctx.Transacciones
                          Join tp In ctx.TipoPago
                                   On pre.idPago Equals tp.idPago
                          Join tv In ctx.TipoVehiculo
                                   On pre.idVehiculo Equals tv.idVehiculo
                          Join t In ctx.Turnos
                                   On pre.idTurno Equals t.idTurno
                          Where pre.Fecha = FechaEvento And pre.NoPlaza = NumCaseta And pre.NoCarrilCapufe = idCarril And pre.idTurno = idHora
                          Order By pre.Hora Descending
                          Select
                               Evento = pre.NoEvento,
                               Hora = pre.Hora,
                               Turno = t.Turno,
                               Carril = pre.NoCarrilCapufe,
                               Empleado = pre.NoEmpleadoCapufe,
                               Folio = pre.Folio,
                               PRE = tv.Clase,
                               POST = tv.Clase,
                               ClaseCR = tv.Clase,
                               Pago = tp.NomPago,
                               Tarifa = Format(pre.idTarifa, "###0.00"),
                               Liquidado = pre.Dictaminado,
                               Fecha = Format(pre.Fecha, "dd/MM/yyyy"),
                               Plaza = pre.NoPlaza,
                               NumLiquidacion = pre.idDictaminacion,
                               ID = pre.idTransaccion,
                               Anulado = pre.Anulado

            dgvEventos.DataSource = eventos.ToList()
            AjusteColumnas()
        End If

    End Sub

    Private Sub CargarPredefinidos()

        Dim ctx As New CLRDataContext

        Dim Hora1 As New TimeSpan(20, 0, 0)
        Dim Hora2 As New TimeSpan(8, 0, 0)

        If idHora = 1 Then
            Dim preDefinidos = From pre In ctx.Transacciones
                               Join tp In ctx.TipoPago
                                   On pre.idPago Equals tp.idPago
                               Join tv In ctx.TipoVehiculo
                                   On pre.idVehiculo Equals tv.idVehiculo
                               Join t In ctx.Turnos
                                   On pre.idTurno Equals t.idTurno
                               Where ((pre.Fecha = FechaEvento.AddDays(-1) And pre.Hora > Hora1) Or (pre.Fecha = FechaEvento And pre.Hora < Hora2)) And pre.NoPlaza = NumCaseta And pre.NoCarrilCapufe = idCarril And pre.idTurno = idHora And pre.idPago <> 1 And pre.idPago <> 12 And pre.idPago <> 14 'And (tp.idPago = IAVE Or tp.idPago = Residente Or tp.idPago = VSC Or tp.idPago = Eludido)
                               Order By pre.Hora Descending
                               Select
                                     Evento = pre.NoEvento,
                                     Hora = pre.Hora,
                                     Turno = t.Turno,
                                     Carril = pre.NoCarrilCapufe,
                                     Empleado = pre.NoEmpleadoCapufe,
                                     Folio = pre.Folio,
                                     PRE = tv.Clase,
                                     POST = tv.Clase,
                                     ClaseCR = tv.Clase,
                                     Pago = tp.NomPago,
                                     Tarifa = Format(pre.idTarifa, "###0.00"),
                                     Liquidado = pre.Dictaminado,
                                     Fecha = Format(pre.Fecha, "dd/MM/yyyy"),
                                     Plaza = pre.NoPlaza,
                                     NumLiquidacion = pre.idDictaminacion,
                                     ID = pre.idTransaccion,
                                     Anulado = pre.Anulado

            dgvEventos.DataSource = preDefinidos.ToList()
            AjusteColumnas()
        Else
            Dim preDefinidos = From pre In ctx.Transacciones
                               Join tp In ctx.TipoPago
                                   On pre.idPago Equals tp.idPago
                               Join tv In ctx.TipoVehiculo
                                   On pre.idVehiculo Equals tv.idVehiculo
                               Join t In ctx.Turnos
                                   On pre.idTurno Equals t.idTurno
                               Where pre.Fecha = FechaEvento And pre.NoPlaza = NumCaseta And pre.NoCarrilCapufe = idCarril And pre.idTurno = idHora And pre.idPago <> 1 And pre.idPago <> 12 And pre.idPago <> 14 'And (tp.idPago = IAVE Or tp.idPago = Residente Or tp.idPago = VSC Or tp.idPago = Eludido)
                               Order By pre.Hora Descending
                               Select
                                     Evento = pre.NoEvento,
                                     Hora = pre.Hora,
                                     Turno = t.Turno,
                                     Carril = pre.NoCarrilCapufe,
                                     Empleado = pre.NoEmpleadoCapufe,
                                     Folio = pre.Folio,
                                     PRE = tv.Clase,
                                     POST = tv.Clase,
                                     ClaseCR = tv.Clase,
                                     Pago = tp.NomPago,
                                     Tarifa = Format(pre.idTarifa, "###0.00"),
                                     Liquidado = pre.Dictaminado,
                                     Fecha = Format(pre.Fecha, "dd/MM/yyyy"),
                                     Plaza = pre.NoPlaza,
                                     NumLiquidacion = pre.idDictaminacion,
                                     ID = pre.idTransaccion,
                                     Anulado = pre.Anulado

            dgvEventos.DataSource = preDefinidos.ToList()
            AjusteColumnas()
        End If

    End Sub

    Public Sub CargarSeleccion()

        rvCabina.StopPlay()
        rvCabina.Visible = False
        rvFoto.Visible = True

        Dim ctx As New CLRDataContext
        Dim Hora1 As New TimeSpan(20, 0, 0)
        Dim Hora2 As New TimeSpan(8, 0, 0)

        If idHora = 1 Then

            Dim seleccion = From i In ctx.Transacciones
                            Join tp In ctx.TipoPago
                                       On i.idPago Equals tp.idPago
                            Join tv In ctx.TipoVehiculo
                                       On i.idVehiculo Equals tv.idVehiculo
                            Join t In ctx.Turnos
                                       On i.idTurno Equals t.idTurno
                            Where ((i.Fecha = FechaEvento.AddDays(-1) And i.Hora > Hora1) Or (i.Fecha = FechaEvento And i.Hora < Hora2)) And i.NoPlaza = NumCaseta And i.idTurno = idHora And i.NoCarrilCapufe = idCarril And (i.idPago = iav Or i.idPago = vs Or i.idPago = resi Or i.idPago = elu Or i.idPago = nor Or i.idPago = tarjC Or i.idPago = tarjD)
                            Order By i.NoEvento
                            Select
                                   Evento = i.NoEvento,
                                   Hora = i.Hora,
                                   Turno = t.Turno,
                                   Carril = i.NoCarrilCapufe,
                                   Empleado = i.NoEmpleadoCapufe,
                                   Folio = i.Folio,
                                   PRE = tv.Clase,
                                   POST = tv.Clase,
                                   ClaseCR = tv.Clase,
                                   Pago = tp.NomPago,
                                   Tarifa = Format(i.idTarifa, "###0.00"),
                                   Liquidado = i.Dictaminado,
                                   Fecha = Format(i.Fecha, "dd/MM/yyyy"),
                                   Plaza = i.NoPlaza,
                                   NumLiquidacion = i.idDictaminacion,
                                   ID = i.idTransaccion,
                                   Anulado = i.Anulado

            dgvEventos.DataSource = seleccion.ToList()
            AjusteColumnas()

        Else

            Dim seleccion = From i In ctx.Transacciones
                            Join tp In ctx.TipoPago
                                       On i.idPago Equals tp.idPago
                            Join tv In ctx.TipoVehiculo
                                       On i.idVehiculo Equals tv.idVehiculo
                            Join t In ctx.Turnos
                                       On i.idTurno Equals t.idTurno
                            Where i.Fecha = FechaEvento And i.NoPlaza = NumCaseta And i.idTurno = idHora And i.NoCarrilCapufe = idCarril And (i.idPago = iav Or i.idPago = vs Or i.idPago = resi Or i.idPago = elu Or i.idPago = nor Or i.idPago = tarjC Or i.idPago = tarjD)
                            Order By i.NoEvento
                            Select
                                   Evento = i.NoEvento,
                                   Hora = i.Hora,
                                   Turno = t.Turno,
                                   Carril = i.NoCarrilCapufe,
                                   Empleado = i.NoEmpleadoCapufe,
                                   Folio = i.Folio,
                                   PRE = tv.Clase,
                                   POST = tv.Clase,
                                   ClaseCR = tv.Clase,
                                   Pago = tp.NomPago,
                                   Tarifa = Format(i.idTarifa, "###0.00"),
                                   Liquidado = i.Dictaminado,
                                   Fecha = Format(i.Fecha, "dd/MM/yyyy"),
                                   Plaza = i.NoPlaza,
                                   NumLiquidacion = i.idDictaminacion,
                                   ID = i.idTransaccion,
                                   Anulado = i.Anulado


            dgvEventos.DataSource = seleccion.ToList()
            AjusteColumnas()

        End If

    End Sub

    Private Sub CargarDiscrepancias()

        Dim ctx As New CLRDataContext

        Dim seleccion = From i In ctx.Transacciones
                        Join tp In ctx.TipoPago
                                   On i.idPago Equals tp.idPago
                        Join tv In ctx.TipoVehiculo
                                   On i.idVehiculo Equals tv.idVehiculo
                        Join t In ctx.Turnos
                                   On i.idTurno Equals t.idTurno
                        Where i.Fecha = FechaEvento And i.NoPlaza = NumCaseta And i.idTurno = idHora And i.NoCarrilCapufe = idCarril And (i.POST <> i.idVehiculo)
                        Order By i.NoEvento
                        Select
                           Evento = i.NoEvento,
                           Hora = i.Hora,
                           Turno = t.Turno,
                           Carril = i.NoCarrilCapufe,
                           Empleado = i.NoEmpleadoCapufe,
                           Folio = i.Folio,
                           PRE = i.PRE,
                           POST = i.POST,
                           ClaseCR = i.idVehiculo,
                           Pago = tp.NomPago,
                           Tarifa = Format(i.idTarifa, "###0.00"),
                           Liquidado = i.Dictaminado,
                           Fecha = Format(i.Fecha, "dd/MM/yyyy"),
                           Plaza = i.NoPlaza,
                           NumLiquidacion = i.idDictaminacion,
                           ID = i.idTransaccion,
                           Anulado = i.Anulado

        dgvEventos.DataSource = seleccion.ToList()
        AjusteColumnas()

    End Sub

    Private Sub Buscar()

        Dim ctx As New CLRDataContext

        Dim busqueda = From b In ctx.Transacciones
                       Join tp In ctx.TipoPago
                                   On b.idPago Equals tp.idPago
                       Join tv In ctx.TipoVehiculo
                                   On b.idVehiculo Equals tv.idVehiculo
                       Join t In ctx.Turnos
                                   On b.idTurno Equals t.idTurno
                       Where b.Fecha = FechaEvento And b.NoPlaza = NumCaseta And b.idTurno = idHora And b.NoCarrilCapufe = idCarril And b.NoEvento = Integer.Parse(txtBuscar.Text)
                       Order By b.NoEvento
                       Select
                             Evento = b.NoEvento,
                             Hora = b.Hora,
                             Turno = t.Turno,
                             Carril = b.NoCarrilCapufe,
                             Empleado = b.NoEmpleadoCapufe,
                             Folio = b.Folio,
                             PRE = tv.Clase,
                             POST = tv.Clase,
                             ClaseCR = tv.Clase,
                             Pago = tp.NomPago,
                             Tarifa = Format(b.idTarifa, "###0.00"),
                             Liquidado = b.Dictaminado,
                             Fecha = Format(b.Fecha, "dd/MM/yyyy"),
                             Plaza = b.NoPlaza,
                             NumLiquidacion = b.idDictaminacion,
                             ID = b.idTransaccion,
                             Anulado = b.Anulado

        dgvEventos.DataSource = busqueda.ToList()
        AjusteColumnas()

    End Sub

    Private Sub LimpiarCheckBox()

        chkIAVE.Checked = False
        chkVSC.Checked = False
        chkNormal.Checked = False
        chkResidentes.Checked = False
        chkEludidos.Checked = False
        chkTarjeta.Checked = False

    End Sub

    Private Sub CargarLiquidaciones(NumLiquidacion As Integer)

        Dim ctx As New CLRDataContext()

		Dim liquidaciones = From l In ctx.Dictaminaciones
							Join p In ctx.TipoPago
								On l.idPago Equals p.idPago
							Join v In ctx.TipoVehiculo
								On l.idVehiculo Equals v.idVehiculo
							Join c In ctx.PersonalCLR
								On l.NoEmpleadoCapufe Equals c.NoEmpleadoCapufe
							Where l.idDictaminacion = NumLiquidacion
							Select
								Liquidación = l.idDictaminacion,
								Evento = l.NoTransaccion,
								Analista = c.Nombre + " " + c.APaterno + " " + c.AMaterno,
								Pago = p.NomPago,
								Clase = v.Clase

		dgvLiquidacion.DataSource = liquidaciones.ToList()
        'dgvLiquidacion.Columns(0).Width = 85
        'dgvLiquidacion.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvLiquidacion.Columns(0).IsVisible = False
        dgvLiquidacion.Columns(1).Width = 55
        dgvLiquidacion.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        'dgvLiquidacion.Columns(2).Width = 175
        'dgvLiquidacion.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvLiquidacion.Columns(2).IsVisible = False
        dgvLiquidacion.Columns(3).Width = 110
        dgvLiquidacion.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvLiquidacion.Columns(4).Width = 90
        dgvLiquidacion.Columns(4).TextAlignment = ContentAlignment.MiddleCenter

    End Sub

    Private Sub CargarClases()

        Dim ctx As New CLRDataContext

		Dim tipo = From c In ctx.TipoVehiculo
				   Order By c.idVehiculo
				   Select
					   ID = c.idVehiculo,
					  Nombre = c.Clase

		ddlClaseAL.ValueMember = "ID"
        ddlClaseAL.DisplayMember = "Nombre"

        ddlClaseAL.DataSource = tipo.ToList()

    End Sub

    Private Sub CargarPagos()

        Dim ctx As New CLRDataContext

		Dim pago = From p In ctx.TipoPago
				   Order By p.NomPago
				   Select
						ID = p.idPago,
						Nombre = p.NomPago

		ddlPago.ValueMember = "ID"
        ddlPago.DisplayMember = "Nombre"

        ddlPago.DataSource = pago.ToList()

    End Sub

    Private Sub DesactivarLiquidacion()

        btnLiquidar.Enabled = False
        btnCorregir.Enabled = True

    End Sub

    Private Sub DesactivarCorreccion()

        btnLiquidar.Enabled = True
        btnCorregir.Enabled = False

    End Sub

    Private Sub ActivarLiquidacion()

        ddlClaseAL.Enabled = True
        ddlPago.Enabled = True
        btnLiquidar.Enabled = True
        btnCorregir.Enabled = False
        CargarClases()
        CargarPagos()
        ddlClaseAL.SelectedText = dgvEventos.CurrentRow.Cells(8).Value
        ddlPago.SelectedText = dgvEventos.CurrentRow.Cells(9).Value

    End Sub

    Private Sub ActivarCorreccion()

        ddlClaseAL.Enabled = True
        ddlPago.Enabled = True
        btnLiquidar.Enabled = False
        btnCorregir.Enabled = True
        CargarClases()
        CargarPagos()
        ddlClaseAL.SelectedText = dgvEventos.CurrentRow.Cells(8).Value
        ddlPago.SelectedText = dgvEventos.CurrentRow.Cells(9).Value

    End Sub

    Private Sub Conversiones()

        Dim ctx As New CLRDataContext

        Dim tipoC = (From t In ctx.TipoVehiculo
                     Where t.Clase = dgvEventos.CurrentRow.Cells(9).Value.ToString().Replace(vbCrLf, "")
                     Select t.idVehiculo).SingleOrDefault()

        ClaseV = tipoC

        Dim pago = (From p In ctx.TipoPago
                    Where p.NomPago = dgvEventos.CurrentRow.Cells(10).Value.ToString()
                    Select p.idPago).SingleOrDefault()

        TipoP = pago

    End Sub

    Private Sub Liquidar()

        Dim ctx As New CLRDataContext

        If ddlClaseAL.SelectedValue = T01LnnA Or ddlClaseAL.SelectedValue = T09PnnC Then

            If txtNoejes.Text IsNot "" Then

                Dim Numliqui = (From n In ctx.Dictaminaciones
                                Select n.idDictaminacion).Max()

                Dim num As Integer

                num = Numliqui + 1

                Dim Dictaminar As New Dictaminaciones()

                Dictaminar.idDictaminacion = num
                Dictaminar.NoTransaccion = NumTransaccion
                Dictaminar.NoEmpleadoCapufe = Liquidador
                Dictaminar.Fecha = Date.Now.Date
                Dictaminar.Hora = Date.Now.TimeOfDay
                Dictaminar.idVehiculo = ddlClaseAL.SelectedValue
                Dictaminar.idPago = ddlPago.SelectedValue
                Dictaminar.NuevaTarifa = NewTarif(ddlClaseAL.SelectedValue, Num_Evento)

                ctx.Dictaminaciones.InsertOnSubmit(Dictaminar)
                ctx.SubmitChanges()

                Dim insertar = (From i In ctx.Transacciones
                                Where i.idTransaccion = Integer.Parse(dgvEventos.CurrentRow.Cells(15).Value) 'Integer.Parse(txtNoEvento.Text)
                                Select i)

                For Each c As Transacciones In insertar

                    c.idDictaminacion = num
                    c.Dictaminado = True
                    c.Num_Ejes = Integer.Parse(txtNoejes.Text)

                Next

                ctx.SubmitChanges()
                RadMessageBox.Show("El Evento " + NumTransaccion.ToString() + " se Corrigió Exitosamente.", "Correción exitosa", MessageBoxButtons.OK, RadMessageIcon.Info)

            Else
                RadMessageBox.Show("Debe indicar un número de ejes.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                txtNoejes.Focusable = True
            End If

        Else

            Dim Numliqui = (From n In ctx.Dictaminaciones
                            Select n.idDictaminacion).Max()

            Dim num As Integer

            num = Numliqui + 1

            Dim Dictaminar As New Dictaminaciones()

            Dictaminar.idDictaminacion = num
            Dictaminar.NoTransaccion = NumTransaccion
            Dictaminar.NoEmpleadoCapufe = Liquidador
            Dictaminar.Fecha = Date.Now.Date
            Dictaminar.Hora = Date.Now.TimeOfDay
            Dictaminar.idVehiculo = ddlClaseAL.SelectedValue
            Dictaminar.idPago = ddlPago.SelectedValue
            Dictaminar.NuevaTarifa = NewTarif(ddlClaseAL.SelectedValue, Num_Evento)

            ctx.Dictaminaciones.InsertOnSubmit(Dictaminar)
            ctx.SubmitChanges()

            Dim insertar = (From i In ctx.Transacciones
                            Where i.idTransaccion = Integer.Parse(dgvEventos.CurrentRow.Cells(15).Value) 'Integer.Parse(txtNoEvento.Text)
                            Select i)

            For Each c As Transacciones In insertar

                c.idDictaminacion = num
                c.Dictaminado = True

            Next

            ctx.SubmitChanges()
            RadMessageBox.Show("El Evento " + NumTransaccion.ToString() + " se Corrigió Exitosamente.", "Correción exitosa", MessageBoxButtons.OK, RadMessageIcon.Info)

        End If



    End Sub

    Private Function ExisteLiquidador(Numero As Integer) As Boolean

        Dim db As New CLRDataContext()

        Dim existe = (From e In db.Usuarios
                      Where e.Nombre = Numero
                      Select e.Nombre).FirstOrDefault()

        If existe = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function ComprobarLiquidacion(Numero As Integer) As Boolean

        Dim ctx As New CLRDataContext()

        Dim query = (From q In ctx.Dictaminaciones
                     Where q.NoTransaccion = Numero
                     Select q.idDictaminacion).SingleOrDefault()

        If query = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub Corregir()

        Dim ctx As New CLRDataContext

        If ddlClaseAL.SelectedValue = T01LnnA Or ddlClaseAL.SelectedValue = T09PnnC Then

            If txtNoejes.Text IsNot "" Then

                Dim numLiqui = Integer.Parse(dgvEventos.CurrentRow.Cells(14).Value)

                Dim correjir = (From c In ctx.Dictaminaciones
                                Where c.idDictaminacion = numLiqui
                                Select c)

                For Each x As Dictaminaciones In correjir

                    x.idPago = ddlPago.SelectedValue
                    x.idVehiculo = ddlClaseAL.SelectedValue
                    x.NoEmpleadoCapufe = Integer.Parse(txtNoEmpleado.Text)
                    x.Fecha = Date.Now.Date
                    x.Hora = Date.Now.TimeOfDay
                    x.NuevaTarifa = NewTarif(ddlClaseAL.SelectedValue, Num_Evento)

                Next

                ctx.SubmitChanges()

                Dim insertar = (From i In ctx.Transacciones
                                Where i.idTransaccion = Integer.Parse(dgvEventos.CurrentRow.Cells(15).Value)
                                Select i)

                For Each c As Transacciones In insertar

                    c.Num_Ejes = Integer.Parse(txtNoejes.Text)

                Next

                ctx.SubmitChanges()
                RadMessageBox.Show("El Evento " + NumTransaccion.ToString() + " se Corrigió Exitosamente.", "Correción exitosa", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                RadMessageBox.Show("Debe indicar un número de ejes.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                txtNoejes.Focusable = True
            End If
        Else
            Dim numLiqui = Integer.Parse(dgvEventos.CurrentRow.Cells(14).Value)

            Dim correjir = (From c In ctx.Dictaminaciones
                            Where c.idDictaminacion = numLiqui
                            Select c)

            For Each x As Dictaminaciones In correjir

                x.idPago = ddlPago.SelectedValue
                x.idVehiculo = ddlClaseAL.SelectedValue
                x.NoEmpleadoCapufe = Integer.Parse(txtNoEmpleado.Text)
                x.Fecha = Date.Now.Date
                x.Hora = Date.Now.TimeOfDay
                x.NuevaTarifa = NewTarif(ddlClaseAL.SelectedValue, Num_Evento)

            Next

            ctx.SubmitChanges()
            RadMessageBox.Show("El Evento " + NumTransaccion.ToString() + " se Corrigió Exitosamente.", "Correción exitosa", MessageBoxButtons.OK, RadMessageIcon.Info)

        End If

    End Sub

    Private Function ExisteLiquidacion(Valor As Integer) As Boolean

        Dim ctx As New CLRDataContext()

        Dim existe = (From e In ctx.Dictaminaciones
                      Where e.idDictaminacion = Valor
                      Select e.NoTransaccion).SingleOrDefault()

        If existe Is Nothing OrElse existe.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function ExiteEvento(Evento As Integer) As Boolean

        Dim ctx As New CLRDataContext()

        Dim existe = (From e In ctx.Transacciones
                      Where e.NoEvento = Evento And e.Fecha = FechaEvento And e.NoPlaza = NumCaseta
                      Select e.NoEvento).FirstOrDefault()

        If existe = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub Timer1_Tick(ByVal Sender As Object, ByVal e As EventArgs) Handles Timer.Tick

        lblCronometro.Text = Mid(AxRecViewer2.CurrentFrameDate(), 12, 8)

    End Sub

    Public Sub Reproducir(num As Integer, num2 As Integer)

        num2 = num - (5 * 11)
        num = num - (FrameXsegundo * 11)

        Barra.Minimum = 1
        Barra.Maximum = AxRecViewer2.FrameCount

        valor1 = num + (FrameXsegundo * 23)
        valor2 = num

        AxRecViewer2.ShowFrame(num)
        rvCabina.ShowFrame(num2)
        AxRecViewer2.StartPlay()
        rvCabina.StartPlay()
        Barra.Value = AxRecViewer2.CurrentFrame
        Timer.Start()

    End Sub  'No se usa

    Public Sub ReproducirCarril(num As Integer)

        num = num - (FrameXsegundo * 11)

        Barra.Minimum = 1
        Barra.Maximum = AxRecViewer2.FrameCount

        valor1 = num + (FrameXsegundo * 23)
        valor2 = num

        AxRecViewer2.ShowFrame(num)
        AxRecViewer2.StartPlay()
        Barra.Value = AxRecViewer2.CurrentFrame
        Timer.Start()

    End Sub

    Public Sub ReproducirCabina(num As Integer)

        num = num - (FrameXsegundo * 11)

        rvCabina.ShowFrame(num)
        rvCabina.StartPlay()

    End Sub

    Public Sub Play()

        pbPlay.Visible = False
        pbPlay2.Visible = True

        pbStop.Visible = True
        pbStop2.Visible = False
        pbPause.Visible = True
        pbPause2.Visible = False
        pbAdelantar.Visible = True
        pbAdelantar2.Visible = False
        pbRegresar.Visible = True
        pbRegresar2.Visible = False

    End Sub

    Private Sub ActivarControles()

        pbRegresar.Enabled = True
        pbRegresar2.Enabled = True
        pbPause.Enabled = True
        pbPause2.Enabled = True
        pbPlay.Enabled = True
        pbPlay2.Enabled = True
        pbStop.Enabled = True
        pbStop2.Enabled = True
        pbAdelantar.Enabled = True
        pbAdelantar2.Enabled = True

    End Sub

    Private Sub DesactivarControles()

        pbRegresar.Enabled = False
        pbRegresar2.Enabled = False
        pbPause.Enabled = False
        pbPause2.Enabled = False
        pbPlay.Enabled = False
        pbPlay2.Enabled = False
        pbStop.Enabled = False
        pbStop2.Enabled = False
        pbAdelantar.Enabled = False
        pbAdelantar2.Enabled = False

    End Sub

    Private Sub ConsultarNomCamaras(Carril As String, Plaza As Integer)

        Dim ctx As New CLRDataContext()

		Dim via = (From v In ctx.CatalogoCarriles
				   Where v.Carril = Carril And v.idPlaza = Plaza
				   Select v.CamaraCarril).SingleOrDefault()

		CamaraCarril = via.ToString()

		Dim cab = (From c In ctx.CatalogoCarriles
				   Where c.Carril = Carril And c.idPlaza = Plaza
				   Select c.CamaraCabina).SingleOrDefault()

		CamaraCabina = cab.ToString()

    End Sub

#End Region

#Region "Events"

#Region "Controles"

    Private Sub pbPlay_Click(sender As Object, e As EventArgs) Handles pbPlay.Click

        pbAdelantar.Enabled = True
        pbRegresar.Enabled = True

        Play()

        AxRecViewer2.StartPlay()
        rvCabina.StartPlay()
        AxRecViewer2.Speedx = 1
        rvCabina.Speedx = 1

    End Sub

    Private Sub pbPlay2_Click(sender As Object, e As EventArgs) Handles pbPlay2.Click

        pbPlay.Visible = True
        pbPlay2.Visible = False
        pbPause2.Visible = True
        pbPause.Visible = False
        pbAdelantar.Enabled = False
        pbRegresar.Enabled = False

        AxRecViewer2.PausePlay()
        rvCabina.PausePlay()

    End Sub

    Private Sub pbPause_Click(sender As Object, e As EventArgs) Handles pbPause.Click

        pbPause.Visible = False
        pbPause2.Visible = True

        pbStop.Visible = True
        pbStop2.Visible = False
        pbPlay.Visible = True
        pbPlay2.Visible = False
        pbAdelantar.Visible = True
        pbAdelantar2.Visible = False
        pbRegresar.Visible = True
        pbRegresar2.Visible = False
        pbAdelantar.Enabled = False
        pbRegresar.Enabled = False

        AxRecViewer2.PausePlay()
        rvCabina.PausePlay()

    End Sub

    Private Sub pbPause2_Click(sender As Object, e As EventArgs) Handles pbPause2.Click

        pbPause.Visible = True
        pbPause2.Visible = False
        pbAdelantar.Enabled = True
        pbRegresar.Enabled = True


        Play()

        AxRecViewer2.StartPlay()
        rvCabina.StartPlay()
        AxRecViewer2.Speedx = 1
        rvCabina.Speedx = 1

    End Sub

    Private Sub pbStop_Click(sender As Object, e As EventArgs) Handles pbStop.Click

        pbStop.Visible = False
        pbStop2.Visible = True

        pbPlay.Visible = True
        pbPlay.Enabled = False
        pbPlay2.Visible = False
        pbPause.Visible = True
        pbPause2.Visible = False
        pbAdelantar.Visible = True
        pbAdelantar2.Visible = False
        pbRegresar.Visible = True
        pbRegresar2.Visible = False
        rvFoto.Visible = True
        Barra.Value = 1
        lblCronometro.Text = "00:00:00"

        DesactivarControles()

        AxRecViewer2.StopPlay()
        rvCabina.StopPlay()
        AxRecViewer2.Visible = False
        rvCabina.Visible = False

    End Sub

    Private Sub pbStop2_Click(sender As Object, e As EventArgs) Handles pbStop2.Click

        pbStop.Visible = True
        pbStop2.Visible = False

        AxRecViewer2.StopPlay()
        rvCabina.StopPlay()

    End Sub

    Private Sub pbAdelantar_Click(sender As Object, e As EventArgs) Handles pbAdelantar.Click

        pbAdelantar.Visible = False
        pbAdelantar2.Visible = True

        pbPlay.Visible = True
        pbPlay2.Visible = False
        pbStop.Visible = True
        pbStop2.Visible = False
        pbPause.Visible = True
        pbPause2.Visible = False
        pbRegresar.Visible = True
        pbRegresar2.Visible = False

        AxRecViewer2.Speedx = 2
        rvCabina.Speedx = 2

    End Sub

    Private Sub pbAdelantar2_Click(sender As Object, e As EventArgs) Handles pbAdelantar2.Click

        pbAdelantar.Visible = True
        pbAdelantar2.Visible = False
        pbPlay.Visible = False
        pbPlay2.Visible = True

        AxRecViewer2.Speedx = 1
        rvCabina.Speedx = 1

    End Sub

    Private Sub pbRegresar_Click(sender As Object, e As EventArgs) Handles pbRegresar.Click

        pbRegresar.Visible = False
        pbRegresar2.Visible = True

        pbPlay.Visible = True
        pbPlay2.Visible = False
        pbStop.Visible = True
        pbStop2.Visible = False
        pbPause.Visible = True
        pbPause2.Visible = False
        pbAdelantar.Visible = True
        pbAdelantar2.Visible = False

        AxRecViewer2.Speedx = -1
        rvCabina.Speedx = -1

    End Sub

    Private Sub pbRegresar2_Click(sender As Object, e As EventArgs) Handles pbRegresar2.Click

        pbRegresar.Visible = True
        pbRegresar2.Visible = False
        pbPlay.Visible = False
        pbPlay2.Visible = True

        AxRecViewer2.Speedx = 1
        rvCabina.Speedx = 1

    End Sub

#End Region

#Region "Botones"

    Private Sub btnDiscrepancias_Click(sender As Object, e As EventArgs) Handles btnDiscrepancias.Click

        chkTodos.Checked = False
        DesactivarLiquidacion()
        LimpiarCheckBox()
        CargarDiscrepancias()
        dgvLiquidacion.DataSource = ""

    End Sub

    Private Sub bntRestablecer_Click(sender As Object, e As EventArgs)

        chkTodos.Checked = False
        DesactivarLiquidacion()
        LimpiarCheckBox()
        CargarPredefinidos()
        dgvLiquidacion.DataSource = ""

    End Sub

    Private Sub btnFiltros_Click(sender As Object, e As EventArgs)

        DesactivarLiquidacion()

        If todos = 8 Then
            CargarTodos()
            dgvLiquidacion.DataSource = ""
        Else
            If vs <> 0 Or iav <> 0 Or dis <> 0 Or elu <> 0 Or tarj <> 0 Or nor <> 0 Or resi <> 0 Then
                CargarSeleccion()
                dgvLiquidacion.DataSource = ""
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        DesactivarLiquidacion()

        If txtBuscar.Text = "" Then
            MessageBox.Show("Debe ingresar una busqueda", "Atencion!", MessageBoxButtons.OK)
        Else
            If ExiteEvento(Integer.Parse(txtBuscar.Text)) = True Then
                Buscar()
                dgvLiquidacion.DataSource = ""
                txtBuscar.Text = ""
            Else
                MessageBox.Show("El número de evento ingresado no existe o pertenece a otra fecha o carril", "Verifique", MessageBoxButtons.OK)
                txtBuscar.Text = ""
            End If
        End If

    End Sub

#End Region

#Region "CheckBox"

    Private Sub chkVSC_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkVSC.ToggleStateChanged

        If bandera = True Then
            chkTodos.Checked = False
            chkIAVE.Checked = False
            chkNormal.Checked = False
            chkResidentes.Checked = False
            chkEludidos.Checked = False
            chkTarjeta.Checked = False
            vs = 27
            CargarSeleccion()
            bandera = False
        Else
            vs = 0
            CargarPredefinidos()
            bandera = True
        End If

    End Sub

    Private Sub chkIAVE_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkIAVE.ToggleStateChanged

        If bandera1 = True Then
            chkTodos.Checked = False
            chkVSC.Checked = False
            chkNormal.Checked = False
            chkResidentes.Checked = False
            chkEludidos.Checked = False
            chkTarjeta.Checked = False
            iav = 15
            CargarSeleccion()
            bandera1 = False
        Else
            iav = 0
            CargarPredefinidos()
            bandera1 = True
        End If

    End Sub

    Private Sub chkResidentes_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkResidentes.ToggleStateChanged

        If bandera3 = True Then
            chkTodos.Checked = False
            chkIAVE.Checked = False
            chkVSC.Checked = False
            chkNormal.Checked = False
            chkEludidos.Checked = False
            chkTarjeta.Checked = False
            resi = 10
            CargarSeleccion()
            bandera3 = False
        Else
            resi = 0
            CargarPredefinidos()
            bandera3 = True
        End If

    End Sub

    Private Sub chkEludidos_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkEludidos.ToggleStateChanged

        If bandera4 = True Then
            chkTodos.Checked = False
            chkIAVE.Checked = False
            chkVSC.Checked = False
            chkNormal.Checked = False
            chkResidentes.Checked = False
            chkTarjeta.Checked = False
            elu = 13
            CargarSeleccion()
            bandera4 = False
        Else
            elu = 0
            CargarPredefinidos()
            bandera4 = True
        End If

    End Sub

    Private Sub chkTarjeta_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkTarjeta.ToggleStateChanged

        If bandera5 = True Then
            chkTodos.Checked = False
            chkIAVE.Checked = False
            chkVSC.Checked = False
            chkNormal.Checked = False
            chkResidentes.Checked = False
            chkEludidos.Checked = False
            tarjC = 12
            tarjD = 14
            CargarSeleccion()
            bandera5 = False
        Else
            tarjC = 0
            tarjD = 0
            CargarPredefinidos()
            bandera5 = True
        End If

    End Sub

    Private Sub chkNormal_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkNormal.ToggleStateChanged

        If bandera6 = True Then
            chkTodos.Checked = False
            chkIAVE.Checked = False
            chkVSC.Checked = False
            chkResidentes.Checked = False
            chkEludidos.Checked = False
            chkTarjeta.Checked = False
            nor = 1
            CargarSeleccion()
            bandera6 = False
        Else
            nor = 0
            CargarPredefinidos()
            bandera6 = True
        End If

    End Sub

    Private Sub chkTodos_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkTodos.ToggleStateChanged

        If bandera7 = True Then
            LimpiarCheckBox()
            todos = 8
            CargarTodos()
            bandera7 = False
        Else
            todos = 0
            CargarPredefinidos()
            bandera7 = True
        End If

    End Sub

#End Region

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            e.Handled = True
            Return
        End If

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnBuscar.PerformClick()
        End If

    End Sub

    Private Sub dgvEventos_CellClick(sender As Object, e As UI.GridViewCellEventArgs) Handles dgvEventos.CellClick

        btnComentar.Enabled = True
        txtNoEvento.Text = dgvEventos.CurrentRow.Cells(0).Value.ToString()
        btnLiquidar.Enabled = True
        NumTransaccion = dgvEventos.CurrentRow.Cells(0).Value
        EventoComentar = dgvEventos.CurrentRow.Cells(0).Value

        If ExisteLiquidacion(dgvEventos.CurrentRow.Cells(14).Value) = True Then
            lblSinLiquidar.Text = ""
            NumTransaccion = dgvEventos.CurrentRow.Cells(0).Value
            DesactivarLiquidacion()
            ActivarCorreccion()
            CargarLiquidaciones(dgvEventos.CurrentRow.Cells(14).Value)
        Else
            NumTransaccion = dgvEventos.CurrentRow.Cells(0).Value
            lblSinLiquidar.Text = "Evento sin Dictaminar"
            ActivarLiquidacion()
            DesactivarCorreccion()
            dgvLiquidacion.DataSource = ""
            txtNoEvento.Text = dgvEventos.CurrentRow.Cells(0).Value.ToString()
        End If

        Try
            If My.Computer.Network.Ping(IPVideo) Then

                Dim FechaProv As Date
                Dim HoraProv As New TimeSpan(21, 0, 0)

                If TurnoD = 1 And dgvEventos.CurrentRow.Cells(1).Value > HoraProv Then
                    FechaProv = FechaEvento.AddDays(-1)
                Else
                    FechaProv = FechaEvento
                End If

                DesactivarControles()
                ConsultarNomCamaras((dgvEventos.CurrentRow.Cells(3).Value).ToString(), NumCaseta)

                Dim valor As Integer
                Dim fecha As String
                Dim hora As String

                rvFoto.Visible = True
                AxRecViewer2.Visible = False
                rvCabina.Visible = False

                Try

                    fecha = dgvEventos.CurrentRow.Cells(12).Value
                    hora = (dgvEventos.CurrentRow.Cells(1).Value).ToString()

                    With AxRMSInfo2

                        Dim fechaVideo As String
                        fechaVideo = FechaProv.ToString.Substring(6, 4) + FechaProv.ToString.Substring(3, 2) + FechaProv.ToString.Substring(0, 2)
                        Dim valorX As String

                        valorX = fechaVideo + "0001#" + fechaVideo + "2359"

                        .FilterRecDate = fechaVideo + "0001#" + fechaVideo + "2359"
                        .LoadRecordings(4, 4, "1#asdc")

                        While Not .EndOfData
                            Dim x As String = .GetValue("CamName")
                            If .GetValue("CamName") = CamaraCarril Then
                                rvFoto.LoadRecording(.GetValue("RecID"))
                                valor = rvFoto.GetFrameNumByDate(fecha & " " & hora)
                                rvFoto.ShowFrame(valor)
                            End If
                            .MoveNext()
                        End While

                    End With
                    Timer.Stop()
                    Barra.Value = 1
                Catch ex As Exception
                    RadMessageBox.Show(ex.Message)
                End Try
            Else
                RadMessageBox.Show("No se puede visualizar la imagen.", "Sin Conexión", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dgvEventos_CellDoubleClick(sender As Object, e As UI.GridViewCellEventArgs) Handles dgvEventos.CellDoubleClick

        If BanderaVideo = True Then
            Try
                If My.Computer.Network.Ping(IPVideo) Then

                    Dim FechaProv As Date
                    Dim HoraProv As New TimeSpan(21, 0, 0)

                    If TurnoD = 1 And dgvEventos.CurrentRow.Cells(1).Value > HoraProv Then
                        FechaProv = FechaEvento.AddDays(-1)
                    Else
                        FechaProv = FechaEvento
                    End If

                    Dim valor As Integer
                    Dim parametro As Integer
                    Dim fecha As String
                    Dim hora As String

                    rvFoto.Visible = False
                    AxRecViewer2.Visible = True
                    rvCabina.Visible = True

                    ActivarControles()

                    AxRecViewer2.Speedx = 1
                    rvCabina.Speedx = 1

                    Try
                        If BanderaVideo = True Then

                            AxRecViewer2.Visible = True
                            Play()
                            fecha = dgvEventos.CurrentRow.Cells(12).Value
                            hora = (dgvEventos.CurrentRow.Cells(1).Value).ToString

                            With AxRMSInfo1

                                Dim fechaVideo As String
                                fechaVideo = FechaProv.ToString.Substring(6, 4) + FechaProv.ToString.Substring(3, 2) + FechaProv.ToString.Substring(0, 2)

                                .FilterRecDate = fechaVideo + "0001#" + fechaVideo + "2359"
                                .LoadRecordings(4, 4, "1#asdc")

                                While Not .EndOfData
                                    If .GetValue("CamName") = CamaraCarril Then
                                        AxRecViewer2.LoadRecording(.GetValue("RecID"))
                                        valor = AxRecViewer2.GetFrameNumByDate(fecha & " " & hora)
                                        ReproducirCarril(valor)
                                    End If
                                    If .GetValue("CamName") = CamaraCabina Then
                                        rvCabina.LoadRecording(.GetValue("RecID"))
                                        parametro = rvCabina.GetFrameNumByDate(fecha & " " & hora)
                                        ReproducirCabina(parametro)
                                    End If
                                    .MoveNext()
                                End While

                            End With

                        End If
                    Catch ex As Exception
                        RadMessageBox.Show(ex.Message)
                    End Try

                Else
                    RadMessageBox.Show("No se puede establecer conexión con el servidor de video.", "Sin Conexión", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If



            Catch ex As Exception
                RadMessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub dbgEventos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEventos.SelectionChanged

        If count > 0 Then
            Try
                DesactivarControles()
                If ExisteLiquidacion(dgvEventos.CurrentRow.Cells(14).Value) = True Then
                    NumTransaccion = dgvEventos.CurrentRow.Cells(0).Value
                    AxRecViewer2.StopPlay()
                    AxRecViewer2.Visible = False
                    lblSinLiquidar.Text = ""
                    DesactivarLiquidacion()
                    CargarLiquidaciones(dgvEventos.CurrentRow.Cells(14).Value)
                    txtNoEvento.Text = dgvEventos.CurrentRow.Cells(0).Value.ToString()
                Else
                    NumTransaccion = dgvEventos.CurrentRow.Cells(0).Value
                    AxRecViewer2.StopPlay()
                    AxRecViewer2.Visible = False
                    lblSinLiquidar.Text = "Evento sin Dictaminar"
                    ActivarLiquidacion()
                    dgvLiquidacion.DataSource = ""
                    txtNoEvento.Text = dgvEventos.CurrentRow.Cells(0).Value.ToString()
                End If
            Catch ex As Exception
                RadMessageBox.Show(ex.Message)
            End Try
        End If
        count = count + 1

    End Sub

    Private Sub btnCorregir_Click(sender As Object, e As EventArgs) Handles btnCorregir.Click

        If RadMessageBox.Show("Esta por Modificar una Dictaminación, Desea Continuar?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then
            If txtNoEmpleado.Text Is Nothing OrElse txtNoEmpleado.Text = String.Empty Then
                RadMessageBox.Show("Debe ingresar el número de empleado.", "Atención!", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Liquidador = Integer.Parse(txtNoEmpleado.Text)
                If ExisteLiquidador(Liquidador) = True Then
                    Corregir()
                    CargarPredefinidos()
                    LimpiarCheckBox()
                Else
                    RadMessageBox.Show("El número de empleado " + Liquidador.ToString() + " no existe.", "ERROR!", MessageBoxButtons.OK, RadMessageIcon.Error)
                End If
            End If
        End If

    End Sub

    Private Sub btnLiquidar_Click(sender As Object, e As EventArgs) Handles btnLiquidar.Click

        If RadMessageBox.Show("Esta por liquidar una Transacción, desea continuar?", "Atención", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then

            If txtNoEmpleado.Text Is Nothing OrElse txtNoEmpleado.Text = String.Empty Then
                RadMessageBox.Show("Debe ingresar el número de empleado", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                Liquidador = Integer.Parse(txtNoEmpleado.Text)

                If ExisteLiquidador(Liquidador) = True Then
                    Liquidar()
                    RadMessageBox.Show("El Evento " + NumTransaccion.ToString() + " se Liquido Exitosamente.", "Liquidación Exitosa", MessageBoxButtons.OK, RadMessageIcon.Info)
                    CargarPredefinidos()
                    LimpiarCheckBox()
                Else
                    RadMessageBox.Show("El número de empleado " + Liquidador.ToString() + " no existe.", "ERROR!", MessageBoxButtons.OK, RadMessageIcon.Error)
                End If

            End If

        End If

    End Sub

    Private Sub Barra_ValueChanged(sender As Object, e As EventArgs)

        AxRecViewer2.ShowFrame(Barra.Value())

    End Sub

    Private Sub Barra_MouseDown(sender As Object, e As MouseEventArgs) Handles Barra.MouseDown
        AxRecViewer2.PausePlay()
        rvCabina.PausePlay()
    End Sub

    Private Sub Barra_MouseUp(sender As Object, e As MouseEventArgs) Handles Barra.MouseUp

        pbPlay.Visible = False
        pbPlay2.Visible = True
        pbPause2.Visible = False
        pbPause.Visible = True
        AxRecViewer2.ShowFrame(Barra.Value)
        rvCabina.ShowFrame(Barra.Value)
        AxRecViewer2.StartPlay()
        rvCabina.StartPlay()

    End Sub

    Private Sub btnVideo_Click(sender As Object, e As EventArgs)
        Identificador = 1
        Help.Show()
    End Sub

    Private Sub btnCamaras_Click(sender As Object, e As EventArgs)
        Identificador = 2
        Help.Show()
    End Sub

    Private Sub btnControles_Click(sender As Object, e As EventArgs)
        Identificador = 3
        Help.Show()
    End Sub

    Private Sub btnFiltro_Click(sender As Object, e As EventArgs)
        Identificador = 4
        Help.Show()
    End Sub

    Private Sub btnEventos_Click(sender As Object, e As EventArgs)
        Identificador = 5
        Help.Show()
    End Sub

    Private Sub btnInfoEvento_Click(sender As Object, e As EventArgs)
        Identificador = 6
        Help.Show()
    End Sub

    Private Sub btnDictaminacion_Click(sender As Object, e As EventArgs)
        Identificador = 7
        Help.Show()
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        '******** CHECAR VALIDACIÓN
        If dgvEventos.CurrentRow Is Nothing Then
            RadMessageBox.Show("Debe seleccionar el evento a remplazar.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else

            ie_NoEvento = dgvEventos.CurrentRow.Cells(0).Value
            ie_Fecha = dgvEventos.CurrentRow.Cells(12).Value
            ie_Hora = dgvEventos.CurrentRow.Cells(1).Value
            ie_Folio = dgvEventos.CurrentRow.Cells(5).Value
            ie_NoCajero = dgvEventos.CurrentRow.Cells(4).Value
            ie_ClaseECT = dgvEventos.CurrentRow.Cells(6).Value
            ie_ClaseCR = dgvEventos.CurrentRow.Cells(8).Value
            ie_FormaPago = dgvEventos.CurrentRow.Cells(9).Value

            AgregarEvento.Show()
        End If

    End Sub

    Private Sub btnComentar_Click(sender As Object, e As EventArgs) Handles btnComentar.Click
        IdTransaccion = dgvEventos.CurrentRow.Cells(15).Value
        Comentar.Show()
    End Sub

    Private Sub btnEstadisticas_Click(sender As Object, e As EventArgs) Handles btnEstadisticas.Click
        Estadisticas.Show()
    End Sub

    Private Sub btnLiquidarTodo_Click(sender As Object, e As EventArgs) Handles btnLiquidarTodo.Click

        If RadMessageBox.Show("Esta por realizar una liquidación multiple, desea continuar?", "Atención", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then

            If txtNoEmpleado.Text Is Nothing OrElse txtNoEmpleado.Text = String.Empty Then
                RadMessageBox.Show("Debe ingresar el número de empleado", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                Liquidador = Integer.Parse(txtNoEmpleado.Text)

                If ExisteLiquidador(Liquidador) = True Then
                    LiquidarTodos()
                    RadMessageBox.Show("Los Eventos seleccionados se liquidaron exitosamente.", "Liquidación Exitosa", MessageBoxButtons.OK, RadMessageIcon.Info)
                    CargarPredefinidos()
                    LimpiarCheckBox()
                Else
                    RadMessageBox.Show("El número de empleado " + Liquidador.ToString() + " no existe.", "ERROR!", MessageBoxButtons.OK, RadMessageIcon.Error)
                End If

            End If

        End If

    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click

        AxRecViewer2.Width = 160
        AxRecViewer2.Height = 160
        AxRecViewer2.Location = New Point(310, 310)
        AxRecViewer2.BringToFront()

        rvCabina.Width = 450
        rvCabina.Height = 450
        rvCabina.Location = New Point(22, 22)

    End Sub

    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click

        rvCabina.Width = 160
        rvCabina.Height = 160
        rvCabina.Location = New Point(310, 310)
        rvCabina.BringToFront()

        AxRecViewer2.Width = 450
        AxRecViewer2.Height = 450
        AxRecViewer2.Location = New Point(22, 22)

    End Sub

    Private Sub Dictaminacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ctx As New CLRDataContext()
        Dim Hora1 As New TimeSpan(20, 0, 0)
        Dim Hora2 As New TimeSpan(8, 0, 0)
        Dim SinDictaminar

        If idHora = 1 Then
            SinDictaminar = (From d In ctx.Transacciones
                             Where ((d.Fecha = FechaEvento.AddDays(-1) And d.Hora > Hora1) Or (d.Fecha = FechaEvento And d.Hora < Hora2)) And d.NoPlaza = NumCaseta And d.NoCarrilCapufe = idCarril And d.idTurno = idHora And (d.Dictaminado = 0 Or d.Dictaminado Is Nothing)
                             Select d.idTransaccion).Count()
        Else
            SinDictaminar = (From d In ctx.Transacciones
                             Where d.Fecha = FechaEvento And d.NoPlaza = NumCaseta And d.NoCarrilCapufe = idCarril And d.idTurno = idHora And (d.Dictaminado = 0 Or d.Dictaminado Is Nothing)
                             Select d.idTransaccion).Count()
        End If



        If SinDictaminar > 0 Then
            If RadMessageBox.Show("Hay " + SinDictaminar.ToString() + " eventos sin liquidar. Desea continuar con el cierre del módulo?", "Atención", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click

        Try

            Dim ctx As New CLRDataContext()

            Dim num = Integer.Parse(dgvEventos.CurrentRow.Cells(15).Value)

            Dim bandera = (From c In ctx.Transacciones
                           Where c.idTransaccion = num
                           Select c.Anulado).SingleOrDefault()

            If bandera = False Then

                If RadMessageBox.Show("Esta por anular un evento, desea continuar?", "Confirme", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then
                    Dim evento = (From c In ctx.Transacciones
                                  Where c.idTransaccion = num
                                  Select c)

                    For Each x As Transacciones In evento

                        x.Anulado = True

                    Next

                    ctx.SubmitChanges()
                    CargarPredefinidos()

                End If

            Else
                RadMessageBox.Show("El evento ya esta anulado.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If


        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

#End Region

    Private Sub dgvEventos_RowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles dgvEventos.RowFormatting

        Try
            If e.RowElement.RowInfo.Cells(16).Value = True Then

                e.RowElement.DrawFill = True
                e.RowElement.GradientStyle = GradientStyles.Linear
                e.RowElement.BackColor = Color.Red

            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub ddlClaseAL_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles ddlClaseAL.SelectedIndexChanged

        If ddlClaseAL.SelectedValue = T09PnnC Or ddlClaseAL.SelectedValue = T01LnnA Then
            lblNoEjes.Visible = True
            txtNoejes.Visible = True
        Else
            lblNoEjes.Visible = False
            txtNoejes.Visible = False
        End If

    End Sub

    Private Sub txtNoejes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoejes.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            e.Handled = True
            Return
        End If

    End Sub

End Class