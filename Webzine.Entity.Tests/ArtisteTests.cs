namespace Webzine.Entity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests de l'entit� <see cref="Artiste"/>.
    /// V�rifie que les contraintes impos�es (nom du champ, longueur max du champ,
    /// champ obligatoire, libell� du champ, cl� primaire...) sont bien respect�es.
    /// </summary>
    [TestClass]
    public class ArtisteTests
    {
        /// <summary>
        /// V�rifie que la propri�t� IdArtiste existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasIdArtiste()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.IdArtiste));
        }

        /// <summary>
        /// V�rifie que la propri�t� Nom existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNom()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.Nom));
        }

        /// <summary>
        /// V�rifie que l'attribut LongueurMin pour la propri�t� Nom est correct.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNomTailleMin1()
        {
            Common.AttributLongueurMin(typeof(Artiste), nameof(Artiste.Nom), 2);
        }

        /// <summary>
        /// V�rifie que l'attribut LongueurMax pour la propri�t� Nom est correct.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNomTailleMax50()
        {
            Common.AttributLongueurMax(typeof(Artiste), nameof(Artiste.Nom), 50);
        }

        /// <summary>
        /// V�rifie que l'attribut Display pour la propri�t� Nom est correct.
        /// </summary>
        [TestMethod]
        public void ArtisteHasNomDisplayValid()
        {
            Common.AttributDisplay(typeof(Artiste), nameof(Artiste.Nom), "Nom de l'artiste");
        }

        /// <summary>
        /// V�rifie que la propri�t� Biographie existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasBiographie()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.Biographie));
        }

        /// <summary>
        /// V�rifie que la propri�t� Titres existe.
        /// </summary>
        [TestMethod]
        public void ArtisteHasTitres()
        {
            Common.HasProperty(typeof(Artiste), nameof(Artiste.Titres));
        }
    }
}