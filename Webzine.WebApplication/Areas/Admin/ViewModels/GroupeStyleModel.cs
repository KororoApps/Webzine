using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class GroupeStyleModel
    {

        // <summary>
        /// Obtient ou définit un groupe de styles.
        /// </summary>
        public IEnumerable<Style> Styles { get; set; } = new List<Style>();
    }
}
