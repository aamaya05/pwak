using ClienteAPI.Helpers;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteAPI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/usuario/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.UsuarioViewModel> usuarios = JsonConvert.DeserializeObject<List<Models.UsuarioViewModel>>(content);

                ViewBag.Title = "Todos los usuarios";
                return View(usuarios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<Models.UsuarioViewModel>().Result;

            return View(usuarioViewModel);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.UsuarioViewModel usuario, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/usuario", usuario);
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<Models.UsuarioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(usuarioViewModel);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]

        public ActionResult Edit(Models.UsuarioViewModel usuario, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/usuario", usuario);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: ClienteController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<Models.UsuarioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(usuarioViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.UsuarioViewModel category)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/usuario/" + category.IdUsuario.ToString());
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
