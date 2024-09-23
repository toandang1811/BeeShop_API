using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Mappers
{
    public class ProductCategoriesMapper : IMapperCommon<DataAccess.ProductCategories, ProductCategories>
    {
        public DataAccess.ProductCategories FillFromDomain(ProductCategories pc)
        {
            if (pc is null)
            {
                throw new ArgumentNullException(nameof(pc));
            }

            return new DataAccess.ProductCategories
            {
                ProductCategoryID = pc.ProductCategoryID,
                ProductCategoryName = pc.ProductCategoryName,
                Icon = pc.Icon,
                Alias = pc.Alias,
                Description = pc.Description,
                CreatedDate = pc.CreatedDate,
                CreatedUserID = pc.CreatedUserID,
                ModifiedDate = pc.ModifiedDate,
                ModifiedUserID = pc.ModifiedUserID
            };
        }

        public Domain.Entities.ProductCategories FillFromDataAccess(DataAccess.ProductCategories pc)
        {
            if (pc is null)
            {
                throw new ArgumentNullException(nameof(pc));
            }

            return new Domain.Entities.ProductCategories
            {
                ProductCategoryID = pc.ProductCategoryID,
                ProductCategoryName = pc.ProductCategoryName,
                Icon = pc.Icon,
                Alias = pc.Alias,
                Description = pc.Description,
                CreatedDate = pc.CreatedDate,
                CreatedUserID = pc.CreatedUserID,
                ModifiedDate = pc.ModifiedDate,
                ModifiedUserID = pc.ModifiedUserID
            };
        }
    }
}
