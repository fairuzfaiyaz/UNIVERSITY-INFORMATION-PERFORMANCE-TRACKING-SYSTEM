using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIVERSITY_INFORMATION___PERFORMANCE_TRACKING_SYSTEM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------
            // 1. CREATE UNIVERSITY OBJECT
            // ---------------------------------------------
            University uni = new University();

            // ---------------------------------------------
            // 2. CREATE TEACHERS
            // Note: adjusted constructor argument order and added empty Course[] and course count (0)
            // ---------------------------------------------
            Teacher t1 = new Teacher("T101", 45, "Dr. Rahman", "Mirpur", "rahman@uni.edu", "Professor", 90000, new Course[10], 0);
            Teacher t2 = new Teacher("T102", 37, "Ms. Fatema", "Banani", "fatema@uni.edu", "Lecturer", 60000, new Course[10], 0);
            Teacher t3 = new Teacher("T103", 40, "Mr. Kamal", "Uttara", "kamal@uni.edu", "Senior Lecturer", 70000, new Course[10], 0);

            // Copy constructor example
            Teacher t4 = new Teacher(t1); // Copy of t1

            // Add teachers to university
            uni.AddTeacher(t1);
            uni.AddTeacher(t2);
            uni.AddTeacher(t3);
            uni.AddTeacher(t4);

            // ---------------------------------------------
            // 3. CREATE COURSES
            // Note: Course signature expects a Teacher parameter; pass null and assign later.
            // ---------------------------------------------
            Course c1 = new Course("CSE101", "Introduction to Programming", null, 3);
            Course c2 = new Course("CSE202", "Data Structures", null, 3);
            Course c3 = new Course("MAT201", "Calculus II", null, 3);
            Course c4 = new Course("PHY102", "Physics", null, 3);

            // Assign teachers to courses
            c1.AssignTeacher(t1);
            c2.AssignTeacher(t2);
            c3.AssignTeacher(t3);
            c4.AssignTeacher(t1);

            // Teacher adds courses they teach
            t1.AddCourse(c1);
            t1.AddCourse(c4);
            t2.AddCourse(c2);
            t3.AddCourse(c3);

            // Add courses to university
            uni.AddCourse(c1);
            uni.AddCourse(c2);
            uni.AddCourse(c3);
            uni.AddCourse(c4);

            // ---------------------------------------------
            // 4. CREATE STUDENTS
            // Note: adjusted constructor argument order and provided empty marks and courses arrays.
            // ---------------------------------------------
            Student s1 = new Student("S001", 21, "Faiyaz", "Mirpur", "faiyaz@mail.com", 3.75, new int[0][], new Course[10], 0);
            Student s2 = new Student("S002", 20, "Zerin", "Dhanmondi", "zerin@mail.com", 3.50, new int[0][], new Course[10], 0);
            Student s3 = new Student("S003", 22, "Hasan", "Uttara", "hasan@mail.com", 3.42, new int[0][], new Course[10], 0);
            Student s4 = new Student("S004", 19, "Nusrat", "Banani", "nusrat@mail.com", 3.60, new int[0][], new Course[10], 0);
            Student s5 = new Student(s2); // Copy constructor

            // Add students to university
            uni.AddStudent(s1);
            uni.AddStudent(s2);
            uni.AddStudent(s3);
            uni.AddStudent(s4);
            uni.AddStudent(s5);

            // ---------------------------------------------
            // 5. SET JAGGED MARKS FOR STUDENTS
            // ---------------------------------------------
            int[][] marks1 = new int[3][];
            marks1[0] = new int[] { 90, 87 };
            marks1[1] = new int[] { 78, 85, 92 };
            marks1[2] = new int[] { 88, 91 };
            s1.SetMarks(marks1);

            int[][] marks2 = new int[2][];
            marks2[0] = new int[] { 80, 75 };
            marks2[1] = new int[] { 70, 85, 96 };
            s2.SetMarks(marks2);

            // ---------------------------------------------
            // 6. ENROLL STUDENTS INTO COURSES
            // ---------------------------------------------
            s1.AddCourse(c1);
            s1.AddCourse(c2);

            s2.AddCourse(c1);
            s2.AddCourse(c3);

            s3.AddCourse(c4);

            // ---------------------------------------------
            // 7. CREATE ENROLLMENTS
            // ---------------------------------------------
            Enrollment e1 = new Enrollment(s1, c1, new int[] { 88, 90 });
            Enrollment e2 = new Enrollment(s1, c2, new int[] { 75, 82 });
            Enrollment e3 = new Enrollment(s2, c1, new int[] { 91, 89 });
            Enrollment e4 = new Enrollment(s2, c3, new int[] { 72, 80 });
            Enrollment e5 = new Enrollment(s3, c4, new int[] { 69, 78 });

            uni.AddEnrollment(e1);
            uni.AddEnrollment(e2);
            uni.AddEnrollment(e3);
            uni.AddEnrollment(e4);
            uni.AddEnrollment(e5);

            // ---------------------------------------------
            // 8. SHOW POLYMORPHISM
            // ---------------------------------------------
            Person p1 = s1;
            Person p2 = t1;

            Console.WriteLine("\n--- POLYMORPHISM DEMO ---");
            p1.ShowInfo();
            p2.ShowInfo();

            // ---------------------------------------------
            // 9. SHOW CGPA UPDATE OVERLOADING
            // ---------------------------------------------
            Console.WriteLine("\n--- OVERLOADING DEMO ---");
            s1.UpdateCgpa(3.90);
            s1.UpdateCgpa(3.95, 90);

            // ---------------------------------------------
            // 10. TEACHER SALARY INCREMENT
            // ---------------------------------------------
            Console.WriteLine("\n--- SALARY UPDATE ---");
            t1.ApplyIncrement(10000);

            // ---------------------------------------------
            // 11. UNIVERSITY REPORTS
            // ---------------------------------------------
            Console.WriteLine("\n\n===== UNIVERSITY STUDENTS =====");
            uni.ShowAllStudents();

            Console.WriteLine("\n===== UNIVERSITY TEACHERS =====");
            uni.ShowAllTeachers();

            Console.WriteLine("\n===== UNIVERSITY COURSES =====");
            uni.ShowAllCourses();

            Console.WriteLine("\n===== UNIVERSITY ENROLLMENTS =====");
            uni.ShowAllEnrollments();

            // ---------------------------------------------
            // 12. STATIC PERSON COUNTER
            // ---------------------------------------------
            Console.WriteLine("\n===== TOTAL PERSONS CREATED =====");
            Console.WriteLine(Person.personCount);

            Console.WriteLine("\nPROGRAM FINISHED.");
        }
    }
}