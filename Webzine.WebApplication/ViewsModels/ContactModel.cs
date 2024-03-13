// <copyright file="ContactModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.ViewModels
{
    /// <summary>
    /// Modèle de vue pour un contact.
    /// </summary>
    public class ContactModel
    {
        /// <summary>
        /// Obtient ou définit la liste des contacts sous forme de chaînes.
        /// </summary>
        public IEnumerable<object> ListString { get; set; } = new List<string>();

        /// <summary>
        /// Obtient ou définit la liste des boutons avec leurs informations associées.
        /// </summary>
        public IEnumerable<object> ListButton { get; set; } = new List<Dictionary<string, string>>();
    }
}