using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool ValidarFecha(int dia, int mes, int year)
        {

            bool fechaValida = false;
            bool esBisiesto = Bisiesto(year);

            if (mes == 2)
            {
                if (esBisiesto == true)
                {
                    if (dia >= 1 && dia <= 29)
                    {
                    fechaValida = true;
                    }
                }

                else
                {
                    if (dia >= 1 && dia <= 28)
                    {
                    fechaValida = true;
                    }
                }
            }

            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                if (dia >= 1 && dia <= 30)
                {
                fechaValida = true;
                }
            }

            else 
            {
                if (dia >= 1 && dia <= 31)
                {
                fechaValida = true;
                }
            }

        return fechaValida;
        }

        bool Bisiesto (int year)
        {
            bool esBisiesto = false;

            if (year % 4 == 0)
            {
            esBisiesto = true;

                if (year % 400 != 0 && year % 100 == 0)
                {
                esBisiesto = false;
                }
            }
            return esBisiesto;
        }

        void SiguienteFecha (ref int dia, ref int mes, ref int year)
        {

            int diaPlus = dia;
            int mesPlus = mes;
            int yearPlus = year;

            bool esBisiesto = Bisiesto(year);
            bool esValido = ValidarFecha(dia, mes, year);

            if (esValido == true)
            {
                diaPlus = dia + 1;

                if (esBisiesto == true)
                {
                    if (mes == 2 && dia == 29)
                    {
                    diaPlus = 1;
                    mesPlus = mes + 1;
                    }
                    else
                    {
                    diaPlus = dia + 1;
                    }
                }

                else
                {
                    if (mes == 2 && dia == 28)
                    {
                    diaPlus = 1;
                    mesPlus = mes + 1;
                    }
                    else
                    {
                    diaPlus = dia + 1;
                    }
                }
          
                if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && dia == 30)
                {
                diaPlus = 1;
                mesPlus = mes + 1;
                }

                else if (dia == 31 && mes != 12)
                {
                diaPlus = 1;
                mesPlus = mes + 1;
                }
                
                if (mes == 12 && dia == 31)
                {
                    diaPlus = 1;
                    mesPlus = 1;
                    yearPlus = year + 1;
                }
            }

          else
            {
            MessageBox.Show("La fecha no es válida");
            }
        }


        private void btnCal_Click(object sender, EventArgs e)
        {
            int year, dia, mes, diaPlus;
            bool fechaValidada;
            fechaValidada = false;
     

            year = int.Parse(Interaction.InputBox("Introduce el año: "));
            mes = int.Parse(Interaction.InputBox("Introduce el mes: "));
            dia = int.Parse(Interaction.InputBox("Introduce el día: "));

            Bisiesto (year);
            fechaValidada = ValidarFecha( dia, mes, year);

            SiguienteFecha(ref dia, ref mes, ref year);


            MessageBox.Show("La siguiente fecha sería:\n\n\nDia: " + diaPlus + "\n\nMes: " + mesPlus + "\n\nAño: " + yearPlus);
            
        }
    }
}
