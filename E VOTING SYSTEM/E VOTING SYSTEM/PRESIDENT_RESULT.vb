Imports System.Data.OleDb
Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class PRESIDENT_RESULT
    'Dim cmd As OleDbCommand = Nothing
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
    Private Sub PRESIDENT_RESULT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DEOLU()
        Call AYODEJI()
        Call ALOLA()
        Call ADEFEMI()
        NO_VOTES()
    End Sub
    Sub DEOLU()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM president WHERE [candidate_name] ='" & Label1.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label8.Text = (dr(0).ToString())
        End While
    End Sub
    Sub AYODEJI()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM president WHERE [candidate_name] ='" & Label2.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label7.Text = (dr(0).ToString())
        End While
    End Sub
    Sub ALOLA()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM president WHERE [candidate_name] ='" & Label3.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label6.Text = (dr(0).ToString())
        End While
    End Sub
    Sub ADEFEMI()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM president WHERE [candidate_name] ='" & Label4.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label5.Text = (dr(0).ToString())
        End While
    End Sub
    Sub NO_VOTES()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM president WHERE [candidate_name] ='" & "NO CANDIDATE" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label13.Text = (dr(0).ToString())
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeFullWindow)
        Catch ex As Exception
            MsgBox("Unsuccessful!, Pls connect the printer and try again")

        End Try
        homepage.Show()
        Me.Hide()
    End Sub

    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        homepage.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        homepage.Show()
        Me.Hide()
    End Sub
End Class