// <copyright file="DashboardServiceTests.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Business.Tests
{
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;

    [TestClass]
    public class DashboardServiceTests
    {
        private readonly LocalTitreRepository titreRepository = new LocalTitreRepository();
        private readonly LocalStyleRepository styleRepository = new LocalStyleRepository();
        private readonly LocalArtisteRepository artisteRepository = new LocalArtisteRepository();

        [TestInitialize]
        public void Initialize()
        {
            DataFactory.Artistes.Clear();
            DataFactory.Titres.Clear();
            DataFactory.Styles.Clear();

            var artistes = new List<Artiste>
            {
                new Artiste
                {
                    IdArtiste = 1,
                    Nom = "Keane",
                    Biographie = "Bio 1",
                    Titres = new List<Titre>
                    {
                        new Titre
                        {
                            Libelle = "Smowhere only we know",
                            Duree = "120",
                            Album = "Keane",
                            Chronique = "Chronique 1",
                            Artiste = new Artiste { IdArtiste = 1, Nom = "Keane" },
                            Styles = new List<Style>
                            {
                                new Style{
                                    IdStyle = 1,
                                    Libelle = "Pop",
                                },
                                new Style
                                {
                                    IdStyle = 2,
                                    Libelle = "Rock",
                                },
                            },
                            NbLectures = 5,
                            NbLikes = 2,
                        },
                        new Titre
                        {
                            Libelle = "Everybody's Changing",
                            Duree = "110",
                            Album = "Keane",
                            Chronique = "Chronique 2",
                            Artiste = new Artiste { IdArtiste = 1, Nom = "Keane" },
                            Styles = new List<Style>
                            {
                                new Style{
                                    IdStyle = 3,
                                    Libelle = "Metal",
                                },
                            },
                            NbLectures = 10,
                            NbLikes = 4,
                        },
                    },
                },
                new Artiste
                {
                    IdArtiste = 3,
                    Nom = "Porter Robinson",
                    Titres = new List<Titre>
                    {
                        new Titre
                        {
                            Libelle = "Everything Goes On",
                            Duree = "90",
                            Album = "Gardiens des étoiles",
                            Chronique = "Chronique 1",
                            Artiste = new Artiste { IdArtiste = 3, Nom = "Porter Robinson" },
                            Styles = new List<Style>
                            {
                                new Style{
                                    IdStyle = 4,
                                    Libelle = "Lyric",
                                },
                            },
                            NbLectures = 30,
                            NbLikes = 15,
                        },
                    },
                },
            };

            foreach (var artiste in artistes)
            {
                this.artisteRepository.Add(artiste);

                foreach (var titre in artiste.Titres)
                {
                    this.titreRepository.Add(titre);

                    foreach (var style in titre.Styles)
                    {
                        this.styleRepository.Add(style);
                    }
                }
            }
        }

    [TestMethod]
    public void TestFindArtisteLePlusChronique()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var artisteLePlusChronique = dashboardService.FindArtisteLePlusChronique();

        // Assert
        Assert.IsNotNull(artisteLePlusChronique);
        Assert.AreEqual("Keane", artisteLePlusChronique.Nom);
    }

    [TestMethod]
    public void TestFindArtisteLePlusTitresAlbumDistinct()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var artisteLePlusTitresAlbumDistinct = dashboardService.FindArtisteLePlusTitresAlbumDistinct();

        // Assert
        Assert.IsNotNull(artisteLePlusTitresAlbumDistinct);
        Assert.AreEqual("Keane", artisteLePlusTitresAlbumDistinct.Nom);
    }

    [TestMethod]
    public void TestFindTitreLePlusLu()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var titreLePlusLu = dashboardService.FindTitreLePlusLu();

        // Assert
        Assert.IsNotNull(titreLePlusLu);
        Assert.AreEqual("Everything Goes On", titreLePlusLu.Libelle);
    }

    [TestMethod]
    public void TestNombreArtistes()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var nombreArtistes = dashboardService.NombreArtistes();

        // Assert
        Assert.IsNotNull(nombreArtistes);
        Assert.AreEqual(2, nombreArtistes);
    }

    [TestMethod]
    public void TestNombreBiographiesArtistes()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var nombreBiographieArtistes = dashboardService.NombreBiographiesArtistes();

        // Assert
        Assert.IsNotNull(nombreBiographieArtistes);
        Assert.AreEqual(1, nombreBiographieArtistes);
    }

    [TestMethod]
    public void TestNombreLectures()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var NombreLectures = dashboardService.NombreLectures();

        // Assert
        Assert.IsNotNull(NombreLectures);
        Assert.AreEqual(45, NombreLectures);
    }

    [TestMethod]
    public void TestNombreLikes()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var NombreLikes = dashboardService.NombreLikes();

        // Assert
        Assert.IsNotNull(NombreLikes);
        Assert.AreEqual(21, NombreLikes);
    }

    [TestMethod]
    public void TestNombreStyles()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var NombreStyles = dashboardService.NombreStyles();

        // Assert
        Assert.IsNotNull(NombreStyles);
        Assert.AreEqual(4, NombreStyles);
    }

    [TestMethod]
    public void TestNombreTitres()
    {
        // Arrange
        var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

        // Act
        var NombreTitres = dashboardService.NombreTitres();

        // Assert
        Assert.IsNotNull(NombreTitres);
        Assert.AreEqual(3, NombreTitres);
    }
}
}
