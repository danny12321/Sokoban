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

        public void Play()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101);
            Console.WriteLine(randomNumber);

            if (IsSleeping)
            {
                if (randomNumber <= 10) IsSleeping = false;
            }
            else
            {
                if (randomNumber <= 25) IsSleeping = true;
            }


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
