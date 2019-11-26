<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comentar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Comentar))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.txtComentarios = New Telerik.WinControls.UI.RadTextBoxControl()
        Me.btnCancelar = New Telerik.WinControls.UI.RadButton()
        Me.btnAceptar = New Telerik.WinControls.UI.RadButton()
        Me.txtEvento = New Telerik.WinControls.UI.RadTextBox()
        Me.lblNoEvento = New Telerik.WinControls.UI.RadLabel()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.txtComentarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEvento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoEvento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtComentarios
        '
        Me.txtComentarios.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.txtComentarios.Location = New System.Drawing.Point(27, 71)
        Me.txtComentarios.MaxLength = 70
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(449, 130)
        Me.txtComentarios.TabIndex = 20
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(366, 220)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(110, 32)
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.ThemeName = "TelerikMetroBlue"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(27, 220)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(110, 32)
        Me.btnAceptar.TabIndex = 21
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.ThemeName = "TelerikMetroBlue"
        '
        'txtEvento
        '
        Me.txtEvento.Location = New System.Drawing.Point(120, 32)
        Me.txtEvento.Name = "txtEvento"
        Me.txtEvento.Size = New System.Drawing.Size(73, 24)
        Me.txtEvento.TabIndex = 24
        Me.txtEvento.ThemeName = "TelerikMetroBlue"
        '
        'lblNoEvento
        '
        Me.lblNoEvento.BackColor = System.Drawing.Color.Transparent
        Me.lblNoEvento.ForeColor = System.Drawing.Color.White
        Me.lblNoEvento.Location = New System.Drawing.Point(30, 33)
        Me.lblNoEvento.Name = "lblNoEvento"
        Me.lblNoEvento.Size = New System.Drawing.Size(84, 23)
        Me.lblNoEvento.TabIndex = 23
        Me.lblNoEvento.Text = "No. Evento:"
        Me.lblNoEvento.ThemeName = "TelerikMetroTouch"
        '
        'Comentar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(497, 270)
        Me.Controls.Add(Me.txtEvento)
        Me.Controls.Add(Me.lblNoEvento)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtComentarios)
        Me.MaximizeBox = False
        Me.Name = "Comentar"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comentario"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.txtComentarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEvento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoEvento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents txtComentarios As Telerik.WinControls.UI.RadTextBoxControl
    Friend WithEvents btnCancelar As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnAceptar As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtEvento As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblNoEvento As Telerik.WinControls.UI.RadLabel
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

