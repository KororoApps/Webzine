using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface ITitreRepository
    {

        // Ajoute un titre à la base de données
        void Add(Titre titre);

        // Récupère le nombre total de titres dans la base de données
        int Count();

        // Supprime un titre de la base de données
        void Delete(Titre titre);

        // Recherche un titre par son ID
        Titre Find(int idTitre);

        //Retourne les titres demandés (pour la pagination) triés selon la date de création (du plus récent à ancien)
        IEnumerable<Titre> FindTitres(int offset, int limit);

        //Retourne tous les titres
        IEnumerable<Titre> FindAll();

        //Incrémente le nombre de lecture d'un titre
        void IncrementNbLectures(Titre titre);

        //Incrémente le nombre de like d'un titre
        void IncrementNbLikes(Titre titre);
        
        //Recherche de manière insensible à la casse les titres contenant le mot recherché
        IEnumerable<Titre> Search(string mot);

        //Recherche de manière insensible à la casse les titres contenant le style de musique cherchée
        IEnumerable<Titre> SearchByStyle(string libelle);

        //Met à jour un titre
        void Update(Titre titre);
    }
}
