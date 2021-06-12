using System;
using System.Collections.Generic;
using System.Text;

namespace eCartDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ItemCode { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string Mou { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto category { get; set; }
    }
}
