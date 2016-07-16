using System;
using System.Collections.Generic;

namespace AF.DataAccessor.Sample
{

    public interface IDataAccessorDemoDAL
    {
        Result AddEmployee(DataAccessorEntity employeeData);

        Result UpdateEmployee(DataAccessorEntity employeeData);

        Result DeleteEmployee(Guid empID);

        List<DataAccessorEntity> GetEmployeeList();
    }
}
