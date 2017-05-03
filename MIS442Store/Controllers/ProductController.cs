using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MIS442Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _prodRepo;

        public ProductController()
        {
            _prodRepo = new ProductRepository();
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";
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
        }
        [HttpGet]
        public ActionResult Edit(Product product)
        {

          
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
        }


    }

}