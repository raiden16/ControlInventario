Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.DataSet
Imports System.Data.DataViewManager
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Salidas

    Dim Almacen, Departamento As String
    Dim conexionSQL As SqlConnection
    Dim PDF As String

    Private Sub Salidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

            UltimaSalida()
            CrearGrid("", "")

            PictureBox4.Visible = False
            PictureBox4.Enabled = False


        Catch ex As Exception

            MsgBox("Cargar forma: " & ex.Message)

        End Try

    End Sub

    Public Function UltimaSalida()

        Dim query2 As String = "Select count(DocNum)+1 as 'DocNum' from OIGE"
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

    Public Function CrearGrid(ByVal Almacen As String, ByVal Departamento As String)

        Dim ComboboxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim ComboboxColumn1 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim ComboboxColumn2 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim ComboboxColumn3 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim ComboboxColumn4 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim query As String = "Select T0.Descripcion from IGN1 T0 Inner Join OIGN T1 on T0.DocEntry=T1.DocEntry Inner Join OWHS T2 on T2.Almacen=T1.Almacen Inner Join OUSR T3 on T3.Usuario=T0.Usuario and T3.Almacen=T1.Almacen where T2.Almacen='" & Almacen & "' and T3.Departamento='" & Departamento & "' and T0.TrgtEntry is null and T0.TrgtLine is null group by T0.Descripcion,T0.LineNum order by T0.LineNum asc"
        Dim query1 As String = "Select T0.Marca from IGN1 T0 Inner Join OIGN T1 on T0.DocEntry=T1.DocEntry Inner Join OWHS T2 on T2.Almacen=T1.Almacen Inner Join OUSR T3 on T3.Usuario=T0.Usuario and T3.Almacen=T1.Almacen where T2.Almacen='" & Almacen & "' and T3.Departamento='" & Departamento & "' and T0.TrgtEntry is null and T0.TrgtLine is null group by T0.Marca,T0.LineNum order by T0.LineNum asc"
        Dim query2 As String = "Select T0.Serie from IGN1 T0 Inner Join OIGN T1 on T0.DocEntry=T1.DocEntry Inner Join OWHS T2 on T2.Almacen=T1.Almacen Inner Join OUSR T3 on T3.Usuario=T0.Usuario and T3.Almacen=T1.Almacen where T2.Almacen='" & Almacen & "' and T3.Departamento='" & Departamento & "' and T0.TrgtEntry is null and T0.TrgtLine is null group by T0.Serie,T0.LineNum order by T0.LineNum asc"
        Dim query3 As String = "Select T0.Modelo from IGN1 T0 Inner Join OIGN T1 on T0.DocEntry=T1.DocEntry Inner Join OWHS T2 on T2.Almacen=T1.Almacen Inner Join OUSR T3 on T3.Usuario=T0.Usuario and T3.Almacen=T1.Almacen where T2.Almacen='" & Almacen & "' and T3.Departamento='" & Departamento & "' and T0.TrgtEntry is null and T0.TrgtLine is null group by T0.Modelo,T0.LineNum order by T0.LineNum asc"
        Dim query4 As String = "Select T3.Nombre from IGN1 T0 Inner Join OIGN T1 on T0.DocEntry=T1.DocEntry Inner Join OWHS T2 on T2.Almacen=T1.Almacen Inner Join OUSR T3 on T3.Usuario=T0.Usuario and T3.Almacen=T1.Almacen where T2.Almacen='" & Almacen & "' and T3.Departamento='" & Departamento & "' and T0.TrgtEntry is null and T0.TrgtLine is null group by T3.Nombre,T0.LineNum order by T0.LineNum asc"
        Dim comm, comm1, comm2, comm3, comm4 As New SqlCommand
        Dim DA, DA1, DA2, DA3, DA4 As New SqlDataAdapter
        Dim DS, DS1, DS2, DS3, DS4 As New System.Data.DataSet
        Dim Name, Name1, Name2, Name3, Name4 As String

        Try
            '----- ejecutamos comando SQL 1
            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            comm1.CommandText = query1
            comm1.Connection = conexionSQL
            DA1.SelectCommand = comm1
            DA1.Fill(DS1)

            comm2.CommandText = query2
            comm2.Connection = conexionSQL
            DA2.SelectCommand = comm2
            DA2.Fill(DS2)

            comm3.CommandText = query3
            comm3.Connection = conexionSQL
            DA3.SelectCommand = comm3
            DA3.Fill(DS3)

            comm4.CommandText = query4
            comm4.Connection = conexionSQL
            DA4.SelectCommand = comm4
            DA4.Fill(DS4)

            DataGridView1.Columns.Clear()
            DataGridView1.Rows.Clear()
            ComboboxColumn.DataPropertyName = "Descripcion"
            ComboboxColumn.HeaderText = "Descripcion *"
            ComboboxColumn1.DataPropertyName = "Marca"
            ComboboxColumn1.HeaderText = "Marca *"
            ComboboxColumn2.DataPropertyName = "Serie"
            ComboboxColumn2.HeaderText = "Serie *"
            ComboboxColumn3.DataPropertyName = "Modelo"
            ComboboxColumn3.HeaderText = "Modelo *"
            ComboboxColumn4.DataPropertyName = "Usuario"
            ComboboxColumn4.HeaderText = "Usuario *"

            If (DS.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS.Tables(0).Rows.Count) - 1

                    Name = DS.Tables(0).Rows(i)("Descripcion").ToString
                    ComboboxColumn.Items.Add(Name)

                Next

            End If

            If (DS1.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS1.Tables(0).Rows.Count) - 1

                    Name1 = DS1.Tables(0).Rows(i)("Marca").ToString
                    ComboboxColumn1.Items.Add(Name1)

                Next

            End If

            If (DS2.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS2.Tables(0).Rows.Count) - 1

                    Name2 = DS2.Tables(0).Rows(i)("Serie").ToString
                    ComboboxColumn2.Items.Add(Name2)

                Next

            End If

            If (DS3.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS3.Tables(0).Rows.Count) - 1

                    Name3 = DS3.Tables(0).Rows(i)("Modelo").ToString
                    ComboboxColumn3.Items.Add(Name3)

                Next

            End If

            If (DS4.Tables(0).Rows.Count > 0) Then

                For i As Integer = 0 To (DS4.Tables(0).Rows.Count) - 1

                    Name4 = DS4.Tables(0).Rows(i)("Nombre").ToString
                    ComboboxColumn4.Items.Add(Name4)

                Next

            End If

            DataGridView1.Columns.Add(ComboboxColumn)
            DataGridView1.Columns.Add(ComboboxColumn1)
            DataGridView1.Columns.Add(ComboboxColumn2)
            DataGridView1.Columns.Add(ComboboxColumn3)
            DataGridView1.Columns.Add(ComboboxColumn4)
            DataGridView1.Columns.Add("Comentarios", "Comentarios *")

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
        ComboBox2.Enabled = False
        ComboBox2.Text = Nothing
        DateTimePicker1.Enabled = False
        DataGridView1.Rows.Clear()
        DataGridView1.Enabled = False
        CrearGrid("", "")

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        UltimaSalida()
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
        ComboBox2.Enabled = True
        ComboBox2.Text = Nothing
        DateTimePicker1.Enabled = True
        DateTimePicker1.Value = Now.Date
        DataGridView1.Rows.Clear()
        DataGridView1.Enabled = True
        CrearGrid("", "")

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        DataGridView1.Rows.Clear()
        Atras("OIGE")

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
        ComboBox2.Enabled = False
        DateTimePicker1.Enabled = False

        Try

            If TextBox1.Text = Nothing Then

                Documento = 0

            Else

                Documento = TextBox1.Text

            End If

            Dim query As String = "Select T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen Inner Join IGE1 T2 on T2.DocEntry=T0.DocEntry Inner Join OUSR T3 on T3.Usuario=T2.Usuario where T0.DocNum=" & Documento - 1 & " group by T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento"

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("DocNum").ToString
                ComboBox1.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                ComboBox2.Text = DS.Tables(0).Rows(0)("Departamento").ToString
                DateTimePicker1.Value = DS.Tables(0).Rows(0)("Fecha").ToString
                DocEntry = DS.Tables(0).Rows(0)("DocEntry").ToString

                LlenarGrid(DocEntry, table)

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select top 1 T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen Inner Join IGE1 T2 on T2.DocEntry=T0.DocEntry Inner Join OUSR T3 on T3.Usuario=T2.Usuario group by T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento order by DocEntry desc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("DocNum").ToString
                    ComboBox1.Text = DS2.Tables(0).Rows(0)("NombreAlmacen").ToString
                    ComboBox2.Text = DS2.Tables(0).Rows(0)("Departamento").ToString
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
        Adelante("OIGE")

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
        ComboBox2.Enabled = False
        DateTimePicker1.Enabled = False

        Try

            If TextBox1.Text = Nothing Then

                Documento = 0

            Else

                Documento = TextBox1.Text

            End If

            Dim query As String = "Select T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen Inner Join IGE1 T2 on T2.DocEntry=T0.DocEntry Inner Join OUSR T3 on T3.Usuario=T2.Usuario where T0.DocNum=" & Documento + 1 & " group by T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento"

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                TextBox1.Text = DS.Tables(0).Rows(0)("DocNum").ToString
                ComboBox1.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                ComboBox2.Text = DS.Tables(0).Rows(0)("Departamento").ToString
                DateTimePicker1.Value = DS.Tables(0).Rows(0)("Fecha").ToString
                DocEntry = DS.Tables(0).Rows(0)("DocEntry").ToString

                LlenarGrid(DocEntry, table)

            ElseIf DS.Tables(0).Rows.Count = 0 Then

                Dim query2 As String = "Select top 1 T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen Inner Join IGE1 T2 on T2.DocEntry=T0.DocEntry Inner Join OUSR T3 on T3.Usuario=T2.Usuario group by T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento order by DocEntry asc"

                comm2.CommandText = query2
                comm2.Connection = conexionSQL
                DA2.SelectCommand = comm2
                DA2.Fill(DS2)

                If DS2.Tables(0).Rows.Count = 0 Then

                    MsgBox("Sin registros.")

                Else

                    TextBox1.Text = DS2.Tables(0).Rows(0)("DocNum").ToString
                    ComboBox1.Text = DS2.Tables(0).Rows(0)("NombreAlmacen").ToString
                    ComboBox2.Text = DS2.Tables(0).Rows(0)("Departamento").ToString
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
                DataGridView1.Columns.Clear()
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Add("Descripcion", "Descripcion *")
                DataGridView1.Columns.Add("Marca", "Marca *")
                DataGridView1.Columns.Add("Serie", "Serie *")
                DataGridView1.Columns.Add("Modelo", "Modelo *")
                DataGridView1.Columns.Add("Nombre", "Nombre *")
                DataGridView1.Columns.Add("Comentarios", "Comentarios *")
                DataGridView1.Rows.Add(Info + Relleno)

                For cont As Integer = 0 To Info - 1

                    DataGridView1.Item(0, cont).Value = DS.Tables(0).Rows(cont)("Descripcion").ToString
                    DataGridView1.Item(1, cont).Value = DS.Tables(0).Rows(cont)("Marca").ToString
                    DataGridView1.Item(2, cont).Value = DS.Tables(0).Rows(cont)("Serie").ToString
                    DataGridView1.Item(3, cont).Value = DS.Tables(0).Rows(cont)("Modelo").ToString
                    DataGridView1.Item(4, cont).Value = DS.Tables(0).Rows(cont)("Nombre").ToString
                    DataGridView1.Item(5, cont).Value = DS.Tables(0).Rows(cont)("Comentarios").ToString

                    DataGridView1.Item(0, cont).ReadOnly = True
                    DataGridView1.Item(1, cont).ReadOnly = True
                    DataGridView1.Item(2, cont).ReadOnly = True
                    DataGridView1.Item(3, cont).ReadOnly = True
                    DataGridView1.Item(4, cont).ReadOnly = True
                    DataGridView1.Item(5, cont).ReadOnly = True

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

            Crear("OIGE", TextBox1.Text, ComboBox1.Text, DateTimePicker1.Value)

        ElseIf Button1.Text = "Buscar" Then

            Buscar("OIGE", TextBox1.Text)

        End If

    End Sub

    Public Function Crear(ByVal table As String, ByVal DocNum As String, ByVal Almacen As String, ByVal Fecha As Date)

        Dim DateFixed, AlmacenCode, Usuario As String
        Dim query As String = "Select Almacen from OWHS where NombreAlmacen='" & Almacen & "'"
        Dim comm, comm2, comm3 As New SqlCommand
        Dim DA, DA2, DA3 As New SqlDataAdapter
        Dim DS, DS2, DS3 As New System.Data.DataSet
        Dim Info, InfoCompleta, Base As Integer

        DateFixed = Fecha.Year & "-" & Fecha.Month & "-" & Fecha.Day
        Info = 0
        InfoCompleta = 0
        Base = 0

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

                    If DataGridView1.Item(0, cont).Value <> "" And DataGridView1.Item(1, cont).Value <> "" And DataGridView1.Item(2, cont).Value <> "" And DataGridView1.Item(3, cont).Value <> "" And DataGridView1.Item(4, cont).Value <> "" And DataGridView1.Item(5, cont).Value <> "" Then

                        InfoCompleta = InfoCompleta + 1

                        Dim query3 As String = "Select Usuario from OUSR where Nombre='" & DataGridView1.Item(4, cont).Value & "'"

                        comm3.CommandText = query3
                        comm3.Connection = conexionSQL
                        DA3.SelectCommand = comm3
                        DA3.Fill(DS3)

                        Usuario = DS3.Tables(0).Rows(0)("Usuario").ToString()

                        Dim query2 As String = "Select Top 1 * from IGN1 where Descripcion='" & DataGridView1.Item(0, cont).Value & "' and Marca='" & DataGridView1.Item(1, cont).Value & "' and Serie='" & DataGridView1.Item(2, cont).Value & "' and Modelo='" & DataGridView1.Item(3, cont).Value & "' and Usuario='" & Usuario & "' and TrgtEntry is null and TrgtLine is null order by LineNum asc"

                        comm2.CommandText = query2
                        comm2.Connection = conexionSQL
                        DA2.SelectCommand = comm2
                        DA2.Fill(DS2)

                        If DS2.Tables(0).Rows.Count = 0 Then

                            MsgBox("La linea " & cont + 1 & " no coincide con los registros de entrada.")

                        Else

                            Base = Base + 1

                        End If

                    End If

                Next

                If Info = 0 Then

                    MsgBox("Por favor coloca articulos de entrada")

                ElseIf Info > 0 And Info > InfoCompleta Then

                    MsgBox("Los campos con (*) son obligatorios por favor completa la informacion")

                ElseIf Info > 0 And Info = InfoCompleta And Info = Base Then

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

        Dim comm2, comm3, comm4, comm5, comm6, comm7 As New SqlCommand
        Dim DA2, DA3, DA4, DA5, DA6, DA7 As New SqlDataAdapter
        Dim DS2, DS3, DS4, DS5, DS6, DS7 As New System.Data.DataSet
        Dim DocEntry, Usuarios, Linea, BaseEntry, BaseLine As Integer
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

                    Dim query4 As String = "insert into " & ChildTable & " values(" & DocEntry & "," & Linea & ",'" & Descripcion & "','" & Marca & "','" & Serie & "','" & Modelo & "'," & Usuarios & ",'" & Comentarios & "')"

                    comm4.CommandText = query4
                    comm4.Connection = conexionSQL
                    DA4.SelectCommand = comm4
                    DA4.Fill(DS4)

                    Dim query6 As String = "Select Top 1 DocEntry, LineNum from IGN1 where Descripcion='" & Descripcion & "' and Marca='" & Marca & "' and Serie='" & Serie & "' and Modelo='" & Modelo & "' and Usuario='" & Usuarios & "' and TrgtEntry is null and TrgtLine is null order by LineNum asc"

                    comm6.CommandText = query6
                    comm6.Connection = conexionSQL
                    DA6.SelectCommand = comm6
                    DA6.Fill(DS6)

                    BaseEntry = DS6.Tables(0).Rows(0)("DocEntry").ToString()
                    BaseLine = DS6.Tables(0).Rows(0)("LineNum").ToString()

                    Dim query7 As String = "Update IGN1 set TrgtEntry=" & DocEntry & ", TrgtLine=" & Linea & " where DocEntry='" & BaseEntry & "' and LineNum='" & BaseLine & "'"

                    comm7.CommandText = query7
                    comm7.Connection = conexionSQL
                    DA7.SelectCommand = comm7
                    DA7.Fill(DS7)

                End If

                DS5.Clear()

            Next

            UltimaSalida()
            ComboBox1.Text = Nothing
            ComboBox2.Text = Nothing
            CrearGrid(ComboBox1.Text, ComboBox2.Text)
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

                Dim query As String = "Select T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento from " & table & " T0 Inner Join OWHS T1 on T1.Almacen=T0.Almacen Inner Join IGE1 T2 on T2.DocEntry=T0.DocEntry Inner Join OUSR T3 on T3.Usuario=T2.Usuario where T0.DocNum=" & DocNum & " group by T0.DocEntry,T0.DocNum,T1.NombreAlmacen,T0.Fecha,T3.Departamento"

                comm.CommandText = query
                comm.Connection = conexionSQL
                DA.SelectCommand = comm
                DA.Fill(DS)

                If DS.Tables(0).Rows.Count > 0 Then

                    TextBox1.Enabled = False
                    TextBox1.Text = DS.Tables(0).Rows(0)("DocNum").ToString
                    ComboBox1.Text = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
                    ComboBox2.Text = DS.Tables(0).Rows(0)("Departamento").ToString
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

    Private Sub Salida_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        Me.Hide()
        Operaciones.Show()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim query As String = "Select Almacen from OWHS where NombreAlmacen='" & ComboBox1.Text & "'"
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet

        Try
            '----- ejecutamos comando SQL 1
            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                Almacen = DS.Tables(0).Rows(0)("Almacen").ToString

            End If

        Catch ex As Exception

            MsgBox("Selection de almacen: " & ex.Message)

        End Try

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Dim query As String = "Select Departamento from WHS1 where Departamento='" & ComboBox2.Text & "'"
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet

        Try
            '----- ejecutamos comando SQL 1
            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                Departamento = DS.Tables(0).Rows(0)("Departamento").ToString
                CrearGrid(Almacen, Departamento)

            End If

        Catch ex As Exception

            MsgBox("Selection de Departamento: " & ex.Message)

        End Try

    End Sub

    Private Sub Impresora_Click(sender As Object, e As EventArgs) Handles Impresora.Click

        Dim Salida As String
        Dim query As String
        Dim comm As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim DS As New System.Data.DataSet

        Try

            Salida = TextBox1.Text
            query = "Select DocEntry from OIGE where DocNum=" & Salida
            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            If DS.Tables(0).Rows.Count = 1 Then

                'Busca o crea el PDF
                ValidarDoc(Salida)

            End If

        Catch ex As Exception

            MsgBox("Error Impresora_Click. " & ex.Message)

        End Try

    End Sub

    Public Function ValidarDoc(ByVal Salida As String)

        'MsgBox("Exportar Documento Exitoso")
        Dim Ruta As String
        PDF = Nothing

        Try

            Ruta = My.Settings.Ruta & "Salida"

            Dim dir As New System.IO.DirectoryInfo(Ruta)

            Dim fileList = dir.GetFiles("*.pdf", System.IO.SearchOption.TopDirectoryOnly)

            Dim FileQuery = From file In fileList
                            Where file.Extension = ".pdf" And file.Name.Trim.ToString.EndsWith(Salida & ".pdf") And file.Name.Trim.ToString.StartsWith(Salida & ".pdf")
                            Order By file.CreationTime
                            Select file

            PDF = Ruta & "\" & Salida & ".pdf"

            If FileQuery.Count > 0 Then

                Dim p As New Process
                p.StartInfo.FileName = PDF
                p.StartInfo.Verb = "Open"
                p.Start()

            Else

                CrearPDF(Salida)

            End If

        Catch ex As Exception

            MsgBox("Error en ValidarDoc. " & ex.Message)

        End Try

    End Function

    Public Function CrearPDF(ByVal Salida As String)

        Dim query As String = "Select T0.*,T1.NombreAlmacen from OIGE T0 INNER JOIN OWHS T1 on T1.""Almacen""=T0.""Almacen"" where T0.DocNum=" & Salida
        Dim comm, comm1 As New SqlCommand
        Dim DA, DA1 As New SqlDataAdapter
        Dim DS, DS1 As New System.Data.DataSet
        Dim query1 As String
        Dim oDoc As New iTextSharp.text.Document(PageSize.LETTER, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente, fuenteInfo As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Settings.Ruta & "Salida\" & Salida & ".pdf"
        Dim DocEntry, Almacen, NombreAlmacen, FixCreateDate, FixFecha As String
        Dim CreateDate, Fecha As Date
        Dim Descripcion, Marca, Serie, Modelo, NombreEmpleado, Comentarios As String
        Dim skip As Integer = 100
        Dim image As Image


        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()
            'Iniciamos el flujo de bytes.
            cb.BeginText()
            'Instanciamos el objeto para la tipo de letra.
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            fuenteInfo = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'iTextSharp.text.Font.DEFAULTSIZE
            'Seteamos el tipo de letra y el tamaño.
            cb.SetFontAndSize(fuente, 14)
            'Seteamos el color del texto a escribir.
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            'Aqui es donde se escribe el texto.
            'Aclaracion: Por alguna razon la coordenada vertical siempre es tomada desde el borde inferior (de ahi que se calcule como “PageSize.A4.Height – 50″)

            '------------Header
            image = Image.GetInstance(My.Settings.RutaLogo & My.Settings.NombreLogo)
            image.ScaleAbsolute(200, 50)
            image.SetAbsolutePosition(30.0F, 730.0F)
            cb.AddImage(image)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Control de Invetario Salidas", 300, PageSize.LETTER.Height - 35, 0)

            comm.CommandText = query
            comm.Connection = conexionSQL
            DA.SelectCommand = comm
            DA.Fill(DS)

            DocEntry = DS.Tables(0).Rows(0)("DocEntry").ToString
            Almacen = DS.Tables(0).Rows(0)("Almacen").ToString
            NombreAlmacen = DS.Tables(0).Rows(0)("NombreAlmacen").ToString
            CreateDate = DS.Tables(0).Rows(0)("CreateDate").ToString
            Fecha = DS.Tables(0).Rows(0)("Fecha").ToString

            FixCreateDate = CreateDate.Day & "-" & CreateDate.Month & "-" & CreateDate.Year
            FixFecha = Fecha.Day & "-" & Fecha.Month & "-" & Fecha.Year

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, FixCreateDate, 360, PageSize.LETTER.Height - 50, 0)

            cb.SetFontAndSize(fuente, 10)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Salida: ", 25, PageSize.LETTER.Height - skip, 0)
            cb.SetFontAndSize(fuenteInfo, 10)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Salida, 80, PageSize.LETTER.Height - skip, 0)

            skip = skip + 15
            cb.SetFontAndSize(fuente, 10)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Almacen: ", 25, PageSize.LETTER.Height - skip, 0)
            cb.SetFontAndSize(fuenteInfo, 10)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Almacen & " - " & NombreAlmacen, 80, PageSize.LETTER.Height - skip, 0)

            skip = skip + 15
            cb.SetFontAndSize(fuente, 10)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha de Salida: ", 25, PageSize.LETTER.Height - skip, 0)
            cb.SetFontAndSize(fuenteInfo, 10)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Fecha, 120, PageSize.LETTER.Height - skip, 0)

            skip = skip + 20
            cb.SetFontAndSize(fuente, 12)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Artículos", 260, PageSize.LETTER.Height - skip, 0)
            skip = skip + 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "___________________________________________________________________________________", 25, PageSize.LETTER.Height - skip, 0)

            query1 = "Select T0.*,T1.Nombre from IGE1 T0 Inner Join OUSR T1 on T1.""Usuario""=T0.""Usuario"" where T0.DocEntry=" & DocEntry
            comm1.CommandText = query1
            comm1.Connection = conexionSQL
            DA1.SelectCommand = comm1
            DA1.Fill(DS1)

            If DS1.Tables(0).Rows.Count > 0 Then

                For x = 0 To DS1.Tables(0).Rows.Count - 1

                    Descripcion = DS1.Tables(0).Rows(x)("Descripcion").ToString()
                    Marca = DS1.Tables(0).Rows(x)("Marca").ToString()
                    Serie = DS1.Tables(0).Rows(x)("Serie").ToString()
                    Modelo = DS1.Tables(0).Rows(x)("Modelo").ToString()
                    NombreEmpleado = DS1.Tables(0).Rows(x)("Nombre").ToString()
                    Comentarios = DS1.Tables(0).Rows(x)("Comentarios").ToString()

                    skip = skip + 20

                    If skip > 720 Then
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
                        skip = 30
                    End If

                    cb.SetFontAndSize(fuente, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Descripcion: ", 25, PageSize.LETTER.Height - skip, 0)
                    cb.SetFontAndSize(fuenteInfo, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Descripcion, 90, PageSize.LETTER.Height - skip, 0)

                    skip = skip + 10
                    cb.SetFontAndSize(fuente, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marca: ", 25, PageSize.LETTER.Height - skip, 0)
                    cb.SetFontAndSize(fuenteInfo, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Marca, 60, PageSize.LETTER.Height - skip, 0)

                    skip = skip + 10
                    cb.SetFontAndSize(fuente, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Serie: ", 25, PageSize.LETTER.Height - skip, 0)
                    cb.SetFontAndSize(fuenteInfo, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Serie, 55, PageSize.LETTER.Height - skip, 0)

                    skip = skip + 10
                    cb.SetFontAndSize(fuente, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Modelo: ", 25, PageSize.LETTER.Height - skip, 0)
                    cb.SetFontAndSize(fuenteInfo, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Modelo, 65, PageSize.LETTER.Height - skip, 0)

                    skip = skip + 10
                    cb.SetFontAndSize(fuente, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Nombre: ", 25, PageSize.LETTER.Height - skip, 0)
                    cb.SetFontAndSize(fuenteInfo, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, NombreEmpleado, 70, PageSize.LETTER.Height - skip, 0)

                    skip = skip + 10
                    cb.SetFontAndSize(fuente, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Comentarios: ", 25, PageSize.LETTER.Height - skip, 0)
                    cb.SetFontAndSize(fuenteInfo, 10)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Comentarios, 95, PageSize.LETTER.Height - skip, 0)

                Next

            End If

            skip = 720
            cb.SetFontAndSize(fuente, 10)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "_____________________________", 55, PageSize.LETTER.Height - skip, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "_____________________________", 350, PageSize.LETTER.Height - skip, 0)
            skip = skip + 15
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Nombre y Firma", 100, PageSize.LETTER.Height - skip, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Nombre y Firma", 390, PageSize.LETTER.Height - skip, 0)
            skip = skip + 15
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Sistemas)", 110, PageSize.LETTER.Height - skip, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Encargado Área)", 390, PageSize.LETTER.Height - skip, 0)


            'Fin del flujo de bytes.
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            Dim p As New Process
            p.StartInfo.FileName = PDF
            p.StartInfo.Verb = "Open"
            p.Start()

            Return NombreArchivo

        Catch ex As Exception

            'Si hubo una excepcion y el archivo existe …
            If File.Exists(NombreArchivo) Then
                'Cerramos el documento si esta abierto.
                'Y asi desbloqueamos el archivo para su eliminacion.
                If oDoc.IsOpen Then oDoc.Close()
                '… lo eliminamos de disco.
                File.Delete(NombreArchivo)
            End If

            MsgBox("Error al crear el pdf, PDF. " & ex.Message)

        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try

    End Function

End Class