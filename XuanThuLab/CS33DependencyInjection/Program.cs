using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;

namespace CS33DependencyInjection
{
    //Dependency - phụ thuộc

    interface IClassC
    {
        public void ActionC();
    }
    interface IClassB
    {
        public void ActionB(); 
    }
    class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }

    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }
    class Horn
    {
        public void Beep() => Console.WriteLine("Beep - Beep - Beep");
    }
    class Car
    {
        //injection bằng phương thức khởi tạo
        Horn horn { get; set; }
        public Car(Horn _horn)
        {
            horn = _horn;
        }
        public void Beep()
        {
            Horn horn = new Horn();
            horn.Beep();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            //IClassC objectC = new ClassC();
            //IClassB objectB = new ClassB(objectC);
            //ClassA  objectA  = new ClassA(objectB);
            //objectA.ActionA();

            //IClassC objectC = new ClassC1();            // new ClassC();
            //IClassB objectB = new ClassB1(objectC);     // new ClassB();
            //ClassA objectA = new ClassA(objectB);
            //objectA.ActionA();

            //Việc Horn là phụ thuộc của lớp Car(dependency). Lớp car muốn thực hiện được cần phải truyền vào Horn. Nhưng nếu truyền bằng cách
            //tạo mới đối tượng thì khi thay đổi lớp horn thì sẽ làm code của car thay đổi. Chính vì vậy chúng ta nên truyền bằng một cách lỏng lẻo hơn.
            //chúng ta sẽ tiêm vào(injection)

            //chúng ta sẽ sử dụng các thư viện Dependency Injection

            Horn horn = new Horn();
            Car car = new Car(horn);
            car.Beep();


            //DI Container
            //đăng ký các dịch vụ dependency vào
            //Thực hiện get<> các dịch vụ ấy ra
            // Nó sẽ tự tạo ra các dependency nếu nó chưa được khởi tạo và injection.

            // đầu tiên chúng ta sẽ gọi DI Container - ServiceCollection
            // chúng ta sẽ đăng kí các Dependency vào ServiceCollection
            // bên trong ServiceCollection sẽ có đối tưởng ServiceProvider sẽ cho phép lấy ra những dependency đăng ký trong ServiceCollection bằng get service

            //Tạo đối tượng serviceCollection
            var services = new ServiceCollection();


            //đăng ký các dịch vụ
            //đăng ký kiểu singleton
            //services.AddSingleton<IClassC,ClassC>();
            //kiểu SingleTon sẽ khởi tạo Dependency nếu nó chưa có.Và sử dụng duy nhất một đối tượng đến hết vòng đời
            //services.AddTransient<IClassC, ClassC>();
            //kiểu Transient mỗi lần gọi sẽ khởi tạo ra một đối tượng mới
            //kiểu Scoped
            services.AddScoped<IClassC, ClassC>();
            //kiểu Scoped mỗi lần gọi sẽ khởi tạo một đối tượng mới tồn tại trong một khối lệnh using tồn tại trong Scoped của nó. Trong Scoped khác thì lại khởi tạo cái mới
            //Nhưng trong phạm vi của 1 scoped thì chỉ khởi tạo một lần duy nhất



            ////lấy ra các dịch vụ đã đăng ký
            //var provider = services.BuildServiceProvider();

            //for (int i = 0; i < 5; i++)
            //{
            //    IClassC c = provider.GetService<IClassC>();
            //    Console.WriteLine(c.GetHashCode());
            //}


            //using(var scoped = provider.CreateScope())
            //{
            //    var provider1 = scoped.ServiceProvider;
            //    for (int i = 0; i < 5; i++)
            //    {
            //        IClassC c = provider1.GetService<IClassC>();
            //        Console.WriteLine(c.GetHashCode());
            //    }
            //}

            services.AddSingleton<ClassA,ClassA>();
            services.AddSingleton<IClassB,ClassB>();
            services.AddSingleton<IClassC,ClassC>();


            var provider = services.BuildServiceProvider();

            ClassA a = provider.GetService<ClassA>();
            a.ActionA();
            Console.ReadLine();
        }
    }
}
