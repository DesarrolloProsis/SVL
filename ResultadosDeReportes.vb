Imports System.Data.Linq.SqlClient
Imports Telerik.WinControls
''' <summary>
''' Formulario ResultadoCarriles
''' Se muestran los carriles derivados
''' de la selección hecha en el formulario
''' anterior (FiltroReporte)
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @06/04/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>
Public Class ResultadosDeReportes

#Region "Variables"

    Dim banderaT As Boolean = True
    Dim banderaV As Boolean = True
    Dim banderaC As Boolean = True
    Dim valorT As Integer = 0
    Dim valorV As Integer = 0
    Dim valorC As Integer = 0

    Dim NumA As Integer = 0
    Dim NumB As Integer = 0

#End Region

    Private Sub ResultadosDeReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        dbgCarriles.ReadOnly = True

        Select Case idPlazaR
            Case 12
                NumA = 11
            Case 22
                NumA = 21
            Case 32
                NumA = 31
            Case 42
                NumA = 41
            Case 51
                NumA = 51
            Case 62
                NumA = 61
            Case 72
                NumA = 71
            Case 82
                NumA = 81
            Case 92
                NumA = 91
            Case 86
                NumA = 85
        End Select

        CargarEncargados()
        CargarAdministradores()
        CargarBolsas()

    End Sub

#Region "Methods"

    Private Sub CargarBolsas()

		Dim ctx As New CLRDataContext()

		Dim cortes = From c In ctx.Declaraciones
					 Where c.Fecha = FechaOperacionR And c.NoPlaza = idPlazaR And c.NoCarrilCapufe = CarrilR And c.idTurno = idTurnoR
					 Select
						 Bolsa = c.Bolsa,
						 Carril = c.NoCarrilCapufe,
						 Cajero = c.Cajero,
						 Comentarios = c.Comentarios,
						 iddeclaracion = c.NoDeclaracion

		dbgCarriles.DataSource = cortes.ToList()
        dbgCarriles.Columns(0).Width = 80
        dbgCarriles.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
        dbgCarriles.Columns(1).Width = 60
        dbgCarriles.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        dbgCarriles.Columns(2).Width = 60
        dbgCarriles.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        dbgCarriles.Columns(3).Width = 200
        dbgCarriles.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
		dbgCarriles.Columns(4).IsVisible = False

	End Sub

    Private Sub CargarEncargados()

        Dim ctx As New CLRDataContext()

        Dim employed = From e In ctx.PersonalPlaza
                       Where SqlMethods.Like(e.NoEmpleadoCapufe, "4%") And (e.NoPlaza = NumA Or e.NoPlaza = idPlazaR)
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
                       Where SqlMethods.Like(e.NoEmpleadoCapufe, "1%") And (e.NoPlaza = NumA Or e.NoPlaza = idPlazaR)
                       Select
                             ID = e.NoEmpleadoCapufe,
                             Nombre = e.Nombre + " " + e.Apellidos

        ddlAdministrador.ValueMember = "ID"
        ddlAdministrador.DisplayMember = "Nombre"

        ddlAdministrador.DataSource = employed.ToList()

    End Sub

    Private Function EstanDictaminados(idBolsa As Integer) As Boolean

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim SinDictaminar

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then

            SinDictaminar = (From s In ctx.Transacciones
                             Where ((s.Fecha = FechaR.AddDays(-1) And s.Hora >= HoraA) Or (s.Fecha = FechaOperacionR And s.Hora <= HoraC)) And s.NoPlaza = idPlazaR And s.idTurno = idTurnoR And s.NoCarrilCapufe = CarrilR And (s.Dictaminado = 0 Or s.Dictaminado Is Nothing)
                             Select s.NoEvento).Count()

            If SinDictaminar = 0 Then
                Return True
            Else
                Return False
            End If

        Else

            SinDictaminar = (From s In ctx.Transacciones
                             Where s.Fecha = FechaOperacionR And (s.Hora >= HoraA And s.Hora <= HoraC) And s.NoPlaza = idPlazaR And s.idTurno = idTurnoR And s.NoCarrilCapufe = CarrilR And (s.Dictaminado = 0 Or s.Dictaminado Is Nothing)
                             Select s.NoEvento).Count()

            If SinDictaminar = 0 Then
                Return True
            Else
                Return False
            End If

        End If

    End Function

    Private Function ConsultarHoraInicio(idBolsa As Integer) As TimeSpan

        Dim ctx As New CLRDataContext()

        Dim horaI = (From h In ctx.Declaraciones
                     Where h.NoDeclaracion = idBolsa
                     Select h.HoraApertura).SingleOrDefault()

        Return horaI

    End Function

    Private Function ConsultarHoraFinal(idBolsa As Integer) As TimeSpan

        Dim ctx As New CLRDataContext()

        Dim horaF = (From h In ctx.Declaraciones
                     Where h.NoDeclaracion = idBolsa
                     Select h.HoraCierre).SingleOrDefault()

        Return horaF

    End Function

#End Region

#Region "Events"

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If NumCarril Is Nothing OrElse NumCarril.ToString = String.Empty Then
            RadMessageBox.Show("Debe seleccionar un registro.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Info)
        Else
            If EstanDictaminados(NumDeclaracion) = True Then
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
            Else
                RadMessageBox.Show("No todos los eventos estan dictaminados.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If
        End If

    End Sub

    Private Sub dbgCarriles_Click(sender As Object, e As EventArgs) Handles dbgCarriles.Click

        NumCarril = dbgCarriles.CurrentRow.Cells(1).Value.ToString()
        NumDeclaracion = dbgCarriles.CurrentRow.Cells(4).Value.ToString()

        'If EstanDictaminados() = True Then
        '    Reportes.Show()
        '    Me.Hide()
        'Else
        '    RadMessageBox.Show("No todos los eventos estan dictaminados.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Info)
        'End If

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
