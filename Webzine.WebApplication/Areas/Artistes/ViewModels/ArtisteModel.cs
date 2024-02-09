namespace Webzine.WebApplication.Areas.Artistes.ViewModels
{
    using Webzine.Entity;
    public class ArtisteModel
    {
        public Artiste Artiste { get; set; } = null;

        public string Nom => this.Artiste.Nom;
        public string Bio => this.Artiste.Biographie;
        public List<Titre> Titres => this.Artiste.Titres;

    }
}
