using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DataAccessor.Sample
{
    public sealed class OperationManager
    {
        public void AddEmployee()
        {
            Console.Clear();
            IDataAccessorDemoDAL dataAccessorDemoDAL = new DataAccessorDemoDAL();
            DataAccessorEntity dataAccessorEntity = new DataAccessorEntity();
            dataAccessorEntity.EmpID = Guid.NewGuid();

            Console.WriteLine("Enter Name:");
            dataAccessorEntity.Name = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            dataAccessorEntity.Address = Console.ReadLine();

            Console.WriteLine("Enter EMail:");
            dataAccessorEntity.EMail = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            dataAccessorEntity.Phone = Console.ReadLine();

            var result = dataAccessorDemoDAL.AddEmployee(dataAccessorEntity);

            if (result.IsValid)
            {
                Console.WriteLine(result.Message[0]);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void UpdateEmployee()
        {
            Console.Clear();
            IDataAccessorDemoDAL dataAccessorDemoDAL = new DataAccessorDemoDAL();
            DataAccessorEntity dataAccessorEntity = new DataAccessorEntity();

            Console.WriteLine("Enter employee ID:");
            var empID=Console.ReadLine();
            dataAccessorEntity.EmpID = empID == null ? Guid.Empty : Guid.Parse(empID);

            Console.WriteLine("Enter Address:");
            dataAccessorEntity.Address = Console.ReadLine();

            Console.WriteLine("Enter EMail:");
            dataAccessorEntity.EMail = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            dataAccessorEntity.Phone = Console.ReadLine();

            var result = dataAccessorDemoDAL.UpdateEmployee(dataAccessorEntity);

            if (result.IsValid)
            {
                Console.WriteLine(result.Message[0]);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void DeleteEmployee()
        {

            Console.Clear();
            IDataAccessorDemoDAL dataAccessorDemoDAL = new DataAccessorDemoDAL();
            DataAccessorEntity dataAccessorEntity = new DataAccessorEntity();

            Console.WriteLine("Enter employee ID:");
            var empID = Console.ReadLine();
            dataAccessorEntity.EmpID = empID == null ? Guid.Empty : Guid.Parse(empID);

            var result = dataAccessorDemoDAL.DeleteEmployee(dataAccessorEntity.EmpID);

            if (result.IsValid)
            {
                Console.WriteLine(result.Message[0]);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void ListEmployee()
        {
            Console.Clear();
            IDataAccessorDemoDAL dataAccessorDemoDAL = new DataAccessorDemoDAL();
            DataAccessorEntity dataAccessorEntity = new DataAccessorEntity();

            var empList = dataAccessorDemoDAL.GetEmployeeList();

            if (empList.Count == 0)
                Console.WriteLine("No records found");

            foreach (var emp in empList)
            {
                Console.WriteLine("Employee ID: " + emp.EmpID);
                Console.WriteLine("Employee Name: " + emp.Name);
                Console.WriteLine("Employee Address:" + emp.Address);
                Console.WriteLine("Employee Email: " + emp.EMail);
                Console.WriteLine("Employee Phone: " + emp.Phone);

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
