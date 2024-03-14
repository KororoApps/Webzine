// <copyright file="Artiste.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Représente un artiste dans le système.
    /// </summary>
    public class Artiste
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'artiste.
        /// </summary>
        [Key]
        [Required]
        public int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de l'artiste.
        /// </summary>
        [Required(ErrorMessage ="Le nom de l'artiste est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le nom de l'artiste doit faire au minimum 2 caractères.")]
        [MaxLength(50, ErrorMessage = "Le nom de l'artiste doit faire au maximum 50 caractères.")]
        [Display(Name = "Nom de l'artiste")]
        public required string Nom { get; set; }

        /// <summary>
        /// Obtient ou définit la biographie de l'artiste.
        /// </summary>
        public string? Biographie { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des titres associés à cet artiste.
        /// </summary>
        public List<Titre>? Titres { get; set; }
    }
}
