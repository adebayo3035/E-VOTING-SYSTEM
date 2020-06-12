Imports System.Data.OleDb
Public Class ACCREDITATION
    'DECLARE CMD and connection string to Database
    Dim CMD As OleDbCommand = Nothing
    Dim connectionstring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        homepage.MenuStrip1.Refresh()
        'check if controls are fully filled
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter  Your Staff ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If
       
        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter  Your Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        If Len(Trim(ComboBox1.Text)) = 0 Then
            MessageBox.Show("Please Select Login Type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        If (TextBox1.MaxLength < 5) Then
            MessageBox.Show("Your Matric Number is Incomplete, Please Complete It", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim cn As New OleDb.OleDbConnection
        cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; " & " Data Source=" & Application.StartupPath & "\Voting System.mdb"
        cn.Open()
        Dim myMS As New IO.MemoryStream

        Dim arrImage() As Byte
        'Authenticate User Login to Check if User is an Electoral Officer or a Voter

        If (ComboBox1.SelectedItem = "ELECTORAL OFFICER") Then
            menu1()
            homepage.MenuStrip1.Refresh()
            Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [electoral_officer]  WHERE [matric]='" & TextBox1.Text & "' AND [password]= '" & TextBox2.Text & "' ", cn)
            Dim dt As New DataTable
            da.Fill(dt)

            'DISPLAY ELECTORAL OFFICER INFORMATION ON HOMEPAGE
            If dt.Rows.Count > 0 Then
                GroupBox1.Text = "Electoral Officer Information"
                homepage.Label9.Text = "Electoral Officer"
                homepage.Label6.Text = dt.Rows(0).Item("matric") & ""
                homepage.Label4.Text = dt.Rows(0).Item("firstname") & ""
                homepage.Label7.Text = dt.Rows(0).Item("level") & ""
                homepage.Label13.Text = dt.Rows(0).Item("lastname") & ""

                'DISPLAY USER PICTURE ON HOMEPAGE
                If Not IsDBNull(dt.Rows(0).Item("photo")) Then
                    arrImage = dt.Rows(0).Item("photo")
                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next
                    '
                    homepage.PictureBox1.Image = System.Drawing.Image.FromStream(myMS)
                End If

                MessageBox.Show("Dear Electoral Officer, Login Successful. Welcome to Computer Science E-voting System ")

                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.SelectedIndex = -1
                ComboBox1.Enabled = True
                CheckBox1.Checked = False

                Me.Hide()
                homepage.Show()


            Else
                MsgBox("Login .....Failed Please Enter Correct Username and Password")
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.SelectedIndex = -1
                ComboBox1.Enabled = True
                homepage.GroupBox1.Text = "Electoral Officer Information"
            End If
            'VOTER LOGIN, AUTHENTICATE VOTER'S USERNAME AND PASSWORD
        ElseIf (ComboBox1.SelectedItem = "VOTERS") Then
            menu2()
            'CHECK IF STUDENT HAS ALREADY VOTED, FROM DATABASE
            'TABLE FOR STUDENT THAT ARE YET TO VOTE
            Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [voters]  WHERE [matric]='" & TextBox1.Text & "' AND [password]= '" & TextBox2.Text & "' ", cn)
            Dim dt As New DataTable
            da.Fill(dt)
            'TABLE FOR ALL REGISTERED STUDENT
            Dim da1 As New OleDb.OleDbDataAdapter("SELECT * FROM [Users]  WHERE [matric]='" & TextBox1.Text & "' AND [password]= '" & TextBox2.Text & "' ", cn)
            Dim dt1 As New DataTable
            da1.Fill(dt1)
            If (dt.Rows.Count <= 0 And dt1.Rows.Count > 0) Then
                MsgBox("This Account has already Voted. Please No multiple Votes", MsgBoxStyle.Exclamation)
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.SelectedIndex = -1
                ComboBox1.Enabled = True

            ElseIf (dt.Rows.Count > 0 And dt1.Rows.Count > 0) Then

                homepage.Label9.Text = "VOTERS"
                homepage.Label6.Text = dt.Rows(0).Item("matric") & ""
                homepage.Label4.Text = dt.Rows(0).Item("firstname") & ""
                homepage.Label7.Text = dt.Rows(0).Item("my_level") & ""
                homepage.Label13.Text = dt.Rows(0).Item("lastname") & ""
                VOTE_PREVIEW.TextBox1.Text = dt.Rows(0).Item("matric") & ""
                'homepage.Label11.Text = dt.Rows(0).Item("ID") & ""
                If Not IsDBNull(dt.Rows(0).Item("photo")) Then
                    arrImage = dt.Rows(0).Item("photo")
                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next
                    '
                    homepage.PictureBox1.Image = System.Drawing.Image.FromStream(myMS)

                End If
                MessageBox.Show("Login Successful. Welcome to Computer Science E-voting System ")

                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.SelectedIndex = -1
                ComboBox1.Enabled = True

                homepage.GroupBox1.Text = "Voter's Information"
                Me.Hide()
                homepage.Show()

            ElseIf (dt.Rows.Count <= 0 And dt1.Rows.Count <= 0) Then
                MsgBox("Invalid Account, Please Check your Username and Password", MsgBoxStyle.Exclamation)
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.SelectedIndex = -1
                ComboBox1.Enabled = True
                'Else
                'MsgBox("Login .....Failed Please Enter Correct Username and Password")
                'TextBox1.Text = ""
                'TextBox2.Text = ""
                'ComboBox1.SelectedIndex = -1
                'ComboBox1.Enabled = True
            End If
        End If


        cn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox1.Enabled = True
        CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "•"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please Select Your Login Type")
        Else
            ComboBox1.Enabled = False
        End If
    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.SelectedItem = Nothing
        Me.Show()
    End Sub
    Sub menu1()
        If ComboBox1.SelectedItem = "ELECTORAL OFFICER" Then
            homepage.MenuStrip1.Location = New Point(0, 0)
            homepage.MenuStrip1.Show()
            homepage.MenuStrip2.Hide()
            homepage.Label12.Hide()
            homepage.Label11.Hide()
        End If
    End Sub
    Sub menu2()
        If ComboBox1.SelectedItem = "VOTERS" Then
            homepage.MenuStrip2.Location = New Point(0, 0)
            homepage.Label12.Location = New Point(1023, 9)
            homepage.Label11.Location = New Point(1023, 50)
            homepage.MenuStrip1.Hide()
            homepage.MenuStrip2.Show()
            homepage.Label1.Hide()
            homepage.Label2.Hide()

        End If

    End Sub
    
    Private Sub ACCREDITATION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class