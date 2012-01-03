using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierController.KFCService;

namespace CashierController
{

    /*
     * Description: 
     * Input: 
     * Output: 
     *          
     * Author:
     * Note:
     */
    public class EmployeeCTL
    {
        /*
         * Description: get employee id and permission
         * Input: username, password
         * Output: get employeeId (string[0]) and permission (string[1])
         * Author:
         * Note:
         */
        public string[] getEmpIdAndPermission(string username, string password)
        {
            return null;
        }

        /*
         * Description: check manager position 
         * Input: employee id
         * Output: employee id          
         * Author:
         * Note:
         */

        public bool checkManagerPermission (string empId)
        {
            return true;
        }

        public string checkCashierPermission(string username, string password)
        {
            return null ;
        }

        public string getEmployeeName(string empId)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                //return ws.getEmployeeName(empId);
                return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
