// <copyright file="DashboardController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Business.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion du tableau de bord administratif.
    /// </summary>
    [Area("Admin")]
    public class DashboardController(IDashboardService dashboardService) : Controller
    {
        private readonly IDashboardService dashboardService = dashboardService;

        /// <summary>
        /// Affiche le dashboard avec des données.
        /// </summary>
        /// <returns>Vue du dashboard.</returns>
        public IActionResult Index()
        {
            var model = new DashboardModel();

            model.TitrePlusLu = this.dashboardService.FindTitreLePlusLu();
            model.NbTitres = this.dashboardService.NombreTitres();
            model.NbStyles = this.dashboardService.NombreStyles();
            model.NbArtistes = this.dashboardService.NombreArtistes();
            model.ArtistePlusDeTitres = this.dashboardService.FindArtisteLePlusTitresAlbumDistinct();
            model.NbBioArtiste = this.dashboardService.NombreBiographiesArtistes();
            model.NbLikes = this.dashboardService.NombreLikes();
            model.NbLectures = this.dashboardService.NombreLectures();
            model.ArtistePlusChronique = this.dashboardService.FindArtisteLePlusChronique();

            return this.View(model);
        }
    }
}