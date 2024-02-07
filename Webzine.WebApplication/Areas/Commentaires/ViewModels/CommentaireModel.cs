using Webzine.Entity;
namespace Webzine.WebApplication.Areas.Titres.ViewModels
{
    public class CommentaireModel
    {

        /// <summary>
        /// Définit la liste des commentaires
        /// </summary>
        public IEnumerable<Commentaire> Commentaires { get; set; } = new List<Commentaire>();
    }
}