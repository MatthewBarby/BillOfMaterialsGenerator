using DataEntities;

namespace BillOfMaterialsGenerator.Interfaces
{
    /// <summary>
    /// Interface for a class that manages the output of the bill of materials
    /// </summary>
    public interface IOutputManager
    {
        /// <summary>
        /// outputs the bill to all configured systems
        /// </summary>
        /// <param name="billOfMaterials"></param>
        void OutputBillOfMaterials(BillOfMaterials billOfMaterials);

        /// <summary>
        /// outputs an error to all configured systems
        /// </summary>
        void OutputError();
    }
}
