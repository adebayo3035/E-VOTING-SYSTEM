Imports System.Data.OleDb
Imports System.IO
Public Class GEN_SEC_VOTE
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

        If ComboBox1.SelectedItem = "EMOKHARE SAMUEL A.K.A ATOM" Then
            Dim ans As String
            ans = MsgBox("You've selected to vote for " & ComboBox1.SelectedItem & " Do you want to Continue? ", vbYesNo)

            If ans = vbYes Then
                Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [candidates]  WHERE [matric]='" & "206324" & "' ", cn)
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

        ElseIf ComboBox1.SelectedItem = "KOLAWOLE OLADELE A.K.A DAM DAM" Then
            Dim ans As String
            ans = MsgBox("You've selected to vote for " & ComboBox1.SelectedItem & " Do you want to Continue? ", vbYesNo)

            If ans = vbYes Then
                Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [candidates]  WHERE [matric]='" & "206325" & "' ", cn)
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "NOT VOTING" Then
            Button1.Text = "PROCEED"
            Label16.Text = "NO CANDIDATE"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cn As New OleDbConnection(connectionstring)
        cn.Open()
        Dim Cmd As New OleDb.OleDbCommand("INSERT INTO gen_sec VALUES('" & Label15.Text & "','" & Label16.Text & "', '" & DateTimePicker1.Value & "')", cn)
        Cmd.ExecuteNonQuery()
        Cmd.Dispose()
        MsgBox("Successfully Voted for " + Label16.Text + " As Nacoss General Sectretary")
        Call Reset()
        Button2.Enabled = False
        FIN_SEC_VOTE.Show()
        Me.Hide()
    End Sub
    Sub Reset()
        ComboBox1.SelectedItem = -1

        GroupBox1.Visible = False
    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MsgBox("You have to cast your vote and allow application to stop automatically", MsgBoxStyle.Exclamation)
        Me.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ComboBox1.SelectedItem = "EMOKHARE SAMUEL A.K.A ATOM" Then
            Dim constring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
            Dim myconnection As OleDbConnection = New OleDbConnection(constring)
            Dim RowsAffected As Integer = 0
            'Dim cmd As New OleDb.OleDbCommand
            Dim co As String
            ' Dim myconnection As New OleDb.OleDbConnection
            myconnection.Open()
            co = "update gen_sec set [candidate_name] = '" & Label16.Text & "' where matric= '" & Label15.Text & "'"
            CMD = New OleDbCommand(co)
            CMD.Connection = myconnection
            RowsAffected = CMD.ExecuteNonQuery()
            myconnection.Close()
            If RowsAffected > 0 Then
                MessageBox.Show("You've Successfully Changed your General Secretary Aspirant Vote", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            myconnection.Close()

        ElseIf ComboBox1.SelectedItem = "KOLAWOLE OLADLE A.K.A DAM DAM" Then
            Dim constring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
            Dim myconnection As OleDbConnection = New OleDbConnection(constring)
            Dim RowsAffected As Integer = 0
            'Dim cmd As New OleDb.OleDbCommand
            Dim co As String
            ' Dim myconnection As New OleDb.OleDbConnection
            myconnection.Open()
            co = "update gen_sec set [candidate_name] = '" & Label16.Text & "' where matric= '" & Label15.Text & "'"
            CMD = New OleDbCommand(co)
            CMD.Connection = myconnection
            RowsAffected = CMD.ExecuteNonQuery()
            myconnection.Close()
            If RowsAffected > 0 Then
                MessageBox.Show("You've Successfully Changed your General Secretary Aspirant Vote", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            co = "update gen_sec set [candidate_name] = '" & Label16.Text & "' where matric= '" & Label15.Text & "'"
            CMD = New OleDbCommand(co)
            CMD.Connection = myconnection
            RowsAffected = CMD.ExecuteNonQuery()
            myconnection.Close()
            If RowsAffected > 0 Then
                MessageBox.Show("You've Successfully Changed your General Secretary Aspirant Vote", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            myconnection.Close()

        End If
        Button3.Enabled = False
        Call GENSECVOTE()
        VOTE_PREVIEW.Show()
        Me.Hide()
    End Sub
    Sub GENSECVOTE()
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()


        Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [gen_sec]  WHERE [matric]='" & Label15.Text & "' ", cn)
        Dim dt As New DataTable
        da.Fill(dt)


        If dt.Rows.Count > 0 Then
            VOTE_PREVIEW.Label2.Text = (dt.Rows(0).Item("candidate_name") & "")
            VOTE_PREVIEW.PictureBox2.Image = Me.PictureBox1.Image
        End If

    End Sub
    'Note there's a button Under the Vote button on the Page, for Upate or Change of Vote
End Class