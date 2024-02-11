using Webzine.Entity;
namespace Webzine.WebApplication.Shared.ViewModels
{
    public class GroupeCommentaireModel
    {

        /// <summary>
        /// Définit la liste des commentaires
        /// </summary>
        public IEnumerable<Commentaire> Commentaires { get; set; } = new List<Commentaire>();
    }
}