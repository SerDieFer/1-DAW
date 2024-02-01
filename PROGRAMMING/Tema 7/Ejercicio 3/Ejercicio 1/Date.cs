
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_3
{
    class Date
    {
        private int dDay;
        private int dMonth;
        private int dYear;

        // CONSTRUCTOR 
        public Date()
        {
            dDay = 01;
            dMonth = 01;
            dYear = 0;
        }

        public string ShowData()
        {
            string txt;
            txt = "Data of this date:\n";
            DateTime date = new DateTime(dYear, dMonth, dDay);
            txt += "Day: " + date.ToString("d, dddd", CultureInfo.CreateSpecificCulture("en-US")) + "\n";
            txt += "Month: " + date.ToString("M, MMMM", CultureInfo.CreateSpecificCulture("en-US")) + "\n";
            txt += "Year: " + date.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")) + "\n";

            return txt;
        }

        public int Day
        {
            get { return dDay; }
            set
            {
                if (value > 0 && value < 32)
                {
                    dDay = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("This value is not possible, insert a day number between 1 and 31");
                }
            }
        }

        public int Month
        {
            get { return dMonth; }
            set
            {
                if (value > 0 && value < 13)
                {
                    dMonth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("This value is not possible, insert a month number between 1 and 12");
                }
            }
        }

        public int Year
        {
            get { return dYear; }
            set { dYear = value; }
        }
    }
}

