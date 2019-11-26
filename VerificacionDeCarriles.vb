
Imports Telerik.WinControls
''' <summary>
''' Formulario VerificacionCarriles
''' Muestra la 
''' actividad de los carriles
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @31/03/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>
Public Class VerificacionDeCarriles

#Region "Variables"

    Dim Via As String
    Dim contador As Integer = 0
    Dim contador1 As Integer = 0
    Dim NombreAL As String
    Dim FechaL As String
    Dim HoraL As String

#End Region

    Private Sub VerificacionDeCarriles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)

        Formulario = "Carriles"


        lblPlaza.Text = NomC
        lblF.Text = fechaC

        dgvInfoCarriles.ReadOnly = True
        ddlTurno.Enabled = False
        ddlTurno.Text = "Seleccione Turno..."
        ddlTipoO.Enabled = False
        ddlTipoO.Text = "Seleccione Tipo..."
        dtpFecha.Value = fechaC
        lblSinEventos.Visible = False

        CargarCarriles()
        CargarListaPlazas()

    End Sub

#Region "Methods"

    Private Sub CargarCarriles()

        Dim db As New CLRDataContext()

		Dim carriles = From c In db.CatalogoCarriles
					   Join t In db.TipoCarril
						   On c.idTipoCarril Equals t.idTipoCarril
					   Where c.idPlaza = plazaC
					   Order By c.Carril
					   Select
						   Número = c.Carril.ToString(),
						   Tipo = t.Tipo,
						   Descripción = t.NomCarril


		dgvCarriles.DataSource = carriles.ToList()
        dgvCarriles.Columns(0).Width = 65
        dgvCarriles.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvCarriles.Columns(1).Width = 55
        dgvCarriles.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvCarriles.Columns(2).Width = 170
        dgvCarriles.Columns(2).TextAlignment = ContentAlignment.MiddleCenter

    End Sub

    Private Sub CargarTransacciones()

        Dim db As New CLRDataContext()

        Dim eventos = From e In db.Transacciones
                      Join p In db.Plazas
                          On e.NoPlaza Equals p.NoPlaza
                      Join t In db.Turnos
                          On e.idTurno Equals t.idTurno
                      Join f In db.TipoPago
                          On e.idPago Equals f.idPago
                      Join tv In db.TipoVehiculo
                          On e.idVehiculo Equals tv.idVehiculo
                      Where e.NoCarrilCapufe = Via And e.Fecha = fechaC And e.NoPlaza = NumeroPlaza
                      Order By e.NoEvento
                      Select
                          Evento = e.NoEvento.ToString(),
                          Carril = e.NoCarrilCapufe.ToString(),
                          Cajero = e.NoEmpleadoCapufe,
                          Plaza = p.NomPlaza,
                          Turno = t.Turno,
                          Pago = f.NomPago,
                          Tarifas = Format(e.idTarifa, "###0.00"),
                          Folio = e.Folio.ToString(),
                          PRE = e.PRE,
                          POST = e.POST,
                          ClaseCR = tv.Clase,
                          Fecha = Format(e.Fecha, "dd/MM/yyyy"),
                          Hora = e.Hora,
                          NumLiqui = e.idDictaminacion

        dgvInfoCarriles.DataSource = eventos.ToList()

        dgvInfoCarriles.Columns(0).Width = 55
        dgvInfoCarriles.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(1).Width = 55
        dgvInfoCarriles.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(2).Width = 150
        dgvInfoCarriles.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(3).Width = 100
        dgvInfoCarriles.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(4).Width = 100
        dgvInfoCarriles.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(5).Width = 115
        dgvInfoCarriles.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(6).Width = 60
        dgvInfoCarriles.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(7).Width = 70
        dgvInfoCarriles.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(8).Width = 60
        dgvInfoCarriles.Columns(8).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(9).Width = 60
        dgvInfoCarriles.Columns(9).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(10).Width = 60
        dgvInfoCarriles.Columns(10).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(11).Width = 100
        dgvInfoCarriles.Columns(11).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(12).Width = 80
        dgvInfoCarriles.Columns(12).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(13).IsVisible = False

    End Sub

    Private Sub CargarTurnos()

        Dim db As New CLRDataContext()

		Dim query = From q In db.Transacciones
					Join t In db.Turnos
						On q.idTurno Equals t.idTurno
					Where q.NoCarrilCapufe = Via And q.Fecha = fechaC
					Order By t.Turno
					Select t.Turno

		ddlTurno.DataSource = query.ToList().Distinct()

    End Sub

    Private Sub CargarTipos()

        Dim db As New CLRDataContext()

		Dim query = From q In db.Transacciones
					Join t In db.TipoPago
						On q.idPago Equals t.idPago
					Where q.NoCarrilCapufe = Via And q.Fecha = fechaC
					Order By t.NomPago
					Select t.NomPago

		ddlTipoO.DataSource = query.ToList().Distinct()

    End Sub

    Private Sub FiltrarTurno()

        Dim db As New CLRDataContext()

		Dim eventos = From e In db.Transacciones
					  Join p In db.Plazas
						  On e.NoPlaza Equals p.NoPlaza
					  Join t In db.Turnos
						  On e.idTurno Equals t.idTurno
					  Join f In db.TipoPago
						  On e.idPago Equals f.idPago
					  Join tv In db.TipoVehiculo
						  On e.idVehiculo Equals tv.idVehiculo
					  Where e.NoCarrilCapufe = Via And e.Fecha = fechaC And t.Turno = ddlTurno.SelectedValue.ToString()
					  Order By e.NoEvento
					  Select
						  Evento = e.NoEvento.ToString(),
						  Carril = e.NoCarrilCapufe.ToString(),
						  Cajero = e.NoEmpleadoCapufe,
						  Plaza = p.NomPlaza,
						  Turno = t.Turno,
						  Pago = f.NomPago,
						  Tarifas = Format(e.idTarifa, "###0.00"),
						  Folio = e.Folio.ToString(),
						  PRE = e.PRE,
						  POST = e.POST,
						  ClaseCR = e.idVehiculo,
						  Fecha = Format(e.Fecha, "dd/MM/yyyy"),
						  Hora = e.Hora

		dgvInfoCarriles.DataSource = eventos.ToList()
        dgvInfoCarriles.Columns(0).Width = 55
        dgvInfoCarriles.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(1).Width = 55
        dgvInfoCarriles.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(2).Width = 150
        dgvInfoCarriles.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(3).Width = 100
        dgvInfoCarriles.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(4).Width = 100
        dgvInfoCarriles.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(5).Width = 80
        dgvInfoCarriles.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(6).Width = 60
        dgvInfoCarriles.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(7).Width = 70
        dgvInfoCarriles.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(8).Width = 60
        dgvInfoCarriles.Columns(8).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(9).Width = 60
        dgvInfoCarriles.Columns(9).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(10).Width = 60
        dgvInfoCarriles.Columns(10).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(11).Width = 100
        dgvInfoCarriles.Columns(11).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(12).Width = 80
        dgvInfoCarriles.Columns(12).TextAlignment = ContentAlignment.MiddleCenter

    End Sub

    Private Sub FiltrarTipo()

        Dim db As New CLRDataContext()

		Dim eventos = From e In db.Transacciones
					  Join p In db.Plazas
						  On e.NoPlaza Equals p.NoPlaza
					  Join t In db.Turnos
						  On e.idTurno Equals t.idTurno
					  Join f In db.TipoPago
						  On e.idPago Equals f.idPago
					  Join tv In db.TipoVehiculo
						  On e.idVehiculo Equals tv.idVehiculo
					  Where e.NoCarrilCapufe = Via And e.Fecha = fechaC And f.NomPago = ddlTipoO.SelectedValue.ToString()
					  Order By e.NoEvento
					  Select
						  Evento = e.NoEvento.ToString(),
						  Carril = e.NoCarrilCapufe.ToString(),
						  Cajero = e.NoEmpleadoCapufe,
						  Plaza = p.NomPlaza,
						  Turno = t.Turno,
						  Pago = f.NomPago,
						  Tarifas = Format(e.idTarifa, "###0.00"),
						  Folio = e.Folio.ToString(),
						  PRE = e.PRE,
						  POST = e.POST,
						  ClaseCR = tv.Clase,
						  Fecha = Format(e.Fecha, "dd/MM/yyyy"),
						  Hora = e.Hora,
						  NumLiqui = e.idDictaminacion

		dgvInfoCarriles.DataSource = eventos.ToList()
        dgvInfoCarriles.Columns(0).Width = 55
        dgvInfoCarriles.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(1).Width = 55
        dgvInfoCarriles.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(2).Width = 150
        dgvInfoCarriles.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(3).Width = 100
        dgvInfoCarriles.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(4).Width = 100
        dgvInfoCarriles.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(5).Width = 115
        dgvInfoCarriles.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(6).Width = 60
        dgvInfoCarriles.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(7).Width = 70
        dgvInfoCarriles.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(8).Width = 60
        dgvInfoCarriles.Columns(8).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(9).Width = 60
        dgvInfoCarriles.Columns(9).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(10).Width = 60
        dgvInfoCarriles.Columns(10).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(11).Width = 100
        dgvInfoCarriles.Columns(11).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(12).Width = 80
        dgvInfoCarriles.Columns(12).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(13).IsVisible = False

    End Sub

    Private Sub BuscarTransaccion()

        Dim db As New CLRDataContext()

		Dim query = From e In db.Transacciones
					Join p In db.Plazas
						  On e.NoPlaza Equals p.NoPlaza
					Join t In db.Turnos
						  On e.idTurno Equals t.idTurno
					Join f In db.TipoPago
						  On e.idPago Equals f.idPago
					Join tv In db.TipoVehiculo
						  On e.idVehiculo Equals tv.idVehiculo
					Where e.NoCarrilCapufe = Via And e.Fecha = fechaC And e.NoEvento = Integer.Parse(txtNoCarril.Text)
					Order By e.NoEvento
					Select
						  Evento = e.NoEvento.ToString(),
						  Carril = e.NoCarrilCapufe.ToString(),
						  Cajero = e.NoEmpleadoCapufe,
						  Plaza = p.NomPlaza,
						  Turno = t.Turno,
						  Pago = f.NomPago,
						  Tarifas = Format(e.idTarifa, "###0.00"),
						  Folio = e.Folio.ToString(),
						  PRE = e.PRE,
						  POST = e.POST,
						  ClaseCR = e.idVehiculo,
						  Fecha = Format(e.Fecha, "dd/MM/yyyy"),
						  Hora = e.Hora


		dgvInfoCarriles.DataSource = query.ToList()
        dgvInfoCarriles.Columns(0).Width = 55
        dgvInfoCarriles.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(1).Width = 55
        dgvInfoCarriles.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(2).Width = 150
        dgvInfoCarriles.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(3).Width = 100
        dgvInfoCarriles.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(4).Width = 100
        dgvInfoCarriles.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(5).Width = 80
        dgvInfoCarriles.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(6).Width = 60
        dgvInfoCarriles.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(7).Width = 70
        dgvInfoCarriles.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(8).Width = 60
        dgvInfoCarriles.Columns(8).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(9).Width = 60
        dgvInfoCarriles.Columns(9).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(10).Width = 60
        dgvInfoCarriles.Columns(10).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(11).Width = 100
        dgvInfoCarriles.Columns(11).TextAlignment = ContentAlignment.MiddleCenter
        dgvInfoCarriles.Columns(12).Width = 80
        dgvInfoCarriles.Columns(12).TextAlignment = ContentAlignment.MiddleCenter

    End Sub

    Private Sub Cambiar()

        Dim db As New CLRDataContext()

        Dim carriles = From c In db.CatalogoCarriles
                       Join t In db.TipoCarril
                           On c.idTipoCarril Equals t.idTipoCarril
                       Where c.idPlaza = Integer.Parse(ddlPlaza1.SelectedValue)
                       Order By c.Carril
                       Select
                           Número = c.Carril.ToString(),
                           Tipo = t.Tipo,
                           Descripción = t.NomCarril

        dgvCarriles.DataSource = carriles.ToList()
        dgvCarriles.Columns(0).Width = 65
        dgvCarriles.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvCarriles.Columns(1).Width = 55
        dgvCarriles.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvCarriles.Columns(2).Width = 170
        dgvCarriles.Columns(2).TextAlignment = ContentAlignment.MiddleCenter

    End Sub

    Private Sub CargarListaPlazas()

        Dim ctx As New CLRDataContext

		Dim caseta = From c In ctx.Plazas
					 Order By c.NomPlaza
					 Select
						 Numero = c.NoPlaza,
						 Plaza = c.NomPlaza

		ddlPlaza1.ValueMember = "Numero"
        ddlPlaza1.DisplayMember = "Plaza"
        ddlPlaza1.DataSource = caseta.ToList()

    End Sub

    Private Function ExisteTransaccion(Numero As String) As Boolean

        Dim db As New CLRDataContext()

        Dim existe = (From e In db.Transacciones
                      Where e.NoEvento = Integer.Parse(Numero) And e.NoCarrilCapufe = dgvCarriles.CurrentRow.Cells(0).Value.ToString()
                      Select e.NoEvento).Count()

        If existe > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function ExistenEventos(Numero As String) As Boolean

        Dim db As New CLRDataContext()

        Dim existe = (From e In db.Transacciones
                      Where e.NoCarrilCapufe = Numero And e.Fecha = dtpFecha.Text
                      Select e).FirstOrDefault()

        If existe Is Nothing OrElse existe.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function EstaLiquidado(Numero As Integer) As Boolean

        Dim db As New CLRDataContext()

        Dim query = (From q In db.Dictaminaciones
                     Where q.idDictaminacion = Numero
                     Select q.idDictaminacion).Count()

        If query = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub DetallesEvento()

        Dim db As New CLRDataContext()
        Dim NoE As Integer

        Dim num = (From n In db.Dictaminaciones
                   Where n.idDictaminacion = Integer.Parse(dgvInfoCarriles.CurrentRow.Cells(13).Value)
                   Select n.NoEmpleadoCapufe).SingleOrDefault()

        NoE = num

        Dim name = (From a In db.PersonalCLR
                    Where a.NoEmpleadoCapufe = NoE
                    Select a.Nombre).SingleOrDefault()

        Dim paterno = (From p In db.PersonalCLR
                       Where p.NoEmpleadoCapufe = NoE
                       Select p.APaterno).SingleOrDefault()

        Dim materno = (From m In db.PersonalCLR
                       Where m.NoEmpleadoCapufe = NoE
                       Select m.AMaterno).SingleOrDefault()

        NombreAL = name + " " + paterno + " " + materno

        Dim dia = (From d In db.Dictaminaciones
                   Where d.idDictaminacion = Integer.Parse(dgvInfoCarriles.CurrentRow.Cells(13).Value)
                   Select Format(d.Fecha, "dd/MM/yyyy")).SingleOrDefault()

        FechaL = dia.ToString()

        Dim query = (From h In db.Dictaminaciones
                     Where h.idDictaminacion = Integer.Parse(dgvInfoCarriles.CurrentRow.Cells(13).Value)
                     Select h.Hora).SingleOrDefault()

        HoraL = query.ToString()

    End Sub

    Private Sub LimpiarInfoEvento()

        lblNoEvento.Text = ""
        lblNombre.Text = ""
        lblFecha.Text = ""
        lblHora.Text = ""
        lblSinLiquidar.Text = ""

    End Sub

