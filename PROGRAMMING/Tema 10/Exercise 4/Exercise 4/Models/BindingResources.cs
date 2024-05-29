using Exercise_4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_4
{
    public static class BindingResources
    {
        // CHECK DUPLICATED ID
        public static bool DuplicatedID(string id, BindingSource bindingSource)
        {
            bool duplicated = false;
            foreach (var item in bindingSource)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null && rowView.Row["DNI"].ToString() == id)
                {
                    duplicated = true;
                }
            }
            return duplicated;
        }

        // CHECK DUPLICATED PHONE
        public static bool DuplicatedPhone(string phone, BindingSource bindingSource)
        {
            bool duplicated = false;
            foreach (var item in bindingSource)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null && rowView.Row["Tlf"].ToString() == phone)
                {
                    duplicated = true;
                }
            }
            return duplicated;
        }

        // CHECK DUPLICATED EMAIL
        public static bool DuplicatedEmail(string email, BindingSource bindingSource)
        {
            bool duplicated = false;
            foreach (var item in bindingSource)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null && rowView.Row["Email"].ToString() == email)
                {
                    duplicated = true;
                }
            }
            return duplicated;
        }

        // CHECK DUPLICATED ADRESS
        public static bool DuplicatedAdress(string address, BindingSource bindingSource)
        {
            bool duplicated = false;
            foreach (var item in bindingSource)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null && rowView.Row["Direccion"].ToString() == address)
                {
                    duplicated = true;
                }
            }
            return duplicated;
        }

        public static bool CheckCourseExist(string course, BindingSource bindingSource)
        {
            bool courseExist = false;

            foreach (var item in bindingSource)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null && rowView.Row["Codigo"].ToString() == course)
                {
                    courseExist = true;
                }
            }
            return courseExist;
        }

        public static void ShowIdentityData(BindingSource bindingSource)
        {
            DataRowView currentBinding = bindingSource.Current as DataRowView;
            if (currentBinding != null)
            {
                if (currentBinding.Row.Table.TableName == "Alumnos")
                {
                    string alumnInfo = "ID: " + currentBinding["DNI"] + "\n" +
                                       "Name: " + currentBinding["Nombre"] + "\n" +
                                       "Surnames: " + currentBinding["Apellido"] + "\n" +
                                       "Phone: " + currentBinding["Tlf"] + "\n" +
                                       "Adress: " + currentBinding["Direccion"] + "\n" +
                                       "Course: " + currentBinding["Codigo"] + "\n";

                    MessageBox.Show(alumnInfo, "Alumn Information");
                }
                else if (currentBinding.Row.Table.TableName == "Profesores")
                {
                    string teacherInfo = "ID: " + currentBinding["DNI"] + "\n" +
                                         "Name: " + currentBinding["Nombre"] + "\n" +
                                         "Surnames: " + currentBinding["Apellido"] + "\n" +
                                         "Phone: " + currentBinding["Tlf"] + "\n" +
                                         "Adress: " + currentBinding["Email"] + "\n" +
                                         "Course: " + currentBinding["Codigo"] + "\n";

                    MessageBox.Show(teacherInfo, "Teacher Information");
                }
                else if (currentBinding.Row.Table.TableName == "Cursos")
                {
                    string courseInfo = "Course: " + currentBinding["Codigo"] + "\n" +
                                        "Name: " + currentBinding["Nombre"] + "\n";

                    MessageBox.Show(courseInfo, "Course Information");
                }
            }
        }


        /* CHECK ALL DUPLICATED DATA
        public static bool CheckAllDuplicatedData(string id, string phone, string emailOrString, string selectedTable)
        {
            bool duplicatedData = false;

            if (selectedTable == "Profesores")
            {
                duplicatedData = DuplicatedID(id, profesoresBindingSource) ||
                                 DuplicatedID(id, alumnosBindingSource) ||
                                 DuplicatedPhone(phone, profesoresBindingSource) ||
                                 DuplicatedPhone(phone, alumnosBindingSource) ||
                                 DuplicatedEmail(emailOrString, profesoresBindingSource);
            }
            else if (selectedTable == "Alumnos")
            {
                duplicatedData = DuplicatedID(id, alumnosBindingSource) ||
                                 DuplicatedID(id, profesoresBindingSource) ||
                                 DuplicatedPhone(phone, alumnosBindingSource) ||
                                 DuplicatedPhone(phone, profesoresBindingSource) ||
                                 DuplicatedAddress(emailOrString, alumnosBindingSource);
            }
            else if (selectedTable == "Cursos")
            {
                duplicatedData = DuplicatedID(id, cursosBindingSource);
            }

            return duplicatedData;
        } */
    }
}
