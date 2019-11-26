Imports Telerik.WinControls

''' <summary>
''' Formulario Login
''' Se usa para pedir las credenciales al usuario
''' en el acceso y salida del programa.
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @27/03/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>

Public Class RadLogin

    Dim Email As String
    Dim Password As String

    Private Sub RadLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        ActivarVistaUno()
        'EffectIn()

    End Sub

#Region "Methods"

    Private Sub ActivarVistaUno()

        Try
			pbImagen.Image = System.Drawing.Image.FromFile("C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\Logos\Bloqueo1.png")
			txtUsuario.Visible = True
            txtUsuario.Text = ""
            txtContraseña.Visible = True
            txtContraseña.Text = ""
            lblUsuario.Visible = True
            lblContraseña.Visible = True
            lblOlvide.Visible = True
            btnAceptar.Visible = True
            btnCancelar.Visible = True
            lblBienvenida.Visible = False
            lblDatosUsuario.Visible = False
            btnContinuar.Visible = False
            txtUsuario.Select()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ActivarVistaDos()

        Try
			pbImagen.Image = System.Drawing.Image.FromFile("C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\Logos\Desbloqueo1.png")
			txtUsuario.Visible = False
            txtContraseña.Visible = False
            lblUsuario.Visible = False
            lblContraseña.Visible = False
            lblOlvide.Visible = False
            btnAceptar.Visible = False
            btnCancelar.Visible = False
            btnContinuar.Visible = True
            lblBienvenida.Visible = True
            lblDatosUsuario.Visible = True
            btnContinuar.Select()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ActivarVistaTres()

        Try
			pbImagen.Image = System.Drawing.Image.FromFile("C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\Logos\Bloqueo1.png")
			txtUsuario.Visible = True
            txtUsuario.Text = txtUsuario.Text
            txtUsuario.Enabled = False
            txtContraseña.Visible = True
            txtContraseña.Text = ""
            lblUsuario.Visible = True
            lblContraseña.Visible = True
            btnAceptar.Visible = True
            btnCancelar.Visible = True
            lblBienvenida.Visible = False
            lblDatosUsuario.Visible = False
            btnContinuar.Visible = False
            lblOlvide.Visible = False
            txtContraseña.Select()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DarBienvenida()

        lblBienvenida.Text = "Bienvenido!"
        ExtraerUsuario()

    End Sub

    Private Sub ExtraerUsuario()

		Dim ctx As New CLRDataContext()

		Try
            Dim user = (From U In ctx.PersonalCLR
                        Where U.NoEmpleadoCapufe = Integer.Parse(txtUsuario.Text)
                        Select U.Nombre + " " + U.APaterno).SingleOrDefault()

            lblDatosUsuario.Text = user

        Catch ex As Exception
            RadMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function VerificarActivo(User As String) As Boolean

		Dim ctx As New CLRDataContext()

		Dim activ = (From e In ctx.Usuarios
                     Where e.Nombre = User
                     Select e.Activo).FirstOrDefault()

        If activ = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function ValidarUsuario(Valor As String) As Boolean

		Dim ctx As New CLRDataContext()

		Dim user = (From u In ctx.Usuarios
                    Where u.Nombre = Valor And u.Activo = True
                    Select u.Nombre).FirstOrDefault()

        If user Is Nothing OrElse user.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function ValidarContraseña(Passwor As String) As Boolean

		Dim ctx As New CLRDataContext()

		Dim pass = (From p In ctx.Usuarios
                    Where p.Contraseña = Passwor
                    Select p.Contraseña).FirstOrDefault()

        If pass Is Nothing OrElse pass.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function Comparar(User As String, Password As String) As Boolean

		Dim ctx As New CLRDataContext()

		Dim usuario = (From u In ctx.Usuarios
					   Where u.Nombre = User
					   Select u.idUsuario).SingleOrDefault()

		Dim pass = (From p In ctx.Usuarios
                    Where p.Contraseña = Password And p.Nombre = txtUsuario.Text
                    Select p.idUsuario).SingleOrDefault()

        If usuario = pass Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Nivel(Empleado As Integer)

        Dim db As New CLRDataContext()

        Dim tipo = (From t In db.Usuarios
                    Where t.Nombre = Empleado.ToString()
                    Select t.idTipo).SingleOrDefault()

        idNivel = Integer.Parse(tipo)

    End Sub

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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        If sesion = False Then
            EffectOut()
            Me.Close()
        Else
            Me.Hide()
            txtContraseña.Text = ""
            MDIPrincipal1.Show()
        End If

    End Sub

    Private Sub txtContraseña_TextChanged(sender As Object, e As EventArgs) Handles txtContraseña.TextChanged

        txtContraseña.PasswordChar = "*"

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If ValidarUsuario(txtUsuario.Text) = True And ValidarContraseña(txtContraseña.Text) = True And VerificarActivo(txtUsuario.Text) = True Then
            If Comparar(txtUsuario.Text, txtContraseña.Text) = True Then
                If sesion = False Then

                    ActivarVistaDos()
                    DarBienvenida()
                Else
                    MDIPrincipal1.Close()
                    EffectOut()
                    Me.Close()
                End If
            Else
                If sesion = True Then
                    RadMessageBox.Show("La contraseña es incorrecta", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Error)
                Else
                    RadMessageBox.Show("El usuario o contraseña son incorrectos", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Error)
                End If
            End If
        Else
            If sesion = True Then
                RadMessageBox.Show("La contraseña es incorrecta", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Error)
                txtContraseña.Text = ""
            Else
                RadMessageBox.Show("El usuario o contraseña son incorrectos", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Error)
                txtContraseña.Text = ""
            End If
        End If

    End Sub

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click

        NoEmpleado = Integer.Parse(txtUsuario.Text)
        Nivel(NoEmpleado)
        MDIPrincipal1.Show()
        sesion = True
        Me.Hide()
        ActivarVistaTres()

    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnAceptar.PerformClick()
        End If

    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress

        txtUsuario.BackColor = Color.White

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtContraseña.Focus()
        End If

    End Sub

    Private Sub lblOlvide_Click(sender As Object, e As EventArgs) Handles lblOlvide.Click

        If txtUsuario.Text Is Nothing OrElse txtUsuario.Text = String.Empty Then
            RadMessageBox.Show("Ingrese su nombre de usuario en el campo indicado y de click de nuevo en 'olvide mi contraseña'.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Info)
            txtUsuario.Focus()
            txtUsuario.BackColor = Color.Moccasin
        ElseIf ValidarUsuario(txtUsuario.Text) = True Then
            TraerCorreo(txtUsuario.Text)
            TraerContraseña(txtUsuario.Text)
            enviarCorreo("soporte.clr.pass@gmail.com", "soporteclr", "En respuesta a su solicitud de recuperación de contraseña se adjunta la misma: " & vbCrLf & vbCrLf & Password, "Soporte CLR-Recuperación de contraseña", Email, txtUsuario.Text)
        Else
            RadMessageBox.Show("El usuario ingresado no existe, verifique.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Error)
        End If

    End Sub

    Private Sub lblOlvide_MouseMove(sender As Object, e As MouseEventArgs) Handles lblOlvide.MouseMove

        lblOlvide.Font = New Font("Segoe UI", 8.5, FontStyle.Underline)

    End Sub

    Private Sub lblOlvide_MouseLeave(sender As Object, e As EventArgs) Handles lblOlvide.MouseLeave

        lblOlvide.Font = New Font("Segoe UI", 8, FontStyle.Underline)

    End Sub

    Private Sub txtUsuario_Leave(sender As Object, e As EventArgs) Handles txtUsuario.Leave

        txtUsuario.BackColor = Color.White

    End Sub

#End Region

End Class
