using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntities
{
    public class Ellipse : WidgetBase
    {
        public Ellipse()
        {
            Name = "Ellipse";
        }

        public int HorizontalDiameter { get; set; }

        public int VerticalDiameter { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PositionX},{PositionY}) diameterH = {HorizontalDiameter} diameterV = {VerticalDiameter}";
        }
    }
}
