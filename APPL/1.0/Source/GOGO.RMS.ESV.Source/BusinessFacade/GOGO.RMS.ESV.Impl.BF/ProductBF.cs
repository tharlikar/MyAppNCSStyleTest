using System;
using System.Collections.Generic;
using System.Linq;
using GOGO.RMS.ESV.Core.Interface;
using GOGO.RMS.ESV.Core.Entity;

namespace GOGO.RMS.ESV.Impl.BF
{
    public class ProductBF : BaseBF, IProductBF
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductBF(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBySku(string SKU)
        {
            throw new NotImplementedException();
        }

        public Product Get(Product entity)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetBySKU(string SKU)
        {
            throw new NotImplementedException();
        }

        public void Save(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
