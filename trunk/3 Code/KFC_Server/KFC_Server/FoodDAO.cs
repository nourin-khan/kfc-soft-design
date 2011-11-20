using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;

namespace KFC_Server
{
    public class FoodDAO
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
        public int add(FoodDTO foodDTO)
        {
            return 0;
        }

        /* 
        * Description: delete food, commit to database
        * Input: FoodDTO - food object, or foodID
        * Output: int - number of rows affected
        * Author:
        */
        public int delete(FoodDTO foodDTO)
        {
            return 0;
        }

        public int delete(string foodID)
        {
            return 0;
        }

        /* 
        * Description: update new information of food into database
        * Input: @ oldInfo - food obj with old information (old foodID)
         *       @ newInfo - new information
         *       @ oldFoodID - old foodID
        * Output: int - number of rows affected
        * Author:
        */
        public int update(FoodDTO oldInfo, FoodDTO newInfo)
        {
            return 0;
        }
        public int update(string oldFoodID, FoodDTO newInfo)
        {
            return 0;
        }

        /* 
         * Description: select list of food, or one food information
         * Input: @foodDTO - food obj, null when you want to select all food
         *          @foodID
         * Output: FoodDTO[] - list of food satisfied the requirement
         * Author:
         */
        public FoodDTO[] selectInfo(FoodDTO foodDTO = null)
        {
            return null;
        }

        public FoodDTO[] selectInfo(string foodID)
        {
            return null;
        }
        #endregion

    }
}
