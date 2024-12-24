using MyLibrary;
namespace CS23PhuongThucMoRong
{

    static class ABC
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
    public class Program
    {
        
        static void Main(string[] args)
        {
            "Anh Linh đẹp trai".Print(ConsoleColor.Red);
            double x = 0.5;
            Console.WriteLine(x.BinhPhuong()) ;
            Console.WriteLine(x.Cos()) ;
            Console.WriteLine(x.Sin());
            Console.WriteLine(x.Can()) ;
            
        }
    }
}
