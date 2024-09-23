using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories;
using BeeShop_API.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.BusinessLogic
{
    public class ProductCategoriesBusinessLogic : IProductCategoriesBusinessLogic
    {
        private readonly IProductCategoriesRepository _repository;
        public ProductCategoriesBusinessLogic(IProductCategoriesRepository repository)
        {
            this._repository = repository;
        }

        public async Task<ProductCategories> Add(ProductCategories pc)
        {
            return await _repository.Add(pc);
        }

        public async Task<bool> Delete(string pcID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductCategories>> GetAll(string txtSearch, int? page)
        {
            return await _repository.GetAll(txtSearch, page);
        }

        public async Task<ProductCategories> GetByID(string pcID)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCategories> Update(ProductCategories pc)
        {
            throw new NotImplementedException();
        }
    }
}
