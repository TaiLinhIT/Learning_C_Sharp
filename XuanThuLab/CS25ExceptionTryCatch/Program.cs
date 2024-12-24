using MyException;
using System.Text;

namespace CS25ExceptionTryCatch
{
    internal class Program
    {
        #region Phát sinh exception
        static void Register(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                
                throw new NameEmplyException();
            }
            if (age < 18 || age > 100)
            {
                throw new AgeException(age);
            }
            Console.WriteLine($"Xin chào {name} - {age}");
        }
        #endregion

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            #region Bắt ngoại lệ
            //int a = 5;
            //int b = 0;
            //try
            //{
            //    var c = a / b; // phát sinh lỗi exception, hoặc là kế thừa của exception
            //    Console.WriteLine(c);
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine(e.Message);

            //    Console.WriteLine("Không được chia cho 0");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //    Console.WriteLine(e.GetType().Name);
            //}
            #endregion
            #region Nhận ngoại lệ
            try
            {
                Register("Linh", 10);

            }
            catch (NameEmplyException nee)
            {
                Console.WriteLine(nee.Message);
            }
            catch (AgeException aet)
            {
                Console.WriteLine(aet.Message);
                aet.Detail();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            #endregion
        }
    }
}
