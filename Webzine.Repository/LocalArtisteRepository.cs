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
        /// <inheritdoc />
        public void Add(Artiste artiste)
        {
            // Génère un nouvel identifiant.
            artiste.IdArtiste = DataFactory.Artistes.Count + 1;

            // Ajoute le nouveal artiste à la liste
            DataFactory.Artistes.Add(artiste);
        }

        /// <inheritdoc />  
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

        /// <inheritdoc />
        public Artiste Find(int idArtiste)
        {
            var artiste = DataFactory.Artistes
                .FirstOrDefault(a => a.IdArtiste == idArtiste);

            return artiste;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public IEnumerable<Artiste> FindAll()
        {
            List<Artiste> artiste = DataFactory.Artistes;

            var orderedArtistes = artiste
                .OrderBy(a => a.Nom)
                .ToList();

            return orderedArtistes;
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new ArgumentNullException(nameof(artiste));
            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public int NombreBioArtistes()
        {
            var nombreArtiste = DataFactory.Artistes
                .Count(a => !string.IsNullOrEmpty(a.Biographie));

            return nombreArtiste;
        }

        /// <inheritdoc />
        public int NombreArtistes()
        {
            var nombreArtiste = DataFactory.Artistes
                .Count;

            return nombreArtiste;
        }
    }
}