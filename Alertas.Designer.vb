<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Alertas
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Alertas))
        Me.btnOk = New Bunifu.Framework.UI.BunifuImageButton()
        Me.lblTitulo = New Telerik.WinControls.UI.RadLabel()
        Me.lblMensaje1 = New Telerik.WinControls.UI.RadLabel()
        Me.pbAdvertencia = New System.Windows.Forms.PictureBox()
        Me.lblMensaje2 = New Telerik.WinControls.UI.RadLabel()
        Me.btnYes = New Bunifu.Framework.UI.BunifuImageButton()
        Me.btnNo = New Bunifu.Framework.UI.BunifuImageButton()
        Me.pbInterrogacion = New System.Windows.Forms.PictureBox()
        CType(Me.btnOk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMensaje1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAdvertencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMensaje2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnYes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbInterrogacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageActive = Nothing
        Me.btnOk.Location = New System.Drawing.Point(271, 151)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(60, 60)
        Me.btnOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnOk.TabIndex = 1
        Me.btnOk.TabStop = False
        Me.btnOk.Zoom = 10
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Arial Black", 10.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(209, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(2, 2)
        Me.lblTitulo.TabIndex = 2
        '
        'lblMensaje1
        '
        Me.lblMensaje1.Font = New System.Drawing.Font("Arial Black", 10.0!)
        Me.lblMensaje1.ForeColor = System.Drawing.Color.White
        Me.lblMensaje1.Location = New System.Drawing.Point(161, 75)
        Me.lblMensaje1.Name = "lblMensaje1"
        Me.lblMensaje1.Size = New System.Drawing.Size(2, 2)
        Me.lblMensaje1.TabIndex = 3
        '
        'pbAdvertencia
        '
        Me.pbAdvertencia.Image = CType(resources.GetObject("pbAdvertencia.Image"), System.Drawing.Image)
        Me.pbAdvertencia.Location = New System.Drawing.Point(27, 57)
        Me.pbAdvertencia.Name = "pbAdvertencia"
        Me.pbAdvertencia.Size = New System.Drawing.Size(100, 113)
        Me.pbAdvertencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAdvertencia.TabIndex = 4
        Me.pbAdvertencia.TabStop = False
        '
        'lblMensaje2
        '
        Me.lblMensaje2.Font = New System.Drawing.Font("Arial Black", 10.0!)
        Me.lblMensaje2.ForeColor = System.Drawing.Color.White
        Me.lblMensaje2.Location = New System.Drawing.Point(161, 103)
        Me.lblMensaje2.Name = "lblMensaje2"
        Me.lblMensaje2.Size = New System.Drawing.Size(2, 2)
        Me.lblMensaje2.TabIndex = 5
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.Color.Transparent
        Me.btnYes.Image = CType(resources.GetObject("btnYes.Image"), System.Drawing.Image)
        Me.btnYes.ImageActive = Nothing
        Me.btnYes.Location = New System.Drawing.Point(176, 151)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(70, 70)
        Me.btnYes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnYes.TabIndex = 6
        Me.btnYes.TabStop = False
        Me.btnYes.Zoom = 10
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.Transparent
        Me.btnNo.Image = CType(resources.GetObject("btnNo.Image"), System.Drawing.Image)
        Me.btnNo.ImageActive = Nothing
        Me.btnNo.Location = New System.Drawing.Point(352, 151)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(60, 60)
        Me.btnNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnNo.TabIndex = 7
        Me.btnNo.TabStop = False
        Me.btnNo.Zoom = 10
        '
        'pbInterrogacion
        '
        Me.pbInterrogacion.Image = CType(resources.GetObject("pbInterrogacion.Image"), System.Drawing.Image)
        Me.pbInterrogacion.Location = New System.Drawing.Point(27, 57)
        Me.pbInterrogacion.Name = "pbInterrogacion"
        Me.pbInterrogacion.Size = New System.Drawing.Size(100, 113)
        Me.pbInterrogacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbInterrogacion.TabIndex = 8
        Me.pbInterrogacion.TabStop = False
        '
        'Alertas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(507, 228)
        Me.Controls.Add(Me.pbInterrogacion)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblMensaje2)
        Me.Controls.Add(Me.pbAdvertencia)
        Me.Controls.Add(Me.lblMensaje1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Alertas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alertas"
        CType(Me.btnOk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMensaje1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAdvertencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMensaje2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnYes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbInterrogacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOk As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents lblTitulo As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblMensaje1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents pbAdvertencia As PictureBox
    Friend WithEvents lblMensaje2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnYes As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents btnNo As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents pbInterrogacion As PictureBox
End Class

