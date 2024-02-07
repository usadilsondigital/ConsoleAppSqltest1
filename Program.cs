﻿using System;
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

            // Set the connection, command, and then execute the command and only return one value.  
            public static Object ExecuteScalar(String connectionString, String commandText,
                CommandType commandType, params SqlParameter[] parameters)
            {
               
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

