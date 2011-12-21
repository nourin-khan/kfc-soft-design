using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace KFC_Server
{
    public class FoodGroupDAO : SQLConnectionDAO
    {
        #region Method

        /* 
        * Description: add new foodGroup to database
        * Input: FoodGroupDTO - foodGroup object
        * Output: int - number of rows affected
        * Author:
        */
        public void insert(FoodGroupDTO foodGroupDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: delete foodGroup, commit to database
        * Input: FoodGroupDTO - foodGroup object, or foodGroupID
        * Output: int - number of rows affected
        * Author:
        */
        public void delete(FoodGroupDTO foodGroupDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        public void delete(string foodGroupID)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: update new information of foodGroup into database
        * Input: @ oldInfo - foodGroup obj with old information (old foodGroupID)
         *       @ newInfo - new information
         *       @ oldFoodGroupID - old foodGroupID
        * Output: int - number of rows affected
        * Author:
        */
        public void update(FoodGroupDTO newInfo)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }
       

        /* 
         * Description: select list of foodGroup, or one foodGroup information
         * Input: @foodGroupDTO - foodGroup obj, null when you want to select all foodGroup
         *          @foodGroupID
         * Output: FoodGroupDTO[] - list of foodGroup satisfied the requirement
         * Author:
         */
        public FoodGroupDTO[] selectInfo(FoodGroupDTO info = null)
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
            FoodGroupDTO[] arr = new FoodGroupDTO[n];
            for (i = 0; i < n; i++)
            {
                object bill = GetDataFromDataRow(dt, i);
                arr[i] = bill as FoodGroupDTO;
            }
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            FoodGroupDTO group = new FoodGroupDTO();
            return group;
        }

        public FoodGroupDTO[] selectInfo(string foodGroupID)
        {
            return null;
        }
        #endregion
    }

}
