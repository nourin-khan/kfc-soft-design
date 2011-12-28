using System;
using System.Web;
using System.ComponentModel;
using DTO;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace ServiceLibrary
{
    public class BillDAO
    {
        /* 
        * Description: add new bill to database
        * Input: BillDTO - bill object
        * Output: int - number of rows affected
        * Author:
        */
        public bool insert(BillDTO info)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext();

            try
            {
                BILL bill = new BILL();
                bill.BillID = info.BillID;
                bill.BillDate = info.BillDate;
                bill.Total = (int)info.Total;
                bill.BillStatus = info.BillStatus;
                bill.DeleteNote = info.DeleteNode;
                bill.EmpID = info.EmpID;
                bill.OrderID = info.OrderID;

                db.BILLs.InsertOnSubmit(bill);
                db.SubmitChanges();
                successfull = true;
            }
            catch
            {
                successfull = false;
            }
            return successfull;
        }

        /* 
        * Description: delete bill, commit to database
        * Input: BillDTO - bill object, or billID
        * Output: int - number of rows affected
        * Author:
        */
        public bool delete(BillDTO info )
        {
            bool successfull = false;

            var db = new KFCDatabaseClassesDataContext();
            try
            {
                var bill = db.BILLs.SingleOrDefault(b => b.BillID == info.BillID);
                if (bill != null)
                {
                    // mark the food for deletion
                    db.BILLs.DeleteOnSubmit(bill);
                    db.SubmitChanges();

                    successfull = true;
                }
            }
            catch 
            {
                successfull = false;
            }
            return successfull;
        }

        public bool delete(string billID)
        {
            bool successfull = false;

            var db = new KFCDatabaseClassesDataContext();
            try
            {
                var bill = db.BILLs.SingleOrDefault(b => b.BillID == billID);
                if (bill != null)
                {
                    // mark the food for deletion
                    db.BILLs.DeleteOnSubmit(bill);
                    db.SubmitChanges();

                    successfull = true;
                }
            }
            catch 
            {
                successfull = false;
            }
            return successfull;
        }

        /* 
        * Description: update new information of bill into database
        * Input: @ oldInfo - bill obj with old information (old billID)
         *       @ newInfo - new information
         *       @ oldBillID - old billID
        * Output: void
        * Author:
        */
        public bool update(BillDTO info)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext();
            try
            {
                var bill = db.BILLs.SingleOrDefault(b => b.BillID == info.BillID);
                if (bill != null)
                {
                    bill.BillID = info.BillID;
                    bill.BillDate = info.BillDate;
                    bill.Total = (int)info.Total;
                    bill.BillStatus = info.BillStatus;
                    bill.DeleteNote = info.DeleteNode;
                    bill.EmpID = info.EmpID;
                    bill.OrderID = info.OrderID;
                    db.SubmitChanges();
                    successfull = true;
                }
            }
            catch
            {
                successfull = false;
            }
            return successfull;
        }

        /* 
         * Description: select list of bill, or one bill information
         * Input: @billDTO - bill obj, null when you want to select all bill
         *          @billID
         * Output: BillDTO[] - list of bill satisfied the requirement
         * Author:
         */
        public BillDTO[] selectInfo(BillDTO info)
        {
            var db = new KFCDatabaseClassesDataContext();
            try
            {
                if (info == null)
                {
                    var allBills = db.BILLs;
                    List<BillDTO> bills = new List<BillDTO>();
                    foreach(var bill in allBills)
                    {
                        BillDTO b = new BillDTO();
                        b.BillID = bill.BillID;
                        b.BillStatus = int.Parse(bill.BillStatus.ToString());
                        b.Total = (float)bill.Total;
                        b.BillDate = DateTime.Parse(bill.BillDate.ToString());
                        b.DeleteNode = bill.DeleteNote;
                        bill.EmpID = info.EmpID;
                        bill.OrderID = info.OrderID;
                        bills.Add(b);
                    }
                    return bills.ToArray();
                } 
                else
                {
                    var bill = db.BILLs.SingleOrDefault(b => b.BillID == info.BillID);
                    if (bill == null)
                    {
                        return null;
                    }
                    else 
                    {
                        List<BillDTO> bills = new List<BillDTO>();
                        // new bill
                        BillDTO b = new BillDTO();
                        b.BillID = bill.BillID;
                        b.BillStatus = int.Parse(bill.BillStatus.ToString());
                        b.Total = (float)bill.Total;
                        b.BillDate = DateTime.Parse(bill.BillDate.ToString());
                        b.DeleteNode = bill.DeleteNote;
                        bill.EmpID = info.EmpID;
                        bill.OrderID = info.OrderID;
                        bills.Add(b);
                        return bills.ToArray();
                    }
                }
            }
            catch
            {
            	return null;
            }
        }


        public BillDTO[] selectInfo(string billID)
        {
            return selectInfo(new BillDTO(billID));
        }
    }
}
