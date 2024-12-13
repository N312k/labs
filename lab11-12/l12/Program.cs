using Lab11;
using System.Diagnostics;
namespace Lab12
{
    public class PriorityQueue : IComparable<PriorityQueue> 
    {
        int priorities { get; set; } 
        int aplicationNumber { get; set; } 
        int step { get; set; } 

        public PriorityQueue(int priorities, int aplicationNumber, int step)
        {
            this.priorities = priorities;
            this.aplicationNumber = aplicationNumber;
            this.step = step;
        }

        public int CompareTo(PriorityQueue other)
        {
            return priorities.CompareTo(other.priorities);
        }

        static void Main(string[] args)
        {
            string path = "D:/log.txt";
            MyPriorityQueue<PriorityQueue> order = new MyPriorityQueue<PriorityQueue>();
            Console.Write("Напишите количество шагов для добавления заявок: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine($"ADD/REMOVE   НомерЗаявки      Приоритет      НомерШага \n");
            for (int i = 0; i < n; i++)
            {
                Random random = new Random();
                int number = random.Next(1, 11);
               
                for (int j = 0; j < number; j++)
                {
                    int priorities = random.Next(1, 6);
                    PriorityQueue list1 = new PriorityQueue(priorities, j, i);
                    order.Add(list1);
                    sw.WriteLine($"ADD: \t\t {list1.priorities}\t\t {list1.aplicationNumber}\t\t {list1.step} ");
                    count++;
                }
                PriorityQueue list2 = order.Poll();
                sw.WriteLine($"REMOVE:  \t {list2.priorities} \t\t {list2.aplicationNumber} \t\t {list2.step} ");
                count--;
            }

            for (int i = 0; i < count; i++)
            {
                PriorityQueue list3 = order.Peek(); 
                sw.WriteLine($"REMOVE:  \t {list3.priorities} \t\t {list3.aplicationNumber} \t\t {list3.step} ");
                order.Remove(order.Peek());
            }

            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            sw.WriteLine($"\nВремя выполнения: {time.TotalSeconds} секунд");
            sw.Close();
        }
    }
}