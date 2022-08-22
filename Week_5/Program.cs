namespace Week_5
{
    class Program
    {
        // I added a new line.
        public static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            string file = GetFileName();
            CheckIfFileExist(file);
            string choice = "";
            while (choice != "3")
            {
                Console.WriteLine(@"Please select and option:
1. Display Summary
2. Add a new line
3. Quit from the program");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    DisplaySummary(file);
                } else if (choice == "2")
                {
                    WriteData(file);
                }
            }
        }

        public static void WriteData(string file)
        {
            using (StreamWriter writer = new StreamWriter(file, append: true))
            {
                Console.WriteLine("What do you want to write, formatted as <id>, <name>, <salary>:");
                string newLine = Console.ReadLine();
                writer.WriteLine(newLine);
            }
        }

        public static void DisplaySummary(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                double totalSalary = 0;
                int employeeCount = 0;
                double maxSalary = 0;
                double minSalary = double.MaxValue;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(',');
                    int id = int.Parse(data[0]);
                    string name = data[1];
                    double salary = double.Parse(data[2]);
                    Console.WriteLine($"Employee {name} with id {id} has salary {salary}.");
                    //salaryList.Add(salary);
                    totalSalary += salary;
                    employeeCount++;
                    if (salary > maxSalary)
                    {
                        maxSalary = salary;
                    }
                    if (salary < minSalary)
                    {
                        minSalary = salary;
                    }
                }
                double averageSalary = totalSalary / employeeCount;
                Console.WriteLine($"The average salary is {averageSalary}");
                Console.WriteLine($"The maximum salary is {maxSalary}");
                Console.WriteLine($"The minimum salary is {minSalary}");
            }
        }

        public static string GetFileName()
        {
            Console.WriteLine("Enter the name of the file");
            string filename = Console.ReadLine();
            return filename;
        }

        public static void CheckIfFileExist(string filename)
        {
            bool fileExists = File.Exists(filename);
            if (!fileExists)
            {
                Console.WriteLine("Error: The file does not exist");
            } else
            {
                Console.WriteLine(File.GetCreationTime(filename));
                Console.WriteLine(File.GetLastWriteTime(filename));
                Console.WriteLine(File.GetLastAccessTime(filename));
            }
        }


    }
}