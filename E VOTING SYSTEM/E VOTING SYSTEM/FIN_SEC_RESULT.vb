Imports System.Data.OleDb
Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class FIN_SEC_RESULT
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
    Sub FAROUQ()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM fin_sec WHERE [candidate_name] ='" & Label1.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label8.Text = (dr(0).ToString())
        End While
        If Val(Label8.Text) > Val(Label7.Text) Then
            Label5.Visible = True
        End If
    End Sub
    Sub BAYONLE()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM fin_sec WHERE [candidate_name] ='" & Label2.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label7.Text = (dr(0).ToString())
        End While
        If Val(Label7.Text) > Val(Label8.Text) Then
            Label6.Visible = True
        End If
    End Sub
    Sub NO_VOTES()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM fin_sec WHERE [candidate_name] ='" & "NO CANDIDATE" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label4.Text = (dr(0).ToString())
            If Val(Label8.Text) = Val(Label7.Text) Then
                Label12.Visible = True
            End If
        End While
    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        homepage.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.FullWindow)
        Catch ex As Exception
            MsgBox("Unsuccessful!, Pls connect the printer and try again")

        End Try
        homepage.Show()
        Me.Hide()
    End Sub

    

    Private Sub FIN_SEC_RESULT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call farouq()
        Call BAYONLE()
        Call NO_VOTES()
        Label19.Text = homepage.Label4.Text
        Label21.Text = homepage.Label13.Text
        Label23.Text = homepage.Label6.Text
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        homepage.Show()
        Me.Hide()
    End Sub

    
End Class