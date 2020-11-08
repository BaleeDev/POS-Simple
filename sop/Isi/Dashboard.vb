Public Class Dashboard


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.ReportSource = "Grafik1.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Dashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Form1.pnlMenu.Visible = False
    End Sub
End Class