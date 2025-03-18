using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_.Domain
{
    [Table ("Presença")]
    public class Presencas
    {
        [Key]
        public Guid IdPresença { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Presença é obrigatoria!")]

        public bool Situacao { get; set; }

        //Ref. tabela Usuario
        [Required(ErrorMessage = "Usuario é obrigatório!")]

        [ForeignKey ("IdEvento, IdUsuario")]

        public Guid IdUsuario { get; set; }

        public Guid Usuario { get; set; }
        public Guid IdEvento { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Presença é obrigatória!")]
        public string? presença { get; set; }
        

    }
}
