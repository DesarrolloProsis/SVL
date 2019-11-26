<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DictaminacionAutomatica
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.dgvPrincipal = New Telerik.WinControls.UI.RadGridView()
        Me.dgvSecundario = New Telerik.WinControls.UI.RadGridView()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPrincipal.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSecundario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSecundario.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPrincipal
        '
        Me.dgvPrincipal.Location = New System.Drawing.Point(18, 38)
        '
        '
        '
        Me.dgvPrincipal.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvPrincipal.Name = "dgvPrincipal"
        Me.dgvPrincipal.ReadOnly = True
        Me.dgvPrincipal.Size = New System.Drawing.Size(531, 340)
        Me.dgvPrincipal.TabIndex = 0
        Me.dgvPrincipal.Text = "RadGridView1"
        Me.dgvPrincipal.ThemeName = "TelerikMetroBlue"
        '
        'dgvSecundario
        '
        Me.dgvSecundario.Location = New System.Drawing.Point(555, 38)
        '
        '
        '
        Me.dgvSecundario.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvSecundario.Name = "dgvSecundario"
        Me.dgvSecundario.ReadOnly = True
        Me.dgvSecundario.Size = New System.Drawing.Size(543, 183)
        Me.dgvSecundario.TabIndex = 1
        Me.dgvSecundario.Text = "RadGridView2"
        Me.dgvSecundario.ThemeName = "TelerikMetroBlue"
        '
        'Dictaminacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 411)
        Me.Controls.Add(Me.dgvSecundario)
        Me.Controls.Add(Me.dgvPrincipal)
        Me.Name = "Dictaminacion"
        Me.Text = "Dictaminacion"
        CType(Me.dgvPrincipal.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSecundario.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSecundario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents dgvPrincipal As Telerik.WinControls.UI.RadGridView
    Friend WithEvents dgvSecundario As Telerik.WinControls.UI.RadGridView
End Class
