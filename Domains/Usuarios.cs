using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;



namespace Projeto_Event_.Domain
{
    public class Usuarios
    {

        [Table("Usuario")]
        [Index(nameof(Email), IsUnique = true)]
        public class usuarios
        {
            [Key]
            public Guid IdUsuarios { get; set; }

            [ForeignKey("IdTipoUsuario")]
            public Guid IdTipoUsuarios { get; set; }



            public string? Nome { get; set; }

            [Column(TypeName = "VARCHAR(50)")]
            [Required(ErrorMessage = "O nome é obrigatório!")]
            public string? Email { get; set; }

            [Column(TypeName = "VARCHAR(50)")]
            [Required(ErrorMessage = "O email é obrigatório!")]

            public string? Senha { get; set; }
            [Column(TypeName = "VARCHAR(60)")]
            [Required(ErrorMessage = "A senha é obrigatória!")]
            [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve ter de 5 a 30 caracteres.")]
        }
    
    }
}
