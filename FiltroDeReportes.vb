Imports Telerik.WinControls

''' <summary>
''' Formulario FiltroDeReportes
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @05/04/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>

Public Class FiltroDeReportes

    Dim contador As Integer = 0
    Dim idPlaza As Integer

    Dim ListaBolsas As New List(Of Integer)
    Dim ListaBolsasDia As New List(Of Integer)

    Dim SinDictaminar As Boolean = False

    Private Sub FiltroDeReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Select Case SeleccionReporte
            Case 1
                CargarListaPlazas()
            Case 2
                ddlCarril.Visible = False
                lblCarril.Visible = False
                dtpFecha.Top = 135
                lblFecha.Top = 110
                ddlTurno.Top = 220
                lblTurno.Top = 195

                ddlPlaza.DataSource = Casetas
                ddlPlaza.ValueMember = "ID_Plaza"
                ddlPlaza.DisplayMember = "Nombre"

            Case 3
                ddlTurno.Visible = False
                ddlCarril.Visible = False
                lblTurno.Visible = False
                lblCarril.Visible = False
                ddlPlaza.Top = 85
                lblPlaza.Top = 60
                dtpFecha.Top = 160
                lblFecha.Top = 135

                ddlPlaza.DataSource = Casetas
                ddlPlaza.ValueMember = "ID_Plaza"
                ddlPlaza.DisplayMember = "Nombre"

        End Select

        RadMessageBox.SetThemeName(Theme)
        dtpFecha.Text = Date.Now.Date
        CargarListaTurnos()
        ddlPlaza.SelectedIndex = 1

    End Sub

#Region "Methods"

    Private Sub CargarListaPlazas()

        Dim ctx As New CLRDataContext()

        Dim casetas = From c In ctx.Plazas
                      Order By c.NomPlaza
                      Select
                          ID = c.NoPlaza,
                          Nombre = c.NomPlaza

        ddlPlaza.ValueMember = "ID"
        ddlPlaza.DisplayMember = "Nombre"

        ddlPlaza.DataSource = casetas.ToList()

    End Sub

    Private Sub CargarListaTurnos()

        Dim ctx As New CLRDataContext()

        Dim turn = From t In ctx.Turnos
                   Order By t.idTurno
                   Select
                       ID = t.idTurno,
                       Turno = t.Turno

        ddlTurno.ValueMember = "ID"
        ddlTurno.DisplayMember = "Turno"

        ddlTurno.DataSource = turn.ToList()

    End Sub

    Private Sub CargarListaCarriles()

        Dim ctx As New CLRDataContext()

        Dim vias = From v In ctx.CatalogoCarriles
                   Where v.idPlaza = idPlaza
                   Select
                       ID = v.idCarril,
                       Carril = v.Carril

        ddlCarril.ValueMember = "ID"
        ddlCarril.DisplayMember = "Carril"

        ddlCarril.DataSource = vias.ToList()

    End Sub
    '***** Turno 1
    Private Function ExistenDatos(Valor As Date) As Boolean

        Dim db As New CLRDataContext()

        Dim existen = (From e In db.Declaraciones
                       Where e.Fecha = Valor
                       Select e).FirstOrDefault()

        If existen Is Nothing OrElse existen.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function ExisteBolsa(Fecha As Date, NumPlaza As Integer, Turno As Integer, Carril As String) As Boolean

        Try

            Dim ctx As New CLRDataContext()

            Dim bolsa = (From b In ctx.Declaraciones
                         Where b.Fecha = Fecha.Date And b.NoPlaza = NumPlaza And b.idTurno = Turno And b.NoCarrilCapufe = Carril
                         Select b.NoDeclaracion).Count()

            If bolsa = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function EstanLiquidados(idBolsa As Integer) As Boolean

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim HoraApertura As TimeSpan
        Dim HoraCierre As TimeSpan
        Dim SinDictaminar

        HoraApertura = ConsultarHoraInicio(idBolsa)
        HoraCierre = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            SinDictaminar = (From s In ctx.Transacciones
                             Where ((s.Fecha = FechaR.AddDays(-1) And s.Hora > HoraA) Or (s.Fecha = FechaR And s.Hora < HoraC)) And (s.NoPlaza = IdPlazaUno Or s.NoPlaza = IdPlazaDos) And s.idTurno = idTurnoR And (s.Dictaminado = 0 Or s.Dictaminado Is Nothing)
                             Select s.NoEvento).Count()

            If SinDictaminar = 0 Then
                Return True
            Else
                Return False
            End If

        Else
            SinDictaminar = (From s In ctx.Transacciones
                             Where s.Fecha = FechaOperacionR And (s.NoPlaza = IdPlazaUno Or s.NoPlaza = IdPlazaDos) And s.idTurno = idTurnoR And (s.Dictaminado = 0 Or s.Dictaminado Is Nothing)
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

    Private Sub ListarBolsas()

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim cortes

        ListaBolsas.Clear()

        If idTurnoR = 1 Then
            cortes = (From n In ctx.Declaraciones
                      Where ((n.Fecha = FechaR.AddDays(-1) And n.HoraCierre > HoraA) Or (n.Fecha = FechaR And n.HoraCierre < HoraC)) And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                      Select n.NoDeclaracion).ToList()
        Else
            cortes = (From n In ctx.Declaraciones
                      Where n.Fecha = FechaR And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                      Select n.NoDeclaracion).ToList()
        End If



        For Each i As Integer In cortes
            ListaBolsas.Add(i)
            ListaBolsasDia.Add(i)
        Next

    End Sub

    Private Function EstaLiquidadoDia() As Boolean

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)

        Dim t12 = (From i In ctx.Transacciones
                   Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And (i.Dictaminado = False Or i.Dictaminado Is Nothing)
                   Select i.idTarifa).Count()

        Dim t3 = (From i In ctx.Transacciones
                  Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And (i.Dictaminado = False Or i.Dictaminado Is Nothing)
                  Select i.idTarifa).Count()

        Dim suma = t12 + t3

        If suma > 0 Then
            Return False
        Else
            Return True
        End If

    End Function

