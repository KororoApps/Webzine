// <copyright file="ApiController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Contrôleur API responsable de fournir des informations sur la version de l'application.
    /// </summary>
    public class ApiController : Controller
    {
        /// <summary>
        /// Obtient les informations sur la version de l'application.
        /// </summary>
        /// <returns>Les informations sur la version de l'application.</returns>
        public IActionResult Version()
        {
            var versionInfo = new
            {
                nom = "webzine",
                version = "1.0",
            };

            return this.Ok(versionInfo);
        }
    }
}
