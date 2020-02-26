Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.DataSet
Imports System.Data.DataViewManager

Public Class Almacenes

    Dim conexionSQL As SqlConnection

    Private Sub Almacenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conexionSQL = Operaciones.conexionSQL

        PictureBox4.Visible = False
        PictureBox4.Enabled = False
        TextBox4.Enabled = False
        TextBox4.Visible = False

        UltimoAlmacen()

    End Sub

    Public Function UltimoAlmacen()

        Dim query2 As String = "Select count(WhsCode)+1 as 'Almacen' from OWHS"
        Dim comm2 As New SqlCommand
        Dim DA2 As New SqlDataAdapter
        Dim DS2 As New System.Data.DataSet

        Try

            comm2.CommandText = query2
            comm2.Connection = conexionSQL
            DA2.SelectCommand = comm2
            DA2.Fill(DS2)

            If (DS2.Tables(0).Rows.Count > 0) Then

                TextBox4.Text = DS2.Tables(0).Rows(0)("Almacen").ToString

            End If

        Catch ex As Exception

            MsgBox("Error en UltimoAlmacen: " & ex.Message)

        End Try

    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Dim comm, comm2 As New SqlCommand
        Dim DA, DA2 As New SqlDataAdapter
        Dim DS, DS2 As New System.Data.DataSet
        Dim Almacen As Integer

        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        Button1.Enabled = False
        Button1.Visible = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        Try

            If TextBox4.Text = Nothing Then

                Almacen = 0

            Else

                Almacen = TextBox4.Text

            End If

            Dim query As String = "Select T0.WhsCode,T0.Almacen,T0.NombreAlmacen,T0.Localidad from OWHS T0 where T0.WhsCode=" & Almacen - 1

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("Almacen").ToString
                TextBox2.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                TextBox3.Text = DS.Tables(0).Rows(0)("Localidad").ToString
                TextBox4.Text = DS.Tables(0).Rows(0)("WhsCode").ToString

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select Top 1 T0.WhsCode,T0.Almacen,T0.NombreAlmacen,T0.Localidad from OWHS T0 order by T0.WhsCode desc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("Almacen").ToString
                    TextBox2.Text = DS2.Tables(0).Rows(0)("NombreAlmacen").ToString
                    TextBox3.Text = DS2.Tables(0).Rows(0)("Localidad").ToString
                    TextBox4.Text = DS2.Tables(0).Rows(0)("WhsCode").ToString

                End If

            End If

            DS.Clear()
            DS2.Clear()

        Catch ex As Exception

            MsgBox("Ir al almacen creado anteriormente: " & ex.Message)

        End Try

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        Dim comm, comm2 As New SqlCommand
        Dim DA, DA2 As New SqlDataAdapter
        Dim DS, DS2 As New System.Data.DataSet
        Dim Almacen As String

        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        Button1.Enabled = False
        Button1.Visible = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        Try

            If TextBox4.Text = Nothing Then

                Almacen = 0

            Else

                Almacen = TextBox4.Text

            End If

            Dim query As String = "Select T0.WhsCode,T0.Almacen,T0.NombreAlmacen,T0.Localidad from OWHS T0 where T0.WhsCode=" & Almacen + 1

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("Almacen").ToString
                TextBox2.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                TextBox3.Text = DS.Tables(0).Rows(0)("Localidad").ToString
                TextBox4.Text = DS.Tables(0).Rows(0)("WhsCode").ToString

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select Top 1 T0.WhsCode,T0.Almacen,T0.NombreAlmacen,T0.Localidad from OWHS T0 order by T0.WhsCode asc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("Almacen").ToString
                    TextBox2.Text = DS2.Tables(0).Rows(0)("NombreAlmacen").ToString
                    TextBox3.Text = DS2.Tables(0).Rows(0)("Localidad").ToString
                    TextBox4.Text = DS2.Tables(0).Rows(0)("WhsCode").ToString

                End If

                DS.Clear()
                DS2.Clear()

            End If

        Catch ex As Exception

            MsgBox("Ir al almacen creado posteriormente: " & ex.Message)

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
        TextBox2.Text = ""
        TextBox2.Enabled = False
        TextBox3.Text = ""
        TextBox3.Enabled = False

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
        TextBox2.Text = ""
        TextBox2.Enabled = True
        TextBox3.Text = ""
        TextBox3.Enabled = True
        UltimoAlmacen()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Button1.Text = "Crear" Then

            Crear()

        ElseIf Button1.Text = "Buscar" Then

            Buscar()

        End If

    End Sub

    Public Function Crear()

        Dim query As String = "Select T0.Almacen,T0.NombreAlmacen,T0.Localidad from OWHS T0 where T0.Almacen='" & TextBox1.Text & "'"
        Dim comm, comm2, comm3 As New SqlCommand
        Dim DA, DA2, DA3 As New SqlDataAdapter
        Dim DS, DS2, DS3 As New System.Data.DataSet

        Try

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If (DS.Tables(0).Rows.Count > 0) Then

                MsgBox("Ya existe el Almacen """ & DS.Tables(0).Rows(0)("Almacen").ToString() & """")

            Else

                Dim query2 As String = "Select T0.Almacen,T0.NombreAlmacen,T0.Localidad from OWHS T0 where T0.NombreAlmacen='" & TextBox2.Text & "' and T0.Localidad='" & TextBox3.Text & "'"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If (DS2.Tables(0).Rows.Count > 0) Then

                    MsgBox("Ya existe el nombre """ & DS2.Tables(0).Rows(0)("NombreAlmacen").ToString() & """ en la localidad " & DS2.Tables(0).Rows(0)("Localidad").ToString())

                Else

                    Dim query3 As String = "insert into OWHS values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"

                    comm3.CommandText = query3
                    comm3.Connection = conexionSQL
                    DA3.SelectCommand = comm3
                    DA3.Fill(DS3)

                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    UltimoAlmacen()

                End If

            End If

        Catch ex As Exception

            MsgBox("Error al crear el almacen: " & ex.Message)

        End Try

    End Function

    Public Function Buscar()

        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim DocEntry As Integer

        Try

            If TextBox1.Text = Nothing Then

                MsgBox("Coloca el almacen que deseaas ver.")

            Else

                Dim query As String = "Select * from OWHS T0 where T0.Almacen='" & TextBox1.Text & "'"

                comm.CommandText = query
                comm.Connection = conexionSQL
                DA.SelectCommand = comm
                DA.Fill(DS)

                If DS.Tables(0).Rows.Count > 0 Then

                    TextBox1.Enabled = False
                    TextBox1.Text = DS.Tables(0).Rows(0)("Almacen").ToString
                    TextBox2.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                    TextBox3.Text = DS.Tables(0).Rows(0)("Localidad").ToString
                    DocEntry = DS.Tables(0).Rows(0)("WhsCode").ToString

                Else

                    MsgBox("No se encontro ni un almacen con el código proporcionado.")

                End If

            End If

        Catch ex As Exception

            MsgBox("Error al Buscar el almacen : " & ex.Message)

        End Try

    End Function

    Private Sub Salida_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        Me.Hide()
        Operaciones.Show()

    End Sub

End Class