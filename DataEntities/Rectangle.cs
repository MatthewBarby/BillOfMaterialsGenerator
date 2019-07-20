using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntities
{
    public class Rectangle : WidgetBase
    {
        public Rectangle()
        {
            Name = "Rectangle";
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PositionX},{PositionY}) width={Width} height={Height}";
        }
    }
}
