﻿// <copyright file="LocalTitreRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Implémente l'interface ITitreRepository pour les opérations liées à la gestion des titres dans une source de données locale.
    /// </summary>
    public class LocalTitreRepository : ITitreRepository
    {
        /// <inheritdoc />
        public void Add(Titre titre)
        {
            // Génère un nouvel identifiant
            titre.IdTitre = DataFactory.Titres.Count + 2;
            titre.DateCreation = DateTime.Now;

            // Ajoute le nouveau titre à la liste
            DataFactory.Titres.Add(titre);
        }

        /// <inheritdoc />
        public int Count()
        {
            return DataFactory.Titres.Count;
        }

        /// <inheritdoc />
        public void Delete(Titre titre)
        {
            var titreASupprimer = DataFactory.Titres
                .SingleOrDefault(s => s.IdTitre == titre.IdTitre);

            if (titreASupprimer != null)
            {
                DataFactory.Titres.Remove(titreASupprimer);
            }
        }

        /// <inheritdoc />
        public void Update(Titre titre)
        {
            var titreAEditer = DataFactory.Titres
                .SingleOrDefault(s => s.IdTitre == titre.IdTitre);

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

        /// <inheritdoc />
        public Titre? Find(int idTitre)
        {
            return DataFactory.Titres
                .SingleOrDefault(t => t.IdTitre == idTitre);
        }

        /// <inheritdoc />
        public IEnumerable<Titre> FindAll()
        {
            return DataFactory.Titres;
        }

        /// <inheritdoc />
        public IEnumerable<Titre?> FindTitres(int offset, int limit)
        {
            return DataFactory.Titres
                .OrderByDescending(t => t.DateCreation)
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        /// <inheritdoc />
        public List<Titre?> FindTitresLesPlusLike(int longueurPeriode)
        {
            // Calcul de la date à partir de laquelle les titres doivent être récupérés
            var dateDebutPeriode = DateTime.Now.AddMonths(-longueurPeriode);

            return DataFactory.Titres
                .Where(t => t.DateCreation >= dateDebutPeriode) // Filtrer les titres créés pendant cette période
                .OrderByDescending(t => t.NbLikes)
                .Take(3)
                .ToList();
        }

        /// <inheritdoc />
        public void IncrementNbLectures(Titre titre)
        {
            Titre existingTitre = DataFactory.Titres
                .FirstOrDefault(t => t.IdTitre == titre.IdTitre);

            existingTitre.NbLectures++;
        }

        /// <inheritdoc />
        public void IncrementNbLikes(Titre titre)
        {
            Titre existingTitre = DataFactory.Titres
                .FirstOrDefault(t => t.IdTitre == titre.IdTitre);

            existingTitre.NbLikes++;
        }

        /// <inheritdoc />
        public IEnumerable<Titre?> Search(string mot)
        {
            List<Titre> titres = DataFactory.Titres.ToList(); // Charger tous les titres en mémoire

            List<Artiste> artistes = DataFactory.Artistes.ToList(); // Charger tous les artistes en mémoire

            if (string.IsNullOrWhiteSpace(mot))
            {
                var results = titres
                   .OrderBy(t => t.Libelle)
                   .Select(t => new
                   {
                       Titre = t,
                       Artiste = artistes.FirstOrDefault(a => a.IdArtiste == t.Artiste.IdArtiste),
                   })
                   .ToList();

                var orderedTitres = results.Select(r => r.Titre);

                return orderedTitres.ToList();
            }
            else
            {
                var results = titres
                    .Where(t => t.Libelle.ToUpper().Contains(mot.ToUpper()))
                    .OrderBy(t => t.Libelle)
                    .Select(t => new
                    {
                        Titre = t,
                        Artiste = artistes.FirstOrDefault(a => a.IdArtiste == t.Artiste.IdArtiste),
                    })
                    .ToList();

                var orderedTitres = results.Select(r => r.Titre);

                return orderedTitres.ToList();
            }
        }

        /// <inheritdoc />
        public IEnumerable<Titre?> SearchByStyle(string libelle)
        {
            return DataFactory.Titres
                .Where(t => t.Styles.Any(s => s.Libelle.Equals(libelle)))
                .OrderByDescending(c => c.Libelle)
                .ToList();
        }
    }
}
