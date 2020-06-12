Imports System.Data.OleDb
Imports System.IO
Public Class VOTE_PREVIEW

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PRESIDENT_VOTE.GroupBox1.Visible = False
        PRESIDENT_VOTE.ComboBox1.SelectedIndex = -1
        PRESIDENT_VOTE.Button3.Visible = True
        PRESIDENT_VOTE.Button3.Enabled = True
        PRESIDENT_VOTE.Button2.Visible = False
        PRESIDENT_VOTE.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GEN_SEC_VOTE.GroupBox1.Visible = False
        GEN_SEC_VOTE.ComboBox1.SelectedIndex = -1
       
        GEN_SEC_VOTE.Button3.Visible = True
        GEN_SEC_VOTE.Button3.Enabled = True
        GEN_SEC_VOTE.Button2.Visible = False
        GEN_SEC_VOTE.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FIN_SEC_VOTE.GroupBox1.Visible = False
        FIN_SEC_VOTE.ComboBox1.SelectedIndex = -1
        FIN_SEC_VOTE.Button4.Visible = True
        FIN_SEC_VOTE.Button4.Enabled = True
        FIN_SEC_VOTE.Button2.Visible = False
        FIN_SEC_VOTE.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        homepage.MenuStrip1.Refresh()
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = cn
        cmd.CommandText = ("DELETE FROM voters WHERE matric='" & TextBox1.Text & "'")
        cmd.ExecuteNonQuery()
        'MessageBox.Show("DATA DELETED SUCCESSFULLY")

        cn.Close()

        Dim constring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
        Dim myconnection As OleDbConnection = New OleDbConnection(constring)
        Dim RowsAffected As Integer = 0
        'Dim cmd As New OleDb.OleDbCommand
        Dim co As String
        ' Dim myconnection As New OleDb.OleDbConnection
        myconnection.Open()
        co = "update Users set [Status] = '" & "VOTED" & "' where matric= '" & TextBox1.Text & "'"
        cmd = New OleDbCommand(co)
        cmd.Connection = myconnection
        RowsAffected = cmd.ExecuteNonQuery()
        myconnection.Close()
        If RowsAffected > 0 Then
            'MessageBox.Show("You've Successfully Changed your Presidential Aspirant Vote", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MsgBox("Thank you for taking your Time to Vote. Bye!!!", MsgBoxStyle.Information)
            myconnection.Close()
            Call RESET()
            ACCREDITATION.Show()
            Me.Hide()
        End If
       
    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MsgBox("Please Click on the Logout Button and allow System to Close Automatically", MsgBoxStyle.Exclamation)
        Me.Show()
    End Sub
    Sub RESET()
        ACCREDITATION.ComboBox1.SelectedIndex = -1
        ACCREDITATION.ComboBox1.Enabled = True
        PRESIDENT_VOTE.ComboBox1.SelectedIndex = -1
        PRESIDENT_VOTE.Button1.Enabled = True
        PRESIDENT_VOTE.Button2.Enabled = True
        GEN_SEC_VOTE.ComboBox1.SelectedIndex = -1
        GEN_SEC_VOTE.Button1.Enabled = True
        GEN_SEC_VOTE.Button2.Enabled = True
        FIN_SEC_VOTE.ComboBox1.SelectedIndex = -1
        FIN_SEC_VOTE.Button1.Enabled = True
        FIN_SEC_VOTE.Button2.Enabled = True
    End Sub
End Class