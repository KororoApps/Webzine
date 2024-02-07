
namespace Webzine.WebApplication.Areas.Artistes.ViewModels
{
    using Webzine.Entity;

    public class ListeArtistesModel
    {
        public IEnumerable<Artiste> Artistes { get; set; } = new List<Artiste>();
    }
}
