using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataManupulationNamespace;
using System.ComponentModel;
using System.Xml.Serialization;


namespace ExpenseTracker
{

    internal class Connection
    {
        public static void Note()
        {
            Console.WriteLine("1: Press 1 To Add Expense\n2: Press 2 to Show All Expense\n3: Press 3 to show Total Expense\n4: Press 4 to exit\n");
        }
       public static void ConnectionHelper()
        {
            DataManupulationn data = new DataManupulationn();

            string cs = "Data Source=ZEESHANN-LAP\\SQLEXPRESS;Initial Catalog=tracker;Integrated Security=true;";

            try
            {
                data.mycon = new SqlConnection(cs);

                        bool con = true;
                        Console.WriteLine("Connection has been created successfully");
                        Connection.Note();
                        while (con)
                        {
                            Console.WriteLine("\nEnter your Choice");
                            string choice=Console.ReadLine();
                            switch(choice)
                            {
                                case "1":    
                                  Console.Clear();
                                  Connection.Note();
                                  data.AddData();                              
                                  break;

                                case "2":
                                   Console.Clear();
                                   Connection.Note();
                                   data.ReadData();
                                   data.TotalExpense();
                                   break;

                                case "3":
                                   Console.Clear();
                                   Connection.Note();
                                   data.TotalExpense();
                                   break;

                                 case "4":
                                    Console.Clear();
                                    Connection.Note();
                                    con = false;
                                    break;

                                default:
                                    Console.Clear();
                                    Connection.Note();
                                    Console.WriteLine("Enter Valid Key");
                                    break;

                            }
                        }
                        
                    

                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
