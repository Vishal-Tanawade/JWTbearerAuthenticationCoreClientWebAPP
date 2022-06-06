using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
