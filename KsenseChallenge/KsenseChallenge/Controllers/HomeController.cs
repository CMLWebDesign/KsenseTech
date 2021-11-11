using KsenseChallenge.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace KsenseChallenge.Controllers
{
    public class HomeController : Controller
    {

        HttpClient client = new HttpClient();
        public IEnumerable<Users> users { get; set; }
        public IEnumerable<UserPost> posts { get; set; }
        public IEnumerable<UserPost> UserPosts { get; set; }
        const string url = "https://jsonplaceholder.typicode.com/";

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Used to populate the dropdown on loading of the view
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri(url + "users");
            message.Headers.Add("Accept", "application/json");


            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                 var responseStream = await response.Content.ReadAsStreamAsync();
                users = await JsonSerializer.DeserializeAsync<IEnumerable<Users>>(responseStream);

            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        /// <summary>
        /// Get the id from the views dropdown submitted by user
        /// </summary>
        public async Task<ActionResult> GetUser(string id)
        {
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri(url + "posts?userId=" + id );
            message.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                posts = await JsonSerializer.DeserializeAsync<IEnumerable<UserPost>>(responseStream);

            }
            return Json(posts, JsonRequestBehavior.AllowGet);
        }
    }
}