using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Projeto_Event_.Domain;

namespace Projeto_Event_.Context
{
    public class Event_Context : DbContext
    {
        public Event_Context()
        {
        }

        public Event_Context(DbContextOptions<Event_Context> options) : base(options)
        {
        }

        /// <summary>
        /// Define que as tabelas se transformarao em tabelas no BD
        /// </summary>

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<TiposUsuarios> TipoEvento { get; set; }
        public DbSet<Eventos> Evento { get; set; }
        public DbSet<Instituicao> Instituição { get; set; }
        public DbSet<Presencas> Presença { get; set; }
        public DbSet<ComentariosEventos> ComentarioEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =DESKTOP-VINIDR3; Database = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");
                //optionsBuilder.UseSqlServer("Server =DESKTOP-VINIDR3\\SQLEXPRESS; Database = filmes_julia; Integrated Security = true; TrustServerCertificate=true;");

            }


        }

    }
}
