namespace CS29Asynchronous
{
    public class Program
    {
        //Asynchronous - multi thread
        static void DoSomeThing(int seconds, string mess,ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mess,10} -- Start");
                Console.ResetColor();
            }
            lock (Console.Out)
            {
                for (int i = 1; i <= seconds; i++)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mess,10} -- {i,2}");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mess,10} -- end");
                Console.ResetColor();
            }
            
        }
        static async Task Task1()
        {
            Task task1 = new Task(() =>
            {
                DoSomeThing(8, "anh Linh 1", ConsoleColor.DarkBlue);
            });
            task1.Start();
            await task1;
            Console.WriteLine("anh Linh 1 hoàn thành");
        }
        static async Task Task2()
        {
            Task task2 = new Task((object obj) =>
            {
                string tentacvu = (string)obj;
                DoSomeThing(6, tentacvu, ConsoleColor.DarkYellow);
            }, "anh Linh 2");
            task2.Start();
            await task2;
            Console.WriteLine("anh Linh 2 hoàn thành");
            
        }
        static async  Task<string> Task4()
        {
            Task<string> task4 = new Task<string>(
                () =>
                {
                    DoSomeThing(6, "anh Linh 4", ConsoleColor.DarkCyan);
                    return "Return form task 4";
                    
                }
            );
            task4.Start();
            var kq =  await task4;
            return kq;
        }
        static async Task<string> Task5()
        {
            Task<string> task5 = new Task<string>(
                (object obj) =>
                {
                    string t = (string)obj;
                    DoSomeThing(3, $"anh Linh {t}", ConsoleColor.DarkMagenta);
                    return $"Return from task {t}";
                },"5"
            ) ;
            task5.Start();
            var kq = await task5;
            Console.WriteLine("task 5 hoàn thành");
            return kq;
        }
        static async Task Main(string[] args)
        {
           // Task task1 = Task1();
            //Task task2 = Task2();
            Task<string> task4 = Task4();
            Task<string> task5 = Task5();
            DoSomeThing(6, "anh Linh 3",ConsoleColor.White);
            var kq4 = await task4;
            var kq5 = await task5;
            Console.WriteLine(kq4);
            Console.WriteLine(kq5);
            Console.WriteLine("Hello world!");
            Console.ReadLine();
        }
    }
}
