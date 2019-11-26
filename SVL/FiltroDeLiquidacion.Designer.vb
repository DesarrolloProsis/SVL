<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroDeLiquidacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroDeLiquidacion))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblCarril = New Telerik.WinControls.UI.RadLabel()
        Me.ddlCarril = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblTurno = New Telerik.WinControls.UI.RadLabel()
        Me.ddlTurno = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblFecha = New Telerik.WinControls.UI.RadLabel()
        Me.dtpFecha = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.lblPlaza = New Telerik.WinControls.UI.RadLabel()
        Me.ddlPlaza = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblDelegacion = New Telerik.WinControls.UI.RadLabel()
        Me.ddlDelegacion = New Telerik.WinControls.UI.RadDropDownList()
        Me.btnAceptar = New Telerik.WinControls.UI.RadButton()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.lblCarril, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlCarril, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDelegacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlDelegacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.lblCarril)
        Me.RadGroupBox1.Controls.Add(Me.ddlCarril)
        Me.RadGroupBox1.Controls.Add(Me.lblTurno)
        Me.RadGroupBox1.Controls.Add(Me.ddlTurno)
        Me.RadGroupBox1.Controls.Add(Me.lblFecha)
        Me.RadGroupBox1.Controls.Add(Me.dtpFecha)
        Me.RadGroupBox1.Controls.Add(Me.lblPlaza)
        Me.RadGroupBox1.Controls.Add(Me.ddlPlaza)
        Me.RadGroupBox1.Controls.Add(Me.lblDelegacion)
        Me.RadGroupBox1.Controls.Add(Me.ddlDelegacion)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RadGroupBox1.HeaderText = "Seleccionar"
        Me.RadGroupBox1.Location = New System.Drawing.Point(24, 15)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(223, 365)
        Me.RadGroupBox1.TabIndex = 9
        Me.RadGroupBox1.Text = "Seleccionar"
        Me.RadGroupBox1.ThemeName = "Aqua"
        '
        'lblCarril
        '
        Me.lblCarril.BackColor = System.Drawing.Color.Transparent
        Me.lblCarril.ForeColor = System.Drawing.Color.White
        Me.lblCarril.Location = New System.Drawing.Point(87, 283)
        Me.lblCarril.Name = "lblCarril"
        Me.lblCarril.Size = New System.Drawing.Size(42, 23)
        Me.lblCarril.TabIndex = 16
        Me.lblCarril.Text = "Carril"
        Me.lblCarril.ThemeName = "TelerikMetroTouch"
        '
        'ddlCarril
        '
        Me.ddlCarril.BackColor = System.Drawing.Color.White
        Me.ddlCarril.ForeColor = System.Drawing.Color.Black
        Me.ddlCarril.Location = New System.Drawing.Point(15, 311)
        Me.ddlCarril.Name = "ddlCarril"
        Me.ddlCarril.Size = New System.Drawing.Size(194, 24)
        Me.ddlCarril.TabIndex = 8
        Me.ddlCarril.ThemeName = "TelerikMetroBlue"
        '
        'lblTurno
        '
        Me.lblTurno.BackColor = System.Drawing.Color.Transparent
        Me.lblTurno.ForeColor = System.Drawing.Color.White
        Me.lblTurno.Location = New System.Drawing.Point(87, 224)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(47, 23)
        Me.lblTurno.TabIndex = 15
        Me.lblTurno.Text = "Turno"
        Me.lblTurno.ThemeName = "TelerikMetroTouch"
        '
        'ddlTurno
        '
        Me.ddlTurno.BackColor = System.Drawing.Color.White
        Me.ddlTurno.ForeColor = System.Drawing.Color.Black
        Me.ddlTurno.Location = New System.Drawing.Point(15, 253)
        Me.ddlTurno.Name = "ddlTurno"
        Me.ddlTurno.Size = New System.Drawing.Size(194, 24)
        Me.ddlTurno.TabIndex = 7
        Me.ddlTurno.ThemeName = "TelerikMetroBlue"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.ForeColor = System.Drawing.Color.White
        Me.lblFecha.Location = New System.Drawing.Point(87, 164)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(46, 23)
        Me.lblFecha.TabIndex = 14
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.ThemeName = "TelerikMetroTouch"
        '
        'dtpFecha
        '
        Me.dtpFecha.BackColor = System.Drawing.Color.White
        Me.dtpFecha.CalendarSize = New System.Drawing.Size(300, 300)
        Me.dtpFecha.ForeColor = System.Drawing.Color.Black
        Me.dtpFecha.Location = New System.Drawing.Point(15, 192)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(194, 24)
        Me.dtpFecha.TabIndex = 6
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Text = "viernes, 21 de abril de 2017"
        Me.dtpFecha.ThemeName = "TelerikMetroBlue"
        Me.dtpFecha.Value = New Date(2017, 4, 21, 0, 0, 0, 0)
        '
        'lblPlaza
        '
        Me.lblPlaza.BackColor = System.Drawing.Color.Transparent
        Me.lblPlaza.ForeColor = System.Drawing.Color.White
        Me.lblPlaza.Location = New System.Drawing.Point(91, 99)
        Me.lblPlaza.Name = "lblPlaza"
        Me.lblPlaza.Size = New System.Drawing.Size(42, 23)
        Me.lblPlaza.TabIndex = 13
        Me.lblPlaza.Text = "Plaza"
        Me.lblPlaza.ThemeName = "TelerikMetroTouch"
        '
        'ddlPlaza
        '
        Me.ddlPlaza.BackColor = System.Drawing.Color.White
        Me.ddlPlaza.ForeColor = System.Drawing.Color.Black
        Me.ddlPlaza.Location = New System.Drawing.Point(15, 128)
        Me.ddlPlaza.Name = "ddlPlaza"
        Me.ddlPlaza.Size = New System.Drawing.Size(194, 24)
        Me.ddlPlaza.TabIndex = 5
        Me.ddlPlaza.ThemeName = "TelerikMetroBlue"
        '
        'lblDelegacion
        '
        Me.lblDelegacion.BackColor = System.Drawing.Color.Transparent
        Me.lblDelegacion.ForeColor = System.Drawing.Color.White
        Me.lblDelegacion.Location = New System.Drawing.Point(75, 32)
        Me.lblDelegacion.Name = "lblDelegacion"
        Me.lblDelegacion.Size = New System.Drawing.Size(82, 23)
        Me.lblDelegacion.TabIndex = 12
        Me.lblDelegacion.Text = "Delegación"
        Me.lblDelegacion.ThemeName = "TelerikMetroTouch"
        '
        'ddlDelegacion
        '
        Me.ddlDelegacion.BackColor = System.Drawing.Color.White
        Me.ddlDelegacion.ForeColor = System.Drawing.Color.Black
        Me.ddlDelegacion.Location = New System.Drawing.Point(15, 61)
        Me.ddlDelegacion.Name = "ddlDelegacion"
        Me.ddlDelegacion.Size = New System.Drawing.Size(194, 24)
        Me.ddlDelegacion.TabIndex = 0
        Me.ddlDelegacion.ThemeName = "TelerikMetroBlue"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(77, 391)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(117, 32)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.ThemeName = "TelerikMetroBlue"
        '
        'FiltroDeLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(274, 435)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.Name = "FiltroDeLiquidacion"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidacion"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.lblCarril, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlCarril, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDelegacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlDelegacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents ddlCarril As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents ddlTurno As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents dtpFecha As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents ddlPlaza As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents ddlDelegacion As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnAceptar As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblCarril As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblTurno As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblFecha As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPlaza As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblDelegacion As Telerik.WinControls.UI.RadLabel
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

