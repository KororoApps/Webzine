using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Titres.ViewModels
{
    public class TitreModel
    {
        
            /// <summary>
            /// Définit la liste des titres
            /// </summary>
            public IEnumerable <Titre> Titres { get; set; } = new List<Titre>();
        }
    }


