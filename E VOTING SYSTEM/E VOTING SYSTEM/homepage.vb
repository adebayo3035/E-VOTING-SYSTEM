Imports System.Data.OleDb
Public Class homepage
    Dim CMD As OleDbCommand = Nothing
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Now.Date.ToLongDateString
        Label2.Text = TimeOfDay.ToString("h : mm : ss : tt")
        Label11.Text = Now.Date.ToLongDateString
        Label12.Text = TimeOfDay.ToString("h : mm : ss : tt")
    End Sub

    Private Sub RESULTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MsgBox("You have to cast your vote and allow application to stop automatically", MsgBoxStyle.Exclamation)
        Me.Show()
    End Sub

    Private Sub HOMEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOMEToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub VOTERREGISTRATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOTERREGISTRATIONToolStripMenuItem.Click
        VOTERS_REG.Show()
        Me.Hide()
    End Sub

    Private Sub VOTESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOTESToolStripMenuItem.Click
        CANDIDATE_REG.Show()
        Me.Hide()
    End Sub

    Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        Me.MenuStrip1.Refresh()
        If Label9.Text = "Electoral Officer" Then
            ACCREDITATION.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
            ACCREDITATION.Show()
            Me.Hide()
        Else
            ACCREDITATION.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub CALCULATORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CALCULATORToolStripMenuItem.Click
        Process.Start("calc.exe")
    End Sub

    Private Sub NOTEPADToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOTEPADToolStripMenuItem.Click
        Process.Start("notepad.exe")
    End Sub

    Private Sub ADDNEWADMINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDNEWADMINToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            ADMIN_REG.Show()
            Me.Hide()
        Else
            MsgBox("You are not Eligible to View this Page.Please Contact Head of Electoral Officer", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub PRESIDENCYRESULTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRESIDENCYRESULTToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            PRESIDENT_RESULT.Show()
            Me.Hide()
        Else
            MsgBox("You are not Eligible to View this Page.Please Contact Head of Electoral Officer", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub REMOVEADMINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REMOVEADMINToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            Dim ans As String
            ans = MsgBox("Are you Sure You Want to Delete An Account", vbYesNo)

            If ans = vbYes Then


                Dim phonen
                phonen = InputBox("Enter The Electoral Officer Matric Number", "Matriculation Number", "")
                If phonen = " " Then
                    MsgBox("You Must enter a Valid Matric Number ")
                    Exit Sub
                ElseIf (phonen.length > 6) Or (phonen.length < 6) Then
                    MsgBox("Matric Number cannot be More than 6 digits")
                    Exit Sub
                ElseIf phonen = "" Then
                    Exit Sub
                End If

                Dim cn As New OleDb.OleDbConnection
                cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
                cn.Open()
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = cn
                'cmd.CommandText = ("DELETE FROM electoral_officer WHERE matric=" & phonen)
                cmd.CommandText = ("DELETE FROM electoral_officer WHERE matric='" & phonen & "'")
                cmd.ExecuteNonQuery()
                MessageBox.Show("ADMIN REMOVED FROM ELECTORAL OFFICERS SUCCESSFULLY")
                If phonen = Label6.Text Then
                    ACCREDITATION.Show()
                    Me.Hide()
                End If

                cn.Close()


            End If
        Else
            MessageBox.Show("PLEASE YOU ARE NOT ELIGIBLE TO ACCESS THIS PAGE CONTACT HEAD OF ADMIN")
        End If
    End Sub

    Private Sub GENERALSECRETARYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERALSECRETARYToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            GEN_SEC_RESULT.Show()
            Me.Hide()
        Else
            MsgBox("You are not Eligible to View this Page.Please Contact Head of Electoral Officer", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub FINANCIALSECRETARYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINANCIALSECRETARYToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            FIN_SEC_RESULT.Show()
            Me.Hide()
        Else
            MsgBox("You are not Eligible to View this Page.Please Contact Head of Electoral Officer", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub EDITCANDIDATEINFORMATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITCANDIDATEINFORMATIONToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            CANDIDATE_RECORD.Show()
            Me.Hide()
        Else
            MsgBox("You are not Eligible to View this Page.Please Contact Head of Electoral Officer", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub EDITVOTERSINFORMATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITVOTERSINFORMATIONToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            VOTERS_RECORD.Show()
            Me.Hide()
        Else
            MsgBox("You are not Eligible to View this Page.Please Contact Head of Electoral Officer", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub GENERATEREPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERATEREPORTToolStripMenuItem.Click
        If (Label6.Text = "199800") And (Label9.Text = "Electoral Officer") Then
            ADMIN_RECORD.Show()
            Me.Hide()
        Else
            MsgBox("You are not Eligible to View this Page.Please Contact Head of Electoral Officer", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        Me.MenuStrip2.Refresh()
        If Label9.Text = "VOTERS" Then
            ACCREDITATION.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            ACCREDITATION.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        PRESIDENT_VOTE.Label15.Text = Label6.Text
        GEN_SEC_VOTE.Label15.Text = Label6.Text
        FIN_SEC_VOTE.Label15.Text = Label6.Text
        'VOTE_PREVIEW.TextBox1.Text = matric

        PRESIDENT_VOTE.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.Show()
    End Sub

    Private Sub ELECTIONSTATISTICSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ELECTIONSTATISTICSToolStripMenuItem.Click
        VOTING_STATISTICS.Show()
        Me.Hide()
    End Sub
End Class