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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindAll()
        {
            var allCommentaires = _context.Commentaires
                .Include(c => c.Titre)
                .Include(c => c.Titre.Artiste)
                .OrderByDescending(t => t.DateCreation)
                .ToList();

            return allCommentaires;
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentairesByIdTitre(int id)
        {
            var orderedCommentaires = _context.Commentaires
                 .Where(c => c.Titre != null && c.Titre.IdTitre == id)
                 .OrderByDescending(c => c.DateCreation)
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
