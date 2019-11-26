Imports Telerik.WinControls

''' <summary>
''' Formulario FiltroDeLiquidacion
''' Formulario previo a la 
''' Dictaminación de carriles
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @05/04/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>
Public Class FiltroDeLiquidacion

#Region "Variables"

    Dim Mensaje As New Mensajes()

    Dim Del As String
    Dim numDel As Integer
    Dim caseta As String
    Dim contador As Integer = 0
    Dim idPlaza As Integer
    Dim idTurno As Integer

#End Region

    Private Sub FiltroDeLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        dtpFecha.Text = Date.Now.Date
        CargarListaDelegaciones()
        DesactivarOpciones()
        ddlDelegacion.SelectedIndex = 0

    End Sub

#Region "Methods"

    Private Sub CargarListaDelegaciones()

        Dim ctx As New CLRDataContext

		Dim delegacion = From d In ctx.Tramo
						 Order By d.Tramo Descending
						 Select
							 ID = d.idTramo,
							 Nombre = d.Tramo

		ddlDelegacion.ValueMember = "ID"
        ddlDelegacion.DisplayMember = "Nombre"

        ddlDelegacion.DataSource = delegacion.ToList()

    End Sub

    Private Sub CargarListaPlazas()

        Dim ctx As New CLRDataContext

		Dim ExistenPlazas = (From e In ctx.Plazas
							 Where e.idTramo = Integer.Parse(ddlDelegacion.SelectedValue)
							 Select e.idTramo).Count()

		If ExistenPlazas > 0 Then
			Dim plaza = From p In ctx.Plazas
						Where p.idTramo = Integer.Parse(ddlDelegacion.SelectedValue)
						Order By p.NomPlaza
						Select
							ID = p.NoPlaza,
							Nombre = p.NomPlaza

			ddlPlaza.ValueMember = "ID"
            ddlPlaza.DisplayMember = "Nombre"

            ddlPlaza.DataSource = plaza.ToList()
        Else
            RadMessageBox.Show("No hay plazas para la delegación seleccionada.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    Private Sub CargarTurnos()

        Dim ctx As New CLRDataContext()

		Dim horarios = From h In ctx.Turnos
					   Select
						   ID = h.idTurno,
						   Turno = h.Turno

		ddlTurno.ValueMember = "ID"
        ddlTurno.DisplayMember = "Turno"

        ddlTurno.DataSource = horarios.ToList()

    End Sub

    Private Sub CargarCarriles()

        Dim ctx As New CLRDataContext()

		Dim vias = From v In ctx.CatalogoCarriles
				   Where v.idPlaza = idPlaza
				   Select
					   ID = v.idPlaza,
					   Carril = v.Carril

		ddlCarril.ValueMember = "ID"
        ddlCarril.DisplayMember = "Carril"

        ddlCarril.DataSource = vias.ToList()

    End Sub

    Private Sub DesactivarOpciones()

        ddlPlaza.Enabled = False
        ddlPlaza.Text = ""
        btnAceptar.Enabled = False
        dtpFecha.Enabled = False
        ddlTurno.Enabled = False
        ddlTurno.Text = ""
        ddlCarril.Enabled = False
        ddlCarril.Text = ""

    End Sub

    Private Sub ConvertirPlaza(Caseta As String)

        Dim ctx As New CLRDataContext()

		Dim convertir = (From c In ctx.Plazas
						 Where c.NomPlaza = Caseta
						 Select c.NoPlaza).SingleOrDefault()

		NumCaseta = convertir

    End Sub

    Private Function ExistenDatos(Fecha As Date, Turno As Integer, Caseta As Integer) As Boolean

        Try

            Dim db As New CLRDataContext()
            Dim H1 As New TimeSpan(20, 0, 0)
            Dim H2 As New TimeSpan(8, 0, 0)
            Dim existen

            If Turno = 1 Then
                existen = (From e In db.Transacciones
                           Where ((e.Fecha = Fecha.AddDays(-1) And e.Hora > H1) Or (e.Fecha = Fecha And e.Hora < H2)) And e.NoCarrilCapufe = idCarril And e.idTurno = Turno And e.NoPlaza = Caseta
                           Select e.NoEvento).Count()
            Else
                existen = (From e In db.Transacciones
                           Where e.Fecha = Fecha And e.NoCarrilCapufe = idCarril And e.idTurno = Turno And e.NoPlaza = Caseta
                           Select e.NoEvento).Count()
            End If

            If existen = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception

        End Try

    End Function

    Private Function TraerIPs(NumPlaza As Integer)

        Dim ctx As New CLRDataContext()

		Dim video = (From v In ctx.Plazas
					 Where v.NoPlaza = NumPlaza
					 Select v.IP_Video).SingleOrDefault()

		Return video.ToString()

    End Function

#End Region

#Region "Events"

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        ConvertirPlaza(ddlPlaza.Text)
        NombreCaseta = ddlPlaza.Text
        NumCaseta = Integer.Parse(ddlPlaza.SelectedValue)
        FechaEvento = dtpFecha.Text
        idHora = ddlTurno.SelectedValue
        idCarril = ddlCarril.Text
        IPVideo = TraerIPs(NumCaseta)
        idTurno = ddlTurno.SelectedValue
        TurnoD = ddlTurno.SelectedValue

        If ExistenDatos(dtpFecha.Text, idTurno, NumCaseta) = True Then
            Dictaminacion.Show()
            Me.Hide()
        Else
            RadMessageBox.Show("No hay datos para los valores seleccionados, intente de nuevo.", "VERIFIQUE", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    Dim Count As Integer = 0

    Private Sub ddlDelegacion_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlDelegacion.SelectedIndexChanged

        If Count > 0 Then
            Del = ddlDelegacion.SelectedText
            ddlPlaza.Enabled = True
            ddlPlaza.SelectedIndex = 0
            ddlTurno.Enabled = True
            btnAceptar.Enabled = True
            dtpFecha.Enabled = True
            CargarListaPlazas()
            CargarTurnos()
        End If
        Count = Count + 1

    End Sub

    Private Sub ddlPlaza_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlPlaza.SelectedIndexChanged

        If contador > 0 Then
            idPlaza = ddlPlaza.SelectedValue
            ddlCarril.Enabled = True
            CargarCarriles()
        End If

        contador = contador + 1

    End Sub

#End Region

End Class
