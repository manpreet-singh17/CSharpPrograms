using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workingWithFlatFile
{
    class Program
    {
        static private void CopyDataToTextFile(string fileName)
        {
            try
            {
                //create connection string.
                string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testDb;Integrated Security=True;Pooling=False";

                //adding connection string to sql connection obj.
                SqlConnection conn = new SqlConnection(conStr);

                //create a command obj using createCommand() method of conn obj.
                SqlCommand cmd = conn.CreateCommand();

                //creating actual command.
                cmd.CommandText = "SELECT * FROM CUSTOMERS";

                //add conn obj to using to automaticaly dispose it.
                using (conn)
                {
                    //open connection.
                    conn.Open();

                    //create sql data reader obj and execute cmd.
                    SqlDataReader reader = cmd.ExecuteReader();

                    //create stream writer obj.
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        //while reader has data.
                        while (reader.Read())
                        {
                            //create row for each customer.
                            string customerRow = String.Format("{0}, {1}, {2}, {3}",
                                reader.GetValue(0),
                                reader.GetValue(1),
                                reader.GetValue(2),
                                reader.GetValue(3)
                                );
                            
                            //write each row in stream writer.
                            sw.WriteLine(customerRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //display data in customer list.
        static void DisplayTextFile(string filename)
        {
            try
            {
                //create stream reader object with filename.
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    //read each line while null.
                    while ((line = sr.ReadLine()) != null)
                    {
                        //output each line to console window.
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            //setting path to myDocs using environment class.
            string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //calling CopyDataToTextFile method.
            CopyDataToTextFile(myDocumentPath + @"\customerList.txt");

            ////calling DisplayTextFile method.
            DisplayTextFile(myDocumentPath + @"\customerList.txt");

        }
    }
}
