<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroDeCortes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroDeCortes))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.btnContinuar = New Telerik.WinControls.UI.RadButton()
        Me.gpbCortes = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.dtpFecha = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.ddlPlazas = New Telerik.WinControls.UI.RadDropDownList()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.btnContinuar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpbCortes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbCortes.SuspendLayout()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ddlPlazas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnContinuar
        '
        Me.btnContinuar.BackColor = System.Drawing.Color.Transparent
        Me.btnContinuar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnContinuar.ForeColor = System.Drawing.Color.White
        Me.btnContinuar.Location = New System.Drawing.Point(106, 282)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(125, 32)
        Me.btnContinuar.TabIndex = 3
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.ThemeName = "TelerikMetroBlue"
        '
        'gpbCortes
        '
        Me.gpbCortes.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gpbCortes.BackColor = System.Drawing.Color.Transparent
        Me.gpbCortes.Controls.Add(Me.RadLabel2)
        Me.gpbCortes.Controls.Add(Me.RadLabel1)
        Me.gpbCortes.Controls.Add(Me.dtpFecha)
        Me.gpbCortes.Controls.Add(Me.ddlPlazas)
        Me.gpbCortes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gpbCortes.HeaderText = "Elija la Plaza y Fecha     "
        Me.gpbCortes.Location = New System.Drawing.Point(41, 49)
        Me.gpbCortes.Name = "gpbCortes"
        Me.gpbCortes.Size = New System.Drawing.Size(251, 210)
        Me.gpbCortes.TabIndex = 2
        Me.gpbCortes.Text = "Elija la Plaza y Fecha     "
        Me.gpbCortes.ThemeName = "Aqua"
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Location = New System.Drawing.Point(92, 103)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(46, 23)
        Me.RadLabel2.TabIndex = 3
        Me.RadLabel2.Text = "Fecha"
        Me.RadLabel2.ThemeName = "TelerikMetroTouch"
        '
        'RadLabel1
        '
        Me.RadLabel1.ForeColor = System.Drawing.Color.White
        Me.RadLabel1.Location = New System.Drawing.Point(96, 22)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(42, 23)
        Me.RadLabel1.TabIndex = 2
        Me.RadLabel1.Text = "Plaza"
        Me.RadLabel1.ThemeName = "TelerikMetroTouch"
        '
        'dtpFecha
        '
        Me.dtpFecha.BackColor = System.Drawing.Color.White
        Me.dtpFecha.CalendarSize = New System.Drawing.Size(300, 300)
        Me.dtpFecha.ForeColor = System.Drawing.Color.Black
        Me.dtpFecha.Location = New System.Drawing.Point(32, 132)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(180, 24)
        Me.dtpFecha.TabIndex = 1
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Text = "viernes, 21 de abril de 2017"
        Me.dtpFecha.ThemeName = "TelerikMetroBlue"
        Me.dtpFecha.Value = New Date(2017, 4, 21, 0, 0, 0, 0)
        '
        'ddlPlazas
        '
        Me.ddlPlazas.BackColor = System.Drawing.Color.White
        Me.ddlPlazas.ForeColor = System.Drawing.Color.Black
        Me.ddlPlazas.Location = New System.Drawing.Point(32, 51)
        Me.ddlPlazas.Name = "ddlPlazas"
        Me.ddlPlazas.Size = New System.Drawing.Size(180, 24)
        Me.ddlPlazas.TabIndex = 0
        Me.ddlPlazas.ThemeName = "TelerikMetroBlue"
        '
        'FiltroDeCortes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(332, 362)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.gpbCortes)
        Me.MaximizeBox = False
        Me.Name = "FiltroDeCortes"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cortes"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.btnContinuar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpbCortes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbCortes.ResumeLayout(False)
        Me.gpbCortes.PerformLayout()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ddlPlazas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents btnContinuar As Telerik.WinControls.UI.RadButton
    Friend WithEvents gpbCortes As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dtpFecha As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents ddlPlazas As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

