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
            
            commentaire.DateCreation = DateTime.Now;

            _context.Add<Commentaire>(commentaire);

            _context
                .SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Commentaire commentaire)
        {

            _context.Commentaires
                .Remove(commentaire);

            _context
                .SaveChanges();
        }

        /// <inheritdoc />
        public Commentaire Find(int idCommentaire)
        {
            return _context.Commentaires
                .Include(c => c.Titre)
                .Include(c => c.Titre.Artiste).AsNoTracking()
                .Single(t => t.IdCommentaire == idCommentaire);
        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindAll()
        {
            return _context.Commentaires
                .Include(c => c.Titre)
                .Include(c => c.Titre.Artiste).AsNoTracking()
                .OrderByDescending(t => t.DateCreation)
                .ToList();

        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentairesByIdTitre(int id)
        {
            return _context.Commentaires.AsNoTracking()
                 .Where(c => c.Titre != null && c.Titre.IdTitre == id)
                 .OrderByDescending(c => c.DateCreation)
                 .ToList();

        }

        /// <inheritdoc />
        public IEnumerable<Commentaire> FindCommentaires(int offset, int limit)
        {
            return _context.Commentaires
                .Include(c => c.Titre)
                .Include(c => c.Titre.Artiste).AsNoTracking()
                .AsNoTracking()  // Ajout de AsNoTracking ici
                .OrderByDescending(t => t.DateCreation)
                .Skip(offset)
                .Take(limit)
                .ToList();
        }
    }
}
