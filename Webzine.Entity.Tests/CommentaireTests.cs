// <copyright file="CommentaireTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webzine.Entity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests de l'entité <see cref="Commentaire"/>.
    /// Vérifie que les contraintes imposées (nom du champ, longueur max du champ,
    /// champ obligatoire, libellé du champ, clé primaire...) sont bien respectées.
    /// </summary>
    [TestClass]
    public class CommentaireTests
    {
        /// <summary>
        /// Vérifie que la propriété IdCommentaire existe.
        /// </summary>
        [TestMethod]
        public void CommentaireHasIdCommentaire()
        {
            Common.HasProperty(typeof(Commentaire), nameof(Commentaire.IdCommentaire));
        }

        /// <summary>
        /// Vérifie que la propriété Contenu existe.
        /// </summary>
        [TestMethod]
        public void CommentaireHasContenu()
        {
            Common.HasProperty(typeof(Commentaire), nameof(Commentaire.Contenu));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété Contenu est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasContenuDisplayValid()
        {
            Common.AttributDisplay(typeof(Commentaire), nameof(Commentaire.Contenu), "Commentaire");
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété Contenu est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasContenuRequis()
        {
            Common.AttributRequis(typeof(Commentaire), nameof(Commentaire.Contenu));
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMin pour la propriété Contenu est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasContenuTailleMin10()
        {
            Common.AttributLongueurMin(typeof(Commentaire), nameof(Commentaire.Contenu), 10);
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété Contenu est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasContenuTailleMax1000()
        {
            Common.AttributLongueurMax(typeof(Commentaire), nameof(Commentaire.Contenu), 1000);
        }

        /// <summary>
        /// Vérifie que la propriété Auteur existe.
        /// </summary>
        [TestMethod]
        public void CommentaireHasAuteur()
        {
            Common.HasProperty(typeof(Commentaire), nameof(Commentaire.Auteur));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété Auteur est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasAuteurDisplayValid()
        {
            Common.AttributDisplay(typeof(Commentaire), nameof(Commentaire.Auteur), "Nom");
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété Auteur est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasAuteurRequis()
        {
            Common.AttributRequis(typeof(Commentaire), nameof(Commentaire.Auteur));
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMin pour la propriété Auteur est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasAuteurTailleMin2()
        {
            Common.AttributLongueurMin(typeof(Commentaire), nameof(Commentaire.Auteur), 2);
        }

        /// <summary>
        /// Vérifie que l'attribut LongueurMax pour la propriété Auteur est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasAuteurTailleMax30()
        {
            Common.AttributLongueurMax(typeof(Commentaire), nameof(Commentaire.Auteur), 30);
        }

        /// <summary>
        /// Vérifie que la propriété DateCreation existe.
        /// </summary>
        [TestMethod]
        public void CommentaireHasDateCreation()
        {
            Common.HasProperty(typeof(Commentaire), nameof(Commentaire.DateCreation));
        }

        /// <summary>
        /// Vérifie que l'attribut Requis pour la propriété DateCreation est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasDateCreationRequis()
        {
            Common.AttributRequis(typeof(Commentaire), nameof(Commentaire.DateCreation));
        }

        /// <summary>
        /// Vérifie que l'attribut Display pour la propriété DateCreation est correct.
        /// </summary>
        [TestMethod]
        public void CommentaireHasDateCreationDisplayValid()
        {
            Common.AttributDisplay(typeof(Commentaire), nameof(Commentaire.DateCreation), "Date de création");
        }

        /// <summary>
        /// Vérifie que la propriété IdTitre existe.
        /// </summary>
        [TestMethod]
        public void CommentaireHasIdTitre()
        {
            Common.HasProperty(typeof(Commentaire), nameof(Commentaire.IdTitre));
        }

        /// <summary>
        /// Vérifie que la propriété Titre existe.
        /// </summary>
        [TestMethod]
        public void CommentaireHasTitre()
        {
            Common.HasProperty(typeof(Commentaire), nameof(Commentaire.Titre));
        }
    }
}