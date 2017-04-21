using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace workWithXmlFiles
{
    class Program
    {
        //method to read data from Xml file.
        static void ReadFromXml(string filename)
        {
            //creating a reader for Xml.
            using (XmlReader reader = XmlReader.Create(filename))
            {
                //while reader has somehting to read.
                while (reader.Read())
                {
                    //check if its a root element.
                    if (reader.IsStartElement())
                    {
                        //swtich to "Name".
                        switch (reader.Name)
                        {
                            //this case run if "Name" is "name"
                            case "name":
                                if (reader.Read())
                                {
                                    Console.WriteLine("Student name: {0}", reader.Value);
                                }
                                break;
                            //this case run if "Name" is "phone"
                            case "phone":
                                if (reader.Read())
                                {
                                    Console.WriteLine("Phone number is: {0}", reader.Value);
                                    Console.WriteLine("-----------------------------------");
                                }
                                break;
                            //default case just break.
                            default:
                                break;
                        }//end of switch.
                    }//end of reader if.
                }//end of while loop.
            }//end of using statement.
        }//end of readFromXml method.

        //method to write data in XML file.
        static void WriteIntoXml()
        {
            //create xdoc obj and add elements to it.
            XDocument doc = new XDocument(new XElement("Stundets",
                                new XElement("Student",
                                    new XElement("name", "abc"),
                                    new XElement("phone","123654789"),
                                    new XElement("name","def"),
                                    new XElement("phone","987456321")
                                )));
            //save file to specified local path.
            doc.Save(@"C:\Users\Manpreet Singh\Documents\Visual Studio 2015\Projects\CSharpPrograms\workWithXmlFiles\studentList.xml");
        }//writeIntoXml method ends.

        static void Main(string[] args)
        {
            //string filename with path.
            string fileName = @"C:\Users\Manpreet Singh\Documents\Visual Studio 2015\Projects\CSharpPrograms\workWithXmlFiles\studentList.xml";
            
            //method call to writeIntoXml.
            WriteIntoXml();

            //method call to readfromxml.
            ReadFromXml(fileName);
            
        }
    }
}
