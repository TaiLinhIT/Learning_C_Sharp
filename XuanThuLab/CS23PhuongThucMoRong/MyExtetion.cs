using System;


namespace MyLibrary
{
    static class MyExtetion
    {
        public static double BinhPhuong(this double x) => x * x;
        public static double Can(this double x) => Math.Sqrt(x);
        public static double Sin(this double x) => Math.Sin(x);
        public static double Cos(this double x) => Math.Cos(x);
    }
}
