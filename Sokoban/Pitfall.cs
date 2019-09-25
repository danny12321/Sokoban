using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Pitfall : Square
    {
        private int _hit = 0;

        private Content _content;
        public override Content Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (value != null)
                {
                    Hit();
                }
                _content = value;
            }
        }

        public override bool CanFallThrough
        {
            get { return _hit >= 3; }
        }


        public override void Show()
        {
            if(_hit >= 3)
            {
                Console.Write(" ");
            } else
            {
                Console.Write("~");
            }
        }

        public void Hit()
        {
            _hit++;
        }

    }
}