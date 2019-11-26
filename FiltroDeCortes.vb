
Imports Telerik.WinControls
''' <summary>
''' Formulario FiltroDeCortes
''' Formulario previo a la verificación
''' de cortes, donde se establecen algunos parametros.
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @05/04/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>
Public Class FiltroDeCortes

    Private Sub FiltroDeCortes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        dtpFecha.Text = Date.Now.Date
        TraerPlazas()
        NomCaseta = ""
        dato1 = Nothing

    End Sub

#Region "Methods"

    Private Sub TraerPlazas()

        Dim ctx As New CLRDataContext()

		Dim casetas = From c In ctx.Plazas
					  Order By c.NomPlaza
					  Select
						  ID = c.NoPlaza,
						  Nombre = c.NomPlaza

		ddlPlazas.ValueMember = "ID"
        ddlPlazas.DisplayMember = "Nombre"

        ddlPlazas.DataSource = casetas.ToList()

    End Sub

    Private Function ExistenDatos(Valor As Date) As Boolean

        Dim ctx As New CLRDataContext()

		Dim query = (From q In ctx.Declaraciones
					 Where q.Fecha = Valor
					 Select q).FirstOrDefault()

		If query Is Nothing OrElse query.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

#End Region

#Region "Events"

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click

        Try
            NomCaseta = ddlPlazas.Text
            NumeroCaseta = ddlPlazas.SelectedValue
            idCaseta = ddlPlazas.SelectedValue
            dato1 = dtpFecha.Text

            If ExistenDatos(dato1) = True Then
                VerificacionDeCortes.Show()
                Me.Hide()
            Else
                RadMessageBox.Show("No hay datos para la fecha seleccionada, intente con otra fecha.", "VERIFIQUE", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

End Class
