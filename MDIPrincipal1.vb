''' <summary>
''' Formulario MDIPrincipal
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @05/04/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>

Public Class MDIPrincipal1

    Private Sub MDIPrincipal1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'EffectInPrincipal()

        gpbSeleccion.Visible = False
        pbPrincipal.Visible = True
        pbUno.Visible = False
        pbDos.Visible = False
        pbTres.Visible = False
        pbR1.Visible = False
        pbR2.Visible = False
        pbR3.Visible = False
        pbVideo.Visible = False
        pbSinVideo.Visible = False
        pbAutomatico.Visible = False
        pbAlta.Visible = False
        pbEdicion.Visible = False
        pbRecuperacion.Visible = False
        pbAbierto.Visible = False
        pbCerrado.Visible = False
        gpbSeleccion.Text = ""
        lblCarril.Text = ""
        lblTurno.Text = ""
        lblCaseta.Text = ""
        lblVideo.Text = ""
        lblSinVideo.Text = ""
        lblAutomatico.Text = ""

        If idNivel = 1 Then
            PictureBox3.Visible = True
            RadLabel4.Visible = True
        Else
            PictureBox3.Visible = False
            RadLabel4.Visible = False
        End If

#Region "ToolTip"

        ToolTip1.SetToolTip(pbVideo, "Se hace dictaminación con apoyo de Video")
        ToolTip1.SetToolTip(pbSinVideo, "Se hace dictaminación solo con Foto")
        ToolTip1.SetToolTip(PictureBox4, "Verificación de Carriles y Cortes y, Dictaminación")
        ToolTip1.SetToolTip(PictureBox5, "Menu de Reportes")
        ToolTip1.SetToolTip(PictureBox3, "Opciones de Configuración")

#End Region

    End Sub

