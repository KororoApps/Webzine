// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;
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
        private readonly ITitreRepository _titreRepository;

        public TitreController(ITitreRepository titreRepository)
        {
            _titreRepository = titreRepository;
        }
        /// <summary>
        /// Action qui affiche la liste des titres.
        /// </summary>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index(int id)
        {
            // Création du modèle de vue contenant un titre.
            var titreModel = new TitreModel
            {
                Titre = this._titreRepository.Find(id),
            };

            // Retour de la vue avec le modèle de vue contenant le titre généré.
            return this.View(titreModel);
        }

        /// <summary>
        /// Action permettant d'afficher les titres liés à un style.
        /// </summary>
        /// <returns>Vue contenant la liste des titres liés au style.</returns>
        public IActionResult Style()
        {
            List<Titre> titres = DataFactory.Titres;

            // Création du modèle de vue contenant la liste de Titres.
            var titreModel = new GroupeTitreModel
            {
                Titres = this._titreRepository.FindAll(),
            };

            // Retour de la vue avec le modèle de vue contenant les titres générés en fonction des styles.
            return this.View(titreModel);
        }
    }
}
