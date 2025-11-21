using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UNIVERSITY_INFORMATION___PERFORMANCE_TRACKING_SYSTEM
{
    internal class Student : Person
    {
        private string studentId;
        private double cgpa;
        private int[][] marks;
        private Course[] enrolledCourses;
        private int courseCount;

        public string StudentID
        {
            get
            {
                return studentId;
            }
        }

        public Student() : base()
        {
            this.studentId = "Not Set";
            this.cgpa = 0.00d;
            this.marks = new int[0][];
            this.enrolledCourses = new Course[10];
            this.courseCount = 0;
        }
        public Student(string name, int age, string address, string email, string studentId, double cgpa, int[][] marks, Course[] enrolledCourses, int courseCount) : base(name, age, address, email)
        {
            this.studentId = studentId;
            this.cgpa = cgpa;
            this.marks = marks;
            this.enrolledCourses = enrolledCourses;
            this.courseCount = courseCount;
        }
        public Student(Student copy) : base(copy)
        {
            this.studentId = copy.studentId;
            this.cgpa = copy.cgpa;
            this.marks = copy.marks;
            this.enrolledCourses = copy.enrolledCourses;
            this.courseCount = copy.courseCount;

        }
        public void UpdateCgpa(double newCgpa)
        {
            this.cgpa = newCgpa;
        }
        public void UpdateCgpa(double semesterCgpa, int completedCredits)
        {
            semesterCgpa = semesterCgpa * completedCredits;
            this.cgpa = (this.cgpa + semesterCgpa) / (completedCredits + 1);

        }
        public override void ShowInfo() {
            base.ShowInfo();
            Console.WriteLine($"Student ID: {studentId}");
            Console.WriteLine($"CGPA: {cgpa}");
            Console.WriteLine("Marks:");
            foreach (var subjectMarks in marks)
            {
                foreach (var mark in subjectMarks)
                {
                    Console.WriteLine($" - {mark}");
                }
            }
            //Console.WriteLine();
            ShowEnrolledCourses();


        }
        public void SetMarks(int[][] m)
        {
            this.marks = m;
        }

        public void AddCourse(Course c) { 
            if (courseCount < enrolledCourses.Length)
            {
                enrolledCourses[courseCount] = c;
                courseCount++;
            }
            else
            {
                Console.WriteLine("Cannot add more courses, maximum limit reached.");
            }
        }
        // Plan (pseudocode):
        // 1. Print header "Enrolled Courses:"
        // 2. If courseCount == 0 -> print " - None" and return.
        // 3. Iterate from 0 to courseCount-1:
        //    a. If enrolledCourses[i] is null -> print slot empty.
        //    b. Otherwise try to print useful fields in a friendly format:
        //       - Try to get common property names: CourseCode/Code, CourseName/Name/Title, Credits/CreditHours.
        //       - If found, print an indexed line like "1. CODE - Name (X credits)".
        //       - If none found, fall back to calling ToString() on the Course object.
        // 4. Provide a small private helper method that uses reflection to read the first matching property name.
        //
        // This keeps the method robust if Course class has different naming conventions.

        public void ShowEnrolledCourses()
        {
            Console.WriteLine("Enrolled Courses:");
            if (courseCount == 0)
            {
                Console.WriteLine(" - None");
                return;
            }

            for (int i = 0; i < courseCount; i++)
            {
                var c = enrolledCourses[i];
                if (c == null)
                {
                    Console.WriteLine($" {i + 1}. <empty slot>");
                    continue;
                }

                // Try common property names
                string code = TryGetFirstPropertyValueAsString(c, "CourseCode", "Code");
                string name = TryGetFirstPropertyValueAsString(c, "CourseName", "Name", "Title");
                string credits = TryGetFirstPropertyValueAsString(c, "Credits", "CreditHours", "Credit");

                if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(credits))
                {
                    var parts = new List<string>();
                    if (!string.IsNullOrEmpty(code)) parts.Add(code);
                    if (!string.IsNullOrEmpty(name)) parts.Add(name);
                    string main = parts.Count > 0 ? string.Join(" - ", parts) : c.ToString();
                    if (!string.IsNullOrEmpty(credits))
                        Console.WriteLine($" {i + 1}. {main} ({credits} credits)");
                    else
                        Console.WriteLine($" {i + 1}. {main}");
                }
                else
                {
                    // Fallback
                    Console.WriteLine($" {i + 1}. {c}");
                }
            }
        }

        private string TryGetFirstPropertyValueAsString(object obj, params string[] candidateNames)
        {
            if (obj == null) return null;
            var type = obj.GetType();
            foreach (var name in candidateNames)
            {
                var prop = type.GetProperty(name);
                if (prop != null)
                {
                    try
                    {
                        var val = prop.GetValue(obj);
                        if (val != null)
                            return val.ToString();
                    }
                    catch
                    {
                        // ignore and continue
                    }
                }

                // also try fields (in case Course uses public fields)
                var field = type.GetField(name);
                if (field != null)
                {
                    try
                    {
                        var val = field.GetValue(obj);
                        if (val != null)
                            return val.ToString();
                    }
                    catch
                    {
                        // ignore and continue
                    }
                }
            }
            return null;
        }

    }
}
