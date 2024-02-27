namespace PersonalRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> staffRegister = LoadStaffRegister();

            Console.WriteLine("Enter employee details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            staffRegister.Add(new Employee(name, gender, salary));

            LogStaffDetails(staffRegister);

            SaveStaffRegister(staffRegister);
        }

        static List<Employee> LoadStaffRegister()
        {
            List<Employee> staffRegister = new List<Employee>();
            string filePath = "staff_register.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string gender = parts[1];
                    double salary = double.Parse(parts[2]);
                    staffRegister.Add(new Employee(name, gender, salary));
                }
            }

            return staffRegister;
        }

        static void SaveStaffRegister(List<Employee> staffRegister)
        {
            string filePath = "staff_register.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var employee in staffRegister)
                {
                    writer.WriteLine($"{employee.Name},{employee.Gender},{employee.Salary}");
                }
            }
        }

        static void LogStaffDetails(List<Employee> staffRegister)
        {
            Console.WriteLine("\nStaff Register:");
            foreach (var employee in staffRegister)
            {
                Console.WriteLine($"Name: {employee.Name}, Gender: {employee.Gender}, Salary: {employee.Salary}");
            }
        }
    }

    public class Employee
    {
        public string Name { get; }
        public string Gender { get; }
        public double Salary { get; }

        public Employee(string name, string gender, double salary)
        {
            Name = name;
            Gender = gender;
            Salary = salary;
        }
    }
}
