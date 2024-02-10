namespace Webzine.WebApplication.ViewModels
{
    public class ContactModel
    {
        /// <summary>
        /// Définit la liste des Contacts
        /// </summary>
        public IEnumerable<object> listString { get; set; } = new List<string>();
        public IEnumerable<object> listButton { get; set; } = new List<Dictionary<string, string>>();
    }
}