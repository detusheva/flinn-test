using System;
using System.ComponentModel.DataAnnotations;

namespace Flin_test.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        [Range(0.1, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        public string Currency { get; set; }
        [Required(ErrorMessage = "The Name is required.")]
        public string Name { get; set; }
        public Guid ProductGroupId { get; set; }
    }
}
