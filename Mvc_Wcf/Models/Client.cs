using Mvc_Wcf.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Wcf.Models
{
    public  class Client
    {
        public  ServiceReference1.Service1Client wcfService = new ServiceReference1.Service1Client();

        public  ClienteBag[] GetClients()
        {
            return wcfService.SearchClient("", "");
        }

        public ClienteBag SearchClientByID(string ID)
        {
            return wcfService.SearchClientByID(ID);
        }

        public  void NewClient()
        {
            wcfService.CreateClient();
        }

        public void DeleteClient(ClienteBag client)
        {
            if (client != null)
            {
                wcfService.DeleteClient(client);
            }
        }

        public  void SaveClient(ClienteBag client)
        {
            if (client != null)
            {
                wcfService.UpdateClient(client);
            }
        }
    }
}