using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Worker : Content
    {
        public bool IsSleeping;
        Square _square;

        public Worker(Square square) : base(square)
        {
            _square = square;
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

        public void Play()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101);

            if (IsSleeping)
            {
                if (randomNumber <= 10)
                {
                    IsSleeping = false;
                }
            }
            else
            {
                if (randomNumber <= 25)
                {
                    IsSleeping = true;
                }
                else
                {
                    Walk();
                }
            }
        }

        private void Walk()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            bool moved = false;

            while (!moved)
            {
                Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
                moved = Move(randomDirection);
            }
        }

        public override bool Move(Direction direction)
        {
            Square squareTo = DirectionToSquare(direction);

            if (squareTo.Content is Player)
            {
                if (!squareTo.Content.Move(direction))
                {
                    return false;
                }
            }

            if (!base.Move(direction))
            {
                return false;
            }

            return true;
        }
    }
}
