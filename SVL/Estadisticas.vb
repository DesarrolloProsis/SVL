Public Class Estadisticas

    Dim Hora1 As New TimeSpan(20, 0, 0)
    Dim Hora2 As New TimeSpan(8, 0, 0)
    Dim TotalImportados As Integer = 0
    Dim TotalDictaminados As Integer = 0

#Region "Formas de Pago"

    Dim NoPago As Integer = 0
    Dim Efectivo As Integer = 1
    Dim EfectivoCRE As Integer = 2
    Dim VSC As Integer = 27
    Dim Valores As Integer = 9
    Dim Residente As Integer = 10
    Dim TDC As Integer = 12
    Dim TDD As Integer = 14
    Dim IAVE As Integer = 15
    Dim Violacion As Integer = 13
    Dim RP1 As Integer = 71
    Dim RP2 As Integer = 72
    Dim RP3 As Integer = 73
    Dim RP4 As Integer = 74

#End Region
    '************************* CONTINUAR CON CAMBIO DE PLAZA ********************
    Private Sub Estadisticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpFecha.ShowUpDown = True
        lblDatos.Text = NombreCaseta + "  Carril: " + idCarril + "  Fecha: " + FechaEvento

        SacarEstadistica()
        CargarPlazas()
        CargarTurnos()

    End Sub

