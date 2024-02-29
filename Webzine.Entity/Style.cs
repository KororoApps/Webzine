namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public required string Libelle { get; set; }

        /// <summary>
        /// Obtient ou définit les titres utilisant le style
        /// </summary>

        [Required]
        public required List<Titre> Titres { get; set; }
    }
}