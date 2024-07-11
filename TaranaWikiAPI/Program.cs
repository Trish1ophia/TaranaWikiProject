using System;
using TaranaWikiAPI.API;

namespace TaranaWikiApi
{
   

        } class Program
    {
        static void Main(string[] args)
        {
            //var api = new TaranaWikiApiClient("http://localhost/TaranaWikiApiPhp/TaranaWikiApi.php", "your-username", "your-password");
            //var token = api.LoginAsync().Result;
            //var pageContent = api.GetPageAsync("YourPageTitle", token).Result;
            //Console.WriteLine(pageContent);


            var api = new TaranaWikiApiClient();

            // Use the PHP API to get articles
            var articles = api.GetArticles();

            // Use the PHP API to get a specific article
            var article = api.GetArticle("Example Article");

    }
}