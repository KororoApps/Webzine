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

            _context.Add<Style>(style);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Style style)
        {

            _context.Styles.Remove(style);

            _context.SaveChanges();

        }

        /// <inheritdoc />
        public Style Find(int id)
        {
             return _context.Styles
                 .Include(s => s.Titres).AsNoTracking()
                 .Where(s => s.IdStyle == id)
                 .First();
                
        }

        /// <inheritdoc />
        public IEnumerable<Style> FindAll()
        {
            return _context.Styles.AsNoTracking()
                .OrderBy(c => c.Libelle.ToLower())
                .ToList();

        }

        /// <inheritdoc />
        public IEnumerable<Style> FindByIds(List<int> ids)
        {
            return _context.Styles.AsNoTracking()
                .Where(s => ids.Contains(s.IdStyle))
                .ToList();

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
            return _context.Styles
                .Count();

        }
    }
}
