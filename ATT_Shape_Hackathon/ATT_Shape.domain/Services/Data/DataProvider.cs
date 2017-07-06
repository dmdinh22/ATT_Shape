using ATT_Shape.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT_Shape.domain.Services.Data
{
    public sealed class DataProvider
    {
        private DataProvider()
        {

        }

        public static IDao Instance
        {
            get
            {
                return SqlDao.Instance;
            }
        }
    }
}
