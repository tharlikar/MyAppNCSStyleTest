using GOGO.RMS.ESV.Core.Entity;
using GOGO.RMS.ESV.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GOGO.RMS.ESV.EF.Impl.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DataAccessContext dataContext;
        public ProductRepository(DataAccessContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public void DeleteBySku(string SKU)
        {
            IList<Product> ps= GetBySKU(SKU);
            foreach(var p in ps)
            {
                this.dataContext.Set<Product>().Remove(p);
                this.dataContext.SaveChanges();
            }
        }

        public IList<Product> GetByName(string Name)
        {
            return List(x => string.Compare(x.Name, Name,true) == 0);
        }

        public IList<Product> GetBySKU(string SKU)
        {
            return List(x => string.Compare(x.SKU,SKU,true)==0);
        }
    }
}
