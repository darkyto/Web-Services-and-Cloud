namespace ConsumeJsonPlaceholderApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            // int userCount = int.Parse(Console.ReadLine());
            // string inputQueryString = Console.ReadLine();

            int count = 10;
            string qureyString = "quo";

            SearchForArticles(qureyString, count);
        }

        private static void SearchForArticles(string qureyString, int count)
        {
            Console.WriteLine("Getting 10 photos with search term 'QUO'.");
            using (var client = new HttpClient())
            {
                string uri = "http://jsonplaceholder.typicode.com/photos";

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    var articles = response.Content.ReadAsStringAsync().Result;
                    var articlesCollection = JsonConvert.DeserializeObject<List<Photo>>(articles);
                    articlesCollection
                        .Where(a => a.Title.Contains(qureyString.ToLower()))
                        .Take(count)
                        .OrderBy(x => x.Title)
                        .ToList()
                        .ForEach(a => Console.WriteLine(
                            "id: {0}\ntitle: {1}\nurl: {2}\nthumbnail: {3}\n ---------------",
                            a.Id , 
                            a.Title, 
                            a.Url, 
                            a.ThumbnailUrl));

                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
    }
}
