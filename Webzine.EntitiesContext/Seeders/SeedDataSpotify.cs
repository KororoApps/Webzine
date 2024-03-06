using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Targets.Wrappers;
using SpotifyAPI.Web;
using System.Collections.Generic;
using Webzine.Entity;
using Webzine.Entity.Fixtures;

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

            /*//context.Artistes.AddRange((IEnumerable<Artiste>)spotify.Artists);
            var searchResults = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, "Muse"));
            var limitedArtists = searchResults.Artists.Items.Take(100);

            foreach (var artist in limitedArtists)
            {
                // Ajoute l'artiste à ta base de données
                context.Artistes.Add(new Artiste
                {
                    Nom = artist.Name,
                    // Ajoute d'autres propriétés d'artiste si nécessaire
                });
            }*/

            //context.Artistes.AddRange((IEnumerable<Artiste>)spotify.Artists);F
            //var searchResultsPlaylist = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Playlist, "pop"));

            var searchResultsPlaylist = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Playlist, "\"Pop Culture: \""));


            var limitedPlaylist = searchResultsPlaylist.Playlists.Items.Take(1).ToList();
            //var limitedPlaylist = searchResultsPlaylist.Playlists.Items.First();
            foreach (var playlist in limitedPlaylist)
            {
                //var playlistId = limitedPlaylist.Id;
                var playlistId = playlist.Id;

                var getPlaylist = await spotify.Playlists.Get(playlistId);

                // Accédez à la liste des pistes (pagination prise en compte)
                var tracks = await spotify.Playlists.GetItems(playlistId);

                foreach (var playlistTrack in tracks.Items)
                {



                    // Accédez aux informations de la piste
                    var track = playlistTrack.Track as FullTrack; // Utilisez FullTrack pour obtenir toutes les informations

                    var album = track.Album.Id;
                    // Obtenez des informations détaillées sur l'album, y compris les genres
                    var albumDetails = await spotify.Albums.Get(album);

                    foreach(var genre in albumDetails.Genres)
                    {

                        context.Styles.Add(new Style
                        {
                            Libelle = genre,
                        });

                    }





                        var artiste = track.Artists.First();

                    context.Titres.Add(new Titre
                    {
                        Libelle = track.Name,
                        Duree = track.DurationMs.ToString(),
                        Artiste = new Artiste
                        {
                            Nom = artiste.Name
                        },
                        Album = track.Album.Name,
                        Chronique = "emoisfmsodvi",
                        UrlJaquette = track.Album.Images.First().Url,
                    });
                }


                /*if (playlist.Name != null && playlist.Name.Length > 2 && playlist.Name.Length < 50)
                {
                    //Ajoute l'artiste à ta base de données
                    context.Styles.Add(new Style
                    {
                       // Libelle = playlist.Name.ToString()
                        Libelle = playlist.Name.ToString()
                        // Ajoute d'autres propriétés d'artiste si nécessaire
                    }); ;
                    //context.Styles.Add(new Style(playlist.Name.ToString()));
                }*/
            }
            // SaveChanges après le seeding
            context.SaveChanges();

        }


    }
}


