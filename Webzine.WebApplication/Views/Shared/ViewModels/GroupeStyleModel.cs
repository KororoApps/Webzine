using Webzine.Entity;

namespace Webzine.WebApplication.Views.Shared.ViewModels
{
    public class GroupeStyleModel
    {

        // <summary>
        /// Obtient ou définit un groupe de styles.
        /// </summary>
        public IEnumerable<Style> Styles { get; set; } = new List<Style>();
    }
}
