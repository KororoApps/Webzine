using Webzine.Entity;

namespace Webzine.WebApplication.Views.Shared.ViewModels
{
    public class GroupeArtisteModel
    {
        /// <summary>
        /// Obtient ou définit un groupe de d'artistes.
        /// </summary>
        public IEnumerable<Artiste> Artistes { get; set; } = new List<Artiste>();
    }
}
