namespace Webzine.WebApplication.Middlewares
{

    public class SingularizeMiddleware 
    {
        private readonly RequestDelegate _next;

        public SingularizeMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            // Modifier le chemin de la requête si nécessaire
            var path = context.Request.Path.Value;
            var action = context.Request.RouteValues["action"]?.ToString()?.ToLower();

            if (path.Contains("/administration/artistes"))
            {
                // Remplacer "artistes" par "artiste" uniquement pour les actions delete, create, edit
                if (action == "Delete" || action == "Create" || action == "Edit")
                {
                    path = path.Replace("/administration/artistes", "/administration/artiste");
                    context.Request.Path = path;
                }
            }

            await _next(context);
        }
    }
}
