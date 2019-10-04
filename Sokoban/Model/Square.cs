using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public abstract class Square
    {
        public virtual bool CanFallThrough { get; }
        public virtual Content Content { get; set; }
        public Square Top { get; set; }
        public Square Right { get; set; }
        public Square Bottom { get; set; }
        public Square Left { get; set; }

    }
}