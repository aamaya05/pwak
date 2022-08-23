using ClienteAPI.Helpers;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteAPI.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/cliente/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.ClienteViewModel> clientes = JsonConvert.DeserializeObject<List<Models.ClienteViewModel>>(content);

                ViewBag.Title = "Todos los clientes";
                return View(clientes);
            }
            catch (Exception)
            {
                throw;
            }
        }
                

            // GET: ClienteController/Details/5
            [HttpGet]
        public ActionResult Details(int id)
        {

            string accessToken = HttpContext.Session.GetString("JWTToken");

            ServiceRepository serviceObj = new ServiceRepository(accessToken);
            HttpResponseMessage response = serviceObj.GetResponse("api/cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ClienteViewModel clienteViewModel = response.Content.ReadAsAsync<Models.ClienteViewModel>().Result;
            
            return View(clienteViewModel);
        }



        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ClienteViewModel cliente)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/cliente", cliente);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ClienteViewModel clienteViewModel = response.Content.ReadAsAsync<Models.ClienteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(clienteViewModel);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]

        public ActionResult Edit(Models.ClienteViewModel cliente, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/cliente", cliente);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: ClienteController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/cliente/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.ClienteViewModel clienteViewModel = response.Content.ReadAsAsync<Models.ClienteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(clienteViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.ClienteViewModel category)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/cliente/" + category.IdCliente.ToString());
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
