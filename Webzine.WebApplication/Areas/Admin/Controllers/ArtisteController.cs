using Microsoft.AspNetCore.Mvc;
using Bogus;


namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Areas.Admin.ViewModels;
    using Webzine.WebApplication.Areas.Artistes.ViewModels;
    using Webzine.WebApplication.Areas.Titres.ViewModels;

    [Area("Admin")]
    public class ArtisteController : Controller
    {
        public IActionResult Read()
        {

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Artiste.
            /// <summary>
            var fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Artiste.
            /// <summary>//
            var artistes = fakerArtiste.Generate(150);

            /// <summary>
            /// Création du modèle de vue contenant la liste de Artiste.
            /// <summary>
            var artisteModel = new GroupeArtisteModel
            {
                Artistes = artistes
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(artisteModel);
        }

        public IActionResult Delete()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Artiste.
            /// <summary>
            var fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Artiste.
            /// <summary>//
            var artiste = fakerArtiste.Generate();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Artiste.
            /// <summary>
            var artisteModel = new ArtisteModel
            {
                Artiste = artiste
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(artisteModel);
        }

        public IActionResult Create()
        {
            
            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View();
        }

        public IActionResult Update()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Artiste.
            /// <summary>
            var fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Artiste.
            /// <summary>//
            var artiste = fakerArtiste.Generate();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Artiste.
            /// <summary>
            var artisteModel = new ArtisteModel
            {
                Artiste = artiste
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(artisteModel);
        }

    }
}