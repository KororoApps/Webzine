using Microsoft.AspNetCore.Mvc;
using Bogus;



namespace Webzine.WebApplication.Areas.Styles.Controllers
{

    using Webzine.Entity;
    using Webzine.WebApplication.Areas.Styles.ViewModels;

    [Area("Styles")]
        public class StyleController : Controller
        {
            public IActionResult Liste()
            {
                /// <summary>
                /// Configuration du générateur de fausses données pour la classe Style
                /// <summary>
                var styleFaker = new Faker<Style>()
                    .RuleFor(a => a.Libelle, f => f.Random.Word())
                    ;
                /// <summary>
                /// Génération de 25 fausses instances de la classe Style
                /// <summary>
                var styles = styleFaker.Generate(25);
                /// <summary>
                /// Création du modèle de vue contenant la liste de styles
                /// <summary>
                var styleModel = new StyleModel
                {
                    Styles = styles
                };
                /// <summary>
                /// Retour de la vue avec le modèle de vue contenant les styles générés
                /// <summary>
                return this.View(styleModel);
            }
        }
    }

