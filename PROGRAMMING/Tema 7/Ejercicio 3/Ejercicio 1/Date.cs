﻿
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
    // DATE CLASS
    class Date
    {
        private int dDay;
        private int dMonth;
        private int dYear;

        // DATE CONSTRUCTOR -- PREMADE VALUES TO CHECK ANY ERROR --
        public Date()
        {
            this.dDay = -1;
            this.dMonth = -1;
            this.dYear = -1;
        }

        // RETURNS A TRUE OR FALSE IF THE SELECTED YEAR IS A LEAP YEAR
        public bool IsLeapYear(int dYear)
        {
            bool isLeap = false;

            if (dYear % 4 == 0)
            {
                isLeap = true;

                if (dYear % 100 == 0 && dYear % 400 != 0)
                {
                    isLeap = false;
                }
            }
            return isLeap;
        }

        // RETURN A TRUE OR FALSE IF THE INTRODUCED DATA IS VALID FOR THE DATA IMPUT RULES
        public bool ValidateData()
        {
            bool isValid = false;

            if (dMonth == 2)
            {
                if (IsLeapYear(dYear))
                {
                    if (dDay <= 29 && dDay >= 1)
                    {
                        isValid = true;
                    }
                }
                else
                {
                    if (dDay <= 28 && dDay >= 1)
                    {
                        isValid = true;
                    }
                }
            }

            else if ((dMonth == 4 || dMonth == 6 || dMonth == 9 || dMonth == 11))
            {
                if (dDay <= 30 && dDay >= 1)
                {
                    isValid = true;
                }
            }
            else
            {
                if (dDay <= 31 && dDay >= 1)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        // SHOWS ALL THE SELECTED DATA WITH MORE INFO
        public string ShowData()
        {
            string txt = "";
            bool beforeC = false;
            int yearAux = dYear;

            if (yearAux < 0)
            {
                yearAux *= -1;
                DateTime date = new DateTime(yearAux, dMonth, dDay);
                txt += "Year: " + date.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")) + " BC\n";
                txt += "Month: " + date.ToString("M, MMMM", CultureInfo.CreateSpecificCulture("en-US")) + "\n";
                txt += "Day: " + date.ToString("d, dddd", CultureInfo.CreateSpecificCulture("en-US")) + "\n";
                beforeC = true;
            }
            else if (!beforeC)
            {
                DateTime date = new DateTime(yearAux, dMonth, dDay);
                txt += "Year: " + date.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")) + " AC\n";
                txt += "Month: " + date.ToString("M, MMMM", CultureInfo.CreateSpecificCulture("en-US")) + "\n";
                txt += "Day: " + date.ToString("d, dddd", CultureInfo.CreateSpecificCulture("en-US")) + "\n";
            }

            return txt;
        }

        // SETTER & GETTER FOR DAY
        public int Day
        {
            get { return dDay; }
            set { dDay = value; }
        }

        // SETTER & GETTER FOR MONTH
        public int Month
        {
            get { return dMonth; }
            set { dMonth = value; }
        }

        // SETTER & GETTER FOR YEAR 
        public int Year
        {
            get { return dYear; }
            set { dYear = value; }
        }
    }
}


