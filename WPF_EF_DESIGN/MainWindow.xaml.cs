using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace WPF_EF_DESIGN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ClientesEntities _context = new ClientesEntities();
        //ObservableCollection<Clientes> cliLista = new ObservableCollection<Clientes>();
        ServiceReference1.Service1Client wcfService = new ServiceReference1.Service1Client();

        public MainWindow()
        {            
            InitializeComponent();
            /*foreach (var c in _context.Clientes)
            {
                cliLista.Add(c);
            }
            listClients.ItemsSource = cliLista;*/
            //cliLista = wcfService.SearchClient();
            try
            {
                var teste = wcfService.SearchClient("", "");
                listClients.ItemsSource = teste;
            }
            catch (CommunicationException e)
            {
                Console.WriteLine(e);
                throw;
            }
            //listClients.ItemsSource = wcfService.SearchClient();
        }

        private void AdicionaTabContato(ServiceReference1.ContatoBag c)
        {
            TabItem item = new TabItem();
            ContatoControl ctrl = new ContatoControl();
            ctrl.DataContext = c;
            item.Content = ctrl;
            item.Header = c.Id.ToString();
            tabControlContacts.Items.Add(item);
            tabControlContacts.SelectedItem = item;
        }

        private void UpdateListBox()
        {
            string valueField = textBoxSearch.Text.ToString();
            string queryField = comboBox.SelectedItem.ToString().ToLower();
            if (checkBoxFilter.IsChecked == true)
            {
                queryField += "obs";
            }
            if (checkBoxFilter1.IsChecked == true)
            {
                queryField += "contato";
            }
            listClients.ItemsSource = wcfService.SearchClient(queryField, valueField);
        }

        private void ResetFilters()
        {
            textBoxSearch.Text = "";
            comboBox.SelectedItem = comboBox.Items[0];
            checkBoxFilter.IsChecked = false;
            checkBoxFilter1.IsChecked = false;
        }

        private void NewClient_Click(object sender, RoutedEventArgs e)
        {
            /*Clientes cli = new Clientes() { Nome = "Não Identificado" };
            _context.Clientes.Add(cli);
            cliLista.Add(cli);*/
            wcfService.CreateClient();
            ResetFilters();
            UpdateListBox();
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if(listClients.SelectedItem != null)
            {
                /*Clientes cli = (Clientes)listClients.SelectedItem;
                cli.Contatos.Clear();
                //_context.Clientes.Remove((Clientes)listClients.SelectedItem);
                //cliLista.Remove((Clientes)listClients.SelectedItem);
                _context.Clientes.Remove(cli);
                cliLista.Remove(cli);*/
                wcfService.DeleteClient((ServiceReference1.ClienteBag)listClients.SelectedItem);
                ResetFilters();
                UpdateListBox();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            /*_context.SaveChanges();
            wcfService.UpdateClient();
            listClients.ItemsSource = wcfService.SearchClient();*/

            if (listClients.SelectedItem != null)
            {
                wcfService.UpdateClient((ServiceReference1.ClienteBag)listClients.SelectedItem);
                ResetFilters();
                UpdateListBox();
            }
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            if(listClients.SelectedItem != null)
            {
                /*Clientes cli = (Clientes)listClients.SelectedItem;
                Contatos con = new Contatos() { Cliente = cli.Id, Nome = "Não identificado" };
                cli.Contatos.Add(con);
                AdicionaTabContato(con);*/
                ServiceReference1.ContatoBag con = wcfService.CreateContact((ServiceReference1.ClienteBag)listClients.SelectedItem);
                AdicionaTabContato(con);
            }
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            if (listClients.SelectedItem != null && tabControlContacts.SelectedItem != null)
            {
                /*Clientes cli = (Clientes)listClients.SelectedItem;
                Contatos con = (Contatos)((ContatoControl)((TabItem)tabControlContacts.SelectedItem).Content).DataContext;
                cli.Contatos.Remove(con);
                tabControlContacts.Items.Remove(tabControlContacts.SelectedItem);
                if(tabControlContacts.Items.Count > 0)
                {
                    tabControlContacts.SelectedIndex = 0;
                }*/
                wcfService.DeleteContact((ServiceReference1.ClienteBag)listClients.SelectedItem, (ServiceReference1.ContatoBag)((ContatoControl)((TabItem)tabControlContacts.SelectedItem).Content).DataContext);
                tabControlContacts.Items.Remove(tabControlContacts.SelectedItem);
                if (tabControlContacts.Items.Count > 0)
                {
                    tabControlContacts.SelectedIndex = 0;
                }
            }
        }

        private void ListClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabControlContacts.Items.Clear();
            if(listClients.SelectedItem != null)
            {
                /*Clientes cli = (Clientes)listClients.SelectedItem;
                foreach(var c in cli.Contatos)
                {
                    AdicionaTabContato(c);
                }*/
                ServiceReference1.ContatoBag[] listCon = wcfService.SearchContact((ServiceReference1.ClienteBag)listClients.SelectedItem);
                //wcfService.SearchContact((ServiceReference1.ClienteBag)listClients.SelectedItem);
                foreach (var c in listCon)
                {
                    AdicionaTabContato(c);
                }
            }
        }

        private void buttomSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdateListBox();
        }

        private void textBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxSearch.Text = "";
        }
    }
}