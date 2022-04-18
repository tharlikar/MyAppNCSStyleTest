using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOGO.RMS.ESV.ProductBFInterface;
using ProductBF=GOGO.RMS.ESV.ProductBF;
using Entity = GOGO.RMS.ESV.Product;
using System.Collections.Generic;

namespace GOGO.RMS.ESV.Source.Test
{
    [TestClass]
    public class TestProductBF
    {
        [TestMethod]
        [Priority(2)]
        public void GetAll()
        {
            SaveProduct();
            IProductBF productBF = new ProductBF.ProductBF();
            IList<Entity.Product> products = productBF.GetAll();
            Assert.IsTrue(products.Count==1);
            DeleteProduct();
        }

        [TestMethod]
        [Priority(1)]
        public void Save()
        {
            Entity.Product product = SaveProduct();

            Assert.IsTrue(product.Id != Guid.Empty);
            //DeleteProduct();
        }

        [TestMethod]
        public void Update()
        {
            Entity.Product product = SaveProduct();
            IProductBF productBF = new ProductBF.ProductBF();
            //var products=productBF.GetBySKU("SKU000001");
            //products[0].Name = "ProductnameChanged";
            //productBF.Save(products[0]);
            productBF.Save(product);
            DeleteProduct();
        }

        private static Entity.Product SaveProduct()
        {
            IProductBF productBF = new ProductBF.ProductBF();
            Entity.Product product = new Entity.Product()
            {
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
            IProductBF productBF = DeleteProduct();
            IList<Entity.Product> products = productBF.GetAll();
            Assert.IsTrue(products.Count == 0);
        }

        private static IProductBF DeleteProduct()
        {
            IProductBF productBF = new ProductBF.ProductBF();
            productBF.DeleteBySku("SKU000001");
            return productBF;
        }
    }
}
