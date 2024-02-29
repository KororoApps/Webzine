using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Wenzine.Repository
{
    // Implémente l'interface IStyleRepository
    public class StyleRepository : IStyleRepository
    {
        // Contexte de base de données pour accéder aux données
        private readonly WebzineDbContext _context;
        

        // Constructeur prenant le contexte en paramètre
        public StyleRepository(WebzineDbContext context)
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
             _context.Styles
                .Remove(style);      
        }
        /// <summary>
        /// Méthode pour trouver un style par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retourne le style trouvé</returns>
        public Style Find(int id)
        {
            Style style;
            if (_context.Styles.Any()) 
            {
                style = _context.Styles
                .Include(c => c.Titres)
                .Where(c => c.IdStyle == id)
                .First();
            }
            else
            {
                // Génération d'un style à partir de DataFactory.
                var styles = DataFactory.Styles;
                style = styles.OrderBy(t => Guid.NewGuid()).FirstOrDefault();
            }

            return style;

        }
        /// <summary>
        /// Méthode pour trouver tous les styles
        /// </summary>
        /// <returns>Retourne tous les styles</returns>
        public IEnumerable<Style> FindAll()
        {
            IEnumerable<Style> allStyles;

            if (_context.Styles.Any()) 
            {
                allStyles = _context.Styles.Include(c => c.Titres).OrderBy(c => c.IdStyle).ToList();
            }
            else
            {
                // Génération d'un style à partir de DataFactory.
                var styles = DataFactory.Styles;
                allStyles = styles.OrderBy(t => Guid.NewGuid()).ToList();

            }
                
            return allStyles;
        }
        // Méthode pour mettre à jour un style (non implémentée)
        public void Update(Style style)
        {
            throw new NotImplementedException();
        }
    }
}
