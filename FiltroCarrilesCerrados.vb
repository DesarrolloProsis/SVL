Imports Telerik.WinControls

''' <summary>
''' 
''' </summary>

Public Class FiltroCarrilesCerrados

    Private Sub FiltroCarrilesCerrados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)

        Dim Casetas As New List(Of Plazas)

        Casetas.Add(New Plazas With {.ID_Plaza = 11, .Nombre = "Alpuyeca"})
        Casetas.Add(New Plazas With {.ID_Plaza = 21, .Nombre = "Paso Morelos"})
        Casetas.Add(New Plazas With {.ID_Plaza = 31, .Nombre = "Palo Blanco"})
        Casetas.Add(New Plazas With {.ID_Plaza = 41, .Nombre = "La Venta"})
        Casetas.Add(New Plazas With {.ID_Plaza = 51, .Nombre = "Xochitepec"})
        Casetas.Add(New Plazas With {.ID_Plaza = 61, .Nombre = "Aeropuerto"})
        Casetas.Add(New Plazas With {.ID_Plaza = 71, .Nombre = "Emiliano Zapata"})
        Casetas.Add(New Plazas With {.ID_Plaza = 81, .Nombre = "Tlalpan"})
        Casetas.Add(New Plazas With {.ID_Plaza = 91, .Nombre = "Tres Marias"})
        Casetas.Add(New Plazas With {.ID_Plaza = 85, .Nombre = "Francisco Velasco"})

        ddlPlaza.DataSource = Casetas
        ddlPlaza.ValueMember = "ID_Plaza"
        ddlPlaza.DisplayMember = "Nombre"

        ObtenerTurnos()

    End Sub

#Region "Methods"

    Private Sub ObtenerTurnos()

        Dim ctx As New CLRDataContext()

        Dim horarios = From h In ctx.Turnos
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
        End Select

        SeleccionReporte = 4
        CarrilesCerrados.Show()

    End Sub

#End Region

End Class
