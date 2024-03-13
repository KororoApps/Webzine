// <copyright file="LocalArtisteRepository.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;

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
            var artisteASupprimer = DataFactory.Artistes
                .First(a => a.IdArtiste == artiste.IdArtiste);

            if (artisteASupprimer != null)
            {
                DataFactory.Artistes.Remove(artisteASupprimer);
            }
        }

        /// <inheritdoc />
        public void Update(Artiste artiste)
        {
            var artisteAEditer = DataFactory.Artistes
                .First(a => a.IdArtiste == artiste.IdArtiste);

            if (artisteAEditer != null)
            {
                artisteAEditer.Nom = artiste.Nom;
                artisteAEditer.Biographie = artiste.Biographie;
            }
        }

        /// <inheritdoc />
        public IEnumerable<Artiste?> FindAll()
        {
            return DataFactory.Artistes;
        }

        /// <inheritdoc />
        public Artiste Find(int idArtiste)
        {
            return DataFactory.Artistes
                .Single(t => t.IdArtiste == idArtiste);
        }

        /// <inheritdoc />
        public IEnumerable<Artiste?> FindArtistes(int offset, int limit)
        {
            return DataFactory.Artistes
                .OrderBy(t => t.Nom.ToLower())
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        /// <inheritdoc />
        public Artiste? FindByName(string nomArtiste)
        {
            Artiste artiste = DataFactory.Artistes.FirstOrDefault(a => a.Nom == nomArtiste);

            if (artiste != null)
            {
                artiste.Titres = DataFactory.Titres.Where(t => t.Artiste.Nom == nomArtiste).ToList();
            }

            return artiste;
        }

        /// <inheritdoc />
        public IEnumerable<Artiste?> Search(string mot)
        {
            return DataFactory.Artistes
                .Where(t => t.Nom.Contains(mot, StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(t => t.Nom)
                .ToList();
        }
    }
}