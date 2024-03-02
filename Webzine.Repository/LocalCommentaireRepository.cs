using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {

        /// <summary>
        /// Ajoute un Commentaire.
        /// </summary>
        /// <param name="commentaire"></param>
        public void Add(Commentaire commentaire)
        {
            // Génère un nouvel identifiant
            commentaire.IdCommentaire = DataFactory.Commentaires.Count + 1;

            // Ajoute le nouveau commentaire à la liste
            DataFactory.Commentaires.Add(commentaire);
        }

        /// <summary>
        /// Supprimme un commentaire.
        /// </summary>
        /// <param name="commentaire"></param>
        public void Delete(Commentaire commentaire)
        {
            // Recherche le commentaire dans la liste
            var commentaireASupprimer = DataFactory.Commentaires
                .FirstOrDefault(t => t.IdCommentaire == commentaire.IdCommentaire);

            // Supprime le commentaire s'il existe
            if (commentaireASupprimer != null)
            {
                DataFactory.Commentaires
                    .Remove(commentaireASupprimer);
            }
        }

        /// <summary>
        /// Renvoie le premier commentaire ayant l'id mise en paramètre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Commentaire Find(int id)
        {
            var commentaire = DataFactory.Commentaires
                .FirstOrDefault(t => t.IdCommentaire == id);

            return commentaire;
        }

        /// <summary>
        /// Renvoie une liste de commentaire par ordre de creation.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindAll()
        {
            List<Commentaire> commentaires = DataFactory.Commentaires;

            var orderedCommentaires = commentaires
                .OrderByDescending(c => c.DateCreation)
                .ToList();

            return orderedCommentaires;
        }

        /// <summary>
        /// Renvoie une liste de commentaire par ordre de creation.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindCommentairesByIdTitre(int id)
        {
            List<Commentaire> commentaires = DataFactory.Commentaires;

            var orderedCommentaires = commentaires
                .Where(c => c.Titre != null && c.Titre.IdTitre == id)
                .OrderBy(c => c.DateCreation)
                .ToList();

            return orderedCommentaires;
        }

        /// <summary>
        /// Retourne les commentaires demandés (pour la pagination) triés selon la date de création (du plus récent à ancien).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindCommentaires(int offset, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
