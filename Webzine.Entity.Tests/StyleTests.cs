namespace Webzine.Entity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests de l'entité <see cref="Style"/>.
    /// Vérifie que les contraintes imposées (nom du champ, longueur max du champ,
    /// champ obligatoire, libellé du champ, clé primaire...) sont bien respectées.
    /// </summary>
    [TestClass]
    public class StyleTests
    {
        /// <summary>
        /// Vérifie que la propriété IdStyle existe.
        /// </summary>
        [TestMethod]
        public void StyleHasIdStyle()
        {
            Common.HasProperty(typeof(Style), nameof(Style.IdStyle));
        }

        /// <summary>
        /// Vérifie que la propriété Libelle existe.
        /// </summary>
        [TestMethod]
        public void StyleHasLibelle()
        {
            Common.HasProperty(typeof(Style), nameof(Style.Libelle));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void StyleHasLibelleDisplayValid()
        {
            Common.AttributDisplay(typeof(Style), nameof(Style.Libelle), "Libellé");
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void StyleHasLibelleRequis()
        {
            Common.AttributRequis(typeof(Style), nameof(Style.Libelle));
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMin pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void StyleHasLibelleTailleMin2()
        {
            Common.AttributLongueurMin(typeof(Style), nameof(Style.Libelle), 2);
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void StyleHasLibelleTailleMax50()
        {
            Common.AttributLongueurMax(typeof(Style), nameof(Style.Libelle), 50);
        }
    }
}