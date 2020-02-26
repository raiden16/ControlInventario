<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Operaciones
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
        Me.Entrada = New System.Windows.Forms.Button()
        Me.Salida = New System.Windows.Forms.Button()
        Me.Usuarios = New System.Windows.Forms.Button()
        Me.Almacen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Entrada
        '
        Me.Entrada.Location = New System.Drawing.Point(12, 27)
        Me.Entrada.Name = "Entrada"
        Me.Entrada.Size = New System.Drawing.Size(75, 23)
        Me.Entrada.TabIndex = 0
        Me.Entrada.Text = "Entrada"
        Me.Entrada.UseVisualStyleBackColor = True
        '
        'Salida
        '
        Me.Salida.Location = New System.Drawing.Point(127, 27)
        Me.Salida.Name = "Salida"
        Me.Salida.Size = New System.Drawing.Size(75, 23)
        Me.Salida.TabIndex = 1
        Me.Salida.Text = "Salida"
        Me.Salida.UseVisualStyleBackColor = True
        '
        'Usuarios
        '
        Me.Usuarios.Location = New System.Drawing.Point(237, 27)
        Me.Usuarios.Name = "Usuarios"
        Me.Usuarios.Size = New System.Drawing.Size(75, 23)
        Me.Usuarios.TabIndex = 2
        Me.Usuarios.Text = "Usuarios"
        Me.Usuarios.UseVisualStyleBackColor = True
        '
        'Almacen
        '
        Me.Almacen.Location = New System.Drawing.Point(344, 27)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(75, 23)
        Me.Almacen.TabIndex = 3
        Me.Almacen.Text = "Almacen"
        Me.Almacen.UseVisualStyleBackColor = True
        '
        'Operaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(431, 78)
        Me.Controls.Add(Me.Almacen)
        Me.Controls.Add(Me.Usuarios)
        Me.Controls.Add(Me.Salida)
        Me.Controls.Add(Me.Entrada)
        Me.Name = "Operaciones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operaciones de Inventario"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Entrada As Button
    Friend WithEvents Salida As Button
    Friend WithEvents Usuarios As Button
    Friend WithEvents Almacen As Button
End Class
