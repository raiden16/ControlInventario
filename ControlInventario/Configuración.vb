Public Class Configuración

    Private Sub Configuración_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Text = My.Settings.Server
        TextBox2.Text = My.Settings.DataBase
        TextBox3.Text = My.Settings.UserSQL
        TextBox4.Text = My.Settings.PassSQL
        TextBox5.Text = My.Settings.Ruta
        TextBox6.Text = My.Settings.RutaLogo
        TextBox7.Text = My.Settings.NombreLogo

    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

        Try

            My.Settings.Server = TextBox1.Text
            My.Settings.DataBase = TextBox2.Text
            My.Settings.UserSQL = TextBox3.Text
            My.Settings.PassSQL = TextBox4.Text
            My.Settings.Ruta = TextBox5.Text
            My.Settings.RutaLogo = TextBox6.Text
            My.Settings.NombreLogo = TextBox7.Text
            My.Settings.Save()
            MsgBox("Configuración guardada con éxito")
            Me.Hide()
            Operaciones.conectar()
            Operaciones.Show()

        Catch ex As Exception

            MsgBox("Error al guardar. " & ex.Message)

        End Try

    End Sub

    Private Sub Configuración_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        Me.Hide()
        Operaciones.conectar()
        Operaciones.Show()

    End Sub

End Class