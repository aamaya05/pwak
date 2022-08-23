using ClienteAPI.Helpers;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteAPI.Controllers
{
    public class RutinaController : Controller
    {
        // GET: RutinaController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/rutina/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.RutinaViewModel> rutinas = JsonConvert.DeserializeObject<List<Models.RutinaViewModel>>(content);

                ViewBag.Title = "Todos los ejercicios";
                return View(rutinas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: RutinaController/Details/5
        public ActionResult Details(int id)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/rutina/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.RutinaViewModel rutinaViewModel = response.Content.ReadAsAsync<Models.RutinaViewModel>().Result;

            return View(rutinaViewModel);
        }

        // GET: RutinaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RutinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.RutinaViewModel rutina, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/rutina", rutina);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (HttpRequestException)
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception)
            {
                throw;
            }
        }

        // GET: RutinaController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/rutina/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.RutinaViewModel rutinaViewModel = response.Content.ReadAsAsync<Models.RutinaViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(rutinaViewModel);
        }

        // POST:EjercicioController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.RutinaViewModel rutina, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/rutina", rutina);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: RutinaController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/rutina/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.RutinaViewModel rutinaViewModel = response.Content.ReadAsAsync<Models.RutinaViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(rutinaViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.RutinaViewModel category)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/rutina/" + category.IdRutina.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().Result;

            if (Eliminado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
