using System.ComponentModel.DataAnnotations;

namespace GenericRepositorySample.Api.Entities;

public class User
{
    [Key]
    [Required]
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;
}
