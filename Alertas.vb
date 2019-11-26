Public Class Alertas

    Private Sub Alerta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Opacity = 0.9
        lblTitulo.Text = ""
        lblMensaje1.Text = ""
        lblMensaje2.Text = ""
        btnOk.Visible = False
        btnYes.Visible = False
        btnNo.Visible = False
        pbAdvertencia.Visible = False
        pbInterrogacion.Visible = False
        Respuesta = ""

        If TipoAlerta = "OK" Then
            AlertOK(TituloAlerta, MensajeAlerta1, MensajeAlerta2)
        End If

        If TipoAlerta = "OPTION" Then
            AlertOption(TituloAlerta, MensajeAlerta1, MensajeAlerta2)
        End If

    End Sub

    Public Sub AlertOK(Titulo As String, Mensaje1 As String, Mensaje2 As String)
        btnOk.Visible = True
        pbAdvertencia.Visible = True
        lblTitulo.Text = Titulo
        lblMensaje1.Text = Mensaje1
        lblMensaje2.Text = Mensaje2
    End Sub

    Public Function AlertOption(Titulo As String, Mensaje1 As String, Mensaje2 As String) As String

        btnYes.Visible = True
        btnNo.Visible = True
        pbInterrogacion.Visible = True
        lblTitulo.Text = Titulo
        lblMensaje1.Text = Mensaje1
        lblMensaje2.Text = Mensaje2

        Return Respuesta

    End Function

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Respuesta = "NO"
        Me.Close()
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Respuesta = "YES"
        Me.Close()
    End Sub
End Class
