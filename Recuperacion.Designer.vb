<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recuperacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recuperacion))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.lblUsuario = New Telerik.WinControls.UI.RadLabel()
        Me.txtUsuario = New Telerik.WinControls.UI.RadTextBox()
        Me.btnEnviar = New Telerik.WinControls.UI.RadButton()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.lblMensaje = New Telerik.WinControls.UI.RadLabel()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMensaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuario.ForeColor = System.Drawing.Color.White
        Me.lblUsuario.Location = New System.Drawing.Point(42, 69)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(49, 17)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Usuario"
        Me.lblUsuario.ThemeName = "Aqua"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(110, 62)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 24)
        Me.txtUsuario.TabIndex = 1
        Me.txtUsuario.ThemeName = "TelerikMetroBlue"
        '
        'btnEnviar
        '
        Me.btnEnviar.BackColor = System.Drawing.Color.Transparent
        Me.btnEnviar.ForeColor = System.Drawing.Color.White
        Me.btnEnviar.Location = New System.Drawing.Point(60, 176)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(150, 50)
        Me.btnEnviar.TabIndex = 2
        Me.btnEnviar.Text = "Enviar Contraseña"
        Me.btnEnviar.ThemeName = "TelerikMetroBlue"
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.Transparent
        Me.lblMensaje.ForeColor = System.Drawing.Color.White
        Me.lblMensaje.Location = New System.Drawing.Point(85, 104)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(2, 2)
        Me.lblMensaje.TabIndex = 3
        Me.lblMensaje.ThemeName = "Aqua"
        '
        'Recuperacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(295, 272)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblUsuario)
        Me.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.MaximizeBox = False
        Me.Name = "Recuperacion"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recuperacion de Contraseñas"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMensaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents lblUsuario As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtUsuario As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnEnviar As Telerik.WinControls.UI.RadButton
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents lblMensaje As Telerik.WinControls.UI.RadLabel
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

