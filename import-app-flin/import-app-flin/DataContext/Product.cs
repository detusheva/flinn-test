using System;
using System.Collections.Generic;

namespace import_app_flin.DataContext
{
    public partial class Product : IProduct
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
        public Guid ProductGroupId { get; set; }
    }
}
