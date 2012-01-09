using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ReportDTO
    {
    }

    public class DailyReportDTO : ReportDTO
    {
        #region Attribute
        private string _foodID;
        private string _foodName;
        private int _quantity;
        private int _total;

        public string foodID
        {
            get { return _foodID; }
            set { _foodID = value; }
        }

        public string foodName
        {
            get { return _foodName; }
            set { _foodName = value; }
        }

        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public int total
        {
            get { return _total; }
            set { _total = value; }
        }

        #endregion
    }

    public class YearlyReportDTO : ReportDTO
    {
        #region Attribute
        private string _billDate;
        private int _total;

        public int total
        {
            get { return _total; }
            set { _total = value; }
        }
        public string billDate
        {
            get { return _billDate; }
            set { _billDate = value; }
        }
        #endregion
    }

    public class MonthlyReportDTO : ReportDTO
    {
        #region Attribute
        private string _billDate;
        private int _total;

        public int total
        {
            get { return _total; }
            set { _total = value; }
        }
        public string billDate
        {
            get { return _billDate; }
            set { _billDate = value; }
        }
        #endregion
    }
    
}
