using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{

    /// <summary>
    /// Implémente l'interface ICommentaireRepository en utilisant une base de données.
    /// </summary>
    public class DbCommentaireRepository(WebzineDbContext context) : ICommentaireRepository
    {
        private readonly WebzineDbContext _context = context;

        /// <summary>
        /// Ajoute un Commentaire.
        /// </summary>
        /// <param name="commentaire"></param>
        public void Add(Commentaire commentaire)
        {
            if (commentaire == null)
            {
                throw new ArgumentNullException(nameof(commentaire));
            }

            commentaire.DateCreation = DateTime.Now;

            _context.Add<Commentaire>(commentaire);

            _context
                .SaveChanges();
        }

        /// <summary>
        /// Supprimme un commentaire.
        /// </summary>
        /// <param name="commentaire"></param>
        public void Delete(Commentaire commentaire)
        {
            if (commentaire == null)
            {
                throw new ArgumentNullException(nameof(commentaire));
            }

            _context.Commentaires
                .Remove(commentaire);

            _context
                .SaveChanges();
        }

        /// <summary>
        ///Renvoie le premier commentaire ayant l'id mise en paramètre.
        /// </summary>
        /// <param name="idCommentaire"></param>
        /// <returns></returns>
        public Commentaire Find(int idCommentaire)
        {
            var commentaie = _context.Commentaires
                .Include(c => c.Titre)
                .Include(c => c.Titre.Artiste)
                .SingleOrDefault(t => t.IdCommentaire == idCommentaire);

            if (commentaie == null)
            {
                //Exception si on ne trouve pas d'artiste correspondant
                throw new ArgumentNullException();
            }

            return commentaie;
        }

        /// <summary>
        /// Renvoie tout les commentaires.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindAll()
        {
            var allCommentaires = _context.Commentaires
                .Include(c => c.Titre)
                .Include(c => c.Titre.Artiste)
                .OrderByDescending(t => t.DateCreation)
                .ToList();

            return allCommentaires;
        }

        /// <summary>
        /// Renvoie une liste de commentaire par ordre de creation.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindCommentairesByIdTitre(int id)
        {
            var orderedCommentaires = _context.Commentaires
                 .Where(c => c.Titre != null && c.Titre.IdTitre == id)
                 .OrderByDescending(c => c.DateCreation)
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
