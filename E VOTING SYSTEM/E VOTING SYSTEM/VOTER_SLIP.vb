Public Class VOTER_SLIP

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            PrintForm1.Print()
        Catch ex As Exception
            MsgBox("Unsuccessful!, Pls connect the printer and try again")

        End Try
        Dim ans As String
        ans = MsgBox("Do you want to Register another Student ?", vbYesNo)

        If ans = vbYes Then
            VOTERS_REG.Show()
            Me.Hide()
            Call Reset()
        Else
            homepage.Show()
            Me.Hide()
        End If
    End Sub

    
End Class