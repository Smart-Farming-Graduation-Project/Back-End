using Croppilot.Date.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croppilot.Date.Models;

public class Product
{
    public Guid Id { get; set; }

    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string Description { get; set; }

    [Range(0.01, 1000000.00, ErrorMessage = "Price must be between 0.01 and 1,000,000.00")]
    public decimal Price { get; set; }

    public Availability Availability { get; set; }

    [Required(ErrorMessage = "Creation date is required")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Update date is required")]
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public IEnumerable<Leasing> Leasings { get; set; } = new List<Leasing>();
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
}