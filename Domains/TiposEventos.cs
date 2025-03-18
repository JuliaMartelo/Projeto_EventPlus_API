using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_.Domains
{
    [Table("TipoUsuario")]
    public class TiposEventos
    {
        [Key]

        public Guid IdTipoUsuario { get; set; }
        public string? tipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "O tipo de usuario e obrigatorio!")]
        public string? TituloTipoUsuario { get; set; }

    }
}
