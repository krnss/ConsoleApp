using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;




namespace ADONETProvaider
{
    public class ADONETProvaider
    {
        const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);

        public ADONETProvaider(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void CreateTable() {
            connection.Open();
            string sqlExpression = @"CREATE TABLE Student 
                    ( StudentID int NOT NULL PRIMARY KEY IDENTITY, Name varchar(55) NOT NULL, Surname varchar(55),Email varchar(55));";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<IProduct> SelectAll()
        {
            List<IProduct> LP = new List<IProduct>();

            return LP;
        }

                

               
        
    }
}