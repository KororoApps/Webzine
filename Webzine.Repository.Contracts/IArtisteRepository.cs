using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    /// <summary>
    /// Interface définissant les opérations CRUD pour la gestion des artistes.
    /// </summary>
    public interface IArtisteRepository
    {
        // Ajoute un artiste.
        void Add(Artiste artiste);

        // Supprime un artiste.
        void Delete(Artiste artiste);

        // Renvoie le premier artiste ayant l'identifiant spécifié.
        Artiste Find(int idArtiste);

        // Renvoie tous les artistes.
        IEnumerable<Artiste> FindAll();

        // Renvoie les artistes demandés (pour la pagination) triés selon le nom (du plus récent à l'ancien).
        IEnumerable<Artiste> FindArtistes(int offset, int limit);

        // Met à jour un artiste.
        void Update(Artiste artiste);

        // Renvoie l'artiste le plus chroniqué.
        Artiste FindArtisteLePlusChronique();

        // Renvoie l'artiste ayant le plus de titres provenant d'albums distincts.
        Artiste FindArtisteLePlusTitresAlbumDistinct();

        // Renvoie le nombre de biographies d'artistes.
        public int NombreBioArtistes();

        // Renvoie le nombre d'artistes.
        public int NombreArtistes();
    }
}
