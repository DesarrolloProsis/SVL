Public Class DictaminacionAutomatica

    Dim idClase As Integer
    Dim NoEvento As Integer

    Private Sub Dictaminacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarEventos()

    End Sub

#Region "Methods"

    Private Sub CargarEventos()

		Dim db As New CLRDataContext()

		Dim normales = From n In db.Transacciones
                       Join p In db.TipoPago
                           On n.idPago Equals p.idPago
                       Where n.idPago = 1
                       Select
                           Evento = n.NoEvento,
                           Carril = n.NoCarrilCapufe,
                           Pago = p.NomPago,
                           Clase = n.idVehiculo,
                           Fecha = Format(n.Fecha, "dd/MM/yyyy"),
                           Hora = n.Hora

        dgvPrincipal.DataSource = normales.ToList()
        dgvPrincipal.Columns(0).Width = 80
        dgvPrincipal.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dgvPrincipal.Columns(1).Width = 80
        dgvPrincipal.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dgvPrincipal.Columns(2).Width = 90
        dgvPrincipal.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dgvPrincipal.Columns(3).Width = 50
        dgvPrincipal.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        dgvPrincipal.Columns(4).Width = 80
        dgvPrincipal.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        dgvPrincipal.Columns(5).Width = 65
        dgvPrincipal.Columns(5).TextAlignment = ContentAlignment.MiddleCenter

    End Sub

    Private Sub Liquidar()

		'Dim ctx As New CLRDataContext

		'Dim id = (From i In ctx.TipoVehiculo
		'          Where i.Clase = dgvPrincipal.CurrentRow.Cells(3).Value.ToString()
		'          Select i.idVehiculo).SingleOrDefault()

		'idClase = id

		'Dim Numliqui = (From n In ctx.Liquidaciones
		'                Select n.NoLiquidacion).Max()

		'Dim num As Integer

		'num = Numliqui + 1

		'Dim Liquidar As New Liquidaciones()

		'Liquidar.NoLiquidacion = num
		'Liquidar.NoTransaccion = Integer.Parse(dgvPrincipal.CurrentRow.Cells(0).Value)
		'Liquidar.idVehiculo = idClase
		'Liquidar.idPago = 1
		'Liquidar.Analizado = True
		'Liquidar.NoEmpleadoCapufe = 10001
		'Liquidar.Fecha = Date.Now.Date
		'Liquidar.Hora = Date.Now.TimeOfDay

		'ctx.Liquidaciones.InsertOnSubmit(Liquidar)
		'ctx.SubmitChanges()

	End Sub

    Private Sub CargarLiquidaciones(Valor As Integer)

		'Dim ctx As New CLRDataContext()
		'Dim datos = From d In ctx.Liquidaciones
		'            Join t In ctx.TipoVehiculo
		'                On d.idVehiculo Equals t.idVehiculo
		'            Join p In ctx.TipoPago
		'                On d.idPago Equals p.idPago
		'            Join e In ctx.PersonalCLR
		'                On d.NoEmpleadoCapufe Equals e.NoEmpleadoCapufe
		'            Where d.NoTransaccion = Valor
		'            Select
		'                Liquidación = d.NoLiquidacion,
		'                Evento = d.NoTransaccion,
		'                Analista = e.Nombre,
		'                Clase = t.Clase,
		'                Pago = p.NomPago,
		'                Dictaminado = d.Analizado

		'dgvSecundario.DataSource = datos.ToList()
		'dgvSecundario.Columns(0).Width = 85
		'dgvSecundario.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
		'dgvSecundario.Columns(1).Width = 55
		'dgvSecundario.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
		'dgvSecundario.Columns(2).Width = 80
		'dgvSecundario.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
		'dgvSecundario.Columns(3).Width = 75
		'dgvSecundario.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
		'dgvSecundario.Columns(4).Width = 100
		'dgvSecundario.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
		'dgvSecundario.Columns(5).Width = 70
		'dgvSecundario.Columns(5).TextAlignment = ContentAlignment.MiddleCenter

	End Sub

    Private Sub dgvPrincipal_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvSecundario.CellDoubleClick, dgvPrincipal.CellDoubleClick

        Liquidar()
        NoEvento = Integer.Parse(dgvPrincipal.CurrentRow.Cells(0).Value)
        CargarLiquidaciones(NoEvento)

    End Sub

    Private Sub dgvPrincipal_CellClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvSecundario.CellClick, dgvPrincipal.CellClick

        NoEvento = Integer.Parse(dgvPrincipal.CurrentRow.Cells(0).Value)
        CargarLiquidaciones(NoEvento)

    End Sub

#End Region

End Class