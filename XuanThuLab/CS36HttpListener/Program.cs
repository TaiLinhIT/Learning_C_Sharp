using System.Net;
using System.Text;

namespace CS36HttpListener
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using (var server = new HttpListener())
            {
                
                

                server.Prefixes.Add("http://localhost:8080/");

                server.Start();
                Console.WriteLine("Http start");
                do
                {
                    var context = await server.GetContextAsync();
                    Console.WriteLine("Client connection!");
                    var response = context.Response;

                    var outputStream = response.OutputStream;
                    response.Headers.Add("content-type", "text/html");
                    var html = "<h1>Hello World!</h1>";
                    var bytes = Encoding.UTF8.GetBytes(html);
                    await outputStream.WriteAsync(bytes, 0, bytes.Length);
                    outputStream.Close();

                } while (server.IsListening);
                Console.ReadLine();
            }
            

        }
    }
}
