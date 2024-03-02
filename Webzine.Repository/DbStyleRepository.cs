using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    /// <summary>
    /// Implémente l'interface IStyleRepository pour la gestion des styles en utilisant une base de données.
    /// </summary>
    public class DbStyleRepository(WebzineDbContext context) : IStyleRepository
    {
        // Contexte de base de données pour accéder aux données
        private readonly WebzineDbContext _context = context;

        /// <summary>
        /// Ajoute un style.
        /// </summary>
        /// <param name="style">Le style à ajouter.</param>
        public void Add(Style style)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprime un style.
        /// </summary>
        /// <param name="style">Le style à supprimer.</param>
        public void Delete(Style style)
        {

            if (style == null)
            {
                throw new ArgumentNullException(nameof(style));
            }
            else
            {
                _context.Styles
                     .Remove(style);
                _context
                    .SaveChanges();
            }          
        }

        /// <summary>
        /// Trouve un style par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du style.</param>
        /// <returns>Le style correspondant à l'identifiant.</returns>
        public Style Find(int id)
        {
             var  style = _context.Styles
                 .Include(s => s.Titres)
                 .Where(s => s.IdStyle == id)
                 .First();
                
            return style;

        }

        /// <summary>
        /// Trouve tous les styles.
        /// </summary>
        /// <returns>Une liste de tous les styles.</returns>
        public IEnumerable<Style> FindAll()
        {
            var  styles = _context.Styles
                .OrderBy(c => c.Libelle)
                .ToList();

            return styles;
        }

        /// <summary>
        /// Trouve les styles par leurs ids.
        /// </summary>
        /// <returns>Une liste de tous les styles.</returns>
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            var filteredStyles = _context.Styles
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
            var nombreStyle = _context.Styles
                .Count();

            return nombreStyle;
        }
    }
}
