
Imports Telerik.WinControls

Public Class AgregarEvento

    Private Sub AgregarEvento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        dtpHora.ShowUpDown = True
        lblNoEjes.Visible = False
        txtNoEjes.Visible = False
        '************* CHECAR QUE DDL'S TOMEN EL VALOR PREDETERMINADO
        txtEvento.Text = ie_NoEvento.ToString()
        dtpFecha.Text = ie_Fecha.ToString()
        dtpHora.Text = ie_Hora.ToString()
        txtFolio.Text = ie_Folio.ToString()
        txtNoCajero.Text = ie_NoCajero.ToString()
        ddlClaseECT.Text = ie_ClaseECT.ToString()
        ddlClaseCR.Text = ie_ClaseCR.ToString()
        ddlFormaPago.Text = ie_FormaPago.ToString()

        LlamarPagos()
        LlamarClases()

    End Sub

#Region "Methods"

    Private Sub LlamarPagos()

        Dim ctx As New CLRDataContext()

		Dim pagos = From p In ctx.TipoPago
					Select
						ID = p.idPago,
						Nombre = p.NomPago

		ddlFormaPago.ValueMember = "ID"
        ddlFormaPago.DisplayMember = "Nombre"

        ddlFormaPago.DataSource = pagos.ToList()

        ddlFormaPagoAL.ValueMember = "ID"
        ddlFormaPagoAL.DisplayMember = "Nombre"

        ddlFormaPagoAL.DataSource = pagos.ToList()

    End Sub

    Private Sub LlamarClases()

        Dim ctx As New CLRDataContext()

		Dim clase = From c In ctx.TipoVehiculo
					Select
						ID = c.idVehiculo,
						Nombre = c.Clase

		ddlClaseCR.ValueMember = "ID"
        ddlClaseCR.DisplayMember = "Nombre"

        ddlClaseCR.DataSource = clase.ToList()

        ddlClaseECT.ValueMember = "ID"
        ddlClaseECT.DisplayMember = "Nombre"

        ddlClaseECT.DataSource = clase.ToList()

        ddlClaseAL.ValueMember = "ID"
        ddlClaseAL.DisplayMember = "Nombre"

        ddlClaseAL.DataSource = clase.ToList()

    End Sub

    Private Sub InsertarEvento()

        Dim ctx As New CLRDataContext()

        Dim Evento As New Transacciones
        Dim HoraEvento As New TimeSpan(dtpHora.Value.Hour, dtpHora.Value.Minute, dtpHora.Value.Second)

        Evento.NoEvento = txtEvento.Text
        Evento.NoCarrilCapufe = idCarril
        Evento.NoEmpleadoCapufe = txtNoCajero.Text
        Evento.NoPlaza = NumCaseta
        Evento.idTurno = TurnoD
        Evento.Fecha = dtpFecha.Value
        Evento.Hora = HoraEvento
        Evento.Folio = txtFolio.Text
        Evento.idPago = ddlFormaPago.SelectedValue
        Evento.PRE = ddlClaseECT.SelectedValue
        Evento.POST = ddlClaseECT.SelectedValue
        Evento.idVehiculo = ddlClaseCR.SelectedValue
        Evento.idTarifa = TraerTarifa(NumCaseta, ddlClaseCR.SelectedValue)
        Evento.Dictaminado = True
        Evento.idDictaminacion = TraerUltDictaminacion() + 1
        Evento.Comentarios = txtComentarios.Text
        Evento.Obs_TT = 0
        Evento.Obs_MP = 0
        Evento.Obs_Secuencia = 0
        Evento.Obs_Paso = 0
        Evento.Num_Ejes = 0
        Evento.Anulado = False
        Evento.Capturado = True

        ctx.Transacciones.InsertOnSubmit(Evento)
        ctx.SubmitChanges()

    End Sub

    Private Sub InsertarDictaminacion()

        Dim ctx As New CLRDataContext()

        Dim Dictamen As New Dictaminaciones

        Dictamen.idDictaminacion = TraerUltDictaminacion() + 1
        Dictamen.NoTransaccion = txtEvento.Text
        Dictamen.NoEmpleadoCapufe = NoEmpleado
        Dictamen.Fecha = Date.Now.Date()
        Dictamen.Hora = Date.Now.TimeOfDay()
        Dictamen.idVehiculo = ddlClaseAL.SelectedValue
        Dictamen.idPago = ddlFormaPagoAL.SelectedValue
        Dictamen.NuevaTarifa = TraerTarifa(NumCaseta, ddlClaseAL.SelectedValue)

        ctx.Dictaminaciones.InsertOnSubmit(Dictamen)
        ctx.SubmitChanges()

    End Sub

    Private Function TraerUltDictaminacion() As Integer

        Dim ctx As New CLRDataContext()

        Dim ult = (From u In ctx.Dictaminaciones
                   Select u.idDictaminacion).Max()

        Return ult

    End Function

    Private Function TraerTarifa(Caseta As Integer, Vehiculo As Integer) As Double

        Dim ctx As New CLRDataContext()

		Dim tarif = (From t In ctx.Tarifas
					 Where t.NoPlaza = Caseta And t.idVehiculo = Vehiculo
					 Select t.Tarifa).SingleOrDefault()

		Return tarif

    End Function

