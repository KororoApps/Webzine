using Webzine.Entity;

namespace Webzine.Repository.Contracts
{

    /// <summary>
    /// Interface définissant les opérations CRUD pour la gestion des titres.
    /// </summary>
    public interface ITitreRepository
    {

        /// <summary>
        /// Ajoute un titre à la base de données.
        /// </summary>
        /// <param name="titre">Le titre à ajouter.</param>
        void Add(Titre titre);

        /// <summary>
        /// Récupère le nombre total de titres dans la base de données.
        /// </summary>
        /// <returns>Le nombre total de titres.</returns>
        int Count();

        //// <summary>
        /// Supprime un titre de la base de données.
        /// </summary>
        /// <param name="titre">Le titre à supprimer.</param>
        void Delete(Titre titre);

        /// <summary>
        /// Recherche un titre par son ID.
        /// </summary>
        /// <param name="idTitre">L'ID du titre.</param>
        /// <returns>Le titre correspondant à l'ID spécifié.</returns>
        Titre Find(int idTitre);

        /// <summary>
        /// Retourne les titres demandés (pour la pagination) triés selon la date de création (du plus récent à ancien).
        /// </summary>
        /// <param name="offset">L'indice de départ pour la pagination.</param>
        /// <param name="limit">Le nombre d'éléments à récupérer.</param>
        /// <returns>Une collection de titres paginée et triée par date de création.</returns>
        IEnumerable<Titre> FindTitres(int offset, int limit);

        /// <summary>
        /// Retourne tous les titres.
        /// </summary>
        /// <returns>Une collection de tous les titres.</returns>
        IEnumerable<Titre> FindAll();

        List<Titre> FindTitresLesPlusLike(int longueurPeriode);

        /// <summary>
        /// Incrémente le nombre de lectures d'un titre.
        /// </summary>
        /// <param name="titre">Le titre pour lequel incrémenter le nombre de lectures.</param>
        void IncrementNbLectures(Titre titre);

        /// <summary>
        /// Incrémente le nombre de likes d'un titre.
        /// </summary>
        /// <param name="titre">Le titre pour lequel incrémenter le nombre de likes.</param>
        void IncrementNbLikes(Titre titre);

        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le mot recherché.
        /// </summary>
        /// <param name="mot">Le mot clé à rechercher.</param>
        /// <returns>Une liste de titres contenant le mot spécifié.</returns>
        IEnumerable<Titre> Search(string mot);

        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le style de musique cherché.
        /// </summary>
        /// <param name="libelle">Le style de musique à rechercher.</param>
        /// <returns>Une collection de titres contenant le style de musique spécifié.</returns>
        IEnumerable<Titre> SearchByStyle(string libelle);

        /// <summary>
        /// Met à jour un titre.
        /// </summary>
        /// <param name="titre">Le titre à mettre à jour.</param>
        void Update(Titre titre);
    }
}
