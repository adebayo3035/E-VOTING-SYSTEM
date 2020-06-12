Imports System.Data.OleDb
Imports System.IO
Imports System.Data.SqlClient
Public Class VOTING_STATISTICS

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.FullWindow)
        Catch ex As Exception
            MsgBox("Unsuccessful!, Pls connect the printer and try again")

        End Try
        homepage.Show()
        Me.Hide()
    End Sub
    Sub REG_VOTERS()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label22.Text = (dr(0).ToString())
        End While
    End Sub
    Sub TURN_OUT()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [Status] ='" & "VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label23.Text = (dr(0).ToString())
        End While
    End Sub
    Sub ABSTENTION()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [Status] ='" & "NOT VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label24.Text = (dr(0).ToString())
        End While
    End Sub
    Sub turnout_percent()
        'get percentage of turnout'
        'using (turnout/register_voters)*100'
        Dim x = ((Val(Label23.Text)) / (Val(Label22.Text)) * 100)
        'converting integer to string
        Dim y = x.ToString()
        Label25.Text = y + "%"
    End Sub
    Sub abstention_percent()
        'get percentage of turnout'
        'using (turnout/register_voters)*100'
        Dim x = ((Val(Label24.Text)) / (Val(Label22.Text)) * 100)
        'converting integer to string
        Dim y = x.ToString()
        Label26.Text = y + "%"
    End Sub
    Sub REG_100()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "100" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label27.Text = (dr(0).ToString())
        End While
    End Sub
    Sub TURNOUT_100()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "100" & "' and [Status] ='" & "VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label28.Text = (dr(0).ToString())
        End While
    End Sub
    Sub ABSTENTION_100()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "100" & "' and [Status] ='" & "NOT VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label29.Text = (dr(0).ToString())
        End While
    End Sub
    Sub REG_200()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "200" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label30.Text = (dr(0).ToString())
        End While
    End Sub
    Sub TURNOUT_200()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "200" & "' and [Status] ='" & "VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label31.Text = (dr(0).ToString())
        End While
    End Sub
    Sub ABSTENTION_200()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "200" & "' and [Status] ='" & "NOT VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label32.Text = (dr(0).ToString())
        End While
    End Sub
    Sub REG_300()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "300" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label33.Text = (dr(0).ToString())
        End While
    End Sub
    Sub TURNOUT_300()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "300" & "' and [Status] ='" & "VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label34.Text = (dr(0).ToString())
        End While
    End Sub
    Sub ABSTENTION_300()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "300" & "' and [Status] ='" & "NOT VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label35.Text = (dr(0).ToString())
        End While
    End Sub
    Sub REG_400()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "400" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label36.Text = (dr(0).ToString())
        End While
    End Sub
    Sub TURNOUT_400()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "400" & "' and [Status] ='" & "VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label37.Text = (dr(0).ToString())
        End While
    End Sub
    Sub ABSTENTION_400()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM Users WHERE [my_level] ='" & "400" & "' and [Status] ='" & "NOT VOTED" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label38.Text = (dr(0).ToString())
        End While
    End Sub
    Private Sub VOTING_STATISTICS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call REG_VOTERS()
        TURN_OUT()
        ABSTENTION()
        turnout_percent()
        abstention_percent()

        REG_100()
        TURNOUT_100()
        ABSTENTION_100()

        REG_200()
        TURNOUT_200()
        ABSTENTION_200()

        REG_300()
        TURNOUT_300()
        ABSTENTION_300()

        REG_400()
        TURNOUT_400()
        ABSTENTION_400()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        homepage.Show()
        Me.Hide()
    End Sub
End Class