// <copyright file="Style.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Représente un style musical dans le système.
    /// </summary>
    public class Style
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du style.
        /// </summary>
        [Key]
        [Required]
        public int IdStyle { get; set; }

        /// <summary>
        /// Obtient ou définit le libellé du style musical.
        /// </summary>
        [Display(Name = "Libellé")]
        [Required(ErrorMessage ="Le libellé du style est obligatoire.")]
        [MinLength(2, ErrorMessage ="Le libellé doit faire au minimum 2 caractères.")]
        [MaxLength(50, ErrorMessage = "Le libellé doit faire au maximum 50 caractères.")]
        public string? Libelle { get; set; }

        /// <summary>
        /// Obtient ou définit les titres utilisant le style.
        /// </summary>
        public List<Titre>? Titres { get; set; }
    }
}