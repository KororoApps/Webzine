// <copyright file="DashboardServiceTests.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Business.Tests
{
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository;

    /// <summary>
    /// Tests unitaires pour la classe DashboardService.
    /// </summary>
    [TestClass]
    public class DashboardServiceTests
    {
        private readonly LocalTitreRepository titreRepository = new();
        private readonly LocalStyleRepository styleRepository = new();
        private readonly LocalArtisteRepository artisteRepository = new();

        /// <summary>
        /// Initialisation des données de test.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            DataFactory.Artistes.Clear();
            DataFactory.Titres.Clear();
            DataFactory.Styles.Clear();

            var artistes = new List<Artiste>
            {
                new()
                {
                    IdArtiste = 1,
                    Nom = "Keane",
                    Biographie = "Bio 1",
                    Titres =
                    [
                        new Titre
                        {
                            Libelle = "Smowhere only we know",
                            Duree = "120",
                            Album = "Keane",
                            Chronique = "Chronique 1",
                            Artiste = new Artiste { IdArtiste = 1, Nom = "Keane" },
                            Styles =
                            [
                                new Style{
                                    IdStyle = 1,
                                    Libelle = "Pop",
                                },
                                new Style
                                {
                                    IdStyle = 2,
                                    Libelle = "Rock",
                                },
                            ],
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
                            Styles =
                            [
                                new Style{
                                    IdStyle = 3,
                                    Libelle = "Metal",
                                },
                            ],
                            NbLectures = 10,
                            NbLikes = 4,
                        },
                    ],
                },
                new()
                {
                    IdArtiste = 3,
                    Nom = "Porter Robinson",
                    Titres =
                    [
                        new Titre
                        {
                            Libelle = "Everything Goes On",
                            Duree = "90",
                            Album = "Gardiens des étoiles",
                            Chronique = "Chronique 1",
                            Artiste = new Artiste { IdArtiste = 3, Nom = "Porter Robinson" },
                            Styles =
                            [
                                new Style{
                                    IdStyle = 4,
                                    Libelle = "Lyric",
                                },
                            ],
                            NbLectures = 30,
                            NbLikes = 15,
                        },
                    ],
                },
            };

            // Ajout des éléments crées dans le Repository
            foreach (var artiste in artistes)
            {
                this.artisteRepository.Add(artiste);

                if (artiste.Titres != null)
                {
                    foreach (var titre in artiste.Titres)
                    {
                        this.titreRepository.Add(titre);

                        if (titre.Styles != null)
                        {
                            foreach (var style in titre.Styles)
                            {
                                this.styleRepository.Add(style);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Teste la méthode FindArtisteLePlusChronique de la classe DashboardService.
        /// </summary>
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

        /// <summary>
        /// Teste la méthode FindArtisteLePlusTitresAlbumDistinct de la classe DashboardService.
        /// </summary>
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

        /// <summary>
        /// Teste la méthode FindTitreLePlusLu de la classe DashboardService.
        /// </summary>
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

        /// <summary>
        /// Teste la méthode NombreArtistes de la classe DashboardService.
        /// </summary>
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

        /// <summary>
        /// Teste la méthode NombreBiographiesArtistes de la classe DashboardService.
        /// </summary>
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

        /// <summary>
        /// Teste la méthode NombreLectures de la classe DashboardService.
        /// </summary>
        [TestMethod]
        public void TestNombreLectures()
        {
            // Arrange
            var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

            // Act
            var nombreLectures = dashboardService.NombreLectures();

            // Assert
            Assert.IsNotNull(nombreLectures);
            Assert.AreEqual(45, nombreLectures);
        }

        /// <summary>
        /// Teste la méthode NombreLikes de la classe DashboardService.
        /// </summary>
        [TestMethod]
        public void TestNombreLikes()
        {
            // Arrange
            var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

            // Act
            var nombreLikes = dashboardService.NombreLikes();

            // Assert
            Assert.IsNotNull(nombreLikes);
            Assert.AreEqual(21, nombreLikes);
        }

        /// <summary>
        /// Teste la méthode NombreStyles de la classe DashboardService.
        /// </summary>
        [TestMethod]
        public void TestNombreStyles()
        {
            // Arrange
            var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

            // Act
            var nombreStyles = dashboardService.NombreStyles();

            // Assert
            Assert.IsNotNull(nombreStyles);
            Assert.AreEqual(4, nombreStyles);
        }

        /// <summary>
        /// Teste la méthode NombreTitres de la classe DashboardService.
        /// </summary>
        [TestMethod]
        public void TestNombreTitres()
        {
            // Arrange
            var dashboardService = new DashboardService(this.titreRepository, this.styleRepository, this.artisteRepository);

            // Act
            var nombreTitres = dashboardService.NombreTitres();

            // Assert
            Assert.IsNotNull(nombreTitres);
            Assert.AreEqual(3, nombreTitres);
        }
    }
}
