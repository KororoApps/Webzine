using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    /// <summary>
    /// Implémente l'interface IStyleRepository pour la gestion des styles  en mémoire locale.
    /// </summary>
    public class LocalStyleRepository : IStyleRepository
    {
        /// <inheritdoc />
        public void Add(Style style)
        {
            // Génère un nouvel identifiant
            style.IdStyle = DataFactory.Styles.Count + 1;

            // Ajoute le nouveau style à la liste
            DataFactory.Styles.Add(style);
        }

        /// <inheritdoc />
        public void Delete(Style style)
        {
           
            DataFactory.Styles.Remove(style);

        }

        /// <inheritdoc />
        public Style Find(int id)
        {
            return DataFactory.Styles
                 .First(t => t.IdStyle == id);

        }

        /// <inheritdoc />
        public IEnumerable<Style> FindAll()
        {
            return DataFactory.Styles
                .OrderByDescending(c => c.Libelle)
                .ToList();

        }

        /// <inheritdoc />
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            return DataFactory.Styles
                .Where(s => ids.Contains(s.IdStyle))
                .ToList();

        }

        /// <inheritdoc />
        public void Update(Style style)
        {
            var styleAEditer = DataFactory.Styles
                .First(s => s.IdStyle == style.IdStyle);

            if (styleAEditer != null)
            {
                styleAEditer.Libelle = style.Libelle;
            }
        }

        /// <inheritdoc />
        public int NombreStyles()
        {
            return DataFactory.Styles
                .Count;

        }
    }
}
