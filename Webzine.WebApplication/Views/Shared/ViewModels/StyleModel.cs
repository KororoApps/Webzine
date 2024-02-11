using Webzine.Entity;
namespace Webzine.WebApplication.Views.Shared.ViewModels
{
    public class StyleModel
    {

        /// <summary>
        /// Définit la liste des styles
        /// </summary>
        public IEnumerable<Style> Styles { get; set; } = new List<Style>();
    }
}
