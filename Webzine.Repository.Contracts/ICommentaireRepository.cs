using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    /// <summary>
    /// Interface définissant les opérations CRUD pour la gestion des commentaires.
    /// </summary>
    public interface ICommentaireRepository
    {
        // Ajoute un Commentaire.
        void Add(Commentaire commentaire);

        // Supprimme un commentaire.
        void Delete(Commentaire commentaire);

        // Renvoie le premier commentaire ayant l'id mise en paramètre.
        Commentaire Find(int idCommentaire);

        // Retourne les commentaires demandés (pour la pagination) triés selon la date de création (du plus récent à ancien).
        IEnumerable<Commentaire> FindCommentaires(int offset, int limit);

        // Renvoie tout les commentaires.
        IEnumerable<Commentaire> FindAll();

        // Renvoie une liste de commentaire par ordre de creation.
        IEnumerable<Commentaire> FindCommentairesByIdTitre(int id);
    }
}
