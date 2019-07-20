using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator.Interfaces
{
    /// <summary>
    /// Interface for a wrapper around system settings
    /// </summary>
    public interface ISystemSettingsWrapper
    {
        /// <summary>
        /// should the bill be output to the console
        /// </summary>
        bool OutputToConsole { get; }
    }
}
