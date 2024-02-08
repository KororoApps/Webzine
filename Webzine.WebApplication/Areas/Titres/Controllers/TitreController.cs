﻿using Microsoft.AspNetCore.Mvc;
using Bogus;


namespace Webzine.WebApplication.Areas.Titres.Controllers
{
    using Webzine.Entity;
    using Webzine.WebApplication.Areas.Titres.ViewModels;

    [Area("Titres")]
    public class TitreController : Controller
    {
        public IActionResult Liste() 
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(a => a.IdTitre, f => f.IndexFaker)
                .RuleFor(a => a.Libelle, f => f.Name.FullName())
                .RuleFor(a => a.Duree, f => f.Date.Timespan())
                .RuleFor(a => a.DateSortie, f => f.Date.Past())
                .RuleFor(a => a.DateCreation, f => f.Date.Recent())
                .RuleFor(a => a.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(a => a.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(a => a.Album, f => f.Commerce.ProductName())
                .RuleFor(a => a.Chronique, f => f.Lorem.Paragraph())
                .RuleFor(a => a.UrlJaquette, f => f.Internet.Url())
                .RuleFor(a => a.UrlEcoute, f => f.Internet.Url())
                //.RuleFor(a => a.Artiste, f => f.Name.FullName())
                //.RuleFor(a => a.Style, f => f.Random.WordsArray(3))
                ;

            /// <summary>
            /// Génération de 50 fausses instances de la classe Titre
            /// <summary>
            var titres = titreFaker.Generate(50);

            /// <summary>
            /// Création du modèle de vue contenant la liste de titres
            /// <summary>
            var titreModel = new TitreModel
            {
                Titres = titres
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés
            /// <summary>
            return this.View(titreModel);
        }
    }
}
