using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddressBook.Views
{
    /// Clase base proporciona el comportamiento de los comandos de los elementos de la interfaz de usuario.
    public class Base : ICommand
    {

        #region [Variables]
        private Action<object> execAction;
        private Func<object, bool> canExecFunc;
        #endregion

        #region [Constructors]
        /// Constructor con un solo parametro.
        /// <param name="execAction">Nombre de la función a ejecutar</param>
        public Base(Action<object> execAction)
        {
            this.execAction = execAction;
            this.canExecFunc = null;
        }

        /// Constructor con dos parametros.
        /// <param name="execAction">Nombre de la función a ejecutar</param>
        /// <param name="canExecFunc">Determina si se ejecuta o no la acción</param>
        public Base(Action<object> execAction, Func<object, bool> canExecFunc)
        {
            this.execAction = execAction;
            this.canExecFunc = canExecFunc;
        }
        #endregion

        #region [Methods]
        /// Define el método que determina si el comando puede ejecutarse en su estado actual.
        /// <param name="parameter">Función a ejecutar</param>
        public bool CanExecute(object parameter)
        {
            if (canExecFunc != null)
            {
                return canExecFunc.Invoke(parameter);
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region [Events]
        /// Se produce cuando hay cambios que influyen en si el comando debería ejecutarse o no.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// Define el método al que se llamará cuando se invoque el comando.
        /// <param name="parameter">Acción a ejecutar</param>
        public void Execute(object parameter)
        {
            if (execAction != null)
            {
                execAction.Invoke(parameter);
            }
        }
        #endregion

    }
}
