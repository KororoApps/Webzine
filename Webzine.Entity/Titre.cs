// <copyright file="Titre.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Représente un titre musical dans le système.
    /// </summary>
    public class Titre
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du titre.
        /// </summary>
        [Key]
        [Required]
        public int IdTitre { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'artiste associé au titre.
        /// </summary>
        public int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit l'artiste associé au titre.
        /// </summary>
        [Required(ErrorMessage = "L'artiste du titre est obligatoire.")]
        public required Artiste Artiste { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des commentaires associés au titre.
        /// </summary>
        public List<Commentaire>? Commentaires { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des styles associés au titre.
        /// </summary>
        public List<Style>? Styles { get; set; }

        /// <summary>
        /// Obtient ou définit le titre du morceau.
        /// </summary>
        [Required(ErrorMessage = "Le libellé du titre est obligatoire.")]
        [Display(Name = "Titre")]
        [MinLength(1, ErrorMessage = "Le libellé doit faire au minimum 1 caractère.")]
        [MaxLength(200, ErrorMessage = "Le libellé doit faire au maximum 200 caractères.")]
        public required string Libelle { get; set; }

        /// <summary>
        /// Obtient ou définit la durée du morceau en secondes.
        /// </summary>
        [Required(ErrorMessage = "La durée du titre est obligatoire.")]
        [Display(Name = "Durée en secondes")]

        public required string Duree { get; set; }

        /// <summary>
        /// Obtient ou définit la date de sortie du morceau.
        /// </summary>
        [Required(ErrorMessage = "La date de sortie du titre est obligatoire.")]
        [Display(Name = "Date de sortie")]

        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Obtient ou définit la date de création du morceau.
        /// </summary>
        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre de lectures du morceau.
        /// </summary>
        [Required]
        [Display(Name = "Nombre de lectures")]

        public int NbLectures { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre de likes du morceau.
        /// </summary>
        [Required]
        [Display(Name = "Nombre de likes")]
        public int NbLikes { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de l'album auquel appartient le morceau.
        /// </summary>
        [Required(ErrorMessage = "L'album du titre est obligatoire.")]
        public required string Album { get; set; }

        /// <summary>
        /// Obtient ou définit la chronique du morceau.
        /// </summary>
        [Required(ErrorMessage = "La chronique du titre est obligatoire.")]
        [MinLength(10, ErrorMessage = "Le chronique doit faire au minimum 10 caractères.")]
        [MaxLength(4000, ErrorMessage = "Le libellé doit faire au maximum 4 000 caractères.")]
        public required string Chronique { get; set; }

        /// <summary>
        /// Obtient ou définit l'URL de la jaquette de l'album du morceau.
        /// </summary>
        [Required(ErrorMessage = "La jaquette du titre est obligatoire.")]
        [Display(Name = "Jaquette de l'album")]
        [MinLength(13, ErrorMessage = "L'URL de la jaquette doit faire au minimum 13 caractères.")]
        [MaxLength(250, ErrorMessage = "L'URL de la jaquette doit faire au maximum 250 caractères.")]
        public string UrlJaquette { get; set; } = string.Empty;

        /// <summary>
        /// Obtient ou définit l'URL d'écoute du morceau.
        /// </summary>
        [Display(Name = "URL d'écoute")]
        [MinLength(13, ErrorMessage = "L'URL d'écoute doit faire au minimum 13 caractères.")]
        [MaxLength(250, ErrorMessage = "L'URL d'écoute doit faire au maximum 250 caractères.")]
        public string? UrlEcoute { get; set; }
    }
}