using Microsoft.EntityFrameworkCore;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    /// <summary>
    /// Implémente l'interface IArtisteRepository pour la gestion des artistes en mémoire locale.
    /// </summary>
    public class LocalArtisteRepository : IArtisteRepository
    {
        /// <summary>
        /// Ajoute un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à ajouter.</param>    
        public void Add(Artiste artiste)
        {
            // Génère un nouvel identifiant.
            artiste.IdArtiste = DataFactory.Artistes.Count + 1;

            // Ajoute le nouveal artiste à la liste
            DataFactory.Artistes.Add(artiste);
        }

        /// <summary>
        /// Supprime un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à supprimer.</param>     
        public void Delete(Artiste artiste)
        {
            // Recherche le artiste dans la liste.
            var artisteASupprimer = DataFactory.Artistes
                .FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste);

            // Supprime le artiste s'il existe.
            if (artisteASupprimer != null)
            {
                DataFactory.Artistes
                    .Remove(artisteASupprimer);
            }
        }

        /// <summary>
        /// Renvoie le premier artiste ayant l'identifiant spécifié.
        /// </summary>
        /// <param name="idArtiste">L'identifiant de l'artiste.</param>
        /// <returns>L'artiste correspondant à l'identifiant.</returns>
        public Artiste Find(int idArtiste)
        {
            var artiste = DataFactory.Artistes
                .FirstOrDefault(a => a.IdArtiste == idArtiste);

            return artiste;
        }

        /// <summary>
        /// Renvoie le premier artiste ayant le nom spécifié.
        /// </summary>
        /// <param name="nomArtiste">Nom de l'artiste.</param>
        /// <returns>L'artiste correspondant au nom fourni.</returns>
        public Artiste FindByName(string nomArtiste)
        {
            var artiste = DataFactory.Artistes
                 .FirstOrDefault(a => a.Nom == nomArtiste);

            if (artiste == null)
            {
                //Exception si on ne trouve pas d'artiste correspondant
                throw new ArgumentNullException();
            }

            return artiste;
        }

        /// <summary>
        /// Renvoie tous les artistes.
        /// </summary>
        /// <returns>Une liste de tous les artistes.</returns>
        public IEnumerable<Artiste> FindAll()
        {
            List<Artiste> artiste = DataFactory.Artistes;

            var orderedArtistes = artiste
                .OrderBy(a => a.Nom)
                .ToList();

            return orderedArtistes;
        }

        /// <summary>
        /// Renvoie les artistes demandés (pour la pagination) triés selon le nom (du plus récent à l'ancien).
        /// </summary>
        /// <param name="offset">La position de départ pour la pagination.</param>
        /// <param name="limit">Le nombre maximum d'artistes à renvoyer.</param>
        /// <returns>Une liste d'artistes paginée et triée.</returns>
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à mettre à jour.</param>
        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }
        }

        /// <summary>
        /// Renvoie l'artiste le plus chroniqué.
        /// </summary>
        /// <returns>L'artiste le plus chroniqué.</returns>
        public Artiste FindArtisteLePlusChronique()
        {
            var artiste = DataFactory.Artistes
                .Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres.Sum(t => t.Chronique != null ? 1 : 0))
                .FirstOrDefault();

            if (artiste != null)
            {
                return artiste;
            }
            else
            {
                throw new Exception("Il n'y a pas d'artiste avec des chroniques");
            }
        }

        /// <summary>
        /// Renvoie l'artiste ayant le plus de titres provenant d'albums distincts.
        /// </summary>
        /// <returns>L'artiste ayant le plus de titres provenant d'albums distincts.</returns>
        public Artiste FindArtisteLePlusTitresAlbumDistinct()
        {
            var artiste = DataFactory.Artistes
                .Where(a => a.Titres != null && a.Titres.Count != 0)
                .OrderByDescending(a => a.Titres
                .GroupBy(t => new { t.Album, t.Artiste }) 
                .Count()) 
                .FirstOrDefault();

            if (artiste != null)
            {
                return artiste;
            }
            else
            {
                throw new Exception("Il n'y a pas d'artiste avec des titres dans des albums distincts");
            }
        }

        /// <summary>
        /// Renvoie le nombre de biographies d'artistes.
        /// </summary>
        /// <returns>Le nombre total de biographies d'artistes.</returns>
        public int NombreBioArtistes()
        {
            var nombreArtiste = DataFactory.Artistes
                .Count(a => !string.IsNullOrEmpty(a.Biographie));

            return nombreArtiste;
        }

        /// <summary>
        /// Renvoie le nombre d'artistes.
        /// </summary>
        /// <returns>Le nombre total d'artistes.</returns>
        public int NombreArtistes()
        {
            var nombreArtiste = DataFactory.Artistes
                .Count;

            return nombreArtiste;
        }
    }
}