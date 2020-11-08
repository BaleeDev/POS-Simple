Imports MySql.Data.MySqlClient
Public Class Transaksi

    Dim kur As Integer = 0
    Dim harga, hargab, totharga As Integer
    Dim nama, merk, id, pembeli As String

    Sub tampil()
        Try
            da = New MySqlDataAdapter("select*from tb_barang  order by id desc", objkoneksi)
            ds = New DataSet
            da.Fill(ds, "tb_barang")
            DataGridView2.DataSource = (ds.Tables("tb_barang"))
            Call RapikanGrid(DataGridView2)
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
    Sub Nomorotomatis()
        Dim kode As String = "NO-" & Format(Now, "yyyyMMddhs")
        lnota.Text = kode
        tCari.Focus()
    End Sub
    Sub Cari()
        da = New MySqlDataAdapter("select * from tb_barang where nama ='" & tCari.Text & "' ", objkoneksi)
        ds = New DataSet
        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        DataGridView2.ReadOnly = True
    End Sub
    Sub kirim()
        Try
            With DataGridView2
                id = .Item(0, .CurrentRow.Index).Value
                nama = .Item(1, .CurrentRow.Index).Value
                harga = .Item(2, .CurrentRow.Index).Value
                merk = .Item(3, .CurrentRow.Index).Value
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub tCari_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tCari.KeyPress
        Call Cari()
    End Sub
    Sub simpan_item()

        Try
            Dim hargasmentara As Integer
            hargasmentara = lsub.Text
            If lsub.Text = "SUB TOTAL" Or tQty.Text = "" Then
                MsgBox("Masukkan Jummlah Barang!", MsgBoxStyle.Information)
            Else
                Call transaksi()
                DataGridView1.RowCount = DataGridView1.RowCount + 1
                DataGridView1(0, DataGridView1.RowCount - 2).Value = id
                DataGridView1(1, DataGridView1.RowCount - 2).Value = nama
                DataGridView1(2, DataGridView1.RowCount - 2).Value = harga
                DataGridView1.Columns(2).DefaultCellStyle.Format = "###,###,###"
                DataGridView1(3, DataGridView1.RowCount - 2).Value = tQty.Text
                DataGridView1(4, DataGridView1.RowCount - 2).Value = hargab
                DataGridView1.Columns(4).DefaultCellStyle.Format = "###,###,###"
            End If


        Catch ex As Exception

        End Try

    End Sub
    Sub transaksi()
        If tcostumer.Text = "" Then
            pembeli = "no name"
        Else
            pembeli = tcostumer.Text
        End If
        Dim Query As String = "insert into tb_transaksi values('" & lnota.Text & "','" & id & "','" & pembeli & "','" & nama & "','" & harga & "', '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
        cmd = New MySqlCommand(Query, objkoneksi)
        cmd.ExecuteNonQuery()
        Call Nomorotomatis()
    End Sub
    Sub transaksidtl()
        If tcostumer.Text = "" Then
            pembeli = "no name"
        Else
            pembeli = tcostumer.Text
        End If
        If lgrandtot.Text = "Grand Total" Then
            MsgBox("Belum Ada Transaksi!!", MsgBoxStyle.Information)
        ElseIf tkembalian.Text = "" Then
            MsgBox("Anda Belum melakukan pembayaran!!", MsgBoxStyle.Information)
        Else

            For i As Integer = 0 To DataGridView1.Rows.Count - 2 Step +1
                Dim Query As String = "INSERT INTO `tb_transaksi_dtl` (`no_nota`, `id`, `pembeli`, `nama`, `harga`, `qty`, `total_harga`, `tgl`, `kembalian`, `uang`) VALUES (?,?,?,?,?,?,?,?,?,?); "
                cmd = New MySqlCommand(Query, objkoneksi)
                cmd.Parameters.AddWithValue("@no_nota", lnota.Text)
                cmd.Parameters.AddWithValue("@id", DataGridView1.Rows(i).Cells(0).Value.ToString)
                cmd.Parameters.AddWithValue("@pembeli", pembeli)
                cmd.Parameters.AddWithValue("@nama", DataGridView1.Rows(i).Cells(1).Value.ToString)
                cmd.Parameters.AddWithValue("@harga", DataGridView1.Rows(i).Cells(2).Value.ToString)
                cmd.Parameters.AddWithValue("@qty", DataGridView1.Rows(i).Cells(3).Value.ToString)
                cmd.Parameters.AddWithValue("@total", DataGridView1.Rows(i).Cells(4).Value.ToString)
                cmd.Parameters.AddWithValue("@tgl", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@kem", tkembalian.Text)
                cmd.Parameters.AddWithValue("@uang", tuang.Text)
                cmd.ExecuteNonQuery()
            Next
            MsgBox("Data Berhasil Di simpan!!", MsgBoxStyle.Information)
            If MessageBox.Show("Cetak Nota Transaksi?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Cetak.ShowDialog()
            End If
            Call hapus()
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim a, b As Integer
            a = tQty.Text
            b = harga
            hargab = a * b
            lsub.Text = hargab
            totharga = totharga + hargab
            lgrandtot.Text = totharga
            Call simpan_item()
            tQty.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Call kirim()

    End Sub

    Sub Hitung()
        Try
            Dim kem, a As Integer
            a = tuang.Text
            kem = a - totharga
            tkembalian.Text = kem
        Catch ex As Exception

        End Try
    End Sub


    Private Sub tuang_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tuang.KeyUp
        Call Hitung()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            kur = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If kur = 0 Then
            MsgBox("Pilih Data Yang Mau dibatalkan", MsgBoxStyle.Information)
        Else
            totharga = totharga - kur
            lgrandtot.Text = totharga
            kur = 0
            lsub.Text = "SUB TOTAL"
            If DataGridView1.CurrentRow.Index <> DataGridView1.NewRowIndex Then
                DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
            End If
        End If
    End Sub

    Sub Hapus()
        DataGridView1.Rows.Clear()
        lsub.Text = "SUB TOTAL"
        lgrandtot.Text = "Grand Total"
        Nomorotomatis()
        tuang.Text = ""
        tkembalian.Text = ""
        tharga.Text = ""
        tQty.Text = ""
        tCari.Text = ""
        tcostumer.Text = ""
        kur = 0
        harga = 0
        hargab = 0
        totharga = 0
        nama = ""
        merk = ""
        id = ""
        pembeli = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Hapus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call transaksidtl()
    End Sub

    Private Sub tQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tQty.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tuang_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tuang.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
    Private Sub Transaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi.Konek()
        Call tampil()
        Call Nomorotomatis()
    End Sub

    Private Sub Transaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Form1.pnlMenu.Visible = False
    End Sub
End Class