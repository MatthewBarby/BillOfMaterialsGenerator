using BillOfMaterialsGenerator.Interfaces;
using System.Configuration;

namespace BillOfMaterialsGenerator
{
    /// <summary>
    /// Wrapper for system settings so they can be injected and mocked in tests
    /// </summary>
    public class SystemSettingsWrapper : ISystemSettingsWrapper
    {
        public SystemSettingsWrapper()
        {

        }

        public bool OutputToConsole
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["OutputToConsole"]);
            }
        }
    }
}
