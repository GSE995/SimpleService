using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleService.Models;

namespace SimpleService.Controllers
{
    [RoutePrefix("api/album")]
    public class AlbumController : ApiController
    {

        // GET: api/album
        [Route("all")]
        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("http://jsonplaceholder.typicode.com/albums");

                return JsonConvert.DeserializeObject<ICollection<Album>>(response);
            }
        }

        // GET: api/album/id
        [Route("{albumid}")]
        public async Task<Album> GetAlbumBy(int albumid)
        {
              using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync($"http://jsonplaceholder.typicode.com/albums/{albumid}");

                    return JsonConvert.DeserializeObject<Album>(response);
                }
        }
        // GET: api/album/userid
        [Route("userid/{userid}")]
        public async Task<IEnumerable<Album>> GetAlbumByUserId(int userid)
        {
             using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"http://jsonplaceholder.typicode.com/albums?userId={userid}");

                return JsonConvert.DeserializeObject<ICollection<Album>>(response);
            }
        }
        
        // POST: api/Albums
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Albums/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Albums/5
        public void Delete(int id)
        {
        }
    }
}
