﻿Imports System.Data.OleDb
Imports System.IO
Public Class FIN_SEC_VOTE
    Dim CMD As OleDbCommand = Nothing
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem = "" Then
            MessageBox.Show("Please Select the Candidate you want to Vote for.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()


        Dim myMS As New IO.MemoryStream

        Dim arrImage() As Byte

        If ComboBox1.SelectedItem = "ADEYEMI BAYONLE A.K.A BAYUSKY" Then
            Dim ans As String
            ans = MsgBox("You've selected to vote for " & ComboBox1.SelectedItem & " Do you want to Continue? ", vbYesNo)

            If ans = vbYes Then
                Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [candidates]  WHERE [matric]='" & "206326" & "' ", cn)
                Dim dt As New DataTable
                da.Fill(dt)


                If dt.Rows.Count > 0 Then
                    Me.Label13.Text = dt.Rows(0).Item("firstname") & ""
                    Me.Label12.Text = dt.Rows(0).Item("lastname") & ""
                    Me.Label11.Text = dt.Rows(0).Item("level") & ""
                    Me.Label10.Text = dt.Rows(0).Item("post") & ""
                    Me.Label9.Text = dt.Rows(0).Item("gender") & ""
                    Me.Label8.Text = dt.Rows(0).Item("nickname") & ""
                    Me.Label16.Text = (Me.Label13.Text + " " + Me.Label12.Text)

                    If Not IsDBNull(dt.Rows(0).Item("photo")) Then
                        arrImage = dt.Rows(0).Item("photo")
                        For Each ar1 As Byte In arrImage
                            myMS.WriteByte(ar1)
                        Next
                        '
                        Me.PictureBox1.Image = System.Drawing.Image.FromStream(myMS)

                    End If
                End If

                'MsgBox("Material was found in Store, Now you can Take Material From Store", MsgBoxStyle.Information)
                Me.GroupBox1.Visible = True
            Else
                ComboBox1.SelectedItem = ""
                MsgBox("Please Select your Preferred Candidate and View Profile")
            End If

        ElseIf ComboBox1.SelectedItem = "OSUOLALE FARUQ A.K.A INOSONMONEY" Then
            Dim ans As String
            ans = MsgBox("You've selected to vote for " & ComboBox1.SelectedItem & " Do you want to Continue? ", vbYesNo)

            If ans = vbYes Then
                Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [candidates]  WHERE [matric]='" & "206327" & "' ", cn)
                Dim dt As New DataTable
                da.Fill(dt)


                If dt.Rows.Count > 0 Then
                    Me.Label13.Text = dt.Rows(0).Item("firstname") & ""
                    Me.Label12.Text = dt.Rows(0).Item("lastname") & ""
                    Me.Label11.Text = dt.Rows(0).Item("level") & ""
                    Me.Label10.Text = dt.Rows(0).Item("post") & ""
                    Me.Label9.Text = dt.Rows(0).Item("gender") & ""
                    Me.Label8.Text = dt.Rows(0).Item("nickname") & ""
                    Me.Label16.Text = (Me.Label13.Text + " " + Me.Label12.Text)

                    If Not IsDBNull(dt.Rows(0).Item("photo")) Then
                        arrImage = dt.Rows(0).Item("photo")
                        For Each ar1 As Byte In arrImage
                            myMS.WriteByte(ar1)
                        Next
                        '
                        Me.PictureBox1.Image = System.Drawing.Image.FromStream(myMS)

                    End If
                End If

                'MsgBox("Material was found in Store, Now you can Take Material From Store", MsgBoxStyle.Information)
                Me.GroupBox1.Visible = True
            Else
                ComboBox1.SelectedItem = ""
                MsgBox("Please Select your Preferred Candidate and View Profile")
            End If
        ElseIf ComboBox1.SelectedItem = "NOT VOTING" Then
            Dim ans As String
            ans = MsgBox("You've selected not to Vote for any Candidate. Do you want to Continue? ", vbYesNo)

            If ans = vbYes Then

                Me.Label13.Text = "NIL"
                Me.Label12.Text = "NIL"
                Me.Label11.Text = "NIL"
                Me.Label10.Text = "NIL"
                Me.Label9.Text = "NIL"
                Me.Label8.Text = "NIL"
                Me.PictureBox1.Image = Nothing


                'MsgBox("Material was found in Store, Now you can Take Material From Store", MsgBoxStyle.Information)
                Me.GroupBox1.Visible = True
            Else
                ComboBox1.SelectedItem = ""
                MsgBox("Please Select your Preferred Candidate and View Profile")
            End If

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cn As New OleDbConnection(connectionstring)
        cn.Open()
        Dim Cmd As New OleDb.OleDbCommand("INSERT INTO fin_sec VALUES('" & Label15.Text & "','" & Label16.Text & "', '" & DateTimePicker1.Value & "')", cn)
        Cmd.ExecuteNonQuery()
        Cmd.Dispose()
        MsgBox("Successfully Voted for " + Label16.Text + " As Nacoss Financial Sectretary")
        'Disable User from multiple votes
        Button2.Enabled = False
        'Enabled User to Preview and Edit Votes
        'Button3.Visible = True
        'FIN_SEC_VOTE.Show()
        Call PRESIDENTVOTE()
        Call GENSEC_VOTE()
        Call FINSEC_VOTE()
        VOTE_PREVIEW.Show()
        Me.Hide()

        'Me.Hide()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "NOT VOTING" Then
            Button1.Text = "PROCEED"
            Label16.Text = "NO CANDIDATE"
        End If
    End Sub
    Sub PRESIDENTVOTE()
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()
        Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [president]  WHERE [matric]='" & Label15.Text & "' ", cn)
        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            VOTE_PREVIEW.Label1.Text = (dt.Rows(0).Item("candidate_name") & "")
            VOTE_PREVIEW.PictureBox1.Image = PRESIDENT_VOTE.PictureBox1.Image
        End If

    End Sub
    Sub GENSEC_VOTE()
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()
        Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [gen_sec]  WHERE [matric]='" & Label15.Text & "' ", cn)
        Dim dt As New DataTable
        da.Fill(dt)


        If dt.Rows.Count > 0 Then
            VOTE_PREVIEW.Label2.Text = (dt.Rows(0).Item("candidate_name") & "")
            VOTE_PREVIEW.PictureBox2.Image = GEN_SEC_VOTE.PictureBox1.Image
        End If

    End Sub
    Sub FINSEC_VOTE()
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()
        Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [fin_sec]  WHERE [matric]='" & Label15.Text & "' ", cn)
        Dim dt As New DataTable
        da.Fill(dt)


        If dt.Rows.Count > 0 Then
            VOTE_PREVIEW.Label3.Text = (dt.Rows(0).Item("candidate_name") & "")
            VOTE_PREVIEW.PictureBox3.Image = Me.PictureBox1.Image
        End If

    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MsgBox("You have to cast your vote and allow application to stop automatically", MsgBoxStyle.Exclamation)
        Me.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ComboBox1.SelectedItem = "ADEYEMI BAYONLE A.K.A BAYUSKY" Then
            Dim constring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
            Dim myconnection As OleDbConnection = New OleDbConnection(constring)
            Dim RowsAffected As Integer = 0
            'Dim cmd As New OleDb.OleDbCommand
            Dim co As String
            ' Dim myconnection As New OleDb.OleDbConnection
            myconnection.Open()
            co = "update fin_sec set [candidate_name] = '" & Label16.Text & "' where matric= '" & Label15.Text & "'"
            CMD = New OleDbCommand(co)
            CMD.Connection = myconnection
            RowsAffected = CMD.ExecuteNonQuery()
            myconnection.Close()
            If RowsAffected > 0 Then
                MessageBox.Show("You've Successfully Changed your Financial Secretary Aspirant Vote", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            myconnection.Close()

        ElseIf ComboBox1.SelectedItem = "OSUOLALE FARUQ A.K.A INOSONMONEY" Then
            Dim constring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
            Dim myconnection As OleDbConnection = New OleDbConnection(constring)
            Dim RowsAffected As Integer = 0
            'Dim cmd As New OleDb.OleDbCommand
            Dim co As String
            ' Dim myconnection As New OleDb.OleDbConnection
            myconnection.Open()
            co = "update fin_sec set [candidate_name] = '" & Label16.Text & "' where matric= '" & Label15.Text & "'"
            CMD = New OleDbCommand(co)
            CMD.Connection = myconnection
            RowsAffected = CMD.ExecuteNonQuery()
            myconnection.Close()
            If RowsAffected > 0 Then
                MessageBox.Show("You've Successfully Changed your Financial Secretary Aspirant Vote", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            myconnection.Close()
        ElseIf ComboBox1.SelectedItem = "NOT VOTING" Then

            Dim ans As String
            ans = MsgBox("You've selected not to Vote for any Candidate. Do you want to Continue? ", vbYesNo)

            If ans = vbYes Then

                Me.Label13.Text = "NIL"
                Me.Label12.Text = "NIL"
                Me.Label11.Text = "NIL"
                Me.Label10.Text = "NIL"
                Me.Label9.Text = "NIL"
                Me.Label8.Text = "NIL"
                Me.PictureBox1.Image = PictureBox1.BackgroundImage


                'MsgBox("Material was found in Store, Now you can Take Material From Store", MsgBoxStyle.Information)
                Me.GroupBox1.Visible = True
            Else
                ComboBox1.SelectedItem = ""
                MsgBox("Please Select your Preferred Candidate and Vote")
            End If

            Dim constring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
            Dim myconnection As OleDbConnection = New OleDbConnection(constring)
            Dim RowsAffected As Integer = 0
            'Dim cmd As New OleDb.OleDbCommand
            Dim co As String
            ' Dim myconnection As New OleDb.OleDbConnection
            myconnection.Open()
            co = "update fin_sec set [candidate_name] = '" & Label16.Text & "' where matric= '" & Label15.Text & "'"
            CMD = New OleDbCommand(co)
            CMD.Connection = myconnection
            RowsAffected = CMD.ExecuteNonQuery()
            myconnection.Close()
            If RowsAffected > 0 Then
                MessageBox.Show("You've Successfully Changed your General Secretary Aspirant Vote", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            myconnection.Close()

        End If
        Button4.Enabled = False
        Call FINSECVOTE()
        VOTE_PREVIEW.Show()
        Me.Hide()
    End Sub
    Sub FINSECVOTE()
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()


        Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [fin_sec]  WHERE [matric]='" & Label15.Text & "' ", cn)
        Dim dt As New DataTable
        da.Fill(dt)


        If dt.Rows.Count > 0 Then
            VOTE_PREVIEW.Label3.Text = (dt.Rows(0).Item("candidate_name") & "")
            VOTE_PREVIEW.PictureBox3.Image = Me.PictureBox1.Image
        End If

    End Sub
    'Note there's a button Under the Vote button on the Page, for Upate or Change of Vote
End Class