// <copyright file="StyleFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Factories
{
    using Bogus;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Interfaces;

    /// <summary>
    /// Classe de fabrique pour la création d'instances de la classe Style avec des données générées.
    /// </summary>
    public class StyleFactory : IStyleFactory
    {
        private readonly Faker<Style> fakerStyle;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="StyleFactory"/>.
        /// </summary>
        public StyleFactory()
        {
            /// <summary>
            /// Configuration pour la génération de fausses données pour la classe Style.
            /// <summary>
            this.fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => this.CapitalizeFirstLetter(f.Lorem.Word()));
        }

        /// <summary>
        /// Crée une instance de la classe Style avec des données générées.
        /// </summary>
        /// <returns>Instance de la classe Style créée.</returns>
        public Style CreateStyle()
        {
            return this.fakerStyle.Generate();
        }

        /// <summary>
        /// Crée une collection d'instances de la classe Style avec des données générées.
        /// </summary>
        /// <param name="random">Le nombre aléatoire de style à générer.</param>
        /// <returns>Une collection d'instances de la classe Style.</returns>
        public List<Style> CreateStyles(int random)
        {
            return this.fakerStyle.Generate(random);
        }

        /// <summary>
        /// Met la première lettre d'une chaîne en majuscule.
        /// </summary>
        /// <param name="input">La chaîne à traiter.</param>
        /// <returns>La chaîne avec la première lettre en majuscule.</returns>

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }
    }
}
