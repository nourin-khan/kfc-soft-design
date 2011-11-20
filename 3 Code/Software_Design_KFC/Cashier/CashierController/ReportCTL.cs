using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }

    public class WeeklyReport : ReportCTL
    {
    }

    public class MonthlyReport : ReportCTL
    {
    }
}
