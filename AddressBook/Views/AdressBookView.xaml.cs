using AddressBook.Views;
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

namespace AddressBook.Views
{
    /// <summary>
    /// Lógica de interacción para ContactsView.xaml
    /// </summary>
    public partial class ContactsView : Page
    {
        public ContactsView()
        {

            ClientsView clientsVM = new ClientsView();
            DataContext = clientsVM;
            InitializeComponent();
        }

        private void contactsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
