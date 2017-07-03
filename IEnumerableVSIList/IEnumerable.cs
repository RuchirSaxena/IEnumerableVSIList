using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableVSIList
{
    //Basic Implementation of Ienumerable InterFace
   
    class Employee: IEnumerable,IComparable
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public Employee[] EmpData = new Employee[3];
        
        

        public void setEmployeeData()
        {
            EmpData[0] = new Employee() { EmployeeId=101,EmployeeName="Ruchir" };
            EmpData[1] = new Employee() { EmployeeId = 102, EmployeeName = "Ajay" };
            EmpData[2] = new Employee() { EmployeeId = 103, EmployeeName = "Summit" };
        }

        //Implementing GetEnumerator() method inside IEnumerable
        public IEnumerator GetEnumerator()
        {
            return EmpData.GetEnumerator();
        }

        //Implementing method CompareTo  of IComparable
        int IComparable.CompareTo(object obj)
        {
            Employee other = (Employee)obj;
            if (this.EmployeeId < other.EmployeeId)
            {
                return 1;
            }else if (this.EmployeeId > other.EmployeeId)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        
    }

  
   
    class Program
    {
        static void Main(string[] args)
        {
           
            Employee objEmployee = new Employee();
            objEmployee.setEmployeeData();

            //We cannot Iterate over Employee collection if Ienumerable 
            //interface is not implemented
            Console.WriteLine("=======Array=========");
            foreach (Employee emp in objEmployee)
            {
                
                Console.WriteLine("Employee Id:");
                Console.WriteLine(emp.EmployeeId);
                Console.WriteLine("Emplyee Name:");
                Console.WriteLine(emp.EmployeeName);
            }

            setArrylistItems();
            Console.Read();
           
        }
        //ArrayList
        static void setArrylistItems()
        {
            ArrayList alEmp = new ArrayList();
            alEmp.Add(new Employee() { EmployeeId = 109, EmployeeName = "Raj" });
            alEmp.Add(new Employee() { EmployeeId = 102, EmployeeName = "Kundan" });
            alEmp.Add(new Employee() { EmployeeId = 105, EmployeeName = "Harish" });

            //Sorting in Arraylist
            alEmp.Sort();

            //foreach can be used only those collection objects
            //which implements interface IEnumerable
            Console.WriteLine("=======ArrayList=========");
            foreach (Employee emp in alEmp)
            {
                Console.WriteLine("Employee Id:");
                Console.WriteLine(emp.EmployeeId);
                Console.WriteLine("Emplyee Name:");
                Console.WriteLine(emp.EmployeeName);
            }

           

            /*the above code can also be written as
            Here GetEnumerator() returns IEnumerator
            Now IEnumerator has following methods
            IEnumerator IEnum = alEmp.GetEnumerator();
              object Current { get; }
	         bool MoveNext();
             void Reset();
             */
            IEnumerator IEnum = alEmp.GetEnumerator();

            Console.WriteLine("=======IEnumerator on ArrayList=========");
            while (IEnum.MoveNext())
            {
                //returns the current object
                Employee emp = (Employee)IEnum.Current;
              

                Console.WriteLine("Employee Id:");
                Console.WriteLine(emp.EmployeeId);
                Console.WriteLine("Emplyee Name:");
                Console.WriteLine(emp.EmployeeName);
            }

        }
    }
}
