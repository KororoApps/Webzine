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

        /// <inheritdoc />
        public void Add(Titre titre)
        {
            titre.DateCreation = DateTime.Now;

            _context.Add<Titre>(titre);

            _context
                .SaveChanges();
        }

        /// <inheritdoc />
        public int Count()
        {
            return _context.Titres
                .Count();

        }

        /// <inheritdoc />
        public void Delete(Titre titre)
        {
            _context.Titres
                .Remove(titre);

            _context
                .SaveChanges();

        }

        /// <inheritdoc />
        public Titre Find(int idTitre)
        {
            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.Styles)
                .Single(t => t.IdTitre == idTitre);

        }

        /// <inheritdoc />
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste) 
                .Include(t => t.Styles)
                .Include(t => t.Commentaires)
                .OrderByDescending(t => t.DateCreation)
                .Skip(offset)
                .Take(limit)
                .ToList();

        }

        /// <inheritdoc />
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

        //// <inheritdoc />
        public Titre FindTitreLePlusLu()
        {
            return _context.Titres.AsNoTracking()
                .OrderByDescending(t => t.NbLectures)
                .First();

        }

        /// <inheritdoc />
        public List<Titre> FindTitresLesPlusLike()
        {
            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
                .Include(t => t.Styles)
                .OrderByDescending(t => t.NbLikes)
                .Take(3)
                .ToList();

        }

        /// <inheritdoc />
        public int NombreTitres()
        {
            //TODO !! Retourner directement  sans passer par une variable
            //FAIRE CA PARTOUT !!
            //EVITER D'ALLER TROP A LA LIGNE !!
            //REMPLIR LES <return> !!!!! </return> !!!!
            return _context.Titres
                .Count();

        }

        /// <inheritdoc />
        public int NombreLikes()
        {
            return _context.Titres
                .Sum(t => t.NbLikes);

        }

        /// <inheritdoc />
        public int NombreLectures()
        {
            return _context.Titres
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
            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
                .Where(t => t.Libelle.ToUpper().Contains(mot.ToUpper()))
                .OrderBy(c => c.Libelle)
                .ToList();

        }

        /// <inheritdoc />
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {

            return _context.Titres.AsNoTracking()
                .Include(t => t.Artiste)
                .Where(t => t.Styles.Any(s => s.Libelle.Equals(libelle)))
                .OrderByDescending(c => c.Libelle)
                .ToList();

        }

        /// <inheritdoc />
        public void Update(Titre titre)
        {

            _context.Update<Titre>(titre);

            _context.SaveChanges();
        }
    }
}
