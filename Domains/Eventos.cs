using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_Event_.Domain;
using Projeto_Event_.Domains;

namespace Event_.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid EventoID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento e  obrigatorio!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao e obrigatoria!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "a data do evento e obrigatorio!")]
        public DateTime DataEvento { get; set; }

        public Guid TipoEventoID { get; set; }

        [ForeignKey("TiposEventosID")]
        public TiposEventos? tipoevento { get; set; }

        public Guid InstituicoesID { get; set; }

        [ForeignKey("InstituicoesID")]

        public Instituicao? instituicao { get; set; }

        public Presencas? presencas { get; set; }
    }
}
