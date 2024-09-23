using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts
{
    public interface IProductCategoriesRepository
    {
        Task<ProductCategories> Add(ProductCategories pc);
        Task<ProductCategories> Update(ProductCategories pc);
        Task<IEnumerable<ProductCategories>> GetAll(string txtSearch, int ? DataContext);
        Task<ProductCategories> GetByID(string pcID);
        Task<bool> Delete(string pcID);
    }
}
