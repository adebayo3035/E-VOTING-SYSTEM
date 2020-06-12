Imports System.Data.OleDb
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class VOTERS_REG
    Dim CMD As OleDbCommand = Nothing
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
    Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        PictureBox1.Image = PictureBox1.BackgroundImage
        Button1.Enabled = True
    End Sub
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function
    Sub capslock()
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox2.CharacterCasing = CharacterCasing.Upper
        TextBox3.CharacterCasing = CharacterCasing.Upper
        TextBox4.CharacterCasing = CharacterCasing.Upper
        TextBox5.CharacterCasing = CharacterCasing.Upper
        TextBox6.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub textbox5_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("please enter numbers only")
            e.Handled = True
        End If

    End Sub
    Private Sub textbox1_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("please enter numbers only")
            e.Handled = True
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try

            If Len(Trim(TextBox1.Text)) = 0 Then
                MessageBox.Show("Please enter  Your Matric Number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
                Exit Sub
            End If
            If Len(Trim(TextBox2.Text)) = 0 Then
                MessageBox.Show("Please enter  Your Firstname.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
                Exit Sub
            End If
            If Len(Trim(TextBox3.Text)) = 0 Then
                MessageBox.Show("Please enter  Last Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
                Exit Sub
            End If
            If Len(Trim(TextBox4.Text)) = 0 Then
                MessageBox.Show("Please enter  Your Level.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
                Exit Sub
            End If
            If Len(Trim(TextBox5.Text)) = 0 Then
                MessageBox.Show("Please enter  Your Phone Number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
                Exit Sub
            End If
            If Len(Trim(TextBox6.Text)) = 0 Then
                MessageBox.Show("Please Click Button below to Generate Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
                Exit Sub
            End If

            If (PictureBox1.Image Is Nothing) Then
                MessageBox.Show("Please Upload a recent Passport Photograph.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Button2.Focus()
                Exit Sub
            End If
            Dim cn As New OleDbConnection(connectionstring)
            cn.Open()

            Dim Cmd As New OleDb.OleDbCommand("INSERT INTO voters VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "', '" & "NOT VOTED" & "',@d1)", cn)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New OleDbParameter("@d1", OleDbType.VarBinary)
            p.Value = data
            Cmd.Parameters.Add(p)
            Cmd.ExecuteNonQuery()
            Cmd.Dispose()

            Dim cn2 As New OleDbConnection(connectionstring)
            cn2.Open()

            Dim Cmd2 As New OleDb.OleDbCommand("INSERT INTO Users VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "', '" & "NOT VOTED" & "',@d1)", cn2)
            Dim ms2 As New MemoryStream()
            Dim bmpImage2 As New Bitmap(PictureBox1.Image)
            bmpImage2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data2 As Byte() = ms2.GetBuffer()
            Dim p2 As New OleDbParameter("@d1", OleDbType.VarBinary)
            p2.Value = data2
            Cmd2.Parameters.Add(p2)
            Cmd2.ExecuteNonQuery()
            Cmd2.Dispose()

            MsgBox("Voter's Account Created Successfully!. Please Print this slip and keep for accreditation")
            VOTER_SLIP.Label8.Text = TextBox1.Text
            VOTER_SLIP.Label7.Text = TextBox2.Text
            VOTER_SLIP.Label6.Text = TextBox3.Text
            VOTER_SLIP.Label5.Text = TextBox6.Text
            VOTER_SLIP.PictureBox2.IMAGE = Me.PictureBox1.Image
            Call reset()
            VOTER_SLIP.Show()
            Me.Hide()
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.png;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (TextBox1.Text.Length < 6) Then
            MsgBox("Your Matric Number is Incomplete, Please Check and Try Again.", MsgBoxStyle.Exclamation)
            'TextBox1.Clear()
            TextBox1.Focus()
            'Exit Sub
        ElseIf (TextBox4.Text.Length < 3) Then
            MsgBox("Your Level is Invalid, Please Check and Try Again.", MsgBoxStyle.Exclamation)
            'TextBox1.Clear()
            TextBox4.Focus()
            'Exit Sub
        ElseIf (TextBox5.Text.Length < 11) Then
            MsgBox("Invalid Phone Number, Please Check and Try Again.", MsgBoxStyle.Exclamation)
            'TextBox1.Clear()
            TextBox5.Focus()
            'Exit Sub
        Else

            TextBox6.Text = ("CSC/VOTE" + GetUniqueKey(4))
            Button1.Enabled = False
        End If
    End Sub

    Private Sub VOTERS_REG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call capslock()
    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        homepage.Show()
    End Sub
End Class
