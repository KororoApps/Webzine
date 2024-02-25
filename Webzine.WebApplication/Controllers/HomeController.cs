// <copyright file="HomeController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// Affiche la page d'accueil avec des données générées aléatoirement.
        /// </summary>
        /// <returns>Vue de la page d'accueil.</returns>
        public IActionResult Index()
        {
            /// <summary>
            /// Génération d'une liste d'artistes.
            /// <summary>
            List<Artiste> artistes = DataFactory.GenerateFakeArtiste(10);

            /// <summary>
            /// Génération d'une liste de titres.
            /// <summary>
            List<Titre> titres = artistes.SelectMany(a => a.Titres).ToList();

            /// <summary>
            /// Tri de la liste des titres par date de création.
            /// <summary>
            var titresTries = titres.OrderByDescending(t => t.DateCreation).ToList();

            /// <summary>
            /// Création du modèle de vue contenant la liste des titres.
            /// <summary>
            GroupeTitreModel groupeTitreModel = new()
            {
                Titres = titresTries,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les détails des titres.
            /// <summary>
            return this.View(groupeTitreModel);
        }
    }
}