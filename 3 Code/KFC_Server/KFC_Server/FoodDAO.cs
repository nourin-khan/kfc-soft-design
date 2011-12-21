using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace KFC_Server
{
    public class FoodDAO : SQLConnectionDAO
    {
        /* 
         * Description:
         * Input:
         * Output:
         * Author:
         */
        #region Method
        
        /* 
        * Description: add new food to database
        * Input: FoodDTO - food object
        * Output: int - number of rows affected
        * Author:
        */
        public void insert(FoodDTO foodDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: delete food, commit to database
        * Input: FoodDTO - food object, or foodID
        * Output: int - number of rows affected
        * Author:
        */
        public void delete(FoodDTO foodDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        public void delete(string foodID)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: update new information of food into database
        * Input: @ oldInfo - food obj with old information (old foodID)
         *       @ newInfo - new information
         *       @ oldFoodID - old foodID
        * Output: int - number of rows affected
        * Author:
        */
        public void update(FoodDTO newInfo)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }
        /* 
         * Description: select list of food, or one food information
         * Input: @foodDTO - food obj, null when you want to select all food
         *          @foodID
         * Output: FoodDTO[] - list of food satisfied the requirement
         * Author:
         */
        public FoodDTO[] selectInfo(FoodDTO info = null)
        {
            string cmd = "";
            if (info == null)
            {
                // select all
                cmd = "";
            }
            else
            {
                // select
                cmd = "";
            }
            connect();
            adapter = new SqlDataAdapter(cmd, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            DataTable dt = dataset.Tables[0];
            int i, n = dt.Rows.Count;
            FoodDTO[] arr = new FoodDTO[n];
            for (i = 0; i < n; i++)
            {
                object bill = GetDataFromDataRow(dt, i);
                arr[i] = bill as FoodDTO;
            }
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            FoodDTO food = new FoodDTO();
            return food;
        }

        public FoodDTO[] selectInfo(string foodID)
        {
            return null;
        }
        #endregion

    }
}
