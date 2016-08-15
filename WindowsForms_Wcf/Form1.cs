using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ServiceModel;


namespace WindowsForms_Wcf
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client wcfService = new ServiceReference1.Service1Client();

        public Form1()
        {
            InitializeComponent();
            try
            {
                var teste = wcfService.SearchClient("", "");
                //listClients.ItemsSource = teste;
                listClients.Items.AddRange(teste);
                
            }
            catch (CommunicationException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private void AdicionaTabContato(ServiceReference1.ContatoBag c)
        {
            /*TabItem item = new TabItem();
            ContatoControl ctrl = new ContatoControl();
            ctrl.DataContext = c;
            item.Content = ctrl;
            item.Header = c.Id.ToString();
            tabControlContacts.Items.Add(item);
            tabControlContacts.SelectedItem = item;*/
            
            TabPage item = new TabPage();
            ContatoControl ctrl = new ContatoControl();
            //ctrl.DataBindings.Add(()c);
            //item.Container.Add(ctrl);
            
            item.Text = c.Id.ToString();
            tabControlContacts.TabPages.Add(item);
            tabControlContacts.SelectedTab = item;
        }
        
        private void UpdateListBox()
        {
            string valueField = textBoxSearch.Text.ToString();
            string queryField = comboBox.SelectedItem.ToString().ToLower();
            if (checkBoxFilter.Checked == true)
            {
                queryField += "obs";
            }
            if (checkBoxFilter1.Checked == true)
            {
                queryField += "contato";
            }
            var teste = wcfService.SearchClient(queryField, valueField);
            listClients.Items.Clear();
            listClients.Items.AddRange(teste);
        }

        private void ResetFilters()
        {
            textBoxSearch.Text = "";
            comboBox.SelectedItem = comboBox.Items[0];
            checkBoxFilter.Checked = false;
            checkBoxFilter1.Checked = false;
        }
        
        private void newClient_Click(object sender, EventArgs e)
        {
            wcfService.CreateClient();
            ResetFilters();
            UpdateListBox();
        }

        private void deleteClient_Click(object sender, EventArgs e)
        {
            if (listClients.SelectedItem != null)
            {
                wcfService.DeleteClient((ServiceReference1.ClienteBag)listClients.SelectedItem);
                ResetFilters();
                UpdateListBox();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (listClients.SelectedItem != null)
            {
                ServiceReference1.ClienteBag cli = (ServiceReference1.ClienteBag)listClients.SelectedItem;
                cli.Cidade = textBoxCity.Text;
                cli.Estado = textBoxEstate.Text;
                cli.Nome = textBoxName.Text;
                cli.Obs = textBoxObs.Text;
                cli.Telefone = textBoxPhone.Text;
                cli.Endereco = textBoxAddress.Text;
                //wcfService.UpdateClient((ServiceReference1.ClienteBag)listClients.SelectedItem);
                wcfService.UpdateClient(cli);
                ResetFilters();
                UpdateListBox();
            }
        }

        private void newContact_Click(object sender, EventArgs e)
        {
            if (listClients.SelectedItem != null)
            {
                ServiceReference1.ContatoBag con = wcfService.CreateContact((ServiceReference1.ClienteBag)listClients.SelectedItem);
                AdicionaTabContato(con);
            }
        }

        private void deleteContact_Click(object sender, EventArgs e)
        {
            if (listClients.SelectedItem != null && tabControlContacts.SelectedTab != null)
            {
                //wcfService.DeleteContact((ServiceReference1.ClienteBag)listClients.SelectedItem, (ServiceReference1.ContatoBag)((ContatoControl)((TabItem)tabControlContacts.SelectedItem).Content).DataContext);
                ////////////////wcfService.DeleteContact((ServiceReference1.ClienteBag)listClients.SelectedItem, (ServiceReference1.ContatoBag)((ContatoControl)((TabPage)tabControlContacts.SelectedTab).content).DataContext);
                //tabControlContacts.Items.Remove(tabControlContacts.SelectedItem);
                tabControlContacts.TabPages.Remove(tabControlContacts.SelectedTab);
                /*if (tabControlContacts.Items.Count > 0)
                {
                    tabControlContacts.SelectedIndex = 0;
                }*/
                if (tabControlContacts.TabPages.Count > 0)
                {
                    tabControlContacts.SelectedIndex = 0;
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void listClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tabControlContacts.Items.Clear();
            tabControlContacts.TabPages.Clear();
            /*if (listClients.SelectedItem != null)
            {
                ServiceReference1.ContatoBag[] listCon = wcfService.SearchContact((ServiceReference1.ClienteBag)listClients.SelectedItem);
                foreach (var c in listCon)
                {
                    AdicionaTabContato(c);
                }
            }*/
            if (listClients.SelectedItem != null)
            {
                ServiceReference1.ClienteBag cli = (ServiceReference1.ClienteBag)listClients.SelectedItem;
                textBoxCity.Text = cli.Cidade;
                textBoxEstate.Text = cli.Estado;
                textBoxName.Text = cli.Nome;
                textBoxObs.Text = cli.Obs;
                textBoxPhone.Text = cli.Telefone;
                textBoxAddress.Text = cli.Endereco;


                ServiceReference1.ContatoBag[] listCon = wcfService.SearchContact((ServiceReference1.ClienteBag)listClients.SelectedItem);
                foreach (var c in listCon)
                {
                    AdicionaTabContato(c);
                }
            }
        }
    }
}