#Region "Methods"

    Private Sub SacarEstadistica()

        'Importados
        lblNoPago.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, NoPago)).ToString()
        lblEfectivo.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, Efectivo)).ToString()
        lblEfectivoCRE.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, EfectivoCRE)).ToString()
        lblVSC.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, VSC)).ToString()
        lblValores.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, Valores)).ToString()
        lblResidente.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, Residente)).ToString()
        lblTDC.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, TDC)).ToString()
        lblTDD.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, TDD)).ToString()
        lblIAVE.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, IAVE)).ToString()
        lblViolacion.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, Violacion)).ToString()
        lblRP1.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, RP1)).ToString()
        lblRP2.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, RP2)).ToString()
        lblRP3.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, RP3)).ToString()
        lblRP4.Text += (ContarEventosTransacciones(FechaEvento, NumCaseta, idHora, idCarril, RP4)).ToString()

        'Dictaminados
        lblNoPagoD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, NoPago)).ToString()
        lblEfectivoD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, Efectivo)).ToString()
        lblEfectivoCRED.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, EfectivoCRE)).ToString()
        lblVSCD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, VSC)).ToString()
        lblValoresD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, Valores)).ToString()
        lblResidenteD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, Residente)).ToString()
        lblTDCD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, TDC)).ToString()
        lblTDDD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, TDD)).ToString()
        lblIAVED.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, IAVE)).ToString()
        lblViolacionD.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, Violacion)).ToString()
        lblRP1D.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, RP1)).ToString()
        lblRP2D.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, RP2)).ToString()
        lblRP3D.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, RP3)).ToString()
        lblRP4D.Text += (ContarEventosDictaminaciones(FechaEvento, NumCaseta, idHora, idCarril, RP4)).ToString()

        lblTotalImportados.Text += TotalImportados.ToString()
        lblTotalDictaminados.Text += TotalDictaminados.ToString()

    End Sub

    Private Function ContarEventos(Fecha As Date, Plaza As Integer, Turno As Integer, Carril As String) As Integer

        Dim ctx As New CLRDataContext()

        Dim total

        If Turno = 1 Then
            total = (From t In ctx.Transacciones
                     Where ((t.Fecha = Fecha.AddDays(-1) And t.Hora > Hora1) Or (t.Fecha = Fecha And t.Hora < Hora2)) And t.NoPlaza = Plaza And t.idTurno = Turno And t.NoCarrilCapufe = Carril
                     Select t.NoEvento).Count()

            Return total

        Else
            total = (From t In ctx.Transacciones
                     Where t.Fecha = Fecha And t.NoPlaza = Plaza And t.idTurno = Turno And t.NoCarrilCapufe = Carril
                     Select t.NoEvento).Count()

            Return total

        End If

    End Function

    Private Function ContarEventosTransacciones(Fecha As Date, Plaza As Integer, Turno As Integer, Carril As String, Pago As Integer) As Integer

        Dim ctx As New CLRDataContext()

        Dim total

        If Turno = 1 Then
            total = (From t In ctx.Transacciones
                     Where ((t.Fecha = Fecha.AddDays(-1) And t.Hora > Hora1) Or (t.Fecha = Fecha And t.Hora < Hora2)) And t.NoPlaza = Plaza And t.idTurno = Turno And t.NoCarrilCapufe = Carril And t.idPago = Pago
                     Select t.NoEvento).Count()

            TotalImportados += total
            Return total

        Else
            total = (From t In ctx.Transacciones
                     Where t.Fecha = Fecha And t.NoPlaza = Plaza And t.idTurno = Turno And t.NoCarrilCapufe = Carril And t.idPago = Pago
                     Select t.NoEvento).Count()

            TotalImportados += total
            Return total

        End If

    End Function

    Private Function ContarEventosDictaminaciones(Fecha As Date, Plaza As Integer, Turno As Integer, Carril As String, Pago As Integer) As Integer

        Dim ctx As New CLRDataContext()

        Dim total

        If Turno = 1 Then
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where ((t.Fecha = Fecha.AddDays(-1) And t.Hora > Hora1) Or (t.Fecha = Fecha And t.Hora < Hora2)) And t.NoPlaza = Plaza And t.idTurno = Turno And t.NoCarrilCapufe = Carril And d.idPago = Pago
                     Select t.NoEvento).Count()

            TotalDictaminados += total
            Return total

        Else
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where t.Fecha = Fecha And t.NoPlaza = Plaza And t.idTurno = Turno And t.NoCarrilCapufe = Carril And d.idPago = Pago
                     Select t.NoEvento).Count()

            TotalDictaminados += total
            Return total

        End If

    End Function

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

    Private Sub CargarCarriles()

        Dim ctx As New CLRDataContext()

        ddlCarril.DataSource = ""

		Dim vias = From v In ctx.CatalogoCarriles
				   Where v.idPlaza = Integer.Parse(ddlPlaza.SelectedValue)
				   Select
					   ID = v.idCarril,
					   Nombre = v.Carril

		ddlCarril.ValueMember = "ID"
        ddlCarril.DisplayMember = "Nombre"

        ddlCarril.DataSource = vias.ToList()

    End Sub

    Private Sub CargarBusqueda()

        lblNoPago.Text = "No Pago: "
        lblEfectivo.Text = "Efectivo: "
        lblEfectivoCRE.Text = "Efectivo CRE: "
        lblVSC.Text = "Exento VSC: "
        lblValores.Text = "Valores: "
        lblResidente.Text = "Residente: "
        lblTDC.Text = "Tarjeta de Credito: "
        lblTDD.Text = "Tarjeta de Debito: "
        lblIAVE.Text = "IAVE: "
        lblViolacion.Text = "Violaciòn: "
        lblRP1.Text = "Residente RP1: "
        lblRP2.Text = "Residente RP2: "
        lblRP3.Text = "Residente RP3: "
        lblRP4.Text = "Residente RP4: "

        lblNoPagoD.Text = "No Pago: "
        lblEfectivoD.Text = "Efectivo: "
        lblEfectivoCRED.Text = "Efectivo CRE: "
        lblVSCD.Text = "Exento VSC: "
        lblValoresD.Text = "Valores: "
        lblResidenteD.Text = "Residente: "
        lblTDCD.Text = "Tarjeta de Credito: "
        lblTDDD.Text = "Tarjeta de Debito: "
        lblIAVED.Text = "IAVE: "
        lblViolacionD.Text = "Violaciòn: "
        lblRP1D.Text = "Residente RP1: "
        lblRP2D.Text = "Residente RP2: "
        lblRP3D.Text = "Residente RP3: "
        lblRP4D.Text = "Residente RP4: "

        lblTotalImportados.Text = "Total importados: "
        lblTotalDictaminados.Text = "Total dictaminados: "

        Dim Fecha As Date
        Dim Caseta As Integer
        Dim idTurno As Integer
        Dim idVia As String

        Fecha = dtpFecha.Value
        Caseta = Integer.Parse(ddlPlaza.SelectedValue)
        idTurno = Integer.Parse(ddlTurno.SelectedValue)
        idVia = ddlCarril.Text

        'Importados
        lblNoPago.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, NoPago)).ToString()
        lblEfectivo.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, Efectivo)).ToString()
        lblEfectivoCRE.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, EfectivoCRE)).ToString()
        lblVSC.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, VSC)).ToString()
        lblValores.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, Valores)).ToString()
        lblResidente.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, Residente)).ToString()
        lblTDC.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, TDC)).ToString()
        lblTDD.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, TDD)).ToString()
        lblIAVE.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, IAVE)).ToString()
        lblViolacion.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, Violacion)).ToString()
        lblRP1.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, RP1)).ToString()
        lblRP2.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, RP2)).ToString()
        lblRP3.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, RP3)).ToString()
        lblRP4.Text += (ContarEventosTransacciones(Fecha, Caseta, idTurno, idVia, RP4)).ToString()

        'Dictaminados
        lblNoPagoD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, NoPago)).ToString()
        lblEfectivoD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, Efectivo)).ToString()
        lblEfectivoCRED.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, EfectivoCRE)).ToString()
        lblVSCD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, VSC)).ToString()
        lblValoresD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, Valores)).ToString()
        lblResidenteD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, Residente)).ToString()
        lblTDCD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, TDC)).ToString()
        lblTDDD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, TDD)).ToString()
        lblIAVED.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, IAVE)).ToString()
        lblViolacionD.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, Violacion)).ToString()
        lblRP1D.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, RP1)).ToString()
        lblRP2D.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, RP2)).ToString()
        lblRP3D.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, RP3)).ToString()
        lblRP4D.Text += (ContarEventosDictaminaciones(Fecha, Caseta, idTurno, idVia, RP4)).ToString()

        lblTotalImportados.Text = "Total importados: " + TotalImportados.ToString()
        lblTotalDictaminados.Text = "Total dictaminados: " + TotalDictaminados.ToString()

        lblDatos.Text = ddlPlaza.Text + " Carril: " + idVia + " Fecha: " + dtpFecha.Text

    End Sub

#End Region

#Region "Events"

    Private Sub ddlPlaza_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlPlaza.SelectedIndexChanged

        CargarCarriles()

    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        CargarBusqueda()

    End Sub

#End Region

End Class
