using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class CommentaireRepository : ICommentaireRepository
    {
        private readonly WebzineDbContext _context;
        public CommentaireRepository(WebzineDbContext context)
        {
            _context = context;
        }
        public void Add(Commentaire commentaire)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprimme un commentaire de la base de donnée
        /// </summary>
        /// <param name="commentaire"></param>
        public void Delete(Commentaire commentaire)
        {
            _context.Remove(commentaire);
        }

        /// <summary>
        ///Renvoie le premier commentaire ayant l'id mise en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Commentaire Find(int id)
        {
            var Commentaire = _context.Commentaires.Include(c => c.Titre).Where(c => c.IdCommentaire == id).FirstOrDefault();
            if (Commentaire == null)
            {
                throw new ArgumentNullException(nameof(Commentaire));
            }
            return Commentaire;
        }

        /// <summary>
        /// Renvoie tout les commentaires
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindAll()
        {
            var allCommentaires = _context.Commentaires.Include(c => c.Titre).OrderBy(c => c.IdTitre).ThenBy(c => c.DateCreation).ToList();
            return allCommentaires;
        }
    }
}
