using Webzine.Entity;

namespace Webzine.Business.Contracts
{
    public interface ITitreService
    {

        /// <summary>
        /// Incrémente le nombre de lectures d'un titre.
        /// </summary>
        /// <param name="titre">Le titre pour lequel incrémenter le nombre de lectures.</param>
        void IncrementNbLectures(Titre titre);

        /// <summary>
        /// Incrémente le nombre de likes d'un titre.
        /// </summary>
        /// <param name="titre">Le titre pour lequel incrémenter le nombre de likes.</param>
        void IncrementNbLikes(Titre titre);


    }
}
