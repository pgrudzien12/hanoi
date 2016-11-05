using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Hanoi tower = new Hanoi(5);
            tower.Solve();
        }
    }
    public class Hanoi
    {
        Stake _left;
        Stake _center;
        Stake _right;

        public Hanoi(int biggestRing)
        {
            _left = new Stake(biggestRing);
            _center = new Stake(0);
            _right = new Stake(0);
        }

        public void Solve()
        {
            _left.Move(_left.Biggest, _right, _center);
        }
    }
}
