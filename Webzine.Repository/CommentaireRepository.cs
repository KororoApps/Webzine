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

        public void Delete(Commentaire commentaire)
        {
            _context.Remove(commentaire);
        }

        public Commentaire Find(int id)
        {
            var Commentaire = _context.Commentaires.Include(c => c.Titre).Where(c => c.IdCommentaire == id).First();
            return Commentaire;
        }

        public IEnumerable<Commentaire> FindAll()
        {
            var allCommentaires = _context.Commentaires.Include(c => c.Titre).OrderBy(c => c.IdTitre).ThenBy(c => c.DateCreation).ToList();
            return allCommentaires;
        }
    }
}
