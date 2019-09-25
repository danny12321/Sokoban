using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Worker : Moving
    {
        private bool IsSleeping;
        public Worker(Square square) : base(square)
        {

        }

        public override void Show()
        {
            if (IsSleeping)
            {
                Console.Write("z");
            }
            else
            {
                Console.Write("$");
            }
        }
    }
}
