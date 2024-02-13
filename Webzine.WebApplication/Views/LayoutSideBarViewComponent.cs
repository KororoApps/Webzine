// ViewComponents/LayoutSectionViewComponent.cs
using Microsoft.AspNetCore.Mvc;

using Webzine.WebApplication.Shared.Factories;
using Webzine.WebApplication.Shared.ViewModels;

namespace Webzine.WebApplication.Shared.Views
{
    /// <summary>
    /// Description du composant.
    /// </summary>
    public class LayoutSideBarViewComponent : ViewComponent
    {

        private readonly StyleFactory styleFactory;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="StyleController"/>.
        /// </summary>
        public LayoutSideBarViewComponent()
        {
            this.styleFactory = new StyleFactory();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // du code ici, on peut faire comme dans un controller
            // à savoir, récupérer un model et le passer à la vue


            var styles = this.styleFactory.CreateStyles(20);

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var styleModel = new GroupeStyleModel
            {
                Styles = styles,
            };
            var vm = styleModel;

            // attention : si cela peut ressembler à un contrôleur, cela n'en
            // est pas un. Le view component ne répond pas à une requête HTTP
            return this.View(vm);

            // ou par exemple nomDeMaVue (au lieu de Default.cshtml)
            // return this.View('nomDeMaVue', vm);
        }
    }
}