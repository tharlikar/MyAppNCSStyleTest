using GOGO.RMS.ESV.ProductBFInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOGO.RMS.ESV.Product;
using GOGO.RMS.ESV.DataAccess;
using System.Data.Entity;

namespace GOGO.RMS.ESV.ProductBF
{
    public class ProductBF : BaseBF.BaseBF, IProductBF
    {
        public void Delete(Product.Product product)
        {
            DeleteById(product.Id);
        }

        public void DeleteById(Guid Id)
        {
            using (var ctx = new DataAccessContext())
            {
                Product.Product p = GetById(Id,ctx);
                ctx.Products.Remove(p);
                ctx.SaveChanges();
            }
        }

        public void DeleteBySku(string SKU)
        {
            using (var ctx = new DataAccessContext())
            {
                IList<Product.Product> products = GetBySKU(SKU,ctx);
                ctx.Products.RemoveRange(products);
                ctx.SaveChanges();
            }
        }

        public Product.Product Get(Product.Product product)
        {
            return GetById(product.Id);
        }

        public IList<Product.Product> GetAll()
        {
            using (var ctx = new DataAccessContext())
            {
                return ctx.Products.ToList<Product.Product>();
            }
        }

        public Product.Product GetById(Guid Id)
        {
            using (var ctx = getDataAccessContext())
            {
                return GetById(Id, ctx);
            }
        }

        private Product.Product GetById(Guid Id,DataAccessContext ctx)
        {
            return ctx.Products.Where(x => x.Id == Id).Single<Product.Product>();
        }

        public IList<Product.Product> GetByName(string Name)
        {
            using (var ctx = getDataAccessContext())
            {
                return ctx.Products.Where(x => x.Name.Equals(Name,StringComparison.InvariantCultureIgnoreCase)).ToList<Product.Product>();
            }
        }

        public IList<Product.Product> GetBySKU(string SKU)
        {
            using (var ctx = getDataAccessContext())
            {
                return GetBySKU(SKU, ctx);
            }
        }

        private IList<Product.Product> GetBySKU(string SKU, DataAccessContext ctx)
        {
            return ctx.Products.Where(x => x.SKU.Equals(SKU, StringComparison.InvariantCultureIgnoreCase)).ToList<Product.Product>(); 
        }

        public void Save(Product.Product product)
        {
            using (var ctx = getDataAccessContext())
            {
                if (product.Id == Guid.Empty)
                {
                    ctx.Products.Add(product);
                }
                else
                {
                    ctx.Entry(product).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }
    }
}
