using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        public void Add(Commentaire commentaire)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fait semblant de supprimmer un commentaire depuis les fausses données
        /// </summary>
        /// <param name="commentaire"></param>
        public void Delete(Commentaire commentaire)
        {

        }

        /// <summary>
        ///Renvoie un commentaire
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Commentaire Find(int id)
        {
            List<Commentaire> commentaires = DataFactory.Commentaires;
            Commentaire commentaire = commentaires.OrderBy(t => Guid.NewGuid()).FirstOrDefault();
            return commentaire;
        }

        /// <summary>
        /// Renvoie une liste de commentaire par ordre de creation
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindAll()
        {
            List<Commentaire> commentaires = DataFactory.Commentaires;
            var orderedCommentaires = commentaires.OrderByDescending(c => c.DateCreation).ToList();
            return orderedCommentaires;
        }
    }
}
