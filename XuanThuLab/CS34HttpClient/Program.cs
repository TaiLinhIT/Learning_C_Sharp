using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

namespace CS34HttpClient
{
    class UriDnsPing
    {
        ////sử dụng uri để xem các thông tin từ địa chỉ url
        //string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
        //var uri = new Uri(url);
        //var uritype = typeof(Uri);
        //uritype.GetProperties().ToList().ForEach(property => {
        //    Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
        //});
        //Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");


        ////sử dụng Dns lấy ra HostName của máy local
        //var hostName = Dns.GetHostName();
        //Console.WriteLine(hostName);

        //var url = "https://www.bootstrapcdn.com/";
        //var uri = new Uri(url);
        //Console.WriteLine(uri.Host);
        //var ipphostentry = Dns.GetHostEntry(uri.Host);
        //Console.WriteLine(ipphostentry.HostName);
        //ipphostentry.AddressList.ToList().ForEach(x => Console.WriteLine(x));

        //để kiểm tra địa chỉ của một sever có phản hồi hay không hay là còn sống hay không thì sử dụng lớp ping
        //var ping = new Ping();
        //var pingReply = ping.Send("google.com.vn");
        //Console.WriteLine(pingReply.Status);
        //if (pingReply.Status == IPStatus.Success)
        //{
        //    Console.WriteLine(pingReply.RoundtripTime);
        //    Console.WriteLine(pingReply.Address);
        //}
    }
    public class Program
    {
        public static void ShowHeaders(HttpResponseHeaders headers)
        {
            Console.WriteLine("Các Header");
            foreach (var header in headers) 
            {
                Console.WriteLine($"{header.Key} -- {header.Value}");
            }
        }
        public static async Task<string> GetWebContent(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage httpResponseMessage = await client.GetAsync(url);

                    ShowHeaders(httpResponseMessage.Headers);
                    string html = await httpResponseMessage.Content.ReadAsStringAsync();
                    return html;

                }
                        
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return "Lỗi";
            }
        }
        static async Task Main(string[] args)
        {
            var url = "https://www.google.com/search?q=xuanthulab";
            var html = await GetWebContent(url);
            Console.WriteLine(html);

        }
    }
}
