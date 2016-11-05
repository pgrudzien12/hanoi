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
    public class Hanoi
    {
        Stake _left;
        Stake _center;
        Stake _right;
        private readonly int _biggestRing;

        public Hanoi(int biggestRing)
        {
            _biggestRing = biggestRing;
            _left = new Stake(biggestRing);
            _center = new Stake(0);
            _right = new Stake(0);
        }

        public void Solve()
        {
            _left.Move(_left.Biggest, _right, _center);
        }

        public bool IsSolved()
        {
            return _left.Count == 0 && _center.Count == 0 && _right.Biggest.Size == _biggestRing && _right.Validate();
        }
    }
}
