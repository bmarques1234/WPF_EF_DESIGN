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
            if(ViewBag.Client == null) 
            {
                ViewBag.Client = new ClienteBag() 
                {
                    Contatos = new ContatoBag[1]
                };
            }
            if(ViewBag.Contact == null)
            {
                ViewBag.Contact = new ContatoBag[1];
            }
            return View("Index");
        }

        public ActionResult UpdateList()
        {
            ViewBag.Clients = wcfService.SearchClient("", "");
            if (ViewBag.Client == null)
            {
                ViewBag.Client = new ClienteBag()
                {
                    Contatos = new ContatoBag[1]
                };
            }
            if (ViewBag.Contact == null)
            {
                ViewBag.Contact = new ContatoBag[1];
            }
            return View("Index");
        }

        public ActionResult CreateClient()
        {
            wcfService.CreateClient();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClient(string ID)
        {
            wcfService.DeleteClient(int.Parse(ID));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveClient(ClienteBag ClienteBag)
        {
            wcfService.UpdateClient(ClienteBag);
            return RedirectToAction("Index");
        }

        public ActionResult SearchClientByID(string ID) {
            ViewBag.Client = wcfService.SearchClientByID(ID);
            ViewBag.Clients = wcfService.SearchClient("", "");
            ViewBag.Contact = wcfService.SearchContact(int.Parse(ID));
            return View("Index", wcfService.SearchClientByID(ID));
        }

        public ActionResult CreateContact(int Id)
        {
            wcfService.CreateContact(Id);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int cliId, int conId)
        {
            wcfService.DeleteContact(cliId, conId);
            return RedirectToAction("Index");
        }

        public ActionResult SearchContact(int cliId)
        {
            wcfService.SearchContact(cliId);
            return RedirectToAction("Index");
        }
    }
}
