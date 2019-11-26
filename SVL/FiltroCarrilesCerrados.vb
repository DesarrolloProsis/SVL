Imports Telerik.WinControls

''' <summary>
''' 
''' </summary>

Public Class FiltroCarrilesCerrados

    Private Sub FiltroCarrilesCerrados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)

        Dim Casetas As New List(Of Plazas)

        Casetas.Add(New Plazas With {.ID_Plaza = 87, .Nombre = "Cerro Gordo"})

        ddlPlaza.DataSource = Casetas
        ddlPlaza.ValueMember = "ID_Plaza"
        ddlPlaza.DisplayMember = "Nombre"

        ObtenerTurnos()

    End Sub

#Region "Methods"

    Private Sub ObtenerTurnos()

        Dim ctx As New CLRDataContext()

        Dim horarios = From h In ctx.Turnos
                       Where h.idTurno <> 0
                       Select
                           ID = h.idTurno,
                           Nombre = h.Turno

        ddlTurno.ValueMember = "ID"
        ddlTurno.DisplayMember = "Nombre"
        ddlTurno.DataSource = horarios.ToList()

    End Sub

#End Region

#Region "Events"

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click

        CC_Fecha = dtpFecha.Text
        CC_Turno = ddlTurno.SelectedValue
        IdPlazaUno = ddlPlaza.SelectedValue

        Select Case IdPlazaUno
            Case 11
                IdPlazaDos = 12
            Case 21
                IdPlazaDos = 22
            Case 31
                IdPlazaDos = 32
            Case 41
                IdPlazaDos = 42
            Case 51
                IdPlazaDos = 0
            Case 61
                IdPlazaDos = 62
            Case 71
                IdPlazaDos = 72
            Case 81
                IdPlazaDos = 82
            Case 91
                IdPlazaDos = 92
            Case 85
                IdPlazaDos = 86
            Case 87
                IdPlazaDos = 88
        End Select

        SeleccionReporte = 4
        CarrilesCerrados.Show()
        Me.Close()

    End Sub

#End Region

End Class
