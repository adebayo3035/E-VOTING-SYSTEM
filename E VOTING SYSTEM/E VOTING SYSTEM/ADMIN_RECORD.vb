Imports System.Data.OleDb
Imports System.IO
Public Class ADMIN_RECORD

    Private Sub ADMIN_RECORD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim constring As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & Application.StartupPath & "\Voting System.mdb"
        Dim mycon As OleDbConnection
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim tables As DataTableCollection
        Dim source1 As New BindingSource

        mycon = New OleDbConnection
        mycon.ConnectionString = constring
        ds = New DataSet
        tables = ds.Tables
        da = New OleDbDataAdapter("SELECT  matric,firstname,lastname,phone,password FROM electoral_officer", mycon)
        da.Fill(ds)
        Dim view As New DataView(tables(0))
        source1.DataSource = view
        DataGridView1.DataSource = view

        DataGridView1.Columns(0).HeaderText = "MATRIC NUMBER"
        DataGridView1.Columns(0).Width = "200"
        DataGridView1.Columns(1).HeaderText = "FIRSTNAME"
        DataGridView1.Columns(1).Width = "350"
        DataGridView1.Columns(2).HeaderText = "LASTNAME"
        DataGridView1.Columns(2).Width = "350"
        DataGridView1.Columns(3).HeaderText = "PHONE NUMBER"
        DataGridView1.Columns(3).Width = "200"
        DataGridView1.Columns(4).HeaderText = "PASSWORD"
        DataGridView1.Columns(4).Width = "250"

    End Sub
    Private Sub userpic()
        Try
            ConnDB()
            Dim arrImage() As Byte
            Dim myMS As New IO.MemoryStream
            Dim da As New OleDbDataAdapter(("select * from electoral_officer where matric ='" & Trim(DataGridView1.CurrentRow.Cells(0).Value) & "'"), conn)

            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item("photo")) Then
                    arrImage = dt.Rows(0).Item("photo")
                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next
                    Me.PictureBox2.Image = System.Drawing.Image.FromStream(myMS)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        userpic()
    End Sub
    Private Sub me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        homepage.Show()
    End Sub
End Class