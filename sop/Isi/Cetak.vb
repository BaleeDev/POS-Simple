Public Class Cetak
    Sub Fakt()
        CrystalReportViewer1.SelectionFormula = "Totext ({tb_transaksi_dtl.pembeli}) = '" & Transaksi.tcostumer.Text & "' and Totext ({tb_transaksi_dtl.no_nota}) = '" & Transaksi.lnota.Text & "' "
        CrystalReportViewer1.ReportSource = "Faktur.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub
    Private Sub Cetak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Fakt()
    End Sub
End Class