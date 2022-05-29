using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LightProductDetails.Models;

namespace LightProductDetails.Controllers
{
    public class ProductApiiController : ApiController
    {
        LifeProductEntities db = new LifeProductEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Product> list = db.Products.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var pro = db.Products.Where(model => model.ID == id).FirstOrDefault();

            return Ok(pro);

        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult ProUpdate(Product p)
        {
            var pro = db.Products.Where(model => model.ID == p.ID).FirstOrDefault();
            if (pro != null)
            {
                pro.ID = p.ID;
                pro.ProductName = p.ProductName;
                pro.Category = p.Category;
                pro.Unit = p.Unit;
                pro.Price = p.Price;


                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }


        [System.Web.Http.HttpDelete]
        public IHttpActionResult ProDelete(int id)
        {
            var emp = db.Products.Where(model => model.ID == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }


    }
}
