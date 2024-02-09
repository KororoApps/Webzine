using Microsoft.AspNetCore.Mvc;
using Bogus;


namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    [Area("Admin")]
    public class CommentaireController : Controller
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
            var artistes = fakerArtiste.Generate(15);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                ;

            /// <summary>
            /// Génération de 1 fausse instance de la classe Titre.
            /// <summary>
            var titres = titreFaker.Generate(20);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Commentaire.
            /// <summary>
            var fakerCommentaire = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(c => c.DateCreation, f => f.Date.Recent())
                .RuleFor(t => t.Artiste, f => f.PickRandom(artistes))
                .RuleFor(t => t.Titre, f => f.PickRandom(titres));

            /// <summary>
            /// Génération de 20 fausses instances de la classe Commentaire.
            /// <summary>//
            var commentaires = fakerCommentaire.Generate(20);   

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var commentaireModel = new GroupeCommentaireModel
            {
                Commentaires = commentaires
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(commentaireModel);
        }
    }
}