using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    /// <summary>
    /// Implémente l'interface IArtisteRepository en utilisant une base de données.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe DbArtisteRepository.
    /// </remarks>
    /// <param name="context">Le contexte de base de données.</param>
    public class DbArtisteRepository(WebzineDbContext context) : IArtisteRepository
    {
        private readonly WebzineDbContext _context = context;

        /// <inheritdoc />
        public void Add(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }

            _context.Add<Artiste>(artiste);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }

            _context.Artistes
                 .Remove(artiste);

            _context.SaveChanges();
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Artiste FindByName(string nomArtiste)
        {
            var artiste = _context.Artistes
                .Include(c => c.Titres)
                .SingleOrDefault(t => t.Nom == nomArtiste);

            if (artiste == null)
            {
                //Exception si on ne trouve pas d'artiste correspondant
                throw new ArgumentNullException();
            }

            return artiste;
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindAll()
        {
            var allArtistes = _context.Artistes
                .Include(c => c.Titres)
                .OrderBy(t => t.Nom.ToLower())
                .ToList();

            return allArtistes;
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }
        }

        /// <inheritdoc />
        public Artiste FindArtisteLePlusChronique()
        {
            var artiste = _context.Artistes
                .Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres.Sum(t => t.Chronique != null ? 1 : 0))
                .FirstOrDefault();

            if (artiste != null)
            {
                return artiste;
            }
            else
            {
                throw new Exception("Il n'y a pas d'artiste avec des chroniques");
            }
        }

        /// <inheritdoc />
        public Artiste FindArtisteLePlusTitresAlbumDistinct()
        {
            var artiste = _context.Artistes
                .Include(a => a.Titres)
                .Where(a => a.Titres != null && a.Titres.Any())
                .OrderByDescending(a => a.Titres
                .Select(t => new { t.Album, t.Artiste })
                .Distinct()
                .Count())
                .FirstOrDefault();

            if (artiste != null)
            {
                return artiste;
            }
            else
            {
                throw new Exception("Il n'y a pas d'artiste avec des titres dans des albums distincts");
            }
        }

        /// <inheritdoc />
        public int NombreBioArtistes()
        {
            var nombreArtiste = _context.Artistes
                .Count(a => !string.IsNullOrEmpty(a.Biographie));

            return nombreArtiste;
        }

        /// <inheritdoc />
        public int NombreArtistes()
        {
            var nombreArtiste = _context.Artistes
                .Count();

            return nombreArtiste;
        }

        /// <inheritdoc />
        public List<Artiste> Search(string mot)
        {
            List<Artiste> artistes = _context.Artistes.Where(t => t.Nom.Contains(mot)).OrderBy(c => c.Nom).ToList();
            if (artistes.Count == 0)
            {
                artistes = new List<Artiste>();
            }

            return artistes;
        }
    }
}