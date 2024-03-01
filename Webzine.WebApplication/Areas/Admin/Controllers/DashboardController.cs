// <copyright file="DashboardController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;


    [Area("Admin")]
    public class DashboardController : Controller
    {
        /// <summary>
        /// Permet d'afficher le dashboard avec des données
        /// </summary>
        /// <returns>Une vue</returns>
        public IActionResult Index()
        {
            var model = new DashboardModel();
            var artistes = GetArtistes();
            var titres = GetTitres();
            var styles = GetStyles();

            model.TitrePlusLu = titres.OrderByDescending(t => t.NbLectures).First();
            model.NbTitres = titres.Count();
            model.NbStyles = styles.Count();
            model.NbArtistes = artistes.Count();
            //model.ArtistePlusDeTitres = artistes.OrderByDescending(a => a.Titres.Count).First();
            model.NbBioArtiste = artistes.Count(a => !string.IsNullOrEmpty(a.Biographie));
            model.NbLikes = titres.Sum(t => t.NbLikes);
            model.NbLectures = titres.Sum(t => t.NbLectures);
            /*model.ArtistePlusChronique = artistes.GroupBy(t => t.Titres)
                .Select(g => new
                {
                    Artiste = g.Key,
                    NombreTitresDifferents = g.Select(t => t.Titres).Distinct().Count(),
                })
                .OrderByDescending(x => x.NombreTitresDifferents)
                .Select(n => n.Artiste).FirstOrDefault()
            ?? throw new Exception("Il n'y a pas d'artiste ou de titre");*/

            return View(model);
        }

        /// <summary>
        /// Récupère tous les artistes
        /// </summary>
        /// <returns>Une liste d'artistes</returns>
        public List<Artiste> GetArtistes()
        {
            var artistes = DataFactory.Artistes;

            return artistes;
        }

        /// <summary>
        /// Récupère tous les styles
        /// </summary>
        /// <returns>Une liste de styles</returns>
        public List<Style> GetStyles()
        {
            var styles = DataFactory.Styles;

            return styles;
        }

        /// <summary>
        /// Récupère tous les titres
        /// </summary>
        /// <returns>Une liste de titres</returns>
        public List<Titre> GetTitres()
        {
            var titres = DataFactory.Titres;

            return titres;
        }
    }
}

/*namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion du tableau de bord administratif.
    /// </summary>
    [Area("Admin")]
    public class DashboardController : Controller
    {
        /// <summary>
        /// Affiche la page d'index du tableau de bord administratif.
        /// </summary>
        /// <returns>Vue avec le modèle de vue contenant les titres générés.</returns>
        public IActionResult Index()
        {
            List<Titre> titres = DataFactory.Titres;

            // Création du modèle de vue contenant la liste de Titres.
            var titreModel = new GroupeTitreModel
            {
                Titres = titres,
            };

            // Retour de la vue avec le modèle de vue contenant les titres générés.
            return this.View(titreModel);
        }
    }
}*/