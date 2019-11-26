Imports Telerik.WinControls

''' <summary>
''' Formulario Registro
''' Para dar de alta nuevos usuarios.
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @04/05/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>

Public Class Registro

    Dim UserName As String = ""
    Dim Password As Boolean = False
    Dim CorreoVal As Boolean = False

    Private Sub Login1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        ListarTipos()
        lblMensaje.Text = ""
        lblValidacionCorreo.Text = ""
        txtAdmin.Text = NoEmpleado
        txtAdmin.Enabled = False

    End Sub

#Region "Methods"

    Private Sub ListarTipos()

        Dim db As New CLRDataContext()

        Dim type = From t In db.TipoUsuario
                   Order By t.idTipo
                   Select
                       ID = t.idTipo,
                       Tipo = t.Tipo

        ddlTipo.ValueMember = "ID"
        ddlTipo.DisplayMember = "Tipo"

        ddlTipo.DataSource = type.ToList()

    End Sub

    Private Sub Registrar()

        Dim db As New CLRDataContext()

        Dim num = (From n In db.Usuarios
                   Select n.idUsuario).Max()

        Dim user As New Usuarios()

        user.idUsuario = num + 1
        user.Nombre = txtUsuario.Text
        user.Contraseña = txtContraseña.Text
        user.idTipo = ddlTipo.SelectedValue
        user.Correo = txtCorreo.Text
        user.Activo = 1

        db.Usuarios.InsertOnSubmit(user)
        db.SubmitChanges()

    End Sub

    Private Function ExisteUsuario(User As String)

        Dim db As New CLRDataContext()

        Dim existe = (From e In db.Usuarios
                      Where e.Nombre = User And e.Activo = True
                      Select e.Nombre).SingleOrDefault()

        If existe Is Nothing OrElse existe.ToString() = String.Empty Then
            Return False 'No existe
        Else
            Return True 'Si existe
        End If

    End Function

    Private Sub Limpiar()

        txtUsuario.Text = ""
        txtContraseña.Text = ""
        lblMensaje.Text = ""
        lblAdvertencia.Text = ""
        txtCorreo.Text = ""
        lblValidacionCorreo.Text = ""
        lblVal.Text = ""

    End Sub

    Private Sub DarDeBaja(User As String)

        Dim db As New CLRDataContext()

        Dim buscar = From b In db.Usuarios
                     Where b.Nombre = User
                     Select b

        For Each b As Usuarios In buscar
            b.Activo = 0
        Next

        db.SubmitChanges()

    End Sub

    Private Sub ActivarUsuario(User As String)

        Dim db As New CLRDataContext()

        Dim buscar = From b In db.Usuarios
                     Where b.Nombre = User
                     Select b

        For Each b As Usuarios In buscar
            b.Contraseña = txtContraseña.Text
            b.idTipo = ddlTipo.SelectedValue
            b.Activo = 1
        Next

        db.SubmitChanges()

    End Sub

    Private Function UserActivo(User As String) As Boolean

        Dim db As New CLRDataContext()

        Dim act = (From a In db.Usuarios
                   Where a.Nombre = User
                   Select a.Activo).SingleOrDefault()

        If act = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function ValidateEmail(ByVal email As String) As Boolean

        Dim emailRegex As New System.Text.RegularExpressions.Regex("^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)

        Return emailMatch.Success

    End Function

    Private Function Comparar(User As String, Password As String) As Boolean

        Dim ctx As New CLRDataContext()

        Dim usuario = (From u In ctx.Usuarios
                       Where u.Nombre = User
                       Select u.idUsuario).SingleOrDefault()

        Dim pass = (From p In ctx.Usuarios
                    Where p.Contraseña = Password And p.Nombre = User
                    Select p.idUsuario).SingleOrDefault()

        If usuario = pass Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region

#Region "Events"

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        If UserName = "OCUPADO" Or txtContraseña.Text = String.Empty Or txtUsuario.Text = String.Empty Or txtCorreo.Text = String.Empty Then
            lblAdvertencia.Text = "*Faltan campos por llenar o los datos son invalidos," + vbCrLf + "Verifique"
        ElseIf CorreoVal = True Then
            Select Case UserName
                Case "DISPONIBLE"
                    Registrar()
                    Limpiar()
                    RadMessageBox.Show("El usuario se registro correctamente.", "REGISTRO EXITOSO", MessageBoxButtons.OK, RadMessageIcon.Info)
                Case "INACTIVO"
                    ActivarUsuario(txtUsuario.Text)
                    Limpiar()
                    RadMessageBox.Show("El usuario se registro correctamente.", "REGISTRO EXITOSO", MessageBoxButtons.OK, RadMessageIcon.Info)
            End Select
        Else
            RadMessageBox.Show("Debe ingresar un correo valido.", "Correo invalido", MessageBoxButtons.OK, RadMessageIcon.Error)
        End If

    End Sub

    Private Sub txtUsuario_Leave(sender As Object, e As EventArgs) Handles txtUsuario.Leave

        If ExisteUsuario(txtUsuario.Text) = True Then
            If UserActivo(txtUsuario.Text) = True Then
                lblMensaje.ForeColor = Color.Red
                lblMensaje.Text = "*El Usuario ya Existe"
                UserName = "OCUPADO"
            Else
                lblMensaje.ForeColor = Color.Green
                lblMensaje.Text = "Nombre de Usuario Disponible"
                UserName = "INACTIVO"
            End If
        Else
            lblMensaje.ForeColor = Color.Green
            lblMensaje.Text = "Nombre de Usuario Disponible"
            UserName = "DISPONIBLE"
        End If

        If txtUsuario.Text = String.Empty Then
            lblMensaje.Text = ""
        End If

    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress

        lblMensaje.Text = ""

        If Not (Char.IsNumber(e.KeyChar)) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            RadMessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Error)
            e.Handled = True
            Return
        End If

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtContraseña.Focus()
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)

        Me.Close()

    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click

        If ExisteUsuario(txtUserBaja.Text) = True And UserActivo(txtUserBaja.Text) = True Then
            If Comparar(NoEmpleado, txtPassword.Text) = True Then
                If RadMessageBox.Show("Esta por eliminar un usuario, desea continuar?", "Atención", MessageBoxButtons.YesNo, RadMessageIcon.Question) = DialogResult.Yes Then
                    DarDeBaja(txtUserBaja.Text)
                    RadMessageBox.Show("El Usuario se elimino correctamente.", "ELIMINACION EXITOSA", MessageBoxButtons.OK, RadMessageIcon.Info)
                End If
            Else
                RadMessageBox.Show("La contraseña no coincide", "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Else
            RadMessageBox.Show("El usuario no existe!", "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        End If

    End Sub

    Private Sub ddlTipo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles ddlTipo.SelectedIndexChanged

        lblAdvertencia.Text = ""

    End Sub

    Private Sub txtUsuario_Click(sender As Object, e As EventArgs) Handles txtUsuario.Click

        lblAdvertencia.Text = ""

    End Sub

    Private Sub txtContraseña_Click(sender As Object, e As EventArgs) Handles txtContraseña.Click

        lblAdvertencia.Text = ""

    End Sub

    Private Sub txtCorreo_Leave(sender As Object, e As EventArgs) Handles txtCorreo.Leave

        If txtCorreo.Text = "" Then
            lblValidacionCorreo.Text = ""
            lblVal.Text = ""
        Else
            If ValidateEmail(txtCorreo.Text) = True Then
                lblValidacionCorreo.Text = ""
                lblVal.Font = New Font("Wingdings", 20, FontStyle.Bold)
                lblVal.ForeColor = Color.Green
                lblVal.Text = "ü"
                CorreoVal = True
            Else
                lblValidacionCorreo.ForeColor = Color.Red
                lblValidacionCorreo.Text = "Correo invalido!"
                lblVal.Font = New Font("Wingdings", 20, FontStyle.Bold)
                lblVal.ForeColor = Color.Red
                lblVal.Text = ChrW(251)
                CorreoVal = False
            End If
        End If

    End Sub

    Private Sub txtCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.KeyPress

        lblValidacionCorreo.Text = ""
        lblVal.Text = ""

    End Sub

    Private Sub txtUserBaja_Leave(sender As Object, e As EventArgs) Handles txtUserBaja.Leave

        If txtUserBaja.Text = "" Then
            lblUserVal.Text = ""
            lblMessage.Text = ""
        Else
            If ExisteUsuario(txtUserBaja.Text) = True Then
                lblUserVal.Font = New Font("Wingdings", 20, FontStyle.Bold)
                lblUserVal.ForeColor = Color.Green
                lblUserVal.Text = "ü"
                lblMessage.Text = ""
            Else
                lblUserVal.Font = New Font("Wingdings", 20, FontStyle.Bold)
                lblUserVal.ForeColor = Color.Red
                lblUserVal.Text = ChrW(251)
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "El usuario no existe!"
            End If
        End If

    End Sub

    Private Sub txtUserBaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserBaja.KeyPress

        lblUserVal.Text = ""
        lblMessage.Text = ""

    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave

        If txtPassword.Text = "" Then
            lblPassVal.Text = ""
            lblPassMess.Text = ""
        Else
            If Comparar(NoEmpleado, txtPassword.Text) = True Then
                lblPassVal.Font = New Font("Wingdings", 20, FontStyle.Bold)
                lblPassVal.ForeColor = Color.Green
                lblPassVal.Text = "ü"
                lblPassMess.Text = ""
            Else
                lblPassVal.Font = New Font("Wingdings", 20, FontStyle.Bold)
                lblPassVal.ForeColor = Color.Red
                lblPassVal.Text = ChrW(251)
                lblPassMess.ForeColor = Color.Red
                lblPassMess.Text = "La contraseña no coincide!"
            End If
        End If

    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress

        lblPassVal.Text = ""
        lblPassMess.Text = ""

    End Sub

#End Region

End Class
