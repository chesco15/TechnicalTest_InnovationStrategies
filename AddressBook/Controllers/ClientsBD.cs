using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    /// Esta clase se encarga de almacenar todos los datos de los clientes
    public static class ClientsBD
    {
        #region [Properties]
        /// Esta lista guardara todos los contactos leidos del archivo .csv
        public static List<Clients> Clients;

        /// Este diccionario almacenara todos los elementos recogidos de la lista de clientes.
        public static Dictionary<string, List<Clients>> DictionaryClients;

        #endregion

        #region [Methods]

        /// Este metodo se encarga de leer los contactos del fichero .csv
        public static void InitializeClientsDB()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Database", Properties.Resources.DataFile);
            Debug.Write(@path);
            Clients = File.ReadLines(path)
                .Skip(1)
                .Where(s => s != "")
                .Select(s => s.Split(new[] { '|' }))
                .Select(n => new Clients
                {
                    Name = n[0],
                    City = n[1],
                    Num = n[2]
                }).ToList();

            DictionaryClients = Clients.GroupBy(x => x.City).ToDictionary(x => x.Key, x => x.ToList());
        }
        #endregion      
    }
}
