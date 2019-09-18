using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Sokoban
    {
        private LevelParser _levelParser = new LevelParser();
        private bool _playing;
        private PlayingField _playingField;

        public Sokoban()
        {
            WelcomeText();
            ChooseLevel();
            _playing = true;



            while (_playing)
            {
                _playingField.Show();

                ConsoleKey keyPressed = Console.ReadKey().Key;

                var player = getPlayer();

                movePlayer(player, keyPressed);

                if (keyPressed == ConsoleKey.S)
                {
                    _playing = false;
                }
            }
        }

        private void movePlayer(Square player, ConsoleKey keyPressed)
        {
            int xTo = 0;
            int yTo = 0;
            
            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    xTo = -1;
                    break;
                case ConsoleKey.UpArrow:
                    yTo = -1;
                    break;
                case ConsoleKey.RightArrow:
                    xTo = 1;
                    break;
                case ConsoleKey.DownArrow:
                    yTo = 1;
                    break;
            }

            int x = player.PosX + xTo;
            int y = player.PosY + yTo;

            if (_playingField.SquareList[y][x].Moving is Chest)
            {
                if(_playingField.SquareList[y + yTo][x + xTo] is Floor || _playingField.SquareList[y + yTo][x + xTo] is Destination)
                {
                    _playingField.SquareList[y + yTo][x + xTo].Moving = _playingField.SquareList[y][x].Moving;
                    _playingField.SquareList[y][x].Moving = null;
                } else
                {
                    return;
                }
            }

            if (_playingField.SquareList[y][x] is Floor || _playingField.SquareList[y][x] is Destination)
            {
                _playingField.SquareList[y][x].Moving = player.Moving;
                _playingField.SquareList[y][x].Moving.Square = player.Moving.Square;
                player.Moving.Square = null;
                player.Moving = null;
            }
        }

        private void WelcomeText()
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

        private void ChooseLevel()
        {
            Console.WriteLine("Choose a level (1 - 2)");
            var value = Console.ReadLine();

            if(value == "s")
            {
                System.Environment.Exit(1);
            }

            try
            {
                int level = Int32.Parse(value);

                if (level >= 1 && level <= 2)
                {
                    _playingField = _levelParser.getPlayingField(level);
                } else
                {
                    Console.WriteLine($"Level {level} does not exist");
                    this.ChooseLevel();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, please try again");
                this.ChooseLevel();
            }
        }

        public Square getPlayer()
        {
            for (int i = 0; i < _playingField.SquareList.Count; i++)
            {
                for (int j = 0; j < _playingField.SquareList[i].Count; j++)
                {
                    if (_playingField.SquareList[i][j].Moving is Player)
                    {
                        return _playingField.SquareList[i][j];
                    }
                }
            }

            return null;

        }
    }

}
