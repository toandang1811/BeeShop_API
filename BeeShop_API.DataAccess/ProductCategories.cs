using BeeShop_API.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.DataAccess
{
    public class ProductCategories : CommonAbstracts
    {
        [Key]
        public string ProductCategoryID { get; set; }
        [Required]
        [StringLength(250)]
        public string ProductCategoryName { get; set; }
        [StringLength(250)]
        public string Alias { get; set; }
        public string Description { get; set; }
        [StringLength(250)]
        public string Icon { get; set; }
    }
}
