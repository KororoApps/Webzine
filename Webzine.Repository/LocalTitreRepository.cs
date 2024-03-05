using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{

    /// <summary>
    /// Implémente l'interface ITitreRepository pour les opérations liées à la gestion des titres dans une source de données locale.
    /// </summary>
    public class LocalTitreRepository : ITitreRepository
    {

        /// <inheritdoc />
        public void Add(Titre titre)
        {
            // Génère un nouvel identifiant
            titre.IdTitre = DataFactory.Titres.Count + 1;
            titre.DateCreation = DateTime.Now;

            // Ajoute le nouveau titre à la liste
            DataFactory.Titres.Add(titre);
        }

        /// <inheritdoc />
        public int Count()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Delete(Titre titre)
        {
            // Recherche le titre dans la liste
            var titreASupprimer = DataFactory.Titres
                .FirstOrDefault(t => t.IdTitre == titre.IdTitre);

            // Supprime le titre s'il existe
            if (titreASupprimer != null)
            {
                DataFactory.Titres
                    .Remove(titreASupprimer);
            }
        }

        /// <inheritdoc />
        public Titre Find(int id)
        {
            var titre =  DataFactory.Titres
                .FirstOrDefault(t => t.IdTitre == id);

            return titre;
        }

        /// <inheritdoc />
        public IEnumerable<Titre> FindAll()
        {
            List<Titre> titres = DataFactory.Titres;

            var orderedTitres = titres
                .OrderByDescending(c => c.DateCreation)
                .ToList();

            return orderedTitres;
        }

        /// <inheritdoc />
        public Titre FindTitreLePlusLu()
        {
            var titre = DataFactory.Titres
                .OrderByDescending(t => t.NbLectures)
                .FirstOrDefault();

            return titre;
        }

        /// <inheritdoc />
        public List<Titre> FindTitresLesPlusLike()
        {
            var titres = DataFactory.Titres
                .OrderByDescending(t => t.NbLikes)
                .Take(3)
                .ToList ();

            return titres;
        }

        /// <inheritdoc />
        public List<Titre> ParutionChroniqueTitres()
        {
            var titres = DataFactory.Titres
                .OrderByDescending(t => t.DateCreation)
                .Take(3)
                .ToList();

            return titres;
        }

        /// <inheritdoc />
        public int NombreTitres()
        {
            var nombreTitres = DataFactory.Titres
                .Count;

            return nombreTitres;
        }

        /// <inheritdoc />
        public int NombreLikes()
        {
            var nombreLikes = DataFactory.Titres
                .Sum(t => t.NbLikes);

            return nombreLikes;
        }

        /// <inheritdoc />
        public int NombreLectures()
        {
            var nombreLectures = DataFactory.Titres
                .Sum(t => t.NbLectures);

            return nombreLectures;
        }

        /// <inheritdoc />
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void IncrementNbLectures(Titre titre)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void IncrementNbLikes(Titre titre)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public List<Titre> Search(string mot)
        {
            List<Titre> titres = DataFactory.Titres;

            var results = titres
                .Where(t => t.Libelle.Contains(mot))
                .OrderBy(t => t.Libelle)
                .Select(t => new
                {
                    Titre = t,
                    Artiste = DataFactory.Artistes.FirstOrDefault(a => a.IdArtiste == t.Artiste.IdArtiste) // Supposons que ArtisteId soit la clé étrangère
                })
                .ToList();

            // Maintenant, 'results' contient des objets anonymes avec les titres et les artistes associés
            // Vous pouvez ensuite extraire les titres si nécessaire
            var orderedTitres = results.Select(r => r.Titre).ToList();

            return orderedTitres;
        }


        /// <inheritdoc />
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            List<Titre> titres = DataFactory.Titres;

            var orderedTitres = titres
                .Where(t => t.Styles.Any(s => s.Libelle.Equals(libelle)))
                .OrderByDescending(c => c.Libelle)
                .ToList();

            return orderedTitres;
        }

        /// <inheritdoc />
        public void Update(Titre titre)
        {
            throw new NotImplementedException();
        }
    }
}
