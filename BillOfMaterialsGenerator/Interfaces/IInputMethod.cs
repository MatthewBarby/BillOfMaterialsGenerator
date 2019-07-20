using DataEntities;

namespace BillOfMaterialsGenerator.Interfaces
{
    public interface IInputMethod
    {
        /// <summary>
        /// Reads the next bill of materials
        /// </summary>
        /// <returns></returns>
        BillOfMaterials GetBillOfMaterials();
    }
}
