using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Shared
{
    public class RandomEx : Random
    {
        private uint _boolBits;

        public RandomEx() : base() { }
        public RandomEx(int seed) : base(seed) { }

        public bool NextBoolean()
        {
            return this.Next(2) == 0;
        }
    }
}
