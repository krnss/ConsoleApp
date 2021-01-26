using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using GameShop.Interfase;
using GameShop.Models;

namespace GameShop.ADONET
{
    public class ADONETProvaider
    {
        const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True";
        SqlConnection connection;

        public ADONETProvaider()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }
        //не коректне
        public void CreateTable() {
            
            string sqlExpression = @"CREATE TABLE Student 
                    ( StudentID int NOT NULL PRIMARY KEY IDENTITY, 
                        Name varchar(55) NOT NULL,
                        Surname varchar(55),
                        Email varchar(55));";

            ExecudeComand(sqlExpression);
        }

        public List<IProduct> SelectAllGame()
        {
            List<IProduct> LP = new List<IProduct>();
            string sqlExpression = "SELECT ID,Name,Autor,Prise,UrlFoto FROM [Shop].[dbo].[Product]";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            using (var reader = command.ExecuteReader())
            {               
                while (reader.Read())
                {
                    LP.Add(ExecudeProduct(reader));                
                }
            }
            return LP;
        }
        public IProduct SelectGame(int? id)
        {
            string sqlExpression = $"SELECT ID,Name,Autor,Prise,UrlFoto FROM [Shop].[dbo].[Product] WHERE ID={id}";
            return GetProduct(sqlExpression);
        }

        public IProduct SelectLastGame()
        {
            string sqlExpression = $"SELECT ID,Name,Autor,Prise,UrlFoto FROM [Shop].[dbo].[Product] ORDER BY ID DESC";
            return GetProduct(sqlExpression);
        }
        public void UpdateGame(IProduct product)
        {
            string sqlExpression = $@"UPDATE Product
                                    SET Name = '{product.Name}'
                                    ,Autor ='{product.Autor}'
                                    ,Prise = {product.Prise}
                                    ,UrlFoto = '{product.UrlFoto}'
                                     WHERE ID={ product.ID}";

            ExecudeComand(sqlExpression);
        }
        public void InsertGame(IProduct product)
        {
            string sqlExpression = $@"INSERT INTO Product (Name,Autor,Prise,UrlFoto) VALUES(
                                     '{product.Name}'
                                    ,'{product.Autor}'
                                    , {product.Prise}
                                    ,'{product.UrlFoto}')";
                                     

            ExecudeComand(sqlExpression);
        }
        public void DeleteGame(int? id)        {

            string sqlExpression = $"DELETE FROM [Shop].[dbo].[Product] WHERE ID={id}";

            ExecudeComand(sqlExpression);
        }

        private void ExecudeComand(string sqlExpression)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
        }
        
        private IProduct GetProduct(string sqlExpression)
        {
            IProduct Product = new Game();
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product = ExecudeProduct(reader);
                }
            }
            return Product;
        }
        private IProduct ExecudeProduct(SqlDataReader reader)
        {
            return new Game
            {
                ID = reader.GetInt32(0),
                Name = reader.GetString(1),
                Autor = reader.GetString(2),
                Prise = reader.GetInt32(3),
                UrlFoto = reader.GetString(4)
            };
        }

               
        
    }
}