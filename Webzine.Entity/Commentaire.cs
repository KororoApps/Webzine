// <copyright file="Commentaire.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Entity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Représente un commentaire associé à un titre dans le système.
    /// </summary>
    public class Commentaire
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du commentaire.
        /// </summary>
        [Key]
        [Required]
        public int IdCommentaire { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de l'auteur du commentaire.
        /// </summary>
        [Required(ErrorMessage = "Votre prénom ou pseudonyme est obligatoire.")]
        [ReadOnly(true)]
        [Display(Name = "Nom")]
        [MinLength(2, ErrorMessage = "Votre prénom/pseudonyme doit faire au minimum 2 caractères.")]
        [MaxLength(30, ErrorMessage = "Votre prénom/pseudonyme doit faire au minimum 2 caractères.")]
        public required string Auteur { get; set; }

        /// <summary>
        /// Obtient ou définit le contenu du commentaire.
        /// </summary>
        [Required(ErrorMessage = "Votre commentaire est obligatoire.")]
        [ReadOnly(true)]
        [Display(Name = "Commentaire")]
        [MaxLength(1000, ErrorMessage = "La longueur maximale d'un commentaire est de 1000 caractères.")]
        [MinLength(10, ErrorMessage = "La longueur minimale d'un commentaire est de 10 caractères.")]
        public required string Contenu { get; set; }

        /// <summary>
        /// Obtient ou définit la date de création du commentaire.
        /// </summary>
        [Required]
        [ReadOnly(true)]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant du titre auquel le commentaire est associé.
        /// </summary>
        public int IdTitre { get; set; }

        /// <summary>
        /// Obtient ou définit le titre auquel le commentaire est associé.
        /// </summary>
        public Titre? Titre { get; set; }
    }
}