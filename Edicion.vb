Imports Telerik.WinControls

''' <summary>
''' Formulario Edicion
''' Para dar de alta nuevos usuarios.
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @08/05/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>
Public Class Edicion

    Dim Mensajes As New Mensajes()

    Private Sub Edicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        gpbEditable.Visible = False
        pbInicio.Visible = True
        pbCorrecto.Visible = False
        pbError.Visible = False

    End Sub

#Region "Methods"

    Private Function ExisteUser(Numero As String) As Boolean

        Dim db As New CLRDataContext()

        Dim existe = (From e In db.Usuarios
                      Where e.Nombre = Numero And e.Activo = True
                      Select e.Nombre).SingleOrDefault()

        If existe Is Nothing OrElse existe.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub CargarTipos()

        Dim db As New CLRDataContext()

        Dim niveles = From n In db.TipoUsuario
                      Select
                          ID = n.idTipo,
                          Nombre = n.Tipo

        ddlTipo.ValueMember = "ID"
        ddlTipo.DisplayMember = "Nombre"
        ddlTipo.DataSource = niveles.ToList()

    End Sub

    Private Function VerificarPassword(User As String) As Boolean

        Dim db As New CLRDataContext()

        Dim pass = (From p In db.Usuarios
                    Where p.Nombre = User
                    Select p.Contraseña).SingleOrDefault()

        If pass = txtContraseña.Text Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Modificar(User As String)

        Dim db As New CLRDataContext()

        Dim buscar = From b In db.Usuarios
                     Where b.Nombre = User
                     Select b

        For Each U As Usuarios In buscar
            U.Contraseña = txtRepetir.Text
            U.idTipo = Integer.Parse(ddlTipo.SelectedValue)
        Next

        db.SubmitChanges()

    End Sub

    Private Sub LimpiarDatos()

        txtUsuario.Text = ""
        txtContraseña.Text = ""
        txtNueva.Text = ""
        txtRepetir.Text = ""
        lblMensaje.Text = ""
        lblError.Text = ""

    End Sub

#End Region

#Region "Events"

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If ExisteUser(txtBuscar.Text) = True Then
            gpbEditable.Visible = True
            pbInicio.Visible = False
            lblMensaje.Text = ""
            txtUsuario.Text = txtBuscar.Text
            CargarTipos()
        Else
            lblMensaje.Text = "El Número de Usuario Ingresado NO Existe!"
            lblMensaje.ForeColor = Color.Red
        End If

    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress

        lblError.Text = ""
        lblAdvertencia.Text = ""
        lblMensaje.Text = ""
        pbCorrecto.Visible = False
        pbError.Visible = False

        gpbEditable.Visible = False
        pbInicio.Visible = True

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Solo se permiten números.", "Atención!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            e.Handled = True
            Return
        End If

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnBuscar.PerformClick()
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If VerificarPassword(txtUsuario.Text) = True Then
            If txtNueva.Text = txtRepetir.Text Then
                If RadMessageBox.Show("Esta por modificar un registro, desea continuar?", "Atención!", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then
                    Try
                        Modificar(txtUsuario.Text)
                        lblAdvertencia.Visible = True
                        lblAdvertencia.Text = "Las Modificaciones se" + vbCrLf + "Guardaron Correctamente"
                        lblAdvertencia.ForeColor = Color.Green
                        pbCorrecto.Visible = True
                        pbError.Visible = False
                        LimpiarDatos()
                    Catch ex As Exception
                        RadMessageBox.Show(ex.Message)
                    End Try
                End If
            End If
        Else
            lblAdvertencia.Text = "Contraseña Incorrecta!"
            pbError.Visible = True
            pbCorrecto.Visible = False
            txtContraseña.Focus()
            txtContraseña.BackColor = Color.LightSteelBlue
        End If

    End Sub

    Private Sub txtRepetir_Leave(sender As Object, e As EventArgs) Handles txtRepetir.Leave

        If txtNueva.Text <> txtRepetir.Text Then
            lblError.ForeColor = Color.Red
            lblError.Text = "*Las contraseñas nuevas NO " + vbCrLf + "coinciden, Verifique"
        Else
            lblError.ForeColor = Color.Green
            lblError.Text = "Las Contraseñas coinciden"
        End If

    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress

        pbError.Visible = False
        txtContraseña.BackColor = Color.White
        lblAdvertencia.Text = ""

    End Sub

    Private Sub txtRepetir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRepetir.KeyPress

        lblError.Text = ""

    End Sub

    Private Sub txtNueva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNueva.KeyPress

        lblError.Text = ""

    End Sub

    Private Sub txtNueva_Leave(sender As Object, e As EventArgs) Handles txtNueva.Leave

        If txtRepetir.Text <> "" Then
            If txtNueva.Text <> txtRepetir.Text Then
                lblError.ForeColor = Color.Red
                lblError.Text = "*Las contraseñas nuevas NO " + vbCrLf + "coinciden, Verifique"
            Else
                lblError.ForeColor = Color.Green
                lblError.Text = "Las Contraseñas coinciden"
            End If
        End If

    End Sub

#End Region

End Class
