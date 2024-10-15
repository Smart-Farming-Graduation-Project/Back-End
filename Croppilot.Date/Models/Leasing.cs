using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croppilot.Date.Models;

public class Leasing
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Product ID is required")]
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = "Leasing start date is required")]
    public DateTime StartingDate { get; set; }

    [DataType(DataType.DateTime)] 
    public DateTime? EndDate { get; set; }

    public Product Product { get; set; }
}