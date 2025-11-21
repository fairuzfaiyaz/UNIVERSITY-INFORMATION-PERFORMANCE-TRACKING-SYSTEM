using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIVERSITY_INFORMATION___PERFORMANCE_TRACKING_SYSTEM
{                                                                                                                       
    /*
    Plan (pseudocode, detailed):
    - Ensure `Teacher` inherits from `Person` (already present) and make constructors call base constructors where appropriate.
    - Keep existing fields: teacherId, designation, salary, taughtCourse[], taughtCourseCount.
    - Provide minimal safe public properties for `TeacherId`, `Designation`, and `Salary` (read-only or read/write as appropriate).
    - Update constructors:
      - Default constructor: call base() then initialize teacher-specific fields.
      - Parameterized constructor: accept teacher-specific values and assign; call base() to preserve base initialization.
      - Copy constructor: copy base-related state if needed (cannot access base private fields) — call base copy if available; otherwise call base().
    - Implement `ShowInfo()` override:
      - Call `base.ShowInfo()` to display person-level information.
      - Print teacher-specific fields (id, designation, salary).
      - Call `ShowTaughtCourses()` to list courses.
    - Keep `IncreaseSalary`, `ApplyIncrement`, `AddCourse`, `ShowTaughtCourses` implementations intact but ensure no access errors.
    - Do not modify other classes or project structure.
    */

    internal class Teacher : Person
    {
        private string teacherId;
        private string designation;
        protected double salary;
        private Course[] taughtCourse;
        private int taughtCourseCount;

        // Optional public properties for external access
        public string TeacherId
        {
            get { return teacherId; }
            set { teacherId = value ?? "Not Set"; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value ?? "Not Set"; }
        }

        public double Salary
        {
            get { return salary; }
            protected set { salary = value; }
        }

        public Teacher()
            : base() // ensure base class initialization
        {
            this.teacherId = "Not Set";
            this.designation = "Not Set";
            this.salary = 0.0d;
            this.taughtCourse = new Course[10];
            this.taughtCourseCount = 0;
        }

        public Teacher(string name, int age, string address, string email, string teacherId, string designation, double salary, Course[] taughtCourse, int taughtCourseCount)
            : base(name, age, address, email) // call base parameterized constructor
        {
            this.teacherId = teacherId ?? "Not Set";
            this.designation = designation ?? "Not Set";
            this.salary = salary;
            this.taughtCourse = taughtCourse ?? new Course[10];
            this.taughtCourseCount = Math.Max(0, Math.Min(taughtCourseCount, this.taughtCourse.Length));
        }

        public Teacher(Teacher copy)
            : base(copy) // copy base state if Person exposes a copy constructor; otherwise default
        {
            if (copy == null) throw new ArgumentNullException(nameof(copy));
            this.teacherId = copy.teacherId;
            this.designation = copy.designation;
            this.salary = copy.salary;
            // shallow copy of array reference to match original behavior
            this.taughtCourse = copy.taughtCourse;
            this.taughtCourseCount = copy.taughtCourseCount;
        }

        protected void IncreaseSalary(double amount)
        {
            this.salary += amount;
        }

        public void ApplyIncrement(double percentage)
        {
            double increment = (this.salary * percentage) / 100.0d;
            IncreaseSalary(increment);
        }

        public void AddCourse(Course course)
        {
            if (taughtCourseCount < taughtCourse.Length)
            {
                taughtCourse[taughtCourseCount] = course;
                taughtCourseCount++;
            }
            else
            {
                Console.WriteLine("Cannot add more courses. Maximum limit reached.");
            }
        }

        public void ShowTaughtCourses()
        {
            Console.WriteLine("Taught Courses:");
            foreach (var course in taughtCourse)
            {
                if (course != null)
                {
                    Console.WriteLine($"Course Code: {course.CourseCode}, Course Name: {course.CourseName}");
                }
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Teacher Information:");
            Console.WriteLine($"Teacher ID: {this.teacherId}");
            Console.WriteLine($"Designation: {this.designation}");
            Console.WriteLine($"Salary: {this.salary}");
            ShowTaughtCourses();
        }
    }
}
