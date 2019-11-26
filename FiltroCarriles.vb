Imports Telerik.WinControls

''' <summary>
''' Formulario Filtro
''' Se muestra previo al formulario
''' de Verificación de Carriles para
''' seleccionar una plaza y una fecha en especifico
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @31/03/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>
Public Class FiltroCarriles

    Private Sub FiltroCarriles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadMessageBox.SetThemeName(Theme)
        dtpFecha.Value = Date.Now.Date
        CargarListaPlazas()

    End Sub

#Region "Methods"

    Private Sub CargarListaPlazas()

        Dim ctx As New CLRDataContext

		Dim caseta = From c In ctx.Plazas
					 Order By c.NomPlaza
					 Select
						 ID = c.NoPlaza,
						 Nombre = c.NomPlaza

		ddlPlaza.ValueMember = "ID"
        ddlPlaza.DisplayMember = "Nombre"

        ddlPlaza.DataSource = caseta.ToList()


    End Sub

    Private Sub Conversionplaza()

        Dim ctx As New CLRDataContext

		Dim num = (From n In ctx.Plazas
				   Where n.NomPlaza = ddlPlaza.Text
				   Select n.NoPlaza).SingleOrDefault

		plazaC = num

    End Sub

    Private Function ExistenDatos(Dia As Date) As Boolean

        Dim db As New CLRDataContext()

		Dim existe = (From e In db.Transacciones
					  Where e.Fecha = Dia
					  Select e).FirstOrDefault()

		If existe Is Nothing OrElse existe.ToString() = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

#End Region

#Region "Events"

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        fechaC = dtpFecha.Text
        plazaC = ddlPlaza.SelectedValue
        NomC = ddlPlaza.Text

        If ExistenDatos(dtpFecha.Text) = True Then
            NumeroPlaza = ddlPlaza.SelectedValue
            VerificacionDeCarriles.Show()
            Me.Hide()
        Else
            RadMessageBox.Show("No hay datos para la fecha seleccionada, intente de nuevo.", "Verifique", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

#End Region

End Class
