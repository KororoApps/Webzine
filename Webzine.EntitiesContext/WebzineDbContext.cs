using Microsoft.EntityFrameworkCore;
using Webzine.Entity;

namespace Webzine.EntitiesContext
{
    public partial class WebzineDbContext : DbContext
    {
        public WebzineDbContext()
        {
        }

        public WebzineDbContext(DbContextOptions<WebzineDbContext> options) : base(options) { }

        public virtual DbSet<Artiste> Artistes { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<Commentaire> Commentaires { get; set; }
        public virtual DbSet<Titre> Titres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(NLog.LogManager.GetCurrentClassLogger().Info, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste>(entity =>
            {
                entity.ToTable("Artiste");

                entity.HasIndex(a => a.IdArtiste, "IX_artiste_artiste_id").IsUnique();

                entity.Property(a => a.IdArtiste);
                entity.Property(a => a.Nom);
                entity.Property(a => a.Biographie);

                entity.HasMany(a => a.Titres).WithOne(t => t.Artiste);
            }
            );

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.ToTable("Commentaire");

                entity.HasIndex(c => c.IdCommentaire, "IX_commentaire_commentaire_id").IsUnique();

                entity.Property(c => c.IdCommentaire);
                entity.Property(c => c.Auteur);
                entity.Property(c => c.Contenu);
                entity.Property(c => c.DateCreation);

                entity.HasOne(c => c.Titre).WithMany(t => t.Commentaires);
            }
            );

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.HasIndex(s => s.IdStyle, "IX_style_style_id").IsUnique();

                entity.Property(s => s.IdStyle);
                entity.Property(s => s.Libelle);
            }
            );

            modelBuilder.Entity<Titre>(entity =>
            {
                entity.ToTable("Titre");

                entity.HasIndex(t => t.IdTitre, "IX_titre_titre_id").IsUnique();

                entity.Property(t => t.IdTitre);
                entity.Property(t => t.Libelle);
                entity.Property(t => t.Duree);
                entity.Property(t => t.DateSortie);
                entity.Property(t => t.DateCreation);
                entity.Property(t => t.NbLectures);
                entity.Property(t => t.NbLikes);
                entity.Property(t => t.Album);
                entity.Property(t => t.Chronique);
                entity.Property(t => t.UrlJaquette);
                entity.Property(t => t.UrlEcoute);

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
