using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cuenta
{
    /// <summary>
    /// Representa una cuenta corriente con operaciones para consultar el saldo,
    /// ingresar y retirar dinero.
    /// </summary>
    public class Cuenta
    {
        private decimal saldo;
        /// <summary>
        /// Obtiene el saldo actual de la cuenta.
        /// </summary>
        /// /// <value>Saldo</value>
        public decimal Saldo
        {
            get { return saldo; }
        }
        /// <summary>
        /// Ingresa una cantidad de dinero a la cuenta.
        /// </summary>
        /// <param name="cantidad">La cantidad a ingresar. Debe ser mayor que 0.</param>
        /// <returns>No devuelve ningún valor</returns>
        public void Ingresar(decimal cantidad)
        {
            if (cantidad > 0)
            {
                saldo += cantidad;
            }
        }
        /// <summary>
        /// Retira una cantidad de dinero de la cuenta.
        /// </summary>
        /// <param name="cantidad">La cantidad a retirar. Debe ser mayor que 0 y no superar el saldo actual.</param>
        /// <returns>La cantidad retirada, o 0 si no se pudo realizar la operación.</returns>
        public decimal Retirar(decimal cantidad)
        {
            decimal retirado = 0; // Cantidad que se retira

            if (cantidad > 0 && cantidad <= saldo)
            {
                retirado = cantidad;
                saldo -= cantidad;
            }
            return retirado;
        }
    }
}