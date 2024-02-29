using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class ArtisteRepository : IArtisteRepository
    {
        private readonly WebzineDbContext _context;
        public ArtisteRepository(WebzineDbContext context)
        {
            _context = context;
        }
        public void Add(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }

            _context.Artistes.Add(artiste);
            _context.SaveChanges();
        }

        public void Delete(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }

            _context.Artistes.Remove(artiste);
            _context.SaveChanges();
        }

        public Artiste Find(int id)
        {
            var artiste = _context.Artistes.Include(a => a.Titres).FirstOrDefault(a => a.IdArtiste == id);

            if (artiste == null)
            {
                //Exception si on ne trouve pas d'artiste correspondant
                throw new ArgumentNullException();
            }

            return artiste;
        }


        public IEnumerable<Artiste> FindAll()
        {
            var allCommentaires = _context.Artistes.Include(a => a.Titres).OrderBy(a => a.Nom).ToList();
            return allCommentaires;
        }

        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }

            _context.Artistes.Update(artiste);
            _context.SaveChanges();
        }
    }
}