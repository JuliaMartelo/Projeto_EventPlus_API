using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_.Domain
{
        [Table ("TipoEvento")]
    public class TiposUsuarios
    {
        [Key]

        public Guid IdTipoEvento { get; set; }

        public string? tipoEvento { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Tipo do evento é obrigatorio!")]
        public string? Nome { get; set; }
    }
}
