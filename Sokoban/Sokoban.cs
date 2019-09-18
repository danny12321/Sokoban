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
            this.WelcomeText();
            this.ChooseLevel();
            _playing = true;


            _playingField.Show();

            while (_playing)
            {
                ConsoleKey keyPressed = Console.ReadKey().Key;
                Console.WriteLine(keyPressed);

                var player = getPlayer();

                Console.WriteLine(player.PosX + " " + player.PosY);

                if (keyPressed == ConsoleKey.S)
                {
                    _playing = false;
                }
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
