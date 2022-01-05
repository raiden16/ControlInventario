<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuración
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Server = New System.Windows.Forms.Label()
        Me.DataBase = New System.Windows.Forms.Label()
        Me.UserSQL = New System.Windows.Forms.Label()
        Me.PassSQL = New System.Windows.Forms.Label()
        Me.Ruta = New System.Windows.Forms.Label()
        Me.RutaLogo = New System.Windows.Forms.Label()
        Me.NombreLogo = New System.Windows.Forms.Label()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(86, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(471, 20)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(86, 68)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(471, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(86, 106)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(471, 20)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(86, 141)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(471, 20)
        Me.TextBox4.TabIndex = 3
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(86, 178)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(471, 20)
        Me.TextBox5.TabIndex = 4
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(86, 215)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(471, 20)
        Me.TextBox6.TabIndex = 5
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(86, 254)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(471, 20)
        Me.TextBox7.TabIndex = 6
        '
        'Server
        '
        Me.Server.AutoSize = True
        Me.Server.Location = New System.Drawing.Point(12, 35)
        Me.Server.Name = "Server"
        Me.Server.Size = New System.Drawing.Size(41, 13)
        Me.Server.TabIndex = 7
        Me.Server.Text = "Server:"
        '
        'DataBase
        '
        Me.DataBase.AutoSize = True
        Me.DataBase.Location = New System.Drawing.Point(12, 71)
        Me.DataBase.Name = "DataBase"
        Me.DataBase.Size = New System.Drawing.Size(57, 13)
        Me.DataBase.TabIndex = 8
        Me.DataBase.Text = "DataBase:"
        '
        'UserSQL
        '
        Me.UserSQL.AutoSize = True
        Me.UserSQL.Location = New System.Drawing.Point(12, 109)
        Me.UserSQL.Name = "UserSQL"
        Me.UserSQL.Size = New System.Drawing.Size(53, 13)
        Me.UserSQL.TabIndex = 9
        Me.UserSQL.Text = "UserSQL:"
        '
        'PassSQL
        '
        Me.PassSQL.AutoSize = True
        Me.PassSQL.Location = New System.Drawing.Point(12, 144)
        Me.PassSQL.Name = "PassSQL"
        Me.PassSQL.Size = New System.Drawing.Size(54, 13)
        Me.PassSQL.TabIndex = 10
        Me.PassSQL.Text = "PassSQL:"
        '
        'Ruta
        '
        Me.Ruta.AutoSize = True
        Me.Ruta.Location = New System.Drawing.Point(12, 181)
        Me.Ruta.Name = "Ruta"
        Me.Ruta.Size = New System.Drawing.Size(33, 13)
        Me.Ruta.TabIndex = 11
        Me.Ruta.Text = "Ruta:"
        '
        'RutaLogo
        '
        Me.RutaLogo.AutoSize = True
        Me.RutaLogo.Location = New System.Drawing.Point(12, 218)
        Me.RutaLogo.Name = "RutaLogo"
        Me.RutaLogo.Size = New System.Drawing.Size(57, 13)
        Me.RutaLogo.TabIndex = 12
        Me.RutaLogo.Text = "RutaLogo:"
        '
        'NombreLogo
        '
        Me.NombreLogo.AutoSize = True
        Me.NombreLogo.Location = New System.Drawing.Point(12, 257)
        Me.NombreLogo.Name = "NombreLogo"
        Me.NombreLogo.Size = New System.Drawing.Size(71, 13)
        Me.NombreLogo.TabIndex = 13
        Me.NombreLogo.Text = "NombreLogo:"
        '
        'Guardar
        '
        Me.Guardar.Location = New System.Drawing.Point(248, 301)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Guardar.TabIndex = 14
        Me.Guardar.Text = "Guardar"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'Configuración
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 336)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.NombreLogo)
        Me.Controls.Add(Me.RutaLogo)
        Me.Controls.Add(Me.Ruta)
        Me.Controls.Add(Me.PassSQL)
        Me.Controls.Add(Me.UserSQL)
        Me.Controls.Add(Me.DataBase)
        Me.Controls.Add(Me.Server)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Configuración"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Server As Label
    Friend WithEvents DataBase As Label
    Friend WithEvents UserSQL As Label
    Friend WithEvents PassSQL As Label
    Friend WithEvents Ruta As Label
    Friend WithEvents RutaLogo As Label
    Friend WithEvents NombreLogo As Label
    Friend WithEvents Guardar As Button
End Class
