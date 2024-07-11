using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaranaWikiAPI.API
{
    //internal class TaranaWikiApi
    //{
    //}

    public class TaranaWikiApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly string _userName;
        private readonly string _password;

        public TaranaWikiApiClient()
        {

            _apiUrl = string.Empty;
            _userName = string.Empty;
            _password = string.Empty;
            _httpClient = new HttpClient();
        }

        public TaranaWikiApiClient(string apiUrl, string userName, string password)
        {
            _apiUrl = apiUrl;
            _userName = userName;
            _password = password;
            _httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };
        }

        // Login to MediaWiki API
        public async Task<string> LoginAsync()
        {
            var requestBody = new
            {
                action = "login",
                lgname = _userName,
                lgpassword = _password,
                format = "json"
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api.php", contentString);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
            return loginResponse.Login.Token;
        }

        // Get page content from MediaWiki API
        public async Task<string> GetPageAsync(string title, string token)
        {
            var requestBody = new
            {
                action = "parse",
                page = title,
                format = "json",
                token = token
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api.php", contentString);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var parseResponse = JsonConvert.DeserializeObject<ParseResponse>(responseBody);
            return parseResponse.Parse.Text["*"];
        }

        // Create a new page in MediaWiki API
        public async Task<string> CreatePageAsync(string title, string content, string token)
        {
            var requestBody = new
            {
                action = "edit",
                title = title,
                text = content,
                token = token,
                format = "json"
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api.php", contentString);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var editResponse = JsonConvert.DeserializeObject<EditResponse>(responseBody);
            return editResponse.Edit.Result;
        }

        // Update an existing page in MediaWiki API
        public async Task<string> UpdatePageAsync(string title, string content, string token)
        {
            var requestBody = new
            {
                action = "edit",
                title = title,
                text = content,
                token = token,
                format = "json"
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api.php", contentString);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var editResponse = JsonConvert.DeserializeObject<EditResponse>(responseBody);
            return editResponse.Edit.Result;
        }

        // Delete a page in MediaWiki API
        public async Task<string> DeletePageAsync(string title, string token)
        {
            var requestBody = new
            {
                action = "delete",
                title = title,
                token = token,
                format = "json"
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api.php", contentString);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var deleteResponse = JsonConvert.DeserializeObject<DeleteResponse>(responseBody);
            return deleteResponse.Delete.Result;
        }
    }
}
