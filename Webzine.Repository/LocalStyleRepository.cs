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
           
            var styleASupprimer = DataFactory.Styles
                .FirstOrDefault(t => t.IdStyle == style.IdStyle);

          
            if (styleASupprimer != null)
            {
                DataFactory.Styles
                    .Remove(styleASupprimer);
            }
        }

        /// <inheritdoc />
        public Style Find(int id)
        {
            var style = DataFactory.Styles
                 .FirstOrDefault(t => t.IdStyle == id);

            return style;
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindAll()
        {
            List<Style> styles = DataFactory.Styles ;

            var orderedStyle = styles
                .OrderByDescending(c => c.Libelle)
                .ToList();

            return orderedStyle;
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            List<Style> styles = DataFactory.Styles;

            var filteredStyles = styles
                .Where(s => ids.Contains(s.IdStyle))
                .ToList();

            return filteredStyles;
        }

        /// <inheritdoc />
        public void Update(Style style)
        {
            var styleAEditer = DataFactory.Styles
                .FirstOrDefault(s => s.IdStyle == style.IdStyle);

            if (styleAEditer != null)
            {
                styleAEditer.Libelle = style.Libelle;
            }
        }

        /// <inheritdoc />
        public int NombreStyles()
        {
            var nombreStyle = DataFactory.Styles
                .Count;

            return nombreStyle;
        }
    }
}
