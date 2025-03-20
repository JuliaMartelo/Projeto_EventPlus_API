using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Event_.Domains
{
    [Table("Instituicoes")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicoes
    {
        [Key]
        public Guid IdInstituicao { get; set; }

       
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O CNPJ é obrigatória!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço é obrigatória!")]
        public string? Endereço { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia é obrigatória!")]
        public string? NomeFantasia { get; set; }


        
    }
}
