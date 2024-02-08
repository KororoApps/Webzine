namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;

    public class Titre
    {
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        public TimeSpan Duree { get; set; }

        public DateTime DateDeSortie { get; set; }

        [Required]
        public DateTime DateDeCreation { get; set; }

        public int NombreDeVues { get; set; }

        public int NombreDeLikes { get; set; }

        public string Album { get; set; }

        [Required]
        public string Chronique { get; set; }

        [Required]
        public string Jaquette { get; set; }

        public string Url { get; set; }
        //public Artiste Astiste { get; set; }
        //public Style Style { get; set; }
    }
}
