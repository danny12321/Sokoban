using Sokoban.Model;
using Sokoban.View;
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
        private ConsoleView _consoleView = new ConsoleView();
        private WMPLib.WindowsMediaPlayer FootstepSound;

        public Sokoban()
        {
            FootstepSound = new WMPLib.WindowsMediaPlayer();
            FootstepSound.URL = "https://www.fesliyanstudios.com/sp.php?i=/731.mp3";


            ChooseLevel();

            Play();
        }

        private void Play()
        {
            _playing = true;
            bool won = false;

            while (_playing && !won)
            {
                _consoleView.Render();

                ConsoleKey keyPressed = Console.ReadKey().Key;

                if (keyPressed == ConsoleKey.S)
                {
                    _playing = false;
                    break;
                }

                MovePlayer(keyPressed);

                _playingField.Worker?.Play();

                won = CheckWin();
            }

            _consoleView.Won();

            if (won) _consoleView.Won();

            this.Restart();
        }


        public void Restart()
        {
            var value = _consoleView.Restart();

            if (value == ConsoleKey.Y)
            {
                Play();
            }
            else
            {
                Console.WriteLine($"Ciao! (Press enter to leave)");
                Console.ReadLine();
            }
        }

        private bool CheckWin()
        {
            bool hasWon = true;
            _playingField.Squares.FindAll(s => s is Destination).ForEach(s =>
            {
                if (!(s.Content is Chest))
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


        private void ChooseLevel()
        {
            var value = _consoleView.ChooseLevel();

            if (value == "s")
            {
                System.Environment.Exit(1);
            }

            try
            {
                int level = Int32.Parse(value);

                if (level >= 1 && level <= 7)
                {
                    _playingField = _levelParser.getPlayingField(level);
                    _consoleView.PlayingField = _playingField;
                }
                else
                {
                    Console.WriteLine($"Level {level} does not exist");
                    this.ChooseLevel();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Why you no good level enter?");
                this.ChooseLevel();
            }
        }
    }

}
