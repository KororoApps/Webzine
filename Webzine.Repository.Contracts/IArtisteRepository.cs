// <copyright file="IArtisteRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository.Contracts
{
    using Webzine.Entity;

    /// <summary>
    /// Interface définissant les opérations CRUD pour la gestion des artistes.
    /// </summary>
    public interface IArtisteRepository
    {
        /// <summary>
        /// Ajoute un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à ajouter.</param>
        void Add(Artiste artiste);

        /// <summary>
        /// Supprime un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à supprimer.</param>
        void Delete(Artiste artiste);

        /// <summary>
        /// Renvoie le premier artiste ayant l'identifiant spécifié.
        /// </summary>
        /// <param name="idArtiste">L'identifiant de l'artiste.</param>
        /// <returns>L'artiste correspondant à l'identifiant spécifié.</returns>
        Artiste Find(int idArtiste);

        /// <summary>
        /// Renvoie tous les artistes.
        /// </summary>
        /// <returns>Une collection d'artistes.</returns>
        IEnumerable<Artiste?> FindAll();

        /// <summary>
        /// Renvoie les artistes demandés (pour la pagination) triés selon le nom (du plus récent à l'ancien).
        /// </summary>
        /// <param name="offset">L'indice de départ pour la pagination.</param>
        /// <param name="limit">Le nombre d'éléments à récupérer.</param>
        /// <returns>Une collection d'artistes paginée et triée par nom.</returns>
        IEnumerable<Artiste?> FindArtistes(int offset, int limit);

        /// <summary>
        /// Met à jour un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à mettre à jour.</param>
        void Update(Artiste artiste);

        /// <summary>
        /// Renvoie le premier artiste ayant le nom spécifié.
        /// </summary>
        /// <param name="nomArtiste">Le nom de l'artiste à rechercher.</param>
        /// <returns>L'artiste correspondant au nom spécifié.</returns>
        Artiste? FindByName(string nomArtiste);

        /// <summary>
        /// Recherche des artistes correspondant à un mot-clé.
        /// </summary>
        /// <param name="mot">Le mot-clé à utiliser pour la recherche.</param>
        /// <returns>Une collection d'artistes correspondant à la recherche.</returns>
        IEnumerable<Artiste?> Search(string mot);
    }
}
