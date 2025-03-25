using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_Event_.Domains;

namespace Projeto_Event_.Domains
{
    [Table ("Presencas")]
    public class Presencas
    {
        [Key]
        public Guid IdPresenca { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação é obrigatoria!")]
        public bool Situacao { get; set; }

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuarios { get; set; }

        public Guid IdEventos { get; set; }

        [ForeignKey ("IdEvento")]
        public Eventos? Eventos { get; set; }  
        
    }
}
