


using System.Runtime.ConstrainedExecution;

namespace ConsoleApp
{
    public struct Complex
    {
        public double x;
        public double y;
        public Complex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString() //
        {
            return x.ToString() + " " + y.ToString() + "i";
        }
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.x + b.x, a.y + b.y);
        }
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.x - b.x, a.y - b.y);
        }
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.x * b.x - b.y * a.y, a.x * b.y + a.y * b.x);
        }
        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex((a.x * b.x + b.y * a.y) / (Math.Pow(b.x, 2) + Math.Pow(a.y, 2)), (a.x * b.y + b.x * a.y) / (Math.Pow(b.x, 2) + Math.Pow(a.y, 2)));
        }
        public double Module()
        {
            return Math.Sqrt((Math.Pow(x, 2)) + (Math.Pow(y, 2)));
        }
        public double Argument()
        {
            if (x > 0) return Math.Atan(y / x);
            if ((x < 0) && (y >= 0)) return Math.PI + Math.Atan(y / x);
            if ((x < 0) && (y < 0)) return -Math.PI + Math.Atan(y / x);
            if ((x == 0) && (y > 0)) return Math.PI / 2;
            if ((x == 0) && (y < 0)) return -Math.PI / 2;
            return 0;
        }
        public double Valid()
        {
            return x;
        }
        public double Imaginary()
        {
            return y;
        }

        static void Main(string[] args)
        {
            string operation;
            do
            {

                Console.WriteLine("Введите первое комплексное число");
                Console.WriteLine();
                Console.WriteLine("Введите действительную часть: ");
                string X01 = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Введите мнимую часть: ");
                string Y01 = Console.ReadLine();
                double x1 = Convert.ToDouble(X01);
                double y1 = Convert.ToDouble(Y01);
                Complex a = new Complex(x1, y1);

                Console.WriteLine("Выберите операцию:");
                operation = Console.ReadLine();


                switch (operation)
                {
                    case "Modul":
                        double Modul = a.Module();
                        Console.WriteLine(Modul);
                        break;
                    case "Arg":
                        double Arg = a.Argument();
                        Console.WriteLine(Arg);
                        break;
                    case "Real":
                        double x = a.Valid();
                        Console.WriteLine(x);
                        break;
                    case "Imaginary":
                        double y = a.Imaginary();
                        Console.WriteLine(y);
                        break;
                    case "Q":
                        Console.WriteLine("Выход из программы");
                        break;
                    case "q":
                        Console.WriteLine("Выход из программы");
                        break;
                    default:
                        Console.WriteLine("Введите второе комплексное число");
                        Console.WriteLine();
                        Console.WriteLine("Введите действительную часть : ");
                        string X02 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Введите мнимую часть: ");
                        Console.WriteLine();
                        string Y02 = Console.ReadLine();
                        double x2 = Convert.ToDouble(X02);
                        double y2 = Convert.ToDouble(Y02);
                        Complex b = new Complex(x2, y2);
                        switch (operation)
                        {
                            case "+":
                                Complex c = a + b;
                                Console.WriteLine(c);
                                break;
                            case "-":
                                Complex d = a - b;
                                Console.WriteLine(d);
                                break;
                            case "*":
                                Complex e = a * b;
                                Console.WriteLine(e);
                                break;
                            case "/":
                                Complex f = a * b;
                                Console.WriteLine(f);
                                break;
                            default:
                                Console.WriteLine("Unknowm command, pls repeat\n");
                                break;
                        }
                        break;
                }
            } while (operation != "Q" && operation != "q");
        }
    }
}