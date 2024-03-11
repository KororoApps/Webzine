// <copyright file="LoggingActionFilter.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// LoggingActionFilter.
    /// </summary>
    public class LoggingActionFilter : IActionFilter, IExceptionFilter
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="LoggingActionFilter"/>.
        /// </summary>
        public LoggingActionFilter()
        {
        }

        /// <inheritdoc/>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName
                .Replace(" (Webzine.WebApplication)", "()")
                .Replace("Webzine.WebApplication.", "")
                .Replace("Controllers.", "")
                .Replace("Areas.Administration.", "")
                .Replace(".", "/");
            Logger.Info("Debut de l'action : {actionName}", actionName);
        }

        /// <inheritdoc/>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName
                .Replace(" (Webzine.WebApplication)", "()")
                .Replace("Webzine.WebApplication.", "")
                .Replace("Controllers.", "")
                .Replace("Areas.Administration.", "")
                .Replace(".", "/");
            Logger.Debug("Fin de l'action : {actionName}", actionName);
        }

        /// <inheritdoc/>
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName
                .Replace(" (Webzine.WebApplication)", "()")
                .Replace("Webzine.WebApplication.", "")
                .Replace("Controllers.", "")
                .Replace("Areas.Administration.", "")
                .Replace(".", "/");
            Logger.Error("Exception à : {actionName}", actionName);
        }
    }
}
