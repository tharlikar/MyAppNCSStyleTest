using GOGO.RMS.ESV.Core.Entity;
using System;
using System.Collections.Generic;

namespace GOGO.RMS.ESV.Core.Interface
{
    public interface IProductBF : IBaseBF
    {
        IList<Product> GetAll();
        Product GetById(Guid Id);
        Product Get(Product entity);
        void Save(Product entity);
        void DeleteById(Guid Id);
        void Delete(Product entity);
        IList<Product> GetBySKU(String SKU);
        IList<Product> GetByName(String Name);
        void DeleteBySku(String SKU);
    }
}
