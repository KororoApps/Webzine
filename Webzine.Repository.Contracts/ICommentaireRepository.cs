using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface ICommentaireRepository
    {
        // Ajoute un commentaire à la base de données
        void Add(Commentaire commentaire);

        // Supprime un commentaire de la base de données
        void Delete(Commentaire commentaire);

        // Recherche un commentaire par son ID
        Commentaire Find(int idCommentaire);

        //Retourne les commentaires demandés (pour la pagination) triés selon la date de création (du plus récent à ancien)
        IEnumerable<Commentaire> FindCommentaires(int offset, int limit);

        //Retourne tous les commentaires
        IEnumerable<Commentaire> FindAll();
    }
}
