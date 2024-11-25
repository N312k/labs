using MyVector;
using System.Numerics;

namespace Lab7
{
    public class Lab7
    {
        static string Input = "input.txt";
        static string Output = "output.txt";
        static StreamReader sr = new StreamReader(Input);
        static StreamWriter sw = new StreamWriter(Output);

        static MyVector<string> Ip()
        {
            string line = sr.ReadLine();
            if (line == null)  throw new Exception("Empty string"); 

            var result = new MyVector<string>(10);
            while (line != null)
            {
                string[] ipar = line.Split(' ');
                foreach (string ip in ipar)
                {
                    bool ifip = true;
                    string[] helpArray = ip.Split('.').ToArray();
                    int[] ipblock = new int[helpArray.Length];
                    for (int i = 0; i < helpArray.Length; i++)
                        ipblock[i] = Convert.ToInt32(helpArray[i]);
                    foreach (int i in ipblock)
                    {
                        if (i > 255 || i < 0) ifip = false;
                    }
                    if (ifip && ipblock.Length == 4) result.Add(ip);
                }
                line = sr.ReadLine();
            }
            return result;
        }
        static void WriteToFile(MyVector<string> result)
        {
            for (int i = 0; i < result.Size(); i++)
            {
                sw.WriteLine(result.Get(i));
            }
            sw.Close();
        }
        static void Main(string[] args)
        {
            MyVector<string> ip = new MyVector<string>(10);
            ip = Ip();
            WriteToFile(ip);
        }
    }
}