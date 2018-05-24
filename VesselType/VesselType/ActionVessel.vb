'Author: Aliaa Syamimi
'Date Written: ‎8 ‎May, ‎2018
'Description: CTMS Vessel Type
'Last Modification: 22 May, 2018

Imports MySql.Data.MySqlClient

Public Class ActionVessel

    Dim conn As New MySqlConnection
    Dim result As Integer
    Dim result1 As Integer
    Dim inuse As Integer

    'open connection when called
    Public Sub connect()
        Dim cn As String
        cn = "server=localhost; user ID=root; pwd=; database=ctms"
        conn = New MySqlConnection(cn)
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Connection Failed !", MsgBoxStyle.OkOnly, "Error")
        End Try

        conn.Close()

    End Sub

    'filling the data in datagridview after closing this form
    Private Sub filldata()

        Dim SQLconn As MySqlConnection = New MySqlConnection
        SQLconn.ConnectionString = "Server=localhost;userid=root;Password=;Database=ctms"
        Dim SQLcommand As MySqlCommand
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

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'refreshing the data after save and delete
    Private Sub refreshdata()

        Dim SQLconn As MySqlConnection = New MySqlConnection
        Dim serverstring As String = "Server=localhost;userid=root;Password=;Database=ctms"

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

    'action on saving edited data
    Private Sub save()

        If String.IsNullOrEmpty(txtdesc.Text) Then
            MsgBox("Please do not leave the Description empty")

        Else
            Try

                connect()
                conn.Open()

                Dim regDate As Date = Date.Now()
                Dim strDate As String = regDate.ToString("yyyy-MM-dd")

                lbldate.Text = strDate
                lbltime.Text = DateTime.Now.ToString("HH:mm:ss")


                Using cmd1 As New MySqlCommand
                    With cmd1
                        .Parameters.Clear()
                        .Parameters.Add("@Code", MySqlDbType.VarChar).Value = txtcode.Text
                        .Connection = conn
                        .CommandText = "SELECT COUNT(*) FROM vestype WHERE code = @Code"

                        result1 = cmd1.ExecuteNonQuery()
                    End With
                End Using

                If result1 <> 0 Then

                    Using cmd As New MySqlCommand
                        With cmd
                            .Parameters.Clear()
                            .Parameters.Add("@Code", MySqlDbType.VarChar).Value = txtcode.Text
                            .Parameters.Add("@Descr", MySqlDbType.VarChar).Value = txtdesc.Text
                            .Parameters.Add("@MovePH", MySqlDbType.Int32).Value = txtmph.Text
                            .Parameters.Add("@User", MySqlDbType.VarChar).Value = lblusername.Text
                            .Parameters.Add("@Date", MySqlDbType.Date).Value = lbldate.Text
                            .Parameters.Add("@Time", MySqlDbType.VarChar).Value = lbltime.Text

                            .Connection = conn
                            .CommandText = "UPDATE vestype SET descr = @Descr, move_per_hr = @MovePH, upd_user = @User, upd_date = @Date, upd_time = @Time" &
                                    " WHERE code = @Code"

                            result = cmd.ExecuteNonQuery

                            If result = 0 Then

                                MsgBox("Failed to update " & txtcode.Text, MsgBoxStyle.OkOnly, "Alert!")

                            Else

                                MsgBox("Successfully updated " & txtcode.Text, MsgBoxStyle.OkOnly, "Success")

                                Me.Hide()
                                filldata()
                                refreshdata()

                            End If

                        End With

                    End Using

                Else

                    MsgBox("Please select a Vessel to update.", MsgBoxStyle.OkOnly, "Alert!")

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
        End If

    End Sub

    'checking for data existance in DB
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
            Else
                SQLconn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    'action of deleting selected data
    Private Sub delete()

        Try
            connect()
            conn.Open()

            If inuse = 0 Then
                Using cmd1 As New MySqlCommand
                    With cmd1
                        .Parameters.Clear()
                        .Parameters.Add("@Code", MySqlDbType.VarChar).Value = txtcode.Text
                        .Connection = conn
                        .CommandText = "SELECT COUNT(*) FROM vestype WHERE code = @Code"

                        result1 = cmd1.ExecuteScalar()
                    End With
                End Using

                If result1 <> 0 Then

                    Using cmd As New MySqlCommand

                        With cmd
                            .Parameters.Clear()
                            .Parameters.Add("@Code", MySqlDbType.VarChar).Value = txtcode.Text
                            .Connection = conn
                            .CommandText = "DELETE FROM vestype WHERE code = @Code"

                            result = cmd.ExecuteNonQuery

                            If result = 0 Then
                                MsgBox("Failed to delete " & txtcode.Text, MsgBoxStyle.OkOnly, "Alert!")
                            Else
                                MsgBox("Successfully deleted " & txtcode.Text, MsgBoxStyle.OkOnly, "Success")
                                Me.Hide()
                                filldata()
                                refreshdata()
                            End If

                        End With
                    End Using

                Else
                    MsgBox("Record" & txtcode.Text & " does not exists!", MsgBoxStyle.OkOnly, "Alert!")
                End If
            Else
                MsgBox("VESMAST using Code " & txtcode.Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    'checking whether the data that is about to be deleted is still in use or not
    Private Sub checkinuse()

        Dim queryvalid As String = "select ves_type from vesmast where ves_type = @Vestype"

        If Checkdata(queryvalid) = False Then
            inuse = 1
            MsgBox("Code " & txtcode.Text & " is still in use, unable to delete Code.")
        ElseIf Checkdata(queryvalid) = True Then
            inuse = 0
        End If

    End Sub

    'confirming to delete or not. call the delete function if confirm.
    Private Sub confirmdelete()

        Try
            If MsgBox("Do you want to delete " & txtcode.Text & "?", MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then

                'checkinuse()
                delete()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    'confirming to edit data or not. will call edit function after confirm.
    Private Sub confirmedit()

        'Dim SQLconn As MySqlConnection = New MySqlConnection
        'Dim serverstring As String = "Server=localhost;userid=root;Password=;Database=ctms"

        Try
            If MsgBox("Do you want to update " & txtcode.Text & " ?", MsgBoxStyle.YesNo, "SAVE EDITED") = MsgBoxResult.Yes Then

                save()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'onload of the page
    Private Sub ActionVessel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(pbDelete, "Delete the Code from record.")
        ToolTip1.SetToolTip(pbSave, "Save the edited Code to record.")

    End Sub

    'upon click, calling the confirmation method of delete
    Private Sub pbDelete_Click(sender As Object, e As EventArgs) Handles pbDelete.Click

        confirmdelete()

    End Sub

    'upon click, calling the confirmation method of  
    Private Sub pbSave_Click(sender As Object, e As EventArgs) Handles pbSave.Click

        confirmedit()

    End Sub

    'on the textbox, to ensure only numeral input and > 0 will be allowed
    Private Sub txtmph_TextChanged(sender As Object, e As EventArgs) Handles txtmph.TextChanged
        Dim tt As New ToolTip With {.IsBalloon = True}

        For Each ch As Char In txtmph.Text
            If Not Char.IsDigit(ch) Or txtmph.Text = "0" Then
                txtmph.Clear()
                tt.Show("Please Enter Valid Numbers Only", txtmph, New Point(0, -40), 4000)
            End If
        Next
    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub
End Class