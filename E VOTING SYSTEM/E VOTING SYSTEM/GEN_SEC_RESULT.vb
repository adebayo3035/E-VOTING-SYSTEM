Imports System.Data.OleDb
Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class GEN_SEC_RESULT
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
    Sub SAMUEL()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM gen_sec WHERE [candidate_name] ='" & Label1.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label8.Text = (dr(0).ToString())
        End While
        If Val(Label8.Text) > Val(Label7.Text) Then
            Label6.Visible = True
        End If
    End Sub
    Sub DAMILARE()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM gen_sec WHERE [candidate_name] ='" & Label2.Text & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label7.Text = (dr(0).ToString())
        End While
        If Val(Label7.Text) > Val(Label8.Text) Then
            Label5.Visible = True
        End If
    End Sub
    Sub NO_VOTES()
        ConnDB()
        Dim sql As String = "select COUNT (*) FROM gen_sec WHERE [candidate_name] ='" & "NO CANDIDATE" & "'"
        Dim cmd As New OleDbCommand(sql, conn)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Label4.Text = (dr(0).ToString())
        End While
        If Val((Label7.Text) = Val(Label8.Text)) Then
            Label12.Visible = True
        End If
    End Sub

    Private Sub GEN_SEC_RESULT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DAMILARE()
        Call SAMUEL()
        Call NO_VOTES()
        Label19.Text = homepage.Label4.Text
        Label21.Text = homepage.Label13.Text
        Label23.Text = homepage.Label6.Text
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
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        homepage.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub

    Private Sub Label23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub
End Class