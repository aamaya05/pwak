using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteAPI.Controllers
{
    public class HistoricoRutinaEjercicioController : Controller
    {
        // GET: HistoricoRutinaEjercicioController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/cliente/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.HistoricoRutinaEjercicioViewModel> historicoRutinaEjercicios = JsonConvert.DeserializeObject<List<Models.HistoricoRutinaEjercicioViewModel>>(content);

                ViewBag.Title = "Todos los Historicos de Rutina Ejercicios ";
                return View(historicoRutinaEjercicios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET:HistoricoRutinaEjercicioController
        [HttpGet]
        public ActionResult Details(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.HistoricoRutinaEjercicioViewModel historicoRutinaEjercicioViewModel = response.Content.ReadAsAsync<Models.HistoricoRutinaEjercicioViewModel>().Result;

            return View(historicoRutinaEjercicioViewModel);
        }



        // GET: HistoricoRutinaEjercicioController
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoricoRutinaEjercicioController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.HistoricoRutinaEjercicioViewModel historicoRutinaEjercicios, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/cliente", historicoRutinaEjercicios);
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

        // GET: HistoricoRutinaEjercicioController

        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.HistoricoRutinaEjercicioViewModel historicoRutinaEjercicioViewModel = response.Content.ReadAsAsync<Models.HistoricoRutinaEjercicioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(historicoRutinaEjercicioViewModel);
        }

        // POST:HistoricoRutinaEjercicioController
        [HttpPost]
        public ActionResult Edit(Models.HistoricoRutinaEjercicioViewModel historicoRutinaEjercicioViewModel, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/cliente", historicoRutinaEjercicioViewModel);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: HistoricoRutinaEjercicioController
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.HistoricoRutinaEjercicioViewModel historicoRutinaEjercicioViewModel = response.Content.ReadAsAsync<Models.HistoricoRutinaEjercicioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(historicoRutinaEjercicioViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.HistoricoRutinaEjercicioViewModel category)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/cliente/" + category.IdHisRutEjer.ToString());
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
