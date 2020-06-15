using System;

namespace import_app_flin.DataContext
{
    public interface IProduct
    {
        string Currency { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        Guid ProductGroupId { get; set; }
        Guid ProductId { get; set; }
    }
}