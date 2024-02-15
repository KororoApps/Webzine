namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Titre
    {
        [Key]
        public int IdTitre { get; set; }

        [ForeignKey(nameof(Artiste))]

        public int IdArtiste { get; set; }


        [ForeignKey(nameof(Artiste))]


        public Artiste Artiste { get; set; }

        public List<Commentaire> Commentaires { get; set; }

        public List<Style> Styles { get; set; }

        [Required]
        [Display(Name = "Titre")]
        [MinLength(1)]
        [MaxLength(200)]
        public string Libelle { get; set; }

        [Display(Name = "Durée en secondes")]

        public TimeSpan Duree { get; set; }

        [Required]
        [Display(Name = "Date de sortie")]

        public DateTime DateSortie { get; set; }

        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        [Required]
        [Display(Name = "Nombre de lectures")]

        public int NbLectures { get; set; }

        [Required]
        [Display(Name = "Nombre de likes")]

        public int NbLikes { get; set; }

        [Required]

        public string Album { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(4000)]
        public string Chronique { get; set; }

        [Required]
        [Display(Name = "Jaquette de l'album")]
        [MaxLength(250)]
        public string UrlJaquette { get; set; } = string.Empty;

        [Display(Name = "URL d'écoute")]
        [MinLength(13)]
        [MaxLength(250)]
        public string UrlEcoute { get; set; }

    }
}