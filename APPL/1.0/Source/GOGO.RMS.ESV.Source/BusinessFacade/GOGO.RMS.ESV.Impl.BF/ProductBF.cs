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
        private readonly IProductRepository productRepository;

        public ProductBF(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        public void Delete(Product entity)
        {
            this.productRepository.Delete(entity);
        }

        public void DeleteById(Guid Id)
        {
            this.productRepository.Delete(GetById(Id));
        }

        public void DeleteBySku(string SKU)
        {
            this.productRepository.DeleteBySku(SKU);
        }

        public Product Get(Product entity)
        {
            return this.productRepository.Get(entity.Id);
        }

        public IList<Product> GetAll()
        {
            return this.productRepository.List();
        }

        public Product GetById(Guid Id)
        {
            return this.productRepository.List(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Product> GetByName(string Name)
        {
            return this.productRepository.GetByName(Name);
        }

        public IList<Product> GetBySKU(string SKU)
        {
            return this.productRepository.GetBySKU(SKU);
        }
        public void Save(Product entity)
        {
            var product = this.productRepository.Get(entity.Id);
            if (product != null)
                this.productRepository.Update(entity);
            else
                this.productRepository.Insert(entity);
        }
    }
}
