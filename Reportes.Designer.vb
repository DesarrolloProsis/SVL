<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Dim UriReportSource2 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim UriReportSource3 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim UriReportSource4 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim UriReportSource6 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim UriReportSource7 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim UriReportSource8 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim UriReportSource1 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim UriReportSource5 As Telerik.Reporting.UriReportSource = New Telerik.Reporting.UriReportSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reportes))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ReporteDia = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.ReporteCarril = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.ReporteTurno = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ComparativoDia = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.ComparativoCajero = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.ComparativoTurno = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        Me.ReporteCarrilCerrado = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.ComparativoCarrilCerrado = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1082, 601)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ReporteCarrilCerrado)
        Me.TabPage1.Controls.Add(Me.ReporteDia)
        Me.TabPage1.Controls.Add(Me.ReporteCarril)
        Me.TabPage1.Controls.Add(Me.ReporteTurno)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1074, 575)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Reporte de Liquidación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ReporteDia
        '
        Me.ReporteDia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteDia.Location = New System.Drawing.Point(3, 3)
        Me.ReporteDia.Margin = New System.Windows.Forms.Padding(2)
        Me.ReporteDia.Name = "ReporteDia"
        UriReportSource2.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Dictamen Liquidacion Dia" &
    "-Caseta.trdp"
        Me.ReporteDia.ReportSource = UriReportSource2
        Me.ReporteDia.Size = New System.Drawing.Size(1068, 569)
        Me.ReporteDia.TabIndex = 2
        Me.ReporteDia.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'ReporteCarril
        '
        Me.ReporteCarril.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteCarril.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteCarril.Location = New System.Drawing.Point(3, 3)
        Me.ReporteCarril.Margin = New System.Windows.Forms.Padding(2)
        Me.ReporteCarril.Name = "ReporteCarril"
        Me.ReporteCarril.ReportEngineConnection = ""
        UriReportSource3.Parameters.Add(New Telerik.Reporting.Parameter("Bolsa", "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "= select Bolsa from Declaraciones where NoDeclaracion = 100001"))
        UriReportSource3.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Dictamen Liquidacion Caj" &
    "ero-Receptor.trdp"
        Me.ReporteCarril.ReportSource = UriReportSource3
        Me.ReporteCarril.Size = New System.Drawing.Size(1068, 569)
        Me.ReporteCarril.TabIndex = 0
        Me.ReporteCarril.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'ReporteTurno
        '
        Me.ReporteTurno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteTurno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteTurno.Location = New System.Drawing.Point(3, 3)
        Me.ReporteTurno.Margin = New System.Windows.Forms.Padding(2)
        Me.ReporteTurno.Name = "ReporteTurno"
        Me.ReporteTurno.ReportEngineConnection = ""
        UriReportSource4.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Dictamen Liquidacion de " &
    "Turno-Carril.trdp"
        Me.ReporteTurno.ReportSource = UriReportSource4
        Me.ReporteTurno.Size = New System.Drawing.Size(1068, 569)
        Me.ReporteTurno.TabIndex = 1
        Me.ReporteTurno.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ComparativoCarrilCerrado)
        Me.TabPage2.Controls.Add(Me.ComparativoDia)
        Me.TabPage2.Controls.Add(Me.ComparativoCajero)
        Me.TabPage2.Controls.Add(Me.ComparativoTurno)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1074, 575)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reporte Comparativo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ComparativoDia
        '
        Me.ComparativoDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ComparativoDia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComparativoDia.Location = New System.Drawing.Point(3, 3)
        Me.ComparativoDia.Name = "ComparativoDia"
        Me.ComparativoDia.ReportEngineConnection = ""
        UriReportSource6.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Comparativo Día-Caseta.t" &
    "rdp"
        Me.ComparativoDia.ReportSource = UriReportSource6
        Me.ComparativoDia.Size = New System.Drawing.Size(1068, 569)
        Me.ComparativoDia.TabIndex = 2
        Me.ComparativoDia.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'ComparativoCajero
        '
        Me.ComparativoCajero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ComparativoCajero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComparativoCajero.Location = New System.Drawing.Point(3, 3)
        Me.ComparativoCajero.Name = "ComparativoCajero"
        Me.ComparativoCajero.ReportEngineConnection = ""
        UriReportSource7.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Comparativo Cajero-Recep" &
    "tor.trdp"
        Me.ComparativoCajero.ReportSource = UriReportSource7
        Me.ComparativoCajero.Size = New System.Drawing.Size(1068, 569)
        Me.ComparativoCajero.TabIndex = 0
        Me.ComparativoCajero.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'ComparativoTurno
        '
        Me.ComparativoTurno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ComparativoTurno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComparativoTurno.Location = New System.Drawing.Point(3, 3)
        Me.ComparativoTurno.Name = "ComparativoTurno"
        Me.ComparativoTurno.ReportEngineConnection = ""
        UriReportSource8.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Comparativo Turno-Carril" &
    "es.trdp"
        Me.ComparativoTurno.ReportSource = UriReportSource8
        Me.ComparativoTurno.Size = New System.Drawing.Size(1068, 569)
        Me.ComparativoTurno.TabIndex = 1
        Me.ComparativoTurno.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'ReporteCarrilCerrado
        '
        Me.ReporteCarrilCerrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteCarrilCerrado.Location = New System.Drawing.Point(3, 3)
        Me.ReporteCarrilCerrado.Name = "ReporteCarrilCerrado"
        UriReportSource1.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Dictamen Liquidacion Caj" &
    "ero-Receptor de Carriles Cerrados.trdp"
        Me.ReporteCarrilCerrado.ReportSource = UriReportSource1
        Me.ReporteCarrilCerrado.Size = New System.Drawing.Size(1068, 569)
        Me.ReporteCarrilCerrado.TabIndex = 3
        Me.ReporteCarrilCerrado.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'ComparativoCarrilCerrado
        '
        Me.ComparativoCarrilCerrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComparativoCarrilCerrado.Location = New System.Drawing.Point(3, 3)
        Me.ComparativoCarrilCerrado.Name = "ComparativoCarrilCerrado"
        UriReportSource5.Uri = "C:\Users\MCOJorgeMonroy\Documents\Jorge\SVL\SVL\Reportes\Comparativo Cajero-Recep" &
    "tor de Carriles Cerrados.trdp"
        Me.ComparativoCarrilCerrado.ReportSource = UriReportSource5
        Me.ComparativoCarrilCerrado.Size = New System.Drawing.Size(1068, 569)
        Me.ComparativoCarrilCerrado.TabIndex = 3
        Me.ComparativoCarrilCerrado.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 601)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reportes"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Reportes"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ReporteCarril As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ComparativoCajero As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents ReporteTurno As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents ComparativoTurno As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents ReporteDia As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents ComparativoDia As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
    Friend WithEvents ReporteCarrilCerrado As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents ComparativoCarrilCerrado As Telerik.ReportViewer.WinForms.ReportViewer
End Class

