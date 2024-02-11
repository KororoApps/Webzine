namespace Webzine.WebApplication.Shared.ViewModels
{
    using Webzine.Entity;
    public class ArtisteModel
    {
        public Artiste Artiste { get; set; } = null;

        public string Nom => Artiste.Nom;
        public string Bio => Artiste.Biographie;
        public List<Titre> Titres => Artiste.Titres;

    }
}
