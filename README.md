# C# ASP.NET Core MVC + Web API Cumulative Project

## 📘 Project Overview

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

---

##  How to Test

### API Endpoints

| Endpoint                         | Test Method     | Example URL                                 |
|----------------------------------|-----------------|---------------------------------------------|
| Get all teachers                 | `GET`           | `/api/TeacherAPI/teachers`                  |
| Get teacher by ID                | `GET`           | `/api/TeacherAPI/Teacher/1`                 |
| Get all students                 | `GET`           | `/api/TeacherAPI/students`                  |
| Get all Courses                  | `GET`           | `/api/TeacherAPI/courses`                   |

Use `curl` or browser:

-curl https://localhost:{port}/api/TeacherAPI/teachers \
-curl https://localhost:{port}/api/TeacherAPI/Teacher/1 \
-curl https://localhost:{port}/api/TeacherAPI/students\
-curl https://localhost:{port}/api/TeacherAPI/courses\

