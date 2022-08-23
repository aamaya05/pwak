using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteAPI.Helpers;
using Newtonsoft.Json;
using BackEnd.DAL;



namespace ClienteAPI.Controllers
{
    public class EjercicioController : Controller
    {


        // GET: EjercicioController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/ejercicio/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.EjercicioViewModel> ejercicios = JsonConvert.DeserializeObject<List<Models.EjercicioViewModel>>(content);

                ViewBag.Title = "Todos los ejercicios";
                return View(ejercicios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET:EjercicioController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/ejercicio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.EjercicioViewModel ejercicioViewModel  = response.Content.ReadAsAsync<Models.EjercicioViewModel>().Result;

            return View(ejercicioViewModel);
        }



        // GET: EjercicioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EjercicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.EjercicioViewModel ejercicio, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/ejercicio", ejercicio);
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

        // GET: EjercicioController/Edit/5

        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/ejercicio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.EjercicioViewModel ejercicioViewModel = response.Content.ReadAsAsync<Models.EjercicioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(ejercicioViewModel);
        }

        // POST:EjercicioController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.EjercicioViewModel ejercicio, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/ejercicio", ejercicio);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: EjercicioController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/ejercicio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.EjercicioViewModel ejercicioViewModel = response.Content.ReadAsAsync<Models.EjercicioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(ejercicioViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.EjercicioViewModel category)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/ejercicio/" + category.IdEjercicio.ToString());
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
