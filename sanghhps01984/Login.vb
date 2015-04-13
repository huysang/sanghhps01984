Imports System.Data.SqlClient
Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim chuoiketnoi As String = "workstation id=sanghhps01984.mssql.somee.com;packet size=4096;user id=sanghhps01984_SQLLogin_1;pwd=mk6eelme8k;data source=sanghhps01984.mssql.somee.com;persist security info=False;initial catalog=sanghhps01984"

        Dim KetNoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim sqlAdapter As New SqlDataAdapter("select * from Nhan_vien where Ma_nhan_vien='" & dangnhap.Text & "' and Password='" & matkhau.Text & "' ", KetNoi)
        Dim tb As New DataTable

        Try
            KetNoi.Open()
            sqlAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                MessageBox.Show("Đăng nhập thành công")
                Main.Show()
                Me.Hide()
            Else
                MessageBox.Show("Sai tài khoản hoặc mật khẩu")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
