using System.ComponentModel.DataAnnotations;

namespace GenericRepositorySample.Api.Entities;

public class Product
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public double Price { get; set; }
}
