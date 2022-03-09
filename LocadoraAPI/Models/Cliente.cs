using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100), MinLength(3, ErrorMessage = "O nome do usuário precisa ter entre 3 a 100 caracteres.")]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true; 
    }
}
