using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    // Implémente l'interface IStyleRepository
    public class DbStyleRepository : IStyleRepository
    {
        // Contexte de base de données pour accéder aux données
        private readonly WebzineDbContext _context;
        

        // Constructeur prenant le contexte en paramètre
        public DbStyleRepository(WebzineDbContext context)
        {
            _context = context;
        }
        // Méthode pour ajouter un style (non implémentée)
        public void Add(Style style)
        {
            throw new NotImplementedException();
        }
        // Méthode pour supprimer un style
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
        /// Méthode pour trouver un style par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retourne le style trouvé</returns>
        public Style Find(int id)
        {
             var  style = _context.Styles
                 .Include(s => s.Titres)
                 .Where(s => s.IdStyle == id)
                 .First();
                
            return style;

        }
        /// <summary>
        /// Méthode pour trouver tous les styles
        /// </summary>
        /// <returns>Retourne tous les styles</returns>
        public IEnumerable<Style> FindAll()
        {
            var  styles = _context.Styles
                .Include(s => s.Titres)
                .OrderBy(s => s.IdStyle)
                .ToList();     

            return styles;
        }
        // Méthode pour mettre à jour un style (non implémentée)
        public void Update(Style style)
        {
            throw new NotImplementedException();
        }
    }
}
