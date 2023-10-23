using System;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables
            double nota;

            //Aqui de donde se obtienen sus valores
            nota = double.Parse(txtNota.Text);

                //En este caso creamos un bloque donde usaremos los siguientes recursos.
                //Este bloque de if nos permite introducir el límite de valores que activan la secuencia.
                if (nota >= 0 && nota <= 10)
                {
                    //Con este if creamos un estado en el cual si la nota es menor que 3, nos da un muy insuficiente.
                    if (nota < 3.0)
                    {
                        //Mostramos un texto en la consola que nos dice que la nota si es menor a 3, nos da un muy insuficiente.
                        MessageBox.Show("Muy Insuficiente");
                    }
                    //Con este else if creamos un estado en el cual si la nota es menor que 5, nos da un insuficiente.
                    else if (nota < 5.0)
                    {
                        //Mostramos un texto en la consola que nos dice que la nota si es menor a 5, nos da un insuficiente.
                        MessageBox.Show("Insuficiente");
                    }
                    //Con este else if creamos un estado en el cual si la nota es menor que 6, nos da un bien.
                    else if (nota < 6.0)
                    {
                        //Mostramos un texto en la consola que nos dice que la nota si es menor a 6, pero mayor o igual a 5, nos da un suficiente.
                        MessageBox.Show("Suficiente");
                    }
                    //Con este else if creamos un estado en el cual si la nota es menor que 7, nos da un notable.
                    else if (nota < 7.0)
                    {
                        //Mostramos un texto en la consola que nos dice que la nota si es menor a 7, pero mayor o igual a 6, nos da un bien.
                        MessageBox.Show("Bien");
                    }
                    //Con este else if creamos un estado en el cual si la nota es menor que 9, nos da un notable.
                    else if (nota < 9.0)
                    {
                        //Mostramos un texto en la consola que nos dice que la nota si es menor a 9, pero mayor o igual a 7, nos da un notable.
                        MessageBox.Show("Notable");
                    }
                    //Con este if creamos un estado en el cual si la nota es menor que 10, nos da un sobresaliente.
                    else if (nota <= 10.0)
                    {
                        //Mostramos un texto en la consola que nos dice que la nota si es  mayor o igual a 9, nos da un sobresaliente.
                        MessageBox.Show("Sobresaliente");
                    }
                }
                //Con este else nos permite indicar el error ya que las notas deben estar comprendidas entre 0 y 10.
                else
                {
                    //Mostramos un texto que nos indique el error de introducción.
                    MessageBox.Show("Error, las notas solo pueden estar entre el 0 y el 10");
                }

        }
    }
}
