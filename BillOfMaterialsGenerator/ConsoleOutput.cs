using BillOfMaterialsGenerator.Interfaces;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator
{
    /// <summary>
    /// Class for outputting a bill of materials to the console
    /// </summary>
    public class  ConsoleOutput : IConsoleOutput
    {
        private ResourceManager resourceManager;

        private string lineBuffer;
        private string billOfMaterialsTitle;
        private string abortMessage;

        private readonly ILogWrapper logger;

        public ConsoleOutput(ILogWrapper logger)
        {
            this.logger = logger;

            initiliseStrings();
        }

        private void initiliseStrings()
        {
            resourceManager = new ResourceManager("BillOfMaterialsGenerator.Properties.Resources", Assembly.GetExecutingAssembly());
            lineBuffer = resourceManager.GetString("LineBuffer");
            billOfMaterialsTitle = resourceManager.GetString("BillOfMaterialsTitle");
            abortMessage = resourceManager.GetString("AbortMessage");
        }

        public void OutputBillOfMaterials(BillOfMaterials billOfMaterials)
        {
            logger.LogInfo("Outputting bill to the console");

            try
            {
                Console.WriteLine(lineBuffer);
                Console.WriteLine(billOfMaterialsTitle);
                Console.WriteLine(lineBuffer);

                OutputWidgets(billOfMaterials.Rectangles);
                OutputWidgets(billOfMaterials.Squares);
                OutputWidgets(billOfMaterials.Elipses);
                OutputWidgets(billOfMaterials.Circles);
                OutputWidgets(billOfMaterials.Textboxes);

                Console.WriteLine(lineBuffer);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception throw while outputting bill. Exception {ex.Message}");
            }
        }

        public void OutputWidgets<TWidgetType>(List<TWidgetType> widgets)
        {
            foreach (var widget in widgets)
            {
                Console.WriteLine(widget.ToString());
            }
        }

        public void OutputError()
        {
            logger.LogInfo("Outputting abort message to the console");

            Console.WriteLine(abortMessage);
        }
    }
}
