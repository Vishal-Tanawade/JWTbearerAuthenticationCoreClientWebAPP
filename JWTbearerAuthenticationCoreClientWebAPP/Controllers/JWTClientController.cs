using JWTbearerAuthenticationCoreClientWebAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JWTbearerAuthenticationCoreClientWebAPP.Controllers
{
    public class JWTClientController : Controller
    {
        // GET: JWTClientController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");

                //http://localhost:60888/api/JWTUserrAuthService/authenticate
                using (var response = await httpClient.PostAsync("http://localhost:60888/api/JWTUserrAuthService/authenticate/", content))
                {
                    //string apiResponse = await response.Content.ReadAsStringAsync();

                    string stringJWT = response.Content.ReadAsStringAsync().Result;


                    JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);
                    if (jwt.Token != null)
                    {
                        HttpContext.Session.SetString("token", jwt.Token);
                        ViewBag.Message = "User logged in successfully!";
                        return View("UserHome");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid email or password!";
                        return RedirectToAction("Index");
                    }



                }


            }
        }

        [HttpGet]
        public ActionResult UserHome()
        {
            return View();
        }

        [HttpPost]
        // GET: JWTClientController/ShowData
        public IActionResult ShowData()
        {
            string baseUrl = "http://localhost:60888/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer",
        HttpContext.Session.GetString("token"));

            HttpResponseMessage response = client.GetAsync("api/JWTUserrAuthService").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Product> data = JsonConvert.DeserializeObject<List<Product>>(stringData);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Unauthorized!";
            }
            else
            {

                return View(data);
            }
            ViewBag.Message = "User logged out successfully!";
            return View("Index");
        }
        // GET: JWTClientController/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            ViewBag.Message = "User logged out successfully!";
            return View("Index");
        }


        // GET: JWTClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JWTClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JWTClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JWTClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JWTClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JWTClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JWTClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
