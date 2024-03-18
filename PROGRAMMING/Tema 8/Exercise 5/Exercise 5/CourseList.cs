using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    public class CourseList
    {
        private List<Course> coursesList;

        public CourseList()
        {
            coursesList = new List<Course>();
        }

        //FUNCTION WHICH ADDS A COURSE TO THE COURSES LIST
        public void AddsCourse(int courseCod, string courseName)
        {
            Course newCourse = new Course();

            newCourse.Name = courseName;
            newCourse.Cod = courseCod;

            coursesList.Add(newCourse);
        }

        // FUNCTION WHICH REMOVES A COURSE FROM THIS LIST
        public void RemovesCourse(int courseCod)
        {
            if (coursesList.Count != 0)
            {
                coursesList.RemoveAt(ReturnsCoursePosition(courseCod));
            }
        }

        // FUNCTION WHICH COLLECTS ALL COURSES FROM THE LIST
        public string ShowsAllCoursesData()
        {
            string courseListTxt = "List of courses: \n";
            if (coursesList.Count != 0)
            {
                foreach (Course course in coursesList)
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
            if (coursesList.Count != 0)
            {
                courseDataTxt += coursesList[ReturnsCoursePosition(courseCod)].ShowsCourseData();
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
            for (int i = 0; i < coursesList.Count; i++)
            {
                if (courseCod == coursesList[i].Cod)
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
            for (int i = 0; i < coursesList.Count; i++)
            {
                if (courseCod == coursesList[i].Cod)
                {
                    courseName = coursesList[i].Name;
                }
            }
            return courseName;
        }

        // FUNCTION WHICH RETURNS IF THE COURSE ID IS ALREADY USED
        public bool AlreadyUsedCourseCod(int courseCod)
        {
            bool used = false;
            for (int i = 0; i < coursesList.Count && !used; i++)
            {
                if (courseCod == coursesList[i].Cod)
                {
                    used = true;
                }
            }
            return used;
        }

        // FUNCTION WHICH RETURNS THE COUNT OF THE NUMBER OF COURSES IN THE LIST
        public int CountsTotalCourses()
        {
            int count = 0;
            for (int i = 0; i < coursesList.Count; i++)
            {
                count++;
            }
            return count;
        }

    }
}
