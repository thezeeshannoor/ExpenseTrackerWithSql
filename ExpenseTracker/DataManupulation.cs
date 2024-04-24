using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker;

namespace DataManupulationNamespace
{

    public class DataManupulationn
    {
        public SqlConnection mycon=null ;

        public void ReadData()
        {
            try
            {
                string query = "spGetExpense";
                //SqlCommand cm = new SqlCommand(query, mycon);
                //SqlDataReader dr = cm.ExecuteReader();
                //while (dr.Read())
                //{
                //    Console.WriteLine("ID: " + dr["ID"] + "  " + "Expense Name: " + dr["Expense_Name"] + "  " + "Expense Desc: " + dr["Expense_Desc"] + "  " + "Expense Amount: " + dr["Expense_Amount"] + "  " + "Expense Time: " + dr["Expense_Time"]);

                //}

                // sql Adapeter for conectless connection
                SqlDataAdapter adapter = new SqlDataAdapter(query, mycon);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine($"ID: {row[0]}, Expense Name: {row[1]}, Expense Desc: {row[2]} ,Expense Amount: {row[3]}, Expense Time: {row[4]}\n");
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void AddData()
        {
            try
            {
                Console.WriteLine("\nEnter Expense name");
                string name = Console.ReadLine();

                Console.WriteLine("\nEnter Expense desc");
                string desc = Console.ReadLine();

                Console.WriteLine("\nEnter Expense Amount");
                
                string amount ;
               decimal amountRes=0;
                bool amountBool = true;
                while(amountBool)
                {
                    amount = Console.ReadLine();
                 
                    if (decimal.TryParse(amount, out amountRes)) amountBool=false;


                    else Console.WriteLine("PLese enter numbers only");

                }
                

                //DateTime expenseTime = DateTime.Now;

                string query = "spAddExpense";
                //SqlCommand cm = new SqlCommand(query, mycon);
                // cm.ExecuteNonQuery();

                //sql adapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, mycon);
                adapter.SelectCommand.CommandType= CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@name", name);
                adapter.SelectCommand.Parameters.AddWithValue("@desc", desc);
                adapter.SelectCommand.Parameters.AddWithValue("@amount", amountRes);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                Console.Clear();
                Connection.Note();
                Console.WriteLine($"name: {name}, desc: {desc} , amount: {amountRes} ,  successfully added");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //total expense
        public void TotalExpense()
        {

            try
            {
                string query = "spTotalExpense";
                //SqlCommand cm = new SqlCommand(query, mycon);
                //SqlDataReader dr = cm.ExecuteReader();
                //while (dr.Read())
                //{
                //    Console.WriteLine ( "Total Expense Amount "+(dr.GetValue(0)));
                //}

                //Sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, mycon);
                adapter.SelectCommand.CommandType=CommandType.StoredProcedure;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                Console.WriteLine("Total Expense Amount " + (dataSet.Tables[0].Rows[0][0]));
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
