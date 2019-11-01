using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employees employee = new Employees("Asta", "Genovaite");
            employee.FirstName = "FFF";
            string fullName = employee.ReturnFullName();
            Console.WriteLine(fullName);

            Console.WriteLine(employee.FirstName);
            Console.WriteLine(employee.ReturnFullName());

        }
    }
}
