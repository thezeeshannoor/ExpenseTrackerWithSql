using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManupulationNamespace
{

    public class DataManupulationn
    {
        public SqlConnection mycon=null ;

        public void ReadData()
        {
            string query = "select * from expense";
            SqlCommand cm = new SqlCommand(query, mycon);
            SqlDataReader dr = cm.ExecuteReader();
          
            while (dr.Read())
            {
                Console.WriteLine("ID: "+dr["ID"] + "  "+"Expense Name: " + dr["Expense_Name"] + "  "+"Expense Desc: " + dr["Expense_Desc"] + "  "+"Expense Amount: " + dr["Expense_Amount"] + "  "+"Expense Time: " + dr["Expense_Time"]);

            }
        }
        public void AddData()
        {
            Console.WriteLine("Enter Expense ID");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Expense name");
            string name= Console.ReadLine();

            Console.WriteLine("\nEnter Expense desc");
            string desc = Console.ReadLine();

            Console.WriteLine("\nEnter Expense Amount");
            int amount = int.Parse(Console.ReadLine());

            DateTime expenseTime = DateTime.Now;

            string query = $"insert into expense VALUES({id}, '{name}', '{desc}', {amount}, '{expenseTime:yyyy-MM-dd HH:mm:ss}')";
            SqlCommand cm = new SqlCommand(query, mycon);
            cm.ExecuteNonQuery();
            

           

        }

        //total expense
        public void TotalExpense()
        {
             
            string query = "select sum(Expense_Amount) from expense";
            SqlCommand cm = new SqlCommand(query, mycon);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine ( "Total Expense Amount "+Convert.ToInt32(dr.GetValue(0)));
            }






        }
    }
}
