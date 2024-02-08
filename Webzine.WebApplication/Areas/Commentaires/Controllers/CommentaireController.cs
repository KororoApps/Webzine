using Microsoft.AspNetCore.Mvc;
using Bogus;

namespace Webzine.WebApplication.Areas.Commentaires.Controllers
{
    using Webzine.Entity;
    using Webzine.WebApplication.Areas.Commentaires.ViewModels;

    [Area("Commentaires")]
    public class CommentaireController : Controller
    {
        public IActionResult Liste()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Commentaire
            /// <summary>
            var commentaireFaker = new Faker<Commentaire>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Pseudo, f => f.Internet.UserName())
                .RuleFor(p => p.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(p => p.DateDeCreation, f => f.Date.Recent())
                //.RuleFor(p => p.Titre, f => f.Lorem.Sentence());
            ;
            /// <summary>
            /// Génération de 5 fausses instances de la classe Commentaire
            /// <summary>
            var commentaires = commentaireFaker.Generate(5);
            /// <summary>
            /// Création du modèle de vue contenant la liste de commentaires
            /// <summary>
            var commentaireModel = new CommentaireModel
            {
                Commentaires = commentaires
            };
            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les commentaires générés
            /// <summary>
            return this.View(commentaireModel);
        }
    }
}


