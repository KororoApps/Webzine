using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class DbCommentaireRepository : ICommentaireRepository
    {
        private readonly WebzineDbContext _context;
        public DbCommentaireRepository(WebzineDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ajoute un Commentaire à base de donnée
        /// </summary>
        /// <param name="commentaire"></param>
        public void Add(Commentaire commentaire)
        {
            if (commentaire == null)
            {
                throw new ArgumentNullException(nameof(commentaire));
            }

            _context.Commentaires
                .Add(commentaire);

            _context
                .SaveChanges();
        }

        /// <summary>
        /// Supprimme un commentaire de la base de donnée
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
        ///Renvoie le premier commentaire ayant l'id mise en paramètre
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
        /// Renvoie tout les commentaires
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
        /// Retourne les commentaires demandés (pour la pagination) triés selon la date de création (du plus récent à ancien)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindCommentaires(int offset, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
