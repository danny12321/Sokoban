using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class LevelParser
    {
        public LevelParser()
        {

        }

        public PlayingField getPlayingField(int level)
        {
            PlayingField playingField = new PlayingField();
            string[] lines = System.IO.File.ReadAllLines($@"../../Levels/level{level}.txt");

            for (int y = 0; y < lines.Length; y++)
            {
                var row = new List<Square>();

                for (int x = 0; x < lines[y].Length; x++)
                {
                    switch (lines[y][x])
                    {
                        case '#':
                            var wall = new Wall();
                            wall.PosX = x;
                            wall.PosY = y;
                            row.Add(new Wall());
                            break;

                        case '.':
                            var floor = new Floor();
                            floor.PosX = x;
                            floor.PosY = y;
                            row.Add(floor);
                            break;

                        case 'o':
                            var chest = new Floor();
                            chest.PosX = x;
                            chest.PosY = y;
                            chest.Moving = new Chest(chest);
                            row.Add(chest);
                            break;

                        case 'x':
                            var destination = new Destination();
                            destination.PosX = x;
                            destination.PosY = y;
                            row.Add(destination);
                            break;

                        case '@':
                            var player = new Floor();
                            player.PosX = x;
                            player.PosY = y;
                            player.Moving = new Player(player);
                            row.Add(player);
                            break;
                        case '~':
                            var pitfall = new Pitfall();
                            pitfall.PosX = x;
                            pitfall.PosY = y;
                            row.Add(pitfall);
                            break;
                    }
                }

                playingField.SquareList.Add(row);
            }

            return playingField;
        }
    }
}
