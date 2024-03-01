using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface IArtisteRepository
    {
        // Ajoute un Artiste
        void Add(Artiste artiste);

        // Supprimme un artiste
        void Delete(Artiste artiste);

        //Renvoie le premier Artiste ayant l'id mise en paramètre
        Artiste Find(int idArtiste);

        // Renvoie tous les Artistes
        IEnumerable<Artiste> FindAll();

        // Retourne les artistes demandés (pour la pagination) triés selon  le nom(du plus récent à ancien)
        IEnumerable<Artiste> FindArtistes(int offset, int limit);

        // Met à jour un Artiste
        void Update(Artiste artiste);
    }
}
