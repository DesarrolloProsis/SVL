
Imports System.Globalization
Imports Telerik.WinControls
''' <summary>
''' Formulario Cortes
''' Muestra información
''' acerca de las declaraciones 
''' hechas en los cortes
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @05/04/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>
Public Class VerificacionDeCortes

#Region "Variables"

    Dim NumCajero As Integer
    Dim numC As Integer
    Dim numE As Integer
    Dim numA As Integer
    Dim EfectivoE As Integer
    Dim EfectivoM As Integer
    Dim bandera As Integer = 0
    Dim activo As Boolean = False
    Dim activo1 As Boolean = False
    Dim contador As Integer = 0

    Dim Carril As String = ""
    Dim HoraApertura As TimeSpan
    Dim HoraCierre As TimeSpan
    Dim idTurno As Integer

#End Region

    Private Sub VerificacionDeCortes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        Formulario = "Cortes"

        gpbCortes.Text = NomCaseta
        dgvBolsas.ReadOnly = True
        ddlTruno.Enabled = False
        ddlCarril.Enabled = False
        ddlTruno.Text = ""
        ddlCarril.Text = ""
        CargarCortes()

    End Sub

#Region "Methods"

    Private Sub CargarCortes()

        Dim ctx As New CLRDataContext

        Dim cortes = From c In ctx.Declaraciones
                     Join t In ctx.Turnos
                         On c.idTurno Equals t.idTurno
                     Join d In ctx.PersonalPlaza
                         On c.Cajero Equals d.NoEmpleadoCapufe
                     Where c.Fecha = dato1 And c.NoPlaza = Integer.Parse(idCaseta)
                     Select
                         Declaracion = c.NoDeclaracion,
                         Bolsa = c.Bolsa,
                         Fecha = Format(c.Fecha, "dd/MM/yyyy"),
                         Turno = t.Turno,
                         Carril = c.NoCarrilCapufe,
                         NoEmpleado = c.Cajero,
                         Cajero = d.Nombre + " " + d.Apellidos,
                         Apertura = c.HoraApertura,
                         Cierre = c.HoraCierre

        dgvBolsas.DataSource = cortes.ToList()
        dgvBolsas.Columns(1).Width = 75
        dgvBolsas.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(2).Width = 85
        dgvBolsas.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(3).Width = 85
        dgvBolsas.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(4).Width = 50
        dgvBolsas.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(5).Width = 90
        dgvBolsas.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(6).Width = 250
        dgvBolsas.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(7).IsVisible = False
        dgvBolsas.Columns(8).IsVisible = False

        dgvBolsas.Columns(0).IsVisible = False

    End Sub
    
    Private Sub CalcularDiferencias()

        Dim DifereciaE As Integer

        DifereciaE = Format(EfectivoE - EfectivoM, "###0.00")

    End Sub

    Private Sub Buscar()

        Dim ctx As New CLRDataContext()

        Dim busqueda = From c In ctx.Declaraciones
                       Join e In ctx.PersonalPlaza
                         On c.Cajero Equals e.NoEmpleadoCapufe
                       Join t In ctx.Turnos
                         On c.idTurno Equals t.idTurno
                       Where c.Bolsa = txtBuscar.Text.ToUpper() And c.Fecha = dato1 And c.NoPlaza = NumeroCaseta
                       Select
                              Declaracion = c.NoDeclaracion,
                              Bolsa = c.Bolsa,
                              Fecha = Format(c.Fecha, "dd/MM/yyyy"),
                              Turno = t.Turno,
                              Carril = c.NoCarrilCapufe,
                              NoEmpleado = c.Cajero,
                              Cajero = e.Nombre + " " + e.Apellidos

        dgvBolsas.DataSource = busqueda.ToList()
        dgvBolsas.Columns(1).Width = 75
        dgvBolsas.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(2).Width = 85
        dgvBolsas.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(3).Width = 85
        dgvBolsas.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(4).Width = 50
        dgvBolsas.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(5).Width = 90
        dgvBolsas.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
        dgvBolsas.Columns(6).Width = 250
        dgvBolsas.Columns(6).TextAlignment = ContentAlignment.MiddleCenter

        dgvBolsas.Columns(0).IsVisible = False

    End Sub

    Private Sub CargarTurnos()

        Dim ctx As New CLRDataContext

		Dim horas = From t In ctx.Turnos
					Join d In ctx.Declaraciones
						On t.idTurno Equals d.idTurno
					Where d.Fecha = dato1
					Select
						ID = t.idTurno,
						Nombre = t.Turno

		ddlTruno.ValueMember = "ID"
        ddlTruno.DisplayMember = "Nombre"

        ddlTruno.DataSource = horas.Distinct.ToList()

    End Sub

    Private Sub CargarCarriles()

        Dim ctx As New CLRDataContext

		Dim vias = From c In ctx.CatalogoCarriles
				   Join d In ctx.Declaraciones
					   On c.idPlaza Equals d.NoPlaza
				   Where c.idPlaza = NumeroCaseta And d.Fecha = dato1
				   Select
					   ID = c.idCarril,
					   Nombre = c.Carril

		ddlCarril.ValueMember = "ID"
        ddlCarril.DisplayMember = "Nombre"

        ddlCarril.DataSource = vias.Distinct.ToList()

    End Sub

    Private Sub FiltrarTurnos()

        Dim ctx As New CLRDataContext

		Dim validar = (From c In ctx.Declaraciones
					   Join e In ctx.PersonalPlaza
						 On c.Cajero Equals e.NoEmpleadoCapufe
					   Join t In ctx.Turnos
						 On c.idTurno Equals t.idTurno
					   Join n In ctx.CatalogoCarriles
						 On c.NoCarrilCapufe Equals n.Carril
					   Join p In ctx.Plazas
						 On n.idPlaza Equals p.NoPlaza
					   Join d In ctx.Tramo
						 On p.idTramo Equals d.idTramo
					   Where t.Turno = ddlTruno.Text And c.Fecha = dato1 And p.NomPlaza = NomCaseta
					   Order By c.NoDeclaracion
					   Select c.Bolsa).Count()

		If validar > 0 Then
			Dim cortes = From c In ctx.Declaraciones
						 Join e In ctx.PersonalPlaza
							 On c.Cajero Equals e.NoEmpleadoCapufe
						 Join t In ctx.Turnos
							 On c.idTurno Equals t.idTurno
						 Join n In ctx.CatalogoCarriles
							 On c.NoCarrilCapufe Equals n.Carril
						 Join p In ctx.Plazas
							 On n.idPlaza Equals p.NoPlaza
						 Join d In ctx.Tramo
							 On p.idTramo Equals d.idTramo
						 Where t.Turno = ddlTruno.Text And c.Fecha = dato1 And p.NomPlaza = NomCaseta
						 Order By c.NoDeclaracion
						 Select
							 Declaracion = c.NoDeclaracion,
							 Bolsa = c.Bolsa,
							 Fecha = Format(c.Fecha, "dd/MM/yyyy"),
							 Turno = t.Turno,
							 Carril = c.NoCarrilCapufe,
							 NoEmpleado = c.Cajero,
							 Cajero = e.Nombre + " " + e.Apellidos

			dgvBolsas.DataSource = cortes.ToList()
            dgvBolsas.Columns(1).Width = 75
            dgvBolsas.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(2).Width = 85
            dgvBolsas.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(3).Width = 85
            dgvBolsas.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(4).Width = 50
            dgvBolsas.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(5).Width = 90
            dgvBolsas.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(6).Width = 250
            dgvBolsas.Columns(6).TextAlignment = ContentAlignment.MiddleCenter

            dgvBolsas.Columns(0).IsVisible = False
        Else
            MessageBox.Show("No existen datos para los parametros seleccionados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub FiltrarCarril()

        Dim ctx As New CLRDataContext

		Dim validar = (From c In ctx.Declaraciones
					   Join e In ctx.PersonalPlaza
						 On c.Cajero Equals e.NoEmpleadoCapufe
					   Join t In ctx.Turnos
						 On c.idTurno Equals t.idTurno
					   Join n In ctx.CatalogoCarriles
						 On c.NoCarrilCapufe Equals n.Carril
					   Join p In ctx.Plazas
						 On n.idPlaza Equals p.NoPlaza
					   Join d In ctx.Tramo
						 On p.idTramo Equals d.idTramo
					   Where c.NoCarrilCapufe = ddlCarril.SelectedText.ToString() And c.Fecha = dato1 And p.NomPlaza = NomCaseta
					   Order By c.NoDeclaracion
					   Select c.Bolsa).Count()

		If validar > 0 Then
			Dim cortes = From c In ctx.Declaraciones
						 Join e In ctx.PersonalPlaza
							 On c.Cajero Equals e.NoEmpleadoCapufe
						 Join t In ctx.Turnos
							 On c.idTurno Equals t.idTurno
						 Join n In ctx.CatalogoCarriles
							 On c.NoCarrilCapufe Equals n.Carril
						 Join p In ctx.Plazas
							 On n.idPlaza Equals p.NoPlaza
						 Join d In ctx.Tramo
							 On p.idTramo Equals d.idTramo
						 Where c.NoCarrilCapufe = ddlCarril.SelectedText.ToString() And c.Fecha = dato1 And p.NomPlaza = NomCaseta
						 Order By c.NoDeclaracion
						 Select
							 Declaracion = c.NoDeclaracion,
							 Bolsa = c.Bolsa,
							 Fecha = Format(c.Fecha, "dd/MM/yyyy"),
							 Turno = t.Turno,
							 Carril = c.NoCarrilCapufe,
							 NoEmpleado = c.Cajero,
							 Cajero = e.Nombre + " " + e.Apellidos

			dgvBolsas.DataSource = cortes.ToList()
            dgvBolsas.Columns(1).Width = 75
            dgvBolsas.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(2).Width = 85
            dgvBolsas.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(3).Width = 85
            dgvBolsas.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(4).Width = 50
            dgvBolsas.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(5).Width = 90
            dgvBolsas.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
            dgvBolsas.Columns(6).Width = 250
            dgvBolsas.Columns(6).TextAlignment = ContentAlignment.MiddleCenter

            dgvBolsas.Columns(0).IsVisible = False
        Else
            MessageBox.Show("No existen datos para los parametros seleccionados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Function Existe(bolsa As String) As Boolean

        Dim ctx As New CLRDataContext()

        Dim query = (From q In ctx.Declaraciones
                     Join e In ctx.PersonalPlaza
                         On q.Cajero Equals e.NoEmpleadoCapufe
                     Join t In ctx.Turnos
                         On q.idTurno Equals t.idTurno
                     Join n In ctx.CatalogoCarriles
                         On q.NoCarrilCapufe Equals n.Carril
                     Join p In ctx.Plazas
                         On n.idPlaza Equals p.NoPlaza
                     Join d In ctx.Tramo
                         On p.idTramo Equals d.idTramo
                     Where q.Bolsa = bolsa And q.Fecha = dato1 And p.NomPlaza = NomCaseta
                     Select q).SingleOrDefault()

        If query Is Nothing OrElse query.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub LlenarEncabezado(idDeclaracion As String)

        Dim ctx As New CLRDataContext()

        lblBolsa.Text = "Bolsa:"
        lblPlaza.Text = "Plaza:"
        lblNoCarril.Text = "Carril:"
        lblHoraInicial.Text = "Hora inicial:"
        lblHoraFinal.Text = "Hora final:"
        lblNoTurno.Text = "Turno:"
        lblComentarios.Text = ""
        lblComentarios2.Text = ""

        lblBolsa.Text += "  " + dgvBolsas.CurrentRow.Cells(1).Value.ToString()
        lblNoCarril.Text += "  " + dgvBolsas.CurrentRow.Cells(4).Value.ToString()
        lblNoTurno.Text += "  " + dgvBolsas.CurrentRow.Cells(3).Value.ToString()

        Dim bolsa = (From d In ctx.Declaraciones
                     Join p In ctx.Plazas
                             On d.NoPlaza Equals p.NoPlaza
                     Where d.NoDeclaracion = idDeclaracion
                     Select p.NomPlaza).SingleOrDefault()

        lblPlaza.Text += "  " + bolsa.ToString()

        Dim horaInicio = (From i In ctx.Declaraciones
                          Where i.NoDeclaracion = idDeclaracion
                          Select i.HoraApertura).SingleOrDefault()

        lblHoraInicial.Text += "  " + horaInicio.ToString()

        Dim horaFinal = (From f In ctx.Declaraciones
                         Where f.NoDeclaracion = idDeclaracion
                         Select f.HoraCierre).SingleOrDefault()

        lblHoraFinal.Text += "  " + horaFinal.ToString()

        Dim comen = (From c In ctx.Declaraciones
                     Where c.NoDeclaracion = idDeclaracion
                     Select c.Comentarios).SingleOrDefault()

        If (comen.ToString()).Length() < 100 Then
            lblComentarios.Text += comen.ToString()
        Else
            Dim longitud As Integer = (comen.ToString()).Length()
            Dim uno As Integer = (longitud / 2)
            lblComentarios.Text = (comen.ToString()).Substring(0, (longitud / 2))
            lblComentarios2.Text = (comen.ToString()).Substring((longitud / 2), (longitud / 2) - 1)
        End If

    End Sub

    Private Sub ObtenerDatos(idDeclaracion As String)

        Dim ctx As New CLRDataContext()

        lblEfectivo.Text = "Efectivo:"
        lblIAVE1.Text = "IAVE:"
        lblVSC1.Text = "VSC:"
        lblTDC1.Text = "TDC:"
        lblTDD1.Text = "TDD:"
        lblEludido.Text = "Eludido:"
        lblTotalVehiculos.Text = "Trafico Total:"

        Select Case dgvBolsas.CurrentRow.Cells(3).Value.ToString()
            Case "22:00-06:00"
                idTurno = 1
            Case "06:00-14:00"
                idTurno = 2
            Case "14:00-22:00"
                idTurno = 3
        End Select

        Carril = dgvBolsas.CurrentRow.Cells(4).Value
        HoraApertura = dgvBolsas.CurrentRow.Cells(7).Value
        HoraCierre = dgvBolsas.CurrentRow.Cells(8).Value

        lblEfectivo.Text += "  " + ContarVehiculos(Efectivo).ToString()
        lblIAVE1.Text += "  " + ContarVehiculos(IAVE).ToString()
        lblVSC1.Text += "  " + ContarVehiculos(VSC).ToString()
        lblTDC1.Text += "  " + ContarVehiculos(TDC).ToString()
        lblTDD1.Text += "  " + ContarVehiculos(TDD).ToString()
        lblEludido.Text += "  " + ContarVehiculos(Violacion).ToString()

        Dim total = (From t In ctx.Declaraciones
                     Where t.NoDeclaracion = idDeclaracion
                     Select t.TotalTrafico).SingleOrDefault()

        lblTotalVehiculos.Text += "  " + total.ToString()

    End Sub

#End Region

#Region "Functions"

    Private Function ContarVehiculos(FormaPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim cantidad

        If idTurno = 1 Then
            cantidad = (From c In ctx.Transacciones
                        Where ((c.Fecha = dato1.AddDays(-1) And c.Hora >= HoraApertura) Or (c.Fecha = dato1 And c.Hora <= HoraCierre)) And c.NoPlaza = idCaseta And c.NoCarrilCapufe = Carril And c.idPago = FormaPago
                        Select c.idTransaccion).Count()
        Else
            cantidad = (From c In ctx.Transacciones
                        Where c.Fecha = dato1 And c.NoPlaza = idCaseta And c.NoCarrilCapufe = Carril And c.Hora >= HoraApertura And c.Hora <= HoraCierre And c.idPago = FormaPago
                        Select c.idTransaccion).Count()
        End If

        Return cantidad

    End Function

#End Region

#Region "Events"

    Private Sub dbgBolsas_Click(sender As Object, e As EventArgs) Handles dgvBolsas.Click

        LlenarEncabezado(dgvBolsas.CurrentRow.Cells(0).Value.ToString())
        ObtenerDatos(dgvBolsas.CurrentRow.Cells(0).Value.ToString())

    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click

        If dgvBolsas.CurrentRow IsNot Nothing Then

            LlenarEncabezado(dgvBolsas.CurrentRow.Cells(0).Value.ToString())
            ObtenerDatos(dgvBolsas.CurrentRow.Cells(0).Value.ToString())

        Else
            RadMessageBox.Show("Debe seleccionar un corte.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Info)
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If txtBuscar.Text = "" Then
            RadMessageBox.Show("Debe ingresar un número de bolsa.", "Verifique!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            txtBuscar.Text = ""
        Else
            If Existe(txtBuscar.Text) = True Then
                Buscar()
                txtBuscar.Text = ""
            Else
                RadMessageBox.Show("El número de bolsa ingresado no existe o pertenece a otra plaza u otra fecha.", "Verifique!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                txtBuscar.Text = ""
            End If
        End If

    End Sub

    Private Sub btnRestablecer_Click(sender As Object, e As EventArgs) Handles btnRestablecer.Click

        CargarCortes()
        chkTurno.Checked = False
        chkCarril.Checked = False

    End Sub

    Private Sub chkTurno_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkTurno.ToggleStateChanged

        If chkTurno.Checked = True Then
            CargarTurnos()
            ddlTruno.Enabled = True
            ddlCarril.Enabled = False
            ddlCarril.Text = ""
            chkCarril.Checked = False
        Else
            ddlTruno.Enabled = False
            ddlTruno.Text = ""
            CargarCortes()
        End If

    End Sub

    Private Sub chkCarril_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkCarril.ToggleStateChanged

        If chkCarril.Checked = True Then
            CargarCarriles()
            ddlCarril.Enabled = True
            ddlTruno.Enabled = False
            ddlTruno.Text = ""
            chkTurno.Checked = False
        Else
            ddlCarril.Enabled = False
            ddlCarril.Text = ""
            CargarCortes()
        End If

    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnBuscar.PerformClick()
        End If

    End Sub

    Private Sub ddlTruno_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlTruno.SelectedIndexChanged

        If ddlTruno.SelectedIndex >= 0 Then
            FiltrarTurnos()
        End If

    End Sub

    Private Sub ddlCarril_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlCarril.SelectedIndexChanged

        If ddlCarril.SelectedIndex >= 0 Then
            FiltrarCarril()
        End If

    End Sub

#End Region

End Class