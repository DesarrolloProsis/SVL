<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroCarrilesCerrados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroCarrilesCerrados))
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        Me.lblPlaza = New Telerik.WinControls.UI.RadLabel()
        Me.lblTurno = New Telerik.WinControls.UI.RadLabel()
        Me.lblFecha = New Telerik.WinControls.UI.RadLabel()
        Me.ddlPlaza = New Telerik.WinControls.UI.RadDropDownList()
        Me.ddlTurno = New Telerik.WinControls.UI.RadDropDownList()
        Me.dtpFecha = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.btnContinuar = New Telerik.WinControls.UI.RadButton()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnContinuar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPlaza
        '
        Me.lblPlaza.BackColor = System.Drawing.Color.Transparent
        Me.lblPlaza.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblPlaza.Location = New System.Drawing.Point(131, 34)
        Me.lblPlaza.Name = "lblPlaza"
        Me.lblPlaza.Size = New System.Drawing.Size(45, 25)
        Me.lblPlaza.TabIndex = 0
        Me.lblPlaza.Text = "Plaza"
        Me.lblPlaza.ThemeName = "VisualStudio2012Dark"
        '
        'lblTurno
        '
        Me.lblTurno.BackColor = System.Drawing.Color.Transparent
        Me.lblTurno.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblTurno.Location = New System.Drawing.Point(125, 106)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(51, 25)
        Me.lblTurno.TabIndex = 1
        Me.lblTurno.Text = "Turno"
        Me.lblTurno.ThemeName = "VisualStudio2012Dark"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblFecha.Location = New System.Drawing.Point(126, 183)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 25)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.ThemeName = "VisualStudio2012Dark"
        '
        'ddlPlaza
        '
        Me.ddlPlaza.Location = New System.Drawing.Point(72, 58)
        Me.ddlPlaza.Name = "ddlPlaza"
        Me.ddlPlaza.Size = New System.Drawing.Size(155, 24)
        Me.ddlPlaza.TabIndex = 3
        Me.ddlPlaza.ThemeName = "TelerikMetroBlue"
        '
        'ddlTurno
        '
        Me.ddlTurno.Location = New System.Drawing.Point(72, 133)
        Me.ddlTurno.Name = "ddlTurno"
        Me.ddlTurno.Size = New System.Drawing.Size(155, 24)
        Me.ddlTurno.TabIndex = 4
        Me.ddlTurno.ThemeName = "TelerikMetroBlue"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(72, 206)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(155, 24)
        Me.dtpFecha.TabIndex = 5
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Text = "12/12/2017"
        Me.dtpFecha.ThemeName = "TelerikMetroBlue"
        Me.dtpFecha.Value = New Date(2017, 12, 12, 12, 44, 11, 287)
        '
        'btnContinuar
        '
        Me.btnContinuar.BackColor = System.Drawing.Color.Transparent
        Me.btnContinuar.ForeColor = System.Drawing.Color.White
        Me.btnContinuar.Location = New System.Drawing.Point(90, 266)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(110, 32)
        Me.btnContinuar.TabIndex = 6
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.ThemeName = "TelerikMetroBlue"
        '
        'FiltroCarrilesCerrados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(293, 332)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.ddlTurno)
        Me.Controls.Add(Me.ddlPlaza)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblTurno)
        Me.Controls.Add(Me.lblPlaza)
        Me.MaximizeBox = False
        Me.Name = "FiltroCarrilesCerrados"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carriles Cerrados"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnContinuar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
    Friend WithEvents lblPlaza As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblTurno As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblFecha As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ddlPlaza As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents ddlTurno As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents dtpFecha As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents btnContinuar As Telerik.WinControls.UI.RadButton
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
End Class

