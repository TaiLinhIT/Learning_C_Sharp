namespace Hello_Asp
{
    public class MyStartUp
    {
        public void ConfigureServices(IServiceCollection services) 
        {
        }
        // Xây dựng pipeline (chuỗi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            // Terminate Middleware
            app.Run();
        }
    }
}
