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
         * Description: check manager position 
         * Input: employee id
         * Output: employee id          
         * Author:
         * Note:
         */

        public bool checkManagerPermission (string empId)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                string permission = ws.getPermission(empId);
                if (permission == "AllPermission")
                    return true;
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string checkCashierPermission(string username, string password)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                string[] info = ws.getEmpIdAndPermission(username, password);
                if (info != null && (info[1] == "CashierPermission" || info[1] == "AllPermission"))
                {
                    return info[0];
                }
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string getEmployeeName(string empId)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                return ws.getEmployeeName(empId);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
