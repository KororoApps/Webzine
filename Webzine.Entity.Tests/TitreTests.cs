namespace Webzine.Entity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests de l'entité <see cref="Titre"/>.
    /// Vérifie que les contraintes imposées (nom du champ, longueur max du champ,
    /// champ obligatoire, libellé du champ, clé primaire...) sont bien respectées.
    /// </summary>
    [TestClass]

    /// <summary>
    /// Tests unitaires pour l'entité <see cref="Titre"/>.
    /// Vérifie si les contraintes imposées (nom du champ, longueur max du champ,
    /// champ obligatoire, libellé du champ, clé primaire...) sont respectées.
    /// </summary>
    public class TitreTests
    {
        /// <summary>
        /// Vérifie que la propriété IdTitre existe.
        /// </summary>
        [TestMethod]
        public void TitreHasIdTitre()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.IdTitre));
        }

        /// <summary>
        /// Vérifie que la propriété IdArtiste existe.
        /// </summary>
        [TestMethod]
        public void TitreHasIdArtiste()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.IdArtiste));
        }

        /// <summary>
        /// Vérifie que la propriété Artiste existe.
        /// </summary>
        [TestMethod]
        public void TitreHasArtiste()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Artiste));
        }

        /// <summary>
        /// Vérifie que la propriété Libelle existe.
        /// </summary>
        [TestMethod]
        public void TitreHasLibelle()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Libelle));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasLibelleDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.Libelle), "Titre");
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasLibelleRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.Libelle));
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMin pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasLibelleTailleMin1()
        {
            Common.AttributLongueurMin(typeof(Titre), nameof(Titre.Libelle), 1);
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété Libelle est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasLibelleTailleMax200()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.Libelle), 200);
        }

        [TestMethod]
        public void TitreHasChronique()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Chronique));
        }

        /// <summary>
        /// Vérifie que la propriété Chronique existe.
        /// </summary>
        [TestMethod]
        public void TitreHasChroniqueRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.Chronique));
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété Chronique est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasChroniqueTailleMin10()
        {
            Common.AttributLongueurMin(typeof(Titre), nameof(Titre.Chronique), 10);
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété Chronique est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasChroniqueTailleMax4000()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.Chronique), 4000);
        }

        /// <summary>
        /// Vérifie que la propriété DateCreation existe.
        /// </summary>
        [TestMethod]
        public void TitreHasDateCreation()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.DateCreation));
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété DateCreation est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasDateCreationRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.DateCreation));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété DateCreation est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasDateCreationDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.DateCreation), "Date de création");
        }

        /// <summary>
        /// Vérifie que la propriété Duree existe.
        /// </summary>
        [TestMethod]
        public void TitreHasDuree()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Duree));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété Duree est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasDureeDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.Duree), "Durée en secondes");
        }

        /// <summary>
        /// Vérifie que la propriété DateSortie existe.
        /// </summary>
        [TestMethod]
        public void TitreHasDateSortie()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.DateSortie));
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété DateSortie est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasDateSortieRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.DateSortie));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété DateSortie est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasDateSortieDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.DateSortie), "Date de sortie");
        }

        /// <summary>
        /// Vérifie que la propriété UrlJaquette existe.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlJaquette()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.UrlJaquette));
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété UrlJaquette est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlJaquetteRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.UrlJaquette));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété UrlJaquette est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlJaquetteDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.UrlJaquette), "Jaquette de l'album");
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété UrlJaquette est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlJaquetteTailleMax250()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.UrlJaquette), 250);
        }

        /// <summary>
        /// Vérifie que la propriété UrlEcoute existe.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlEcoute()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.UrlEcoute));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété UrlEcoute est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlEcouteDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.UrlEcoute), "URL d'écoute");
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMin pour la propriété UrlEcoute est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlEcouteTailleMin13()
        {
            Common.AttributLongueurMin(typeof(Titre), nameof(Titre.UrlEcoute), 13);
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété UrlEcoute est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasUrlEcouteTailleMax250()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.UrlEcoute), 250);
        }

        /// <summary>
        /// Vérifie que la propriété NbLectures existe.
        /// </summary>
        [TestMethod]
        public void TitreHasNbLectures()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.NbLectures));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété NbLectures est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasNbLecturesDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.NbLectures), "Nombre de lectures");
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété NbLectures est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasNbLecturesRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.NbLectures));
        }

        /// <summary>
        /// Vérifie que la propriété NbLikes existe.
        /// </summary>
        [TestMethod]
        public void TitreHasNbLikes()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.NbLikes));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété NbLikes est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasNbLikesDisplayValid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.NbLikes), "Nombre de likes");
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété NbLikes est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasNbLikesRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.NbLikes));
        }

        /// <summary>
        /// Vérifie que la propriété Album existe.
        /// </summary>
        [TestMethod]
        public void TitreHasAlbum()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Album));
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété Album est correct.
        /// </summary>
        [TestMethod]
        public void TitreHasAlbumRequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.Album));
        }

        /// <summary>
        /// Vérifie que la propriété Commentaires existe.
        /// </summary>
        [TestMethod]
        public void TitreHasCommentaires()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Commentaires));
        }

        /// <summary>
        /// Vérifie que l'attribut UrlJaquetteeIsNotMandatory est correct.
        /// </summary>
        [TestMethod]
        public void TitreUrlJaquetteeIsNotMandatory()
        {
            Common.AttributHasNotUrlValidation(typeof(Titre), nameof(Titre.UrlJaquette));
        }
    }
}
