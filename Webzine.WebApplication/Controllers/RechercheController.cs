// <copyright file="RechercheController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    public class RechercheController : Controller
    {
        /// <summary>
        /// Affiche la page d'accueil avec des données générées aléatoirement.
        /// </summary>
        /// <param name="recherche">Le terme de recherche saisi dans le formulaire.</param>
        /// <returns>Vue de la page d'accueil.</returns>
        [HttpPost]
        public IActionResult Index(string recherche)
        {
            // Génération d'une liste de titres.
            List<Titre> titres = DataFactory.Titres;

            // Génération d'une liste d'artistes.
            List<Artiste> artistes = DataFactory.Artistes;

            // Filtrage des titres en fonction de la recherche.
            List<Titre> titresFiltres = titres
                .Where(t => t.Libelle.ToLower().Contains(recherche.ToLower()))
                .ToList();

            // Filtrage des artistes en fonction de la recherche.
            List<Artiste> artisteFiltres = artistes
                .Where(a => a.Nom.ToLower().Contains(recherche.ToLower()))
                .ToList();

            // Création du modèle de vue contenant la liste de titres filtrés.
            var titreModel = new GroupeTitreModel
            {
                Artistes = artisteFiltres,
                Titres = titresFiltres,
                Recherche = recherche,
            };

            // Retour de la vue avec le modèle de vue contenant les titres filtrés.
            return this.View(titreModel);
        }
    }
}