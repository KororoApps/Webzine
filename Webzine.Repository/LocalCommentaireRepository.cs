using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        /// <inheritdoc />
        public void Add(Commentaire commentaire)
        {
            // Génère un nouvel identifiant
            commentaire.IdCommentaire = DataFactory.Commentaires.Count + 1;

            // Ajoute le nouveau commentaire à la liste
            DataFactory.Commentaires.Add(commentaire);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Commentaire Find(int id)
        {
            var commentaire = DataFactory.Commentaires
                .FirstOrDefault(t => t.IdCommentaire == id);

            return commentaire;
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindAll()
        {
            List<Commentaire> commentaires = DataFactory.Commentaires;

            var orderedCommentaires = commentaires
                .OrderByDescending(c => c.DateCreation)
                .ToList();

            return orderedCommentaires;
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentairesByIdTitre(int id)
        {
            List<Commentaire> commentaires = DataFactory.Commentaires;

            var orderedCommentaires = commentaires
                .Where(c => c.Titre != null && c.Titre.IdTitre == id)
                .OrderBy(c => c.DateCreation)
                .ToList();

            return orderedCommentaires;
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentaires(int offset, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
