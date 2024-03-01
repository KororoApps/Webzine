// <copyright file="ArtisteModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

using Webzine.Entity;

namespace Webzine.WebApplication.Shared.ViewModels
{
    public class DashboardModel
    {
        public int NbArtistes { get; set; }
        public Artiste ArtistePlusChronique { get; set; }
        public Artiste ArtistePlusDeTitres { get; set; }
        public int NbBioArtiste { get; set; }
        public Titre TitrePlusLu { get; set; }
        public int NbTitres { get; set; }
        public int NbStyles { get; set; }
        public int NbLectures { get; set; }
        public int NbLikes { get; set; }
    }
}