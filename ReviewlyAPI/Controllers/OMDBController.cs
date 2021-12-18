using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReviewlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OMDBController : ControllerBase
    {
        public class Movies
        {
            public string Title { get; }
            public string Year { get; }
            public string Genre { get; }
            public string imdbID { get; }

        }

        static HttpClient client = new HttpClient();

        
        public async Task<List<Movies>> GetMovie()
        {
            string searchTerm = null;
            List<Movies> movieList = new List<Movies>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://www.omdbapi.com/?t={searchTerm}&apikey=e2953175"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<List<Movies>>(apiResponse);
                }
            }

            return movieList;

            
        }
    }
}
