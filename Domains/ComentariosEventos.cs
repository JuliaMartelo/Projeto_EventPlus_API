using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_.Domain
{
    [Table("ComentarioEvento")]
    public class ComentariosEventos
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }
        [ForeignKey("IdEvento, IdUsuario")]
        public Guid IdEvento { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid Descrição { get; set; }
        public Guid Exibe { get; set; }
        public string? comentarioEvento { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Comentário do evento é obrigatório!")]
        public string? Comentario { get; set; }
    }
}
