using System.Collections.Generic;

//Dictionary<int, Employee> EmployeeDeails = new Dictionary<int, Employee>()
//{
//     { 1, new Employee { Name="Sachine",Department="Batsman", Age=17,Salary=1000000,Deleted=0 } },
//            {2, new Employee { Name="Messi",Department="Baller", Age=14,Salary=100000000,Deleted=0 } },
//            { 3, new Employee { Name="Rolando",Department="Striker", Age=20,Salary=100000000 , Deleted = 0} }

 
//};
bool Continue = true;

while (Continue) {

    Employee employee = new Employee();

    employee.Employees.Add(new Employee { ID = 1, Name = "Sachine", Department = "Batsman", Age = 17, Salary = 1000000, Deleted = 0 });
    employee.Employees.Add(new Employee { ID = 2, Name = "Messi", Department = "Baller", Age = 14, Salary = 100000000, Deleted = 0 });
    employee.Employees.Add(new Employee { Name = "Rolando", Department = "Striker", Age = 20, Salary = 100000000, Deleted = 0 });

    Console.WriteLine("Welcome to employee page Select your prefered option");
    Console.WriteLine("press 0 for Displaying Data");
    Console.WriteLine("press 1 for search");
    Console.WriteLine("press 2 for filter based on department");
    Console.WriteLine("press 3 for Sort based on Salary");
    Console.WriteLine("Press 4 for group based on department");
    Console.WriteLine("Press 5 for Top 3 Highest paid Salary");
    Console.WriteLine("Press 6 for Existance Check by Employee Name");
    Console.WriteLine("Press 7 for Department Statictics avg salary for each department");

    Console.WriteLine();
    int value = int.Parse(Console.ReadLine());
    Functionality functions = new Functionality();

    switch (value)
    {
        case 0:
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", "Emp ID", "Name", "Department", "Age", "Salary");
            functions.Display(employee);
            break;
        case 1:
            Console.WriteLine("Enter your Name");
            String Name = Console.ReadLine();
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", "Emp ID", "Name", "Department", "Age", "Salary");
            functions.DisplayName(Name, employee);
            break;
        case 3:
            Console.WriteLine("Sort based on Salary");
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", "Emp ID", "Name", "Department", "Age", "Salary");
            functions.SortSalary(employee);
            break;
        case 4:
            Console.WriteLine(4);
            functions.GroupDepartment(employee);
            break;
        case 5:
            Console.WriteLine(5);
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", "Emp ID", "Name", "Department", "Age", "Salary");
            functions.SortSalary(employee);
            break;
        case 6:
            Console.WriteLine(6);
            Console.WriteLine("Enter the name or Character present in the name");
            string name;
            name = Console.ReadLine();
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", "Emp ID", "Name", "Department", "Age", "Salary");
            functions.EmployeePresent(employee, name);
            break;
        case 7:
            Console.WriteLine(7);
            functions.AvgSalary(employee);
            break;
    }
    Console.WriteLine("Do you want to Continue if yes press Y else N");
    char inputs;
    inputs = Console.ReadKey().KeyChar;
    

    switch (inputs)
    {
        case 'y':
        case 'Y':
            Continue = true;
            break;
        case 'n':
        case 'N':
            Continue= false;
            break;

    }

}

public class Functionality
{
    public void Display(Employee employee1)
    {
        

        foreach(var e in employee1.Employees)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", e.ID, e.Name,e.Department, e.Age,e.Salary);
        }
    }
    public void DisplayName(string Names,Employee employee1)
    {
        //linq queary that I have used 

        var result = from e in employee1.Employees
                     where e.Name.ToLower().Contains(Names.ToLower())
                     select e;

        foreach (var ele in result)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", ele.ID, ele.Name, ele.Department, ele.Age, ele.Salary);
        }


    }
    public void SortSalary(Employee employee1)
    {
        var result = from e in employee1.Employees
                     .OrderByDescending(e => e.Salary)
                     select e;




        foreach (var ele in result)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", ele.ID, ele.Name, ele.Department, ele.Age, ele.Salary);
        }




    }
    public void GroupDepartment(Employee employee)
    {
        var result = from e in employee.Employees
                     group e by e.Department into dept 
                     select dept;
        foreach(var groupa in result)
        {
            Console.WriteLine(groupa.Key);
            foreach(var ele in groupa)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", ele.ID, ele.Name, ele.Department, ele.Age, ele.Salary);

            }
        }

    }
    public void Top3HighestPaidSalary(Employee employee)
    {
        var result = (from e in employee.Employees
                     orderby e.Salary
                     select e).Take(3);
        foreach(var ele in result)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-5} {3,5} {4,10}", ele.ID, ele.Name, ele.Department, ele.Age, ele.Salary);

        }
    }
    public void EmployeePresent(Employee employee,string name)
    {
        var result = from e in employee.Employees
                     where e.Name.ToLower().Contains(name.ToLower())
                     select e;
        foreach(var ele in result)
        {
        }

    }
    public void AvgSalary(Employee employee)
    {
        var result = from e in employee.Employees
                     group e by e.Department into dept
                     select new
                     {
                         deptName = dept.Key,
                         Avg = dept.Average(e => e.Salary)
                     };
        foreach(var ele in result)
        {
            Console.WriteLine("The average for the following dept {0} is {1}",ele.deptName,ele.Avg);
        }

    }

}


public class Employee
{
    public int ID { get; set; }
    public String Name { get; set; }
    public String Department { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }

    public int Deleted { get;set; }

    public List<Employee> Employees { get; set;}

    public Employee()
    {
        Employees = new List<Employee>(); // now it's an empty list
    }
}








