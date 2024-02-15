namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Style
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStyle { get; set; }

        [Display(Name = "Libellé")]
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Libelle { get; set; }
    }
}