using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    public class NameEmplyException : Exception
    {
        public NameEmplyException():base("Tên không được để rỗng")
        {

        }
    }
    public class AgeException : Exception
    {
        public int Age { get; set; }
        public AgeException(int age) : base("Tuổi không phù hợp")
        {
            Age = age;
        }
        public void Detail()
        {
            Console.WriteLine($"Tuổi là {Age}, Không nằm trong khoảng quy định");
        }
    }
}
