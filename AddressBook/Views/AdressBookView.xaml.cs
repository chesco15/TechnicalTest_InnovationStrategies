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
    /// Lógica de interacción para AdressBookView.xaml
    public partial class AddressBookView : Page
    {
        public AddressBookView()
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
