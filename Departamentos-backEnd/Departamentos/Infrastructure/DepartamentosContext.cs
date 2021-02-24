using Departamentos.Infrastructure.Persistents.Entities;
using Departamentos.Infrastructure.Persistents.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure
{
    public class DepartamentosContext : IdentityDbContext
    {
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Asunto> Asuntos { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Catedra> Catedras { get; set; }
        public virtual DbSet<Docente> Docentes { get; set; }
        public virtual DbSet<DocenteTomaCargo> DocenteTomaCargos { get; set; }
        public virtual DbSet<DocumentoMovimiento> DocumentoMovimientos { get; set; }
        public virtual DbSet<Entidad> Entidades { get; set; }
        public virtual DbSet<EstadoCargo> EstadoCargos { get; set; }
        public virtual DbSet<EstadoTramite> EstadoTramites { get; set; }
        public virtual DbSet<EtapaTramite> EtapaTramites { get; set; }
        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Pase> Pases { get; set; }
        public virtual DbSet<ReferenciaDocente> ReferenciaDocentes { get; set; }
        public virtual DbSet<ReferenciaDocumento> ReferenciaDocumentos { get; set; }
        public virtual DbSet<ReferenciaEntidad> ReferenciaEntidades { get; set; }
        public virtual DbSet<TipoCargo> TipoCargos { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<TipoTramite> TipoTramites { get; set; }
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options)
          : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //add primary keys to entities:
            modelBuilder.Entity<Asignatura>().HasKey(key => key.Id);
            modelBuilder.Entity<Asunto>().HasKey(key => key.Id);
            modelBuilder.Entity<Cargo>().HasKey(key => key.Id);
            modelBuilder.Entity<Catedra>().HasKey(key => key.Id);
            modelBuilder.Entity<Docente>().HasKey(key => key.Id);
            modelBuilder.Entity<DocenteTomaCargo>().HasKey(key => key.Id);
            modelBuilder.Entity<DocumentoMovimiento>().HasKey(key => key.Id);
            modelBuilder.Entity<Entidad>().HasKey(key => key.Id);
            modelBuilder.Entity<EstadoCargo>().HasKey(key => key.Id);
            modelBuilder.Entity<EstadoTramite>().HasKey(key => key.Id);
            modelBuilder.Entity<EtapaTramite>().HasKey(key => key.Id);
            modelBuilder.Entity<Documento>().HasKey(key => key.Id);
            modelBuilder.Entity<Pase>().HasKey(key => key.Id);
            modelBuilder.Entity<ReferenciaDocente>().HasKey(key => key.Id);
            modelBuilder.Entity<ReferenciaDocumento>().HasKey(key => key.Id);
            modelBuilder.Entity<ReferenciaEntidad>().HasKey(key => key.Id);
            modelBuilder.Entity<TipoCargo>().HasKey(key => key.Id);
            modelBuilder.Entity<TipoDocumento>().HasKey(key => key.Id);
            modelBuilder.Entity<TipoTramite>().HasKey(key => key.Id);
            
        }
    }
}
