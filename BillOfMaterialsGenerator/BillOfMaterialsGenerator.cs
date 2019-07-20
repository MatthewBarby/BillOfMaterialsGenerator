using BillOfMaterialsGenerator.Interfaces;
using DataEntities;
using System;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator
{
    public class BillOfMaterialsGenerator : IBillOfMaterialsGenerator
    {
        private IInputMethod inputMethod;
        private IBillOfMaterialsValidator billOfMaterialsValidator;
        private readonly IOutputManager outputManager;
        private readonly ILogWrapper logger;

        public BillOfMaterialsGenerator(IInputMethod inputMethod, 
            IBillOfMaterialsValidator billOfMaterialsValidator,
            IOutputManager outputManager,
            ILogWrapper logger)
        {
            this.inputMethod = inputMethod;
            this.billOfMaterialsValidator = billOfMaterialsValidator;
            this.outputManager = outputManager;
            this.logger = logger;
        }

        public void ProccessNextBill()
        {
            try
            {
                logger.LogInfo("Processing next bill");

                BillOfMaterials nextBill = inputMethod.GetBillOfMaterials();
                if (billOfMaterialsValidator.IsValid(nextBill))
                {
                    outputManager.OutputBillOfMaterials(nextBill);
                }
                else
                {
                    logger.LogError("Error processing bill - Aborting");
                    outputManager.OutputError();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error encountered processing bill. Exceptions {ex.Message}");
            }
            
        }
    }
}