#End Region

#Region "Events"

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If txtNoCarril.Text = "" Then
            TipoAlerta = "OK"
            TituloAlerta = "ATENCION!"
            MensajeAlerta1 = "Debe ingresar una busqueda."
            MensajeAlerta2 = ""
            Alertas.Show()
        Else
            If ExisteTransaccion(txtNoCarril.Text) = True Then
                BuscarTransaccion()
                LimpiarInfoEvento()
                txtNoCarril.Text = ""
                chkTurno.Checked = False
                chkTipoO.Checked = False
            Else
                TipoAlerta = "OK"
                TituloAlerta = "VERIFIQUE!"
                MensajeAlerta1 = "El número de transaccion ingresado no existe!"
                MensajeAlerta2 = ""
                Alertas.Show()
            End If
        End If

    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click

        fechaC = dtpFecha.Text
        dgvInfoCarriles.DataSource = ""
        chkTurno.Checked = False
        chkTipoO.Checked = False
        lblPlaza.Text = ddlPlaza1.SelectedItem.ToString
        lblF.Text = dtpFecha.Text
        NumeroPlaza = ddlPlaza1.SelectedValue
        Cambiar()
        LimpiarInfoEvento()

    End Sub

    Private Sub txtNoCarril_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoCarril.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Solo se permiten numeros.", "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            e.Handled = True
            Return
        End If

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnBuscar.PerformClick()
        End If

    End Sub

    Private Sub dgvCarriles_Click(sender As Object, e As EventArgs) Handles dgvCarriles.Click

        Via = dgvCarriles.CurrentRow.Cells(0).Value
        If ExistenEventos(Via) = True Then
            lblSinEventos.Visible = False
            chkTipoO.Checked = False
            chkTurno.Checked = False
            CargarTransacciones()
            LimpiarInfoEvento()
        Else
            lblSinEventos.Visible = True
            dgvInfoCarriles.DataSource = ""
            RadMessageBox.Show("No hay eventos para el carril seleccionado.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Info)
        End If

    End Sub

    Private Sub chkTruno_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkTurno.ToggleStateChanged

        If chkTurno.Checked = True Then
            ddlTurno.Enabled = True
            chkTipoO.Checked = False
            CargarTurnos()
        Else
            CargarTransacciones()
            ddlTurno.Enabled = False
            ddlTurno.Text = "Seleccione Turno..."
        End If

    End Sub

    Private Sub chkTipoO_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkTipoO.ToggleStateChanged

        If chkTipoO.Checked = True Then
            ddlTipoO.Enabled = True
            chkTurno.Checked = False
            CargarTipos()
        Else
            CargarTransacciones()
            ddlTipoO.Enabled = False
            ddlTipoO.Text = "Seleccione Tipo..."
        End If

    End Sub

    Private Sub ddlTurno_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlTurno.SelectedIndexChanged

        If contador > 0 Then
            If ddlTurno.SelectedIndex >= 0 Then
                FiltrarTurno()
                LimpiarInfoEvento()
            End If
        End If
        contador = contador + 1

    End Sub

    Private Sub ddlTipoO_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlTipoO.SelectedIndexChanged

        If contador1 > 0 Then
            If ddlTipoO.SelectedIndex >= 0 Then
                FiltrarTipo()
                LimpiarInfoEvento()
            End If
        End If
        contador1 = contador1 + 1

    End Sub

    Private Sub dgvInfoCarriles_CellClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvInfoCarriles.CellClick

        If (dgvInfoCarriles.CurrentRow.Cells(13).Value) Is Nothing Then
            lblNoEvento.Text = ""
            lblNombre.Text = ""
            lblFecha.Text = ""
            lblHora.Text = ""
            lblSinLiquidar.Text = "Evento sin Dictaminar"
        Else
            If EstaLiquidado(Integer.Parse(dgvInfoCarriles.CurrentRow.Cells(13).Value)) Then
                lblSinLiquidar.Text = ""
                lblNoEvento.Text = "Evento Número: " + dgvInfoCarriles.CurrentRow.Cells(0).Value.ToString()
                DetallesEvento()
                lblNombre.Text = "Dictaminó: " + NombreAL
                lblFecha.Text = "Fecha de Dictaminación: " + FechaL
                lblHora.Text = "Hora de Dictaminación: " + HoraL.Split(".")(0)
            Else
                lblNoEvento.Text = ""
                lblNombre.Text = ""
                lblFecha.Text = ""
                lblHora.Text = ""
                lblSinLiquidar.Text = "Evento sin Dictaminar"
            End If
        End If

    End Sub

    Private Sub btnRestablecer_Click(sender As Object, e As EventArgs) Handles btnRestablecer.Click

        chkTurno.Checked = False
        chkTipoO.Checked = False
        CargarTransacciones()

    End Sub

#Region "Ayudas"

    Private Sub btnCarriles_Click(sender As Object, e As EventArgs)
        Identificador = 1
        Help.Show()
    End Sub

    Private Sub btnCambio_Click(sender As Object, e As EventArgs)
        Identificador = 2
        Help.Show()
    End Sub

    Private Sub btnEventos_Click(sender As Object, e As EventArgs)
        Identificador = 3
        Help.Show()
    End Sub

    Private Sub btnInfoEvento_Click(sender As Object, e As EventArgs)
        Identificador = 4
        Help.Show()
    End Sub

    Private Sub btnFiltro_Click(sender As Object, e As EventArgs)
        Identificador = 5
        Help.Show()
    End Sub

#End Region

#End Region

End Class