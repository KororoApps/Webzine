using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class GroupeCommentaireModel
    {
        /// <summary>
        /// Obtient ou définit le commentaire.
        /// </summary>
        public List<Commentaire> Commentaires { get; set; } = null!;
    }
}
