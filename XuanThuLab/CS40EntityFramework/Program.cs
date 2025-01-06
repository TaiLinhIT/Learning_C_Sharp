using CS40EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CS40EntityFramework
{
    
    public class Program
    {
        public static void CreateTable()
        {
            using var dbcontext = new ProductDbcontext();
            string dbName = dbcontext.Database.GetDbConnection().Database;
            var result = dbcontext.Database.EnsureCreated();
            if (result)
            {
                Console.WriteLine($"Tạo cơ sở dữ liệu {dbName} thành công.");
            }
            else
            {
                Console.WriteLine($"Tạo cơ sở dữ liệu {dbName} không thành công.");
            }
        }
        public static void DropTable()
        {
            using var dbcontext = new ProductDbcontext();
            string dbName = dbcontext.Database.GetDbConnection().Database;
            var result = dbcontext.Database.EnsureDeleted();
            if (result)
            {
                Console.WriteLine($"Xóa cơ sở dữ liệu {dbName} thành công.");
            }
            else
            {
                Console.WriteLine($"Xóa cơ sở dữ liệu {dbName} không thành công.");
            }
        }
        //Thư viện EF Core cung cấp khả năng ánh xạ đến cơ sở dữ liệu 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            CreateTable();
            Console.ReadLine();
        }
    }
}
