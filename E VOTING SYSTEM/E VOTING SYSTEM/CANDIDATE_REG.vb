Imports System.Data.OleDb
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class CANDIDATE_REG
    Dim CMD As OleDbCommand = Nothing
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
    Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.SelectedItem = Nothing
        ComboBox2.SelectedItem = Nothing
        ComboBox3.SelectedItem = Nothing
        PictureBox1.Image = PictureBox1.BackgroundImage

    End Sub
    Sub capslock()
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox2.CharacterCasing = CharacterCasing.Upper
        TextBox3.CharacterCasing = CharacterCasing.Upper
        TextBox4.CharacterCasing = CharacterCasing.Upper
        TextBox5.CharacterCasing = CharacterCasing.Upper
        TextBox6.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub textbox1_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("please enter numbers only")
            e.Handled = True
        End If
    End Sub
    Private Sub textbox4_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("please enter numbers only")
            e.Handled = True
        End If

    End Sub
    Private Sub textbox6_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
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
                MessageBox.Show("Please enter  Your Nick Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
                Exit Sub
            End If
            If Len(Trim(TextBox6.Text)) = 0 Then
                MessageBox.Show("Please Enter the Receipt Number of the Form you Purchased.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
                Exit Sub
            End If
            If Len(Trim(TextBox7.Text)) = 0 Then
                MessageBox.Show("Please Click on the Button Below to Generate Your Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
                Exit Sub
            End If
            If Len(Trim(ComboBox1.SelectedItem)) = 0 Then
                MessageBox.Show("Please Select the Post you are vying for.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox1.Focus()
                Exit Sub
            End If
            If Len(Trim(ComboBox2.SelectedItem)) = 0 Then
                MessageBox.Show("Please Select your Gender.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox2.Focus()
                Exit Sub
            End If
            If Len(Trim(ComboBox3.SelectedItem)) = 0 Then
                MessageBox.Show("Please Select your Marital Status.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox3.Focus()
                Exit Sub
            End If
            If (PictureBox1.Image Is Nothing) Then
                MessageBox.Show("Please Upload a recent Passport Photograph.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Button2.Focus()
                Exit Sub
            End If
            If (TextBox4.Text = "200" And ComboBox1.SelectedItem = "PRESIDENT") Then
                MessageBox.Show("200 level Student Cannot Contest for the Post of PRESIDENT.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If (TextBox4.Text = "300" And ComboBox1.SelectedItem = "PRESIDENT") Then
                MessageBox.Show("300 level Student Cannot Contest for the Post of PRESIDENT.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If (TextBox4.Text = "100" And ComboBox1.SelectedItem = "PRESIDENT") Then
                MessageBox.Show("100 level Student Cannot Contest for the Post of PRESIDENT.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If (TextBox4.Text = "100" And ComboBox1.SelectedItem = "GENERAL SECRETARY") Then
                MessageBox.Show("100 level Student Cannot Contest for the Post of GENERAL SECRETARY.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If (TextBox4.Text = "200" And ComboBox1.SelectedItem = "GENERAL SECRETARY") Then
                MessageBox.Show("200 level Student Cannot Contest for the Post of GENERAL SECRETARY.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
            cn1.Open()
            Dim da1 As New OleDb.OleDbDataAdapter("SELECT * FROM [electoral_officer]  WHERE [matric]='" & TextBox1.Text & "'", cn1)
            Dim dt1 As New DataTable
            da1.Fill(dt1)
            If (dt1.Rows.Count > 0) Then
                MsgBox("You have Registered as a Candidate or a Voter before so you cannnot become an electoral officer. Thank you", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Call reset()
            Else
                Dim cn2 As New OleDbConnection(connectionstring)
                cn2.Open()
                Dim Cmd2 As New OleDb.OleDbCommand("INSERT INTO Users VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "', '" & "NOT VOTED" & "',@d1)", cn2)
                Dim ms2 As New MemoryStream()
                Dim bmpImage2 As New Bitmap(PictureBox1.Image)
                bmpImage2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data2 As Byte() = ms2.GetBuffer()
                Dim p2 As New OleDbParameter("@d1", OleDbType.VarBinary)
                p2.Value = data2
                Cmd2.Parameters.Add(p2)
                Cmd2.ExecuteNonQuery()
                Cmd2.Dispose()

                Dim cn3 As New OleDbConnection(connectionstring)
                cn3.Open()
                Dim Cmd3 As New OleDb.OleDbCommand("INSERT INTO voters VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & "NOT VOTED" & "',@d1)", cn3)
                Dim ms3 As New MemoryStream()
                Dim bmpImage3 As New Bitmap(PictureBox1.Image)
                bmpImage3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data3 As Byte() = ms3.GetBuffer()
                Dim p3 As New OleDbParameter("@d1", OleDbType.VarBinary)
                p3.Value = data3
                Cmd3.Parameters.Add(p3)
                Cmd3.ExecuteNonQuery()
                Cmd3.Dispose()

                Dim cn As New OleDbConnection(connectionstring)
                cn.Open()
                Dim Cmd As New OleDb.OleDbCommand("INSERT INTO candidates VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "', '" & ComboBox1.Text & "', '" & ComboBox2.Text & "', '" & ComboBox3.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "',@d1)", cn)
                Dim ms As New MemoryStream()
                Dim bmpImage As New Bitmap(PictureBox1.Image)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New OleDbParameter("@d1", OleDbType.VarBinary)
                p.Value = data
                Cmd.Parameters.Add(p)
                Cmd.ExecuteNonQuery()
                Cmd.Dispose()
                MsgBox("Candidate's Account Created Successfully!. Please Print this slip and keep for accreditation")
                CANDIDATE_SLIP.Label8.Text = TextBox1.Text
                CANDIDATE_SLIP.Label7.Text = TextBox2.Text
                CANDIDATE_SLIP.Label6.Text = TextBox3.Text
                CANDIDATE_SLIP.Label5.Text = TextBox4.Text
                CANDIDATE_SLIP.Label11.Text = ComboBox1.SelectedItem
                CANDIDATE_SLIP.Label13.Text = ComboBox2.SelectedItem
                CANDIDATE_SLIP.Label15.Text = TextBox7.Text
                CANDIDATE_SLIP.PictureBox2.Image = Me.PictureBox1.Image
                CANDIDATE_SLIP.Show()
                Me.Hide()
                Call reset() 
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call reset()
        homepage.Show()
        Me.Hide()
    End Sub

    Private Sub CANDIDATE_REG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call capslock()
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call reset()
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
        ElseIf (TextBox6.Text.Length < 11) Then
            MsgBox("Invalid Phone Number, Please Check and Try Again.", MsgBoxStyle.Exclamation)
            'TextBox1.Clear()
            TextBox6.Focus()
            'Exit Sub
        Else
            TextBox7.Text = ("CSC/VOTE" + GetUniqueKey(4))
            Button1.Enabled = False
        End If
        

    End Sub
End Class