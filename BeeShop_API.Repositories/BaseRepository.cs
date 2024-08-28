using BeeShop_API.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories
{
    public abstract class BaseRepository
    {
        protected BaseRepository(DataContext context)
        {
            DataContext = context;
        }

        public DataContext DataContext { get; private set; }
    }
}
