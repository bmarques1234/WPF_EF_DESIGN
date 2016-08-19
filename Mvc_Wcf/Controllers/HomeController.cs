using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Wcf.ServiceReference1;
using Mvc_Wcf.Models;

namespace Mvc_Wcf.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client wcfService = new ServiceReference1.Service1Client();

        public ActionResult Index()
        {
            ViewBag.Clients = wcfService.SearchClient("", "");
            return View("Index");
        }

        public ActionResult UpdateList()
        {
            ViewBag.Clients = wcfService.SearchClient("", "");
            return View("Index");
        }

        public ActionResult CreateClient()
        {
            wcfService.CreateClient();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClient(int ID)
        {
            wcfService.DeleteClient(ID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveClient(ClienteBag ClienteBag)
        {
            wcfService.UpdateClient(ClienteBag);
            return RedirectToAction("Index");
        }

        public ActionResult SearchClientByID(int ID) {
            ViewBag.Client = wcfService.SearchClientByID(ID);
            return PartialView("_ClienteInfo", wcfService.SearchClientByID(ID));
        }

        public ActionResult CreateContact(int Id)
        {
            wcfService.CreateContact(Id);
            return PartialView("_ContatoTab", wcfService.SearchContact(Id));
        }

        public ActionResult DeleteContact(int cliId, int conId)
        {
            wcfService.DeleteContact(cliId, conId);
            return PartialView("_ContatoTab", wcfService.SearchContact(cliId));
        }

        public ActionResult SaveContact(ContatoBag ContatoBag)
        {
            wcfService.UpdateContact(ContatoBag);
            //return PartialView("_ContatoTab", wcfService.SearchContact(ContatoBag.Cliente));
            return RedirectToAction("Index");
        }

        public ActionResult SearchContact(int cliId)
        {
            ViewBag.Contact = wcfService.SearchContact(cliId);
            return PartialView("_ContatoTab", wcfService.SearchContact(cliId));
        }

        public ActionResult SearchContactByID(int ID)
        {
            ViewBag.Contact = wcfService.SearchContactByID(ID);
            return PartialView("_ContatoInfo", wcfService.SearchContactByID(ID));
        }
    }
}
