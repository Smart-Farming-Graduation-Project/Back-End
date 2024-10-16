using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Croppilot.Date.Models;

public class Category
{
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; }


    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string Description { get; set; } = default!;

    [ValidateNever]
    public ICollection<Product> Products { get; set; }
}