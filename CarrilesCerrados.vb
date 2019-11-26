Imports System.Data.Linq.SqlClient
Imports Telerik.WinControls
''' <summary>
''' 
''' </summary>

Public Class CarrilesCerrados

    Dim ListaCarriles As New List(Of String)
    Dim ListaCarrilesBolsa As New List(Of String)

    Private Sub CarrilesCerrados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)

        ObtenerListas()
        CargarEncargados()
        CargarAdministradores()

        ddlCarrilesCarrados.DataSource = ListaCarriles.Except(ListaCarrilesBolsa).ToList()

    End Sub

#Region "Methods"

    Private Sub ObtenerListas()

        Dim ctx As New CLRDataContext()

        Dim vias = From v In ctx.CatalogoCarriles
                   Where v.idPlaza = IdPlazaUno Or v.idPlaza = IdPlazaDos Order By v.Carril Ascending
                   Select v.Carril

        For Each i As String In vias.ToList()
            ListaCarriles.Add(i)
        Next

        Dim cBolsas = From c In ctx.Declaraciones
                      Where c.Fecha = CC_Fecha And (c.NoPlaza = IdPlazaUno Or c.NoPlaza = IdPlazaDos) And c.idTurno = CC_Turno Order By c.NoCarrilCapufe Ascending
                      Select c.NoCarrilCapufe

        For Each j As String In cBolsas.ToList()
            ListaCarrilesBolsa.Add(j)
        Next

    End Sub

    Private Sub CargarEncargados()

        Dim ctx As New CLRDataContext()

        Dim employed = From e In ctx.PersonalPlaza
                       Where SqlMethods.Like(e.NoEmpleadoCapufe, "4%") And (e.NoPlaza = IdPlazaUno Or e.NoPlaza = IdPlazaDos)
                       Select
                             ID = e.NoEmpleadoCapufe,
                             Nombre = e.Nombre + " " + e.Apellidos

        ddlEncargado.ValueMember = "ID"
        ddlEncargado.DisplayMember = "Nombre"

        ddlEncargado.DataSource = employed.ToList()

    End Sub

    Private Sub CargarAdministradores()

        Dim ctx As New CLRDataContext()

        Dim employed = From e In ctx.PersonalPlaza
                       Where SqlMethods.Like(e.NoEmpleadoCapufe, "1%") And (e.NoPlaza = IdPlazaUno Or e.NoPlaza = IdPlazaDos)
                       Select
                             ID = e.NoEmpleadoCapufe,
                             Nombre = e.Nombre + " " + e.Apellidos

        ddlAdministrador.ValueMember = "ID"
        ddlAdministrador.DisplayMember = "Nombre"

        ddlAdministrador.DataSource = employed.ToList()

    End Sub

#End Region

#Region "Events"

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        NoNomEncargado = (ddlEncargado.SelectedValue).ToString() + " - " + (ddlEncargado.Text).ToString()
        NoNomAdministrador = (ddlAdministrador.SelectedValue).ToString() + " - " + (ddlAdministrador.Text).ToString()

        Dim str As String = txtObservaciones.Text.PadRight(230)

        PrimeraLinea = (str).Substring(0, 70)
        SegundaLinea = (str).Substring(70, 80)
        TerceraLinea = (str).Substring(150, 80)

        If PrimeraLinea.Length = 0 Then
            PrimeraLinea = ""
        End If

        If SegundaLinea.Length = 0 Then
            SegundaLinea = ""
        End If

        If TerceraLinea.Length = 0 Then
            TerceraLinea = ""
        End If
        '********************** CONTINUAR AQUI, la fecha se guarda con todo y hora ****************
        FechaOperacionR = (CC_Fecha.Date).ToString()
        CarrilR = ddlCarrilesCarrados.SelectedItem.Text

        idPlazaR = IdPlazaUno

        Reportes.Show()

    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress

        If txtObservaciones.TextLength = 230 Then
            RadMessageBox.Show("Solo se permiten 230 caracteres.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

#End Region

End Class
