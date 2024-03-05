using Microsoft.EntityFrameworkCore;
using Webzine.Entity.Fixtures;

namespace Webzine.EntitiesContext.Seeders
{
    public static class SeedDataLocal
    {
        public static void Initialize(IServiceProvider serviceProvider, WebzineDbContext context)
        {

            // Désactivez le suivi des changements 
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            context.Artistes.AddRange(DataFactory.Artistes);
            context.Commentaires.AddRange(DataFactory.Commentaires);
            context.Styles.AddRange(DataFactory.Styles);
            context.Titres.AddRange(DataFactory.Titres);

            // SaveChanges après le seeding
            context.SaveChanges();

        }

    }
}


