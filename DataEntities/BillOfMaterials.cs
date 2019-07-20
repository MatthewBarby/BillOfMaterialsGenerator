using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntities
{
    public class BillOfMaterials
    {
        public BillOfMaterials()
        {

        }

        public List<Rectangle> Rectangles { get; set; }

        public List<Square> Squares { get; set; }

        public List<Ellipse> Elipses { get; set; }

        public List<Circle> Circles { get; set; }

        public List<Textbox> Textboxes { get; set; }
    }
}
