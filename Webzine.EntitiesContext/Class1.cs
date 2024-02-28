using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Webzine.EntitiesContext
{
    public class WebzineContext: DbContext
    {
        public WebzineContext(DbContextOptions<WebzineContext>options):base(options) { }

    }
}
