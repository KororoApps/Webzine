// <copyright file="DashboardController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Business.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées au dashboard dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage du dashboard .
    /// Il utilise soit le générateur de fausses données Bogus pour simuler des données, soit des données Spotify en fonction du Seeder sélectionné.
    /// </remarks>
    /// <param name="dashboardService">Référence à la classe responsable de l'accès aux données du dashboard.</param>
    [Area("Administration")]
    public class DashboardController(IDashboardService dashboardService) : Controller
    {
        private readonly IDashboardService dashboardService = dashboardService;

        /// <summary>
        /// Affiche le dashboard avec des données.
        /// </summary>
        /// <returns>Vue du dashboard.</returns>
        public IActionResult Index()
        {
            var model = new DashboardModel
            {
                TitrePlusLu = this.dashboardService.FindTitreLePlusLu(),
                NbTitres = this.dashboardService.NombreTitres(),
                NbStyles = this.dashboardService.NombreStyles(),
                NbArtistes = this.dashboardService.NombreArtistes(),
                ArtistePlusDeTitres = this.dashboardService.FindArtisteLePlusTitresAlbumDistinct(),
                NbBioArtiste = this.dashboardService.NombreBiographiesArtistes(),
                NbLikes = this.dashboardService.NombreLikes(),
                NbLectures = this.dashboardService.NombreLectures(),
                ArtistePlusChronique = this.dashboardService.FindArtisteLePlusChronique(),
            };

            return this.View(model);
        }
    }
}