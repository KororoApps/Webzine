namespace Webzine.Entity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests de l'entité <see cref="Artiste"/>.
    /// Vérifie que les contraintes imposées (nom du champ, longueur max du champ,
    /// champ obligatoire, libellé du champ, clé primaire...) sont bien respectées.
    /// </summary>
    [TestClass]
    public class ArtisteTests
    {
        /// <summary>
        /// Vérifie que la propriété IdArtiste existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasIdArtiste()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.IdArtiste));
        }

        /// <summary>
        /// Vérifie que la propriété Nom existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNom()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.Nom));
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMin pour la propriété Nom est correct.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNomTailleMin1()
        {
            Common.AttributLongueurMin(typeof(Artiste), nameof(Artiste.Nom), 2);
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété Nom est correct.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNomTailleMax50()
        {
            Common.AttributLongueurMax(typeof(Artiste), nameof(Artiste.Nom), 50);
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété Nom est correct.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNomDisplayValid()
        {
            Common.AttributDisplay(typeof(Artiste), nameof(Artiste.Nom), "Nom de l'artiste");
        }

        /// <summary>
        /// Vérifie que la propriété Biographie existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasBiographie()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.Biographie));
        }

        /// <summary>
        /// Vérifie que la propriété Titres existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasTitres()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.Titres));
        }
    }
}