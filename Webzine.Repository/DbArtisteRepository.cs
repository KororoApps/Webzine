using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    /// <summary>
    /// Implémente l'interface IArtisteRepository en utilisant une base de données.
    /// </summary>
    public class DbArtisteRepository : IArtisteRepository
    {
        private readonly WebzineDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de la classe DbArtisteRepository.
        /// </summary>
        /// <param name="context">Le contexte de base de données.</param>
        public DbArtisteRepository(WebzineDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ajoute un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à ajouter.</param>
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
        /// Supprime un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à supprimer.</param>
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
        /// Renvoie le premier artiste ayant l'identifiant spécifié.
        /// </summary>
        /// <param name="idArtiste">L'identifiant de l'artiste.</param>
        /// <returns>L'artiste correspondant à l'identifiant.</returns>
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
        /// Renvoie tous les artistes.
        /// </summary>
        /// <returns>Une liste de tous les artistes.</returns>
        public IEnumerable<Artiste> FindAll()
        {
            var allArtistes = _context.Artistes
                .Include(c => c.Titres)
                .OrderBy(t => t.Nom)
                .ToList();

            return allArtistes;
        }

        /// <summary>
        /// Renvoie les artistes demandés (pour la pagination) triés selon le nom (du plus récent à l'ancien).
        /// </summary>
        /// <param name="offset">La position de départ pour la pagination.</param>
        /// <param name="limit">Le nombre maximum d'artistes à renvoyer.</param>
        /// <returns>Une liste d'artistes paginée et triée.</returns>
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à mettre à jour.</param>
        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }
        }

        /// <summary>
        /// Renvoie l'artiste le plus chroniqué.
        /// </summary>
        /// <returns>L'artiste le plus chroniqué.</returns>
        public Artiste FindArtisteLePlusChronique()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie l'artiste ayant le plus de titres provenant d'albums distincts.
        /// </summary>
        /// <returns>L'artiste ayant le plus de titres provenant d'albums distincts.</returns>
        public Artiste FindArtisteLePlusTitresAlbumDistinct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie le nombre de biographies d'artistes.
        /// </summary>
        /// <returns>Le nombre total de biographies d'artistes.</returns>
        public int NombreBioArtistes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie le nombre d'artistes.
        /// </summary>
        /// <returns>Le nombre total d'artistes.</returns>
        public int NombreArtistes()
        {
            throw new NotImplementedException();
        }
    }
}