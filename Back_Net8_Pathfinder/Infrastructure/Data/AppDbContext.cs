using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    #region [ Properties ]

    public DbSet<Actividad> Actividades { get; set; }
    public DbSet<ActividadConquistador> ActividadConquistadores { get; set; }
    public DbSet<Asistencia> Asistencias { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Clase> Clases { get; set; }
    public DbSet<Conquistador> Conquistadores { get; set; }
    public DbSet<ConquistadorEspecialidad> ConquistadorEspecialidades { get; set; }
    public DbSet<ConquistadorItemCuadernillo> ConquistadorItemsCuadernillo { get; set; }
    public DbSet<Cronograma> Cronogramas { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }
    public DbSet<ItemCuadernillo> ItemsCuadernillo { get; set; }
    public DbSet<Parametro> Parametros { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<RolUsuario> RolesUsuario { get; set; }
    public DbSet<Sesion> Sesiones { get; set; }
    public DbSet<Tipo> Tipos { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<TutorConquistador> TutorConquistadores { get; set; }
    public DbSet<Unidad> Unidades { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region [ AudiFechCrea_Default ]

        modelBuilder.Entity<Actividad>()
            .Property(a => a.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<ActividadConquistador>()
            .Property(ac => ac.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Asistencia>()
            .Property(a => a.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Categoria>()
            .Property(c => c.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Clase>()
            .Property(c => c.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Conquistador>()
            .Property(c => c.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<ConquistadorEspecialidad>()
            .Property(c => c.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .Property(ci => ci.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Cronograma>()
            .Property(c => c.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Especialidad>()
            .Property(e => e.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Inscripcion>()
            .Property(i => i.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<ItemCuadernillo>()
            .Property(ic => ic.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Parametro>()
            .Property(p => p.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Rol>()
            .Property(r => r.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<RolUsuario>()
            .Property(r => r.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Sesion>()
            .Property(s => s.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<Tipo>()
            .Property(s => s.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<Tutor>()
            .Property(s => s.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<TutorConquistador>()
            .Property(s => s.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Unidad>()
            .Property(u => u.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Usuario>()
            .Property(u => u.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        #endregion

        #region [ ForeigKeys ]

        // ActividadConquistador
        modelBuilder.Entity<ActividadConquistador>()
            .HasKey(ac => new { ac.AccoId, ac.ActiId, ac.ConqId });

        modelBuilder.Entity<ActividadConquistador>()
            .HasOne(ac => ac.AccoActividad)
            .WithMany(a => a.ActiParticipantes)
            .HasForeignKey(ac => ac.ActiId);

        modelBuilder.Entity<ActividadConquistador>()
            .HasOne(ac => ac.AccoConquistador)
            .WithMany(c => c.ConqActividades)
            .HasForeignKey(ac => ac.ConqId);

        modelBuilder.Entity<ActividadConquistador>()
            .HasOne(ac => ac.AccoTipoParticipacion)
            .WithMany(t => t.TipoParticipaciones)
            .HasForeignKey(ac => ac.AccoTipoParticipacionId);

        //Asistencia
        modelBuilder.Entity<Asistencia>()
            .HasKey(a => new { a.ConqId, a.AsisId });

        modelBuilder.Entity<Asistencia>()
            .HasOne(a => a.AsisConquistador)
            .WithMany(c => c.ConqAsistencias)
            .HasForeignKey(a => a.ConqId);

        //Conquistador
        modelBuilder.Entity<Conquistador>()
            .HasOne(c => c.ConqClase)
            .WithMany(c => c.ClasConquistadores)
            .HasForeignKey(c => c.ClasId);

        modelBuilder.Entity<Conquistador>()
            .HasOne(c => c.ConqUnidad)
            .WithMany(u => u.UnidConquistadores)
            .HasForeignKey(c => c.UnidId);
        
        // ConquistadorEspecialidad
        modelBuilder.Entity<ConquistadorEspecialidad>()
            .HasKey(e => new { e.CoesId, e.ConqId, e.EspeId });
        
        modelBuilder.Entity<ConquistadorEspecialidad>()
            .HasOne(ce => ce.CoesConquistador)
            .WithMany(c => c.ConqEspecialidades)
            .HasForeignKey(ce => ce.ConqId);

        modelBuilder.Entity<ConquistadorEspecialidad>()
            .HasOne(ce => ce.CoesEspecialidad)
            .WithMany(e => e.EspeConquistadores)
            .HasForeignKey(ce => ce.EspeId);

        //ConquistadorItemCuadernillo
        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .HasOne(cic => cic.CoicConquistador)
            .WithMany(c => c.ConqItemsCuadernillo)
            .HasForeignKey(cic => cic.ConqId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .HasOne(cic => cic.CoicItemCuadernillo)
            .WithMany(ic => ic.ItcuConquistadores)
            .HasForeignKey(cic => cic.ItcuId)
            .OnDelete(DeleteBehavior.NoAction);
        
        // Cronograma
        modelBuilder.Entity<Cronograma>()
            .HasOne(c => c.CronItem)
            .WithMany(ic => ic.ItcuCronogramas)
            .HasForeignKey(c => c.ItcuId);
        
        // Especialidad
        modelBuilder.Entity<Especialidad>()
            .HasOne(e => e.EspeCategoria)
            .WithMany(c => c.CateEspecialidades)
            .HasForeignKey(e => e.CateId);
        
        // Inscripcion
        modelBuilder.Entity<Inscripcion>()
            .HasKey(i => new { i.ConqId, i.InscId });
        
        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.InscConquistador)
            .WithMany(c => c.ConqInscripciones)
            .HasForeignKey(i => i.ConqId);
        
        // ItemCuadernillo
        modelBuilder.Entity<ItemCuadernillo>()
            .HasOne(ic => ic.ItcuClase)
            .WithMany(c => c.ClasItemsCuadernillo)
            .HasForeignKey(ic => ic.ClasId);

        // RolUsuario
        modelBuilder.Entity<RolUsuario>()
            .HasKey(ru => new { ru.RousId, ru.UsuaId, ru.RoleId });

        modelBuilder.Entity<RolUsuario>()
            .HasOne(ru => ru.RousUsuario)
            .WithMany(u => u.UsuaRoles)
            .HasForeignKey(ru => ru.UsuaId);

        modelBuilder.Entity<RolUsuario>()
            .HasOne(ru => ru.RousRol)
            .WithMany(r => r.RoleUsuarios)
            .HasForeignKey(ru => ru.RoleId);
        
        // Sesion
        modelBuilder.Entity<Sesion>()
            .HasKey(s => new { s.UsuaId, s.SesiId });

        modelBuilder.Entity<Sesion>()
            .HasOne(s => s.SesiUsuario)
            .WithMany(u => u.UsuaSesiones)
            .HasForeignKey(s => s.UsuaId);
        
        // TutorConquistador
        modelBuilder.Entity<TutorConquistador>()
            .HasKey(tc => new { tc.TucoId, tc.TutoId, tc.ConqId });
        
        modelBuilder.Entity<TutorConquistador>()
            .HasOne(tc => tc.TucoParentesco)
            .WithMany(t => t.TipoParentescos)
            .HasForeignKey(tc => tc.TucoParentescoId);

        modelBuilder.Entity<TutorConquistador>()
            .HasOne(tc => tc.TucoTutor)
            .WithMany(t => t.TutoConquistadores)
            .HasForeignKey(tc => tc.TutoId);

        modelBuilder.Entity<TutorConquistador>()
            .HasOne(tc => tc.TucoConquistador)
            .WithMany(c => c.ConqTutores)
            .HasForeignKey(tc => tc.ConqId);

        // Usuario
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.UsuaConquistador)
            .WithOne(c => c.ConqUsuario)
            .HasForeignKey<Conquistador>(c => c.UsuaId);

        #endregion
    }
}