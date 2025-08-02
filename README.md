# C# ASP.NET Core MVC + Web API Cumulative Project

## Project Overview

This is a school management MVP project built using **ASP.NET Core MVC and Web API**. It implements CRUD functionality (READ only for now) on the `Teachers`, `Courses`, and `Students` tables using a MySQL database (XAMPP).

The application supports:
- Viewing all teachers and search functionality by HireDate
- Viewing a single teacher's details by ID
- Displaying all courses taught by a teacher (using ViewModel)
- Viewing all students
- Viewing all Courses
- Web API for getting all teacher data
- Web API for getting teacher detail by ID
- Web API for getting all Students data
- Web API for getting all Courses data
- An API which adds a Teacher
- An API which deletes a Teacher
- An API which adds a Student
- An API which deletes a Student
- An API which adds a Course
- An API which deletes a Course
- Web API for adding teacher data
- Web API for deleting particular teacher
- Web API for confirmation of delteion of teacher data
- Web API for adding student data
- Web API for deleting particular student
- Web API for confirmation of delteion of student data
- Web API for adding course data
- Web API for deleting particular course
- Web API for confirmation of delteion of course data
---

##  How to Test

### API Endpoints

| Endpoint                         | Test Method     | Example URL                                 |
|----------------------------------|-----------------|---------------------------------------------|
| Get all teachers                 | `GET`           | `/api/TeacherAPI/teachers`                  |
| Get teacher by ID                | `GET`           | `/api/TeacherAPI/Teacher/1`                 |
| Get all students                 | `GET`           | `/api/TeacherAPI/students`                  |
| Get all Courses                  | `GET`           | `/api/TeacherAPI/courses`                   |
| Add new teacher                  | `POST`          | `/api/TeacherAPI/addteacher`                |
| delete teacher                   | `GET`           | `/api/TeacherAPI/deleteteacher/12`          |
| Add new student                  | `POST`          | `/api/TeacherAPI/AddStudent`                |
| delete teacher                   | `GET`           | `/api/TeacherAPI/deletestudent/33`          |
| Add new course                   | `POST`          | `/api/TeacherAPI/addcourse`                 |
| delete course                    | `GET`           | `/api/TeacherAPI/deletecourse/2`            |



Use `curl` or browser:

-curl https://localhost:{port}/api/TeacherAPI/teachers \
-curl https://localhost:{port}/api/TeacherAPI/Teacher/1 \
-curl https://localhost:{port}/api/TeacherAPI/students \
-curl https://localhost:{port}/api/TeacherAPI/courses
-curl https://localhost:{port}/api/TeacherAPI/addteacher
-curl https://localhost:{port}/api/TeacherAPI/deleteteacher/11
-curl https://localhost:{port}/api/TeacherAPI/addstudent
-curl https://localhost:{port}/api/TeacherAPI/deletestudent/20
-curl https://localhost:{port}/api/TeacherAPI/addcourse
-curl https://localhost:{port}/api/TeacherAPI/deletecourse/4


## Web Page Testing (Views)

The following Razor views were tested in the browser:

### All Teachers Page
- URL: `/TeacherPage/List`
- Function: Displays a list of all teachers
- Extra Feature: Date range filter for HireDate

### Single Teacher Page
- URL: `/TeacherPage/Show/{id}`
- Function: Displays full details of a single teacher
- Extra Feature: Also shows all courses taught by the teacher using a ViewModel

### All Students Page
- URL: `/StudentPage/StudentList`
- Function: Displays all students with all info

### All Courses Page
- URL: `/CoursePage/CourseList`
- Function: Displays all courses with all teacherId

### Add Teacher Detail Page
- URL: `/TeacherPage/new`
- Function: Shows a web page where we can add teacher detail

### Add Course Detail Page
- URL: `/CoursePage/new`
- Function: Shows a web page where we can add course detail

### Add Student Detail Page
- URL: `/StudentPage/new`
- Function: Shows a web page where we can add student detail
