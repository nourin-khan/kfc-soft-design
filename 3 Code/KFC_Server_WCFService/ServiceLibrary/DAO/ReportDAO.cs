using System;
using System.Data;

namespace ServiceLibrary
{
    public class ReportDAO
    {
        public class ReportDTO
        {
        }

        public class DailyReport : ReportDTO
        {
            
        }

        public class WeeklyReport : ReportDTO
        {
        }

        public class MonthlyReport : ReportDTO
        {
        }

        public int getTotalOfDay(DateTime billDate)
            {
                SQLConnection db = new SQLConnection();
                try
                {
                    DataTable data = db.ThucThiCauTruyVan_TraVeBang("SET DATEFORMAT MDY; SELECT SUM(b.Total) as ToTal FROM dbo.BILL b WHERE DATEDIFF(d,b.BillDate,'" + billDate.Date.ToShortDateString() + "') = 0");
                    if(!string.IsNullOrEmpty(data.Rows[0]["Total"].ToString()))
                    {
                        return int.Parse(data.Rows[0]["Total"].ToString());
                    }
                    else
                        return 0;
                }
                catch (System.Exception ex)
                {
                	throw ex;
                }        
            }

        public DataTable getDailyReport(DateTime billDate)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                DataTable data =  db.ThucThiCauTruyVan_TraVeBang("SET DATEFORMAT MDY;"
                    + " SELECT foo.FoodID, foo.FoodName, foo2.Quantity, foo2.quantity*(foo.FoodPrice - foo.DiscountPrice) AS Total FROM dbo.FOOD foo JOIN (" +
                    " SELECT ordDel.FoodID, COUNT (ordDel.FoodID) AS quantity FROM dbo.BILL bill JOIN dbo.ORDER_ ord ON (bill.OrderID = ord.OrderID) JOIN dbo.ORDER_DETAIL ordDel ON (ord.OrderID = ordDel.OrderID) " +
                    " WHERE DATEDIFF(d,bill.BillDate,'" + billDate.Date.ToShortDateString() + "') = 0" +
                    " GROUP BY ordDel.FoodID) AS foo2 ON (foo.FoodID = foo2.FoodID) ");
                return data;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int getTotalOfMonth(DateTime billDate)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                DataTable data = db.ThucThiCauTruyVan_TraVeBang("SET DATEFORMAT MDY; " + 
                                                                " SELECT SUM(b.Total) " + 
                                                                " FROM dbo.BILL b WHERE DATEDIFF(M,b.BillDate,'" + billDate.Date.ToShortDateString() + "') = 0");
                if(!string.IsNullOrEmpty(data.Rows[0]["Total"].ToString()))
                    {
                        return int.Parse(data.Rows[0]["Total"].ToString());
                    }
                    else
                        return 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMonthlyReport(DateTime billDate)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                return db.ThucThiCauTruyVan_TraVeBang("SET DATEFORMAT MDY; " + 
                                                        " SELECT DISTINCT DATENAME(d,bill.BillDate) + '/' + (CAST(MONTH(bill.BillDate) AS VARCHAR(2))) +'/' + DATENAME(yy,bill.BillDate) AS BillDate, dat.Total " + 
                                                        " FROM dbo.BILL bill, (SELECT DAY(b.BillDate) AS d, MONTH(b.BillDate) AS m, YEAR(b.BillDate) AS y, SUM(b.Total) AS Total " + 
						                                                        " FROM dbo.BILL b " +
                                                                                " WHERE DATEDIFF(M, b.BillDate, '" + billDate.Date.ToShortDateString() + "')=0 " +
						                                                        " GROUP BY DAY(b.BillDate), MONTH(b.BillDate), YEAR(b.BillDate)) AS dat " + 
                                                        " WHERE DAY(bill.BillDate) = dat.d AND MONTH(bill.BillDate) = dat.m AND YEAR( bill.BillDate)=dat.y "); 
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public int getTotalOfYear(DateTime billDate)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                DataTable data = db.ThucThiCauTruyVan_TraVeBang("SET DATEFORMAT MDY; " +
                                                                " SELECT SUM(b.Total) " +
                                                                " FROM dbo.BILL b WHERE DATEDIFF(yy,b.BillDate,'" + billDate.Date.ToShortDateString() + "') = 0"); 
                if(!string.IsNullOrEmpty(data.Rows[0]["Total"].ToString()))
                    {
                        return int.Parse(data.Rows[0]["Total"].ToString());
                    }
                    else
                        return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable getYearlyReport(DateTime billDate)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                return db.ThucThiCauTruyVan_TraVeBang(" SET DATEFORMAT MDY; " +
                                                        " SELECT DISTINCT(CAST(MONTH(bill.BillDate) AS VARCHAR(2))) +'/' + DATENAME(yy,bill.BillDate) AS BillDate, dat.Total " + 
                                                        " FROM dbo.BILL bill, (SELECT MONTH(b.BillDate) AS m, YEAR(b.BillDate) AS y, SUM(b.Total) AS Total " + 
						                                                        " FROM dbo.BILL b " +
                                                                                " WHERE DATEDIFF(yy, b.BillDate, '" + billDate.Date.ToShortDateString() + "')=0 " + 
						                                                        " GROUP BY MONTH(b.BillDate), YEAR(b.BillDate)) AS dat " + 
                                                        " WHERE MONTH(bill.BillDate) = dat.m AND YEAR( bill.BillDate)=dat.y ");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
