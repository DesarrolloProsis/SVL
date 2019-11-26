<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Observaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Observaciones))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.txtObservaciones = New Telerik.WinControls.UI.RadTextBoxControl()
        Me.lblComentario = New Telerik.WinControls.UI.RadLabel()
        Me.ddlAdministrador = New Telerik.WinControls.UI.RadDropDownList()
        Me.ddlEncargado = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblEncargado = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnAceptar = New Telerik.WinControls.UI.RadButton()
        Me.btnCancelar = New Telerik.WinControls.UI.RadButton()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComentario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlAdministrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlEncargado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEncargado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.txtObservaciones.Location = New System.Drawing.Point(19, 65)
        Me.txtObservaciones.MaxLength = 230
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(358, 186)
        Me.txtObservaciones.TabIndex = 21
        '
        'lblComentario
        '
        Me.lblComentario.BackColor = System.Drawing.Color.Transparent
        Me.lblComentario.ForeColor = System.Drawing.Color.White
        Me.lblComentario.Location = New System.Drawing.Point(19, 36)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Size = New System.Drawing.Size(108, 23)
        Me.lblComentario.TabIndex = 20
        Me.lblComentario.Text = "Observaciones:"
        Me.lblComentario.ThemeName = "TelerikMetroTouch"
        '
        'ddlAdministrador
        '
        Me.ddlAdministrador.DropDownAnimationEnabled = False
        Me.ddlAdministrador.Location = New System.Drawing.Point(24, 182)
        Me.ddlAdministrador.Name = "ddlAdministrador"
        Me.ddlAdministrador.Size = New System.Drawing.Size(223, 24)
        Me.ddlAdministrador.TabIndex = 22
        Me.ddlAdministrador.ThemeName = "TelerikMetroBlue"
        '
        'ddlEncargado
        '
        Me.ddlEncargado.DropDownAnimationEnabled = False
        Me.ddlEncargado.Location = New System.Drawing.Point(24, 72)
        Me.ddlEncargado.Name = "ddlEncargado"
        Me.ddlEncargado.Size = New System.Drawing.Size(223, 24)
        Me.ddlEncargado.TabIndex = 23
        Me.ddlEncargado.ThemeName = "TelerikMetroBlue"
        '
        'lblEncargado
        '
        Me.lblEncargado.BackColor = System.Drawing.Color.Transparent
        Me.lblEncargado.ForeColor = System.Drawing.Color.White
        Me.lblEncargado.Location = New System.Drawing.Point(24, 43)
        Me.lblEncargado.Name = "lblEncargado"
        Me.lblEncargado.Size = New System.Drawing.Size(145, 23)
        Me.lblEncargado.TabIndex = 24
        Me.lblEncargado.Text = "Encargado de Turno:"
        Me.lblEncargado.ThemeName = "TelerikMetroTouch"
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Location = New System.Drawing.Point(24, 153)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(161, 23)
        Me.RadLabel2.TabIndex = 25
        Me.RadLabel2.Text = "Administrador General:"
        Me.RadLabel2.ThemeName = "TelerikMetroTouch"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.lblComentario)
        Me.RadGroupBox1.Controls.Add(Me.txtObservaciones)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RadGroupBox1.HeaderText = "Observaciones"
        Me.RadGroupBox1.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadGroupBox1.Location = New System.Drawing.Point(312, 28)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(399, 279)
        Me.RadGroupBox1.TabIndex = 26
        Me.RadGroupBox1.Text = "Observaciones"
        Me.RadGroupBox1.ThemeName = "Aqua"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox2.Controls.Add(Me.lblEncargado)
        Me.RadGroupBox2.Controls.Add(Me.ddlAdministrador)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox2.Controls.Add(Me.ddlEncargado)
        Me.RadGroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RadGroupBox2.HeaderText = "Encargado y Administrador"
        Me.RadGroupBox2.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadGroupBox2.Location = New System.Drawing.Point(12, 28)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(287, 279)
        Me.RadGroupBox2.TabIndex = 27
        Me.RadGroupBox2.Text = "Encargado y Administrador"
        Me.RadGroupBox2.ThemeName = "Aqua"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(12, 319)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(169, 49)
        Me.btnAceptar.TabIndex = 28
        Me.btnAceptar.Text = "Generar Reporte"
        Me.btnAceptar.ThemeName = "TelerikMetroBlue"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(542, 319)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(169, 49)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.ThemeName = "TelerikMetroBlue"
        '
        'Observaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(733, 383)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "Observaciones"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComentario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlAdministrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlEncargado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEncargado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents txtObservaciones As Telerik.WinControls.UI.RadTextBoxControl
    Friend WithEvents lblComentario As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ddlAdministrador As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents ddlEncargado As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblEncargado As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnAceptar As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancelar As Telerik.WinControls.UI.RadButton
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

