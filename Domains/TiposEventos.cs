using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_.Domain
{
        [Table ("TiposEventos")]
    public class TiposEventos
    {
        [Key]
        public Guid IdTipoEvento { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Tipo do evento é obrigatorio!")]
        public string? TituloTipoEvento { get; set; }
      
    }
}
