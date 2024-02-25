﻿// <copyright file="DashboardController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion du tableau de bord administratif.
    /// </summary>
    [Area("Admin")]
    public class DashboardController : Controller
    {
        /// <summary>
        /// Affiche la page d'index du tableau de bord administratif.
        /// </summary>
        /// <returns>Vue avec le modèle de vue contenant les titres générés.</returns>
        public IActionResult Index()
        {
            List<Artiste> artistes = DataFactory.GenerateFakeArtiste(10);

            /// <summary>
            /// Génération d'une liste de titres.
            /// <summary>
            List<Titre> titres = artistes.SelectMany(a => a.Titres).ToList();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new GroupeTitreModel
            {
                Titres = titres,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(titreModel);
        }
    }
}