using CatalogoCursos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoCursos.Dados
{
    public class CatalogoContext:DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options):base(options){}

        public DbSet<Area> Area { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Turma>().ToTable("Turma");
        }
    }
}