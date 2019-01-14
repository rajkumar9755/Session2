using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee
{
    class Employee
    {
        public String name { get; set; } = String.Empty;
        public DateTime dob { get; set; }
        public String country { get; set; } = String.Empty;
        public Char gender { get; set; }
    }
    class Class1
    {
        delegate void Print(Employee e);
        static void PrintEmp(Employee e)
        {
            Console.WriteLine("Name : {0}\tCountry : {1}\tDob : {2}\tGender : {3}\n", e.name, e.country, e.dob.ToString("dd-MM-yyyy"), e.gender);
        }
        static void PrintEmpName(Employee e)
        {
            Console.WriteLine(e.name);
        }
        static List<Employee> FilterByCountry(List<Employee> emps ,String country)
        {
            return emps.Where(x => x.country.Equals(country)).ToList();
        }
        static List<Employee> FilterByAge(List<Employee> emps,int days)
        {
            return emps.Where(x => ((DateTime.Now-x.dob).TotalDays<days)).ToList();
        }
        static int EmpCountBasedOnGender(List<Employee> emps, Char gender)
        {
            return emps.Where(x => x.gender == gender).ToArray().Length;
        }
        static List<Employee> OrderByAgeDesc(List<Employee> emps)
        {
            return emps.OrderByDescending(x => ((DateTime.Now - x.dob).TotalDays / 12)).ToList();
        }
        public static void Main(String[] args)
        {
            var emps = new List<Employee>()
            {
                new Employee(){name="Raj",country="India",dob=new DateTime(1997,05,05),gender='M'},
                new Employee(){name="Sriram pandey",country="India",dob=new DateTime(1994,02,28),gender='M'},
                new Employee(){name="Ananya",country="India",dob=new DateTime(1995,05,26),gender='F'},
                new Employee(){name="Venkat",country="US",dob=new DateTime(1990,03,20),gender='M'}
            };
            Print print1= new Print(PrintEmp);
            Print print2 = new Print(PrintEmpName);
            var US_emps = FilterByCountry(emps, "US");
            Console.WriteLine("US Employees Details");
            foreach (Employee emp in US_emps)
            {
                print2(emp);
            }
            Console.WriteLine("\nMale Employees Count : {0}", EmpCountBasedOnGender(emps, 'M'));
            var young_emps = FilterByAge(emps,34500);
            Console.WriteLine("\nYoung Employees Details");
            foreach (Employee emp in young_emps)
            {
                print2(emp);
            }
            Console.WriteLine("\nDetails of Employees based on Descending order of ages");
            foreach (Employee emp in OrderByAgeDesc(emps))
            {
                print2(emp);
            }
            Console.ReadLine();
        }
    }
}
