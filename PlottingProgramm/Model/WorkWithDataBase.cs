using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlottingProgramm.Model
{
    internal class WorkWithDataBase
    {
        private SqlConnection connection = null;

        public WorkWithDataBase()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionTestDB"].ConnectionString);
        }



        public double[] selectDataFromDB(string columnName, string tableName, int columnSize)
        {
            
            int i = 0;
            double[] numbers = new double[columnSize];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionTestDB"].ConnectionString);
            conn.Open();
            string query = $"SELECT "+ columnName + " FROM " + tableName;
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                numbers[i] = Convert.ToDouble(row.Field<int>(0));
                i++;
            }
            //reader.Close();
            return numbers;
        }

        public string[] selectSTRDataFromDB(string columnName, string tableName, int columnSize)
        {
            
            int i = 0;
            string[] numbers = new string[columnSize];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionTestDB"].ConnectionString);
            conn.Open();
            string query = $"SELECT "+ columnName + " FROM " + tableName;
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                numbers[i] = Convert.ToString(row.Field<string>(0));
                i++;
            }
            //reader.Close();
            return numbers;
        }
    }
}
