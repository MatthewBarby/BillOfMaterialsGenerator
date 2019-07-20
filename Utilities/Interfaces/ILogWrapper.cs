using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Interfaces
{
    /// <summary>
    /// A wrapper around some logging system 
    /// </summary>
    public interface ILogWrapper
    {
        void LogDebug(string message);

        void LogInfo(string message);
       
       void LogWarn(string message);
        
       void LogError(string message);
    }
}
