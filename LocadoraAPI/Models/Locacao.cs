using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdFilme { get; set; }      
        [Required]
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
