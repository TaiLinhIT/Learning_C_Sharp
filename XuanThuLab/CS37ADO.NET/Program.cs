using Microsoft.Data.SqlClient;
using System.Data.Common;


namespace CS37ADO.NET
{
    public class Program
    {
        //Ado.net là tập hợp các thư viện lớp qua đó cho phép tương tác đến nguồn cơ sở dữ liệu
        //Data provider là các thư viện lớp cung cấp kết nối đến dữ liệu nguồn. Và cung cấp các lệnh như(insert, update, delete, read)
        //Loại Data provider mặc định của .NET Core là SqlClient trong namespace system.data.sqlclient cung cấp khả năng kết nối đến Sql Server
        //Nếu muốn Data provider cung cấp đến MySql thì cài thêm package MySql.Data
        //Nếu muốn Data provider cung cấp đến SqlLite thì cài thêm package Microsoft.Data.SQLite
        //Data Set là các thư viện lớp độc lập với Data provider. Tạo ra các đối tượng quản lý dữ liệu không phụ thuộc là nguồn dữ liệu đến từ đâu,
        //Trong Data Set thì gồm nhiều Data Table. Trong Data Table thì gồm nhiều Data Column và các ràng buộc kết nối. Nói chung Data Set là sự trừu tượng của CSDL thực

        static void Main(string[] args)
        {
            var SqlconnectionStringBuilder = new SqlConnectionStringBuilder();
            SqlconnectionStringBuilder["Server"] = "SYSSANG\\SQLEXPRESS";
            SqlconnectionStringBuilder["Database"] = "master";
            SqlconnectionStringBuilder["Integrated Security"] = true;
            SqlconnectionStringBuilder["Trust Server Certificate"] = true;
            var SqlStringConnection = SqlconnectionStringBuilder.ToString();

            //string ConnectionString = "Data Source=SYSSANG\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True";

            using var sqlCollection = new SqlConnection(SqlStringConnection);
            sqlCollection.Open();
            


            //thực hiện truy vấn
            //Để thực hiện truy vấn dữ liệu thì ta sử dụng Data Command
            using DbCommand datacommand = new SqlCommand();
            datacommand.Connection = sqlCollection;
            #region Sử dụng ExcuteReader sử dụng khi có dữ liệu là nhiều dòng

            #region Cách 1
            //datacommand.CommandText = "select top (5) * from SanPham";// thực hiện trực tiếp câu lệnh sql vào đây
            //var datareader = datacommand.ExecuteReader();//thực hiện câu lệnh

            //while (datareader.Read())//ở đây phương thức Read sẽ trả về là true hoặc false. Nếu là true thì là có dữ liệu sẽ lưu trong datareader
            //{
            //    Console.WriteLine($"Tên của sản phầm {datareader["TenSanPham"],10}, giá sản phầm {datareader["Gia"],8}");
            //}

            #endregion
            #region Cách 2
            //datacommand.CommandText = "SELECT DanhmucID, TenDanhMuc, MoTa FROM Danhmuc where DanhmucID > @DanhmucID";
            ////var danhMucId = new SqlParameter("@DanhmucID", 5);
            ////datacommand.Parameters.Add(danhMucId);

            //var parameter = datacommand.CreateParameter();
            //parameter.ParameterName = "@DanhmucID";
            //parameter.Value = 5;

            //using var sqlreader = datacommand.ExecuteReader();
            //if (sqlreader.HasRows)
            //{
            //    while (sqlreader.Read())
            //    {
            //        var Ten = sqlreader["TenDanhMuc"];
            //        var MoTa = sqlreader["MoTa"];
            //        Console.WriteLine($"Tên là: {Ten}, Mô tả: {MoTa}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Không tìm thấy dữ liệu");
            //}

            #endregion
            #endregion
            #region ExcuteScalar trả về 1 giá trị (dong 1, cột 1)
            datacommand.CommandText = "SELECT count(*) FROM Danhmuc where DanhmucID > @DanhmucID";
            

            var parameter = datacommand.CreateParameter();
            parameter.ParameterName = "@DanhmucID";
            parameter.Value = 5;

            var result = datacommand.ExecuteScalar();
            Console.WriteLine(result);
            #endregion
            #region ExecuteNonQuery() sử dụng cho insert, update, delete
            

            #endregion
            sqlCollection.Close();
            Console.ReadLine();
        }
    }
}
