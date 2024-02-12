// <copyright file="ContactController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.Shared.ViewModels;

    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            //génération des contacts
            string CompanyName = "C.U.C.D.B - DIIAGE";
            string Address = "69 Avenue Aristide Briand";
            string VilleDepartement = "21000 Dijon";
           
            ContactModel contacts = new()
            {
                listString =
                [
                    CompanyName,
                    Address,
                    VilleDepartement
                ],
            };
            /// <summary>
            /// Retour de la vue
            /// <summary>
            return View(contacts);
        }
    }
}