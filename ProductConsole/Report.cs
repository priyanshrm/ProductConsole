using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //to implement file handling.

namespace ProductConsole
{
    public abstract class Report
    {
        public abstract void GenerateReport();
    }
    public class PDFReport : Report
    {
        public override void GenerateReport()
        {
            Console.WriteLine("Pdf report generation");
        }
    }
    public class TextFileReport : Report
    {
        public override void GenerateReport()
        {
            Console.WriteLine("TextFile report generation");
            //File generation
            FileStream fs = new FileStream("salesreport.txt", FileMode.Create, FileAccess.Write);

            //how to write data into file
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("Welcome to e-mobile Shop");
            writer.WriteLine("Sales Report");
            writer.WriteLine("************");

            writer.Close();//close write operation
            fs.Close();//close file operation
        }

        public void ReadReport()
        {
            FileStream fs = new FileStream("salesreport.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);//read data
            Console.WriteLine(reader.ReadToEnd());
        }

        public void ReadReportNameAndId()
        {
            FileStream fs = new FileStream("salesreport.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string line = reader.ReadLine();
            Console.WriteLine("ReportName\t\tReportId");
            while(reader.Peek() > 0)
            {
                if (line.StartsWith("Report Name"))
                {
                    string[] values = line.Split(':');
                    Console.Write(values[1] + "\t\t");
                }
                else if (line.StartsWith("Report Id"))
                {
                    string[] values = line.Split(':');
                    Console.WriteLine(values[1]);
                }
                line = reader.ReadLine();
            }
        }

        public void ReadNetworkLog(string status)
        {
            FileStream fs = new FileStream("networkLog.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string line = reader.ReadLine();
            Console.WriteLine("Id\t\tSource\t\tDestination\t\tDate\t\tTime\t\tStatus\t\tNetwork");
            string k = "";
            bool flag = false;
            while (reader.Peek() > 0)
            {
                if (line.StartsWith("Id"))
                {
                    string[] values = line.Split(':');
                    k += values[1] + "\t";
                }
                else if (line.StartsWith("Source"))
                {
                    string[] values = line.Split(':');
                    k += values[1] + "\t";
                }
                else if (line.StartsWith("Destination"))
                {
                    string[] values = line.Split(':');
                    k += values[1] + "\t";
                }
                else if (line.StartsWith("Date"))
                {
                    string[] values = line.Split(' ');
                    string[] values2 = values[0].Split(':');
                    k += values2[1] + "\t";
                    k += values[1] + "\t";
                }
                
                else if (line.StartsWith("Status"))
                {
                    string[] values = line.Split(':');
                    k += values[1] + "\t";
                    if (values[1] == status)
                    {
                        flag = true;
                    } 
                }
                else if (line.StartsWith("Network"))
                {
                    string[] values = line.Split(':');
                    k += values[1] + "\t";
                    if (flag)
                    {
                        Console.WriteLine(k);
                        flag = false;
                    }
                    k = "";
                }
                
                line = reader.ReadLine();
            }
        }
    }
}