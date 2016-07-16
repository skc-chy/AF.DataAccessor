using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Architecture.Foundation.DataAccessor;
using Architecture.Foundation.DataAccessor.SqlClient;

namespace AF.DataAccessor.Sample
{
    /// <summary>
    /// Add attribute 'AFDataStore' and pass connection key defined in configuration XML name 'Database.xml'
    /// Inherit class 'AFDataStoreAccessor'
    /// </summary>
    /// 

    [AFDataStore("AF")]
    public class DataAccessorDemoDAL : AFDataStoreAccessor, IDataAccessorDemoDAL
    {

        public Result AddEmployee(DataAccessorEntity employeeData)
        {
            var result = new Result() { IsValid = false };

            StoreProcedureCommand procedure = CreateProcedureCommand("dbo.InsertEmployee");
            procedure.AppendGuid("EmpID", employeeData.EmpID);
            procedure.AppendNVarChar("Name", employeeData.Name);
            procedure.AppendNVarChar("Address", employeeData.Address);
            procedure.AppendNVarChar("EMail", employeeData.EMail);
            procedure.AppendNVarChar("Phone", employeeData.Phone);

            int resultValue = ExecuteCommand(procedure);

            if (resultValue == 0)
            {
                result.IsValid = true;
                result.Message = new List<string> { "Employee added successfully" };
            }

            return result;
        }

        public Result UpdateEmployee(DataAccessorEntity employeeData)
        {
            var result = new Result() { IsValid = false };

            StoreProcedureCommand procedure = CreateProcedureCommand("dbo.UpdateEmployee","AF");
            procedure.AppendGuid("EmpID", employeeData.EmpID);
            procedure.AppendNVarChar("Address", employeeData.Address);
            procedure.AppendNVarChar("EMail", employeeData.EMail);
            procedure.AppendNVarChar("Phone", employeeData.Phone);

            int resultValue = ExecuteCommand(procedure);

            if (resultValue == 0)
            {
                result.IsValid = true;
                result.Message = new List<string> { "Employee updated successfully" };
            }

            return result;
        }

        public Result DeleteEmployee(Guid empID)
        {
            var result = new Result() { IsValid = false };

            StoreProcedureCommand procedure = CreateProcedureCommand("dbo.DeleteEmployee","AF");
            procedure.AppendGuid("EmpID", empID);

            int resultValue = ExecuteCommand(procedure);

            if (resultValue == 0)
            {
                result.IsValid = true;
                result.Message = new List<string> { "Employee deleted successfully" };
            }

            return result;
        }

        public List<DataAccessorEntity> GetEmployeeList()
        {
            var empList = new List<DataAccessorEntity>();

            SqlDataReader reader = null;

            try
            {
                StoreProcedureCommand procedure = CreateProcedureCommand("dbo.GetEmployee","AF");
                reader = ExecuteCommandAndReturnDataReader(procedure);

                while (reader.Read())
                    empList.Add(new DataAccessorEntity { EmpID = new Guid(reader["EmpID"].ToString()), Name = reader["Name"].ToString(), Address = reader["Address"].ToString(), EMail = reader["EMail"].ToString(), Phone = reader["Phone"].ToString() });

                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                throw ex;
            }

            return empList;
        }
    }
}
