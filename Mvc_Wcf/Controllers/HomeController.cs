using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Wcf.Models;
using Mvc_Wcf.ServiceReference1;

namespace Mvc_Wcf.Controllers
{
    public class HomeController : Controller
    {
        Client clientes = new Client();

        public ActionResult Index()
        {
            return View("Index", clientes.GetClients());
        }

        public ActionResult UpdateList()
        {
            return View("Index", clientes.GetClients());
        }

        public ActionResult CreateClient()
        {
            clientes.NewClient();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClient(string ID)
        {
            clientes.DeleteClient(clientes.SearchClientByID(ID));
            return RedirectToAction("Index");
        }

        public ActionResult SaveClient(ClienteBag client)
        {
            clientes.SaveClient(client);
            return RedirectToAction("Index");
        }
    }
}
