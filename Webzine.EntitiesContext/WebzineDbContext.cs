using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Webzine.Entity;

namespace Webzine.EntitiesContext
{
    public partial class WebzineDbContext: DbContext
    {
        public WebzineDbContext()
        {
        }

        public WebzineDbContext(DbContextOptions<WebzineDbContext>options):base(options) { }

        public virtual DbSet<Artiste> Artistes { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<Commentaire> Commentaires { get; set; }
        public virtual DbSet<Titre> Titres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(NLog.LogManager.GetCurrentClassLogger().Info, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=webzine;Username=postgres;Password=es");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste>(entity =>
            {
                entity.ToTable("Artiste");

                entity.HasIndex(a => a.IdArtiste,"IX_artiste_artiste_id").IsUnique();

                entity.Property(a => a.IdArtiste).IsRequired();
                entity.Property(a => a.Nom).HasMaxLength(50).HasColumnName("Nom de l'artiste").IsRequired();
                entity.Property(a => a.Biographie).IsRequired();

                entity.HasMany(a => a.Titres).WithOne(t => t.Artiste);
            }
            );

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.ToTable("Commentaire");

                entity.HasIndex(c => c.IdCommentaire, "IX_commentaire_commentaire_id").IsUnique();

                entity.Property(c => c.IdCommentaire).IsRequired();
                entity.Property(c => c.Auteur).HasMaxLength(30).HasColumnName("Nom").IsRequired();
                entity.Property(c => c.Contenu).HasMaxLength(1000).HasColumnName("Commentaire").IsRequired();
                entity.Property(c => c.DateCreation).HasColumnName("Date de création").IsRequired();

                entity.HasOne(c => c.Titre).WithMany(t => t.Commentaires);
            }
            );

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.HasIndex(s => s.IdStyle, "IX_style_style_id").IsUnique();

                entity.Property(s => s.IdStyle).IsRequired();
                entity.Property(s => s.Libelle).HasMaxLength(50).HasColumnName("Libellé").IsRequired();    
            }
            );

            modelBuilder.Entity<Titre>(entity =>
            {
                entity.ToTable("Titre");

                entity.HasIndex(t => t.IdTitre, "IX_titre_titre_id").IsUnique();

                entity.Property(t => t.IdTitre).IsRequired();
                entity.Property(t => t.Libelle).HasMaxLength(200).HasColumnName("Titre").IsRequired();
                entity.Property(t => t.Duree).HasColumnName("Durée en secondes").IsRequired();
                entity.Property(t => t.DateSortie).HasColumnName("Date de sortie").IsRequired();
                entity.Property(t => t.DateCreation).HasColumnName("Date de Création").IsRequired();
                entity.Property(t => t.NbLectures).HasColumnName("Nombre de lecture").IsRequired();
                entity.Property(t => t.NbLikes).HasColumnName("Nombre de likes").IsRequired();
                entity.Property(t => t.Album).IsRequired();
                entity.Property(t => t.Chronique).HasMaxLength(4000).IsRequired();
                entity.Property(t => t.UrlJaquette).HasColumnName("Jaquette de l'album").HasMaxLength(250).IsRequired();
                entity.Property(t => t.UrlEcoute).HasColumnName("URL d'écoute").HasMaxLength(250);

                entity.HasOne(t => t.Artiste).WithMany(a => a.Titres);
                entity.HasMany(t => t.Commentaires).WithOne(c => c.Titre);
                entity.HasMany(t => t.Styles).WithMany(s => s.Titres);
            }
            );

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
}
