<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Help
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Help))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.HighContrastBlackTheme1 = New Telerik.WinControls.Themes.HighContrastBlackTheme()
        Me.lblTitulo = New Telerik.WinControls.UI.RadLabel()
        Me.lblUno = New Telerik.WinControls.UI.RadLabel()
        Me.lblDos = New Telerik.WinControls.UI.RadLabel()
        Me.TelerikMetroTouchTheme1 = New Telerik.WinControls.Themes.TelerikMetroTouchTheme()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.pbContrloes = New System.Windows.Forms.PictureBox()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.pbContrloes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblTitulo.Location = New System.Drawing.Point(37, 27)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(2, 2)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.ThemeName = "TelerikMetroTouch"
        '
        'lblUno
        '
        Me.lblUno.ForeColor = System.Drawing.Color.Black
        Me.lblUno.Location = New System.Drawing.Point(22, 76)
        Me.lblUno.Name = "lblUno"
        Me.lblUno.Size = New System.Drawing.Size(2, 2)
        Me.lblUno.TabIndex = 1
        Me.lblUno.ThemeName = "TelerikMetroTouch"
        '
        'lblDos
        '
        Me.lblDos.ForeColor = System.Drawing.Color.Black
        Me.lblDos.Location = New System.Drawing.Point(22, 194)
        Me.lblDos.Name = "lblDos"
        Me.lblDos.Size = New System.Drawing.Size(2, 2)
        Me.lblDos.TabIndex = 1
        Me.lblDos.ThemeName = "TelerikMetroTouch"
        '
        'RadPanel1
        '
        Me.RadPanel1.BackColor = System.Drawing.Color.White
        Me.RadPanel1.Controls.Add(Me.pbContrloes)
        Me.RadPanel1.Controls.Add(Me.lblTitulo)
        Me.RadPanel1.Controls.Add(Me.lblUno)
        Me.RadPanel1.Controls.Add(Me.lblDos)
        Me.RadPanel1.Location = New System.Drawing.Point(27, 45)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(289, 397)
        Me.RadPanel1.TabIndex = 3
        '
        'pbContrloes
        '
        Me.pbContrloes.BackgroundImage = CType(resources.GetObject("pbContrloes.BackgroundImage"), System.Drawing.Image)
        Me.pbContrloes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbContrloes.Location = New System.Drawing.Point(22, 194)
        Me.pbContrloes.Name = "pbContrloes"
        Me.pbContrloes.Size = New System.Drawing.Size(252, 187)
        Me.pbContrloes.TabIndex = 2
        Me.pbContrloes.TabStop = False
        '
        'BunifuImageButton1
        '
        Me.BunifuImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton1.Image = CType(resources.GetObject("BunifuImageButton1.Image"), System.Drawing.Image)
        Me.BunifuImageButton1.ImageActive = Nothing
        Me.BunifuImageButton1.Location = New System.Drawing.Point(306, 2)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(34, 43)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 2
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(350, 482)
        Me.Controls.Add(Me.RadPanel1)
        Me.Controls.Add(Me.BunifuImageButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Help"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Help"
        Me.ThemeName = "Aqua"
        Me.TransparencyKey = System.Drawing.Color.Gray
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        Me.RadPanel1.PerformLayout()
        CType(Me.pbContrloes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents HighContrastBlackTheme1 As Telerik.WinControls.Themes.HighContrastBlackTheme
    Friend WithEvents lblTitulo As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblUno As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblDos As Telerik.WinControls.UI.RadLabel
    Friend WithEvents TelerikMetroTouchTheme1 As Telerik.WinControls.Themes.TelerikMetroTouchTheme
    Friend WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents pbContrloes As PictureBox
End Class

