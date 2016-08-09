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
            listClients.ItemsSource = wcfService.SearchClient();
        }

        private void AdicionaTabContato(ServiceReference1.Contatos c)
        {
            /*TabItem item = new TabItem();
            ContatoControl ctrl = new ContatoControl();
            ctrl.DataContext = c;
            item.Content = ctrl;
            item.Header = c.Id.ToString();
            tabControlContacts.Items.Add(item);
            tabControlContacts.SelectedItem = item;*/
        }

        private void NewClient_Click(object sender, RoutedEventArgs e)
        {
            /*Clientes cli = new Clientes() { Nome = "Não Identificado" };
            _context.Clientes.Add(cli);
            cliLista.Add(cli);*/
            wcfService.CreateClient();
            //listClients.ItemsSource = wcfService.SearchClient();
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
                wcfService.DeleteClient((ServiceReference1.Clientes)listClients.SelectedItem);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //_context.SaveChanges();
            wcfService.UpdateClient();
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            if(listClients.SelectedItem != null)
            {
                /*Clientes cli = (Clientes)listClients.SelectedItem;
                Contatos con = new Contatos() { Cliente = cli.Id, Nome = "Não identificado" };
                cli.Contatos.Add(con);
                AdicionaTabContato(con);*/
                wcfService.CreateContact((ServiceReference1.Clientes)listClients.SelectedItem);
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
                wcfService.DeleteContact((ServiceReference1.Clientes)listClients.SelectedItem, (ServiceReference1.Contatos)tabControlContacts.SelectedItem);
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
                wcfService.SearchContact((ServiceReference1.Clientes)listClients.SelectedItem);
            }
        }
    }
}