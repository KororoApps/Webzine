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
            return _context.Artistes
                .Include(c => c.Titres)
                .AsNoTracking()
                .Single(t => t.IdArtiste == idArtiste);
        }

        /// <inheritdoc />
        public Artiste FindByName(string nomArtiste)
        {
            return _context.Artistes
                .Include(c => c.Titres).AsNoTracking()
                .Single(t => t.Nom == nomArtiste);
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindAll()
        {
            return _context.Artistes
                .Include(c => c.Titres)
                .AsNoTracking()  // Ajout de AsNoTracking ici
                .OrderBy(t => t.Nom.ToLower())
                .ToList();

        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(Artiste artiste)
        {
            _context.Update<Artiste>(artiste);

            _context.SaveChanges();
        }


        /// <inheritdoc />
        public Artiste FindArtisteLePlusChronique()
        {
            return _context.Artistes.AsNoTracking()
                .Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres.Sum(t => t.Chronique != null ? 1 : 0))
                .First();

        }

        /// <inheritdoc />
        public Artiste FindArtisteLePlusTitresAlbumDistinct()
        {
            return _context.Artistes
                .Include(a => a.Titres).AsNoTracking()
                .Where(a => a.Titres != null && a.Titres.Any())
                .OrderByDescending(a => a.Titres
                .Select(t => new { t.Album, t.Artiste })
                .Distinct()
                .Count())
                .First();

        }

        /// <inheritdoc />
        public int NombreBioArtistes()
        {
            return _context.Artistes
                .Count(a => !string.IsNullOrEmpty(a.Biographie));

        }

        /// <inheritdoc />
        public int NombreArtistes()
        {
            return _context.Artistes
                .Count();

       }

        /// <summary>
        /// Renvoie les résultats de la recherche coté artistes.
        public IEnumerable<Artiste> Search(string mot)
        {
            return _context.Artistes
                .Where(t => t.Nom.ToUpper().Contains(mot.ToUpper()))
                .OrderBy(c => c.Nom)
                .AsNoTracking()  // Ajout de AsNoTracking ici
                .ToList();

        }
    }
}