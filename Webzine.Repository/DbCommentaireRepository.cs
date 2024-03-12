// <copyright file="DbCommentaireRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.EntitiesContext;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémente l'interface ICommentaireRepository en utilisant une base de données.
    /// </summary>
    public class DbCommentaireRepository(WebzineDbContext context) : ICommentaireRepository
    {
        private readonly WebzineDbContext context = context;

        /// <inheritdoc />
        public void Add(Commentaire commentaire)
        {
            commentaire.DateCreation = DateTime.Now;

            this.context.Add<Commentaire>(commentaire);

            this.context
                .SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Commentaire commentaire)
        {
            this.context.Commentaires
                .Remove(commentaire);

            this.context
                .SaveChanges();
        }

        /// <inheritdoc />
        public Commentaire Find(int idCommentaire)
        {
            return this.context.Commentaires
                .Include(c => c.Titre)
                .ThenInclude(t => t.Artiste)
                .AsNoTracking()
                .SingleOrDefault(t => t.IdCommentaire == idCommentaire);
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindAll()
        {
            return this.context.Commentaires
                .Include(c => c.Titre)
                .ThenInclude(t => t.Artiste)
                .AsNoTracking()
                .OrderByDescending(t => t.DateCreation)
                .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentairesByIdTitre(int id)
        {
            return this.context.Commentaires
                 .AsNoTracking()
                 .Where(c => c.Titre != null && c.Titre.IdTitre == id)
                 .OrderByDescending(c => c.DateCreation)
                 .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentaires(int offset, int limit)
        {
            return this.context.Commentaires
                .Include(c => c.Titre)
                .ThenInclude(t => t.Artiste)
                .AsNoTracking()
                .OrderByDescending(t => t.DateCreation)
                .Skip(offset)
                .Take(limit)
                .ToList();
        }
    }
}
