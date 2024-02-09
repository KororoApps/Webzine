using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class TitreModel
    {
        /// <summary>
        /// Obtient ou définit le titre.
        /// </summary>
        public List<Titre> Titres { get; set; } = null!;

        public List<Artiste> Artistes { get; set; } = null!;
    }
}
