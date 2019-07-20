using DataEntities;

namespace BillOfMaterialsGenerator.Interfaces
{
    /// <summary>
    /// The interface for a variety of output methods
    /// </summary>
    public interface IOutputMethod
    {
        /// <summary>
        /// Output the bill to my method of output
        /// </summary>
        /// <param name="billOfMaterials"></param>
        void OutputBillOfMaterials(BillOfMaterials billOfMaterials);

        /// <summary>
        /// Output an error message to my method of output
        /// </summary>
        void OutputError();
    }
}
