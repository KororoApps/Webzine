// <copyright file="SeedDataSpotify.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.EntitiesContext.Seeders
{
    using Bogus;
    using Microsoft.Extensions.Configuration;
    using SpotifyAPI.Web;
    using Webzine.Entity;
    using static SpotifyAPI.Web.SearchRequest;

    /// <summary>
    /// Classe statique pour le seeding des données Spotify dans la base de données.
    /// </summary>
    public static class SeedDataSpotify
    {
        /// <summary>
        /// Méthode pour effectuer une requête Spotify et remplir la base de données.
        /// </summary>
        /// <param name="context">Contexte de la base de données.</param>
        /// <param name="spotifyConnexion">Configuration Spotify.</param>
        /// <returns>Tâche asynchrone.</returns>
        public static async Task Request(WebzineDbContext context, IConfigurationSection spotifyConnexion)
        {
            // Création de la configuration du client Spotify
            var config = SpotifyClientConfig.CreateDefault();

            var clientId = spotifyConnexion.GetSection("ClientId")?.Value;
            var clientSecret = spotifyConnexion.GetSection("ClientSecret")?.Value;

            // Création de la demande d'octroi de client (Client Credentials Grant)
            var request = new ClientCredentialsRequest(clientId, clientSecret);

            // Obtention du jeton d'accès OAuth en utilisant la demande d'octroi de client
            var response = await new OAuthClient(config).RequestToken(request);

            // Configuration du client Spotify avec le jeton d'accès obtenu
            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            // Création d'un objet Faker pour la génération de données aléatoires
            var faker = new Faker();

            // Initialisation d'une liste de styles pour les genres récupérés
            List<Style> stylesContext = [];

            // Initialisation d'une liste pour stocker les noms d'artistes récupérés de Spotify
            List<string> artistesRecuperesSpotify = [];

            // Obtenir 6 genre de la liste des genres recommandés
            var genres = (await spotify.Browse.GetRecommendationGenres()).Genres.OrderBy(genre => Guid.NewGuid()).Take(6).ToList();

            // Pour chaque genre dans la liste des genres recommandés...
            foreach (var genre in genres)
            {
                // Pause entre chaque recherche pour éviter les limitations de l'API
                Thread.Sleep(100);

                // Recherche des artistes liés au genre actuel
                SearchResponse artistesSearchResponse = await spotify.Search.Item(new SearchRequest(Types.Artist, "genre:" + genre)
                {
                    // Limiter le nombre de résultats à 3 artistes par genre
                    Limit = 3,
                });

                if (artistesSearchResponse.Artists.Items != null)
                {
                    // Pour chaque artiste dans les résultats de la recherche...
                    foreach (var artiste in artistesSearchResponse.Artists.Items)
                    {
                        if (!artistesRecuperesSpotify.Contains(artiste.Name))
                        {
                            // Initialisation d'une liste de style vide pour récupérer les styles qui existent dans le context et déjà sauvegardé
                            // en comparant aux genres de l'artiste
                            List<Style> listeStyles = [];

                            // Pour chaque genre de l'artiste...
                            foreach (var genreArtiste in artiste.Genres.Take(3)) // Limiter le nombre de styles à 3 par artiste
                            {
                                // Recherche du style correspondant dans la liste des styles déjà existants
                                var styleArtiste = stylesContext.SingleOrDefault(s => s.Libelle == genreArtiste);

                                if (styleArtiste == null)
                                {
                                    styleArtiste = new Style
                                    {
                                        Libelle = genreArtiste,
                                    };

                                    // AJOUT DES STYLES DANS LA BDD
                                    stylesContext.Add(styleArtiste);
                                }

                                // Ajout du style à la liste de styles de l'artiste
                                // Liste qui est ajoutée aux titres
                                // Ainsi, le Titre fait référence aux styles de son artiste
                                listeStyles.Add(styleArtiste);
                            }

                            // Création d'un nouvel objet Artiste
                            var newArtiste = new Artiste
                            {
                                Nom = artiste.Name,

                                // Génération d'une biographie nulle avec 20% de probabilité
                                Biographie = faker.Random.Bool(0.8f) ? faker.Lorem.Paragraphs() : null,
                            };

                            // AJOUT D'ARTISTES DANS LA BDD
                            context.Artistes.Add(newArtiste);

                            // Ajout du nom de l'artiste à la liste pour éviter les doublons
                            artistesRecuperesSpotify.Add(artiste.Name);

                            // Recherche des titres associés à l'artiste actuel
                            SearchResponse titresSearchResponse = await spotify.Search.Item(new SearchRequest(Types.Track, "artits:" + artiste.Name)
                            {
                                // Limiter le nombre de résultats à 10 titres par artiste
                                Limit = 10,
                            });

                            if (titresSearchResponse.Tracks.Items != null)
                            {
                                // Pour chaque titre dans les résultats de la recherche de titres
                                foreach (var titre in titresSearchResponse.Tracks.Items)
                                {
                                    DateTime dateSortie;

                                    // Conversion de la date de Sortie qui peut-être soir nulle, soit au format yyyy- soit au format yyyy-MM soit au format yyyy-MM-dd
                                    // Vérifier si la chaîne est vide
                                    if (DateTime.TryParseExact(titre.Album.ReleaseDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dateObject))
                                    {
                                        dateSortie = dateObject.ToUniversalTime();
                                    }
                                    else if (DateTime.TryParseExact(titre.Album.ReleaseDate, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out DateTime dateObjectAnneeMois))
                                    {
                                        dateSortie = dateObjectAnneeMois.ToUniversalTime();
                                    }
                                    else if (DateTime.TryParseExact(titre.Album.ReleaseDate, "yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateObjectAnnee))
                                    {
                                        dateSortie = dateObjectAnnee.ToUniversalTime();
                                    }
                                    else
                                    {
                                        dateSortie = DateTime.ParseExact("1950-01-01", "yyyy-MM-dd", null);
                                    }

                                    // AJOUT DE TITRES DANS LA BDD
                                    context.Titres.Add(new Titre
                                    {
                                        Libelle = titre.Name,
                                        Artiste = newArtiste,
                                        Duree = (titre.DurationMs / 1000).ToString(),
                                        Album = titre.Album.Name,
                                        Chronique = faker.Lorem.Paragraph(),
                                        UrlJaquette = titre.Album.Images.First().Url,
                                        UrlEcoute = titre.PreviewUrl,
                                        Styles = listeStyles,
                                        NbLikes = titre.Popularity * 500,
                                        NbLectures = titre.Popularity * 5000,
                                        DateSortie = dateSortie,
                                        DateCreation = faker.Date.Recent().ToUniversalTime(),
                                    });
                                }
                            }
                        }
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
