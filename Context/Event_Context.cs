using Projeto_Event_.Domains;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public DbSet<TiposEventos> TiposEventos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Instituicoes> Intituicoes {get; set; }
        public DbSet<Presencas> Presencas { get; set; }
        public DbSet<ComentariosEventos> ComentariosEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VINIDR3; Database = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");
                //optionsBuilder.UseSqlServer("Server =DESKTOP-VINIDR3\\SQLEXPRESS; Database = filmes_julia; Integrated Security = true; TrustServerCertificate=true;");
            }


        }

    }
}
