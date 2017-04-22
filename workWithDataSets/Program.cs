using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workWithDataSets
{
    class Program
    {
        static void WorkWithDataSet()
        {
            //connection string.
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testDb;Integrated Security=True;Pooling=False";

            //make a connection using sqlCOnnectin.
            SqlConnection conn = new SqlConnection(connStr);

            //cmd to select all customers from Customers table.
            string cmd = "SELECT * FROM Customers";

            //create sqladapter to fetch data from data source.
            SqlDataAdapter customerAdptr = new SqlDataAdapter(cmd, conn);

            //create a DataSet. This is in-memory database.
            DataSet customerSet = new DataSet();

            //filling customer in customerSet.
            customerAdptr.Fill(customerSet, "Customer");

            //loop through from all rows of customer table.
            foreach (DataRow item in customerSet.Tables["Customer"].Rows)
            {
                //print all row to console.
                Console.WriteLine("{0}  {1}  {2}", item["name"], item["age"], item["gender"]);
            }   
        }
        static void Main(string[] args)
        {
            //calling workWithDataSet method.
            WorkWithDataSet();
        }
    }
}
