using DataEntities.Interfaces;
using System;

namespace DataEntities
{
    public abstract class WidgetBase : IWidgetBase
    {
        public string Name { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
