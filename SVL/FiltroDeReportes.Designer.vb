<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroDeReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroDeReportes))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblCarril = New Telerik.WinControls.UI.RadLabel()
        Me.ddlCarril = New Telerik.WinControls.UI.RadDropDownList()
        Me.btnAceptar = New Telerik.WinControls.UI.RadButton()
        Me.lblTurno = New Telerik.WinControls.UI.RadLabel()
        Me.lblPlaza = New Telerik.WinControls.UI.RadLabel()
        Me.lblFecha = New Telerik.WinControls.UI.RadLabel()
        Me.ddlPlaza = New Telerik.WinControls.UI.RadDropDownList()
        Me.ddlTurno = New Telerik.WinControls.UI.RadDropDownList()
        Me.dtpFecha = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.lblCarril, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlCarril, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.lblCarril)
        Me.RadGroupBox1.Controls.Add(Me.ddlCarril)
        Me.RadGroupBox1.Controls.Add(Me.btnAceptar)
        Me.RadGroupBox1.Controls.Add(Me.lblTurno)
        Me.RadGroupBox1.Controls.Add(Me.lblPlaza)
        Me.RadGroupBox1.Controls.Add(Me.lblFecha)
        Me.RadGroupBox1.Controls.Add(Me.ddlPlaza)
        Me.RadGroupBox1.Controls.Add(Me.ddlTurno)
        Me.RadGroupBox1.Controls.Add(Me.dtpFecha)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(25, 24)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(226, 335)
        Me.RadGroupBox1.TabIndex = 1
        Me.RadGroupBox1.ThemeName = "Aqua"
        '
        'lblCarril
        '
        Me.lblCarril.BackColor = System.Drawing.Color.Transparent
        Me.lblCarril.ForeColor = System.Drawing.Color.White
        Me.lblCarril.Location = New System.Drawing.Point(84, 209)
        Me.lblCarril.Name = "lblCarril"
        Me.lblCarril.Size = New System.Drawing.Size(42, 23)
        Me.lblCarril.TabIndex = 9
        Me.lblCarril.Text = "Carril"
        Me.lblCarril.ThemeName = "TelerikMetroTouch"
        '
        'ddlCarril
        '
        Me.ddlCarril.BackColor = System.Drawing.Color.White
        Me.ddlCarril.ForeColor = System.Drawing.Color.Black
        Me.ddlCarril.Location = New System.Drawing.Point(18, 236)
        Me.ddlCarril.Name = "ddlCarril"
        Me.ddlCarril.Size = New System.Drawing.Size(191, 24)
        Me.ddlCarril.TabIndex = 3
        Me.ddlCarril.ThemeName = "TelerikMetroBlue"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(55, 283)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(115, 32)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.ThemeName = "TelerikMetroBlue"
        '
        'lblTurno
        '
        Me.lblTurno.BackColor = System.Drawing.Color.Transparent
        Me.lblTurno.ForeColor = System.Drawing.Color.White
        Me.lblTurno.Location = New System.Drawing.Point(84, 143)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(47, 23)
        Me.lblTurno.TabIndex = 6
        Me.lblTurno.Text = "Turno"
        Me.lblTurno.ThemeName = "TelerikMetroTouch"
        '
        'lblPlaza
        '
        Me.lblPlaza.BackColor = System.Drawing.Color.Transparent
        Me.lblPlaza.ForeColor = System.Drawing.Color.White
        Me.lblPlaza.Location = New System.Drawing.Point(89, 11)
        Me.lblPlaza.Name = "lblPlaza"
        Me.lblPlaza.Size = New System.Drawing.Size(42, 23)
        Me.lblPlaza.TabIndex = 7
        Me.lblPlaza.Text = "Plaza"
        Me.lblPlaza.ThemeName = "TelerikMetroTouch"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.ForeColor = System.Drawing.Color.White
        Me.lblFecha.Location = New System.Drawing.Point(89, 79)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(46, 23)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.ThemeName = "TelerikMetroTouch"
        '
        'ddlPlaza
        '
        Me.ddlPlaza.BackColor = System.Drawing.Color.White
        Me.ddlPlaza.ForeColor = System.Drawing.Color.Black
        Me.ddlPlaza.Location = New System.Drawing.Point(18, 41)
        Me.ddlPlaza.Name = "ddlPlaza"
        Me.ddlPlaza.Size = New System.Drawing.Size(191, 24)
        Me.ddlPlaza.TabIndex = 0
        Me.ddlPlaza.ThemeName = "TelerikMetroBlue"
        '
        'ddlTurno
        '
        Me.ddlTurno.BackColor = System.Drawing.Color.White
        Me.ddlTurno.ForeColor = System.Drawing.Color.Black
        Me.ddlTurno.Location = New System.Drawing.Point(18, 170)
        Me.ddlTurno.Name = "ddlTurno"
        Me.ddlTurno.Size = New System.Drawing.Size(191, 24)
        Me.ddlTurno.TabIndex = 2
        Me.ddlTurno.ThemeName = "TelerikMetroBlue"
        '
        'dtpFecha
        '
        Me.dtpFecha.BackColor = System.Drawing.Color.White
        Me.dtpFecha.CalendarSize = New System.Drawing.Size(300, 300)
        Me.dtpFecha.ForeColor = System.Drawing.Color.Black
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(18, 108)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(191, 24)
        Me.dtpFecha.TabIndex = 1
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Text = "21/04/2017"
        Me.dtpFecha.ThemeName = "TelerikMetroBlue"
        Me.dtpFecha.Value = New Date(2017, 4, 21, 0, 0, 0, 0)
        '
        'FiltroDeReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(276, 385)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.MaximizeBox = False
        Me.Name = "FiltroDeReportes"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.lblCarril, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlCarril, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents ddlPlaza As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents ddlTurno As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents dtpFecha As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents btnAceptar As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTurno As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPlaza As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblFecha As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblCarril As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ddlCarril As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

