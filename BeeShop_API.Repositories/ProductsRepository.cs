using BeeShop_API.DataAccess;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories
{
    public class ProductsRepository : BaseRepository
    {
        public ProductsRepository(DataContext context) : base(context)
        {

        }
    }
}
