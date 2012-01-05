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

        /* 
         * Description: get employee Id and permission
         * Input: username, password
         * Output: employee ID (string[0]) and permission (string[1])
         * Author:
         */
        public string[] getEmpIdAndPermission(string username, string password)
        {
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                //var query = from e in db.EMPLOYEEs
                //            join p in db.PERMISSIONs on e.PositionID equals p.PositionID
                //            where e.Username == username && e.Password == password
                //            select new { e.EmpID, p.Permission1 };
                var query = db.EMPLOYEEs.Join(
                        db.PERMISSIONs,
                        e => e.PositionID,
                        p => p.PositionID,
                        (e, p) => new { e.EmpID, e.Username, e.Password, p.Permission1 }
                    )
                    .Where(condition => condition.Username == username && condition.Password == password)
                    .Select(row => new { row.EmpID, row.Permission1 });
                var obj = query.SingleOrDefault();
                if (obj == null)
                {
                    throw new Exception("Username and password doesn't exists on database");
                }
                else
                {
                    return new string[] { obj.EmpID, obj.Permission1 };
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /* 
         * Description: get permission
         * Input: employee
         * Output: permission
         * Author:
         */
        public string getPermission(string empId)
        {
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                var query = db.EMPLOYEEs.Join(
                        db.PERMISSIONs,
                        e => e.PositionID,
                        p => p.PositionID,
                        (e, p) => new { e.EmpID, p.Permission1 }
                    )
                    .Where(condition => condition.EmpID == empId)
                    .Select(result => result.Permission1);
                
                if (query != null)
                {
                    return query.Single();
                } 
                else
                {
                    throw new Exception("Employee id " + empId + "doesn't exists on database");
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
