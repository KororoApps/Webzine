using Webzine.Entity;
namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class GroupeCommentaireModel
    {

        /// <summary>
        /// Définit la liste des commentaires
        /// </summary>
        public IEnumerable<Commentaire> Commentaires { get; set; } = new List<Commentaire>();
    }
}