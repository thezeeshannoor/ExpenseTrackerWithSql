using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
            //SqlCommand cm = new SqlCommand(query, mycon);
            //SqlDataReader dr = cm.ExecuteReader();
            //while (dr.Read())
            //{
            //    Console.WriteLine("ID: " + dr["ID"] + "  " + "Expense Name: " + dr["Expense_Name"] + "  " + "Expense Desc: " + dr["Expense_Desc"] + "  " + "Expense Amount: " + dr["Expense_Amount"] + "  " + "Expense Time: " + dr["Expense_Time"]);

            //}

            // sql Adapeter for conectless connection
            SqlDataAdapter adapter = new SqlDataAdapter(query,mycon);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine($"ID: {row[0]}, Expense Name: {row[1]}, Expense Desc: {row[2]} ,Expense Amount: {row[3]}, Expense Time: {row[4]}\n");
            }

        }
        public void AddData()
        {
            Console.WriteLine("\nEnter Expense name");
            string name= Console.ReadLine();

            Console.WriteLine("\nEnter Expense desc");
            string desc = Console.ReadLine();

            Console.WriteLine("\nEnter Expense Amount");
            int amount = int.Parse(Console.ReadLine());

            DateTime expenseTime = DateTime.Now;

            string query = $"insert into expense VALUES( '{name}', '{desc}', {amount}, '{expenseTime:yyyy-MM-dd HH:mm:ss}')";
            //SqlCommand cm = new SqlCommand(query, mycon);
           // cm.ExecuteNonQuery();

            //sql adapter
            SqlDataAdapter adapter=new SqlDataAdapter(query,mycon);
            DataSet ds=new DataSet();
            adapter.Fill(ds);

        }

        //total expense
        public void TotalExpense()
        {

            string query = "select sum(Expense_Amount) from expense";
            //SqlCommand cm = new SqlCommand(query, mycon);
            //SqlDataReader dr = cm.ExecuteReader();
            //while (dr.Read())
            //{
            //    Console.WriteLine ( "Total Expense Amount "+(dr.GetValue(0)));
            //}

            //Sql data adapter
            SqlDataAdapter adapter = new SqlDataAdapter(query,mycon);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            Console.WriteLine("Total Expense Amount " + (dataSet.Tables[0].Rows[0][0]));

        }
    }
}
