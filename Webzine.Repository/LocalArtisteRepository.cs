using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalArtisteRepository : IArtisteRepository
    {
        /// <summary>
        /// Ajoute un Artiste aux fausses données
        /// </summary>
        /// <param name="artiste"></param>
        public void Add(Artiste artiste)
        {
            // Génère un nouvel identifiant
            artiste.IdArtiste = DataFactory.Artistes.Count + 1;

            // Ajoute le nouveal artiste à la liste
            DataFactory.Artistes.Add(artiste);
        }

        /// <summary>
        /// Supprimme un artiste aux fausses données
        /// </summary>
        /// <param name="artiste"></param>
        public void Delete(Artiste artiste)
        {
            // Recherche le artiste dans la liste
            var artisteASupprimer = DataFactory.Artistes
                .FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste);

            // Supprime le artiste s'il existe
            if (artisteASupprimer != null)
            {
                DataFactory.Artistes
                    .Remove(artisteASupprimer);
            }
        }

        /// <summary>
        ///Renvoie le premier Artiste ayant l'id mise en paramètre
        /// </summary>
        /// <param name="idArtiste"></param>
        /// <returns></returns>
        public Artiste Find(int idArtiste)
        {
            var artiste = DataFactory.Artistes
                .FirstOrDefault(a => a.IdArtiste == idArtiste);

            return artiste;
        }

        /// <summary>
        /// Renvoie tous les Artistes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Artiste> FindAll()
        {
            List<Artiste> artiste = DataFactory.Artistes;

            var orderedArtistes = artiste
                .OrderByDescending(a => a.Nom)
                .ToList();

            return orderedArtistes;
        }

        /// <summary>
        /// Retourne les artistes demandés (pour la pagination) triés selon  le nom(du plus récent à ancien)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour un Artiste
        /// </summary>
        /// <returns></returns>
        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }
        }
    }
}