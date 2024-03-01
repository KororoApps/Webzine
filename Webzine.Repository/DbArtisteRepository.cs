using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class DbArtisteRepository : IArtisteRepository
    {
        private readonly WebzineDbContext _context;
        public DbArtisteRepository(WebzineDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ajoute un Artiste à base de donnée
        /// </summary>
        /// <param name="artiste"></param>
        public void Add(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }

            _context.Artistes
                .Add(artiste);

            _context
                .SaveChanges();
        }

        /// <summary>
        /// Supprimme un artiste de la base de donnée
        /// </summary>
        /// <param name="artiste"></param>
        public void Delete(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }

            _context.Artistes
                .Remove(artiste);

            _context
                .SaveChanges();
        }

        /// <summary>
        ///Renvoie le premier Artiste ayant l'id mise en paramètre
        /// </summary>
        /// <param name="idArtiste"></param>
        /// <returns></returns>

        public Artiste Find(int idArtiste)
        {
            var artiste = _context.Artistes
                .Include(c => c.Titres)
                .SingleOrDefault(t => t.IdArtiste == idArtiste);

            if (artiste == null)
            {
                //Exception si on ne trouve pas d'artiste correspondant
                throw new ArgumentNullException();
            }

            return artiste;
        }

        /// <summary>
        /// Renvoie tous les Artistes
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Artiste> FindAll()
        {
            var allArtistes = _context.Artistes
                .OrderBy(t => t.Nom)
                .ToList();

            return allArtistes;
        }

        /// <summary>
        /// Retourne les artistes demandés (pour la pagination) triés selon  le nom(du plus récent à ancien)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour un Artiste
        /// </summary>
        /// <returns></returns>
        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }
        }
    }
}