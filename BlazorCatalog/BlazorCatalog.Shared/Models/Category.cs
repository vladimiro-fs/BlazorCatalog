namespace BlazorCatalog.Shared.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Category name is mandatory")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Description is mandatory")]
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
