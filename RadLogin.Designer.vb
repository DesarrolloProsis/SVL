<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RadLogin
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RadLogin))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblDatosUsuario = New Telerik.WinControls.UI.RadLabel()
        Me.lblBienvenida = New Telerik.WinControls.UI.RadLabel()
        Me.lblOlvide = New Telerik.WinControls.UI.RadLabel()
        Me.lblContraseña = New Telerik.WinControls.UI.RadLabel()
        Me.lblUsuario = New Telerik.WinControls.UI.RadLabel()
        Me.txtContraseña = New Telerik.WinControls.UI.RadTextBox()
        Me.txtUsuario = New Telerik.WinControls.UI.RadTextBox()
        Me.btnContinuar = New Telerik.WinControls.UI.RadButton()
        Me.btnCancelar = New Telerik.WinControls.UI.RadButton()
        Me.btnAceptar = New Telerik.WinControls.UI.RadButton()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.lblDatosUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBienvenida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOlvide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblContraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnContinuar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.lblDatosUsuario)
        Me.RadGroupBox1.Controls.Add(Me.lblBienvenida)
        Me.RadGroupBox1.Controls.Add(Me.lblOlvide)
        Me.RadGroupBox1.Controls.Add(Me.lblContraseña)
        Me.RadGroupBox1.Controls.Add(Me.lblUsuario)
        Me.RadGroupBox1.Controls.Add(Me.txtContraseña)
        Me.RadGroupBox1.Controls.Add(Me.txtUsuario)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(210, 31)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(242, 136)
        Me.RadGroupBox1.TabIndex = 1
        Me.RadGroupBox1.ThemeName = "Aqua"
        '
        'lblDatosUsuario
        '
        Me.lblDatosUsuario.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDatosUsuario.Location = New System.Drawing.Point(64, 73)
        Me.lblDatosUsuario.Name = "lblDatosUsuario"
        Me.lblDatosUsuario.Size = New System.Drawing.Size(2, 2)
        Me.lblDatosUsuario.TabIndex = 6
        '
        'lblBienvenida
        '
        Me.lblBienvenida.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblBienvenida.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblBienvenida.Location = New System.Drawing.Point(64, 39)
        Me.lblBienvenida.Name = "lblBienvenida"
        Me.lblBienvenida.Size = New System.Drawing.Size(2, 2)
        Me.lblBienvenida.TabIndex = 5
        '
        'lblOlvide
        '
        Me.lblOlvide.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Underline)
        Me.lblOlvide.ForeColor = System.Drawing.Color.Blue
        Me.lblOlvide.Location = New System.Drawing.Point(104, 111)
        Me.lblOlvide.Name = "lblOlvide"
        Me.lblOlvide.Size = New System.Drawing.Size(108, 18)
        Me.lblOlvide.TabIndex = 4
        Me.lblOlvide.Text = "Olvide mi contraseña"
        Me.lblOlvide.ThemeName = "TelerikMetroTouch"
        '
        'lblContraseña
        '
        Me.lblContraseña.BackColor = System.Drawing.Color.Transparent
        Me.lblContraseña.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblContraseña.ForeColor = System.Drawing.Color.White
        Me.lblContraseña.Location = New System.Drawing.Point(19, 73)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(87, 23)
        Me.lblContraseña.TabIndex = 3
        Me.lblContraseña.Text = "Contraseña"
        Me.lblContraseña.ThemeName = "TelerikMetroTouch"
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.Color.White
        Me.lblUsuario.Location = New System.Drawing.Point(40, 23)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(62, 23)
        Me.lblUsuario.TabIndex = 2
        Me.lblUsuario.Text = "Usuario"
        Me.lblUsuario.ThemeName = "TelerikMetroTouch"
        '
        'txtContraseña
        '
        Me.txtContraseña.BackColor = System.Drawing.Color.White
        Me.txtContraseña.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtContraseña.ForeColor = System.Drawing.Color.Black
        Me.txtContraseña.Location = New System.Drawing.Point(108, 69)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(100, 27)
        Me.txtContraseña.TabIndex = 2
        Me.txtContraseña.ThemeName = "TelerikMetroTouch"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.White
        Me.txtUsuario.ForeColor = System.Drawing.Color.Black
        Me.txtUsuario.Location = New System.Drawing.Point(108, 21)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 32)
        Me.txtUsuario.TabIndex = 1
        Me.txtUsuario.ThemeName = "TelerikMetroTouch"
        '
        'btnContinuar
        '
        Me.btnContinuar.BackColor = System.Drawing.Color.Transparent
        Me.btnContinuar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnContinuar.ForeColor = System.Drawing.Color.White
        Me.btnContinuar.Location = New System.Drawing.Point(261, 196)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(110, 32)
        Me.btnContinuar.TabIndex = 5
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.ThemeName = "TelerikMetroBlue"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(338, 196)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(110, 32)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.ThemeName = "TelerikMetroBlue"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(210, 196)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(110, 32)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.ThemeName = "TelerikMetroBlue"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbImagen.Location = New System.Drawing.Point(31, 31)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(129, 183)
        Me.pbImagen.TabIndex = 8
        Me.pbImagen.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'RadLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(499, 275)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "RadLogin"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.lblDatosUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBienvenida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOlvide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblContraseña, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContraseña, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnContinuar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblDatosUsuario As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblBienvenida As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblOlvide As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblContraseña As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblUsuario As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtContraseña As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtUsuario As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnContinuar As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancelar As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnAceptar As Telerik.WinControls.UI.RadButton
    Friend WithEvents pbImagen As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

