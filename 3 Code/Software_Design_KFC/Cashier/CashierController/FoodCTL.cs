using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierDTO;

namespace CashierController
{
    public class FoodCTL
    {
        /*
         * Description: add new food
         * Input: foodDTO - food obj contains information of new food
         * Output: @true: successfully added
         *          @false: failed
         * Author:
         * Note:
         */
        public bool add(FoodDTO foodDTO)
        {
            return true;
        }

        /*
         * Description: delete food
         * Input: foodDTO - food obj, foodID - id of deleted food
         * Output: @true: successfully deleted
         *          @false: failed
         * Author:
         * Note:
         */
        public bool delete(FoodDTO foodDTO)
        {
            return true;
        }

        public bool delete(string foodID)
        {
            return true;
        }

        /* 
       * Description: update new information of food into database
       * Input: @ oldInfo - food obj with old information (old foodID)
        *       @ newInfo - new information
        *       @ oldFoodID - old foodID
       * Output: bool - @true: successfully updated
         *              @false: failed
       * Author:
       */
        public bool update(FoodDTO oldInfo, FoodDTO newInfo)
        {
            return true;
        }

        public bool update(string oldFoodID, FoodDTO newinfo)
        {
            return true;
        }

        /*
         * Description: view information of food
         * Input: FoodDTO - some information of food, string - foodId
         * Output: list of food information
         * Author:
         * Note:
         */
        public FoodDTO[] viewFoodInfo(FoodDTO foodInfo)
        {
            return null;
        }
        public FoodDTO[] viewFoodInfo(string foodID)
        {
            return null;
        }

        /*
        * Description: get price of food
        * Input: FoodDTO - some information of food, string - foodId
        * Output: list of food information
        * Author:
        * Note:
        */
        public int getFoodPrice(FoodDTO foodInfo)
        {
            return 0;
        }
        public int getFoodPrice(string foodID)
        {
            return 0;
        }
    }
}
