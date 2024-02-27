// <copyright file="ContactController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Contrôleur gérant les actions liées à la page de contact.
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// Action pour afficher la page de contact.
        /// </summary>
        /// <returns>Une vue avec les informations de contact.</returns>
        public IActionResult Index()
        {
            // Retour de la vue.
            return this.View();
        }
    }
}