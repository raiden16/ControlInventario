Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.DataSet
Imports System.Data.DataViewManager

Public Class Operaciones

    Friend conexionSQL As SqlConnection

    Private Sub Operaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        openConexionSQL()
    End Sub

    Public Function conectar() As Boolean
        Dim stCadenaConexion As String
        Try

            conectar = False

            ''---- Cargamos datos de archivo de configuracion

            '---- objeto compañia
            conexionSQL = New SqlConnection

            '---- armamos cadena de conexion
            stCadenaConexion = "data source=" & My.Settings.Server & ";initial catalog=" & My.Settings.DataBase & ";user id=" & My.Settings.UserSQL & ";password=" & My.Settings.PassSQL

            '---- realizamos conexion
            conexionSQL = New SqlConnection(stCadenaConexion)

            '----- devuelve valor de conexion correcta
            conectar = True

        Catch ex As Exception
            conectar = False
            Dim tipo, idcompra, ubicacionError, mensaje As String
            tipo = "Error"
            idcompra = "?"
            ubicacionError = "conectar"
            mensaje = "Error Interno. conectar: " & ex.Message
            'setlog(tipo, idcompra, ubicacionError, mensaje)
        End Try
    End Function

    '----- Abre conexion SQL --------------
    Public Function openConexionSQL() As Integer
        Try
            openConexionSQL = 0
            conexionSQL.Open()
        Catch ex As Exception
            openConexionSQL = -1
            Dim tipo, idcompra, ubicacionError, mensaje As String
            tipo = "Error"
            idcompra = "?"
            ubicacionError = "openConexionSQL"
            mensaje = "Error Interno. openConexionSQL: " & ex.Message
            'setlog(tipo, idcompra, ubicacionError, mensaje)
        End Try
    End Function

    '----- Abre conexion SQL --------------
    Public Function closeConexionSQL() As Integer
        Try
            closeConexionSQL = 0
            conexionSQL.Close()
        Catch ex As Exception
            closeConexionSQL = -1
            Dim tipo, idcompra, ubicacionError, mensaje As String
            tipo = "Error"
            idcompra = "?"
            ubicacionError = "openConexionSQL"
            mensaje = "Error Interno. openConexionSQL: " & ex.Message
            'setlog(tipo, idcompra, ubicacionError, mensaje)
        End Try
    End Function

    Private Sub Entrada_Click(sender As Object, e As EventArgs) Handles Entrada.Click
        Me.Hide()
        Entradas.Show()
    End Sub

    Private Sub Salida_Click(sender As Object, e As EventArgs) Handles Salida.Click
        Me.Hide()
        Salidas.Show()
    End Sub

    Private Sub Usuarios_Click(sender As Object, e As EventArgs) Handles Usuarios.Click
        Me.Hide()
        Usuario.Show()
    End Sub

    Private Sub Almacen_Click(sender As Object, e As EventArgs) Handles Almacen.Click
        Me.Hide()
        Almacenes.Show()
    End Sub

    Private Sub Operaciones_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        closeConexionSQL()
        End

    End Sub

End Class
