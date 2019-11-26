Imports Telerik.WinControls

''' <summary>
''' Formulario LiquidacionSinRevision
''' Se lleva a cabo  la dictaminación
''' de los eventos que no requieren revisión
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @04/10/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>

Public Class LiquidacionSinRevision

    Dim ListaEventos As New ListBox
    Dim ListaClases As New ListBox
    Dim ListaPagos As New ListBox
    Dim NumPlaza As Integer
    Dim NumTurno As Integer
    Dim Carril As String
    Dim Fecha As String

    Dim Normal As Integer = 0
    Dim Tarjeta As Integer = 0
    Dim TarjetaC As Integer = 0
    Dim TarjetaD As Integer = 0
    Dim IAVE As Integer = 0
    Dim Residente As Integer = 0
    Dim VSC As Integer = 0
    Dim Eludido As Integer = 0

    Private Sub LiquidacionAutomatica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)

        txtNoEmplado.Text = NoEmpleado
        txtNoEmplado.Enabled = False
        gpbFiltros.Enabled = False
        CargarPlazas()
        CargarTurnos()

    End Sub

#Region "Methods"

    Private Sub CargarPlazas()

        Dim ctx As New CLRDataContext()

		Dim casetas = From c In ctx.Plazas
					  Select
						  ID = c.NoPlaza,
						  Nombre = c.NomPlaza

		ddlPlaza.ValueMember = "ID"
        ddlPlaza.DisplayMember = "Nombre"

        ddlPlaza.DataSource = casetas.ToList()

    End Sub

    Private Sub CargarTurnos()

        Dim ctx As New CLRDataContext()

		Dim horarios = From h In ctx.Turnos
					   Select
						   ID = h.idTurno,
						   Nombre = h.Turno

		ddlTurno.ValueMember = "ID"
        ddlTurno.DisplayMember = "Nombre"

        ddlTurno.DataSource = horarios.ToList()

    End Sub

    Private Sub CargarCarriles(idPlaza As Integer)

        Dim ctx As New CLRDataContext()

		Dim vias = From v In ctx.CatalogoCarriles
				   Where v.idPlaza = idPlaza
				   Select
					   Nombre = v.Carril

		ddlCarril.DataSource = vias.ToList

    End Sub

    Private Sub LLenarGrid()

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim FechaMetodo As Date = Fecha

        If NumTurno = 1 Then

			Dim transaction = From t In ctx.Transacciones
							  Join c In ctx.TipoVehiculo
								  On t.idVehiculo Equals c.idVehiculo
							  Join p In ctx.TipoPago
								  On t.idPago Equals p.idPago
							  Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And ((t.Fecha = FechaMetodo.AddDays(-1) And t.Hora > HoraA) Or (t.Fecha = FechaMetodo And t.Hora < HoraC))
							  Select
								 Evento = t.NoEvento,
								 Carril = t.NoCarrilCapufe,
								 Clase = c.Clase,
								 Pago = p.NomPago,
								 Dictaminado = t.Dictaminado,
								 Liquidacion = t.idDictaminacion

			dgvEventos.DataSource = transaction.ToList()
            dgvEventos.Columns(0).Width = 60
            dgvEventos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(1).Width = 60
            dgvEventos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(2).Width = 60
            dgvEventos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(3).Width = 110
            dgvEventos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(4).Width = 100
            dgvEventos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(5).IsVisible = False

        Else

			Dim transaction = From t In ctx.Transacciones
							  Join c In ctx.TipoVehiculo
								  On t.idVehiculo Equals c.idVehiculo
							  Join p In ctx.TipoPago
								  On t.idPago Equals p.idPago
							  Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And t.Fecha = Fecha
							  Select
								  Evento = t.NoEvento,
								  Carril = t.NoCarrilCapufe,
								  Clase = c.Clase,
								  Pago = p.NomPago,
								  Dictaminado = t.Dictaminado,
								  Liquidacion = t.idDictaminacion

			dgvEventos.DataSource = transaction.ToList()
            dgvEventos.Columns(0).Width = 60
            dgvEventos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(1).Width = 60
            dgvEventos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(2).Width = 60
            dgvEventos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(3).Width = 110
            dgvEventos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(4).Width = 100
            dgvEventos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(5).IsVisible = False

        End If

    End Sub

    Private Sub LlenarSeleccion()

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim FechaMetodo As Date = Fecha

        If NumTurno = 1 Then

			Dim transaction = From t In ctx.Transacciones
							  Join c In ctx.TipoVehiculo
								  On t.idVehiculo Equals c.idVehiculo
							  Join p In ctx.TipoPago
								  On t.idPago Equals p.idPago
							  Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And ((t.Fecha = FechaMetodo.AddDays(-1) And t.Hora > HoraA) Or (t.Fecha = FechaMetodo And t.Hora < HoraC)) And (t.idPago = IAVE Or t.idPago = VSC Or t.idPago = Residente Or t.idPago = Eludido Or t.idPago = Normal Or t.idPago = TarjetaC Or t.idPago = TarjetaD)
							  Select
								  Evento = t.NoEvento,
								  Carril = t.NoCarrilCapufe,
								  Clase = c.Clase,
								  Pago = p.NomPago,
								  Dictaminado = t.Dictaminado,
								  Liquidacion = t.idDictaminacion

			dgvEventos.DataSource = transaction.ToList()
            dgvEventos.Columns(0).Width = 60
            dgvEventos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(1).Width = 60
            dgvEventos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(2).Width = 60
            dgvEventos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(3).Width = 110
            dgvEventos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(4).Width = 100
            dgvEventos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(5).IsVisible = False

        Else

			Dim transaction = From t In ctx.Transacciones
							  Join c In ctx.TipoVehiculo
								  On t.idVehiculo Equals c.idVehiculo
							  Join p In ctx.TipoPago
								  On t.idPago Equals p.idPago
							  Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And t.Fecha = Fecha And (t.idPago = IAVE Or t.idPago = VSC Or t.idPago = Residente Or t.idPago = Eludido Or t.idPago = Normal Or t.idPago = TarjetaC Or t.idPago = TarjetaD)
							  Select
								  Evento = t.NoEvento,
								  Carril = t.NoCarrilCapufe,
								  Clase = c.Clase,
								  Pago = p.NomPago,
								  Dictaminado = t.Dictaminado,
								  Liquidacion = t.idDictaminacion

			dgvEventos.DataSource = transaction.ToList()
            dgvEventos.Columns(0).Width = 60
            dgvEventos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(1).Width = 60
            dgvEventos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(2).Width = 60
            dgvEventos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(3).Width = 110
            dgvEventos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(4).Width = 100
            dgvEventos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
            dgvEventos.Columns(5).IsVisible = False

        End If



    End Sub

    Private Sub Dictaminar()

        Dim ctx As New CLRDataContext()
        Dim num As Integer
        Dim num2 As Integer
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim FechaMetodo As Date = Fecha
        Dim numeroevento

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

            'Se valida si se aplica algun filtro
            If rbtnIAVE.IsChecked Or rbtnVSC.IsChecked Or rbtnEfectivo.IsChecked Or rbtnTarjeta.IsChecked Or rbtnResidentes.IsChecked Or rbtnEludidos.IsChecked Or rbtnTodos.IsChecked Then
                If NumTurno = 1 Then
                    numeroevento = From t In ctx.Transacciones
                                   Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And ((t.Fecha = FechaMetodo.AddDays(-1) And t.Hora > HoraA) Or (t.Fecha = FechaMetodo And t.Hora < HoraC)) And (t.Dictaminado = False Or t.Dictaminado Is Nothing) And (t.idPago = IAVE Or t.idPago = VSC Or t.idPago = Residente Or t.idPago = Eludido Or t.idPago = Normal Or t.idPago = TarjetaC Or t.idPago = TarjetaD)
                                   Select t
                Else
                    numeroevento = From t In ctx.Transacciones
                                   Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And t.Fecha = Fecha And (t.Dictaminado = False Or t.Dictaminado Is Nothing) And (t.idPago = IAVE Or t.idPago = VSC Or t.idPago = Residente Or t.idPago = Eludido Or t.idPago = Normal Or t.idPago = TarjetaC Or t.idPago = TarjetaD)
                                   Select t
                End If

            Else
                If NumTurno = 1 Then
                    numeroevento = From t In ctx.Transacciones
                                   Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And ((t.Fecha = FechaMetodo.AddDays(-1) And t.Hora > HoraA) Or (t.Fecha = FechaMetodo And t.Hora < HoraC)) And (t.Dictaminado = False Or t.Dictaminado Is Nothing)
                                   Select t
                Else
                    numeroevento = From t In ctx.Transacciones
                                   Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And t.Fecha = Fecha And (t.Dictaminado = False Or t.Dictaminado Is Nothing)
                                   Select t

                End If
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

                InsertarDictamen(num, index)
                num = num + 1

            Next

            'Se actualiza el grid
            If rbtnIAVE.IsChecked Or rbtnVSC.IsChecked Or rbtnEfectivo.IsChecked Or rbtnTarjeta.IsChecked Or rbtnResidentes.IsChecked Or rbtnEludidos.IsChecked Or rbtnTodos.IsChecked Then
                LlenarSeleccion()
            Else
                LLenarGrid()
            End If

            RadMessageBox.Show("Las transacciones seleccionadas se dictaminaron correctamente.", "Dictaminación Existosa", MessageBoxButtons.OK, RadMessageIcon.Info)

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
        liquidacion.NuevaTarifa = NewTarif(ListaClases.Items(Index))

        ctx.Dictaminaciones.InsertOnSubmit(liquidacion)
        ctx.SubmitChanges()

    End Sub

    Private Function NewTarif(Clase As Integer)

        Dim ctx As New CLRDataContext()

		Dim tarif = (From t In ctx.Tarifas
					 Where t.NoPlaza = NumPlaza And t.idVehiculo = Clase
					 Select t.Tarifa).SingleOrDefault()

		Return tarif

    End Function

    Private Function ExistenDatos() As Boolean

        Dim ctx As New CLRDataContext()

        Dim numeroevento = (From t In ctx.Transacciones
                            Where t.NoPlaza = NumPlaza And t.idTurno = NumTurno And t.NoCarrilCapufe = Carril And t.Fecha = Fecha
                            Select t.idTransaccion).Count

        If numeroevento = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

