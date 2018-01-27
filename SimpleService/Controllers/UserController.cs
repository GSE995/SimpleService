using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SimpleService.Models;
using SimpleService.EncripterHelper;



namespace SimpleService.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        Encripter encrypter;

        public UserController()
        {
            this.encrypter = new Encripter();
        }

        // GET: api/user/all
        [Route("all")]
        public async Task<ICollection<User>> GetAllUser()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("http://jsonplaceholder.typicode.com/users");

                 var users = JsonConvert.DeserializeObject<ICollection<User>>(response);

                this.encrypter.EncryptEmailAllUsers(users);

                return users;
            }
        }

        // GET: api/user/id
        [Route("{id}")]
        public async Task<User> GetUserById(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"http://jsonplaceholder.typicode.com/users/{id}");

                var user = JsonConvert.DeserializeObject<User>(response);

                this.encrypter.EncryptEmailUser(user);

                return user;
            }
        }


        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
