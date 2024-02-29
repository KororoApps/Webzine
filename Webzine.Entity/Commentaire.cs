﻿namespace Webzine.Entity
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
        public int IdCommentaire { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de l'auteur du commentaire.
        /// </summary>
        [Required]
        [ReadOnly(true)]
        [Display(Name = "Nom")]
        [MinLength(2)]
        [MaxLength(30)]
        public required string Auteur { get; set; }

        /// <summary>
        /// Obtient ou définit le contenu du commentaire.
        /// </summary>
        [Required]
        [ReadOnly(true)]
        [Display(Name = "Commentaire")]
        [MaxLength(1000)]
        [MinLength(10)]
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
        public required Titre Titre { get; set; }
    }
}