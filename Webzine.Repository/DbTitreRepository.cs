// <copyright file="DbTitreRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.EntitiesContext;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémente l'interface ITitreRepository pour les opérations liées à la gestion des titres dans la base de donnée.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe DbTitreRepository.
    /// </remarks>
    /// <param name="context">Le context de base de donnée.</param>
    public class DbTitreRepository(WebzineDbContext context) : ITitreRepository
    {
        private readonly WebzineDbContext context = context;

        /// <inheritdoc />
        public void Add(Titre titre)
        {
            titre.DateCreation = DateTime.Now;

            this.context.Add<Titre>(titre);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public int Count()
        {
            return this.context.Titres.Count();
        }

        /// <inheritdoc />
        public void Delete(Titre titre)
        {
            this.context.Titres.Remove(titre);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(Titre titre)
        {
            this.context.Update<Titre>(titre);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public Titre? Find(int idTitre)
        {
            return this.context.Titres
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.Styles)
                .SingleOrDefault(t => t.IdTitre == idTitre);
        }

        /// <inheritdoc />
        public IEnumerable<Titre?> FindAll()
        {
            return this.context.Titres.AsNoTracking()
                .Include(t => t.Artiste).AsNoTracking();
        }

        /// <inheritdoc />
        public IEnumerable<Titre?> FindTitres(int offset, int limit)
        {
            return this.context.Titres.AsNoTracking()
                .Include(t => t.Artiste).AsNoTracking()
                .Include(t => t.Styles).AsNoTracking()
                .Include(t => t.Commentaires).AsNoTracking()
                .OrderByDescending(t => t.DateCreation)
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        /// <inheritdoc />
        public List<Titre?> FindTitresLesPlusLike(int longueurPeriode)
        {
            // Calcul de la date à partir de laquelle les titres doivent être récupérés
            var dateDebutPeriode = DateTime.UtcNow.AddMonths(-longueurPeriode);

            return this.context.Titres.AsNoTracking()
                .Include(t => t.Artiste).AsNoTracking()
                .Include(t => t.Styles).AsNoTracking()
                .Where(t => t.DateCreation >= dateDebutPeriode) // Filtrer les titres créés pendant cette période
                .OrderByDescending(t => t.NbLikes)
                .Take(3)
                .ToList();
        }

        /// <inheritdoc />
        public void IncrementNbLectures(Titre titre)
        {
            // Charger le titre depuis la base de donnée avec suivi des modifications
            Titre existingTitre = this.context.Titres.Find(titre.IdTitre);

            if (existingTitre != null)
            {
                existingTitre.NbLectures++;

                this.context.SaveChanges();
            }
        }

        /// <inheritdoc />
        public void IncrementNbLikes(Titre titre)
        {
            // Charger le titre depuis la base de donnée avec suivi des modifications
            Titre existingTitre = this.context.Titres.Find(titre.IdTitre);

            if (existingTitre != null)
            {
                existingTitre.NbLikes++;

                this.context.SaveChanges();
            }
        }

        /// <inheritdoc />
        public IEnumerable<Titre?> Search(string mot)
        {
            return this.context.Titres.AsNoTracking()
                .Include(t => t.Artiste).AsNoTracking()
                .Where(t => t.Libelle.ToUpper().Contains(mot.ToUpper()))
                .OrderBy(c => c.Libelle)
                .ToList();        }

        /// <inheritdoc />
        public IEnumerable<Titre?> SearchByStyle(string libelle)
        {
            return this.context.Titres.AsNoTracking()
                .Include(t => t.Artiste).AsNoTracking()
                .Where(t => t.Styles.Any(s => s.Libelle.Equals(libelle)))
                .OrderByDescending(c => c.Libelle)
                .ToList();
        }
    }
}
