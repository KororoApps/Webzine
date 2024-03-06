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

        /// <summary>
        /// Ajoute un Titre.
        /// </summary>
        /// <param name="titre"></param>
        public void Add(Titre titre)
        {
            // Génère un nouvel identifiant
            titre.IdTitre = DataFactory.Titres.Count + 1;
            titre.DateCreation = DateTime.Now;

            // Ajoute le nouveau titre à la liste
            DataFactory.Titres.Add(titre);
        }

        /// <summary>
        /// Compte le nombre de titre.
        /// </summary>
        public int Count()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprimme un Titre.
        /// </summary>
        /// <param name="Titre"></param>
        public void Delete(Titre titre)
        {
            DataFactory.Titres.Remove(titre);
        }

        /// <summary>
        ///Renvoie le premier Titre ayant l'id mise en paramètre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Titre Find(int id)
        {
            return  DataFactory.Titres
                .First(t => t.IdTitre == id);
        }

        /// <summary>
        /// Renvoie tous les Titres.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> FindAll()
        {
            return DataFactory.Titres
                .OrderByDescending(c => c.DateCreation)
                .ToList();

        }

        /// <summary>
        /// Renvoie tous le titre le plus lu.
        /// </summary>
        /// <returns></returns>
        public Titre FindTitreLePlusLu()
        {
            return DataFactory.Titres
                .OrderByDescending(t => t.NbLectures)
                .First();

        }

        /// <summary>
        /// Renvoie les titres du plus liké au moins liké  et en retourne un certain nombre.
        /// </summary>
        /// <returns></returns>
        public List<Titre> FindTitresLesPlusLike()
        {
            return DataFactory.Titres
                .OrderByDescending(t => t.NbLikes)
                .Take(3)
                .ToList ();

        }

        /// <summary>
        /// Renvoie la liste des titres du plus récent au plus ancien chroniqué et en retourne un certain nombre.
        /// </summary>
        /// <returns></returns>
        public List<Titre> ParutionChroniqueTitres()
        {
            return DataFactory.Titres
                .OrderByDescending(t => t.DateCreation)
                .Take(3)
                .ToList();

        }

        /// <summary>
        /// Renvoie le nombre de titres.
        /// </summary>
        /// <returns></returns>
        public int NombreTitres()
        {
            return DataFactory.Titres
                .Count;

        }

        /// <summary>
        /// Renvoie le nombre de likes totals.
        /// </summary>
        /// <returns></returns>
        public int NombreLikes()
        {
            return DataFactory.Titres
                .Sum(t => t.NbLikes);

        }

        /// <summary>
        /// Renvoie le nombre de lectures totales.
        /// </summary>
        /// <returns></returns>
        public int NombreLectures()
        {
            return DataFactory.Titres
                .Sum(t => t.NbLectures);

        }

        /// <summary>
        /// Retourne les titres demandés (pour la pagination) triés selon la date de création (du plus récent à ancien).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Incrémente le nombre de lecture d'un titre.
        /// </summary>
        /// <returns></returns>
        public void IncrementNbLectures(Titre titre)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Incrémente le nombre de like d'un titre.
        /// </summary>
        /// <returns></returns>
        public void IncrementNbLikes(Titre titre)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le mot recherché.
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le style de musique cherchée.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            return DataFactory.Titres
                .Where(t => t.Styles.Any(s => s.Libelle.Equals(libelle)))
                .OrderByDescending(c => c.Libelle)
                .ToList();

        }

        /// <summary>
        /// Met à jour un titre.
        /// </summary>
        /// <returns></returns>
        public void Update(Titre titre)
        {
            throw new NotImplementedException();
        }
    }
}
