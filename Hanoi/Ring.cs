using System;
using System.Diagnostics;

namespace Hanoi
{
    public struct Ring
    {
        public Ring(int size)
        {
            if (size == 0)
                throw new Exception($"Cannot create ring of size {size}");
            this.Size = size;
        }

        public int Size { get; private set; }

        public override int GetHashCode()
        {
            return Size.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Size.Equals(obj);
        }

        public static bool operator ==(Ring x, Ring y)
        {
            return x.Size == y.Size;
        }

        public static bool operator !=(Ring x, Ring y)
        {
            return !(x == y);
        }

        public static bool operator >(Ring x, Ring y)
        {
            return x.Size > y.Size;
        }

        public static bool operator <(Ring x, Ring y)
        {
            return x.Size < y.Size;
        }

        public Ring Smaller()
        {
            return new Ring(Size - 1);
        }

        public override string ToString()
        {
            return "Ring " + Size;
        }
    }
}