using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Actividad> Actividades { get; set; }
    public DbSet<ActividadConquistador> ActividadConquistadores { get; set; }
    public DbSet<Asistencia> Asistencias { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Clase> Clases { get; set; }
    public DbSet<Conquistador> Conquistadores { get; set; }
    public DbSet<ConquistadorItemCuadernillo> ConquistadorItemsCuadernillo { get; set; }
    public DbSet<Cronograma> Cronogramas { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }
    public DbSet<ItemCuadernillo> ItemsCuadernillo { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Unidad> Unidades { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .HasOne(cic => cic.CoicConquistador)
            .WithMany(c => c.ConqItemsCuadernillo)
            .HasForeignKey(cic => cic.ConqID)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .HasOne(cic => cic.CoicItemCuadernillo)
            .WithMany(ic => ic.ItcuConquistadores)
            .HasForeignKey(cic => cic.ItcuID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}