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
    /// <summary>
    /// Controla la lógica de la aplicación respecto a las operaciones con contactos
    /// </summary>
    public class ClientsView : INotifyPropertyChanged
    {

        #region [Variables]
        private string controlMessage;
        private string searchCity;

        private ObservableCollection<Clients> searchedContacts;

        private ICommand searchCommand;
        private ICommand listCommand;
        #endregion

        #region [Properties]
        /// <summary>
        /// Almacena los contactos resultantes de las diferentes consultas
        /// </summary>
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

        /// <summary>
        /// Almacena la ciudad por la que se va a buscar en una consulta
        /// </summary>
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


        /// <summary>
        /// Mensaje de control para mostrar errores o avisos
        /// </summary>
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

        #region [Constructors]
        /// <summary>
        /// Constructor de la clase ContactsViewModel
        /// </summary>
        public ClientsView()
        {
            ClientsBD.InitializeClientsDB();

            ControlMessage = "";
            SearchCommand = new Base(param => SearchContacts());
            ListCommand = new Base(param => ListContacts());
        }
        
        #endregion

        #region [Events]
        /// <summary>
        /// Manejador de eventos para propiedades de la clase
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Función que lanza la notificación al resto de la aplicación de que una propiedad ha cambiado su valor
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region [Methods]
        /// <summary>
        /// Comando para ejecutar una función de búsqueda
        /// </summary>
        public ICommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }

        /// <summary>
        /// Comando para ejecutar una función de listado
        /// </summary>
        public ICommand ListCommand
        {
            get { return listCommand; }
            set { listCommand = value; }
        }

        /// <summary>
        /// Función para buscar contactos en la base de datos
        /// </summary>
        private void SearchContacts()
        {
            if (ClientsBD.DictionaryClients.ContainsKey(SearchCity))
            {
                ControlMessage = "";
                SearchedContacts = new ObservableCollection<Clients>(ClientsBD.DictionaryClients[SearchCity]);
            }
            else
                ControlMessage = "There's no one that lives in that city";
        }

        /// <summary>
        /// Función para listar los contactos de la base de datos
        /// </summary>
        private void ListContacts()
        {
            SearchedContacts = new ObservableCollection<Clients>(ClientsBD.Clients);
            ControlMessage = "";
        }
        #endregion

    }
}
