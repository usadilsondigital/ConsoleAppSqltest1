using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleAppSqltest1
{
    internal class Program
    {
        static class SqlHelper
        {

            // Set the connection, command, and then execute the command with non query.  
            public static Int32 ExecuteNonQuery(String connectionString, String commandText,
                CommandType commandType, params SqlParameter[] parameters)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect   
                        // type is only for OLE DB.    
                        cmd.CommandType = commandType;
                        cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }

            }

            // Set the connection, command, and then execute the command and only return one value.  
            public static Object ExecuteScalar(String connectionString, String commandText,
                CommandType commandType, params SqlParameter[] parameters)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect   
                        // type is only for OLE DB.    
                        cmd.CommandType = commandType;
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }

            // Set the connection, command, and then execute the command with query and return the reader.  
            public static SqlDataReader ExecuteReader(String connectionString, String commandText,
                CommandType commandType, params SqlParameter[] parameters)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();

                    // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                    // IDataReader is closed.  
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return reader;
                }




        }


        static void Main(string[] args)
        {
            String connectionString = "Data Source=DESKTOP-3H9KDN6\\SQLEXPRESS;Initial Catalog=janizeck;User ID=sa;Password=sa;Integrated Security=True;Asynchronous Processing=true;";

            CountPlansbyYear(connectionString, 2012);


            Console.WriteLine("Please press any key to exit...");
            Console.ReadKey();
        }


        static void CountPlansbyYear(String connectionString, Int32 year)
        {
            String commandText = "Select Count([PlanID]) FROM [janizeck].[dbo].[tblPlan] Where PlanYear=@Year";
            SqlParameter parameterYear = new SqlParameter("@Year", SqlDbType.Int);
            parameterYear.Value = year;
            Object oValue = SqlHelper.ExecuteScalar(connectionString, commandText, CommandType.Text, parameterYear);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
                Console.WriteLine("There {0} {1} plans{2} in {3}.", count > 1 ? "are" : "is", count, count > 1 ? "s" : null, year);
        }
        //




    }
}

