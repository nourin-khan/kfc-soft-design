using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierController;
using CashierController.KFCService;
using System.Data;

namespace CashierController
{
    public class ReportCTL
    {
        /*
         * Description: do report
         * Input:
         * Output:
         * Author:
         * Note: add more input when coding
         */
        virtual public void doReport()
        {

        }
    }

    public class DailyReport : ReportCTL
    {
        public int getTotalOfDay(DateTime billDate)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                return ws.getTotalOfDay(billDate);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getDailyReport(DateTime billDate)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                return ws.getDailyReport(billDate);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public class WeeklyReport : ReportCTL
    {
         public int getTotalOfMonth(DateTime billDate)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
             try
             {
                 return ws.getTotalOfMonth(billDate);
             }
             catch (System.Exception ex)
             {
                 throw ex;
             }
        }

        public DataTable getMonthlyReport(DateTime billDate)
         {
             ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                return ws.getMonthlyReport(billDate);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
         }
    }

    public class MonthlyReport : ReportCTL
    {
        public int getTotalOfYear(DateTime billDate)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                return ws.getTotalOfYear(billDate);
            }
            catch (System.Exception ex)
            {
            	throw ex;
            }
        }

         public DataTable getYearlyReport(DateTime billDate)
        {
            ServiceClient ws = ConnectionCTL.connectWebService();
            try
            {
                return ws.getYearlyReport(billDate);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
