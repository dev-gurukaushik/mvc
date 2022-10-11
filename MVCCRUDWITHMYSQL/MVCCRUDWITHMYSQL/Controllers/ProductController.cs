using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUDWITHMYSQL.Models;

namespace MVCCRUDWITHMYSQL.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            List<product> productList = new List<product>();
            using (DBModels dBModel = new DBModels())
            {
                productList = dBModel.products.ToList<product>();
            }
            return View(productList);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            product productModel = new product();
            using (DBModels dBModel = new DBModels())
            {
                productModel = dBModel.products.Where(x => x.ProductID == id).FirstOrDefault();
            }
            return View(productModel);
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            return View(new product());
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(product productModel)
        {
            using (DBModels dBModel = new DBModels())
            {
                dBModel.products.Add(productModel);
                dBModel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            product productModel = new product();
            using (DBModels dBModel = new DBModels())
            {
                productModel = dBModel.products.Where(x => x.ProductID == id).FirstOrDefault();
            }
            return View(productModel);
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(product productModel)
        {
            using (DBModels dbModel = new DBModels())
            {
                dbModel.Entry(productModel).State = System.Data.EntityState.Modified;
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            product productModel = new product();
            using (DBModels dBModel = new DBModels())
            {
                productModel = dBModel.products.Where(x => x.ProductID == id).FirstOrDefault();
            }
            return View(productModel);
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (DBModels dBModel = new DBModels())
            {
                product productModel = dBModel.products.Where(x => x.ProductID == id).FirstOrDefault();
                dBModel.products.Remove(productModel);
                dBModel.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
