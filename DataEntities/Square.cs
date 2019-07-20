using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntities
{
    public class Square : WidgetBase
    {
        public Square()
        {
            Name = "Square";
        }

        public int Width { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PositionX},{PositionY}) size={Width}";
        }
    }
}