#End Region

#Region "Events"

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Select Case SeleccionReporte
            Case 1
                idPlazaR = Integer.Parse(ddlPlaza.SelectedValue)
                idTurnoR = ddlTurno.SelectedValue
                FechaOperacionR = dtpFecha.Text '<---- Tipo String
                idCarrilR = ddlCarril.SelectedValue
                CarrilR = ddlCarril.SelectedItem.Text
                FechaR = dtpFecha.Text  '<---- Tipo Date

                If ExisteBolsa(FechaR, idPlazaR, idTurnoR, CarrilR) = True Then
                    ResultadosDeReportes.Show()
                    Me.Hide()
                Else
                    RadMessageBox.Show("No existe bolsa para el carril seleccionado.", "VERIFICA", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

            Case 2
                idPlazaR = Integer.Parse(ddlPlaza.SelectedValue)
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

                NombrePlaza = ddlPlaza.Text
                idTurnoR = ddlTurno.SelectedValue
                FechaOperacionR = dtpFecha.Text '<---- Tipo String
                FechaR = dtpFecha.Text  '<---- Tipo Date
                ListarBolsas()

                If ExistenDatos(dtpFecha.Text) = True Then
                    For i As Integer = 0 To ListaBolsas.Count - 1
                        If EstanLiquidados(ListaBolsas.Item(i)) = False Then
                            SinDictaminar = True
                            Exit For
                        End If
                    Next
                    If SinDictaminar = False Then
                        Observaciones.Show()
                        Me.Close()
                    Else
                        RadMessageBox.Show("No se puede generar el reporte debido a que hay eventos en este turno que no se han liquidado.", "VERIFICA", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    End If
                Else
                    RadMessageBox.Show("No hay datos para la fecha seleccionada.", "VERIFICA", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

            Case 3
                idPlazaR = Integer.Parse(ddlPlaza.SelectedValue)
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
                NombrePlaza = ddlPlaza.Text
                NombrePlaza = ddlPlaza.Text
                FechaOperacionR = dtpFecha.Text '<---- Tipo String
                FechaR = dtpFecha.Text  '<---- Tipo Date

                If ExistenDatos(dtpFecha.Text) = True Then
                    If EstaLiquidadoDia() = True Then
                        Observaciones.Show()
                        Me.Close()
                    Else
                        RadMessageBox.Show("No se puede generar el reporte debido a que hay eventos en este turno que no se han liquidado.", "VERIFICA", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    End If
                Else
                    RadMessageBox.Show("No hay datos para la fecha seleccionada.", "VERIFICA", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

        End Select

    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged

        FechaO = dtpFecha.Text

    End Sub

    Private Sub ddlPlaza_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlPlaza.SelectedIndexChanged

        If contador > 1 Then
            Caseta = ddlPlaza.Text
            idPlaza = ddlPlaza.SelectedValue
            CargarListaCarriles()
        End If

        contador = contador + 1

    End Sub

#End Region

End Class

Class Plazas

    Property ID_Plaza As Integer
    Property Nombre As String

End Class

