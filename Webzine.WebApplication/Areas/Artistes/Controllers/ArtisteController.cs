using Bogus;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Artistes.Controllers
{
    using Webzine.WebApplication.Areas.Artistes.ViewModels;
    [Area("Artistes")]
    public class ArtisteController: Controller
    {
        public IActionResult Index(string nomArtiste)
        {
            // Créez un générateur Bogus pour les artistes musicaux
            var artisteFaker = new Faker<Artiste>()
                .RuleFor(a => a.Id, (f, u) => f.UniqueIndex + 1)
                .RuleFor(a => a.Nom, nomArtiste)
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph());

            // Générez une liste de 10 artistes fictifs
            var artiste = artisteFaker.Generate();

            var artisteModel = new ArtisteModel { Artiste = artiste };

            return this.View(artisteModel);
        }
    }
}
