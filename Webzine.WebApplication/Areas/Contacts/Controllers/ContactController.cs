using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Contacts.Controllers
{
    using Webzine.WebApplication.Areas.Contacts.ViewModels;

    [Area("Contacts")]
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            //génération des contacts
            string CompanyName = "C.U.C.D.B - DIIAGE";
            string Address = "69 Avenue Aristide Briand";
            string VilleDepartement = "21000 Dijon";
            string Phone = "03 80 73 45 90";
            string Mail = "secretariat@cucdb.fr";
            ContactModel contacts = new()
            {
                listString =
                [
                    CompanyName,
                    Address,
                    VilleDepartement,
                    Phone,
                    Mail,
                ],
            };
            /// <summary>
            /// Retour de la vue
            /// <summary>
            return this.View(contacts);
        }
    }
}