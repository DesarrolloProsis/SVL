Imports System.Data.Linq.SqlClient
Imports Telerik.WinControls

Public Class Observaciones

    Private Sub Observaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)

        CargarEncargados()
        CargarAdministradores()

    End Sub

#Region "Methods"

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

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress

        If txtObservaciones.TextLength = 230 Then
            RadMessageBox.Show("Solo se permiten 230 caracteres.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

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

        Reportes.Show()
        Me.Close()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

#End Region

End Class
