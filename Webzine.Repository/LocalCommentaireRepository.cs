// <copyright file="LocalCommentaireRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémente l'interface ICommentaireRepository pour la gestion des commentaires en mémoire locale.
    /// </summary>
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        /// <inheritdoc />
        public void Add(Commentaire commentaire)
        {
            // Génère un nouvel identifiant
            commentaire.IdCommentaire = DataFactory.Commentaires.Count + 1;
            commentaire.IdTitre = commentaire.Titre.IdTitre;

            // Ajoute le nouveau commentaire à la liste
            DataFactory.Commentaires.Add(commentaire);
        }

        /// <inheritdoc />
        public void Delete(Commentaire commentaire)
        {
                DataFactory.Commentaires.Remove(commentaire);
        }

        /// <inheritdoc />
        public Commentaire Find(int id)
        {
            return DataFactory.Commentaires
                .First(t => t.IdCommentaire == id);
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindAll()
        {
            return DataFactory.Commentaires
                .OrderByDescending(c => c.DateCreation)
                .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentairesByIdTitre(int id)
        {
            return DataFactory.Commentaires
                .Where(c => c.Titre != null && c.Titre.IdTitre == id)
                .OrderBy(c => c.DateCreation)
                .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentaires(int offset, int limit)
        {
            return DataFactory.Commentaires
                .OrderBy(t => t.DateCreation)
                .Skip(offset)
                .Take(limit)
                .ToList();
        }
    }
}
