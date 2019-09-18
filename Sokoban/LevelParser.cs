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

        public PlayingField getPlayingField()
        {
            PlayingField playingField = new PlayingField();

            string[] lines = System.IO.File.ReadAllLines(@"../../Levels/level1.txt");

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    Console.WriteLine(lines[y][x]);

                }
            }

            Console.ReadLine();

            return playingField;
        }
    }
}
