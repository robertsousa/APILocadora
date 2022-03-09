using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100), MinLength(3, ErrorMessage = "O nome do filme precisa ter entre 3 a 100 caracteres."),]
        public string Title { get; set; }
        public bool IsLeased { get; set; }
        public bool IsActive { get; set; }
    }
}
