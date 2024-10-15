using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croppilot.Date.Models;
public class ProductImage
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Image URL is required")]
    public string ImageUrl { get; set; }

    [Required(ErrorMessage = "Product ID is required")]
    public Guid ProductId { get; set; }

    public Product Product { get; set; }
}