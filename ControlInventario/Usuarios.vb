Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.DataSet
Imports System.Data.DataViewManager

Public Class Usuario

    Dim conexionSQL As SqlConnection

    Private Sub Usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conexionSQL = Operaciones.conexionSQL

        Dim query As String = "Select NombreAlmacen from OWHS"
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim Name As String
        Dim query2 As String = "Select Departamento from WHS1"
        Dim comm2 As New SqlCommand
        Dim DA2 As New SqlDataAdapter
        Dim DS2 As New System.Data.DataSet
        Dim Name2 As String

        PictureBox4.Visible = False
        PictureBox4.Enabled = False
        TextBox3.Enabled = False
        TextBox3.Visible = False

        Try

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If (DS.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS.Tables(0).Rows.Count) - 1

                    Name = DS.Tables(0).Rows(i)("NombreAlmacen").ToString
                    ComboBox1.Items.Add(Name)

                Next

            End If

            comm2.CommandText = query2
            comm2.Connection = conexionSQL
            DA2.SelectCommand = comm2
            DA2.Fill(DS2)

            If (DS2.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS2.Tables(0).Rows.Count) - 1

                    Name2 = DS2.Tables(0).Rows(i)("Departamento").ToString
                    ComboBox2.Items.Add(Name2)

                Next

            End If

            UltimoUsuario()

        Catch ex As Exception

            MsgBox("Error al cargar la forma de usuarios: " & ex.Message)

        End Try

    End Sub

    Public Function UltimoUsuario()

        Dim query2 As String = "Select count(Usuario)+1 as 'Usuario' from OUSR"
        Dim comm2 As New SqlCommand
        Dim DA2 As New SqlDataAdapter
        Dim DS2 As New System.Data.DataSet

        Try

            comm2.CommandText = query2
            comm2.Connection = conexionSQL
            DA2.SelectCommand = comm2
            DA2.Fill(DS2)

            If (DS2.Tables(0).Rows.Count > 0) Then

                TextBox3.Text = DS2.Tables(0).Rows(0)("Usuario").ToString

            End If

        Catch ex As Exception

            MsgBox("Error en UltimoUsuario: " & ex.Message)

        End Try

    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Dim comm, comm2 As New SqlCommand
        Dim DA, DA2 As New SqlDataAdapter
        Dim DS, DS2 As New System.Data.DataSet
        Dim Usuario As Integer

        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        Button1.Enabled = False
        Button1.Visible = False
        TextBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False

        Try

            If TextBox3.Text = Nothing Then

                Usuario = 0

            Else

                Usuario = TextBox3.Text

            End If

            Dim query As String = "Select T0.Usuario,T0.Nombre,T0.Almacen,T0.Departamento from OUSR T0 where T0.Usuario=" & Usuario - 1

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("Nombre").ToString
                ComboBox2.Text = DS.Tables(0).Rows(0)("Almacen").ToString
                ComboBox1.Text = DS.Tables(0).Rows(0)("Departamento").ToString
                TextBox3.Text = DS.Tables(0).Rows(0)("Usuario").ToString

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select Top 1 T0.Usuario,T0.Nombre,T0.Almacen,T0.Departamento from OUSR T0 order by T0.Usuario desc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("Nombre").ToString
                    ComboBox2.Text = DS2.Tables(0).Rows(0)("Almacen").ToString
                    ComboBox1.Text = DS2.Tables(0).Rows(0)("Departamento").ToString
                    TextBox3.Text = DS2.Tables(0).Rows(0)("Usuario").ToString

                End If

            End If

            DS.Clear()
            DS2.Clear()

        Catch ex As Exception

            MsgBox("Error al ir con el usuario creado anteriormente: " & ex.Message)

        End Try

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        Dim comm, comm2 As New SqlCommand
        Dim DA, DA2 As New SqlDataAdapter
        Dim DS, DS2 As New System.Data.DataSet
        Dim Usuario As Integer

        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        Button1.Enabled = False
        Button1.Visible = False
        TextBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False

        Try

            If TextBox3.Text = Nothing Then

                Usuario = 0

            Else

                Usuario = TextBox3.Text

            End If

            Dim query As String = "Select T0.Usuario,T0.Nombre,T0.Almacen,T0.Departamento from OUSR T0 where T0.Usuario=" & Usuario + 1

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("Nombre").ToString
                ComboBox2.Text = DS.Tables(0).Rows(0)("Almacen").ToString
                ComboBox1.Text = DS.Tables(0).Rows(0)("Departamento").ToString
                TextBox3.Text = DS.Tables(0).Rows(0)("Usuario").ToString

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select Top 1 T0.Usuario,T0.Nombre,T0.Almacen,T0.Departamento from OUSR T0 order by T0.Usuario asc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("Nombre").ToString
                    ComboBox2.Text = DS2.Tables(0).Rows(0)("Almacen").ToString
                    ComboBox1.Text = DS2.Tables(0).Rows(0)("Departamento").ToString
                    TextBox3.Text = DS2.Tables(0).Rows(0)("Usuario").ToString

                End If

            End If

            DS.Clear()
            DS2.Clear()

        Catch ex As Exception

            MsgBox("Error al ir con el usuario creado posteriormente: " & ex.Message)

        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Button1.Enabled = True
        Button1.Visible = True
        Button1.Text = "Buscar"
        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        TextBox1.Text = ""
        TextBox1.Enabled = True
        ComboBox2.Text = ""
        ComboBox2.Enabled = False
        ComboBox1.Text = ""
        ComboBox1.Enabled = False

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Button1.Enabled = True
        Button1.Visible = True
        Button1.Text = "Crear"
        PictureBox4.Visible = False
        PictureBox4.Enabled = False
        PictureBox1.Visible = True
        PictureBox1.Enabled = True
        TextBox1.Text = ""
        TextBox1.Enabled = True
        ComboBox2.Text = ""
        ComboBox2.Enabled = True
        ComboBox1.Text = ""
        ComboBox1.Enabled = True
        UltimoUsuario()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Button1.Text = "Crear" Then

            Crear()

        ElseIf Button1.Text = "Buscar" Then

            Buscar()

        End If

    End Sub

    Public Function Crear()

        Dim query As String = "Select * from OUSR T0 where T0.Nombre='" & TextBox1.Text & "'"
        Dim comm, comm2, comm3 As New SqlCommand
        Dim DA, DA2, DA3 As New SqlDataAdapter
        Dim DS, DS2, DS3 As New System.Data.DataSet

        Try

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If (DS.Tables(0).Rows.Count > 0) Then

                MsgBox("Ya existe el usuario """ & DS.Tables(0).Rows(0)("Nombre").ToString() & """")

            Else

                Dim query2 As String = "Select T0.Almacen from OWHS T0 where T0.NombreAlmacen='" & ComboBox1.Text & "'"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                Dim query3 As String = "insert into OUSR values(" & TextBox3.Text & ",'" & TextBox1.Text & "','" & DS2.Tables(0).Rows(0)("Almacen").ToString() & "','" & ComboBox2.Text & "')"

                comm3.CommandText = query3
                comm3.Connection = conexionSQL
                DA3.SelectCommand = comm3
                DA3.Fill(DS3)

                TextBox1.Clear()
                ComboBox1.Text = Nothing
                ComboBox2.Text = Nothing
                UltimoUsuario()

            End If

        Catch ex As Exception

            MsgBox("Error al crear al usuario: " & ex.Message)

        End Try

    End Function

    Public Function Buscar()

        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim DocEntry As Integer

        Try

            If TextBox1.Text = Nothing Then

                MsgBox("Coloca el nombre del usuario que deseaas ver.")

            Else

                Dim query As String = "Select * from OUSR T0 where T0.Nombre='" & TextBox1.Text & "'"

                comm.CommandText = query
                comm.Connection = conexionSQL
                DA.SelectCommand = comm
                DA.Fill(DS)

                If DS.Tables(0).Rows.Count > 0 Then

                    TextBox1.Enabled = False
                    TextBox1.Text = DS.Tables(0).Rows(0)("Nombre").ToString
                    ComboBox2.Text = DS.Tables(0).Rows(0)("Almacen").ToString
                    ComboBox1.Text = DS.Tables(0).Rows(0)("Departamento").ToString
                    DocEntry = DS.Tables(0).Rows(0)("Usuario").ToString

                Else

                    MsgBox("No se encontro ni un usaurio con el nombre proporcionado.")

                End If

            End If

        Catch ex As Exception

            MsgBox("Error al Buscar el usuario : " & ex.Message)

        End Try

    End Function

    Private Sub Salida_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        Me.Hide()
        Operaciones.Show()

    End Sub

End Class