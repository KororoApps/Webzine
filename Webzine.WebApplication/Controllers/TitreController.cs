// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Business.Contracts;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des titres.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la chronique d'un titre.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="TitreController"/>.
    /// </remarks>
    /// <param name="titreRepository">Le repository des titres utilisé par le contrôleur.</param>
    public class TitreController(ITitreRepository titreRepository, ICommentaireRepository commentaireRepository) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly ICommentaireRepository commentaireRepository = commentaireRepository;

        /// <summary>
        /// Action qui affiche la liste des titres.
        /// </summary>
        /// <param name="id">Identifiant du titre à afficher.</param>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index(int id)
        {
            // Génération d'une liste de styles.
            var commentaires = this.commentaireRepository.FindCommentairesByIdTitre(id);

            Titre titre = this.titreRepository.Find(id);

            this.titreRepository.IncrementNbLectures(titre);

            // Création du modèle de vue contenant un titre.
            var titreModel = new TitreModel
            {
                Titre = titre,
                Commentaires = commentaires,
            };

            // Retour de la vue avec le modèle de vue contenant le titre généré.
            return this.View(titreModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IncrementLike(Titre titre)
        {

            // Incrémentez le nombre de likes
            this.titreRepository.IncrementNbLikes(titre);

            // Redirigez ou retournez à la vue selon vos besoins
            return this.RedirectToAction(nameof(this.Index), new { id = titre.IdTitre });
        }

        /// <summary>
        /// Action permettant d'afficher les titres liés à un style.
        /// </summary>
        /// /// <param name="id">Libellé du style.</param>
        /// <returns>Vue contenant la liste des titres liés au style.</returns>
        public IActionResult Style(string id)
        {
            // Création du modèle de vue contenant un titre.
            var titreModel = new GroupeTitreModel
            {
                Titres = this.titreRepository.SearchByStyle(id),
                Libelle = id,
            };

            // Retour de la vue avec le modèle de vue contenant les titres générés en fonction des styles.
            return this.View(titreModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la création d'un commentaire.
        /// </summary>
        /// <param name="commentaire">L'entité Commentaire à créer.</param>
        /// <param name="IdTitre">Id du titre lié au commentaire.</param>
        /// <returns>Redirection vers l'action Index après la création.</returns>
        /// 
        //TODO : Metre la création d'un commentaire dans TItreController. Voir les routes.
        //TODO : Appeler la méthode "Commenter"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Commenter(Commentaire commentaire, int IdTitre)
        {
            // Génération d'une liste de styles.
            var commentaires = this.commentaireRepository.FindCommentairesByIdTitre(IdTitre);

            var titre = this.titreRepository.Find(IdTitre);

            // Création du modèle de vue contenant un titre.
            var titreModel = new TitreModel
            {
                Titre = titre,
                Commentaires = commentaires,
            };

            if (!this.ModelState.IsValid)
            {
                //return this.RedirectToAction(nameof(this.Index), titreModel);
                return this.View("~/Views/Titre/Index.cshtml", titreModel);
            }

            commentaire.DateCreation = DateTime.Now;
            commentaire.Titre = titre;

            this.commentaireRepository.Add(commentaire);

            this.ModelState.Clear();

            //return this.RedirectToAction(nameof(this.Index), titreModel);
            return this.View("~/Views/Titre/Index.cshtml", titreModel);
        }
    }
}
