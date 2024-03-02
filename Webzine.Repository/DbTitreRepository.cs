using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{

    /// <summary>
    /// Implémente l'interface ITitreRepository pour les opérations liées à la gestion des titres dans la base de données.
    /// </summary>
    public class DbTitreRepository(WebzineDbContext context) : ITitreRepository
    {
        private readonly WebzineDbContext _context = context;

        /// <summary>
        /// Ajoute un Titre.
        /// </summary>
        /// <param name="titre"></param>
        public void Add(Titre titre)
        {
            if (titre == null)
            {
                throw new ArgumentNullException(nameof(titre));
            }

            titre.DateCreation = DateTime.Now;

            _context.Titres
                .Add(titre);

            _context
                .SaveChanges();
        }

        /// <summary>
        /// Compte le nombre de titre.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            var NombreTitres = _context.Titres
                .Count();

            return NombreTitres;
        }

        /// <summary>
        /// Supprimme un Titre.
        /// </summary>
        /// <param name="titre"></param>
        public void Delete(Titre titre)
        {
            if (titre == null)
            {
                throw new ArgumentNullException(nameof(titre));
            }

            _context.Titres
                .Remove(titre);

            _context
                .SaveChanges();
        }

        /// <summary>
        ///Renvoie le premier Titre ayant l'id mise en paramètre.
        /// </summary>
        /// <param name="idTitre"></param>
        /// <returns></returns>
        public Titre Find(int idTitre)
        {
            var titre = _context.Titres
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.Styles)
                .SingleOrDefault(t => t.IdTitre == idTitre);

            if (titre == null)
            {
                //Exception si on ne trouve pas d'artiste correspondant
                throw new ArgumentNullException();
            }

            return titre;
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
        /// Renvoie tous les Titres.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> FindAll()
        {
            var allTitres = _context.Titres
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.Styles)
                .OrderBy(t => t.Libelle)
                .ToList();

            return allTitres;
        }

        /// <summary>
        /// Renvoie tous le titre le plus lu.
        /// </summary>
        /// <returns></returns>
        public Titre FindTitreLePlusLu()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie les titres du plus liké au moins liké  et en retourne un certain nombre.
        /// </summary>
        /// <returns></returns>
        public List<Titre> FindTitresLesPlusLike()
        {
            var titres = _context.Titres
                .OrderBy(t => t.NbLikes)
                .Take(3)
                .ToList();

            return titres;
        }

        /// <summary>
        /// Renvoie la liste des titres du plus récent au plus ancien chroniqué et en retourne un certain nombre.
        /// </summary>
        /// <returns></returns>
        public List<Titre> ParutionChroniqueTitres()
        {
            var titres = _context.Titres
                .OrderByDescending(t => t.DateCreation)
                .Take(3)
                .ToList();

            return titres;
        }

        /// <summary>
        /// Renvoie le nombre de titres.
        /// </summary>
        /// <returns></returns>
        public int NombreTitres()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie le nombre de likes totals.
        /// </summary>
        /// <returns></returns>
        public int NombreLikes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie le nombre de lectures totales.
        /// </summary>
        /// <returns></returns>
        public int NombreLectures()
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le style de musique cherchée.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {

            List<Titre> titres = _context.Titres
                .Include(t => t.Artiste)
                .Where(t => t.Styles.Any(s => s.Libelle.Equals(libelle)))
                .OrderByDescending(c => c.Libelle)
                .ToList();

            if (titres == null)
            {
                //Exception si on ne trouve pas d'artiste correspondant
                throw new ArgumentNullException();
            }

            return titres;
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
