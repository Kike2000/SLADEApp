using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CongresoServer.Model;

namespace CongresoServer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }

        public DbSet<Participante> Participante { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Area> Area { get; set; }
    }
}