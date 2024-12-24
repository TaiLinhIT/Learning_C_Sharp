using System.Text;

namespace CS20DelegateActionFunc
{
    //delegate là một kiểu dữ liệu nó có thể gán cho một phương thức hoặc nhiều phương thức
    public delegate void ShowLog(string message);

    public class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Wanning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ShowLog log = null;
            log += Info;
            log += Info;
            log += Wanning;
            log("Xin chào");
            log?.Invoke("Xin chào anh Linh");


            //Action - Func : là delegate được viết sẵn theo kiểu generic

            Action action;
            Action<int, string> action2;
            Action<string> action3;
            action3 = Info;
            action3 += Wanning;
            action3?.Invoke("Anh Linh đẹp trai");


            //Func 

            Func<int, string> f1;// tương đương với delegate trả về là string và 1 tham số là int
            Func<string, string> f2;// kiểu dữ liệu cuối cùng là kiểu trả về còn lại đều là tham số

        }
    }
}
