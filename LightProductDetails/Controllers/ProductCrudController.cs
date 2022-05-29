using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LightProductDetails.Models;

namespace LightProductDetails.Controllers
{
    public class ProductCrudController : Controller
    {
        // GET: ProductCrud

        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Product> Pro_list = new List<Product>();
            client.BaseAddress = new Uri("http://localhost:50381/api/ProductApii");
            var response = client.GetAsync("ProductApii");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Product>>();
                display.Wait();
                Pro_list = display.Result;
            }


            return View(Pro_list);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pro)
        {


            client.BaseAddress = new Uri("http://localhost:50381/api/ProductApii");
            var response = client.PostAsJsonAsync<Product>("ProductApii", pro);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Create");
        }


        [HttpGet]

        public ActionResult Details(int id)
        {
            Product p = null;
            client.BaseAddress = new Uri("http://localhost:50381/api/ProductApii");
            var response = client.GetAsync("ProductApii?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
                display.Wait();
                p = display.Result;
            }


            return View(p);


        }


        public ActionResult Edit(int id)
        {
            Product p = null;
            client.BaseAddress = new Uri("http://localhost:50381/api/ProductApii");
            var response = client.GetAsync("ProductApii?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
                display.Wait();
                p = display.Result;
            }


            return View(p);


        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            client.BaseAddress = new Uri("http://localhost:50381/api/ProductApii");
            var response = client.PutAsJsonAsync<Product>("ProductApii", p);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            Product p = null;
            client.BaseAddress = new Uri("http://localhost:50381/api/ProductApii");
            var response = client.GetAsync("ProductApii?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
                display.Wait();
                p = display.Result;
            }


            return View(p);


        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:50381/api/ProductApii");
            var response = client.DeleteAsync("ProductApii/" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Delete");


        }



    }
}