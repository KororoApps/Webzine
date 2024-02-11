// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Bogus;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Configuration du générateur de fausses données pour la classe Artiste.
    /// </summary>
    [Area("Admin")]
    public class TitreController : Controller
    {
        /// <summary>
        /// Configuration du générateur de fausses données pour la classe Artiste.
        /// </summary>
        /// <returns>hhh.</returns>
        public IActionResult Index()
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

        /// <summary>
        /// Configuration du générateur de fausses données pour la classe Artiste.
        /// </summary>
        /// <returns>hhh.</returns>
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

        /// <summary>
        /// Configuration du générateur de fausses données pour la classe Artiste.
        /// </summary>
        /// <returns>hhh.</returns>
        public IActionResult Create()
        {

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Style.
            /// <summary>
            var fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => f.Random.Word());

            /// <summary>
            /// Génération de 20 fausses instances de la classe Style.
            /// <summary>//
            var styles = fakerStyle.Generate(20);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.IdTitre, f => f.IndexFaker)
                ;

            /// <summary>
            /// Génération de 1 fausse instance de la classe Titre.
            /// <summary>
            var titre = titreFaker.Generate();
            titre.Styles = styles;

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(titreModel);
        }

        /// <summary>
        /// Configuration du générateur de fausses données pour la classe Artiste.
        /// </summary>
        /// <returns>hhh.</returns>
        public IActionResult Edit()
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
            /// Configuration du générateur de fausses données pour la classe Style.
            /// <summary>
            var fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => f.Random.Word());

            /// <summary>
            /// Génération de 20 fausses instances de la classe Style.
            /// <summary>//
            var styles = fakerStyle.Generate(20);

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
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.Chronique, f => f.Lorem.Paragraphs(10))
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                .RuleFor(t => t.UrlEcoute, f => f.Internet.Url())
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                ;

            /// <summary>
            /// Génération de 1 fausse instance de la classe Titre.
            /// <summary>
            var titre = titreFaker.Generate();
            titre.Artiste = artiste;
            titre.Styles = styles;

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(titreModel);
        }


    }
}