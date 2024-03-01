// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
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
        private readonly ITitreRepository titreRepository;
        private readonly IStyleRepository styleRepository;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TitreController"/>.
        /// </summary>
        /// <param name="titreRepository">Le repository des titres utilisé par le contrôleur.</param>
        /// <param name="styleRepository">Le repository des styles utilisé par le contrôleur.</param>
        public TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository)
        {
            this.titreRepository = titreRepository;
            this.styleRepository = styleRepository;
        }

        /// <summary>
        /// Action qui affiche la liste des titres.
        /// </summary>
        /// <param name="id">Identifiant du titre à afficher.</param>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index(int id)
        {
            // Création du modèle de vue contenant un titre.
            var titreModel = new TitreModel
            {
                Titre = this.titreRepository.Find(id),
            };

            // Retour de la vue avec le modèle de vue contenant le titre généré.
            return this.View(titreModel);
        }

        /// <summary>
        /// Action permettant d'afficher les titres liés à un style.
        /// </summary>
        /// /// <param name="id">Libellé du style.</param>
        /// <returns>Vue contenant la liste des titres liés au style.</returns>
        public IActionResult Style(string id)
        {
            // Création du modèle de vue contenant un titre.
            var titreModel = new GroupeTitreModel
            {
                Titres = this.titreRepository.SearchByStyle(id),
                Libelle = id,
            };

            // Retour de la vue avec le modèle de vue contenant les titres générés en fonction des styles.
            return this.View(titreModel);
        }
    }
}
