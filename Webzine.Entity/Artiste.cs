using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity
{
    public class Artiste
    {
        public int IdArtiste { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Nom de l'artiste")]
        public string Nom { get; set; }
        public string Biographie { get; set; }
        public List<Titre> Titres { get; set; }

    }
}
