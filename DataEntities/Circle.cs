using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntities
{
    public class Circle : WidgetBase
    {
        public Circle()
        {
            Name = "Circle";
        }

        public int Diameter { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PositionX},{PositionY}) size={Diameter}";
        }
    }
}
