using GOGO.RMS.ESV.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOGO.RMS.ESV.BaseBF
{
    public class BaseBF
    {
        public DataAccessContext getDataAccessContext()
        {
            return new DataAccessContext();
        }
    }
}
