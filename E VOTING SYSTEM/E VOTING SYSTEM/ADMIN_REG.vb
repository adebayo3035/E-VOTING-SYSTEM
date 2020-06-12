Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Public Class ADMIN_REG
    Dim cmd As OleDbCommand = Nothing
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
        chars = "0123456789".ToCharArray()
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

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
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
            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
            cn1.Open()
            Dim da1 As New OleDb.OleDbDataAdapter("SELECT * FROM [candidates]  WHERE [matric]='" & TextBox1.Text & "'", cn1)
            Dim dt1 As New DataTable
            da1.Fill(dt1)

            Dim cn2 As New OleDb.OleDbConnection
            cn2.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
            cn2.Open()
            Dim da2 As New OleDb.OleDbDataAdapter("SELECT * FROM [voters]  WHERE [matric]='" & TextBox1.Text & "'", cn2)
            Dim dt2 As New DataTable
            da2.Fill(dt2)

            If (dt1.Rows.Count > 0) Or (dt2.Rows.Count > 0) Then
                MsgBox("You have Registered as a Candidate or a Voter before so you cannnot become an electoral officer. Thank you", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Call reset()
            Else
                Dim cn As New OleDbConnection(connectionstring)
                cn.Open()

                Dim Cmd As New OleDb.OleDbCommand("INSERT INTO electoral_officer VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "',@d1)", cn)


                Dim ms As New MemoryStream()
                Dim bmpImage As New Bitmap(PictureBox1.Image)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New OleDbParameter("@d1", OleDbType.VarBinary)
                p.Value = data
                Cmd.Parameters.Add(p)
                Cmd.ExecuteNonQuery()
                Cmd.Dispose()
                MsgBox("Electoral Officer Account Created Successfully!. Please Print this slip and keep for accreditation")
                ADMIN_SLIP.Label8.Text = TextBox1.Text
                ADMIN_SLIP.Label7.Text = TextBox2.Text
                ADMIN_SLIP.Label6.Text = TextBox3.Text
                ADMIN_SLIP.Label5.Text = TextBox6.Text
                ADMIN_SLIP.PICTUREBOX1.IMAGE = Me.PictureBox1.Image
                Call reset()
                ADMIN_SLIP.Show()
                Me.Hide()
            End If
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
            TextBox6.Text = ("NIEC" + GetUniqueKey(4))
            Button1.Enabled = False
        End If
    End Sub

    Private Sub ADMIN_REG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call capslock()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call reset()
        ACCREDITATION.Show()
        Me.Hide()
    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        homepage.Show()
    End Sub
End Class