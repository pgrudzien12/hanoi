using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hanoi
{
    public class Stake
    {
        List<Ring> _stake = new List<Ring>();

        public Stake(int biggestRing)
        {
            for (int i = biggestRing; i > 0; i--)
            {
                Accept(new Ring(i));
            }
        }

        public Ring Biggest
        {
            get
            {
                return _stake.First();
            }
        }

        public void Move(Ring ringToMove, Stake targetStake, Stake temporaryStake)
        {
            if (CanTake(ringToMove) && targetStake.WouldAccept(ringToMove))
            {
                targetStake.Accept(this);
                return;
            }

            Move(ringToMove.Smaller(), temporaryStake, targetStake);

            targetStake.Accept(this);

            temporaryStake.Move(ringToMove.Smaller(), targetStake, this);
        }

        private void Accept(Stake sourceStake)
        {
            Accept(sourceStake.Take());
        }

        private void Accept(Ring ring)
        {
            if (!WouldAccept(ring))
                throw new Exception("Cannot accept this ring");

            _stake.Add(ring);
        }

        private Ring Take()
        {
            if (_stake.Count == 0)
                throw new Exception("Cannot take ring from empty stake");

            var lastRing = _stake.Last();
            _stake.RemoveAt(_stake.Count-1);
            return lastRing;
        }

        private bool WouldAccept(Ring ringSize)
        {
            if (!_stake.Any())
                return true;
            return _stake.Last() > ringSize;
        }

        private bool CanTake(Ring ring)
        {
            return _stake.LastOrDefault() == ring;
        }

        public override string ToString()
        {
            if (!_stake.Any())
                return string.Empty;
            return _stake.Skip(1).Aggregate(_stake.First().Size.ToString(), (a, r) => a + " " + r.Size);
        }
    }
}