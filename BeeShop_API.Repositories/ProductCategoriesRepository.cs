using BeeShop_API.DataAccess;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts;
using BeeShop_API.Repositories.Contracts.Mappers;
using BeeShop_API.Repositories.Mappers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BeeShop_API.Repositories
{
    public class ProductCategoriesRepository : BaseRepository, IProductCategoriesRepository
    {
        private ProductCategoriesMapper _mapper;
        public ProductCategoriesRepository(DataContext context) : base(context)
        {
            this._mapper = new ProductCategoriesMapper();
        }

        public async Task<Domain.Entities.ProductCategories> Add(Domain.Entities.ProductCategories item)
        {
            item.ValidateAndThrow();

            await DataContext.ProductCategories.AddAsync(_mapper.FillFromDomain(item));
            await DataContext.SaveChangesAsync();

            return item;
        }

        public async Task<bool> Delete(string id)
        {
            var _pc = DataContext.ProductCategories.Find(id);
            if (_pc != null)
            {
                DataContext.ProductCategories.Remove(_pc);
                return await DataContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Domain.Entities.ProductCategories>> GetAll(string ? txtSearch, int ? page)
        {
            List<Domain.Entities.ProductCategories> rsItems = new List<Domain.Entities.ProductCategories>();
            var pageSize = 10;
            page ??= 1;
            IQueryable<DataAccess.ProductCategories> items = DataContext.ProductCategories.OrderByDescending(x => x.CreatedDate);
            if (!string.IsNullOrEmpty(txtSearch))
            {
                items = items.Where(x => x.Alias.Contains(txtSearch)
                || x.ProductCategoryName.Contains(txtSearch)
                || x.ProductCategoryID.Contains(txtSearch));
            }

            var pagedItems = items.ToPagedList(page.Value, pageSize);

            foreach (var item in pagedItems)
            {
                rsItems.Add(_mapper.FillFromDataAccess(item));
            }
            return rsItems.AsEnumerable();
        }

        public async Task<Domain.Entities.ProductCategories> GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.ProductCategories> Update(Domain.Entities.ProductCategories item)
        {
            throw new NotImplementedException();
        }
    }
}
