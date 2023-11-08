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

        void SiguienteFecha (int dia, int mes, int year, out int diaPlus, out int mesPlus, out int yearPlus)
        {
            bool esBisiesto = Bisiesto(year);

            if (mes == 2 && esBisiesto)
            {
                diaPlus = dia++;
            }
            else
            {
                diaPlus = dia++;
                mesPlus = mes++;
            }

           

        }


        private void btnCal_Click(object sender, EventArgs e)
        {
            int year, dia, mes, diaPlus, mesPlus, yearPlus;
            bool fechaValidada;
            fechaValidada = false;
     

            year = int.Parse(Interaction.InputBox("Introduce el año: "));
            mes = int.Parse(Interaction.InputBox("Introduce el mes: "));
            dia = int.Parse(Interaction.InputBox("Introduce el día: "));

            Bisiesto (year);
            fechaValidada = ValidarFecha( dia, mes, year);

            SiguienteFecha(dia, mes, year, out diaPlus, out mesPlus, out yearPlus);


            MessageBox.Show("La siguiente fecha sería:\n\n\n\nDia: " + diaPlus + "\n\nMes: " + mesPlus + "\n\nAño: " + yearPlus);
            
        }
    }
}
