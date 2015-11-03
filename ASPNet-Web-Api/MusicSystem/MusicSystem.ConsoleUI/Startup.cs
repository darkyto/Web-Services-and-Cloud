namespace MusicSystem.ConsoleUI
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using MusicSystem.Data;
    using Newtonsoft.Json.Linq;

    public class Startup
    {
        private static readonly MusicSystemDbContext Data = new MusicSystemDbContext();
        
        internal static void Main()
        {
            // localhost post may vary on different PCs and after each restart
            var connection = new Uri("http://localhost:62983/");

            PrintXmlAlbums(connection, "api/country");
            PrintXmlCountries(connection, "api/country");
            PrintJsonSongs(connection, "api/song");

            PostCountries(connection, "api/country");
            PostProducers(connection, "api/producer");
            PostGenre(connection, "api/genre");

            GetGenres(connection, "api/genre");
            GetProducer(connection, "api/producer/", 1);

            DeleteGenre(connection, "api/genre/delete/{id}", 5);

        }

        protected static async void PostCountries(Uri connectionUri, string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connectionUri;

                for (int i = 0; i < 5; i++)
                {
                    var jsonEntry = "{\"Name\" : \"Country # " + i + "\"}";

                    var query = new StringContent(jsonEntry, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(path, query);
                    Console.WriteLine(Environment.NewLine + "Added country: " + await response.Content.ReadAsStringAsync());
                }
            }
        }

        protected static async void PostProducers(Uri connectionUri, string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connectionUri;

                for (int i = 0; i < 5; i++)
                {
                    var jsonEntry = "{\"Name\" : \"Proucer#00" + i + "\"}";

                    var query = new StringContent(jsonEntry, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(path, query);
                    Console.WriteLine(Environment.NewLine + "Added producer: " + await response.Content.ReadAsStringAsync());
                }
            }
        }

        protected static async void PostGenre(Uri connectionUri, string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connectionUri;

                for (int i = 0; i < 5; i++)
                {
                    var jsonEntry = "{\"Name\" : \"Genre#" + i + "\"}";

                    var query = new StringContent(jsonEntry, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(path, query);
                    Console.WriteLine(Environment.NewLine + "Added genre: " + await response.Content.ReadAsStringAsync());
                }
            }
        }

        protected static async void PrintXmlAlbums(Uri connectionUri, string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connectionUri;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = await httpClient.GetAsync(path);
                Console.WriteLine(Environment.NewLine + "XML Albums: " + await response.Content.ReadAsStringAsync());

            }
        }

        protected static async void PrintXmlCountries(Uri connectionUri, string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connectionUri;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = await httpClient.GetAsync(path);
                Console.WriteLine(Environment.NewLine + "XML Countries: " + await response.Content.ReadAsStringAsync());
            }
        }

        protected static async void PrintJsonSongs(Uri connectionUri, string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connectionUri;

                var response = await httpClient.GetAsync(path);
                Console.WriteLine(Environment.NewLine + "Songs: " + await response.Content.ReadAsStringAsync());
            }
        }

        protected static async void GetGenres(Uri connectionUri, string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connectionUri;

                var response = await httpClient.GetAsync(path);

                Console.WriteLine(Environment.NewLine + "JSON Added Genre: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void GetProducer(Uri connection, string requestPath, int id)
        {
            if (Data.Producers.Find(id) == null)
            {
                Console.WriteLine("No such producer was found.");
                return;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Name\": \"The Producer From the Put\"}");

                var response = await httpClient.GetAsync(
                    requestPath + id);

                Console.WriteLine(Environment.NewLine + "Modified Producer: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void DeleteGenre(Uri connection, string requestPath, int id)
        {
            if (Data.Genres.Find(id) == null)
            {
                Console.WriteLine("No such genre was found.");
                return;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Name\": \"The Producer From the Put\"}");

                var response = await httpClient.DeleteAsync(requestPath + id);

                Console.WriteLine(Environment.NewLine + "Deleted Genre:: " + await response.Content.ReadAsStringAsync());
            }
        }
    }
}
