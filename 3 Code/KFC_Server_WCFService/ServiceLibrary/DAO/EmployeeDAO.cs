using System;
using System.ComponentModel;
using DTO;
using System.Linq;

namespace ServiceLibrary
{
    public class EmployeeDAO
    {
        /* 
         * Description: check for Permission of an employee
         * Input:
         * Output: bool - @true: have permission
         *              @false: do not have permission to do it
         * Author:
         * Note: think about the input
         */
        public bool checkForPermission()
        {
            return true;
        }

        /* 
         * Description: get employee name from empID
         * Input: empID - employee id
         * Output: name of employee 
         * Author:
         */
        public string getEmployeeName(string empID)
        {
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                var emp = db.EMPLOYEEs.SingleOrDefault(e => e.EmpID == empID);
                return (emp != null ? emp.Username : string.Empty);
            }
            catch
            {
                return string.Empty;
            }
        }

        /* 
         * Description: get employee Id from name
         * Input: empName - employee name
         * Output: employee ID
         * Author:
         */
        public string getEmployeeID(string empName)
        {
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                var emp = db.EMPLOYEEs.SingleOrDefault(e => e.EmpID == empName);
                return (emp != null ? emp.EmpID : string.Empty);
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
