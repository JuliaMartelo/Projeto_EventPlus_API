using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_Event_.Domains;

namespace Projeto_Event_.Domains
{
    [Table("ComentariosEventos")]
    public class ComentariosEventos
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Descrição do evento é obrigatório!")]
        public Guid Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "O exibir é obrigatório!")]
        public bool? Exibe { get; set; }

        public Guid IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Eventos? Eventos { get; set; }
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuarios { get; set; }



    }
}
