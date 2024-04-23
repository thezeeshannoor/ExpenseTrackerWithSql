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
       
           
        
     
        
       public static void ConnectionHelper()
        {
            DataManupulationn data = new DataManupulationn();

            string cs = "Data Source=ZEESHANN-LAP\\SQLEXPRESS;Initial Catalog=tracker;Integrated Security=true;";


            try
            {
                data.mycon = new SqlConnection(cs);
                
                  
                    
                    
                        bool con = true;
                        Console.WriteLine("Connection has been created successfully");
                        Console.WriteLine("1: Press 1 To Add Expense\n2: Press 2 to Show All Expense\n3: Press 3 to show Total Expense\n4: Press 4 to exit");
                        while (con)
                        {
                            Console.WriteLine("Enter your Choice");
                            int choice=int.Parse(Console.ReadLine());
                            switch(choice)
                            {
                                case 1:
                                    data.mycon.Open();
                                    data.AddData();
                                    data.mycon.Close();
                                    break;

                                case 2:
                                    data.mycon.Open();
                                    data.ReadData();
                                    data.mycon.Close();
                                    break;

                                case 3:
                                    data.mycon.Open();
                                    data.TotalExpense();
                                    data.mycon.Close();
                                    break;

                                 case 4:
                                    con = false;
                                    break;

                                default:
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
