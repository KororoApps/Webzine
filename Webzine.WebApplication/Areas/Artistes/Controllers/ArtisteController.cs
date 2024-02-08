using Bogus;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Artistes.Controllers
{
    using Webzine.WebApplication.Areas.Artistes.ViewModels;
    [Area("Artistes")]
    public class ArtisteController: Controller
    {
        public IActionResult ListeArtistes()
        {
            // Créez un générateur Bogus pour les artistes musicaux
            var artisteFaker = new Faker<Artiste>()
                .RuleFor(a => a.Id, (f, u) => f.UniqueIndex + 1)
                .RuleFor(a => a.Nom, (f, u) => f.Name.FullName())
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph());

            // Générez une liste de 10 artistes fictifs
            var artistes = artisteFaker.Generate(10);

            var artisteModel = new ListeArtistesModel
            {
                Artistes = artistes,
            };

            return this.View(artisteModel);
        }
    }
}
