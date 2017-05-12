using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using MIS442Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class RegistrationController : Controller
    {
        public RegistrationController()
            {
            _stateRepo = new StateRepository();
            _regRepo = new RegistrationRepository();
            }
        
        // GET: Registration
        private IRegistrationRepository _regRepo;
        private IStateRepository _stateRepo;
        [HttpGet]
        public ActionResult Index()
        {
            
            return View(_regRepo.GetUserRegistrations("Thomas"));
        }
        [HttpGet]
        public ActionResult AddRegistration()
        {
            RegistrationModel reg = new RegistrationModel();
            reg.States = _stateRepo.GetStates();
            return View(reg);
        }
        [HttpPost]
        public ActionResult AddRegistration(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                registration.States = _stateRepo.GetStates();
                return View(registration);
            }
            Registration regData = new Registration();
            regData.RegistrationID = registration.RegistrationID;
            regData.RegistrationDate = registration.RegistrationDate;
            regData.RegistrationProductID = registration.RegistrationProductID;
            regData.RegistrationSerialNumber = registration.RegistrationSerialNumber;
            regData.RegistrationVerified = registration.RegistrationVerified;
            regData.RegistrationUserName = registration.RegistrationUserName;
            regData.RegistrationAddress = registration.RegistrationAddress;
            regData.RegistrationState = registration.RegistrationState;
            regData.RegistrationCity = registration.RegistrationCity;
            regData.RegistrationZip = registration.RegistrationZip;
            regData.RegistrationPhone = registration.RegistrationPhone;
            _regRepo.SaveRegistration(regData);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminIndex()
        {
            return View(_regRepo.GetRegistrations());
        }

    }
}