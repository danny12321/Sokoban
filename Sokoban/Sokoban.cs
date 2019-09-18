using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Sokoban
    {
        private LevelParser _levelParser;
        private bool _playing;
        private PlayingField _playingField;

        public Sokoban()
        {
            _playing = true;

            _levelParser = new LevelParser();

            _playingField = _levelParser.getPlayingField();

            _playingField.Show();

            while (_playing)
            {
                ConsoleKey keyPressed = Console.ReadKey().Key;
                Console.WriteLine(keyPressed);
                if (keyPressed == ConsoleKey.S)
                {
                    _playing = false;
                }
            }
        }

        //public Square getPlayer()
        //{
        //    _playingField.
        //}
    }

}
