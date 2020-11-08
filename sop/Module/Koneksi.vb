Imports MySql.Data.MySqlClient
Module Koneksi
    Public objkoneksi As MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet


    Sub Konek()
        Try
            Dim str As String = "Server = localhost ;user= root;password =; database = db_tokoE"
            objkoneksi = New MySqlConnection(str)
            If objkoneksi.State = ConnectionState.Closed Then
                objkoneksi.Open()
                'MsgBox("Koneksi ke data base berhasil", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
End Module
