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

        
        // Tải từ url, trả về stream để đọc dữ liệu (xem bài về stream)
        public static async Task<byte[]> DownloadDataBytes(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage httpResponseMessage = await client.GetAsync(url);

                    ShowHeaders(httpResponseMessage.Headers);
                    var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                    return bytes;

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
        // Tải từ url, trả về stream để đọc dữ liệu (xem bài về stream)
        public static async Task DownloadDataStream(string url, string filename)
        {
            var httpClient = new HttpClient();
            Console.WriteLine($"Starting connect {url}");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Lấy Stream để đọc content
                using var stream = await response.Content.ReadAsStreamAsync();

                // THỰC HIỆN ĐỌC Content
                int SIZEBUFFER = 500;
                using var streamwrite = File.OpenWrite(filename);  // Mở stream để lưu file
                byte[] buffer = new byte[SIZEBUFFER];               // tạo bộ nhớ đệm lưu dữ liệu khi đọc stream

                bool endread = false;
                do                                                  // thực hiện đọc các byte từ stream và lưu ra streamwrite
                {
                    int numberRead = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                    Console.WriteLine(numberRead);
                    if (numberRead == 0)
                    {
                        endread = true;
                    }
                    else
                    {
                        await streamwrite.WriteAsync(buffer, 0, numberRead);
                    }

                } while (!endread);
                Console.WriteLine("Download success");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        static async Task Main(string[] args)
        {
            #region Đọc dữ liệu
            ////var url = "https://www.google.com/search?q=xuanthulab";
            ////var html = await GetWebContent(url);
            ////Console.WriteLine(html);
            //var url = "https://raw.githubusercontent.com/xuanthulabnet/linux-centos/master/docs/samba1.png";
            //var bytes =  await DownloadDataBytes(url);
            //string fileName = "1.png";
            //using var stream =  new FileStream(fileName,FileMode.Create, FileAccess.Write,FileShare.None);
            //stream.Write(bytes, 0, bytes.Length);

            #endregion

            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");


            // Tạo đối tượng MultipartFormDataContent
            var content = new MultipartFormDataContent();

            // Tạo StreamContent chứa nội dung file upload, sau đó đưa vào content
            Stream fileStream = System.IO.File.OpenRead("Program.cs");
            content.Add(new StreamContent(fileStream), "fileupload", "abc.xyz");

            // Thêm vào MultipartFormDataContent một StringContent
            content.Add(new StringContent("value1"), "key1");
            // Thêm phần tử chứa mạng giá trị (HTML Multi Select)
            content.Add(new StringContent("value2-1"), "key2[]");
            content.Add(new StringContent("value2-2"), "key2[]");


            httpRequestMessage.Content = content;
            var response = await httpClient.SendAsync(httpRequestMessage);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
            Console.ReadLine();
        }
    }
}
