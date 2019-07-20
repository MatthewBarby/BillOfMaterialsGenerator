using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DataEntities
{
    public class Textbox : WidgetBase
    {
        public Textbox()
        {
            Name = "Textbox";
        }

        public int Width { get; set; }

        public int Height{ get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PositionX},{PositionY}) width={Width} height={Height} text=\"{Text}\"";
        }
    }
}
