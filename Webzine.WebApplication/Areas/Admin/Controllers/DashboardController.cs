// <copyright file="DashboardController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion du tableau de bord administratif.
    /// </summary>
    [Area("Admin")]
    public class DashboardController(IArtisteRepository artisteRepository, IStyleRepository styleRepository, ITitreRepository titreRepository) : Controller
    {
        private readonly IArtisteRepository artisteRepository = artisteRepository;
        private readonly IStyleRepository styleRepository = styleRepository;
        private readonly ITitreRepository titreRepository = titreRepository;

        /// <summary>
        /// Affiche le dashboard avec des données.
        /// </summary>
        /// <returns>Vue du dashboard.</returns>
        public IActionResult Index()
        {
            var model = new DashboardModel();

            model.TitrePlusLu = this.titreRepository.FindTitreLePlusLu();
            model.NbTitres = this.titreRepository.NombreTitres();
            model.NbStyles = this.styleRepository.NombreStyles();
            model.NbArtistes = this.artisteRepository.NombreArtistes();
            model.ArtistePlusDeTitres = this.artisteRepository.FindArtisteLePlusTitresAlbumDistinct();
            model.NbBioArtiste = this.artisteRepository.NombreBioArtistes();
            model.NbLikes = this.titreRepository.NombreLikes();
            model.NbLectures = this.titreRepository.NombreLectures();
            model.ArtistePlusChronique = this.artisteRepository.FindArtisteLePlusChronique();

            return this.View(model);
        }
    }
}