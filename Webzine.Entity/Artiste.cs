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
        public required int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de l'artiste.
        /// </summary>
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Nom de l'artiste")]
        public required string Nom { get; set; }

        /// <summary>
        /// Obtient ou définit la biographie de l'artiste.
        /// </summary>
        public required string Biographie { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des titres associés à cet artiste.
        /// </summary>
        public required List<Titre> Titres { get; set; }
    }
}
