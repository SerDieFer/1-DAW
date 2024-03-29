﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] vector1 = new int[10];
        void LeerVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));
            }
        }  
   
        void MoveToRight(int[] vector)
        {
          
            int lastP = vector[vector.Length - 1];

            for (int i = vector.Length-1; i>= 1; i--)
            { 
                vector[i] = vector[i-1];  
            }
            vector[0] = lastP;

        }

        string MostrarVector(int[] vector)
        {
            string txt = "Los valores del vector son: ";

            for(int i = 0; i < vector.Length; i++)
            {
            
                if (i == (vector.Length - 1))
                {
                    txt += vector[i] + ".";
                }
                else
                {
                    txt += vector[i] + ", ";
                }
            }

            return txt;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            LeerVector(vector1);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            

            string txtRes;
            MoveToRight(vector1);
            txtRes = MostrarVector(vector1);
            MessageBox.Show(txtRes);
        
        }
    }
}
