using DataEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator.Interfaces
{
    /// <summary>
    /// Interface for validation a bill of materials.
    /// </summary>
    public interface IBillOfMaterialsValidator
    {
        /// <summary>
        /// Validate a bill of materials
        /// </summary>
        /// <param name="billOfMaterials"></param>
        /// <returns></returns>
        bool IsValid(BillOfMaterials billOfMaterials);
    }
}
