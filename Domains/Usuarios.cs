using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Projeto_Event_.Domains;

namespace Projeto_Event_.Domains
{
     [Table("Usuario")]
     [Index(nameof(Email), IsUnique = true)]
    public class Usuarios
    {

     [Key]
       public Guid IdUsuarios { get; set; }

      [Column(TypeName = "VARCHAR(50)")]
      [Required(ErrorMessage = "O nome é obrigatório!")]
      public string? Nome { get; set; }

      [Column(TypeName = "VARCHAR(50)")]
      [Required(ErrorMessage = "O email é obrigatório!")]
      public string? Email { get; set; }

      [Column(TypeName = "VARCHAR(60)")]
      [Required(ErrorMessage = "A senha é obrigatória!")]
      [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve ter de 5 a 30 caracteres.")]
      public string? Senha { get; set; }


      public Guid IdTipoUsuarios { get; set; }
      [ForeignKey("IdTipoUsuario")]
      public TiposUsuarios? TipoUsuario { get; set; }

    }
}
