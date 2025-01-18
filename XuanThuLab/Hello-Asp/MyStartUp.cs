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
            //StaticFileMiddleware
            // wwwroot
            app.UseStaticFiles();


            // EndpointRoutingMiddleware
            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapGet("/", async (context) =>
                {
                    //npm(node.js)
                    string html = "Trang chu";
                    await context.Response.WriteAsync(html);
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/about", async (context) =>
                {
                    await context.Response.WriteAsync("Trang giới thiệu");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/contact", async (context) =>
                {
                    await context.Response.WriteAsync("Trang liên hệ");
                });
            });

            
            // Terminate Middleware
            app.Map("/abc", app1 =>
            {
                app1.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Nội dung tra về từ ABC");
                });
            });


            //statusCodePages
            app.UseStatusCodePages();


        }
    }
}
