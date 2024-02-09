using Microsoft.AspNetCore.Mvc;
using Bogus;


namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Areas.Admin.ViewModels;
    using Webzine.WebApplication.Areas.Titres.ViewModels;

    [Area("Admin")]
    public class TitreController : Controller
    {
        public IActionResult ReadTitre()
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
            /// Configuration du générateur de fausses données pour la classe Commentaire.
            /// <summary>
            var fakerCommentaire = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(c => c.DateCreation, f => f.Date.Recent());

            /// <summary>
            /// Génération d'un nombre aléatoire de fausses instances de la classe Commentaire.
            /// <summary>//
            Random random = new Random();

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.IdTitre, f => f.IndexFaker)
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.DateSortie, f => f.Date.Past())
                .RuleFor(t => t.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(t => t.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(t => t.Artiste, f => f.PickRandom(artistes))
                .RuleFor(t => t.Commentaires, f => fakerCommentaire.Generate(random.Next(1, 100)))
                ;

            /// <summary>
            /// Génération de 500 fausse instance de la classe Titre.
            /// <summary>
            var titres = titreFaker.Generate(500);
            //titres.Commentaires = commentaires;

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new GroupeTitreModel
            {
                Titres = titres
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(titreModel);
        }

        public IActionResult DeleteTitre()
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
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Artiste, f => artiste)
                ;

            /// <summary>
            /// Génération de 1 fausse instance de la classe Titre.
            /// <summary>
            var titre = titreFaker.Generate();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre
            };


            return this.View(titreModel);
        }

        public IActionResult CreateTitre()
        {

            return this.View();
        }


    }
}