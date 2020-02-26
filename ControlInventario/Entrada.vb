Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.DataSet
Imports System.Data.DataViewManager
Imports System.Windows.Forms

Public Class Entradas

    Dim conexionSQL As SqlConnection

    Private Sub Entrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conexionSQL = Operaciones.conexionSQL

        Dim query As String = "Select NombreAlmacen from OWHS"
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim Name As String

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

            UltimaEntrega()
            CrearGrid("")

            PictureBox4.Visible = False
            PictureBox4.Enabled = False

        Catch ex As Exception

            MsgBox("Cargar forma: " & ex.Message)

        End Try

    End Sub

    Public Function UltimaEntrega()

        Dim query2 As String = "Select count(DocNum)+1 as 'DocNum' from OIGN"
        Dim comm2 As New SqlCommand
        Dim DA2 As New SqlDataAdapter
        Dim DS2 As New System.Data.DataSet

        Try

            comm2.CommandText = query2
            comm2.Connection = conexionSQL
            DA2.SelectCommand = comm2
            DA2.Fill(DS2)

            If (DS2.Tables(0).Rows.Count > 0) Then

                TextBox1.Text = DS2.Tables(0).Rows(0)("DocNum").ToString
                TextBox1.Enabled = False

            End If

        Catch ex As Exception

            MsgBox("Error en UltimaEntrega: " & ex.Message)

        End Try

    End Function

    Public Function CrearGrid(ByVal Almacen As String)

        Dim ComboboxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim query As String = "Select Nombre from OUSR where Almacen='" & Almacen & "'"
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim Name As String

        Try
            '----- ejecutamos comando SQL 1
            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            DataGridView1.Columns.Clear()
            DataGridView1.Rows.Clear()
            ComboboxColumn.DataPropertyName = "Usuario"
            ComboboxColumn.HeaderText = "Usuario *"

            If (DS.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS.Tables(0).Rows.Count) - 1

                    Name = DS.Tables(0).Rows(i)("Nombre").ToString
                    ComboboxColumn.Items.Add(Name)

                Next

            End If

            DataGridView1.Columns.Add("Descripcion", "Descripcion *")
            DataGridView1.Columns.Add("Marca", "Marca *")
            DataGridView1.Columns.Add("Serie", "Serie *")
            DataGridView1.Columns.Add("Modelo", "Modelo *")
            DataGridView1.Columns.Add(ComboboxColumn)
            DataGridView1.Columns.Add("Comentarios", "Comentarios")

            DataGridView1.Rows.Add(10)

        Catch ex As Exception

            MsgBox("Crear Grid: " & ex.Message)

        End Try

    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        TextBox1.Text = ""
        TextBox1.Enabled = True
        Button1.Text = "Buscar"
        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        ComboBox1.Enabled = False
        ComboBox1.Text = Nothing
        DateTimePicker1.Enabled = False
        DataGridView1.Rows.Clear()
        DataGridView1.Enabled = False
        CrearGrid("")

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        UltimaEntrega()
        TextBox1.Enabled = False
        Button1.Enabled = True
        Button1.Visible = True
        Button1.Text = "Crear"
        PictureBox4.Visible = False
        PictureBox4.Enabled = False
        PictureBox1.Visible = True
        PictureBox1.Enabled = True
        ComboBox1.Enabled = True
        ComboBox1.Text = Nothing
        DateTimePicker1.Enabled = True
        DateTimePicker1.Value = Now.Date
        DataGridView1.Rows.Clear()
        DataGridView1.Enabled = True
        CrearGrid("")

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        DataGridView1.Rows.Clear()
        Atras("OIGN")

    End Sub

    Public Function Atras(ByVal table As String)

        Dim comm, comm2, comm4, comm5 As New SqlCommand
        Dim DA, DA2, DA4, DA5 As New SqlDataAdapter
        Dim DS, DS2, DS4, DS5 As New System.Data.DataSet
        Dim Documento, DocEntry As Integer

        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        Button1.Enabled = False
        Button1.Visible = False
        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        DateTimePicker1.Enabled = False

        Try

            If TextBox1.Text = Nothing Then

                Documento = 0

            Else

                Documento = TextBox1.Text

            End If

            Dim query As String = "Select T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen where T0.DocNum=" & Documento - 1

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("DocNum").ToString
                ComboBox1.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                DateTimePicker1.Value = DS.Tables(0).Rows(0)("Fecha").ToString
                DocEntry = DS.Tables(0).Rows(0)("DocEntry").ToString

                LlenarGrid(DocEntry, table)

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select top 1 T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen order by DocEntry desc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("DocNum").ToString
                    ComboBox1.Text = DS2.Tables(0).Rows(0)("NombreAlmacen").ToString
                    DateTimePicker1.Value = DS2.Tables(0).Rows(0)("Fecha").ToString
                    DocEntry = DS2.Tables(0).Rows(0)("DocEntry").ToString

                    LlenarGrid(DocEntry, table)

                End If

            End If

        Catch ex As Exception

            MsgBox("Error en Buscar Documento Anteriror: " & ex.Message)

        End Try

    End Function

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        DataGridView1.Rows.Clear()
        Adelante("OIGN")

    End Sub

    Public Function Adelante(ByVal table As String)

        Dim comm, comm2, comm4, comm5 As New SqlCommand
        Dim DA, DA2, DA4, DA5 As New SqlDataAdapter
        Dim DS, DS2, DS4, DS5 As New System.Data.DataSet
        Dim Documento, DocEntry As Integer

        PictureBox1.Visible = False
        PictureBox1.Enabled = False
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        Button1.Enabled = False
        Button1.Visible = False
        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        DateTimePicker1.Enabled = False

        Try

            If TextBox1.Text = Nothing Then

                Documento = 0

            Else

                Documento = TextBox1.Text

            End If

            Dim query As String = "Select T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen where T0.DocNum=" & Documento + 1

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("DocNum").ToString
                ComboBox1.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                DateTimePicker1.Value = DS.Tables(0).Rows(0)("Fecha").ToString
                DocEntry = DS.Tables(0).Rows(0)("DocEntry").ToString

                LlenarGrid(DocEntry, table)

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select top 1 T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen order by DocEntry asc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("DocNum").ToString
                    ComboBox1.Text = DS2.Tables(0).Rows(0)("NombreAlmacen").ToString
                    DateTimePicker1.Value = DS2.Tables(0).Rows(0)("Fecha").ToString
                    DocEntry = DS2.Tables(0).Rows(0)("DocEntry").ToString

                    LlenarGrid(DocEntry, table)

                End If

            End If

        Catch ex As Exception

            MsgBox("Error en Buscar Documento Anteriror: " & ex.Message)

        End Try

    End Function

    Public Function LlenarGrid(ByVal DocEntry As Integer, ByVal table As String)

        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim childtable As String
        Dim Info, Relleno As Integer

        childtable = table.Substring(1, 3) & "1"

        Dim query As String = "Select T0.Descripcion,T0.Marca,T0.Serie,T0.Modelo,T1.Nombre,T0.Comentarios from " & childtable & " T0 Inner Join OUSR T1 on T1.Usuario=T0.Usuario where T0.DocEntry=" & DocEntry & " order by T0.LineNum asc"

        Try

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count > 0 Then

                Info = DS.Tables(0).Rows.Count
                Relleno = 10 - Info
                DataGridView1.Rows.Add(Info + Relleno)

                For cont As Integer = 0 To Info - 1

                    DataGridView1.Item(0, cont).Value = DS.Tables(0).Rows(cont)("Descripcion").ToString
                    DataGridView1.Item(1, cont).Value = DS.Tables(0).Rows(cont)("Marca").ToString
                    DataGridView1.Item(2, cont).Value = DS.Tables(0).Rows(cont)("Serie").ToString
                    DataGridView1.Item(3, cont).Value = DS.Tables(0).Rows(cont)("Modelo").ToString
                    DataGridView1.Item(4, cont).Value = DS.Tables(0).Rows(cont)("Nombre").ToString
                    DataGridView1.Item(5, cont).Value = DS.Tables(0).Rows(cont)("Comentarios").ToString

                Next

                For cont2 As Integer = 0 To 10 - 1

                    DataGridView1.Item(0, cont2).ReadOnly = True
                    DataGridView1.Item(1, cont2).ReadOnly = True
                    DataGridView1.Item(2, cont2).ReadOnly = True
                    DataGridView1.Item(3, cont2).ReadOnly = True
                    DataGridView1.Item(4, cont2).ReadOnly = True
                    DataGridView1.Item(5, cont2).ReadOnly = True

                Next

            End If

        Catch ex As Exception

            MsgBox("Error al llenar grid: " & ex.Message)

        End Try

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Button1.Text = "Crear" Then

            Crear("OIGN", TextBox1.Text, ComboBox1.Text, DateTimePicker1.Value)

        ElseIf Button1.Text = "Buscar" Then

            Buscar("OIGN", TextBox1.Text)

        End If

    End Sub

    Public Function Crear(ByVal table As String, ByVal DocNum As String, ByVal Almacen As String, ByVal Fecha As Date)

        Dim DateFixed, AlmacenCode As String
        Dim query As String = "Select Almacen from OWHS where NombreAlmacen='" & Almacen & "'"
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim Info, InfoCompleta As Integer

        DateFixed = Fecha.Year & "-" & Fecha.Month & "-" & Fecha.Day
        Info = 0
        InfoCompleta = 0

        Try

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If (DS.Tables(0).Rows.Count > 0) Then

                AlmacenCode = DS.Tables(0).Rows(0)("Almacen").ToString

                For cont As Integer = 0 To 10

                    If DataGridView1.Item(0, cont).Value <> "" Then

                        Info = Info + 1

                    End If

                    If DataGridView1.Item(0, cont).Value <> "" And DataGridView1.Item(1, cont).Value <> "" And DataGridView1.Item(2, cont).Value <> "" And DataGridView1.Item(3, cont).Value <> "" And DataGridView1.Item(4, cont).Value <> "" Then

                        InfoCompleta = InfoCompleta + 1

                    End If

                Next

                If Info = 0 Then

                    MsgBox("Por favor coloca articulos de entrada")

                ElseIf Info > 0 And Info > InfoCompleta Then

                    MsgBox("Los campos con (*) son obligatorios por favor completa la informacion")

                ElseIf Info > 0 And Info = InfoCompleta Then

                    InsertTables(table, DocNum, AlmacenCode, DateFixed)

                End If

            Else

                MsgBox("Por favor coloca un almacen valido.")

            End If

        Catch ex As Exception

            MsgBox("Error en UltimaEntrega: " & ex.Message)

        End Try

    End Function

    Public Function InsertTables(ByVal table As String, ByVal DocNum As String, ByVal AlmacenCode As String, ByVal DateFixed As String)

        Dim comm2, comm3, comm4, comm5 As New SqlCommand
        Dim DA2, DA3, DA4, DA5 As New SqlDataAdapter
        Dim DS2, DS3, DS4, DS5 As New System.Data.DataSet
        Dim DocEntry, Usuarios, Linea As Integer
        Dim Descripcion, Marca, Serie, Modelo, Comentarios, ChildTable As String

        Dim query2 As String = "Insert Into " & table & " values(" & DocNum & ",'" & AlmacenCode & "',getdate(),'" & DateFixed & "')"
        Dim query3 As String = "Select DocEntry from " & table & " where DocNum=" & DocNum

        Try

            comm2.CommandText = query2
            comm2.Connection = conexionSQL
            DA2.SelectCommand = comm2
            DA2.Fill(DS2)

            comm3.CommandText = query3
            comm3.Connection = conexionSQL
            DA3.SelectCommand = comm3
            DA3.Fill(DS3)

            Linea = 0

            For cont As Integer = 0 To 10

                If DataGridView1.Item(0, cont).Value <> "" Then

                    Dim query5 As String = "Select Usuario from OUSR where Nombre='" & DataGridView1.Item(4, cont).Value & "'"

                    comm5.CommandText = query5
                    comm5.Connection = conexionSQL
                    DA5.SelectCommand = comm5
                    DA5.Fill(DS5)

                    ChildTable = table.Substring(1, 3) & "1"
                    DocEntry = DS3.Tables(0).Rows(0)("DocEntry").ToString
                    Descripcion = DataGridView1.Item(0, cont).Value
                    Marca = DataGridView1.Item(1, cont).Value
                    Serie = DataGridView1.Item(2, cont).Value
                    Modelo = DataGridView1.Item(3, cont).Value
                    Usuarios = DS5.Tables(0).Rows(0)("Usuario").ToString
                    Comentarios = DataGridView1.Item(5, cont).Value
                    Linea = Linea + 1

                    Dim query4 As String = "insert into " & ChildTable & " values(" & DocEntry & "," & Linea & ",'" & Descripcion & "','" & Marca & "','" & Serie & "','" & Modelo & "'," & Usuarios & ",'" & Comentarios & "',null,null)"

                    comm4.CommandText = query4
                    comm4.Connection = conexionSQL
                    DA4.SelectCommand = comm4
                    DA4.Fill(DS4)

                End If

                DS5.Clear()

            Next

            UltimaEntrega()
            ComboBox1.Text = Nothing
            CrearGrid(ComboBox1.Text)
            DateTimePicker1.Value = Now.Date
            DS2.Clear()
            DS3.Clear()
            DS4.Clear()

        Catch ex As Exception

            MsgBox("Error en InsertTables: " & ex.Message)

        End Try

    End Function

    Public Function Buscar(ByVal table As String, ByVal DocNum As String)

        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim DocEntry As Integer

        Try

            If DocNum = Nothing Then

                MsgBox("Coloca el numero de entrada que deseaas ver.")

            Else

                Dim query As String = "Select T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen where T0.DocNum=" & DocNum

                comm.CommandText = query
                comm.Connection = conexionSQL
                DA.SelectCommand = comm
                DA.Fill(DS)

                If DS.Tables(0).Rows.Count > 0 Then

                    TextBox1.Enabled = False
                    TextBox1.Text = DS.Tables(0).Rows(0)("DocNum").ToString
                    ComboBox1.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                    DateTimePicker1.Value = DS.Tables(0).Rows(0)("Fecha").ToString
                    DocEntry = DS.Tables(0).Rows(0)("DocEntry").ToString

                    LlenarGrid(DocEntry, table)

                Else

                    MsgBox("No se encontro una entrega con el numero proporcionado.")

                End If

            End If

        Catch ex As Exception

            MsgBox("Error al Buscar: " & ex.Message)

        End Try

    End Function

    Private Sub Entrada_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        Me.Hide()
        Operaciones.Show()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim query As String = "Select Almacen from OWHS where NombreAlmacen='" & ComboBox1.Text & "'"
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet
        Dim Almacen As String

        Try
            '----- ejecutamos comando SQL 1
            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                Almacen = DS.Tables(0).Rows(0)("Almacen").ToString
                CrearGrid(Almacen)

            End If

        Catch ex As Exception

            MsgBox("Selection de almacen: " & ex.Message)

        End Try

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class