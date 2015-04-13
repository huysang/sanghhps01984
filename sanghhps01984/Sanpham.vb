Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class Sanpham
    Dim data As New DataTable
    Dim dulieu As String = "workstation id=sanghhps01984.mssql.somee.com;packet size=4096;user id=sanghhps01984_SQLLogin_1;pwd=mk6eelme8k;data source=sanghhps01984.mssql.somee.com;persist security info=False;initial catalog=sanghhps01984"
    Private Sub loadthongtin()
        Dim xem As New SqlConnection(dulieu)
        Dim load As New SqlDataAdapter("select * From SanPham", xem)
        Try
            xem.Open()
            load.Fill(data)
        Catch ex As Exception
        End Try
        data1.DataSource = data
        xem.Close()
    End Sub
    Private Sub Xem_Click(sender As Object, e As EventArgs) Handles Xem.Click
        Dim xem As New SqlConnection(dulieu)
        Dim load As New SqlDataAdapter("select * From SanPham", xem)
        Try
            xem.Open()
            load.Fill(data)
        Catch ex As Exception
        End Try
        data1.DataSource = data
        xem.Close()
    End Sub


    Private Sub btnthem_Click(sender As Object, e As EventArgs) Handles btnthem.Click
        Dim xem As New SqlConnection(dulieu)
        Dim them As New SqlDataAdapter("insert into SanPham values ('" & txtmasp.Text & "','" & txtmaloai.Text & "','" & txttensp.Text & "','" & txtchitiet.Text & "')", xem)
        Try
            xem.Open()
            them.Fill(data)
        Catch ex As Exception
            MessageBox.Show("Thêm dữ liệu thành công")
        End Try
        data1.DataSource = data
        xem.Close()
    End Sub
    Private Sub DT1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles data1.CellContentClick
        Dim dulieu As Integer = data1.CurrentCell.RowIndex
        txtmasp.Text = data1.Item(0, dulieu).Value
        txtmaloai.Text = data1.Item(1, dulieu).Value
        txttensp.Text = data1.Item(2, dulieu).Value
        txtchitiet.Text = data1.Item(3, dulieu).Value
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub Del_Click(sender As Object, e As EventArgs) Handles Del.Click
        Dim xoa As New SqlConnection(dulieu)
        xoa.Open()
        Dim del As String = "Delete from SanPham where MaSP=@MaSP"
        Dim com As New SqlCommand(del, xoa)
        Try
            com.Parameters.AddWithValue("MaSP", txtmasp.Text)
            com.ExecuteNonQuery()
            xoa.Close()

        Catch ex As Exception
            MessageBox.Show("Xóa dữ liệu thành công")
        End Try
        data.Clear()
        data1.DataSource = data
        data1.DataSource = Nothing
        loadthongtin()
    End Sub

    Private Sub btnsua_Click(sender As Object, e As EventArgs) Handles btnsua.Click
        Dim sua As New SqlConnection(dulieu)
        sua.Open()
        Dim change As String = "Update SanPham set MaSP=@MaSP, TenSP=@TenSP, ChiTietSP=@ChiTietSP, MaLoai=@MaLoai where MaSP=@MaSP"
        Dim com As New SqlCommand(change, sua)
        Try
            com.Parameters.AddWithValue("@MaSP", txtmasp.Text)
            com.Parameters.AddWithValue("@TenSP", txttensp.Text)
            com.Parameters.AddWithValue("@ChiTietSP", txtchitiet.Text)
            com.Parameters.AddWithValue("@MaLoai", txtmaloai.Text)
            com.ExecuteNonQuery()
            sua.Close()

        Catch ex As Exception
            MessageBox.Show("Dữ liệu đã được thay đổi")
        End Try
        data.Clear()
        data1.DataSource = data
        data1.DataSource = Nothing
        loadthongtin()
    End Sub
End Class