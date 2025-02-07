﻿// <copyright file="LocalStyleRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémente l'interface IStyleRepository pour la gestion des styles  en mémoire locale.
    /// </summary>
    public class LocalStyleRepository : IStyleRepository
    {
        /// <inheritdoc />
        public void Add(Style style)
        {
            // Génère un nouvel identifiant
            style.IdStyle = DataFactory.Styles.Count + 2;

            // Ajoute le nouveau style à la liste
            DataFactory.Styles.Add(style);
        }

        /// <inheritdoc />
        public void Delete(Style style)
        {
            var styleASupprimer = DataFactory.Styles
                .SingleOrDefault(s => s.IdStyle == style.IdStyle);

            if (styleASupprimer != null)
            {
                DataFactory.Styles.Remove(styleASupprimer);
            }
        }

        /// <inheritdoc />
        public void Update(Style style)
        {
            var styleAEditer = DataFactory.Styles
                .SingleOrDefault(s => s.IdStyle == style.IdStyle);

            if (styleAEditer != null)
            {
                styleAEditer.Libelle = style.Libelle;
            }
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindAll()
        {
            return DataFactory.Styles;
        }

        /// <inheritdoc />
        public Style Find(int id)
        {
            return DataFactory.Styles
                 .SingleOrDefault(t => t.IdStyle == id);
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            return DataFactory.Styles
                .Where(s => ids.Contains(s.IdStyle))
                .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindStyles(int offset, int limit)
        {
            return DataFactory.Styles
                .OrderBy(c => c.Libelle.ToLower())
                .Skip(offset)
                .Take(limit)
                .ToList();
        }
    }
}
