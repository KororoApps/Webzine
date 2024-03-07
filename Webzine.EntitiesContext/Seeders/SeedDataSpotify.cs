using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection; // Ajout de cette référence pour IServiceScopeFactory
using Microsoft.Extensions.Configuration;
using Webzine.Entity;
using static SpotifyAPI.Web.SearchRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Webzine.EntitiesContext.Seeders
{
    public static class SeedDataSpotify
    {
        public static async Task Request(IServiceProvider serviceProvider, WebzineDbContext context, IConfigurationSection spotifyConnexion)
        {
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(spotifyConnexion.GetSection("ClientId").Value, spotifyConnexion.GetSection("ClientSecret").Value);
            var response = await new OAuthClient(config).RequestToken(request);
            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            //TODO : ATTENTION BIEN VERIFIER LA TAILLE DES STRING APPORTES


            ////////////TROUVER LES STYLES////////////////////////
            // Obtenir la liste des genres recommandés
            var genres = await spotify.Browse.GetRecommendationGenres();

            var compteur = 0;
            //  Pour chaque genre...            
            foreach (var genre in genres.Genres)
            {
                //AJOUTER DES STYLES
                var genreEntity = new Style { Libelle = genre };
                context.Styles.Add(genreEntity);

            }
            // Enregistrez les modifications dans la base de données
            context.SaveChanges();
            ///////////



            List<string> artistesRecuperesSpotify = new List<string>();
            /////////////TROUVER LES ARTISTES////////////////////////////
            foreach (var genre in genres.Genres)
            {

                compteur++;
                if (compteur > 5)
                {
                    break;
                }
                Thread.Sleep(100);

                SearchResponse artistesSearchResponse = await spotify.Search.Item(new SearchRequest(Types.Artist, "genre:" + genre)
                {
                    // Limitez le nombre de résultats
                    Limit = 10
                });


                foreach (var artiste in artistesSearchResponse.Artists.Items)
                {
                    if (!artistesRecuperesSpotify.Contains(artiste.Name))
                    {
                        //Initialisation d'une liste de style vide pour récupérer les styles qui existent dans le context et déjà sauvegardé
                        //en comparant aux genres de l'artiste
                        List<Style> listeStyles = new List<Style>();

                        foreach (var genreArtiste in artiste.Genres)
                        {
                            foreach (var genreContextStyles in context.Styles)
                            {
                                if (genreArtiste == genreContextStyles.Libelle)
                                {

                                    listeStyles.Add(genreContextStyles);
                                }


                            }
                        }




                        var newArtiste = new Artiste { Nom = artiste.Name };


                        context.Artistes.Add(newArtiste);
                        artistesRecuperesSpotify.Add(artiste.Name);



                        /////////////AJOUTER DES TITRES
                        SearchResponse titresSearchResponse = await spotify.Search.Item(new SearchRequest(Types.Track, "artits:" + artiste.Name)
                        {
                            Limit = 2
                        });



                        foreach (var titre in titresSearchResponse.Tracks.Items)
                        {
                            DateTime dateSortie;

                            //Conversion de la date de Sortie qui peut-être soir nulle, soit au format yyyy- soit au format yyyy-MM soit au format yyyy-MM-dd
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


                            context.Titres.Add(new Titre
                            {
                                Libelle = titre.Name,
                                Artiste = newArtiste,
                                //TODO :  A CONVERTIR
                                Duree = (titre.DurationMs / 1000).ToString(),
                                Album = titre.Album.Name,
                                Chronique = "Merci d'ajouter cette information :)",
                                UrlJaquette = titre.Album.Images.First().Url,
                                UrlEcoute = titre.PreviewUrl,
                                Styles = listeStyles,
                                NbLikes = (titre.Popularity) * 500,
                                NbLectures = (titre.Popularity) * 5000,
                                DateSortie = dateSortie,
                                DateCreation = DateTime.Now.ToUniversalTime(),
                            });
                        }
                        {

                        }
                    }
                }
            }
            context.SaveChanges();




            /*var searchRequest = new SearchRequest(SearchRequest.Types.Track, $"genre:\"{genre}\"")
            {
                // Limitez le nombre de résultats
                Limit = 10
            };

            var searchResponse = await spotify.Search.Item(searchRequest);


            foreach (var track in searchResponse.Tracks.Items)
            {
                var artistEntity = new Artiste
                {
                    Nom = track.Artists.FirstOrDefault()?.Name
                };

                context.Artistes.Add(artistEntity);

                var titreEntity = new Titre
                {
                    Libelle = track.Name,
                    Duree = track.DurationMs.ToString(),
                    Artiste = artistEntity,
                    Album = track.Album.Name,
                    Chronique = "emoisfmsodvi",
                    UrlJaquette = track.Album.Images.First().Url,
                    UrlEcoute = track.PreviewUrl,
                    Styles = new List<Style>()



                };
                //titreEntity.Styles.Add(new Style { Libelle = genre });

                context.Titres.Add(titreEntity);


            }
*/





        }


    }



}
