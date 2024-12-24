using System.Text;

namespace CS19VirtualMethodAbstractInterface
{
    #region Override và Abstract
    public abstract class Product
    {
        protected double Price { get; set; }
        public abstract void ProductInfo();
        public void Test() => ProductInfo();
    }
    public class Iphone : Product
    {
        public Iphone() => Price = 500;
        //override - nạp chồng phương thức
        //public override void ProductInfo()
        //{
        //    Console.WriteLine("Điện thoại Iphone");
        //    base.ProductInfo();
        //}
        public override void ProductInfo()
        {
            Console.WriteLine("Điện thoại Iphone");
            Console.WriteLine("Giá của điện thoại là " + Price);
        }
    }

    #endregion
    #region Interface
    interface IHinhHoc
    {
        public double ChuVi();
        public double DienTich();
    }
    public class HinhChuNhat : IHinhHoc
    {
        public HinhChuNhat(double _a, double _b)
        {
            a = _a;
            b = _b;
        }
        public double a { get; set; }
        public double b { get; set; }
        public double ChuVi()
        {
            return (a + b) * 2;
        }

        public double DienTich()
        {
            return a * b;
        }
    }
    public class HinhTron : IHinhHoc
    {
        public HinhTron(double _r)
        {
            r = _r;
        }
        public double r { get; set; }
        public double ChuVi()
        {
            return 2 * r * Math.PI;
        }

        public double DienTich()
        {
            return r * r * Math.PI;
        }
    }
    #endregion
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Iphone iphone = new Iphone();
            iphone.Test();
            //iphone.Test();

            IHinhHoc hinhChuNhat = new HinhChuNhat(4,5);
            Console.WriteLine(hinhChuNhat.DienTich());
            Console.WriteLine(hinhChuNhat.ChuVi());
            IHinhHoc hinhtron = new HinhTron(1);
            Console.WriteLine(hinhtron.DienTich());
            Console.WriteLine(hinhtron.ChuVi());
            
        }
    }
}
