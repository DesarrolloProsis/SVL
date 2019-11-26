
Imports Telerik.WinControls

Public Class Comentar

    Private Sub Comentar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)

        txtEvento.Text = EventoComentar
        txtEvento.Enabled = False

    End Sub

#Region "Methods"

    Private Sub InsertarComentario(ID As Integer)

		Dim ctx As New CLRDataContext()

		Try

			Dim transaction = (From t In ctx.Transacciones
							   Where t.idTransaccion = ID
							   Select t)

			For Each x As Transacciones In transaction
                x.Comentarios = txtComentarios.Text
            Next

            ctx.SubmitChanges()
            RadMessageBox.Show("El comentario se ingreso exitosamente", "Exitoso!", MessageBoxButtons.OK, RadMessageIcon.Info)

        Catch ex As Exception
            RadMessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

#Region "Events"

    Private Sub txtComentarios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarios.KeyPress

        If txtComentarios.TextLength = 70 Then
            RadMessageBox.Show("Solo se permiten 70 caracteres.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If txtEvento.Text Is Nothing OrElse txtEvento.Text = String.Empty Then
            RadMessageBox.Show("Debe tener un número de evento", "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            InsertarComentario(IdTransaccion)
            Me.Close()
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

#End Region

End Class
