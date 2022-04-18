using GOGO.RMS.ESV.Core.Entity;
using System;
using System.Collections.Generic;

namespace GOGO.RMS.ESV.Core.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IList<Product> GetBySKU(String SKU);
        IList<Product> GetByName(String Name);
        void DeleteBySku(String SKU);
    }
}
