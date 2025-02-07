﻿// <copyright file="HomeController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="HomeController"/>.
    /// </remarks>
    /// <param name="titreRepository">Le repository des titres.</param>
    /// <param name="configuration">Récupère la configuration de l'appsettings.</param>
    public class HomeController(ITitreRepository titreRepository, IConfiguration configuration) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly IConfiguration configuration = configuration;

        /// <summary>
        /// Affiche la page d'accueil.
        /// </summary>
        /// <returns>Vue de la page d'accueil.</returns>
        /// <param name="numeroPage">Indique le nunméro de page sur lequel nous sommes.</param>
        public IActionResult Index(int numeroPage)
        {
            // Charger la valeur MaxDescriptionTitre depuis la configuration
            int maxDescriptionTitre = int.Parse(this.configuration["MaxDescriptionTitre"]);

            var titreToSkip = numeroPage * int.Parse(this.configuration["NbDernierTitreChronique"]);
            // Création du modèle de vue contenant la liste des titres.
            TitreModel TitreModel = new()
            {
                ParutionChroniqueTitre = this.titreRepository.FindTitres(titreToSkip, int.Parse(this.configuration["NbDernierTitreChronique"])),
                TitresPopulaires = this.titreRepository.FindTitresLesPlusLike(int.Parse(this.configuration["NbMoisDernierTitrePopulaire"])),
                NumeroPage = numeroPage,
                MaxDescriptionTitre = maxDescriptionTitre,
            };

            // Retour de la vue avec le modèle de vue contenant les détails des titres.
            return this.View(TitreModel);
        }
    }
}