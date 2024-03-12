namespace Webzine.Business
{
    using Webzine.Business.Contracts;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémentation de l'interface IDashboardService pour la récupération d'informations liées au tableau de bord.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="DashboardService"/>.
    /// Constructeur de DashboardService prenant les dépendances du repository en tant que paramètres.
    /// </remarks>
    /// <param name="titreRepository">Le repository pour les opérations liées aux titres.</param>
    /// <param name="styleRepository">Le repository pour les opérations liées aux styles.</param>
    /// <param name="artisteRepository">Le repository pour les opérations liées aux artistes.</param>
    public class DashboardService(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository) : IDashboardService
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly IStyleRepository styleRepository = styleRepository;
        private readonly IArtisteRepository artisteRepository = artisteRepository;

        /// <inheritdoc />
        public Artiste FindArtisteLePlusChronique()
        {
            return this.artisteRepository.FindAll()
                .Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres?.Sum(t => t.Chronique != null ? 1 : 0))
                .First();
        }

        /// <inheritdoc />
        public Artiste FindArtisteLePlusTitresAlbumDistinct()
        {
            return this.artisteRepository.FindAll()
                .Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres?.Count)
                .First();
        }

        /// <inheritdoc />
        public Titre FindTitreLePlusLu()
        {
            return this.titreRepository.FindAll()
                .OrderByDescending(t => t.NbLectures)
                .First();
        }

        /// <inheritdoc />
        public int NombreArtistes()
        {
            return this.artisteRepository.FindAll()
                .Count();
        }

        /// <inheritdoc />
        public int NombreBiographiesArtistes()
        {
            return this.artisteRepository.FindAll()
                .Count(a => !string.IsNullOrEmpty(a.Biographie));
        }

        /// <inheritdoc />
        public int NombreLectures()
        {
            return this.titreRepository.FindAll()
                .Sum(t => t.NbLectures);
        }

        /// <inheritdoc />
        public int NombreLikes()
        {
            return this.titreRepository.FindAll()
                .Sum(t => t.NbLikes);
        }

        /// <inheritdoc />
        public int NombreStyles()
        {
            return this.styleRepository.FindAll()
                .Count();
        }

        /// <inheritdoc />
        public int NombreTitres()
        {
            return this.titreRepository.FindAll()
                .Count();
        }
    }
}
