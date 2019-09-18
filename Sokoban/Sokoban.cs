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


            while (_playing)
            {
                _playingField.Show();
                // input
                // change field

                // Get player input
                ConsoleKey keyPressed = Console.ReadKey().Key;

                // Get player
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
            int x = player.PosY;
            int y = player.PosX;

            Console.WriteLine(_playingField.SquareList[y][x].PosX + " " + _playingField.SquareList[y][x].PosY);
            
            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    x = x - 1;
                    break;
                case ConsoleKey.UpArrow:
                    y = y - 1;
                    break;
                case ConsoleKey.RightArrow:
                    x = x + 1;
                    break;
                case ConsoleKey.DownArrow:
                    y = y + 1;
                    break;
            }


            if(_playingField.SquareList[y][x] is Floor)
            {
                _playingField.SquareList[y][x].Moving = player.Moving;
                player.Moving = null;
            }
        }

        private Square getPlayer()
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
