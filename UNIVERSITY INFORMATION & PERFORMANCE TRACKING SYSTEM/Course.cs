using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIVERSITY_INFORMATION___PERFORMANCE_TRACKING_SYSTEM
{
    internal class Course
    {
        private string courseCode;
        private string courseName;
        private Teacher courseTeacher;
        private int credit;

        public string CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }
        public string CourseName
        {
            get { return courseName; }
        }
        public Course()
        {
            this.courseCode = "Not Set";
            this.courseName = "Not Set";
            this.courseTeacher = new Teacher();
            this.credit = 0;
        }
        public Course(string courseCode, string courseName, Teacher courseTeacher, int credit)
        {
            this.courseCode = courseCode;
            this.courseName = courseName;
            this.courseTeacher = courseTeacher;
            this.credit = credit;
        }
        public Course(Course copy)
        {
            this.courseCode = copy.courseCode;
            this.courseName = copy.courseName;
            this.courseTeacher = copy.courseTeacher;
            this.credit = copy.credit;
        }
        public void AssignTeacher(Teacher newTeacher)
        {
            this.courseTeacher = newTeacher;
        }
        public void ShowCourseInfo()
        {
            Console.WriteLine("Course Code: " + this.courseCode);
            Console.WriteLine("Course Name: " + this.courseName);
            Console.WriteLine("Course Credit: " + this.credit);
            Console.WriteLine("Course Teacher Info:");
            this.courseTeacher.ShowInfo();
        }
           }
}
