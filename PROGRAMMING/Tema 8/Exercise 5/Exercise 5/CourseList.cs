using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    public class CourseList
    {
        private List<Course> courseList;

        public CourseList()
        {
            courseList = new List<Course>();
        }

        public void AddsCourse(int courseCod, string courseName)
        {
            Course newCourse = new Course();

            newCourse.Name = courseName;
            newCourse.Cod = courseCod;

            courseList.Add(newCourse);
        }

        public void RemovesCourse(int courseCod)
        {
            if (courseList.Count != 0)
            {
                courseList.RemoveAt(ReturnsCoursePosition(courseCod));
            }
        }

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
        public bool AlreadyUsedCourseCod(int courseCod)
        {
            bool used = false;
            for (int i = 0; i < courseList.Count && !used; i++)
            {
                if (courseCod == courseList[i].Cod)
                {
                    used = true;
                }
            }
            return used;
        }

        public int CountsTotalCourses()
        {
            return courseList.Count;
        }

    }
}
