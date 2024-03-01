using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalStyleRepository : IStyleRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        public void Add(Style style)
        {
            // Génère un nouvel identifiant
            style.IdStyle = DataFactory.Styles.Count + 1;

            // Ajoute le nouveau style à la liste
            DataFactory.Styles.Add(style);
        }
        /// <summary>
        /// Méthode pour supprimer un style
        /// </summary>
        /// <param name="style"></param>
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
        /// Méthode pour trouver un style par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retourne le style trouvé</returns>
        public Style Find(int id)
        {
            var style = DataFactory.Styles
                 .FirstOrDefault(t => t.IdStyle == id);

            return style;
        }
        /// <summary>
        /// Méthode pour trouver tous les styles
        /// </summary>
        /// <returns>Retourne tous les styles</returns>
        public IEnumerable<Style> FindAll()
        {
            List<Style> styles = DataFactory.Styles ;

            var orderedStyle = styles
                .OrderByDescending(c => c.Titres)
                .ToList();

            return orderedStyle;
        }
        /// <summary>
        /// Méthode pour mettre à jour un style (non implémentée)
        /// </summary>
        /// <param name="style"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(Style style)
        {
            throw new NotImplementedException();
        }
    }
}
