using BeeShop_API.Domain.Entities.Abstracts;
using BeeShop_API.Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Entities
{
    public class ProductCategories : CommonEFAbstract
    {
        private ProductCategoriesValidator pcValidator = new ProductCategoriesValidator();
        public string ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public override void ValidateAndThrow()
        {
            pcValidator.ValidateAndThrow(this);
        }
    }
}
