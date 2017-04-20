using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace workWithXmlFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Users\Manpreet Singh\Documents\Visual Studio 2015\Projects\CSharpPrograms\workWithXmlFiles\studentList.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "name":
                                if (reader.Read())
                                {
                                    Console.WriteLine("Student name: {0}", reader.Value);
                                }
                                break;
                            case "phone":
                                if (reader.Read())
                                {
                                    Console.WriteLine("Phone number is: {0}", reader.Value);
                                    Console.WriteLine("-----------------------------------");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
