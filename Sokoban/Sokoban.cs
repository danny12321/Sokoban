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
        private WMPLib.WindowsMediaPlayer FootstepSound;

        public Sokoban()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            // wplayer.URL = "http://www.tomatenland.nl/content/mp3/Guus%20Meeuwis%20-%20Brabant.mp3";
            wplayer.URL = "https://staticcrate.com/content/audio-pro/soundscrate-digital-distress.mp3";
            wplayer.controls.play();



            FootstepSound = new WMPLib.WindowsMediaPlayer();
            FootstepSound.URL = "https://www.fesliyanstudios.com/sp.php?i=/731.mp3";

            WelcomeText();
            Play();
        }

        private void Play()
        {
            ChooseLevel();
            _playing = true;

            while (_playing)
            {
                Console.Clear();
                _playingField.Show();

                ConsoleKey keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.S)
                {
                    _playing = false;
                    break;
                }

                MovePlayer(keyPressed);

                _playingField.Worker?.Play();

                _playing = !CheckWin();
            }

            _playingField.Show();

            Console.WriteLine("\n You won!");
            Console.WriteLine("Do you want to play again? (Y/n)");

            var k = Console.ReadKey().Key;
            Console.WriteLine();

            if (k == ConsoleKey.Y)
            {
                Play();
            }
            else
            {
                Console.WriteLine("Ciao");
                Console.ReadLine();
            }
        }

        private bool CheckWin()
        {
            bool hasWon = true;
            _playingField.Squares.FindAll(s => s is Destination).ForEach(s => 
            {
                if(!(s.Content is Chest))
                {
                    hasWon = false;
                }
            });

            return hasWon;
        }

        private void MovePlayer(ConsoleKey keyPressed)
        {
            Direction direction = Direction.Top;

            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    direction = Direction.Top;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Bottom;
                    break;
            }

            FootstepSound.controls.stop();
            FootstepSound.controls.play();
            _playingField.Player.Move(direction);
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
            Console.WriteLine("Choose a level (1 - 6)");
            var value = Console.ReadLine();

            if(value == "s")
            {
                System.Environment.Exit(1);
            }

            try
            {
                int level = Int32.Parse(value);

                if (level >= 1 && level <= 7)
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
                Console.WriteLine(e);
                this.ChooseLevel();
            }
        }
    }

}
