using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{

    /// <summary>
    /// Implémente l'interface ITitreRepository pour les opérations liées à la gestion des titres dans la base de données.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe DbTitreRepository.
    /// </remarks>
    /// <param name="context">Le contexte de base de données.</param>
    public class DbTitreRepository(WebzineDbContext context) : ITitreRepository
    {
        private readonly WebzineDbContext _context = context;

        /// <summary>
        /// Ajoute un Titre.
        /// </summary>
        /// <param name="titre"></param>
        public void Add(Titre titre)
        {
            titre.DateCreation = DateTime.Now;

            _context.Add<Titre>(titre);

            _context
                .SaveChanges();
        }

        /// <summary>
        /// Compte le nombre de titre.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _context.Titres
                .Count();

        }

        /// <summary>
        /// Supprimme un Titre.
        /// </summary>
        /// <param name="titre"></param>
        public void Delete(Titre titre)
        {
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
            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.Styles)
                .Single(t => t.IdTitre == idTitre);

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
            //TODO : Les titres sont reliés avec tout ici
            //Retourner que le nécessaire
            //Enlever style
            //Faire passer que le nombre de commentaires
            //Voir peut-être pour plutôt utiliser le FindTitres car il vaut mieux paginer.
            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.Styles)
                .OrderByDescending(t => t.DateCreation)
                .ToList();

        }

        /// <summary>
        /// Renvoie tous le titre le plus lu.
        /// </summary>
        /// <returns></returns>
        public Titre FindTitreLePlusLu()
        {
            return _context.Titres.AsNoTracking()
                .OrderByDescending(t => t.NbLectures)
                .First();

        }

        /// <summary>
        /// Renvoie les titres du plus liké au moins liké  et en retourne un certain nombre.
        /// </summary>
        /// <returns></returns>
        public List<Titre> FindTitresLesPlusLike()
        {
            return _context.Titres.AsNoTracking()
                .OrderByDescending(t => t.NbLikes)
                .Take(3)
                .ToList();

        }

        /// <summary>
        /// Renvoie la liste des titres du plus récent au plus ancien chroniqué et en retourne un certain nombre.
        /// </summary>
        /// <returns></returns>
        public List<Titre> ParutionChroniqueTitres()
        {
            return _context.Titres.AsNoTracking()
                .OrderByDescending(t => t.DateCreation)
                .Take(3)
                .ToList();

        }

        /// <summary>
        /// Renvoie le nombre de titres.
        /// </summary>
        /// <returns></returns>
        /// 
        /// <inheritdoc/> !!!!!!!!!!!!!!!!!!!!!!!
        public int NombreTitres()
        {
            //TODO !! Retourner directement  sans passer par une variable
            //FAIRE CA PARTOUT !!
            //EVITER D'ALLER TROP A LA LIGNE !!
            //REMPLIR LES <return> !!!!! </return> !!!!
            return _context.Titres
                .Count();

        }

        /// <summary>
        /// Renvoie le nombre de likes totals.
        /// </summary>
        /// <returns></returns>
        public int NombreLikes()
        {
            return _context.Titres
                .Sum(t => t.NbLikes);

        }

        /// <summary>
        /// Renvoie le nombre de lectures totales.
        /// </summary>
        /// <returns></returns>
        public int NombreLectures()
        {
            return _context.Titres
                .Sum(t => t.NbLectures);

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
            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
                .Where(t => t.Libelle.ToUpper().Contains(mot.ToUpper()))
                .OrderBy(c => c.Libelle)
                .ToList();

        }


        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le style de musique cherchée.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {

            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
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
