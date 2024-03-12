// <copyright file="ICommentaireRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository.Contracts
{
    using Webzine.Entity;

    /// <summary>
    /// Interface définissant les opérations CRUD pour la gestion des commentaires.
    /// </summary>
    public interface ICommentaireRepository
    {
        /// <summary>
        /// Ajoute un commentaire.
        /// </summary>
        /// <param name="commentaire">Le commentaire à ajouter.</param>
        void Add(Commentaire commentaire);

        /// <summary>
        /// Ajoute un commentaire.
        /// </summary>
        /// <param name="commentaire">Le commentaire à ajouter.</param>
        void Delete(Commentaire commentaire);

        /// <summary>
        /// Renvoie le premier commentaire ayant l'ID spécifié.
        /// </summary>
        /// <param name="idCommentaire">L'ID du commentaire.</param>
        /// <returns>Le commentaire correspondant à l'ID spécifié.</returns>
        Commentaire Find(int idCommentaire);

        /// <summary>
        /// Renvoie les commentaires demandés (pour la pagination) triés selon la date de création (du plus récent à l'ancien).
        /// </summary>
        /// <param name="offset">L'indice de départ pour la pagination.</param>
        /// <param name="limit">Le nombre d'éléments à récupérer.</param>
        /// <returns>Une collection de commentaires paginée et triée par date de création.</returns>
        IEnumerable<Commentaire> FindCommentaires(int offset, int limit);

        /// <summary>
        /// Renvoie tous les commentaires.
        /// </summary>
        /// <returns>Une collection de tous les commentaires.</returns>
        IEnumerable<Commentaire> FindAll();

        /// <summary>
        /// Renvoie une liste de commentaires par ordre de création pour un ID de titre spécifique.
        /// </summary>
        /// <param name="id">L'ID du titre pour lequel les commentaires sont demandés.</param>
        /// <returns>Une collection de commentaires triée par date de création pour l'ID de titre spécifié.</returns>
        IEnumerable<Commentaire> FindCommentairesByIdTitre(int id);
    }
}
