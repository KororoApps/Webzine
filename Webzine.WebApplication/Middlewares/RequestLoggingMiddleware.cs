// <copyright file="RequestLoggingMiddleware.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Middlewares
{
    /// <summary>
    /// Middleware responsable de l'enregistrement des informations de requête.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestLoggingMiddleware> logger;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RequestLoggingMiddleware"/>.
        /// </summary>
        /// <param name="next">La fonction de rappel suivante dans le pipeline de requête.</param>
        /// <param name="logger">Le logger utilisé pour l'enregistrement des informations.</param>
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Méthode d'invocation du middleware.
        /// </summary>
        /// <param name="context">Le contexte de la requête HTTP.</param>
        /// <returns>Une tâche représentant l'exécution du middleware.</returns>
        public async Task Invoke(HttpContext context)
        {
            // Log request information
            this.logger.LogInformation($"Path from middleware : {context.Request.Path}");
            this.logger.LogDebug($"Query from middleware : {context.Request.QueryString}");

            // Call the next middleware in the pipeline
            await this.next(context);
        }
    }
}
