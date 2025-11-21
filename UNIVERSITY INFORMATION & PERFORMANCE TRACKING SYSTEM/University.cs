using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIVERSITY_INFORMATION___PERFORMANCE_TRACKING_SYSTEM
{
    internal class University
    {
        private Student[] students;
        private Teacher[] teachers;
        private Course[] courses;
        private Enrollment[] enrollments;
        private int studentCount;
        private int teacherCount;
        private int coursesCount;
        private int enrollmentCount;

        public University()
        {
            this.students = new Student[100];
            this.teachers = new Teacher[50];
            this.courses = new Course[50];
            this.enrollments = new Enrollment[200];
            this.studentCount = 0;
            this.teacherCount = 0;
            this.coursesCount = 0;
            this.enrollmentCount = 0;
        }

        public void AddStudent(Student newStudent)
        {
            if (studentCount < students.Length)
            {
                students[studentCount++] = newStudent;
            }
            else
            {
                Console.WriteLine("Cannot add more students, capacity reached.");
            }
        }
        public void AddTeacher(Teacher newTeacher)
        {
            if (teacherCount < teachers.Length)
            {
                teachers[teacherCount++] = newTeacher;
            }
            else
            {
                Console.WriteLine("Cannot add more teachers, capacity reached.");
            }
        }
        public void AddCourse(Course newCourse) {
            if (coursesCount < courses.Length)
            {
                courses[coursesCount++] = newCourse;
            }
            else
            {
                Console.WriteLine("Cannot add more courses, capacity reached.");
            }
        }
        public void AddEnrollment(Enrollment newEnrollment)
        {
            if (enrollmentCount < enrollments.Length)
            {
                enrollments[enrollmentCount++] = newEnrollment;
            }
            else
            {
                Console.WriteLine("Cannot add more enrollments, capacity reached.");
            }
        }

        public void  SearchStudentById(string studentId)
        {
            for (int i = 0; i < studentCount; i++)
            {
                // Use a getter method or property to access studentId
                // Assuming Student has a private field 'studentId', add a public getter in Student class
                if (students[i].StudentID == studentId)
                {
                    students[i].ShowInfo();
                    return;
                }
            }
            Console.WriteLine("Student with ID " + studentId + " not found.");
        }
        public void SearchCourseByCode(string courseCode)
        {
            for (int i = 0; i < coursesCount; i++)
            {
                // Use a getter method or property to access courseCode
                // Assuming Course has a private field 'courseCode', add a public getter in Course class
                if (courses[i].CourseCode == courseCode)
                {
                    courses[i].ShowCourseInfo();
                    return;
                }
            }
            Console.WriteLine("Course with Code " + courseCode + " not found.");
        }
        public void ShowAllStudents()
        {
            for (int i = 0; i < studentCount; i++)
            {
                students[i].ShowInfo();
                Console.WriteLine("-----------------------");
            }
        }

        public void ShowAllTeachers()
        {
            for (int i = 0; i < teacherCount; i++)
            {
                teachers[i].ShowInfo();
                Console.WriteLine("-----------------------");
            }
        }

        public void ShowAllCourses()
        {
            for (int i = 0; i < coursesCount; i++)
            {
                courses[i].ShowCourseInfo();
                Console.WriteLine("-----------------------");
            }
        }

        public void ShowAllEnrollments()
        {
            for (int i = 0; i < enrollmentCount; i++)
            {
                enrollments[i].ShowEnrollmentInfo();
                Console.WriteLine("-----------------------");
            }
        }
    }
}
