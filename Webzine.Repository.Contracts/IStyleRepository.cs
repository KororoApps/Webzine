using Webzine.Entity;

namespace Webzine.Repository.Contracts
{

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
        /// Trouve un style par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du style.</param>
        /// <returns>Le style correspondant à l'identifiant spécifié.</returns>
        Style Find(int id);

        /// <summary>
        /// Trouve tous les styles.
        /// </summary>
        /// <returns>Une collection de tous les styles.</returns>
        IEnumerable<Style> FindAll();

        /// <summary>
        /// Trouve les styles par leurs identifiants.
        /// </summary>
        /// <param name="ids">Une liste d'identifiants de styles.</param>
        /// <returns>Une collection de styles correspondant aux identifiants spécifiés.</returns>
        IEnumerable<Style> FindByIds(List<int> ids);

        /// <summary>
        /// Met à jour un style.
        /// </summary>
        /// <param name="style">Le style à mettre à jour.</param>
        void Update(Style style);

        /// <summary>
        /// Retourne le nombre de styles.
        /// </summary>
        /// <returns>Le nombre total de styles.</returns>
        public int NombreStyles();
    }
}
