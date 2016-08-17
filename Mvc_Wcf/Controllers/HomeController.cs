using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Wcf.ServiceReference1;

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
                ViewBag.Client = new ClienteBag();
            }
            return View("Index");
        }

        public ActionResult UpdateList()
        {
            ViewBag.Clients = wcfService.SearchClient("", "");
            if (ViewBag.Client == null)
            {
                ViewBag.Client = new ClienteBag();
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
            wcfService.DeleteClient(wcfService.SearchClientByID(ID));
            return RedirectToAction("Index");
        }

        public ActionResult SaveClient(Client cli)
        {
            ClienteBag client = new ClienteBag()
            {
                Cidade = cli.Cidade,
                Endereco = cli.Endereco,
                Estado = cli.Estado,
                Nome = cli.Nome,
                Obs = cli.Obs,
                Telefone = cli.Telefone,
                Id = cli.Id
            };
            wcfService.UpdateClient(client);
            return RedirectToAction("Index");
        }

        public ActionResult SearchClientByID(string ID) {
            ViewBag.Client = wcfService.SearchClientByID(ID);
            ViewBag.Clients = wcfService.SearchClient("", "");
            return View("Index");
        }

        public class Client
        {
            public string Nome;
            public string Cidade;
            public string Endereco;
            public string Estado;
            public string Telefone;
            public string Obs;
            public int Id;
        }
    }
}
