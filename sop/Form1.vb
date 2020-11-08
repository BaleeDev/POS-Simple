Imports MySql.Data.MySqlClient
Public Class Form1

    Sub tampil()
        Try
            da = New MySqlDataAdapter("select*from tb_transaksi_dtl WHERE tgl='" & Dashboard.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "'  order by id_transaksi desc", objkoneksi)
            ds = New DataSet
            da.Fill(ds, "tb_barang")
            DataGridView2.DataSource = (ds.Tables("tb_barang"))
            Call RapikanGrid(DataGridView2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub HitungStok()
        Dim hitung As Integer
        For baris As Integer = 0 To DataGridView2.RowCount - 1
            hitung = hitung + DataGridView2.Rows(baris).Cells(7).Value
        Next
        TextBox1.Text = hitung
    End Sub
    Sub hitungqty()
        Dim hitung As Integer
        For baris As Integer = 0 To DataGridView2.RowCount - 1
            hitung = hitung + DataGridView2.Rows(baris).Cells(6).Value
        Next
        TextBox2.Text = hitung
    End Sub
    Sub hitungbarang()
        TextBox3.Text = DataGridView2.RowCount - 1
    End Sub
    Sub RapikanGrid(ByVal grid As DataGridView)
        grid.Columns(0).HeaderText = "ID TRANSAKSI"
        grid.Columns(0).Width = 200
        grid.Columns(1).HeaderText = "NO NOTA"
        grid.Columns(1).Width = 200
        grid.Columns(2).HeaderText = "ID"
        grid.Columns(2).Width = 200
        grid.Columns(3).HeaderText = "Pembeli"
        grid.Columns(3).Width = 200
        grid.Columns(4).HeaderText = "NAMA"
        grid.Columns(4).Width = 200
        grid.Columns(5).HeaderText = "HARGA"
        grid.Columns(5).Width = 200
        grid.Columns(6).HeaderText = "QTY"
        grid.Columns(6).Width = 200
        grid.Columns(7).HeaderText = "TOTAL HARGA"
        grid.Columns(7).Width = 200
        grid.Columns(8).HeaderText = "TGL"
        grid.Columns(8).Width = 200
        grid.Columns(9).HeaderText = "KEMBALIAN"
        grid.Columns(9).Width = 200
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu.Click
        pnlIsi.Visible = True
        pnlIsi.Controls.Clear()
        Call tampil()
        Call HitungStok()
        Call hitungbarang()
        Call hitungqty()
        Dashboard.CrystalReportViewer1.ReportSource = "Grafik1.rpt"
        Dashboard.CrystalReportViewer1.RefreshReport()
        Dashboard.lhari.Text = TextBox1.Text
        Dashboard.Label8.Text = TextBox3.Text
        Dashboard.lpenjualan.Text = TextBox2.Text
        Dashboard.TopLevel = False
        pnlIsi.Controls.Add(Dashboard)
        Dashboard.Show()
        pnlMenu.Visible = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        pnlMenu.Visible = True
        pnlMenu.BringToFront()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pnlIsi.Visible = True
        pnlIsi.Controls.Clear()
        Barang.TopLevel = False
        pnlIsi.Controls.Add(Barang)
        Barang.Show()
        pnlMenu.Visible = False
    End Sub

    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi.Konek()
        pnlMenu.Visible = False
        Call tampil()
        Call HitungStok()
        Call hitungbarang()
        Call hitungqty()
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        DataGridView2.Visible = False
        Dashboard.lhari.Text = TextBox1.Text
        Dashboard.Label8.Text = TextBox3.Text
        Dashboard.lpenjualan.Text = TextBox2.Text
        Dashboard.TopLevel = False
        pnlIsi.Controls.Add(Dashboard)
        Dashboard.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pnlIsi.Visible = True
        pnlIsi.Controls.Clear()
        Transaksi.TopLevel = False
        pnlIsi.Controls.Add(Transaksi)
        Transaksi.Show()
        pnlMenu.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        pnlIsi.Visible = True
        pnlIsi.Controls.Clear()
        Laporan.TopLevel = False
        pnlIsi.Controls.Add(Laporan)
        Laporan.Show()
        pnlMenu.Visible = False
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click
        pnlMenu.Visible = False
    End Sub
End Class
