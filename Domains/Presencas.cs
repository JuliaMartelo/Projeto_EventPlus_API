using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_Event_.Domains;

namespace Projeto_Event_.Domains
{
    [Table ("Presencas")]
    public class Presencas
    {
        [Key]
        public Guid IdPresença { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação é obrigatoria!")]
        public bool Situacao { get; set; }

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuario { get; set; }

        public Guid EventosID { get; set; }

        [ForeignKey ("IdEvento")]
        public Eventos? eventos { get; set; }  
        
    }
}
