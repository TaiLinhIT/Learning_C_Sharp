namespace Hello_Asp
{
    // bước 1: Tạo IHostBuilder
    // bước 2: Cấu hình, đăng ký các dịch vụ
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start App");
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            //cấu hình mặc định cho host tạo ra
            builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>
            {
                //Tùy biến thêm về host vào trong đây
                webBuilder.UseStartup<MyStartUp>();
            });
            IHost host = builder.Build();
            host.Run();
        }

    }
}