#End Region

#Region "Events"

    Private Sub ddlPlaza_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlPlaza.SelectedIndexChanged

        CargarCarriles(ddlPlaza.SelectedValue)

    End Sub

    Private Sub btnDictaminar_Click(sender As Object, e As EventArgs) Handles btnDictaminar.Click

        If RadMessageBox.Show("Esta por hacer una dictaminación multiple, desea continuar?", "Atención", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then
            Dictaminar()
        End If


    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        NumPlaza = ddlPlaza.SelectedValue
        NumTurno = ddlTurno.SelectedValue
        Carril = ddlCarril.SelectedValue
        Fecha = dtpFecha.SelectedDate

        If dtpFecha.SelectedDate > Date.Now.Date Then
            RadMessageBox.Show("La fecha seleccionada no es valida.", "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            If ExistenDatos() = True Then
                gpbFiltros.Enabled = True
                LLenarGrid()
                lblTitulo.Text = ddlPlaza.Text + "    " + (Format(dtpFecha.SelectedDate, "dd/mm/yyyy")).ToString()
                rbtnIAVE.CheckState = False
                rbtnVSC.CheckState = False
                rbtnEfectivo.CheckState = False
                rbtnTarjeta.CheckState = False
                rbtnResidentes.CheckState = False
                rbtnEludidos.CheckState = False
                rbtnTodos.CheckState = False
            Else
                RadMessageBox.Show("No hay datos para los parametros establecidos.", "No Existen Datos", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If
        End If

    End Sub

#Region "RadioButtons"

    Private Sub rbtnIAVE_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbtnIAVE.ToggleStateChanged

        If rbtnIAVE.IsChecked Then
            IAVE = 15
            LlenarSeleccion()
        Else
            IAVE = 0
            LLenarGrid()
        End If

    End Sub

    Private Sub rbtnVSC_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbtnVSC.ToggleStateChanged

        If rbtnVSC.IsChecked Then
            VSC = 27
            LlenarSeleccion()
        Else
            VSC = 0
            LLenarGrid()
        End If

    End Sub

    Private Sub rbtnEfectivo_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbtnEfectivo.ToggleStateChanged

        If rbtnEfectivo.IsChecked Then
            Normal = 1
            LlenarSeleccion()
        Else
            Normal = 0
        End If

    End Sub

    Private Sub rbtnTarjeta_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbtnTarjeta.ToggleStateChanged

        If rbtnTarjeta.IsChecked Then
            TarjetaC = 12
            TarjetaD = 14
            LlenarSeleccion()
        Else
            TarjetaC = 0
            TarjetaD = 0
        End If

    End Sub

    Private Sub rbtnResidentes_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbtnResidentes.ToggleStateChanged

        If rbtnResidentes.IsChecked Then
            Residente = 4
            LlenarSeleccion()
        Else
            Residente = 0
        End If

    End Sub

    Private Sub rbtnEludidos_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbtnEludidos.ToggleStateChanged

        If rbtnEludidos.IsChecked Then
            Eludido = 13
            LlenarSeleccion()
        Else
            Eludido = 0
        End If

    End Sub

    Private Sub rbtnTodos_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbtnTodos.ToggleStateChanged

        If rbtnTodos.IsChecked Then
            LLenarGrid()
        End If

    End Sub

#End Region

#End Region

End Class
