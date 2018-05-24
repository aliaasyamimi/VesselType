'Author: Aliaa Syamimi
'Date Written: ‎8 ‎May, ‎2018
'Description: CTMS Vessel Type
'Last Modification: 22 May, 2018



' hello alia
Imports MySql.Data.MySqlClient

Public Class AddVessel

    Dim SQLconn As New MySqlConnection
    Dim SQLcommand As MySqlCommand
    Dim read As MySqlDataReader
    Dim serverstring As String = "Server=localhost;userid=root;Password=;Database=ctms"

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

    'filling in data inside datagridview
    Private Sub filldata()

        SQLconn.ConnectionString = serverstring
        Dim da As New MySqlDataAdapter
        Dim bs As New BindingSource

        Try
            Dim dbDataset As New DataTable
            SQLconn.Open()
            Dim query As String
            query = "select * from vestype where code = '" & txtcode.Text & "' and descr = '" & txtdesc.Text & "' and move_per_hr = '" & txtmph.Text & "'"

            SQLcommand = New MySqlCommand(query, SQLconn)
            da.SelectCommand = SQLcommand
            da.Fill(dbDataset)
            bs.DataSource = dbDataset
            Form1.DataGridView1.DataSource = bs
            da.Update(dbDataset)
            SQLconn.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'refreshing the data saved into datagridview
    Public Sub refreshdata()

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
                Form1.DataGridView1.DataSource = ds.Tables(0)
                Form1.DataGridView1.ReadOnly = True
                SQLconn.Close()
            Else
                SQLconn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Form1.DataGridView1.ClearSelection()
        Form1.lblTotalRecords.Text = Form1.DataGridView1.Rows.Count
    End Sub

    'Function to add the record. this function will be called in the button click when all arguments have passed
    Public Sub Addrecord(ByRef SQLStatement As String)

        Try

            Dim SQLcommand As MySqlCommand = New MySqlCommand

            With SQLcommand
                .CommandText = SQLStatement
                .CommandType = CommandType.Text
                .Connection = SQLconn
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Checking data input and compare it to any existing data in DB
    Public Function Checkdata(ByRef sqlvalid As String) As Boolean

        Dim serverstring As String = "Server=localhost;userid=root;Password=;Database=ctms"
        Dim SQLconn As MySqlConnection = New MySqlConnection
        Dim reader As MySqlDataReader
        Dim SQLcommand As MySqlCommand

        SQLconn.ConnectionString = serverstring

        Try
            If SQLconn.State = ConnectionState.Closed Then
                SQLconn.Open()
                SQLcommand = New MySqlCommand(sqlvalid, SQLconn)
                reader = SQLcommand.ExecuteReader
                Dim count As Integer

                count = 0
                While reader.Read
                    count = count + 1
                End While

                If count = 0 Then
                    Return True

                ElseIf count > 0 Then
                    Return False

                End If
                SQLconn.Close()
            Else
                SQLconn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    'action upon click of the button. this will be inititate in the on-click 
    Public Sub onclickadd()

        Dim query As String = "insert into vestype (code, descr, move_per_hr, upd_user, upd_date, upd_time) VALUES ('" & txtcode.Text & "','" & txtdesc.Text & "','" & txtmph.Text & "','" & lblusername.Text & "','" & lbldate.Text & "','" & lbltime.Text & "')"
        Dim updatemaster As String = "insert into vesmast (ves_type) VALUES ('" & txtcode.Text & "')"
        Dim queryvalid As String = "select * from vestype where code = '" & txtcode.Text & "'"

        Try


            If Checkdata(queryvalid) = True Then
                If String.IsNullOrEmpty(txtcode.Text) Then
                    MsgBox("Please do not leave the Code empty")

                ElseIf String.IsNullOrEmpty(txtdesc.Text) Then
                    MsgBox("Please do not leave the Description empty")

                Else

                    Addrecord(query)
                    Addrecord(updatemaster)

                    MsgBox("Vessel type " & txtcode.Text & " has been added!", MsgBoxStyle.Exclamation, "ADDED VESSEL")

                    txtcode.Clear()
                    txtdesc.Clear()
                    txtmph.Clear()

                    'This is a test

                    Me.Hide()
                End If

            Else

                txtcode.Clear()
                txtdesc.Clear()
                txtmph.Clear()

                MsgBox("Please enter a NEW Vessel Code", MsgBoxStyle.Exclamation, "Existing Vessel Code")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SQLconn.Close()

    End Sub
    '
    'on load of the page
    Private Sub AddVessel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(pbAdd, "Add the Code to record.")

        Dim regDate As Date = Date.Now()
        Dim strDate As String = regDate.ToString("yyyy-MM-dd")
        lbldate.Text = strDate
        lbltime.Text = DateTime.Now.ToString("HH:mm:ss")

    End Sub

    'Check positive value for 'Move per hour' input
    Private Sub txtmph_TextChanged(sender As Object, e As EventArgs) Handles txtmph.TextChanged

        Dim tt As New ToolTip With {.IsBalloon = True}

        For Each ch As Char In txtmph.Text
            If Not Char.IsDigit(ch) Or txtmph.Text = "0" Then
                txtmph.Clear()
                tt.Show("Please Enter Valid Numbers Only", txtmph, New Point(0, -40), 4000)
            End If
        Next
    End Sub

    'Add a new data upon click action
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbAdd.Click

        Try
            connect()
            SQLconn.Open()
            onclickadd()
            filldata()
            refreshdata()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) 

    End Sub
End Class