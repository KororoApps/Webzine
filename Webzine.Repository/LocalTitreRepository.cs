﻿using Webzine.Entity;
using Webzine.Entity.Fixtures;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalTitreRepository : ITitreRepository
    {

        /// <summary>
        /// Ajoute un Titre aux fausses données
        /// </summary>
        /// <param name="titre"></param>
        public void Add(Titre titre)
        {
            // Génère un nouvel identifiant
            titre.IdTitre = DataFactory.Titres.Count + 1;

            // Ajoute le nouveau titre à la liste
            DataFactory.Titres.Add(titre);
        }

        /// <summary>
        /// Compte le nombre de titre
        /// </summary>
        public int Count()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprimme un Titre aux fausses données
        /// </summary>
        /// <param name="Titre"></param>
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

        /// <summary>
        ///Renvoie le premier Titre ayant l'id mise en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Titre Find(int id)
        {
            var titre =  DataFactory.Titres
                .FirstOrDefault(t => t.IdTitre == id);

            return titre;
        }

        /// <summary>
        /// Renvoie tous les Titres
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> FindAll()
        {
            List<Titre> titres = DataFactory.Titres;

            var orderedTitres = titres
                .OrderByDescending(c => c.DateCreation)
                .ToList();

            return orderedTitres;
        }

        /// <summary>
        /// Retourne les titres demandés (pour la pagination) triés selon la date de création (du plus récent à ancien)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Incrémente le nombre de lecture d'un titre
        /// </summary>
        /// <returns></returns>
        public void IncrementNbLectures(Titre titre)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Incrémente le nombre de like d'un titre
        /// </summary>
        /// <returns></returns>
        public void IncrementNbLikes(Titre titre)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le mot recherché
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> Search(string mot)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recherche de manière insensible à la casse les titres contenant le style de musique cherchée
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour un titre
        /// </summary>
        /// <returns></returns>
        public void Update(Titre titre)
        {
            throw new NotImplementedException();
        }
    }
}
