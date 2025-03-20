using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_Event_.Domains;

namespace Projeto_Event_.Domains
{
    [Table("Eventos")]
    public class Eventos
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento e  obrigatorio!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao e obrigatoria!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "a data do evento e obrigatorio!")]
        public DateTime DataEvento { get; set; }


        public Guid TipoEventoID { get; set; }
        [ForeignKey("TipoEventoID")]
        public TiposEventos? tipoevento { get; set; }

        
        public Guid InstituicoesID { get; set; }
        [ForeignKey("InstituicoesID")]
        public Instituicoes? instituicao { get; set; }


        public Presencas? presencas { get; set; }
    }
}
