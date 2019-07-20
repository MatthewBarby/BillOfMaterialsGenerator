using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntities.Interfaces
{
    /// <summary>
    /// Interface for widget base
    /// </summary>
    public interface IWidgetBase
    {
        string Name { get; }

        int PositionX { get; set; }

        int PositionY { get; set; }
    }
}
