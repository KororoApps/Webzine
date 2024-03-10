using Webzine.Entity;

namespace Webzine.Business.Contracts
{
    public interface IDashboardService
    {
        /// <summary>
        /// Renvoie le titre le plus lu.
        /// </summary>
        /// <returns>Le titre le plus lu.</returns>
        Titre FindTitreLePlusLu();

        /// <summary>
        /// Renvoie le nombre de titres.
        /// </summary>
        /// <returns>Le nombre total de titres.</returns>
        int NombreTitres();

        /// <summary>
        /// Renvoie le nombre de likes totaux.
        /// </summary>
        /// <returns>Le nombre total de likes.</returns>
        int NombreLikes();

        /// <summary>
        /// Renvoie le nombre de lectures totales.
        /// </summary>
        /// <returns>Le nombre total de lectures.</returns>
        int NombreLectures();

        /// <summary>
        /// Renvoie le nombre de biographies d'artistes.
        /// </summary>
        /// <returns>Le nombre de biographies d'artistes.</returns>
        public int NombreBiographiesArtistes();

        /// <summary>
        /// Renvoie le nombre d'artistes.
        /// </summary>
        /// <returns>Le nombre total d'artistes.</returns>
        public int NombreArtistes();

        /// <summary>
        /// Renvoie l'artiste le plus chroniqué.
        /// </summary>
        /// <returns>L'artiste le plus chroniqué.</returns>
        Artiste FindArtisteLePlusChronique();

        /// <summary>
        /// Renvoie l'artiste ayant le plus de titres provenant d'albums distincts.
        /// </summary>
        /// <returns>L'artiste avec le plus de titres d'albums distincts.</returns>
        Artiste FindArtisteLePlusTitresAlbumDistinct();

        /// <summary>
        /// Retourne le nombre de styles.
        /// </summary>
        /// <returns>Le nombre total de styles.</returns>
        public int NombreStyles();


    }
}
