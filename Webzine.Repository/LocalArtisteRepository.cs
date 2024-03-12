using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SpotifyAPI.Web;
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
            DataFactory.Artistes.Remove(artiste);
        }

        /// <inheritdoc />
        public Artiste Find(int idArtiste)
        {
            return DataFactory.Artistes
                .Single(t => t.IdArtiste == idArtiste);

        }

        /// <inheritdoc />
        public Artiste FindByName(string nomArtiste)
        {
            Artiste artiste = DataFactory.Artistes.FirstOrDefault(a => a.Nom == nomArtiste);

            if (artiste != null)
            {
                artiste.Titres = DataFactory.Titres.Where(t => t.Artiste.Nom == nomArtiste).ToList();
            }

            return artiste;
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindAll()
        {
            return DataFactory.Artistes;
        }

        /// <inheritdoc />
        public IEnumerable<Artiste> FindArtistes(int offset, int limit)
        {
            return DataFactory.Artistes
                .OrderBy(t => t.Nom.ToLower())
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        /// <inheritdoc />
        public void Update(Artiste artiste)
        {
            var artisteAEditer = DataFactory.Artistes
                .First(a => a.IdArtiste  == artiste.IdArtiste);

            if (artisteAEditer != null)
            {
                artisteAEditer.Nom = artiste.Nom;
                artisteAEditer.Biographie = artiste.Biographie;
            }
        }

        /// <summary>
        /// Renvoie les résultats de la recherche coté artistes.
        public IEnumerable<Artiste> Search(string mot)
        {

            return DataFactory.Artistes
                .Where(t => t.Nom.ToUpper().Contains(mot.ToUpper()))
                .OrderBy(t => t.Nom)
                .ToList();

        }
    }
}