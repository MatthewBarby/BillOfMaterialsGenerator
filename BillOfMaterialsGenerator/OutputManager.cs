using BillOfMaterialsGenerator.Interfaces;
using DataEntities;
using System;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator
{
    /// <summary>
    /// Class for managing the output of the bill of materials generator. Additional methods of output can be injected in if they are required.
    /// </summary>
    public class OutputManager : IOutputManager
    {
        private readonly IConsoleOutput consoleOutput;
        private readonly ISystemSettingsWrapper systemSettingsWrapper;
        private readonly ILogWrapper logWrapper;

        public OutputManager(IConsoleOutput consoleOutput,
            ISystemSettingsWrapper systemSettingsWrapper,
            ILogWrapper logWrapper)
        {
            this.consoleOutput = consoleOutput;
            this.systemSettingsWrapper = systemSettingsWrapper;
            this.logWrapper = logWrapper;
        }

        public void OutputBillOfMaterials(BillOfMaterials billOfMaterials)
        {
            try
            {
                if (systemSettingsWrapper.OutputToConsole)
                {
                    consoleOutput.OutputBillOfMaterials(billOfMaterials);
                }
            }
            catch(Exception ex)
            {
                logWrapper.LogError($"Error outputting the bill of materials. Exception: {ex.Message}");
            }
        }

        public void OutputError()
        {
            consoleOutput.OutputError();
        }
    }
}
