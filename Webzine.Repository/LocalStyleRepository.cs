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
        /// <summary>
        /// Ajoute un style.
        /// </summary>
        /// <param name="style">Le style à ajouter.</param>
        public void Add(Style style)
        {
            // Génère un nouvel identifiant
            style.IdStyle = DataFactory.Styles.Count + 1;

            // Ajoute le nouveau style à la liste
            DataFactory.Styles.Add(style);
        }

        /// <summary>
        /// Supprime un style.
        /// </summary>
        /// <param name="style">Le style à supprimer.</param>
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

        /// <summary>
        /// Trouve un style par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du style.</param>
        /// <returns>Le style correspondant à l'identifiant.</returns>
        public Style Find(int id)
        {
            var style = DataFactory.Styles
                 .FirstOrDefault(t => t.IdStyle == id);

            return style;
        }

        /// <summary>
        /// Trouve tous les styles.
        /// </summary>
        /// <returns>Une liste de tous les styles.</returns>
        public IEnumerable<Style> FindAll()
        {
            List<Style> styles = DataFactory.Styles ;

            var orderedStyle = styles
                .OrderByDescending(c => c.Libelle)
                .ToList();

            return orderedStyle;
        }

        /// <summary>
        /// Trouve les styles par leurs ids.
        /// </summary>
        /// <returns>Une liste de tous les styles.</returns>
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            List<Style> styles = DataFactory.Styles;

            var filteredStyles = styles
                .Where(s => ids.Contains(s.IdStyle))
                .ToList();

            return filteredStyles;
        }

        /// <summary>
        /// Met à jour un style.
        /// </summary>
        /// <param name="style">Le style à mettre à jour.</param>
        public void Update(Style style)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne le nombre de styles.
        /// </summary>
        /// <returns>Le nombre total de styles.</returns>
        public int NombreStyles()
        {
            var nombreStyle = DataFactory.Styles
                .Count;

            return nombreStyle;
        }
    }
}
