using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity=GOGO.RMS.ESV.Product;
namespace GOGO.RMS.ESV.ProductBFInterface
{
    public interface IProductBF
    {
        IList<Entity.Product> GetAll();
        IList<Entity.Product> GetBySKU(String SKU);
        IList<Entity.Product> GetByName(String Name);
        Entity.Product GetById(Guid Id);
        Entity.Product Get(Entity.Product product);
        void Save(Entity.Product product);
        void DeleteById(Guid Id);
        void Delete(Entity.Product product);
        void DeleteBySku(String SKU);
    }
}
