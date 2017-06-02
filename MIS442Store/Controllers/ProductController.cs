using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class ProductController : Controller
    {
        private LINQProductRepository _prodRepo;

        public ProductController()
        {
            _prodRepo = new LINQProductRepository();
        }
        [HttpGet]
        public ActionResult Index()
        {
           
            return View(_prodRepo.GetList());
        }

        
        [HttpGet]
        public ActionResult Add()
        {

            return View(new Product());
        }


        [HttpPost]
        public ActionResult Add(Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _prodRepo.Save(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = _prodRepo.Get(id);
            return View(product);
          
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _prodRepo.Save(product);
            return RedirectToAction("Index");
        }
        [OutputCache(Duration = 300)]
        [HttpGet]    
        public ActionResult ViewProduct(int id)
        {
            Product product = _prodRepo.Get(id);
            return View(product);
        }
        
    }

}