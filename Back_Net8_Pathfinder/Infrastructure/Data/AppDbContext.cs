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
    public DbSet<ClaseConquistador> ClaseConquistadores { get; set; }
    public DbSet<Conquistador> Conquistadores { get; set; }
    public DbSet<ConquistadorEspecialidad> ConquistadorEspecialidades { get; set; }
    public DbSet<ConquistadorItemCuadernillo> ConquistadorItemsCuadernillo { get; set; }
    public DbSet<Cronograma> Cronogramas { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<FichaMedica> FichasMedicas { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }
    public DbSet<ItemCuadernillo> ItemsCuadernillo { get; set; }
    public DbSet<Parametro> Parametros { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Sesion> Sesiones { get; set; }
    public DbSet<Tipo> Tipos { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<TutorConquistador> TutorConquistadores { get; set; }
    public DbSet<Unidad> Unidades { get; set; }
    public DbSet<UnidadConquistador> UnidadConquistadores { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioRol> UsuarioRoles { get; set; }
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

        modelBuilder.Entity<ClaseConquistador>()
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

        modelBuilder.Entity<FichaMedica>()
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

        modelBuilder.Entity<UnidadConquistador>()
            .Property(u => u.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Usuario>()
            .Property(u => u.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<UsuarioRol>()
            .Property(r => r.AudiFechCrea)
            .HasDefaultValueSql("GETDATE()");
        #endregion

        #region [ PrimaryKeys ]
        #region [ ActividadConquistador ]
        modelBuilder.Entity<ActividadConquistador>()
            .HasKey(ac => new { ac.ActiId, ac.ConqId });
        #endregion

        #region [ Asistencia ]
        modelBuilder.Entity<Asistencia>()
            .HasKey(a => new { a.ConqId, a.AsisId });
        #endregion

        #region [ ClaseConquistador ]
        modelBuilder.Entity<ClaseConquistador>()
            .HasKey(a => new { a.ConqId, a.ClasId });
        #endregion

        #region [ ConquistadorEspecialidad ]
        modelBuilder.Entity<ConquistadorEspecialidad>()
            .HasKey(e => new { e.ConqId, e.EspeId });
        #endregion

        #region [ ConquistadorItemCuadernillo ]
        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .HasKey(e => new { e.ConqId, e.ClasId, e.ItcuId });
        #endregion

        #region [ Cronograma ]
        modelBuilder.Entity<Cronograma>()
            .HasKey(e => new { e.ClasId, e.ItcuId, e.CronAno });
        #endregion

        #region [ CuentaCorriente ]
        modelBuilder.Entity<CuentaCorriente>()
            .HasKey(cc => new { cc.ConqId, cc.CucoId });
        #endregion

        #region [ Especialidad ]
        modelBuilder.Entity<Especialidad>()
            .HasKey(e => new { e.CateId, e.EspeId });
        #endregion

        #region [ FichaMedica ]
        modelBuilder.Entity<FichaMedica>()
            .HasKey(e => new { e.ConqId, e.FimeId, e.FimeAnio });
        #endregion

        #region [ Inscripcion ]
        modelBuilder.Entity<Inscripcion>()
            .HasKey(i => new { i.ConqId, i.InscAnio });
        #endregion

        #region [ ItemCuadernillo ]
        modelBuilder.Entity<ItemCuadernillo>()
            .HasKey(i => new { i.ClasId, i.ItcuId });
        #endregion

        #region [ Sesion ]
        modelBuilder.Entity<Sesion>()
            .HasKey(s => new { s.UsuaId, s.SesiId });
        #endregion

        #region [ Tipo ]
        modelBuilder.Entity<Tipo>()
            .HasKey(t => new { t.TipoTabla, t.TipoId });
        #endregion

        #region [ TutorConquistador ]
        modelBuilder.Entity<TutorConquistador>()
            .HasKey(tc => new { tc.TutoId, tc.ConqId });
        #endregion

        #region [ UnidadConquistador ]
        modelBuilder.Entity<UnidadConquistador>()
            .HasKey(uc => new { uc.UnidId, uc.ConqId, uc.UncoAno });
        #endregion

        #region [ UsuarioRol ]
        modelBuilder.Entity<UsuarioRol>()
            .HasKey(ur => new { ur.UsuaId, ur.RoleId });
        #endregion
        #endregion

        #region [ ForeigKeys ]
        #region [ ActividadConquistador ]
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
            .WithMany(t => t.TipoActividades)
            .HasForeignKey(ac => new { ac.AccoTipoParticipacionTabla, ac.AccoTipoParticipacionId });
        #endregion

        #region [ Asistencia ]
        modelBuilder.Entity<Asistencia>()
            .HasOne(a => a.AsisConquistador)
            .WithMany(c => c.ConqAsistencias)
            .HasForeignKey(a => a.ConqId);
        #endregion

        #region [ ClaseConquistador ]
        modelBuilder.Entity<ClaseConquistador>()
            .HasOne(cc => cc.ClcoClase)
            .WithMany(c => c.ClasConquistadores)
            .HasForeignKey(cc => cc.ClasId);

        modelBuilder.Entity<ClaseConquistador>()
            .HasOne(cc => cc.ClcoConquistador)
            .WithMany(c => c.ConqClases)
            .HasForeignKey(cc => cc.ConqId);
        #endregion

        #region [ ConquistadorEspecialidad ]
        modelBuilder.Entity<ConquistadorEspecialidad>()
            .HasOne(ce => ce.CoesConquistador)
            .WithMany(c => c.ConqEspecialidades)
            .HasForeignKey(ce => ce.ConqId);

        modelBuilder.Entity<ConquistadorEspecialidad>()
            .HasOne(ce => ce.CoesEspecialidad)
            .WithMany(e => e.EspeConquistadores)
            .HasForeignKey(ce => new { ce.CateId, ce.EspeId });
        #endregion

        #region [ ConquistadorItemCuadernillo ]
        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .HasOne(cic => cic.CoicConquistador)
            .WithMany(c => c.ConqItemsCuadernillo)
            .HasForeignKey(cic => cic.ConqId);

        modelBuilder.Entity<ConquistadorItemCuadernillo>()
            .HasOne(cic => cic.CoicItemCuadernillo)
            .WithMany(ic => ic.ItcuConquistadores)
            .HasForeignKey(cic => new { cic.ClasId, cic.ItcuId });
        #endregion

        #region [ Cronograma ]
        modelBuilder.Entity<Cronograma>()
            .HasOne(c => c.CronItemCuadernillo)
            .WithMany(ic => ic.ItcuCronogramas)
            .HasForeignKey(c => new { c.ClasId, c.ItcuId });
        #endregion

        #region [ CuentaCorriente ]
        modelBuilder.Entity<CuentaCorriente>()
            .HasOne(cc => cc.CucoConquistador)
            .WithMany(c => c.ConqCuentaCorriente)
            .HasForeignKey(cc => new { cc.ConqId });
        #endregion

        #region [ Especialidad ]
        modelBuilder.Entity<Especialidad>()
            .HasOne(e => e.EspeCategoria)
            .WithMany(c => c.CateEspecialidades)
            .HasForeignKey(e => e.CateId);
        #endregion

        #region [ FichaMedica ]
        modelBuilder.Entity<FichaMedica>()
            .HasOne(fm => fm.FimeConquistador)
            .WithMany(c => c.ConqFichasMedicas)
            .HasForeignKey(e => e.ConqId);
        #endregion

        #region [ Inscripcion ]
        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.InscConquistador)
            .WithMany(c => c.ConqInscripciones)
            .HasForeignKey(i => i.ConqId);
        #endregion

        #region [ ItemCuadernillo ]
        modelBuilder.Entity<ItemCuadernillo>()
            .HasOne(ic => ic.ItcuClase)
            .WithMany(c => c.ClasItemsCuadernillo)
            .HasForeignKey(ic => ic.ClasId);
        #endregion

        #region [ Sesion ]
        modelBuilder.Entity<Sesion>()
            .HasOne(s => s.SesiUsuario)
            .WithMany(u => u.UsuaSesiones)
            .HasForeignKey(s => s.UsuaId);
        #endregion

        #region [ TutorConquistador ]
        modelBuilder.Entity<TutorConquistador>()
            .HasOne(tc => tc.TucoTutor)
            .WithMany(t => t.TutoConquistadores)
            .HasForeignKey(tc => tc.TutoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TutorConquistador>()
            .HasOne(tc => tc.TucoConquistador)
            .WithMany(c => c.ConqTutores)
            .HasForeignKey(tc => tc.ConqId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TutorConquistador>()
            .HasOne(tc => tc.TucoTipoParentesco)
            .WithMany(t => t.TipoParentescos)
            .HasForeignKey(tc => new { tc.TucoTipoParentescoTabla, tc.TucoTipoParentescoId });
        #endregion

        #region [ UnidadConquistador ]
        modelBuilder.Entity<UnidadConquistador>()
            .HasOne(uc => uc.UncoUnidad)
            .WithMany(u => u.UnidConquistadores)
            .HasForeignKey(uc => uc.UnidId);

        modelBuilder.Entity<UnidadConquistador>()
            .HasOne(uc => uc.UncoConquistador)
            .WithMany(c => c.ConqUnidades)
            .HasForeignKey(uc => uc.ConqId);
        #endregion

        #region [ Usuario ]
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.UsuaConquistador)
            .WithOne(p => p.PersUsuario)
            .HasForeignKey<Conquistador>(c => c.UsuaId);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.UsuaTutor)
            .WithOne(p => p.PersUsuario)
            .HasForeignKey<Tutor>(c => c.UsuaId);
        #endregion

        #region [ UsuarioRol ]
        modelBuilder.Entity<UsuarioRol>()
            .HasOne(ru => ru.UsroUsuario)
            .WithMany(u => u.UsuaRoles)
            .HasForeignKey(ru => ru.UsuaId);

        modelBuilder.Entity<UsuarioRol>()
            .HasOne(ru => ru.UsroRol)
            .WithMany(r => r.RoleUsuarios)
            .HasForeignKey(ru => ru.RoleId);
        #endregion
        #endregion
    }
}