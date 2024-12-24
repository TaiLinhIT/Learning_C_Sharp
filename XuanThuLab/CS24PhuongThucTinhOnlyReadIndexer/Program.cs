namespace CS24PhuongThucTinhOnlyReadIndexer
{
    class CountNumber
    {
        public static int Number = 0;
        public static void Info()
        {
            Console.WriteLine("Số lần truy cập là: " +  Number);
        }
        public void Count()
        {
            Number++;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CountNumber n1 = new CountNumber();
            CountNumber n2 = new CountNumber();
            n1.Count();
            //n2.Count();
            CountNumber.Info();
        }
    }
}
