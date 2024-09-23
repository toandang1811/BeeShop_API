using BeeShop_API.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Validators
{
    public class ProductCategoriesValidator : AbstractValidator<ProductCategories>
    {
        public ProductCategoriesValidator()
        {
            RuleFor(pc => pc.ProductCategoryID)
                .NotEmpty().WithMessage("Bắt buộc nhập mã loại sản phẩm.")
                .Length(1, 256);
            RuleFor(pc => pc.ProductCategoryName)
                .NotEmpty()
                .Length(1, 256);
        }
    }
}
