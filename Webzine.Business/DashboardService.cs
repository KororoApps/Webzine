using Webzine.Business.Contracts;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Business
{
    public class DashboardService : IDashboardService
    {
        ITitreRepository _titreRepository;
        IStyleRepository _styleRepository;
        IArtisteRepository _artisteRepository;
        public DashboardService(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository)
        {
            _titreRepository = titreRepository;
            _styleRepository = styleRepository;
            _artisteRepository = artisteRepository;
        }

        /// <inheritdoc />
        public Artiste FindArtisteLePlusChronique()
        {
            return _artisteRepository.FindAll().Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres.Sum(t => t.Chronique != null ? 1 : 0))
                .First();
        }

        /// <inheritdoc />
        public Artiste FindArtisteLePlusTitresAlbumDistinct()
        {
            return _artisteRepository.FindAll().Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres
                .GroupBy(t => new { t.Album, t.Artiste })
                .Count())
                .First();
        }

        /// <inheritdoc />
        public Titre FindTitreLePlusLu()
        {
            return _titreRepository.FindAll()
                .OrderByDescending(t => t.NbLectures)
                .First();
        }

        /// <inheritdoc />
        public int NombreArtistes()
        {
            return _artisteRepository.FindAll().Count();
        }

        /// <inheritdoc />
        public int NombreBiographiesArtistes()
        {
            return _artisteRepository.FindAll().Count(a => !string.IsNullOrEmpty(a.Biographie));
        }

        /// <inheritdoc />
        public int NombreLectures()
        {
            return _titreRepository.FindAll().Sum(t => t.NbLectures);
        }

        /// <inheritdoc />
        public int NombreLikes()
        {
            return _titreRepository.FindAll()
                .Sum(t => t.NbLikes);
        }

        /// <inheritdoc />
        public int NombreStyles()
        {
            return _styleRepository.FindAll().Count();
        }

        /// <inheritdoc />
        public int NombreTitres()
        {
            return _titreRepository.FindAll()
                .Count();
        }
    }
}
