namespace Webzine.Entity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Commentaire
    {
        public int Id { get; set; }

        [Required]
        [ReadOnly(true)]
        public string Pseudo { get; set; }

        [Required]
        [ReadOnly(true)]

        public string Contenu { get; set; }

        [Required]
        [ReadOnly(true)]

        public DateTime DateDeCreation { get; set; }

        
        //public Titre Titre { get; set; }vjevzujnvznjvnjfnjnjfnjfjnfnjrzknlr
    }
}
