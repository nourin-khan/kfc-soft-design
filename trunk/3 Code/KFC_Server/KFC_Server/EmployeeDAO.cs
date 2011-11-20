using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;

namespace KFC_Server
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
            return null;
        }

        /* 
         * Description: get employee Id from name
         * Input: empName - employee name
         * Output: employee ID
         * Author:
         */
        public string getEmployeeID(string empName)
        {
            return null;
        }

    }
}
