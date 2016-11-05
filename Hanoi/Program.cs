using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Warmup();
            for (int i = 1; i < 25; i++)
            {
                var sw = Stopwatch.StartNew();
                Hanoi tower = new Hanoi(i);
                tower.Solve();
                sw.Stop();
                if (!tower.IsSolved())
                    throw new Exception("Error - tower has not been solved properly !");
                Console.WriteLine($"Solving problem of size {i} took {sw.Elapsed}");
            }
        }

        private static void Warmup()
        {
            Hanoi tower = new Hanoi(20);
            tower.Solve();
        }
    }
}
