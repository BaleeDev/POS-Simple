Imports MySql.Data.MySqlClient
Public Class Barang
    Dim tg As Integer = 0
    Sub Nomorotomatis()
        Dim kode As String = "BR-" & Format(Now, "yyyyMMddhs")
        tkode.Text = kode
        tnama.Focus()
    End Sub
    Sub hapus()
        tnama.Text = ""
        tharga.Text = ""
        tkode.Text = ""
        Nomorotomatis()
        cmerk.Text = "pilih"
        tg = 0
    End Sub
    Sub insert()
        Try

            If tnama.Text = "" Or tharga.Text = "" Or cmerk.Text = "pilih" Then
                MsgBox("Data Belum Lengkap", MsgBoxStyle.Exclamation)
            Else
                Dim Query As String = "insert into tb_barang values ('" & tkode.Text & "','" & tnama.Text & "','" & tharga.Text & "','" & cmerk.Text & "')"
                cmd = New MySqlCommand(Query, objkoneksi)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil di Simpan", MsgBoxStyle.Information)
                Call hapus()
                Call tampil()

            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub kirim()
        Try
            With DataGridView1
                tkode.Text = .Item(0, .CurrentRow.Index).Value
                tnama.Text = .Item(1, .CurrentRow.Index).Value
                tharga.Text = .Item(2, .CurrentRow.Index).Value
                cmerk.Text = .Item(3, .CurrentRow.Index).Value
                tg = 1
            End With
        Catch ex As Exception

        End Try

    End Sub
    Sub Up()
        Try
            If tkode.Text = "" Or tnama.Text = "" Or tharga.Text = "" Or cmerk.Text = "pilih" Then
                MsgBox("Data Belum Lengkap", MsgBoxStyle.Information)
            Else
                Dim query As String = "update tb_barang set nama ='" & tnama.Text & "', harga='" & tharga.Text & "', merk='" & cmerk.Text & "' Where id='" & tkode.Text & "' "
                cmd = New MySqlCommand(query, objkoneksi)
                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil di update", MsgBoxStyle.Information)
                Call tampil()
                Call hapus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampil()
        Try
            da = New MySqlDataAdapter("select*from tb_barang  order by id desc", objkoneksi)
            ds = New DataSet
            da.Fill(ds, "tb_barang")
            DataGridView1.DataSource = (ds.Tables("tb_barang"))
            Call RapikanGrid(DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub RapikanGrid(ByVal grid As DataGridView)
        grid.Columns(0).HeaderText = "KODE BARANG"
        grid.Columns(0).Width = 280
        grid.Columns(1).HeaderText = "NAMA BARANG"
        grid.Columns(1).Width = 280
        grid.Columns(2).HeaderText = "HARGA BARANG"
        grid.Columns(2).Width = 200
        grid.Columns(3).HeaderText = "MERK BARANG"
        grid.Columns(3).Width = 280
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call tampil()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call tampil()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        If tg = 0 Then
            Call insert()
        ElseIf tg = 1 Then
            Call Up()
        End If
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Call kirim()
    End Sub
    Sub delete()
        Dim id As String
        id = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        Dim Query As String = "delete from tb_barang where id='" & id & "'"
        cmd = New MySqlCommand(Query, objkoneksi)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.Information)
        Call tampil()
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Informasi", MessageBoxButtons.OKCancel)
        If (result = DialogResult.OK) Then
            Call delete()
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Call hapus()
    End Sub

    Sub Cari()
        da = New MySqlDataAdapter("select * from tb_barang where nama ='" & tcari.Text & "' ", objkoneksi)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub tcari_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tcari.KeyPress
        If tcari.Text = "" Then
            Call tampil()
        Else
            Call Cari()
        End If
    End Sub

    Private Sub tharga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tharga.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
    Private Sub Barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Nomorotomatis()
        Call tampil()
    End Sub

    Private Sub Barang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Form1.pnlMenu.Visible = False
    End Sub
End Class