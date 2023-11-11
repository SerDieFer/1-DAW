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

            if (mes >= 1 && mes <= 12)
            {

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

        void CalcularSiguiente(ref int dia, ref int mes, ref int year)
        {

            bool esBisiesto = Bisiesto(year);
            bool fechaValida = ValidarFecha(dia, mes, year);

            if (fechaValida == true)
            {
                dia++;

                if (mes == 2)
                {
                    if (esBisiesto == true)
                    {
                        if (dia > 29)
                        {
                            dia = 1;
                            mes++;
                        }
                    }
                    else
                    {
                        if (dia > 28)
                        {
                            dia = 1;
                            mes++;
                        }
                    }
                }

                else if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && dia > 30)
                {
                    dia = 1;
                    mes++;
                }

                else if (dia > 31)
                {
                    dia = 1;
                    mes++;

                    if (mes > 12)
                    {
                        mes = 1;
                        year++;
                    }
                }
            }

            else
            {
                MessageBox.Show("La fecha introducida no es válida");
            }
        }


            private void btnCal_Click(object sender, EventArgs e)
        {
            int year, dia, mes;
            bool fechaIntroducida, fechaSiguiente, bisiestoSN;
     
            year = int.Parse(Interaction.InputBox("Introduce el año: "));
            mes = int.Parse(Interaction.InputBox("Introduce el mes: "));
            dia = int.Parse(Interaction.InputBox("Introduce el día: "));

            bisiestoSN = Bisiesto(year);
            fechaIntroducida = ValidarFecha( dia, mes, year);
            CalcularSiguiente(ref dia, ref mes, ref year);

            fechaSiguiente = ValidarFecha(dia, mes, year);

            if (fechaSiguiente == true)
            {
                MessageBox.Show("La siguiente fecha sería:\n\n\nDia: " + dia + "\n\nMes: " + mes + "\n\nAño: " + year);
            }
        }
    }
}
