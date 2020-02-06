using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    
    /// Clase que se utilizara de modelo para los clientes.
    public class Clients
    {
        #region [Variables]
        private string _name;
        private string _city;
        private string _num;
        #endregion

        #region [Propiedades]
        
        /// Nombre del cliente
        public string Name { 
            
            get { return _name; }
            set {
                _name = value;
            }
        
        }
        /// Ciudad
        public string City
        {

            get { return _city; }
            set
            {
                _city = value;
            }

        }
        /// Número de teléfono
        public string Num
        {
            
            get { return _num; }
            set
            {
                _num = value;
            }

        }
        #endregion
    }
}