#Region "Events"

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        gpbSeleccion.Visible = True
        lblSeleccion.Text = "Modulos"
        pbPrincipal.Visible = False
        pbR1.Visible = False
        pbR2.Visible = False
        pbR3.Visible = False
        pbAlta.Visible = False
        pbEdicion.Visible = False
        pbRecuperacion.Visible = False
        pbAbierto.Visible = False
        pbCerrado.Visible = False
        pbUno.Visible = True
        pbDos.Visible = True
        pbTres.Visible = True
        lblCarril.Text = "Verificación de Carriles"
        lblTurno.Text = "Verificación de Cortes"
        lblCaseta.Text = "Dictaminación"

        pbVideo.Visible = False
        pbSinVideo.Visible = False
        pbAutomatico.Visible = False
        lblVideo.Text = ""
        lblSinVideo.Text = ""
        lblAutomatico.Text = ""

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        gpbSeleccion.Visible = True
        lblSeleccion.Text = "Reportes"
        pbPrincipal.Visible = False
        pbUno.Visible = False
        pbDos.Visible = False
        pbTres.Visible = False
        pbAlta.Visible = False
        pbEdicion.Visible = False
        pbRecuperacion.Visible = False
        pbAbierto.Visible = False
        pbCerrado.Visible = False
        pbR1.Visible = True
        pbR2.Visible = True
        pbR3.Visible = True
        lblCarril.Text = "Liquidación de Carril"
        lblTurno.Text = "Liquidación de Turno"
        lblCaseta.Text = "Liquidación de Día/Caseta"

        pbVideo.Visible = False
        pbSinVideo.Visible = False
        pbAutomatico.Visible = False
        lblVideo.Text = ""
        lblSinVideo.Text = ""
        lblAutomatico.Text = ""

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        gpbSeleccion.Visible = True
        lblSeleccion.Text = "Configuración"
        pbPrincipal.Visible = False
        pbUno.Visible = False
        pbDos.Visible = False
        pbTres.Visible = False
        pbR1.Visible = False
        pbR2.Visible = False
        pbR3.Visible = False
        pbAbierto.Visible = False
        pbCerrado.Visible = False
        lblCarril.Text = "Alta y Baja de Usuarios"
        lblTurno.Text = "Editar Usuarios"
        lblCaseta.Text = "Recuperación de Contraseñas"

        pbAlta.Visible = True
        pbEdicion.Visible = True
        pbRecuperacion.Visible = True

        pbVideo.Visible = False
        pbSinVideo.Visible = False
        pbAutomatico.Visible = False
        lblVideo.Text = ""
        lblSinVideo.Text = ""
        lblAutomatico.Text = ""

    End Sub

    Private Sub pbTres_Click(sender As Object, e As EventArgs) Handles pbTres.Click

        gpbSeleccion.Visible = True
        lblSeleccion.Text = "Dictaminación"
        pbUno.Visible = False
        pbDos.Visible = False
        lblCarril.Text = ""
        lblTurno.Text = ""

        pbVideo.Visible = True
        pbSinVideo.Visible = True
        pbAutomatico.Visible = False '*
        lblVideo.Text = "Con Video"
        lblSinVideo.Text = "Sin Video"
        lblAutomatico.Text = "" '*

    End Sub

    Private Sub pbVideo_Click(sender As Object, e As EventArgs) Handles pbVideo.Click

        BanderaVideo = True
        FiltroDeLiquidacion.Show()

    End Sub

    Private Sub pbSinVideo_Click(sender As Object, e As EventArgs) Handles pbSinVideo.Click

        BanderaVideo = False
        FiltroDeLiquidacion.Show()

    End Sub

    Private Sub pbR1_MouseMove(sender As Object, e As MouseEventArgs) Handles pbR1.MouseMove

        pbR1.Height = 220
        pbR1.Width = 220

    End Sub

    Private Sub pbR1_MouseLeave(sender As Object, e As EventArgs) Handles pbR1.MouseLeave

        pbR1.Height = 200
        pbR1.Width = 200

    End Sub

    Private Sub pbR2_MouseMove(sender As Object, e As MouseEventArgs) Handles pbR2.MouseMove, PictureBox6.MouseMove

        pbR2.Height = 220
        pbR2.Width = 220

    End Sub

    Private Sub pbR2_MouseLeave(sender As Object, e As EventArgs) Handles pbR2.MouseLeave, PictureBox6.MouseLeave

        pbR2.Height = 200
        pbR2.Width = 200

    End Sub

    Private Sub pbR3_MouseMove(sender As Object, e As MouseEventArgs) Handles pbR3.MouseMove

        pbR3.Width = 220
        pbR3.Height = 220

    End Sub

    Private Sub pbR3_MouseLeave(sender As Object, e As EventArgs) Handles pbR3.MouseLeave

        pbR3.Width = 200
        pbR3.Height = 200

    End Sub

    Private Sub pbUno_MouseMove(sender As Object, e As MouseEventArgs) Handles pbUno.MouseMove

        pbUno.Height = 220
        pbUno.Width = 220

    End Sub

    Private Sub pbUno_MouseLeave(sender As Object, e As EventArgs) Handles pbUno.MouseLeave

        pbUno.Height = 200
        pbUno.Width = 200

    End Sub

    Private Sub pbDos_MouseMove(sender As Object, e As MouseEventArgs) Handles pbDos.MouseMove, PictureBox1.MouseMove

        pbDos.Height = 220
        pbDos.Width = 220

    End Sub

    Private Sub pbDos_MouseLeave(sender As Object, e As EventArgs) Handles pbDos.MouseLeave, PictureBox1.MouseLeave

        pbDos.Height = 200
        pbDos.Width = 200

    End Sub

    Private Sub pbTres_MouseMove(sender As Object, e As MouseEventArgs) Handles pbTres.MouseMove

        pbTres.Height = 220
        pbTres.Width = 220

    End Sub

    Private Sub pbTres_MouseLeave(sender As Object, e As EventArgs) Handles pbTres.MouseLeave

        pbTres.Height = 200
        pbTres.Width = 200

    End Sub

    Private Sub pbBaja_MouseMove(sender As Object, e As MouseEventArgs) Handles pbEdicion.MouseMove

        pbEdicion.Height = 220
        pbEdicion.Width = 220

    End Sub

    Private Sub pbBaja_MouseLeave(sender As Object, e As EventArgs) Handles pbEdicion.MouseLeave

        pbEdicion.Height = 200
        pbEdicion.Width = 200

    End Sub

    Private Sub pbAlta_MouseMove(sender As Object, e As MouseEventArgs) Handles pbAlta.MouseMove

        pbAlta.Height = 220
        pbAlta.Width = 220

    End Sub

    Private Sub pbAlta_MouseLeave(sender As Object, e As EventArgs) Handles pbAlta.MouseLeave

        pbAlta.Height = 200
        pbAlta.Width = 200

    End Sub

    Private Sub pbAlta_Click(sender As Object, e As EventArgs) Handles pbAlta.Click

        Registro.Show()

    End Sub

    Private Sub pbUno_Click(sender As Object, e As EventArgs) Handles pbUno.Click

        FiltroCarriles.Show()

    End Sub

    Private Sub pbDos_Click(sender As Object, e As EventArgs) Handles pbDos.Click, PictureBox1.Click

        FiltroDeCortes.Show()

    End Sub

    Private Sub pbVideo_MouseMove(sender As Object, e As MouseEventArgs) Handles pbVideo.MouseMove

        pbVideo.Height = 110
        pbVideo.Width = 110

    End Sub

    Private Sub pbVideo_MouseLeave(sender As Object, e As EventArgs) Handles pbVideo.MouseLeave

        pbVideo.Height = 100
        pbVideo.Width = 100

    End Sub

    Private Sub pbSinVideo_MouseMove(sender As Object, e As MouseEventArgs) Handles pbSinVideo.MouseMove

        pbSinVideo.Height = 110
        pbSinVideo.Width = 110

    End Sub

    Private Sub pbSinVideo_MouseLeave(sender As Object, e As EventArgs) Handles pbSinVideo.MouseLeave

        pbSinVideo.Height = 100
        pbSinVideo.Width = 100

    End Sub

    Private Sub pbR1_Click(sender As Object, e As EventArgs) Handles pbR1.Click

        pbR2.Visible = False
        pbR3.Visible = False
        pbAbierto.Visible = True
        pbCerrado.Visible = True
        lblTurno.Text = ""
        lblCaseta.Text = ""
        lblVideo.Text = "Carriles Abiertos"
        lblSinVideo.Text = "Carriles Cerrados"

    End Sub

    Private Sub pbR2_Click(sender As Object, e As EventArgs) Handles pbR2.Click, PictureBox6.Click

        SeleccionReporte = 2
        FiltroDeReportes.Show()

    End Sub

    Private Sub pbR3_Click(sender As Object, e As EventArgs) Handles pbR3.Click

        SeleccionReporte = 3
        FiltroDeReportes.Show()

    End Sub

    Private Sub MDIPrincipal1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        e.Cancel() = True
        RadLogin.Show()

    End Sub

    Private Sub pbRecuperacion_MouseMove(sender As Object, e As MouseEventArgs) Handles pbRecuperacion.MouseMove

        pbRecuperacion.Height = 220
        pbRecuperacion.Width = 220

    End Sub

    Private Sub pbRecuperacion_MouseLeave(sender As Object, e As EventArgs) Handles pbRecuperacion.MouseLeave

        pbRecuperacion.Height = 200
        pbRecuperacion.Width = 200

    End Sub

    Private Sub pbEdicion_Click(sender As Object, e As EventArgs) Handles pbEdicion.Click

        Edicion.Show()

    End Sub

    Private Sub MDIPrincipal1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        EffectOutPrincipal()

    End Sub

    Private Sub pbRecuperacion_Click(sender As Object, e As EventArgs) Handles pbRecuperacion.Click

        Recuperacion.Show()

    End Sub

    Private Sub pbAutomatico_Click(sender As Object, e As EventArgs) Handles pbAutomatico.Click

        LiquidacionSinRevision.Show()

    End Sub

    Private Sub pbAbierto_Click(sender As Object, e As EventArgs) Handles pbAbierto.Click

        SeleccionReporte = 1
        FiltroDeReportes.Show()

    End Sub

    Private Sub pbCerrado_Click(sender As Object, e As EventArgs) Handles pbCerrado.Click

        SeleccionReporte = 4
        FiltroCarrilesCerrados.Show()

    End Sub

    Private Sub pbAutomatico_MouseMove(sender As Object, e As MouseEventArgs) Handles pbAutomatico.MouseMove

        pbAutomatico.Height = 110
        pbAutomatico.Width = 110

    End Sub

    Private Sub pbAutomatico_MouseLeave(sender As Object, e As EventArgs) Handles pbAutomatico.MouseLeave

        pbAutomatico.Height = 100
        pbAutomatico.Width = 100

    End Sub

    Private Sub pbAbierto_MouseMove(sender As Object, e As MouseEventArgs) Handles pbAbierto.MouseMove

        pbAbierto.Height = 110
        pbAbierto.Width = 110

    End Sub

    Private Sub pbAbierto_MouseLeave(sender As Object, e As EventArgs) Handles pbAbierto.MouseLeave

        pbAbierto.Height = 100
        pbAbierto.Width = 100

    End Sub

    Private Sub pbCerrado_MouseMove(sender As Object, e As MouseEventArgs) Handles pbCerrado.MouseMove

        pbCerrado.Height = 110
        pbCerrado.Width = 110

    End Sub

    Private Sub pbCerrado_MouseLeave(sender As Object, e As EventArgs) Handles pbCerrado.MouseLeave

        pbCerrado.Height = 100
        pbCerrado.Width = 100

    End Sub

#End Region

End Class