#End Region

#Region "Events"

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If (txtEvento.Text Is Nothing OrElse txtEvento.Text = String.Empty) Or (txtFolio.Text Is Nothing OrElse txtFolio.Text = String.Empty) Or (txtNoCajero.Text Is Nothing OrElse txtNoCajero.Text = String.Empty) Then
            RadMessageBox.Show("Algunos campos obligatorios no estan llenos, intente de nuevo.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            If RadMessageBox.Show("Esta por insertar un evento, ¿Desea continiar?", "Confirmar", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then
                Try
                    InsertarEvento()
                    InsertarDictaminacion()
                    RadMessageBox.Show("El evento se inserto correctamente.", "Inserción Exitosa", MessageBoxButtons.OK, RadMessageIcon.Info)
                    Me.Close()
                Catch ex As Exception
                    RadMessageBox.Show(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private Sub txtComentarios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarios.KeyPress

        If txtComentarios.TextLength = 70 Then
            RadMessageBox.Show("Solo se permiten 70 caracteres.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    Private Sub txtEvento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEvento.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Este campo solo permite numeros.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Info)
            e.Handled = True
            Return
        End If

    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Este campo solo permite numeros.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Info)
            e.Handled = True
            Return
        End If

    End Sub

    Private Sub txtNoCajero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoCajero.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Este campo solo permite numeros.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Info)
            e.Handled = True
            Return
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtNoEjes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoEjes.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Este campo solo permite numeros.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Info)
            e.Handled = True
            Return
        End If

    End Sub

    Private Sub txtNoEjes_2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoEjes_2.KeyPress

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Este campo solo permite numeros.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Info)
            e.Handled = True
            Return
        End If

    End Sub

    Private Sub ddlClaseAL_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles ddlClaseAL.SelectedIndexChanged

        If ddlClaseAL.SelectedValue = T09PnnC Or ddlClaseAL.SelectedValue = T01LnnA Then
            lblNoEjes.Visible = True
            txtNoEjes.Visible = True
        Else
            lblNoEjes.Visible = False
            txtNoEjes.Visible = False
        End If

    End Sub

    Private Sub ddlClaseCR_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles ddlClaseCR.SelectedIndexChanged

        If ddlClaseCR.SelectedValue = T09PnnC Or ddlClaseCR.SelectedValue = T01LnnA Then
            lblNoEjes_2.Visible = True
            txtNoEjes_2.Visible = True
        Else
            lblNoEjes_2.Visible = False
            txtNoEjes_2.Visible = False
        End If

    End Sub

#End Region

End Class
