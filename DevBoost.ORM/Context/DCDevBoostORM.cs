using DevBoost.ORM.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DevBoost.ORM.Context
{
    public class DCDevBoostORM : DbContext
    {
        public DCDevBoostORM(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Clube> Clubes { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Jogador>().HasKey(p => p.Id);
            modelBuilder.Entity<Jogador>()
                .HasOne(p => p.Clube)
                .WithOne()
                .HasForeignKey<Clube>(c => c.Id);
            modelBuilder.Entity<Jogador>()
               .HasOne(p => p.Posicao)
               .WithOne()
               .HasForeignKey<Posicao>(c => c.Id);


            modelBuilder.Entity<Clube>().HasKey(p => p.Id);
           

            modelBuilder.Entity<Posicao>().HasKey(p => p.Id);

        }
    }
}
