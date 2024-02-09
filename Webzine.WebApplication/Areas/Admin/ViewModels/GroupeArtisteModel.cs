using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class GroupeArtisteModel
    {
        /// <summary>
        /// Obtient ou définit le l'artiste.
        /// </summary>
        public IEnumerable<Artiste> Artistes { get; set; } = new List<Artiste>();
    }
}
