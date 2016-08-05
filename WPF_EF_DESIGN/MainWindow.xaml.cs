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
        ClientesEntities _context = new ClientesEntities();
        ObservableCollection<Clientes> cliLista = new ObservableCollection<Clientes>();

        public MainWindow()
        {
            InitializeComponent();
            foreach (var c in _context.Clientes)
            {
                cliLista.Add(c);
            }
            listBox1.ItemsSource = cliLista;
        }

        private void AdicionaTabContato(Contatos c)
        {
            TabItem item = new TabItem();
            ContatoControl ctrl = new ContatoControl();
            ctrl.DataContext = c;
            item.Content = ctrl;
            item.Header = c.Id.ToString();
            tabControl1.Items.Add(item);
            tabControl1.SelectedItem = item;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Clientes cli = new Clientes() { Nome = "Não Identificado" };
            _context.Clientes.Add(cli);
            cliLista.Add(cli);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                Clientes cli = (Clientes)listBox1.SelectedItem;
                cli.Contatos.Clear();
                _context.Clientes.Remove((Clientes)listBox1.SelectedItem);
                cliLista.Remove((Clientes)listBox1.SelectedItem);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                Clientes cli = (Clientes)listBox1.SelectedItem;
                Contatos con = new Contatos() { Cliente = cli.Id, Nome = "Não identificado" };
                cli.Contatos.Add(con);
                AdicionaTabContato(con);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(listBox1.SelectedItem != null && tabControl1.SelectedItem != null)
            {
                Clientes cli = (Clientes)listBox1.SelectedItem;
                Contatos con = (Contatos)((ContatoControl)((TabItem)tabControl1.SelectedItem).Content).DataContext;
                cli.Contatos.Remove(con);
                tabControl1.Items.Remove(tabControl1.SelectedItem);
                if(tabControl1.Items.Count > 0)
                {
                    tabControl1.SelectedIndex = 0;
                }
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabControl1.Items.Clear();
            if(listBox1.SelectedItem != null)
            {
                Clientes cli = (Clientes)listBox1.SelectedItem;
                foreach(var c in cli.Contatos)
                {
                    AdicionaTabContato(c);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {

        }
    }
}
