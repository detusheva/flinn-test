using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flin_test.DataContext
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
        public Guid ProductGroupId { get; set; }
    }
}
