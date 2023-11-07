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

        void diaMes(out int dia, out int mes, out bool validarDia, out bool validarMes, ref bool validarBisiesto)
        {
            mes = int.Parse(Interaction.InputBox("Introduce el mes: "));
            dia = int.Parse(Interaction.InputBox("Introduce el día: "));
            validarDia = validarMes = false;


            if (mes >= 1 && mes <= 12)
            {
                validarMes = true;

                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    if (dia >= 1 && dia <= 31)
                    {
                        validarDia = true;
                    }
                }

                if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
                {
                    if (dia >= 1 && dia <= 30)
                    {
                        validarDia = true;
                    }
                }

                if (mes == 2 && validarBisiesto == true)
                {
                    if (dia >= 1 && dia <= 29)
                    {
                        validarDia = true;
                    }
                }

                if (mes == 2 && validarBisiesto == false)
                {
                    if (dia >= 1 && dia <= 28)
                    {
                        validarDia = true;
                    }
                }
            }
        }

        void Bisiesto (out int year, out bool validarBisiesto)
        {
    
            year = int.Parse(Interaction.InputBox("Introduce el año: "));
            validarBisiesto = false;

            if (year % 4 == 0)
            {
                validarBisiesto = true;

                if (year % 400 != 0 && year % 100 == 0)
                {
                validarBisiesto = false;
                }
            }
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int year, dia, mes;
            bool validarBisiesto, validarDia, validarMes;
            string txtS, txtN;
            txtS = "Sería válido";
            txtN = "No sería válido";

            Bisiesto(out year, out validarBisiesto);
            diaMes(out dia, out mes, out validarDia, out validarMes , ref validarBisiesto);
  
            if (validarDia && validarMes == true)
            {
            MessageBox.Show("Dia: " + dia + "\n\nMes: " + mes + "\n\nAño: " + year + "\n\n" + txtS);
            }

            else
            {
            MessageBox.Show("Dia: " + dia + "\n\nMes: " + mes + "\n\nAño: " + year + "\n\n" + txtN);
            }
        }
    }
}
