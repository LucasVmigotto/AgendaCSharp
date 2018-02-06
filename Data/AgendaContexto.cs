using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data
{
    public class AgendaContexto : DbContext
    {
        public AgendaContexto(DbContextOptions<AgendaContexto> options):base(options){}
        
        public DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder model){
            model.Entity<Contato>().ToTable("Contato");
        }
    }
}