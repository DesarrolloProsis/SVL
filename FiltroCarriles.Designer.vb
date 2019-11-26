<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroCarriles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroCarriles))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.ddlPlaza = New Telerik.WinControls.UI.RadDropDownList()
        Me.dtpFecha = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.btnFiltrar = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblFecha = New Telerik.WinControls.UI.RadLabel()
        Me.lblPlaza = New Telerik.WinControls.UI.RadLabel()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ddlPlaza
        '
        Me.ddlPlaza.BackColor = System.Drawing.Color.White
        Me.ddlPlaza.ForeColor = System.Drawing.Color.Black
        Me.ddlPlaza.Location = New System.Drawing.Point(14, 56)
        Me.ddlPlaza.Name = "ddlPlaza"
        Me.ddlPlaza.Size = New System.Drawing.Size(201, 24)
        Me.ddlPlaza.TabIndex = 1
        Me.ddlPlaza.ThemeName = "TelerikMetroBlue"
        '
        'dtpFecha
        '
        Me.dtpFecha.BackColor = System.Drawing.Color.White
        Me.dtpFecha.CalendarSize = New System.Drawing.Size(300, 300)
        Me.dtpFecha.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtpFecha.ForeColor = System.Drawing.Color.Black
        Me.dtpFecha.Location = New System.Drawing.Point(14, 134)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(201, 22)
        Me.dtpFecha.TabIndex = 3
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Text = "viernes, 21 de abril de 2017"
        Me.dtpFecha.ThemeName = "TelerikMetroBlue"
        Me.dtpFecha.Value = New Date(2017, 4, 21, 0, 0, 0, 0)
        '
        'btnFiltrar
        '
        Me.btnFiltrar.BackColor = System.Drawing.Color.Transparent
        Me.btnFiltrar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnFiltrar.ForeColor = System.Drawing.Color.White
        Me.btnFiltrar.Location = New System.Drawing.Point(67, 232)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(125, 32)
        Me.btnFiltrar.TabIndex = 4
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.ThemeName = "TelerikMetroBlue"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.lblFecha)
        Me.RadGroupBox1.Controls.Add(Me.lblPlaza)
        Me.RadGroupBox1.Controls.Add(Me.ddlPlaza)
        Me.RadGroupBox1.Controls.Add(Me.dtpFecha)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(14, 17)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(233, 190)
        Me.RadGroupBox1.TabIndex = 5
        Me.RadGroupBox1.ThemeName = "Aqua"
        '
        'lblFecha
        '
        Me.lblFecha.ForeColor = System.Drawing.Color.White
        Me.lblFecha.Location = New System.Drawing.Point(93, 104)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(46, 23)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.ThemeName = "TelerikMetroTouch"
        '
        'lblPlaza
        '
        Me.lblPlaza.ForeColor = System.Drawing.Color.White
        Me.lblPlaza.Location = New System.Drawing.Point(95, 27)
        Me.lblPlaza.Name = "lblPlaza"
        Me.lblPlaza.Size = New System.Drawing.Size(42, 23)
        Me.lblPlaza.TabIndex = 4
        Me.lblPlaza.Text = "Plaza"
        Me.lblPlaza.ThemeName = "TelerikMetroTouch"
        '
        'FiltroCarriles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(261, 287)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.btnFiltrar)
        Me.MaximizeBox = False
        Me.Name = "FiltroCarriles"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FiltroCarriles"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.ddlPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents ddlPlaza As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents dtpFecha As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents btnFiltrar As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblFecha As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPlaza As Telerik.WinControls.UI.RadLabel
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

