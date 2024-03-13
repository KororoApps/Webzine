// <copyright file="DbStyleRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.EntitiesContext;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémente l'interface IStyleRepository pour la gestion des styles en utilisant une base de données.
    /// </summary>
    public class DbStyleRepository(WebzineDbContext context) : IStyleRepository
    {
        // Contexte de base de données pour accéder aux données
        private readonly WebzineDbContext context = context;

        /// <inheritdoc />
        public void Add(Style style)
        {
            this.context.Add<Style>(style);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Style style)
        {
            this.context.Styles.Remove(style);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(Style style)
        {
            this.context.Update<Style>(style);

            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindAll()
        {
            return this.context.Styles;
        }

        /// <inheritdoc />
        public Style Find(int id)
        {
            return this.context.Styles
                .Include(s => s.Titres)
                .Where(s => s.IdStyle == id)
                .First();
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            return this.context.Styles
                .Where(s => ids.Contains(s.IdStyle))
                .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindStyles(int offset, int limit)
        {
            return this.context.Styles
               .OrderBy(c => c.Libelle.ToLower())
               .Skip(offset)
               .Take(limit)
               .ToList();
        }
    }
}
