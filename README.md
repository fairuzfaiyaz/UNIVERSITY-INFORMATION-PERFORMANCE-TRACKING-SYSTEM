# University Information & Performance Tracking System
### C# Console Application (Encapsulation, Inheritance, Polymorphism)

This project is a complete University Information & Performance Tracking System developed using **C#**.  
It demonstrates strong Object-Oriented Programming principles while avoiding interfaces or abstraction (as per requirement).  
The system handles students, teachers, courses, enrollments, CGPA calculations, salary updates, and performance reports.

---

## Features

### 1. Student Management
- Add and manage students
- Jagged array (`int[][]`) used to store marks for multiple exams
- CGPA update using **method overloading**
- Enroll into multiple courses with limits
- Custom `ShowInfo()` using **polymorphism**
- Copy constructor support

### 2. Teacher Management
- Add teachers with designation and salary
- Assign and track taught courses
- Protected salary increment method
- Overridden `ShowInfo()` for teachers
- Copy constructor support

### 3. Course Management
- Create courses with code, title, and credit
- Assign teachers dynamically
- Track which teacher teaches which course

### 4. Enrollment System
- Connect students with courses
- Store exam marks per enrollment
- Display full performance breakdown per student–course pair

### 5. OOP Concepts Implemented
| Concept | Demonstration |
|--------|---------------|
| Encapsulation | Private fields, properties, setters/getters |
| Inheritance | `Student : Person`, `Teacher : Person` |
| Polymorphism | Overridden `ShowInfo()`; base class references |
| Method Overloading | `UpdateCgpa()` with multiple versions |
| Copy Constructors | Student and Teacher duplication |
| Static Members | `Person.personCount` |
| Jagged Array | Student marks (`int[][]`) |
| Protected Method | Salary increment method inside Teacher |

---


