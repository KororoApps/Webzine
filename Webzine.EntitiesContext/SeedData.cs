using Microsoft.EntityFrameworkCore;
using Webzine.Entity.Fixtures;

namespace Webzine.EntitiesContext
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebzineDbContext()) {

                // Désactivez le suivi des changements pour les Commentaires
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                // Désactivez la génération automatique des identifiants
                /*context.Artistes.AddRange(DataFactory.Artistes.Select(a => { a.IdArtiste = 0; return a; }));
                context.Styles.AddRange(DataFactory.Styles.Select(s => { s.IdStyle = 0; return s; }));
                context.Titres.AddRange(DataFactory.Titres.Select(t => { t.IdTitre = 0; return t; }));       
                context.Commentaires.AddRange(DataFactory.Commentaires.Select(c => { c.IdCommentaire = 0; return c; }));*/

                context.Artistes.AddRange(DataFactory.Artistes);
                context.Styles.AddRange(DataFactory.Styles);
                context.Titres.AddRange(DataFactory.Titres);
                context.Commentaires.AddRange(DataFactory.Commentaires);

                // SaveChanges après le seeding
                context.SaveChanges();

            }

        }

    }
}


