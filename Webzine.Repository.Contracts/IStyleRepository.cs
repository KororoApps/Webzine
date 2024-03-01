using Webzine.Entity;

namespace Webzine.Repository.Contracts
{

    /// <summary>
    /// Interface définissant les opérations CRUD pour la gestion des styles.
    /// </summary>
    public interface IStyleRepository
    {
        // Ajoute un style.
        void Add(Style style);

        // Supprime un style.
        void Delete(Style style);

        // Trouve un style par son identifiant.
        Style Find(int id);

        // Trouve tous les styles.
        IEnumerable<Style> FindAll();

        // Met à jour un style.
        void Update(Style style);

        // Retourne le nombre de styles.
        public int NombreStyles();
    }
}
