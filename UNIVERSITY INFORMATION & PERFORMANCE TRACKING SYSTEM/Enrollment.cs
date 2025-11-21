using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIVERSITY_INFORMATION___PERFORMANCE_TRACKING_SYSTEM
{
    internal class Enrollment
    {
        private Student student;
        private Course course;
        private int[] examMarks;
        public Enrollment()
        {
            this.student = new Student();
            this.course = new Course();
            this.examMarks = new int[0];
        }
        public Enrollment(Student student, Course course, int[] examMarks)
        {
            this.student = student;
            this.course = course;
            this.examMarks = examMarks;
        }
        public Enrollment(Enrollment copy)
        {
            this.student = copy.student;
            this.course = copy.course;
            this.examMarks = copy.examMarks;
        }
        public void ShowEnrollmentInfo()
        {
            Console.WriteLine("Enrollment Information:");
            student.ShowInfo();
            course.ShowCourseInfo();
            Console.WriteLine("Exam Marks: " + string.Join(", ", examMarks));
        }
    }
}
