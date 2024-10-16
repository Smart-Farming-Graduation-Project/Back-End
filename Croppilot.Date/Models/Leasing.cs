using System.ComponentModel.DataAnnotations;

namespace Croppilot.Date.Models;

public class Leasing
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product ID is required")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Leasing start date is required")]
    public DateTime StartingDate { get; set; }

    [Required(ErrorMessage = "Leasing Details ID is required")]
    public string LeasingDetails { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? EndDate { get; set; }

    public Product Product { get; set; }
}