using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player : Moving
    {


        public override void Show()
        {
            Console.Write("@");
        }
    }
}