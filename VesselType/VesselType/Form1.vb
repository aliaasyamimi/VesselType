'Author: Aliaa Syamimi
'Date Written: ‎8 ‎May, ‎2018
'Description: CTMS Vessel Type
'Last Modification: 15 May, 2018

Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As New MySqlConnection
    Dim result1 As Integer
    Dim alpha As String

    Dim SQLconn As MySqlConnection = New MySqlConnection
    Dim SQLcommand As MySqlCommand
    Dim read As MySqlDataReader

    Dim serverstring As String = "Server=localhost;userid=root;Password=;Database=ctms"

    'Private i As Integer
    'Private j As Integer

    'initiate connection
    Public Sub connect()
        Dim cn As String
        cn = "server=localhost; user ID=root; pwd=; database=ctms"
        SQLconn = New MySqlConnection(cn)
        Try
            SQLconn.Open()
        Catch ex As Exception
            MsgBox("Connection Failed!", MsgBoxStyle.OkOnly, "Error")
        End Try

        SQLconn.Close()

    End Sub

    Private Sub onload()
        SQLconn.ConnectionString = serverstring
        Try
            If SQLconn.State = ConnectionState.Closed Then
                SQLconn.Open()

                Dim str As String = "Data Source=localhost;uid=root;pwd=;database=ctms"
                Dim con As MySqlConnection = New MySqlConnection(str)
                Dim com As String = "Select code, descr, move_per_hr from vestype"
                Dim Adpt As MySqlDataAdapter = New MySqlDataAdapter(com, con)
                Dim ds As DataSet = New DataSet()
                Adpt.Fill(ds, "code, descr, move_per_hr")
                DataGridView1.DataSource = ds.Tables(0)
                DataGridView1.ReadOnly = True
                SQLconn.Close()
            Else
                SQLconn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        DataGridView1.ClearSelection()
        lblTotalRecords.Text = DataGridView1.Rows.Count
        Dim ToolTip1 As New ToolTip
        ToolTip1.SetToolTip(pbSearch, "Search for Code")
        ToolTip1.SetToolTip(pbAdd, "Add a new Vessel type")
        ToolTip1.SetToolTip(PictureBox1, "Sort the records in descending/ascending order")
    End Sub

    Private Sub filldata()

        'filling information in datagridview. this will be called during the on load of the form

        Dim SQLconn As MySqlConnection = New MySqlConnection
        SQLconn.ConnectionString = "Server=localhost;userid=root;Password=;Database=ctms"
        Dim SQLcommand As MySqlCommand
        Dim da As New MySqlDataAdapter
        Dim bs As New BindingSource

        Try
            Dim dbDataset As New DataTable
            SQLconn.Open()
            Dim query As String
            query = "select code, descr, move_per_hr from vestype where code = '" & AddVessel.txtcode.Text & "' and descr = '" & AddVessel.txtdesc.Text & "' and move_per_hr = '" & AddVessel.txtmph.Text & "'"

            With DataGridView1
                SQLcommand = New MySqlCommand(query, SQLconn)
                da.SelectCommand = SQLcommand
                da.Fill(dbDataset)
                bs.DataSource = dbDataset
                .DataSource = bs
                da.Update(dbDataset)

                .EnableHeadersVisualStyles = False

                .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue
                .MultiSelect = False

                .Columns(0).HeaderText = "Code"
                .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(0).Width = 200
                .Columns(0).DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

                .Columns(1).HeaderText = "Description"
                .Columns(1).ToolTipText = "Sort the records in descending/ascending order"
                .Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(1).HeaderCell.SortGlyphDirection = SortOrder.Ascending
                .Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)
                .Columns(1).DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

                .Columns(2).HeaderText = "Move Per Hour"
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(2).Width = 200
                .Columns(2).DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

                .AutoGenerateColumns = False
                Dim btn As New DataGridViewButtonColumn()
                .Columns.Add(btn)
                btn.HeaderText = "Actions"
                btn.Text = "Edit/Delete"
                btn.Name = "btnAction"
                btn.Width = 100
                btn.UseColumnTextForButtonValue = True

                'DataGridView1.AutoResizeColumns()

                .ClearSelection()
            End With

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub search()

        If String.IsNullOrEmpty(txtSearch.Text) Then
            MsgBox("Please insert a Vessel Code to filter search.")
        Else
            Try
                connect()
                conn.Open()

                Using cmd1 As New MySqlCommand
                    With cmd1
                        .Parameters.Clear()
                        .Parameters.Add("@Code", MySqlDbType.VarChar).Value = txtSearch.Text
                        .Connection = conn
                        .CommandText = "SELECT COUNT(*) FROM vestype WHERE code = @Code"

                        result1 = cmd1.ExecuteScalar()

                        lblTotalRecords.Text = result1
                    End With
                End Using

                If result1 <> 0 Then

                    Dim search As String = "SELECT * FROM vestype WHERE code = @Code"

                    Dim comm As MySqlCommand
                    comm = New MySqlCommand(search, conn)
                    comm.Parameters.Add("@Code", MySqlDbType.VarChar).Value = txtSearch.Text

                    Using cmd = New MySqlDataAdapter()

                        cmd.SelectCommand = comm

                        Using ds As New DataSet()
                            DataGridView1.Columns.Clear()
                            cmd.Fill(ds, "code")
                            DataGridView1.DataSource = ds.Tables(0)

                        End Using

                    End Using

                ElseIf result1 = 0 Then

                    MsgBox("No data found", MsgBoxStyle.OkOnly, "Alert!")
                    DataGridView1.DataSource = Nothing
                    DataGridView1.Rows.Clear()
                    DataGridView1.Columns.Clear()

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
        End If
    End Sub

    Private Sub filteronchange()

        Try
            'select query is used to display the list of records from the database to be displayed in the datagridview.
            Dim temp As Double = 0
            Dim lt As String = "select code from vestype"
            Dim da As New MySqlDataAdapter(lt, conn)
            conn.Open()

            Dim ds As New DataSet
            da.Fill(ds, "vestype")
            da.Dispose()

            Dim tables As DataTableCollection = ds.Tables
            Dim source1 As New BindingSource()
            Dim view1 As New DataView(Tables(0))
            source1.DataSource = view1
            DataGridView1.DataSource = view1
            'DataGridView1.DataSource = ds.Tables(0)

            source1.Filter = "code = '" & txtSearch.Text & "'"
            DataGridView1.Refresh()

            filldata()

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbAdd.Click
        Dim add As New AddVessel()

        add.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        'Dim permission As String = Command()
        'If permission = "1" Then
        'MsgBox("CTMS Vessel Type program started")
        filldata()
        onload()
        'Else
        'Me.Visible = False
        'MsgBox("Please log in before you access the application")
        'Me.Close()
        'End If
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            Dim grid = DirectCast(sender, DataGridView)

            If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If grid.Columns(e.ColumnIndex).Name = "btnAction" Then

                    ActionVessel.txtcode.Text = DataGridView1.CurrentRow.Cells(0).Value
                    ActionVessel.txtdesc.Text = DataGridView1.CurrentRow.Cells(1).Value
                    ActionVessel.txtmph.Text = DataGridView1.CurrentRow.Cells(2).Value

                    ActionVessel.ShowDialog()

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pbSearch.Click
        'search()

        Try
            Dim dbDataset As New DataTable
            Dim dv As New DataView(dbDataset)
            dv.RowFilter = String.Format("code like '%{0}%'", txtSearch.Text)
            DataGridView1.DataSource = dv
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'another testing for github connection
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Hide()
        DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
        DataGridView1.Columns(1).HeaderCell.SortGlyphDirection = SortOrder.Ascending
        DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        filteronchange()
    End Sub
End Class
