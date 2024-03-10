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
            DataFactory.Titres.Remove(titre);
        }

        /// <inheritdoc />
        public Titre Find(int id)
        {
            return  DataFactory.Titres
                .First(t => t.IdTitre == id);
        }
        /// <inheritdoc />
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return DataFactory.Titres
                .OrderByDescending(t => t.DateCreation)
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<Titre> FindAll()
        {
            return DataFactory.Titres
                .OrderByDescending(c => c.DateCreation)
                .ToList();

        }

        /// <inheritdoc />
        public Titre FindTitreLePlusLu()
        {
            return DataFactory.Titres
                .OrderByDescending(t => t.NbLectures)
                .First();

        }

        /// <inheritdoc />
        public List<Titre> FindTitresLesPlusLike(int longueurPeriode)
        {
            // Calcule de la date à partir de laquelle les titres doivent être récupérés
            var dateDebutPeriode = DateTime.Now.AddMonths(-longueurPeriode);

            return DataFactory.Titres
                .Where(t => t.DateCreation >= dateDebutPeriode) //Filtrer les titres créés pendant cette période
                .OrderByDescending(t => t.NbLikes)
                .Take(3)
                .ToList ();

        }


        /// <inheritdoc />
        public int NombreTitres()
        {
            return DataFactory.Titres
                .Count;

        }

        /// <inheritdoc />
        public int NombreLikes()
        {
            return DataFactory.Titres
                .Sum(t => t.NbLikes);

        }

        /// <inheritdoc />
        public int NombreLectures()
        {
            return DataFactory.Titres
                .Sum(t => t.NbLectures);

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
        public IEnumerable<Titre> Search(string mot)
        {
            List<Titre> titres = DataFactory.Titres;

            var results = titres
                .Where(t => t.Libelle.ToUpper().Contains(mot.ToUpper()))
                .OrderBy(t => t.Libelle)
                .Select(t => new
                {
                    Titre = t,
                    Artiste = DataFactory.Artistes.FirstOrDefault(a => a.IdArtiste == t.Artiste.IdArtiste)
                })
                .ToList();

            var orderedTitres = results.Select(r => r.Titre);

            return orderedTitres;
        }




        /// <inheritdoc />
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            return DataFactory.Titres
                .Where(t => t.Styles.Any(s => s.Libelle.Equals(libelle)))
                .OrderByDescending(c => c.Libelle)
                .ToList();

        }

        /// <inheritdoc />
        public void Update(Titre titre)
        {
            var titreAEditer = DataFactory.Titres
                .FirstOrDefault(s => s.IdTitre == titre.IdTitre);

            if (titreAEditer != null)
            {
                titreAEditer.Artiste = titre.Artiste;
                titreAEditer.Libelle = titre.Libelle;
                titreAEditer.Album = titre.Album;
                titreAEditer.Chronique = titre.Chronique;
                titreAEditer.DateSortie = titre.DateSortie;
                titreAEditer.Duree = titre.Duree;
                titreAEditer.UrlJaquette = titre.UrlJaquette;
                titreAEditer.UrlEcoute = titre.UrlEcoute;
                titre.Styles = titre.Styles;
            }
        }
    }
}
