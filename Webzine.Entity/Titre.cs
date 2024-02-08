namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;

    public class Titre
    {
        public int IdTitre { get; set; }

        public int IdArtiste { get; set; }

        //public virtual Artiste Artiste { get; set; }

        //public virtual List<Commentaire> Commentaires { get; set; }

        [Required]
        [Display(Name = "Titre")]
        [StringLength(200, MinimumLength = 1)]
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
        [StringLength(4000, MinimumLength = 10)]
        public string Chronique { get; set; }

        [Required]
        [Display(Name = "Jaquette de l'album")]
        [StringLength(250)]
        public string UrlJaquette { get; set; } = string.Empty;

        [Display(Name = "URL d'écoute")]
        [StringLength(250, MinimumLength = 13)]
        public string UrlEcoute { get; set; }

    }
}
