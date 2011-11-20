using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;

namespace KFC_Server
{
    public class FoodGroupDAO
    {
        #region Method

        /* 
        * Description: add new foodGroup to database
        * Input: FoodGroupDTO - foodGroup object
        * Output: int - number of rows affected
        * Author:
        */
        public int add(FoodGroupDTO foodGroupDTO)
        {
            return 0;
        }

        /* 
        * Description: delete foodGroup, commit to database
        * Input: FoodGroupDTO - foodGroup object, or foodGroupID
        * Output: int - number of rows affected
        * Author:
        */
        public int delete(FoodGroupDTO foodGroupDTO)
        {
            return 0;
        }

        public int delete(string foodGroupID)
        {
            return 0;
        }

        /* 
        * Description: update new information of foodGroup into database
        * Input: @ oldInfo - foodGroup obj with old information (old foodGroupID)
         *       @ newInfo - new information
         *       @ oldFoodGroupID - old foodGroupID
        * Output: int - number of rows affected
        * Author:
        */
        public int update(FoodGroupDTO oldInfo, FoodGroupDTO newInfo)
        {
            return 0;
        }
        public int update(string oldFoodGroupID, FoodGroupDTO newInfo)
        {
            return 0;
        }

        /* 
         * Description: select list of foodGroup, or one foodGroup information
         * Input: @foodGroupDTO - foodGroup obj, null when you want to select all foodGroup
         *          @foodGroupID
         * Output: FoodGroupDTO[] - list of foodGroup satisfied the requirement
         * Author:
         */
        public FoodGroupDTO[] selectInfo(FoodGroupDTO foodGroupDTO = null)
        {
            return null;
        }

        public FoodGroupDTO[] selectInfo(string foodGroupID)
        {
            return null;
        }
        #endregion
    }

}
