using System;
using System.IO;
using System.Linq;

    class Program
    {
      // declarations
        public static int ID;
       // public static int linecount;
        public static string Name;
        public static string Class;
        public static string Section;
       

        static void Main(string[] args)
        {
            // Main Page Design
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-                  Good Day                           -");
            Console.WriteLine("-                  welcome                            -");
            Console.WriteLine("-             to the rainbow school!                  -");
            Console.WriteLine("-                                                     -");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("You can Update or add data by inserting your ID:");
            // Getting the user id 
            Console.WriteLine("ID:");
            ID = Convert.ToInt32(Console.ReadLine());
            // Getting the user name
            Console.WriteLine("Name:");
            Name = Console.ReadLine();
            // Getting the user Class
            Console.WriteLine("Class:");
            Class = Console.ReadLine();
            // Getting the user Section
            Console.WriteLine("Section:");
            Section = Console.ReadLine();
        // testing outputs
        // Console.WriteLine(ID);
        // Console.WriteLine(Name);
            RunFile();
        }
        // Running the File
        public static void RunFile()
        {
            // directory
         string directory = Directory.GetCurrentDirectory();
         string FileName = "Teachers.txt";
        // checks if the file name is exisit or not and perform action
         if (File.Exists(FileName))
         {
                // we will open the file and read to check in the lines and close it
            string[] check = File.ReadAllLines(FileName);
                if (check.Contains("ID:" + ID))
                {
                  for (int i = 0; i < check.Length; i++)
                    {
                    if (check[i].Contains("ID:" + ID))
                    {
                        check[i + 1] = "Name:" + Name;
                        check[i + 2] = "Class:" + Class;
                        check[i + 3] = "Section:" + Section;
                        using (StreamWriter Writer = File.CreateText(FileName))
                        {
                            // Display all the updated data 
                            foreach (string line in check)
                            {
                                Writer.WriteLine(line);
                            }
                        }
                        Console.WriteLine("Data has been updated sussufully!");
                    }
                    }
                }
                else // In case we didn't find the user id in the text file
                {
                    using (StreamWriter Writer = File.AppendText(FileName))
                    {
                        Writer.WriteLine("ID:" + ID);
                        Writer.WriteLine("Name:" + Name);
                        Writer.WriteLine("Class:" + Class);
                        Writer.WriteLine("Section:" + Section);
                    }
                    Console.WriteLine("New Data has been added sussufully!");
                }
         }
            else
                File.CreateText(FileName);
        }
    }
    

