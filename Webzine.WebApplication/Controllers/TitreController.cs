// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des titres.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la chronique d'un titre.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    public class TitreController : Controller
    {
        /// <summary>
        /// Action qui affiche la liste des titres.
        /// </summary>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index()
        {
            /// <summary>
            /// Génération d'une liste d'artistes.
            /// <summary>
            List<Titre> titres = DataFactory.Titres;
            Titre titre = titres.OrderBy(t => Guid.NewGuid()).FirstOrDefault();

            /// <summary>
            /// Création du modèle de vue contenant un titre.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant le titre généré.
            /// <summary>
            return this.View(titreModel);
        }

        /// <summary>
        /// Action permettant d'afficher les titres liés à un style.
        /// </summary>
        /// <returns>Vue contenant la liste des titres liés au style.</returns>
        public IActionResult Style()
        {
            List<Artiste> artistes = DataFactory.Artistes;

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
            /// Retour de la vue avec le modèle de vue contenant les titres générés en fonction des styles.
            /// <summary>
            return this.View(titreModel);
        }
    }
}
