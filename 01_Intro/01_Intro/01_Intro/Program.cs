using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            #region repeat
            // ТЗ (на СУБД):
            // зберігати дані 
            // формувати звіти 
            // резервне копіювання і відновлення
            // система прав користувачів
            // доступ до даних (по мережі)

            // інтерфейс адміна
            // API (набір функцій)
            // універсальна мова - sql
            // шифрування - захист від несанкціонованого доступу

            // ORM - EntityFramework (EF) 
            #endregion

            //1) connection string
            // Data Source - server name
            //Initial catalog - database
            // IS - режим аутентифікації, якщо true - windows authentification
            //                                 false - server authentification
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial catalog=master;
                                        Integrated Security=true;";
            // 2) створюємо об'єкт з'єднання
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = connectionString;

            IDbConnection connection = new SqlConnection(connectionString);
            // 3) відкрити з'єднання

            ((SqlConnection)connection).StateChange += Program_StateChange;
            #region open and close
            //try
            //{
            //    connection.Open();
            //    Console.WriteLine($"State: {connection.State}");
            //    //
            //    //
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    if (connection != null)
            //        connection.Close();
            //} 
            #endregion
            using (connection)
            {
                try
                {
                    connection.Open();
                    Console.WriteLine($"State: {connection.State}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // code
        }

        private static void Program_StateChange(object sender, StateChangeEventArgs e)
        {
            SqlConnection connection = sender as SqlConnection;
            Console.WriteLine($"Connection:\n\tDatabase: {connection.Database}" +
                $"\n\tServer: {connection.DataSource}" +
                $"\n\tState: {connection.State}");
        }
    }
}
