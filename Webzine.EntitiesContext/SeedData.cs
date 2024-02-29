using Microsoft.EntityFrameworkCore;
using Webzine.Entity.Fixtures;

namespace Webzine.EntitiesContext
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, WebzineDbContext context)
        {
            
            // Désactivez le suivi des changements 
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            context.Artistes.AddRange(DataFactory.Artistes);
            context.Styles.AddRange(DataFactory.Styles);
            context.Titres.AddRange(DataFactory.Titres);
            context.Commentaires.AddRange(DataFactory.Commentaires);

            // SaveChanges après le seeding
            context.SaveChanges();

        }

    }
}


