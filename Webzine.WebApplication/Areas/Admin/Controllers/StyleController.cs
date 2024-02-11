// <copyright file="StyleController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers

{
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    public class StyleController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
        public IActionResult Create()
        {
            return this.View();
        }
        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
