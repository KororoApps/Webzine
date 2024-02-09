using Bogus;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Artistes.Controllers
{
    using Webzine.WebApplication.Areas.Artistes.ViewModels;
    [Area("Artistes")]
    public class ArtisteController: Controller
    {
        public IActionResult Index(string nomArtiste)
        {
            var artisteFaker = new Faker<Artiste>()
                .RuleFor(a => a.IdArtiste, (f, u) => f.UniqueIndex + 1)
                .RuleFor(a => a.Nom, nomArtiste)
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph());

            var artiste = artisteFaker.Generate();

            Random random = new Random();

            int randomNumber = random.Next(1, 11);

            var titres = GenerateFakeTitres(randomNumber);


            artiste.Titres = titres;

            foreach (var titre in artiste.Titres)
            {
                Console.WriteLine($"Titre: {titre.Libelle}");
                Console.WriteLine($"Durée: {titre.Duree}");
                Console.WriteLine();
            }

            var artisteModel = new ArtisteModel { Artiste = artiste };


            return this.View(artisteModel);
        }

        public List<Titre> GenerateFakeTitres(int numberOfTitles)
        {
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.IdTitre, (f, u) => f.UniqueIndex + 1)
                .RuleFor(t => t.Libelle, (f, u) => f.Lorem.Word())
                .RuleFor(t => t.Duree, (f, u) => TimeSpan.FromMinutes(f.Random.Double(2, 4)))
                .RuleFor(t => t.DateSortie, (f, u) => f.Date.Past())
                .RuleFor(t => t.DateCreation, (f, u) => f.Date.Past())
                .RuleFor(t => t.NbLectures, (f, u) => f.Random.Number(1000, 100000))
                .RuleFor(t => t.NbLikes, (f, u) => f.Random.Number(100, 5000))
                .RuleFor(t => t.Album, (f, u) => f.Lorem.Word())
                .RuleFor(t => t.Chronique, (f, u) => f.Lorem.Paragraphs(5))
                .RuleFor(t => t.UrlJaquette, (f, u) => f.Image.PicsumUrl());

            var fakeTitres = titreFaker.Generate(numberOfTitles);

            return fakeTitres;
        }

        public static string FormatDuration(TimeSpan duration)
        {
            return $"{(int)duration.TotalMinutes}:{duration.Seconds:D2}";
        }
    }
}
