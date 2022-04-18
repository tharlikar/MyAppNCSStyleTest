using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GOGO.RMS.ESV.Core.Interface;
using GOGO.RMS.ESV.Impl.BF;
using GOGO.RMS.ESV.Core.Entity;
using GOGO.RMS.ESV.EF.Impl.Repository;

namespace GOGO.RMS.ESV.Source.Test
{
    [TestClass]
    public class TestProductBF
    {
        private static DataAccessContext ctx = new DataAccessContext();
        [TestMethod]
        [Priority(2)]
        public void GetAll()
        {
            SaveProduct();
                IProductBF productBF = new ProductBF(new UnitOfWork(ctx),new ProductRepository(ctx));
                IList<Product> products = productBF.GetAll();
                Assert.IsTrue(products.Count>0);
                DeleteProduct();
            
        }

        [TestMethod]
        [Priority(1)]
        public void Save()
        {
            Product product = SaveProduct();

            Assert.IsTrue(product.Id != Guid.Empty);
            DeleteProduct();
        }

        [TestMethod]
        public void Update()
        {
            
                Product product = SaveProduct();
                IProductBF productBF = new ProductBF(new UnitOfWork(ctx), new ProductRepository(ctx));
                var products=productBF.GetBySKU("SKU000001");
                products[0].Name = "ProductnameChanged";
                productBF.Save(products[0]);
                DeleteProduct();
            
        }

        private static Product SaveProduct()
        {
            
                IProductBF productBF = new ProductBF(new UnitOfWork(ctx), new ProductRepository(ctx));
                Product product = new Product()
                {
                    Id= Guid.NewGuid(),
                    SKU = "SKU000001"
                    ,
                    Name = "Product 1"
                };
                productBF.Save(product);
                return product;
            
            
        }

        [TestMethod]
        [Priority(3)]
        public void DeleteBySKU()
        {
            SaveProduct();
            DeleteProduct();
            IProductBF productBF = new ProductBF(new UnitOfWork(ctx), new ProductRepository(ctx));
            IList<Product> products = productBF.GetAll();
            Assert.IsTrue(products.Count == 0);
        }

        private static IProductBF DeleteProduct()
        {

                IProductBF productBF = new ProductBF(new UnitOfWork(ctx), new ProductRepository(ctx));
                productBF.DeleteBySku("SKU000001");
                return productBF;
           
        }
    }
}
