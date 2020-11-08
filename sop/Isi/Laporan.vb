Public Class Laporan

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.SelectionFormula = "Totext ({tb_transaksi_dtl.tgl}) = '" & DateTimePicker1.Text & "'"
        CrystalReportViewer1.ReportSource = "Laporan Harian.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CrystalReportViewer1.SelectionFormula = "{tb_transaksi_dtl.tgl} in date ('" & DateTimePicker2.Text & "') to date ('" & DateTimePicker3.Text & "')"
        CrystalReportViewer1.ReportSource = "Laporan Periodik.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CrystalReportViewer1.SelectionFormula = "month ({tb_transaksi_dtl.tgl}) = (" & Month(DateTimePicker4.Text) & ") and year ({tb_transaksi_dtl.tgl}) = (" & Year(DateTimePicker4.Text) & ")"
        CrystalReportViewer1.ReportSource = "Laporan Bulanan.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Laporan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Form1.pnlMenu.Visible = False
    End Sub
End Class