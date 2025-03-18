using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Event_.Domain
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; }

        [Required]
        public string? NomeFantasia { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Instituição é obrigatória!")]
        
        public string? Endereço { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Instituição é obrigatória!")]


        public string? CNPJ { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Instituição é obrigatória!")]
        [StringLength(14)]


        
    }
}
