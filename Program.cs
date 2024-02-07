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
        }
            //




        }
}

