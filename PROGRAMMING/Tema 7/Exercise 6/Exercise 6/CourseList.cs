using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Exercise_6
{
    public class CourseList
    {
        private List<Course> courseList;

        public CourseList()
        {
            courseList = new List<Course>();
        }

        //FUNCTION WHICH ADDS A COURSE TO THE COURSES LIST
        public void AddsCourse(int courseCod, string courseName)
        {
            Course newCourse = new Course();

            newCourse.Name = courseName;
            newCourse.Cod = courseCod;

            courseList.Add(newCourse);
        }

        // FUNCTION WHICH REMOVES A COURSE FROM THIS LIST
        public void RemovesCourse(int courseCod)
        {
            if (courseList.Count != 0)
            {
                courseList.RemoveAt(ReturnsCoursePosition(courseCod));
            }
        }

        // FUNCTION WHICH COLLECTS ALL COURSES FROM THE LIST
        public string ShowsAllCoursesData()
        {
            string courseListTxt = "List of courses: \n";
            if (courseList.Count != 0)
            {
                foreach (Course course in courseList)
                {
                    courseListTxt += course.ShowsCourseData();
                }
            }
            return courseListTxt;
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM THE SELECTED COURSE
        public string ShowsSelectedCourseData(int courseCod)
        {
            string courseDataTxt = "";
            if (courseList.Count != 0)
            {
                courseDataTxt += courseList[ReturnsCoursePosition(courseCod)].ShowsCourseData();
            }
            else
            {
                courseDataTxt = "There isn't any added course to the course list";
            }
            return courseDataTxt;
        }

        // FUNCTION WHICH RETURNS THE POSITION OF THE COURSE IN THE LIST, IF IT'S NEGATIVE THE COURSE IS NOT IN THE LIST
        public int ReturnsCoursePosition(int courseCod)
        {
            int index = -1;
            for (int i = 0; i < courseList.Count; i++)
            {
                if (courseCod == courseList[i].Cod)
                {
                    index = i;
                }
            }
            return index;
        }

        // FUNCTION WHICH RETURNS THE NAME OF THE COURSE IN THE LIST
        public string ReturnsCourseName(int courseCod)
        {
            string courseName = "";
            for (int i = 0; i < courseList.Count; i++)
            {
                if (courseCod == courseList[i].Cod)
                {
                    courseName = courseList[i].Name;
                }
            }
            return courseName;
        }


        // FUNCTION WHICH RETURNS THE COUNT OF THE NUMBER OF COURSES IN THE LIST
        public int CountsTotalCourses()
        {
            int count = 0;
            for (int i = 0; i < courseList.Count; i++)
            {
                count++;
            }
            return count;
        }

    }
}
