using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
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
