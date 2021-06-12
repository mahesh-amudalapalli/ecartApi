using System;
using System.Collections.Generic;

#nullable disable

namespace eCartDAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
