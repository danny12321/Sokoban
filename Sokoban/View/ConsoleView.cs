using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    public class ConsoleView
    {
        private PlayingField _playingField;

        public PlayingField PlayingField
        {
            get { return _playingField; }
            set { _playingField = value; }
        }

        public ConsoleView()
        {
            Console.WriteLine("Welcome to Sokoban!");
            Console.WriteLine("Push the crates to the destinations with the truck \n");

            Console.WriteLine("Symbols:");
            Console.WriteLine("#: Wall");
            Console.WriteLine(".: Floor");
            Console.WriteLine("o: Chest");
            Console.WriteLine("O: Chest at destination");
            Console.WriteLine("x: Destination");
            Console.WriteLine("@: Truck");

            Console.WriteLine();
        }

        public string ChooseLevel()
        {
            Console.WriteLine("Choose a level (1 - 6)");
            var value = Console.ReadLine();

            return value;
        }


        public void Render()
        {
            Console.Clear();
            var vertical = _playingField.Squares[0];

            while (vertical != null)
            {

                var horizontal = vertical;

                while (horizontal != null)
                {
                    if (horizontal.Content != null)
                    {
                        ShowContent(horizontal.Content);
                    }
                    else
                    {
                        ShowSquare(horizontal);
                    }
                    horizontal = horizontal.Right;
                }

                Console.WriteLine();
                vertical = vertical.Bottom;
            }
        }

        private void ShowContent(Content content)
        {
            if (content is Chest)
            {
                Console.Write("o");
            }
            else if (content is Player)
            {
                Console.Write("@");
            }
            else if (content is Worker)
            {
                if (((Worker)content).IsSleeping)
                {
                    Console.Write("z");
                }
                else
                {
                    Console.Write("$");
                }
            }
        }

        private void ShowSquare(Square square)
        {
            if (square is Wall)
            {
                Console.Write("█");
            }
            else if (square is Floor)
            {
                Console.Write(".");
            }
            else if (square is Destination)
            {
                Console.Write("x");
            }
            else if (square is Pitfall)
            {
                if (((Pitfall)square).CanFallThrough)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("~");
                }
            }
            else if (square is Empty)
            {
                Console.Write(" ");
            }
        }

        public void Won()
        {
            this.Render();
            Console.WriteLine("\nYou won!");
        }

        public ConsoleKey Restart()
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to play again? (Y)");

            var value = Console.ReadKey().Key;
            Console.WriteLine();
            return value;
        }
    }
}
