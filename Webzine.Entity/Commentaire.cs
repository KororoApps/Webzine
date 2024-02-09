namespace Webzine.Entity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Commentaire
    {
        public int IdCommentaire { get; set; }

        [Required]
        [ReadOnly(true)]
        [Display(Name = "Nom")]
        [MinLength(2)]
        [MaxLength(30)]
        public string Auteur { get; set; }

        [Required]
        [ReadOnly(true)]
        [Display(Name = "Commentaire")]
        [MaxLength(1000)]
        [MinLength(10)]
        public string Contenu { get; set; }

        [Required]
        [ReadOnly(true)]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        [ForeignKey(nameof(Titre))]
        public int IdTitre { get; set; }

        [ForeignKey(nameof(Titre))]
        public Titre Titre { get; set; }
    }
}
