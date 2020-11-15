using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=University;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlExpression = "";
                sqlExpression += "DROP TABLE  Student ;DROP TABLE Courses ;DROP TABLE StudentsCourses ;DROP TABLE Teacher;";

                sqlExpression += @"CREATE TABLE Student 
                    ( StudentID int NOT NULL PRIMARY KEY IDENTITY, Name varchar(55) NOT NULL, Surname varchar(55),Email varchar(55));";

                sqlExpression += @"CREATE TABLE Courses 
                    ( CoursesID int NOT NULL PRIMARY KEY IDENTITY, Name varchar(55) NOT NULL, Description varchar(255),TeatherID int);"; 

                sqlExpression += @"CREATE TABLE StudentsCourses 
                    ( StudentID int NOT NULL,CoursesID int NOT NULL);"; 

                sqlExpression += @"CREATE TABLE Teacher
                    ( TeacherID int NOT NULL PRIMARY KEY IDENTITY, Name varchar(55) NOT NULL, Surname varchar(55));";

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {               
                connection.Close();                
            }
           
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                InsertStudent(connection, new Student { Name = "Petro", Surname = "Petrov", Email = "perggro@gmail.ua" });
                InsertStudent(connection, new Student { Name = "Nazv", Surname = "Faerth", Email = "Fearth209@gmail.com" });
                InsertStudent(connection, new Student { Name = "Mas", Surname = "Piokl", Email = "dvdo@gmail.ua" });

                InsertTeacher(connection, new Teacher { Name = "Georg", Surname = "Hobbitt" });
                InsertTeacher(connection, new Teacher { Name = "Kolig", Surname = "Makil" });

                InsertCourses(connection, new Courses { Name = "math", Description = "not description", TeatherID = 1 });
                InsertCourses(connection, new Courses { Name = "English", Description = "not description", TeatherID = 2 });

                AddCoursesForStudent(connection, 1, 1);
                AddCoursesForStudent(connection, 1, 2);
                AddCoursesForStudent(connection, 2, 1);
                AddCoursesForStudent(connection, 2, 3);

                List<Student> students = SelectStudet(connection);
                foreach (var item in students)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");

                List<Courses> courses = AllCoursesOfStudent(connection, students[0].StudentID);
                foreach (var item in courses)
                {
                    Console.WriteLine(item);
                }                
            }            
            Console.Read();
        }

        #region StudetMethod
        static void InsertStudent(SqlConnection connection , Student student)
        {
            string insert = "INSERT INTO Student (Name, Surname, Email )" +
                    $"VALUES ('{student.Name}', '{student.Surname}', '{student.Email}');";
            SqlCommand command = new SqlCommand(insert, connection);
            command.ExecuteNonQuery();
        }
        static List<Student> SelectStudet(SqlConnection connection)
        {
            List<Student> students = new List<Student>();
            string select = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(select, connection);
            using(var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3)
                    });
                }
            }
            return students;
        }
        static Student SelectStudet(SqlConnection connection ,int StudentID)
        {
            Student students= new Student();
            string select = $"SELECT * FROM Student WHERE StudentID={StudentID}";
            SqlCommand command = new SqlCommand(select, connection);
            using(var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    students = new Student
                    {
                        StudentID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3)
                    };
                }
            }
            return students;
        }
        static void DeleteStudet(SqlConnection connection, int StudentID)
        {
            Student students = new Student();
            string delete = $"DELETE FROM Student WHERE StudentID={StudentID}";
            SqlCommand command = new SqlCommand(delete, connection);
            command.ExecuteNonQuery();
        }
        static void AddCoursesForStudent(SqlConnection connection, int CoursesID, int StudentID)
        {
            string insert = "INSERT INTO StudentsCourses (StudentID,CoursesID )" +
                   $"VALUES ({StudentID},{CoursesID});";
            SqlCommand command = new SqlCommand(insert, connection);
            command.ExecuteNonQuery();
        }
        static List<Courses> AllCoursesOfStudent(SqlConnection connection ,int StudentID)
        {
            List<Courses> courses = new List<Courses>();
            string select = $@"SELECT [CoursesID],[Name],[Description] ,[TeatherID]
                 FROM Courses WHERE [CoursesID]  
                 IN(SELECT CoursesID FROM StudentsCourses WHERE StudentID={StudentID});";
            SqlCommand command = new SqlCommand(select, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    courses.Add(new Courses
                    {
                        CoursesID=reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description=reader.GetString(2),
                        TeatherID=reader.GetInt32(3)
                    }) ;
                }
            }
            return courses;
        }
        

        #endregion

        #region TeacherMethod
        static void InsertTeacher(SqlConnection connection, Teacher teacher)
        {
            string insert = "INSERT INTO Teacher (Name, Surname)" +
                    $"VALUES ('{teacher.Name}', '{teacher.Surname}');";
            SqlCommand command = new SqlCommand(insert, connection);
            command.ExecuteNonQuery();
        }
        static List<Teacher> SelectTeacher(SqlConnection connection)
        {
            List<Teacher> teachers = new List<Teacher>();
            string select = "SELECT * FROM Teacher";
            SqlCommand command = new SqlCommand(select, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    teachers.Add(new Teacher
                    {
                        TeacherID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2)                        
                    });
                }
            }
            return teachers;
        }
        static Teacher SelectTeacher(SqlConnection connection, int TeacherID)
        {
            Teacher teachers = new Teacher();
            string select = $"SELECT * FROM Teacher WHERE TeacherID={TeacherID}";
            SqlCommand command = new SqlCommand(select, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    teachers = new Teacher
                    {
                        TeacherID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2)                        
                    };
                }
            }
            return teachers;
        }
        static void DeleteTeacher(SqlConnection connection, int TeacherID)
        {
            Student students = new Student();
            string delete = $"DELETE FROM Teacher WHERE TeacherID={TeacherID}";
            SqlCommand command = new SqlCommand(delete, connection);
            command.ExecuteNonQuery();
        }

        #endregion

        #region CoursestMethod
        static void InsertCourses(SqlConnection connection, Courses courses)
        {
            string insert = "INSERT INTO Courses ( Name, Description ,TeatherID )" +  
                    $"VALUES ('{courses.Name}', '{courses.Description}', {courses.TeatherID});";
            SqlCommand command = new SqlCommand(insert, connection);
            command.ExecuteNonQuery();
        }
        static List<Courses> SelectCourses(SqlConnection connection)
        {
            List<Courses> courses = new List<Courses>();
            string select = "SELECT * FROM Courses";
            SqlCommand command = new SqlCommand(select, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    courses.Add(new Courses
                    {
                        CoursesID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        TeatherID = reader.GetInt32(3)
                    });
                }
            }
            return courses;
        }
        static Courses SelectCourses(SqlConnection connection, int CoursesID)
        {
            Courses courses = new Courses();
            string select = $"SELECT * FROM Courses WHERE CoursesID={CoursesID}";
            SqlCommand command = new SqlCommand(select, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    courses = new Courses
                    {
                        CoursesID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        TeatherID = reader.GetInt32(3)
                    };
                }
            }
            return courses;
        }
        static void DeleteCourses(SqlConnection connection, int CoursesID)
        {
            Student students = new Student();
            string delete = $"DELETE  FROM Courses WHERE CoursesID={CoursesID}";
            SqlCommand command = new SqlCommand(delete, connection);
            command.ExecuteNonQuery();
        }

        #endregion

       
    }
}
