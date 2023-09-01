using System;
namespace ProductConsole
{
	public class NetworkLog
	{
		public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public string Network { get; set; }

        public void DisplayReport()
        {
            //Console.WriteLine("1");

            List<NetworkLog> networkLogs = new List<NetworkLog>();

            FileStream fs = new FileStream("networkLog.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string line = reader.ReadLine();


            NetworkLog log = new NetworkLog();

            while (reader.Peek() > 0)
            {
                //Console.WriteLine("1");
                if (line.StartsWith("Id"))
                {
                    log.Id = Convert.ToInt32( line.Split(':')[1]);
                }
                else if (line.StartsWith("Source"))
                {
                    log.Source = line.Split(':')[1];
                }
                else if (line.StartsWith("Destination"))
                {
                    log.Destination = line.Split(':')[1];
                }
                else if (line.StartsWith("Date"))
                {
                    log.Date = Convert.ToDateTime(line.Split(' ')[0].Split(':')[1]);
                    log.Time = Convert.ToDateTime(line.Split(' ')[1]);
                }
                else if (line.StartsWith("Status"))
                {
                    log.Status = line.Split(':')[1];
                }
                else if (line.StartsWith("Network"))
                {
                    log.Network = line.Split(':')[1];
                    networkLogs.Add(log);
                    log = new NetworkLog();
                }
                line = reader.ReadLine();
            }

            //Console.WriteLine("1");
            foreach (var item in networkLogs)
            {
                //Console.WriteLine("2");
                //Console.WriteLine(item);
                Console.Write(item.Id + "\t");
                Console.Write(item.Source + "\t");
                Console.Write(item.Destination + "\t");
                Console.Write(item.Date + "\t");
                Console.Write(item.Time + "\t");
                Console.Write(item.Status + "\t");
                Console.WriteLine(item.Network + "\t");

            }
        }

        public void DisplaySuccessReport()
        {
            List<NetworkLog> networkLogs = new List<NetworkLog>();

            FileStream fs = new FileStream("networkLog.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string line = reader.ReadLine();

            NetworkLog log = new NetworkLog();

            bool flag = false;

            while (reader.Peek() > 0)
            {
                //Console.WriteLine("1");
                if (line.StartsWith("Id"))
                {
                    log.Id = Convert.ToInt32(line.Split(':')[1]);
                }
                else if (line.StartsWith("Source"))
                {
                    log.Source = line.Split(':')[1];
                }
                else if (line.StartsWith("Destination"))
                {
                    log.Destination = line.Split(':')[1];
                }
                else if (line.StartsWith("Date"))
                {
                    log.Date = Convert.ToDateTime(line.Split(' ')[0].Split(':')[1]);
                    log.Time = Convert.ToDateTime(line.Split(' ')[1]);
                }
                else if (line.StartsWith("Status"))
                {
                    log.Status = line.Split(':')[1];
                    if(log.Status == "Success")
                    {
                        flag = true;
                    }

                }
                else if (line.StartsWith("Network"))
                {
                    log.Network = line.Split(':')[1];
                    if (flag)
                    {
                        networkLogs.Add(log);
                        log = new NetworkLog();
                        flag = false;
                    }

                }
                line = reader.ReadLine();
            }


            //File generation
            FileStream fs2 = new FileStream("successReport.txt", FileMode.Create, FileAccess.Write);

            //how to write data into file
            StreamWriter writer = new StreamWriter(fs2);
            writer.WriteLine("Id\t\tSource\t\tDestination\t\tDate\t\tTime\t\tStatus\t\tNetwork");


            foreach (var item in networkLogs)
            {
                writer.WriteLine(item.Id+"\t"+ item.Source + "\t"
                                + item.Destination + "\t" + item.Date +
                                "\t" + item.Time + "\t" + item.Status + "\t" + item.Network);
            }

            writer.Close();//close write operation
            fs.Close();//close file operation
        }

        public void DisplayFailedReport()
        {
            List<NetworkLog> networkLogs = new List<NetworkLog>();

            FileStream fs = new FileStream("networkLog.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string line = reader.ReadLine();

            NetworkLog log = new NetworkLog();

            bool flag = false;

            while (reader.Peek() > 0)
            {
                //Console.WriteLine("1");
                if (line.StartsWith("Id"))
                {
                    log.Id = Convert.ToInt32(line.Split(':')[1]);
                }
                else if (line.StartsWith("Source"))
                {
                    log.Source = line.Split(':')[1];
                }
                else if (line.StartsWith("Destination"))
                {
                    log.Destination = line.Split(':')[1];
                }
                else if (line.StartsWith("Date"))
                {
                    log.Date = Convert.ToDateTime(line.Split(' ')[0].Split(':')[1]);
                    log.Time = Convert.ToDateTime(line.Split(' ')[1]);
                }
                else if (line.StartsWith("Status"))
                {
                    log.Status = line.Split(':')[1];
                    if (log.Status == "Failed")
                    {
                        flag = true;
                    }

                }
                else if (line.StartsWith("Network"))
                {
                    log.Network = line.Split(':')[1];
                    if (flag)
                    {
                        networkLogs.Add(log);
                        log = new NetworkLog();
                        flag = false;
                    }

                }
                line = reader.ReadLine();
            }


            //File generation
            FileStream fs2 = new FileStream("failedReport.txt", FileMode.Create, FileAccess.Write);

            //how to write data into file
            StreamWriter writer = new StreamWriter(fs2);
            writer.WriteLine("Id\t\tSource\t\tDestination\t\tDate\t\tTime\t\tStatus\t\tNetwork");


            foreach (var item in networkLogs)
            {
                writer.WriteLine(item.Id + "\t" + item.Source + "\t"
                                + item.Destination + "\t" + item.Date +
                                "\t" + item.Time + "\t" + item.Status + "\t" + item.Network);
            }

            writer.Close();//close write operation
            fs.Close();//close file operation

        }

        public void DisplayDialedReport()
        {
            List<NetworkLog> networkLogs = new List<NetworkLog>();

            FileStream fs = new FileStream("networkLog.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string line = reader.ReadLine();

            NetworkLog log = new NetworkLog();

            bool flag = false;

            while (reader.Peek() > 0)
            {
                //Console.WriteLine("1");
                if (line.StartsWith("Id"))
                {
                    log.Id = Convert.ToInt32(line.Split(':')[1]);
                }
                else if (line.StartsWith("Source"))
                {
                    log.Source = line.Split(':')[1];
                }
                else if (line.StartsWith("Destination"))
                {
                    log.Destination = line.Split(':')[1];
                }
                else if (line.StartsWith("Date"))
                {
                    log.Date = Convert.ToDateTime(line.Split(' ')[0].Split(':')[1]);
                    log.Time = Convert.ToDateTime(line.Split(' ')[1]);
                }
                else if (line.StartsWith("Status"))
                {
                    log.Status = line.Split(':')[1];
                    if (log.Status == "Dialled")
                    {
                        flag = true;
                    }

                }
                else if (line.StartsWith("Network"))
                {
                    log.Network = line.Split(':')[1];
                    if (flag)
                    {
                        networkLogs.Add(log);
                        log = new NetworkLog();
                        flag = false;
                    }

                }
                line = reader.ReadLine();
            }


            //File generation
            FileStream fs2 = new FileStream("dialedReport.txt", FileMode.Create, FileAccess.Write);

            //how to write data into file
            StreamWriter writer = new StreamWriter(fs2);
            writer.WriteLine("Id\t\tSource\t\tDestination\t\tDate\t\tTime\t\tStatus\t\tNetwork");


            foreach (var item in networkLogs)
            {
                writer.WriteLine(item.Id + "\t" + item.Source + "\t"
                                + item.Destination + "\t" + item.Date +
                                "\t" + item.Time + "\t" + item.Status + "\t" + item.Network);
            }

            writer.Close();//close write operation
            fs.Close();//close file operation

        }
    }
}

