using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_StoredProcedures
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    // 1. Створюємо команду, вказуємо назву процедури та з'єдання, в якому будемо її виконувати
                    SqlCommand command = new SqlCommand("sp_AvarageMark", connection);
                    // 2. вказуэмо, що наша команда - це збережена процедура
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // 3. Створюэмо параметри
                    // вхідний параметр - назва групи
                    command.Parameters.Add("@subject", System.Data.SqlDbType.NVarChar, 30).Value = "C++";
                    // створюємо вихідний параметр
                    #region outputParameter = new SqlParameter().... 
                    //SqlParameter outputParameter = new SqlParameter
                    //{
                    //    ParameterName = "@countStud",
                    //    SqlDbType = System.Data.SqlDbType.Int,
                    //    // змінюємо напрям параметра - вказуємо, що це ВИХІДНИЙ параметр
                    //    Direction = System.Data.ParameterDirection.Output
                    //    // Value для вихідних параметрів НЕ ЗАДАЄТЬСЯ
                    //}; 
                    // Додаємо параметр в колекцію параметрів команди
                    // command.Parameters.Add(outputParameter);
                    #endregion
                    // Скорочений варіант створення вихідного параметра (анонімно) - без виділення пам'яті раніше
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@avarageMark",
                        SqlDbType = System.Data.SqlDbType.Int,
                        // змінюємо напрям параметра - вказуємо, що це ВИХІДНИЙ параметр
                        Direction = System.Data.ParameterDirection.Output
                    });

                    command.ExecuteNonQuery();
                    // Console.WriteLine($"Result: {outputParameter.Value}");
                    Console.WriteLine($"Avarage Mark on {command.Parameters["@subject"].Value.ToString()}: {command.Parameters["@avarageMark"].Value.ToString()}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}

