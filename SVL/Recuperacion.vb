Imports System.Net.Mail.SmtpClient
Imports System.Net.Mail
Imports Telerik.WinControls

Public Class Recuperacion

    Dim bandera As Boolean = False
    Dim Email As String
    Dim Password As String

    Private Sub Recuperacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#Region "Methods"

    Private Function ValidarUsuario(User As String) As Boolean

        Dim db As New CLRDataContext()

        Dim existe = (From e In db.Usuarios
                      Where e.Nombre = User And e.Activo = True
                      Select e.Nombre).SingleOrDefault()

        If existe Is Nothing OrElse existe.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub TraerCorreo(User As String)

        Dim db As New CLRDataContext()

        Dim mail = (From m In db.Usuarios
                    Where m.Nombre = User
                    Select m.Correo).SingleOrDefault()

        Email = mail.ToString()

    End Sub

    Private Sub TraerContraseña(User As String)

        Dim db As New CLRDataContext()

        Dim pass = (From p In db.Usuarios
                    Where p.Nombre = User
                    Select p.Contraseña).SingleOrDefault()

        Password = pass.ToString()

    End Sub

#End Region

#Region "Events"

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        If bandera = True Then
            TraerCorreo(txtUsuario.Text)
            TraerContraseña(txtUsuario.Text)
            enviarCorreo("soporte.clr.pass@gmail.com", "soporteclr", "En respuesta a su solicitud de recuperación de contraseña se adjunta la misma: " & vbCrLf & vbCrLf & Password, "Soporte CLR-Recuperación de contraseña", Email, txtUsuario.Text)
        Else
            RadMessageBox.Show("El usuario ingresado no existe.", "Usuario invalido", MessageBoxButtons.OK, RadMessageIcon.Error)
            txtUsuario.Focus()
        End If

    End Sub

    Private Sub txtUsuario_Leave(sender As Object, e As EventArgs) Handles txtUsuario.Leave

        If ValidarUsuario(txtUsuario.Text) = True Then
            lblMensaje.Text = ""
            bandera = True
        Else
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Text = "El usuario no existe!"
            bandera = False
        End If

    End Sub

#End Region

End Class
