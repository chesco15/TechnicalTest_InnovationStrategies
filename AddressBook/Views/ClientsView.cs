using AddressBook.Data;
using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddressBook.Views
{
    /// Controla la lógica de la aplicación respecto a las operaciones con contactos
    public class ClientsView : INotifyPropertyChanged
    {

        #region [Variables]
        private string controlMessage;
        private string searchCity;

        private ObservableCollection<Clients> searchedContacts;

        private ICommand searchCommand;
        private ICommand listCommand;
        #endregion

        #region [Propieades]
        /// Almacena los contactos resultantes de las diferentes consultas
        public ObservableCollection<Clients> SearchedContacts
        {
            get { return this.searchedContacts; }
            set
            {
                if (!string.Equals(this.searchedContacts, value))
                {
                    this.searchedContacts = value;
                    OnPropertyChanged("SearchedContacts");
                }
            }
        }

        /// Almacena la ciudad por la que se va a buscar en una consulta
        public string SearchCity
        {
            get { return this.searchCity; }
            set
            {
                if (!string.Equals(this.searchCity, value))
                {
                    this.searchCity = value;
                    OnPropertyChanged("SearchCity");
                }
            }
        }

        /// Mensaje de control para mostrar errores o avisos
        public string ControlMessage
        {
            get { return this.controlMessage; }
            set
            {
                if (!string.Equals(this.controlMessage, value))
                {
                    this.controlMessage = value;
                    OnPropertyChanged("ControlMessage");
                }
            }
        }
        #endregion

        #region [Constructores]
        /// Constructor de la clase ContactsViewModel
        public ClientsView()
        {
            ClientsBD.InitializeClientsDB();

            ControlMessage = "";
            SearchCommand = new Base(param => SearchContacts());
            ListCommand = new Base(param => ListContacts());
        }
        
        #endregion

        #region [Eventos]
        /// Controlador de eventos para propiedades de la clase
        public event PropertyChangedEventHandler PropertyChanged;

        /// Función que lanza la notificación al resto de la aplicación de que una propiedad ha cambiado su valor
        /// <param name="propertyName">Nombre de la propiedad</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region [Metodos]
        /// Comando para ejecutar una función de búsqueda
        public ICommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }

        /// Comando para ejecutar una función de listado
        public ICommand ListCommand
        {
            get { return listCommand; }
            set { listCommand = value; }
        }

        /// Función para buscar contactos en la base de datos, con control de errores
        private void SearchContacts()
        {

            if (SearchCity == null)
            {
                
                ControlMessage = " Por favor, introduzca una ciudad existente.";
                
            }
            else if (ClientsBD.DictionaryClients.ContainsKey(SearchCity))
                SearchedContacts = new ObservableCollection<Clients>(ClientsBD.DictionaryClients[SearchCity]);
            else
                ControlMessage = " No se encuentra ningun cliente con esa ciudad.";
        }

        /// Función para listar los contactos de la base de datos
        private void ListContacts()
        {
            SearchedContacts = new ObservableCollection<Clients>(ClientsBD.Clients);
            ControlMessage = "";
        }
        #endregion

    }
}
