using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator.Interfaces
{
    public interface IBillOfMaterialsGenerator
    {
        /// <summary>
        /// Process the next bill.
        /// </summary>
        void ProccessNextBill();
    }
}
