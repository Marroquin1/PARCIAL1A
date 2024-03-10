using System.ComponentModel.DataAnnotations;
namespace PARCIAL1A.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }

    }
}
