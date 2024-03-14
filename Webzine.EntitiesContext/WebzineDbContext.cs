// <copyright file="WebzineDbContext.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.EntitiesContext
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.Entity;

    /// <summary>
    /// Contexte de la base de données Webzine.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="WebzineDbContext"/> avec des options spécifiques.
    /// </remarks>
    /// <param name="options">Options du contexte.</param>
    public partial class WebzineDbContext(DbContextOptions<WebzineDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Obtient ou définit la table des artistes.
        /// </summary>
        public virtual DbSet<Artiste> Artistes { get; set; }

        /// <summary>
        /// Obtient ou définit la table des styles.
        /// </summary>
        public virtual DbSet<Style> Styles { get; set; }

        /// <summary>
        /// Obtient ou définit la table des commentaires.
        /// </summary>
        public virtual DbSet<Commentaire> Commentaires { get; set; }

        /// <summary>
        /// Obtient ou définit la table des titres.
        /// </summary>
        public virtual DbSet<Titre> Titres { get; set; }

        /// <summary>
        /// Configurations spécifiques au moment de la configuration.
        /// </summary>
        /// <param name="optionsBuilder">Constructeur d'options de DbContext.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(NLog.LogManager.GetCurrentClassLogger().Info, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        /// <summary>
        /// Configurations spécifiques du modèle.
        /// </summary>
        /// <param name="modelBuilder">Constructeur de modèle.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de l'entité Artiste
            modelBuilder.Entity<Artiste>(entity =>
            {
                entity.ToTable("Artiste");

                // Définir la clé primaire
                entity.HasKey(a => a.IdArtiste);

                // Définir l'index unique
                entity.HasIndex(a => a.IdArtiste).IsUnique().HasName("IX_artiste_artiste_id");

                // Configuration de l'incrémentation automatique de l'ID
                entity.Property(a => a.IdArtiste).UseIdentityColumn();

                entity.Property(a => a.Nom);
                entity.Property(a => a.Biographie);

                entity.HasMany(a => a.Titres).WithOne(c => c.Artiste).HasForeignKey(t => t.IdArtiste).IsRequired();
            });

            // Configuration de l'entité Commentaire
            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.ToTable("Commentaire");

                entity.HasIndex(c => c.IdCommentaire, "IX_commentaire_commentaire_id").IsUnique();

                // Configuration de l'incrémentation automatique de l'ID
                entity.Property(a => a.IdCommentaire).UseIdentityColumn();

                entity.Property(c => c.Auteur);
                entity.Property(c => c.Contenu);
                entity.Property(c => c.DateCreation);

                entity.HasOne(c => c.Titre).WithMany(c => c.Commentaires).HasForeignKey(c => c.IdTitre).IsRequired();
            });

            // Configuration de l'entité Style
            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.HasIndex(s => s.IdStyle, "IX_style_style_id").IsUnique();

                // Configuration de l'incrémentation automatique de l'ID
                entity.Property(a => a.IdStyle).UseIdentityColumn();

                entity.Property(s => s.Libelle);

                entity.HasMany(s => s.Titres);
            });

            // Configuration de l'entité Titre
            modelBuilder.Entity<Titre>(entity =>
            {
                entity.ToTable("Titre");

                entity.HasIndex(t => t.IdTitre, "IX_titre_titre_id").IsUnique();

                // Configuration de l'incrémentation automatique de l'ID
                entity.Property(a => a.IdTitre).UseIdentityColumn();

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

                entity.HasOne(t => t.Artiste).WithMany(a => a.Titres).HasForeignKey(t => t.IdArtiste).IsRequired();
                entity.HasMany(t => t.Commentaires).WithOne(c => c.Titre).HasForeignKey(c => c.IdTitre).IsRequired();
                entity.HasMany(t => t.Styles);
            });

            /// <summary>
            /// Configurations partielles du modèle.
            /// </summary>
            /// <param name="modelBuilder">Constructeur de modèle.</param>
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
