using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_6
{
    public class AlumnList
    {
        private List<Alumn> alumnList;

        public AlumnList()
        {
            alumnList = new List<Alumn>();
        }

        //FUNCTION WHICH ADDS AN ALUMN TO THE ALUMN LIST
        public void AddsAlumn(string alumnName, int alumnID, int alumnPhone, int courseCod)
        {
            Alumn newAlumn = new Alumn();

            newAlumn.Name = alumnName;
            newAlumn.ID = alumnID;
            newAlumn.Phone = alumnPhone;
            newAlumn.CourseCod = courseCod;

            alumnList.Add(newAlumn);
        }

        // FUNCTION WHICH REMOVES AN ALUMN FROM THIS LIST
        public void RemovesAlumn(int alumnID)
        {
            alumnList.RemoveAt(ReturnsAlumnPosition(alumnID));
        }


        // FUNCTION WHICH CALCULATES THE AVERAGE GRADES FROM A SELECTED ALUMN
        public double SelectAlumnGradesAverage(string alumnName)
        {
            double alumnGradesAvg = 0;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    alumnGradesAvg = alumnList[i].AlumnGradesAverage(); 
                }
            }  
            return alumnGradesAvg;

        }

        // FUNCTION WHICH RETURNS THE POSITION OF THE ALUMN IN THE LIST, IF IT'S NEGATIVE THE ALUMN IS NOT IN THE LIST
        public int ReturnsAlumnPosition(int alumnID)
        {
            int index = -1;
            for (int i = 0; i < alumnList.Count; i++)
            {
                if (alumnID == alumnList[i].ID)
                {
                    index = i;
                }
            }
            return index;
        }

        // FUNCTION WHICH RETURNS THE COUNT OF THE NUMBER OF ALUMNS IN THE LIST
        public int CountsTotalAlumns()
        {
            int count = 0;
            for (int i = 0; i < alumnList.Count; i++)
            {
                count++;
            }
            return count;
        }




        //^[a-zA-Z]{1}+[0-9]{7}+[a-zA-Z]{1}+$|^[0-9]{8}+[a-zA-Z]{1}+$ DNI
        //^[6|7]{1}+[0-9]{8}+$ TLFN

    }
}
