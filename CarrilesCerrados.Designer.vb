<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarrilesCerrados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CarrilesCerrados))
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        Me.ddlCarrilesCarrados = New Telerik.WinControls.UI.RadDropDownList()
        Me.btnGenerar = New Telerik.WinControls.UI.RadButton()
        Me.btnCancelar = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblEncargado = New Telerik.WinControls.UI.RadLabel()
        Me.ddlAdministrador = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.ddlEncargado = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblComentario = New Telerik.WinControls.UI.RadLabel()
        Me.txtObservaciones = New Telerik.WinControls.UI.RadTextBoxControl()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        CType(Me.ddlCarrilesCarrados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGenerar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.lblEncargado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlAdministrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlEncargado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.lblComentario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ddlCarrilesCarrados
        '
        Me.ddlCarrilesCarrados.Location = New System.Drawing.Point(24, 66)
        Me.ddlCarrilesCarrados.Name = "ddlCarrilesCarrados"
        Me.ddlCarrilesCarrados.Size = New System.Drawing.Size(125, 24)
        Me.ddlCarrilesCarrados.TabIndex = 0
        Me.ddlCarrilesCarrados.ThemeName = "TelerikMetroBlue"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(19, 341)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(174, 49)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "GENERAR"
        Me.btnGenerar.ThemeName = "TelerikMetroBlue"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(544, 341)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(174, 49)
        Me.btnCancelar.TabIndex = 32
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.ThemeName = "TelerikMetroBlue"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox2.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox2.Controls.Add(Me.lblEncargado)
        Me.RadGroupBox2.Controls.Add(Me.ddlAdministrador)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox2.Controls.Add(Me.ddlEncargado)
        Me.RadGroupBox2.Controls.Add(Me.ddlCarrilesCarrados)
        Me.RadGroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RadGroupBox2.HeaderText = "Encargado y Administrador"
        Me.RadGroupBox2.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadGroupBox2.Location = New System.Drawing.Point(19, 52)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(287, 279)
        Me.RadGroupBox2.TabIndex = 31
        Me.RadGroupBox2.Text = "Encargado y Administrador"
        Me.RadGroupBox2.ThemeName = "Aqua"
        '
        'lblEncargado
        '
        Me.lblEncargado.BackColor = System.Drawing.Color.Transparent
        Me.lblEncargado.ForeColor = System.Drawing.Color.White
        Me.lblEncargado.Location = New System.Drawing.Point(23, 109)
        Me.lblEncargado.Name = "lblEncargado"
        Me.lblEncargado.Size = New System.Drawing.Size(145, 23)
        Me.lblEncargado.TabIndex = 24
        Me.lblEncargado.Text = "Encargado de Turno:"
        Me.lblEncargado.ThemeName = "TelerikMetroTouch"
        '
        'ddlAdministrador
        '
        Me.ddlAdministrador.Location = New System.Drawing.Point(24, 218)
        Me.ddlAdministrador.Name = "ddlAdministrador"
        Me.ddlAdministrador.Size = New System.Drawing.Size(223, 24)
        Me.ddlAdministrador.TabIndex = 22
        Me.ddlAdministrador.ThemeName = "TelerikMetroBlue"
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Location = New System.Drawing.Point(24, 189)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(161, 23)
        Me.RadLabel2.TabIndex = 25
        Me.RadLabel2.Text = "Administrador General:"
        Me.RadLabel2.ThemeName = "TelerikMetroTouch"
        '
        'ddlEncargado
        '
        Me.ddlEncargado.Location = New System.Drawing.Point(23, 138)
        Me.ddlEncargado.Name = "ddlEncargado"
        Me.ddlEncargado.Size = New System.Drawing.Size(223, 24)
        Me.ddlEncargado.TabIndex = 23
        Me.ddlEncargado.ThemeName = "TelerikMetroBlue"
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
        Me.RadGroupBox1.Location = New System.Drawing.Point(319, 52)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(399, 279)
        Me.RadGroupBox1.TabIndex = 30
        Me.RadGroupBox1.Text = "Observaciones"
        Me.RadGroupBox1.ThemeName = "Aqua"
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
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.ForeColor = System.Drawing.Color.White
        Me.RadLabel1.Location = New System.Drawing.Point(24, 37)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(124, 23)
        Me.RadLabel1.TabIndex = 26
        Me.RadLabel1.Text = "Carriles Cerrados:"
        Me.RadLabel1.ThemeName = "TelerikMetroTouch"
        '
        'CarrilesCerrados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(737, 404)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Name = "CarrilesCerrados"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carriles Cerrados"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.ddlCarrilesCarrados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGenerar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.lblEncargado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlAdministrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlEncargado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.lblComentario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
    Friend WithEvents ddlCarrilesCarrados As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnGenerar As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancelar As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblEncargado As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ddlAdministrador As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ddlEncargado As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblComentario As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtObservaciones As Telerik.WinControls.UI.RadTextBoxControl
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
End Class

