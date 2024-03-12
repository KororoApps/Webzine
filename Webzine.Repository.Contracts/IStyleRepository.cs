// <copyright file="IStyleRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository.Contracts
{
    using Webzine.Entity;

    /// <summary>
    /// Interface définissant les opérations CRUD pour la gestion des styles.
    /// </summary>
    public interface IStyleRepository
    {
        /// <summary>
        /// Ajoute un style.
        /// </summary>
        /// <param name="style">Le style à ajouter.</param>
        void Add(Style style);

        /// <summary>
        /// Supprime un style.
        /// </summary>
        /// <param name="style">Le style à supprimer.</param>
        void Delete(Style style);

        /// <summary>
        /// Met à jour un style.
        /// </summary>
        /// <param name="style">Le style à mettre à jour.</param>
        void Update(Style style);

        /// <summary>
        /// Trouve tous les styles.
        /// </summary>
        /// <returns>Une collection de tous les styles.</returns>
        IEnumerable<Style> FindAll();

        /// <summary>
        /// Trouve un style par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du style.</param>
        /// <returns>Le style correspondant à l'identifiant spécifié.</returns>
        Style Find(int id);

        /// <summary>
        /// Trouve les styles par leurs identifiants.
        /// </summary>
        /// <param name="ids">Une liste d'identifiants de styles.</param>
        /// <returns>Une collection de styles correspondant aux identifiants spécifiés.</returns>
        IEnumerable<Style> FindByIds(List<int> ids);

        /// <summary>
        /// Recherche et retourne une liste paginée de styles.
        /// </summary>
        /// <param name="offset">L'indice de départ pour la pagination.</param>
        /// <param name="limit">Le nombre maximum d'éléments à retourner.</param>
        /// <returns>Une collection paginée de styles.</returns>
        IEnumerable<Style> FindStyles(int offset, int limit);
    }
}
