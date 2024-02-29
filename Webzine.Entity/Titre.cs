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
        [Required] public int Id { get; set; }
        public int IdTitre { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'artiste associé au titre.
        /// </summary>

        public int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit l'artiste associé au titre.
        /// </summary>
        public required Artiste Artiste { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des commentaires associés au titre.
        /// </summary>
        public required List<Commentaire> Commentaires { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des styles associés au titre.
        /// </summary>
        public required List<Style> Styles { get; set; }


        /// <summary>
        /// Obtient ou définit le titre du morceau.
        /// </summary>
        [Required]
        [Display(Name = "Titre")]
        [MinLength(1)]
        [MaxLength(200)]
        public required string Libelle { get; set; }

        /// <summary>
        /// Obtient ou définit la durée du morceau en secondes.
        /// </summary>
        [Display(Name = "Durée en secondes")]

        public TimeSpan Duree { get; set; }

        /// <summary>
        /// Obtient ou définit la date de sortie du morceau.
        /// </summary>
        [Required]
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
        [Required]

        public required string Album { get; set; }

        /// <summary>
        /// Obtient ou définit la chronique du morceau.
        /// </summary>
        [Required]
        [MinLength(10)]
        [MaxLength(4000)]
        public required string Chronique { get; set; }

        /// <summary>
        /// Obtient ou définit l'URL de la jaquette de l'album du morceau.
        /// </summary>
        [Required]
        [Display(Name = "Jaquette de l'album")]
        [MaxLength(250)]
        public string UrlJaquette { get; set; } = string.Empty;

        /// <summary>
        /// Obtient ou définit l'URL d'écoute du morceau.
        /// </summary>
        [Display(Name = "URL d'écoute")]
        [MinLength(13)]
        [MaxLength(250)]
        public string? UrlEcoute { get; set; }

    }
}