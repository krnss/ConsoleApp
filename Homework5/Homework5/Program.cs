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
                //sqlExpression += "DROP TABLE  Student ;DROP TABLE Courses ;DROP TABLE StudensCourses ;DROP TABLE Teacher;";

                sqlExpression += @"CREATE TABLE Student 
                    ( StudentID int NOT NULL PRIMARY KEY IDENTITY, Name varchar(55) NOT NULL, Surname varchar(55),Email varchar(55));";

                sqlExpression += @"CREATE TABLE Courses 
                    ( CoursesID int NOT NULL PRIMARY KEY IDENTITY, Name varchar(55) NOT NULL, Description varchar(255),TeatherID int);"; 

                sqlExpression += @"CREATE TABLE StudensCourses 
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
            List<Student> students = new List<Student>();
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                InsertStudent(connection, new Student { Name = "Pet", Surname = "Peggrv", Email = "perggro@gmail.ua" });

                students = SelectStudet(connection);
                foreach (var item in students)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n\nstudet whith id 1  "+SelectStudet(connection,1));
            }            
            Console.Read();
        }

        #region StudetMetod
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
            string insert = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(insert, connection);
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
            string insert = $"SELECT * FROM Student WHERE StudentID={StudentID}";
            SqlCommand command = new SqlCommand(insert, connection);
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
        static void DeleteStudet(SqlConnection connection ,int StudentID)
        {
            Student students= new Student();
            string insert = $"SELECT  FROM Student WHERE StudentID={StudentID}";
            SqlCommand command = new SqlCommand(insert, connection);
            command.ExecuteNonQuery();
        }

        #endregion

    }
}
