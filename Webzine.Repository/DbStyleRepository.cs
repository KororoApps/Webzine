using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
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

        /// <inheritdoc />
        public void Add(Style style)
        {
            if (style == null)
            {
                throw new ArgumentNullException(nameof(style));
            }

            _context.Add<Style>(style);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Style style)
        {
            // Recherchez le style existant dans le contexte de données
            var styleASupprimer = _context.Styles.Find(style.IdStyle);

            if (styleASupprimer == null)
            {
                throw new ArgumentNullException(nameof(styleASupprimer));
            }
            else
            {
                _context.Styles
                     .Remove(styleASupprimer);

                _context.SaveChanges();
            }          
        }

        /// <inheritdoc />
        public Style Find(int id)
        {
             var  style = _context.Styles
                 .Include(s => s.Titres)
                 .Where(s => s.IdStyle == id)
                 .First();
                
            return style;

        }

        /// <inheritdoc />
        public IEnumerable<Style> FindAll()
        {
            var  styles = _context.Styles
                .OrderBy(c => c.Libelle.ToLower())
                .ToList();

            return styles;
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            var filteredStyles = _context.Styles
                .Where(s => ids.Contains(s.IdStyle))
                .ToList();

            return filteredStyles;
        }

        /// <inheritdoc />
        public void Update(Style style)
        {
            _context.Update<Style>(style);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        public int NombreStyles()
        {
            var nombreStyle = _context.Styles
                .Count();

            return nombreStyle;
        }
    }
}
