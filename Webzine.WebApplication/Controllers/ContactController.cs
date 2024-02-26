// <copyright file="ContactController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.Shared.ViewModels;

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
            /// <summary>
            /// Génération des contacts.
            /// </summary>
            string companyName = "C.U.C.D.B - DIIAGE";
            string address = "69 Avenue Aristide Briand";
            string villeDepartement = "21000 Dijon";

            ContactModel contacts = new()
            {
                ListString =
                [
                    companyName,
                    address,
                    villeDepartement
                ],
            };
            /// <summary>
            /// Retour de la vue
            /// <summary>
            return this.View(contacts);
        }
    }
}