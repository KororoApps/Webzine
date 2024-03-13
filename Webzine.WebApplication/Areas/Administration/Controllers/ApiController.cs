// <copyright file="ApiController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller API responsable de fournir des informations sur la version de l'application.
    /// </summary>
    public class ApiController : Controller
    {
        /// <summary>
        /// Obtient les informations sur la version de l'application.
        /// </summary>
        /// <returns>Retourne les informations sur la version de l'application.</returns>
        public IActionResult Version()
        {
            var versionInfo = new
            {
                nom = "webzine",
                version = "3.0",
            };

            return this.Ok(versionInfo);
        }
    }
}
