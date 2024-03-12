// <copyright file="DbArtisteRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.EntitiesContext;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémente l'interface IArtisteRepository en utilisant une base de données.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe DbArtisteRepository.
    /// </remarks>
    /// <param name="context">Le contexte de base de données.</param>
    public class DbArtisteRepository(WebzineDbContext context) : IArtisteRepository
    {
        private readonly WebzineDbContext context = context;

        /// <inheritdoc />
        public void Add(Artiste artiste)
        {
            ArgumentNullException.ThrowIfNull(artiste);

            this.context.Add<Artiste>(artiste);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Artiste artiste)
        {
            ArgumentNullException.ThrowIfNull(artiste);

            this.context.Artistes.Remove(artiste);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public Artiste Find(int idArtiste)
        {
            return this.context.Artistes.AsNoTracking()
                .Include(c => c.Titres)
                .Single(t => t.IdArtiste == idArtiste);
        }

        /// <inheritdoc />
        public Artiste FindByName(string nomArtiste)
        {
            return this.context.Artistes.AsNoTracking()
                .Include(c => c.Titres)
                .Single(t => t.Nom == nomArtiste);
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindAll()
        {
            return this.context.Artistes.AsNoTracking()
                .Include(c => c.Titres);
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            return this.context.Artistes.AsNoTracking()
                .OrderBy(t => t.Nom.ToLower())
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        /// <inheritdoc />
        public void Update(Artiste artiste)
        {
            this.context.Update<Artiste>(artiste);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> Search(string mot)
        {
            return this.context.Artistes.AsNoTracking()
                .Where(t => t.Nom.ToUpper().Contains(mot.ToUpper()))
                .OrderBy(c => c.Nom)
                .ToList();
        }
    }
}