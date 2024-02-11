using Webzine.Entity;

namespace Webzine.WebApplication.Shared.ViewModels
{
    public class GroupeTitreModel
    {
        /// <summary>
        /// Obtient ou définit un groupe de titres.
        /// </summary>
        public IEnumerable<Titre> Titres { get; set; } = new List<Titre>();
    }
}
